<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetImageSizes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblProjectFile = New System.Windows.Forms.Label()
        Me.lblConnectionString = New System.Windows.Forms.Label()
        Me.txtConnectionString = New System.Windows.Forms.TextBox()
        Me.txtProjectFile = New System.Windows.Forms.TextBox()
        Me.btnResize = New System.Windows.Forms.Button()
        Me.lbxResultList = New System.Windows.Forms.ListBox()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.lblResultsText = New System.Windows.Forms.Label()
        Me.lblMinWidth = New System.Windows.Forms.Label()
        Me.lblMinHeight = New System.Windows.Forms.Label()
        Me.txtMinWidth = New System.Windows.Forms.TextBox()
        Me.txtMinHeight = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.lblProjectFile.AutoSize = True
        Me.lblProjectFile.Location = New System.Drawing.Point(51, 40)
        Me.lblProjectFile.Name = "lblProjectFile"
        Me.lblProjectFile.Size = New System.Drawing.Size(56, 13)
        Me.lblProjectFile.TabIndex = 0
        Me.lblProjectFile.Text = "ProjectFile"
        '
        'Label1
        '
        Me.lblConnectionString.AutoSize = True
        Me.lblConnectionString.Location = New System.Drawing.Point(23, 15)
        Me.lblConnectionString.Name = "lblConnectionString"
        Me.lblConnectionString.Size = New System.Drawing.Size(84, 13)
        Me.lblConnectionString.TabIndex = 1
        Me.lblConnectionString.Text = "ConnectionString"
        '
        'ConnectionString
        '
        Me.txtConnectionString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionString.Location = New System.Drawing.Point(113, 12)
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.Size = New System.Drawing.Size(516, 20)
        Me.txtConnectionString.TabIndex = 2
        Me.txtConnectionString.Text = "Data Source=192.168.0.15; Initial Catalog=Demo; User ID=sa; Passwo" &
    "rd=qaz123; Persist Security Info=True;Min Pool Size=20;Max Pool Size=200;"
        '
        'ProjectFile
        '
        Me.txtProjectFile.Location = New System.Drawing.Point(113, 37)
        Me.txtProjectFile.Name = "ProjectFile"
        Me.txtProjectFile.Size = New System.Drawing.Size(274, 20)
        Me.txtProjectFile.TabIndex = 3
        Me.txtProjectFile.Text = "\\SAPP1\Websites\DemoSite"
        '
        'Resize
        '
        Me.btnResize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResize.Location = New System.Drawing.Point(554, 113)
        Me.btnResize.Name = "Resize"
        Me.btnResize.Size = New System.Drawing.Size(75, 23)
        Me.btnResize.TabIndex = 4
        Me.btnResize.Text = "Resize"
        Me.btnResize.UseVisualStyleBackColor = True
        '
        'ResultList
        '
        Me.lbxResultList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxResultList.FormattingEnabled = True
        Me.lbxResultList.Location = New System.Drawing.Point(113, 139)
        Me.lbxResultList.Name = "lbxResultList"
        Me.lbxResultList.Size = New System.Drawing.Size(516, 277)
        Me.lbxResultList.TabIndex = 11
        '
        'Label7
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Location = New System.Drawing.Point(71, 118)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(37, 13)
        Me.lblResults.TabIndex = 12
        Me.lblResults.Text = "Result"
        '
        'ResultText
        '
        Me.lblResultsText.AutoSize = True
        Me.lblResultsText.Location = New System.Drawing.Point(114, 118)
        Me.lblResultsText.Name = "ResultText"
        Me.lblResultsText.Size = New System.Drawing.Size(0, 13)
        Me.lblResultsText.TabIndex = 13
        '
        'Label3
        '
        Me.lblMinWidth.AutoSize = True
        Me.lblMinWidth.Location = New System.Drawing.Point(51, 79)
        Me.lblMinWidth.Name = "lblMinWidth"
        Me.lblMinWidth.Size = New System.Drawing.Size(52, 13)
        Me.lblMinWidth.TabIndex = 14
        Me.lblMinWidth.Text = "MinWidth"
        '
        'Label4
        '
        Me.lblMinHeight.AutoSize = True
        Me.lblMinHeight.Location = New System.Drawing.Point(171, 79)
        Me.lblMinHeight.Name = "lblMinHeight"
        Me.lblMinHeight.Size = New System.Drawing.Size(55, 13)
        Me.lblMinHeight.TabIndex = 15
        Me.lblMinHeight.Text = "MinHeight"
        '
        'MinWidth
        '
        Me.txtMinWidth.Location = New System.Drawing.Point(113, 76)
        Me.txtMinWidth.Name = "txtMinWidth"
        Me.txtMinWidth.Size = New System.Drawing.Size(35, 20)
        Me.txtMinWidth.TabIndex = 16
        Me.txtMinWidth.Text = "400"
        '
        'MinHeight
        '
        Me.txtMinHeight.Location = New System.Drawing.Point(232, 76)
        Me.txtMinHeight.Name = "txtMinHeight"
        Me.txtMinHeight.Size = New System.Drawing.Size(35, 20)
        Me.txtMinHeight.TabIndex = 17
        Me.txtMinHeight.Text = "257"
        '
        'SetImageSizes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 425)
        Me.Controls.Add(Me.txtMinHeight)
        Me.Controls.Add(Me.txtMinWidth)
        Me.Controls.Add(Me.lblMinHeight)
        Me.Controls.Add(Me.lblMinWidth)
        Me.Controls.Add(Me.lblResultsText)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.lbxResultList)
        Me.Controls.Add(Me.btnResize)
        Me.Controls.Add(Me.txtProjectFile)
        Me.Controls.Add(Me.txtConnectionString)
        Me.Controls.Add(Me.lblConnectionString)
        Me.Controls.Add(Me.lblProjectFile)
        Me.MaximizeBox = False
        Me.Name = "frmResizeImages"
        Me.Text = "Resize Images"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProjectFile As System.Windows.Forms.Label
    Friend WithEvents lblConnectionString As System.Windows.Forms.Label
    Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectFile As System.Windows.Forms.TextBox
    Friend WithEvents btnResize As System.Windows.Forms.Button
    Friend WithEvents lbxResultList As System.Windows.Forms.ListBox
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents lblResultsText As System.Windows.Forms.Label
    Friend WithEvents lblMinWidth As System.Windows.Forms.Label
    Friend WithEvents lblMinHeight As System.Windows.Forms.Label
    Friend WithEvents txtMinWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtMinHeight As System.Windows.Forms.TextBox

End Class
