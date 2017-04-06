<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lstStreams = New System.Windows.Forms.ListBox()
        Me.cmsInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyUrlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyTitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstStreamers = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmsTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnLoad = New Glass.GlassButton()
        Me.btnChat = New Glass.GlassButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnViewGames = New Glass.GlassButton()
        Me.btnSpeedRun = New Glass.GlassButton()
        Me.btnEditStreams = New Glass.GlassButton()
        Me.lblTimeCount = New System.Windows.Forms.Label()
        Me.ToolTip_lstStreams = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSettings = New Glass.GlassButton()
        Me.btnHistory = New Glass.GlassButton()
        Me.NotifyIcon2 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.btnRefresh = New Glass.GlassButton()
        Me.chkNotify = New System.Windows.Forms.CheckBox()
        Me.btnNonTwitch = New Glass.GlassButton()
        Me.btnFeatured = New Glass.GlassButton()
        Me.cmsInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstStreams
        '
        Me.lstStreams.BackColor = System.Drawing.Color.Black
        Me.lstStreams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstStreams.ContextMenuStrip = Me.cmsInfo
        Me.lstStreams.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStreams.ForeColor = System.Drawing.Color.White
        Me.lstStreams.FormattingEnabled = True
        Me.lstStreams.Location = New System.Drawing.Point(9, 3)
        Me.lstStreams.Name = "lstStreams"
        Me.lstStreams.Size = New System.Drawing.Size(449, 145)
        Me.lstStreams.TabIndex = 1
        '
        'cmsInfo
        '
        Me.cmsInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem, Me.CopyUrlToolStripMenuItem, Me.CopyTitleToolStripMenuItem})
        Me.cmsInfo.Name = "cmsInfo"
        Me.cmsInfo.Size = New System.Drawing.Size(129, 70)
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'CopyUrlToolStripMenuItem
        '
        Me.CopyUrlToolStripMenuItem.Name = "CopyUrlToolStripMenuItem"
        Me.CopyUrlToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CopyUrlToolStripMenuItem.Text = "Copy URL"
        '
        'CopyTitleToolStripMenuItem
        '
        Me.CopyTitleToolStripMenuItem.Name = "CopyTitleToolStripMenuItem"
        Me.CopyTitleToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CopyTitleToolStripMenuItem.Text = "Copy Title"
        '
        'lstStreamers
        '
        Me.lstStreamers.FormattingEnabled = True
        Me.lstStreamers.Location = New System.Drawing.Point(595, 36)
        Me.lstStreamers.Name = "lstStreamers"
        Me.lstStreamers.Size = New System.Drawing.Size(35, 30)
        Me.lstStreamers.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 180000
        '
        'cmsTray
        '
        Me.cmsTray.Name = "cmsTray"
        Me.cmsTray.Size = New System.Drawing.Size(61, 4)
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.Black
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.ForeColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Source", "High", "Medium", "Low", "Mobile"})
        Me.ComboBox1.Location = New System.Drawing.Point(94, 156)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(61, 21)
        Me.ComboBox1.TabIndex = 10
        '
        'btnLoad
        '
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.GlowColor = System.Drawing.Color.Cyan
        Me.btnLoad.Location = New System.Drawing.Point(9, 154)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.ShineColor = System.Drawing.Color.Gray
        Me.btnLoad.Size = New System.Drawing.Size(41, 22)
        Me.btnLoad.TabIndex = 11
        Me.btnLoad.Text = "Open"
        '
        'btnChat
        '
        Me.btnChat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChat.GlowColor = System.Drawing.Color.Cyan
        Me.btnChat.Location = New System.Drawing.Point(52, 154)
        Me.btnChat.Name = "btnChat"
        Me.btnChat.ShineColor = System.Drawing.Color.Gray
        Me.btnChat.Size = New System.Drawing.Size(37, 22)
        Me.btnChat.TabIndex = 12
        Me.btnChat.Text = "Chat"
        '
        'btnViewGames
        '
        Me.btnViewGames.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewGames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewGames.GlowColor = System.Drawing.Color.Cyan
        Me.btnViewGames.Location = New System.Drawing.Point(161, 155)
        Me.btnViewGames.Name = "btnViewGames"
        Me.btnViewGames.ShineColor = System.Drawing.Color.Gray
        Me.btnViewGames.Size = New System.Drawing.Size(74, 22)
        Me.btnViewGames.TabIndex = 17
        Me.btnViewGames.Text = "View Games"
        '
        'btnSpeedRun
        '
        Me.btnSpeedRun.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSpeedRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSpeedRun.GlowColor = System.Drawing.Color.Cyan
        Me.btnSpeedRun.Location = New System.Drawing.Point(238, 155)
        Me.btnSpeedRun.Name = "btnSpeedRun"
        Me.btnSpeedRun.ShineColor = System.Drawing.Color.Gray
        Me.btnSpeedRun.Size = New System.Drawing.Size(69, 22)
        Me.btnSpeedRun.TabIndex = 18
        Me.btnSpeedRun.Text = "Speed Run"
        '
        'btnEditStreams
        '
        Me.btnEditStreams.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditStreams.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditStreams.GlowColor = System.Drawing.Color.Cyan
        Me.btnEditStreams.Location = New System.Drawing.Point(310, 155)
        Me.btnEditStreams.Name = "btnEditStreams"
        Me.btnEditStreams.ShineColor = System.Drawing.Color.Gray
        Me.btnEditStreams.Size = New System.Drawing.Size(74, 22)
        Me.btnEditStreams.TabIndex = 19
        Me.btnEditStreams.Text = "Edit Streams"
        '
        'lblTimeCount
        '
        Me.lblTimeCount.AutoSize = True
        Me.lblTimeCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeCount.ForeColor = System.Drawing.Color.White
        Me.lblTimeCount.Location = New System.Drawing.Point(6, 206)
        Me.lblTimeCount.Name = "lblTimeCount"
        Me.lblTimeCount.Size = New System.Drawing.Size(144, 15)
        Me.lblTimeCount.TabIndex = 20
        Me.lblTimeCount.Text = "Time Until Next Refresh -"
        '
        'ToolTip_lstStreams
        '
        Me.ToolTip_lstStreams.AutoPopDelay = 5000
        Me.ToolTip_lstStreams.InitialDelay = 500
        Me.ToolTip_lstStreams.ReshowDelay = 100
        '
        'btnSettings
        '
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.GlowColor = System.Drawing.Color.Cyan
        Me.btnSettings.Location = New System.Drawing.Point(405, 155)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.ShineColor = System.Drawing.Color.Gray
        Me.btnSettings.Size = New System.Drawing.Size(53, 22)
        Me.btnSettings.TabIndex = 22
        Me.btnSettings.Text = "Settings"
        '
        'btnHistory
        '
        Me.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.GlowColor = System.Drawing.Color.Cyan
        Me.btnHistory.Location = New System.Drawing.Point(9, 180)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.ShineColor = System.Drawing.Color.Gray
        Me.btnHistory.Size = New System.Drawing.Size(47, 22)
        Me.btnHistory.TabIndex = 23
        Me.btnHistory.Text = "History"
        '
        'NotifyIcon2
        '
        Me.NotifyIcon2.ContextMenuStrip = Me.cmsTray
        Me.NotifyIcon2.Icon = CType(resources.GetObject("NotifyIcon2.Icon"), System.Drawing.Icon)
        Me.NotifyIcon2.Text = "Twitch"
        Me.NotifyIcon2.Visible = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Enabled = False
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.GlowColor = System.Drawing.Color.Cyan
        Me.btnRefresh.Location = New System.Drawing.Point(405, 180)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.ShineColor = System.Drawing.Color.Gray
        Me.btnRefresh.Size = New System.Drawing.Size(53, 22)
        Me.btnRefresh.TabIndex = 24
        Me.btnRefresh.Text = "Refresh"
        '
        'chkNotify
        '
        Me.chkNotify.AutoSize = True
        Me.chkNotify.Checked = True
        Me.chkNotify.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNotify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNotify.ForeColor = System.Drawing.Color.White
        Me.chkNotify.Location = New System.Drawing.Point(361, 208)
        Me.chkNotify.Name = "chkNotify"
        Me.chkNotify.Size = New System.Drawing.Size(97, 17)
        Me.chkNotify.TabIndex = 25
        Me.chkNotify.Text = "Notifications"
        Me.chkNotify.UseVisualStyleBackColor = True
        '
        'btnNonTwitch
        '
        Me.btnNonTwitch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNonTwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNonTwitch.GlowColor = System.Drawing.Color.Cyan
        Me.btnNonTwitch.Location = New System.Drawing.Point(58, 180)
        Me.btnNonTwitch.Name = "btnNonTwitch"
        Me.btnNonTwitch.ShineColor = System.Drawing.Color.Gray
        Me.btnNonTwitch.Size = New System.Drawing.Size(73, 22)
        Me.btnNonTwitch.TabIndex = 26
        Me.btnNonTwitch.Text = "New Stream"
        '
        'btnFeatured
        '
        Me.btnFeatured.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFeatured.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFeatured.GlowColor = System.Drawing.Color.Cyan
        Me.btnFeatured.Location = New System.Drawing.Point(133, 180)
        Me.btnFeatured.Name = "btnFeatured"
        Me.btnFeatured.ShineColor = System.Drawing.Color.Gray
        Me.btnFeatured.Size = New System.Drawing.Size(57, 22)
        Me.btnFeatured.TabIndex = 27
        Me.btnFeatured.Text = "Featured"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(464, 230)
        Me.Controls.Add(Me.btnFeatured)
        Me.Controls.Add(Me.btnNonTwitch)
        Me.Controls.Add(Me.chkNotify)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.lblTimeCount)
        Me.Controls.Add(Me.btnEditStreams)
        Me.Controls.Add(Me.btnSpeedRun)
        Me.Controls.Add(Me.btnViewGames)
        Me.Controls.Add(Me.btnChat)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lstStreamers)
        Me.Controls.Add(Me.lstStreams)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Twitch TV Viewer"
        Me.cmsInfo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstStreams As System.Windows.Forms.ListBox
    Friend WithEvents lstStreamers As System.Windows.Forms.ListBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoad As Glass.GlassButton
    Friend WithEvents btnChat As Glass.GlassButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmsTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnViewGames As Glass.GlassButton
    Friend WithEvents btnSpeedRun As Glass.GlassButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnEditStreams As Glass.GlassButton
    Friend WithEvents lblTimeCount As System.Windows.Forms.Label
    Friend WithEvents cmsInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip_lstStreams As System.Windows.Forms.ToolTip
    Friend WithEvents btnSettings As Glass.GlassButton
    Friend WithEvents btnHistory As Glass.GlassButton
    Friend WithEvents NotifyIcon2 As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnRefresh As Glass.GlassButton
    Friend WithEvents chkNotify As System.Windows.Forms.CheckBox
    Friend WithEvents CopyUrlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNonTwitch As Glass.GlassButton
    Friend WithEvents CopyTitleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnFeatured As Glass.GlassButton
End Class
