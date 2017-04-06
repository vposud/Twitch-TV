<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpeedRun
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpeedRun))
        Me.lstSpeedRun = New System.Windows.Forms.ListBox()
        Me.cmsSpeedRun = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoad = New Glass.GlassButton()
        Me.btnChatSR = New Glass.GlassButton()
        Me.cmsSpeedRun.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstSpeedRun
        '
        Me.lstSpeedRun.BackColor = System.Drawing.Color.Black
        Me.lstSpeedRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSpeedRun.ContextMenuStrip = Me.cmsSpeedRun
        Me.lstSpeedRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSpeedRun.ForeColor = System.Drawing.Color.White
        Me.lstSpeedRun.FormattingEnabled = True
        Me.lstSpeedRun.Location = New System.Drawing.Point(5, 5)
        Me.lstSpeedRun.Name = "lstSpeedRun"
        Me.lstSpeedRun.Size = New System.Drawing.Size(429, 158)
        Me.lstSpeedRun.TabIndex = 3
        '
        'cmsSpeedRun
        '
        Me.cmsSpeedRun.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem})
        Me.cmsSpeedRun.Name = "cmsSpeedRun"
        Me.cmsSpeedRun.Size = New System.Drawing.Size(97, 26)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.GlowColor = System.Drawing.Color.Cyan
        Me.btnLoad.Location = New System.Drawing.Point(5, 167)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.ShineColor = System.Drawing.Color.Gray
        Me.btnLoad.Size = New System.Drawing.Size(41, 22)
        Me.btnLoad.TabIndex = 12
        Me.btnLoad.Text = "Open"
        '
        'btnChatSR
        '
        Me.btnChatSR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChatSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChatSR.GlowColor = System.Drawing.Color.Cyan
        Me.btnChatSR.Location = New System.Drawing.Point(49, 167)
        Me.btnChatSR.Name = "btnChatSR"
        Me.btnChatSR.ShineColor = System.Drawing.Color.Gray
        Me.btnChatSR.Size = New System.Drawing.Size(37, 22)
        Me.btnChatSR.TabIndex = 13
        Me.btnChatSR.Text = "Chat"
        '
        'frmSpeedRun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(439, 194)
        Me.Controls.Add(Me.btnChatSR)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lstSpeedRun)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSpeedRun"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Speed Runners"
        Me.cmsSpeedRun.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstSpeedRun As System.Windows.Forms.ListBox
    Friend WithEvents cmsSpeedRun As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLoad As Glass.GlassButton
    Friend WithEvents btnChatSR As Glass.GlassButton
End Class
