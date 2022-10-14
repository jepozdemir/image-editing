Imports System.Data.SqlClient
Public Class CropImages
    Private oSqlConnection As SqlConnection
    Private oSqlCommand As SqlCommand
    Private oSqlDataAdapter As SqlDataAdapter
    Public ReadOnly Property SqlConnection As SqlConnection
        Get
            If Me.oSqlConnection Is Nothing Then
                Me.oSqlConnection = New SqlConnection
                Me.oSqlConnection.ConnectionString = txtConnectionString.Text
            End If
            Return Me.oSqlConnection
        End Get
    End Property
    Public ReadOnly Property SqlCommand As SqlCommand
        Get
            If Me.oSqlCommand Is Nothing Then Me.oSqlCommand = New SqlCommand
            Return Me.oSqlCommand
        End Get
    End Property
    Public ReadOnly Property SqlDataAdapter As SqlDataAdapter
        Get
            If Me.oSqlDataAdapter Is Nothing Then Me.oSqlDataAdapter = New SqlDataAdapter
            Return Me.oSqlDataAdapter
        End Get
    End Property
    Public Sub SqlOpen()
        If Me.SqlConnection.State = ConnectionState.Closed Then Me.SqlConnection.Open()
    End Sub
    Public Sub SqlClose()
        If Not Me.SqlConnection Is Nothing AndAlso Me.SqlConnection.State <> ConnectionState.Closed Then Me.SqlConnection.Close()
    End Sub
    Public Sub Lock()
        Me.btnResize.Enabled = False
        Me.txtConnectionString.Enabled = False
        Me.txtProjectFile.Enabled = False
    End Sub
    Public Sub UnLock()
        Me.btnResize.Enabled = True
        Me.txtConnectionString.Enabled = True
        Me.txtProjectFile.Enabled = True
    End Sub
    Public Function CropImage(ByVal Image As Drawing.Image, ByVal FilePath As String, ByRef Width As Integer, ByRef Height As Integer) As Drawing.Bitmap
        Dim SizedWidth, SizedHeight As Decimal
        SizedWidth = Image.Width
        SizedHeight = Image.Height
        If Image.Width > Width Then SizedWidth = Width
        If Image.Height > Height Then SizedHeight = Height

        Dim filter As New CodeCarvings.Piczard.FixedResizeConstraint(SizedWidth, SizedHeight)
        filter.ImagePosition = CodeCarvings.Piczard.FixedResizeConstraintImagePosition.Fill
        filter.CanvasColor = CodeCarvings.Piczard.BackgroundColor.GetStatic(System.Drawing.Color.White)
        If IO.File.Exists(FilePath) Then IO.File.Delete(FilePath)
        filter.SaveProcessedImageToFileSystem(Image, FilePath, New CodeCarvings.Piczard.JpegFormatEncoderParams(90))
        Return Nothing
    End Function
    Private Sub SaveImageMedias(ByVal FileName As String)
        If IO.File.Exists(FileName) Then
            Dim Image As Drawing.Image = Drawing.Image.FromFile(FileName)
            Dim Folder As String = IO.Path.GetDirectoryName(FileName).Replace("/Large", "").Replace("\Large", "")
            FileName = IO.Path.GetFileName(FileName)
            If Not IO.Directory.Exists(Folder & "/Small/") Then IO.Directory.CreateDirectory(Folder & "/Small/")
            If Not IO.Directory.Exists(Folder & "/Medium320/") Then IO.Directory.CreateDirectory(Folder & "/Medium320/")
            If Not IO.Directory.Exists(Folder & "/Medium480/") Then IO.Directory.CreateDirectory(Folder & "/Medium480/")
            If Not IO.Directory.Exists(Folder & "/Medium640/") Then IO.Directory.CreateDirectory(Folder & "/Medium640/")

            Dim ImageWidth As Integer = Image.Width
            Dim ImageHeight As Integer = Image.Height
            Dim ResizeBeForeCrop As Boolean = False
            If Image.Width > Image.Height Then
                If Image.Width > 5000 Then
                    ImageHeight = 5000 * ImageHeight / ImageWidth
                    ImageWidth = 5000
                    ResizeBeForeCrop = True
                End If
            Else
                If Image.Height > 5000 Then
                    ImageWidth = 5000 * ImageWidth / ImageHeight
                    ImageHeight = 5000
                    ResizeBeForeCrop = True
                End If
            End If
            If ResizeBeForeCrop Then
                Image = New Bitmap(Image, New Drawing.Size(ImageWidth, ImageHeight))
            End If
            Me.CropImage(Image, Folder & "/Small/" & FileName, 160, 160)
            Me.CropImage(Image, Folder & "/Medium320/" & FileName, 320, 320)
            Me.CropImage(Image, Folder & "/Medium480/" & FileName, 480, 480)
            Me.CropImage(Image, Folder & "/Medium640/" & FileName, 640, 640)
        End If
    End Sub
    Public Function GetImages(ByVal Type As Integer) As DataTable
        If Type = 0 Then
            Me.SqlCommand.CommandText = "SELECT [FilePath] FROM [Catalog_Image]"
        ElseIf Type = 1 Then
            Me.SqlCommand.CommandText = "SELECT [FileName] FROM [Community_MemberImage]"
        ElseIf Type = 2 Then
            Me.SqlCommand.CommandText = "SELECT [FileName] FROM [Journey_ContentImage]"
        End If
        Me.SqlDataAdapter.SelectCommand = Me.SqlCommand
        Dim DataTable As New DataTable
        Try
            Me.SqlCommand.Connection = Me.SqlConnection
            Me.SqlDataAdapter.Fill(DataTable)
        Catch ex As SqlException
            Throw ex
        Finally
            Me.oSqlCommand.Dispose()
            Me.oSqlCommand = Nothing
            Me.oSqlDataAdapter.Dispose()
            Me.oSqlDataAdapter = Nothing
        End Try
        Return DataTable
    End Function
    'Public Function UpdateImage(ByVal ImageID As Integer, ByVal Width As Integer, ByVal Height As Integer) As Boolean
    '    Me.SqlCommand.CommandText = "UPDATE [Catalog_Image] SET [Width] = @Width, [Height] = @Height WHERE [ImageID] = @ImageID"
    '    Me.SqlCommand.Parameters.Add("@ImageID", SqlDbType.Int).Value = ImageID
    '    Me.SqlCommand.Parameters.Add("@Width", SqlDbType.Int).Value = Width
    '    Me.SqlCommand.Parameters.Add("@Height", SqlDbType.Int).Value = Height
    '    Dim Result As Boolean = False
    '    Try
    '        Me.SqlCommand.Connection = Me.SqlConnection
    '        Me.SqlCommand.ExecuteNonQuery()
    '        Result = True
    '    Catch ex As SqlException
    '        Throw ex
    '    Finally
    '        Me.oSqlCommand.Dispose()
    '        Me.oSqlCommand = Nothing
    '    End Try
    '    Return Result
    'End Function
    Private Sub Process(ByVal Type As Integer)
        Dim ImageList As DataTable = Me.GetImages(Type)
        If Not ImageList Is Nothing AndAlso ImageList.Rows.Count > 0 Then
            Application.DoEvents()
            Dim RootFolder As String = ""
            Dim Column As String = "FilePath"
            If Type = 1 Then
                RootFolder = "\Data\Member\Images\Large\"
                Column = "FileName"
            ElseIf Type = 2 Then
                RootFolder = "\Data\Content\Images\Large\"
                Column = "FileName"
            End If
            Dim Width As Integer = 0
            Dim Height As Integer = 0
            For i As Integer = 0 To ImageList.Rows.Count - 1
                Application.DoEvents()
                lblResultsText.Text = (i + 1) & "/" & ImageList.Rows.Count
                Try
                    Me.SaveImageMedias(Me.txtProjectFile.Text & RootFolder & ImageList.Rows(i)(Column))
                Catch ex As Exception
                    lbxResultList.Items.Add(ex.Message & " " & ex.StackTrace)
                End Try
            Next
        End If
    End Sub
    Private Sub Resize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResize.Click
        Try
            Me.SqlOpen()
            Me.Lock()
            lbxResultList.Items.Clear()
            Me.Process(0)
            Me.Process(1)
            Me.Process(2)
            Me.UnLock()
            Me.SqlClose()
        Catch ex As Exception
            lbxResultList.Items.Add("ExceptionMessage=" & ex.Message)
        End Try
    End Sub
End Class
