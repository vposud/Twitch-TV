<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCacheEmotes = New System.Windows.Forms.CheckBox()
        Me.chkEmotes = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTwitchPass = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTwitchUser = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHistoryAmount = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFTPDirectory = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFTPPW = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFTPAccount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVLCPath = New System.Windows.Forms.TextBox()
        Me.btnSave = New Glass.GlassButton()
        Me.btnClose = New Glass.GlassButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCacheEmotes)
        Me.GroupBox1.Controls.Add(Me.chkEmotes)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTwitchPass)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtTwitchUser)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtHistoryAmount)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFTPDirectory)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFTPPW)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFTPAccount)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtVLCPath)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 264)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'chkCacheEmotes
        '
        Me.chkCacheEmotes.AutoSize = True
        Me.chkCacheEmotes.Location = New System.Drawing.Point(6, 242)
        Me.chkCacheEmotes.Name = "chkCacheEmotes"
        Me.chkCacheEmotes.Size = New System.Drawing.Size(95, 17)
        Me.chkCacheEmotes.TabIndex = 45
        Me.chkCacheEmotes.Text = "Cache Emotes"
        Me.chkCacheEmotes.UseVisualStyleBackColor = True
        '
        'chkEmotes
        '
        Me.chkEmotes.AutoSize = True
        Me.chkEmotes.Location = New System.Drawing.Point(6, 225)
        Me.chkEmotes.Name = "chkEmotes"
        Me.chkEmotes.Size = New System.Drawing.Size(98, 17)
        Me.chkEmotes.TabIndex = 44
        Me.chkEmotes.Text = "Display Emotes"
        Me.chkEmotes.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(1, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(295, 13)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "________________________________________________"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Twitch Password"
        '
        'txtTwitchPass
        '
        Me.txtTwitchPass.BackColor = System.Drawing.Color.Black
        Me.txtTwitchPass.ForeColor = System.Drawing.Color.White
        Me.txtTwitchPass.Location = New System.Drawing.Point(100, 188)
        Me.txtTwitchPass.Name = "txtTwitchPass"
        Me.txtTwitchPass.Size = New System.Drawing.Size(191, 20)
        Me.txtTwitchPass.TabIndex = 40
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 169)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Twitch Username"
        '
        'txtTwitchUser
        '
        Me.txtTwitchUser.BackColor = System.Drawing.Color.Black
        Me.txtTwitchUser.ForeColor = System.Drawing.Color.White
        Me.txtTwitchUser.Location = New System.Drawing.Point(100, 166)
        Me.txtTwitchUser.Name = "txtTwitchUser"
        Me.txtTwitchUser.Size = New System.Drawing.Size(191, 20)
        Me.txtTwitchUser.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "History Amount"
        '
        'txtHistoryAmount
        '
        Me.txtHistoryAmount.BackColor = System.Drawing.Color.Black
        Me.txtHistoryAmount.ForeColor = System.Drawing.Color.White
        Me.txtHistoryAmount.Location = New System.Drawing.Point(83, 129)
        Me.txtHistoryAmount.MaxLength = 3
        Me.txtHistoryAmount.Name = "txtHistoryAmount"
        Me.txtHistoryAmount.Size = New System.Drawing.Size(40, 20)
        Me.txtHistoryAmount.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(295, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "________________________________________________"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "FTP Directory"
        '
        'txtFTPDirectory
        '
        Me.txtFTPDirectory.BackColor = System.Drawing.Color.Black
        Me.txtFTPDirectory.ForeColor = System.Drawing.Color.White
        Me.txtFTPDirectory.Location = New System.Drawing.Point(79, 93)
        Me.txtFTPDirectory.Name = "txtFTPDirectory"
        Me.txtFTPDirectory.Size = New System.Drawing.Size(209, 20)
        Me.txtFTPDirectory.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "FTP PW"
        '
        'txtFTPPW
        '
        Me.txtFTPPW.BackColor = System.Drawing.Color.Black
        Me.txtFTPPW.ForeColor = System.Drawing.Color.White
        Me.txtFTPPW.Location = New System.Drawing.Point(79, 71)
        Me.txtFTPPW.Name = "txtFTPPW"
        Me.txtFTPPW.Size = New System.Drawing.Size(209, 20)
        Me.txtFTPPW.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "FTP Account"
        '
        'txtFTPAccount
        '
        Me.txtFTPAccount.BackColor = System.Drawing.Color.Black
        Me.txtFTPAccount.ForeColor = System.Drawing.Color.White
        Me.txtFTPAccount.Location = New System.Drawing.Point(79, 49)
        Me.txtFTPAccount.Name = "txtFTPAccount"
        Me.txtFTPAccount.Size = New System.Drawing.Size(209, 20)
        Me.txtFTPAccount.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(295, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "________________________________________________"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "VLC Path"
        '
        'txtVLCPath
        '
        Me.txtVLCPath.BackColor = System.Drawing.Color.Black
        Me.txtVLCPath.ForeColor = System.Drawing.Color.White
        Me.txtVLCPath.Location = New System.Drawing.Point(71, 14)
        Me.txtVLCPath.Name = "txtVLCPath"
        Me.txtVLCPath.Size = New System.Drawing.Size(217, 20)
        Me.txtVLCPath.TabIndex = 26
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.GlowColor = System.Drawing.Color.LawnGreen
        Me.btnSave.Location = New System.Drawing.Point(100, 268)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShineColor = System.Drawing.Color.Gray
        Me.btnSave.Size = New System.Drawing.Size(52, 22)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.GlowColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(158, 268)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShineColor = System.Drawing.Color.Gray
        Me.btnClose.Size = New System.Drawing.Size(52, 22)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "________________________________________________"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(310, 298)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As Glass.GlassButton
    Friend WithEvents btnClose As Glass.GlassButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVLCPath As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFTPPW As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFTPAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFTPDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHistoryAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTwitchPass As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTwitchUser As System.Windows.Forms.TextBox
    Friend WithEvents chkEmotes As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkCacheEmotes As CheckBox
End Class
