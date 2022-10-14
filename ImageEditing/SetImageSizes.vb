Imports System.Data.SqlClient
Public Class SetImageSizes
    Private oSqlConnection As SqlConnection
    Private oSqlCommand As SqlCommand
    Private oSqlDataAdapter As SqlDataAdapter
    Public ReadOnly Property SqlConnection As SqlConnection
        Get
            If oSqlConnection Is Nothing Then
                oSqlConnection = New SqlConnection
                oSqlConnection.ConnectionString = txtConnectionString.Text
            End If
            Return oSqlConnection
        End Get
    End Property
    Public ReadOnly Property SqlCommand As SqlCommand
        Get
            If oSqlCommand Is Nothing Then oSqlCommand = New SqlCommand
            Return oSqlCommand
        End Get
    End Property
    Public ReadOnly Property SqlDataAdapter As SqlDataAdapter
        Get
            If oSqlDataAdapter Is Nothing Then oSqlDataAdapter = New SqlDataAdapter
            Return oSqlDataAdapter
        End Get
    End Property
    Public Sub SqlOpen()
        If SqlConnection.State = ConnectionState.Closed Then SqlConnection.Open()
    End Sub
    Public Sub SqlClose()
        If Not SqlConnection Is Nothing AndAlso SqlConnection.State <> ConnectionState.Closed Then SqlConnection.Close()
    End Sub
    Public Sub Lock()
        btnResize.Enabled = False
        txtConnectionString.Enabled = False
        txtProjectFile.Enabled = False
    End Sub
    Public Sub UnLock()
        btnResize.Enabled = True
        txtConnectionString.Enabled = True
        txtProjectFile.Enabled = True
    End Sub
    Public Function GetImages() As DataTable
        SqlCommand.CommandText = "SELECT [FilePath], ImageID FROM [Catalog_Image]"
        SqlDataAdapter.SelectCommand = SqlCommand
        Dim DataTable As New DataTable
        Try
            SqlCommand.Connection = SqlConnection
            SqlDataAdapter.Fill(DataTable)
        Catch ex As SqlException
            Throw ex
        Finally
            oSqlCommand.Dispose()
            oSqlCommand = Nothing
            oSqlDataAdapter.Dispose()
            oSqlDataAdapter = Nothing
        End Try
        Return DataTable
    End Function
    Public Function UpdateImage(ByVal FileName As String, ImageID As Integer) As Boolean
        If IO.File.Exists(FileName) Then
            Dim Image As Drawing.Image = Drawing.Image.FromFile(FileName)

            SqlCommand.CommandText = "UPDATE [Catalog_Image] SET [Width] = @Width, [Height] = @Height, [IsActive] = @IsActive WHERE [ImageID] = @ImageID"
            SqlCommand.Parameters.Add("@ImageID", SqlDbType.Int).Value = ImageID
            SqlCommand.Parameters.Add("@Width", SqlDbType.Int).Value = Image.Width
            SqlCommand.Parameters.Add("@Height", SqlDbType.Int).Value = Image.Height
            If Image.Width < txtMinWidth.Text OrElse Image.Height < txtMinHeight.Text Then
                SqlCommand.Parameters.Add("@IsActive", SqlDbType.Int).Value = 0
            Else
                SqlCommand.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1
            End If
            Dim Result As Boolean = False
            Try
                SqlCommand.Connection = SqlConnection
                SqlCommand.ExecuteNonQuery()
                Result = True
            Catch ex As SqlException
                Throw ex
            Finally
                oSqlCommand.Dispose()
                oSqlCommand = Nothing
            End Try
            Return Result
        Else
            lbxResultList.Items.Add("Dosya bulunamadı - ImageID: " & ImageID & ", FileName: " & FileName)
            Return False
        End If
    End Function
    Private Sub Process(ByVal Type As Integer)
        Dim ImageList As DataTable = GetImages()
        If Not ImageList Is Nothing AndAlso ImageList.Rows.Count > 0 Then
            Application.DoEvents()
            Dim RootFolder As String = ""
            Dim Column As String = "FilePath"
            If Type = 1 Then
                RootFolder = "\Data\Content\Images\Large\"
            End If
            Dim Width As Integer = 0
            Dim Height As Integer = 0
            For i As Integer = 0 To ImageList.Rows.Count - 1
                Application.DoEvents()
                lblResultsText.Text = (i + 1) & "/" & ImageList.Rows.Count
                Try
                    UpdateImage(txtProjectFile.Text & RootFolder & ImageList.Rows(i)("FilePath"), ImageList.Rows(i)("ImageID"))
                Catch ex As Exception
                    lbxResultList.Items.Add(ex.Message & " " & ex.StackTrace)
                End Try
            Next
        End If
    End Sub
    Private Sub Resize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResize.Click
        Try
            SqlOpen()
            Lock()
            lbxResultList.Items.Clear()
            Process(0)
            Process(1)
            UnLock()
            SqlClose()
        Catch ex As Exception
            lbxResultList.Items.Add("ExceptionMessage=" & ex.Message)
        End Try
    End Sub
End Class
