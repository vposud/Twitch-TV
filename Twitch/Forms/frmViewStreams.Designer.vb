<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewStreams
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewStreams))
        Me.lstGameNames = New System.Windows.Forms.ListBox()
        Me.lstStreamNames = New System.Windows.Forms.ListBox()
        Me.cmsStreamer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoad = New Glass.GlassButton()
        Me.btnBack = New Glass.GlassButton()
        Me.btnNext = New Glass.GlassButton()
        Me.btnPrev = New Glass.GlassButton()
        Me.btnChatVS = New Glass.GlassButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.btnSearch = New Glass.GlassButton()
        Me.btnList = New Glass.GlassButton()
        Me.cmsStreamer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstGameNames
        '
        Me.lstGameNames.BackColor = System.Drawing.Color.Black
        Me.lstGameNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstGameNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGameNames.ForeColor = System.Drawing.Color.White
        Me.lstGameNames.FormattingEnabled = True
        Me.lstGameNames.Location = New System.Drawing.Point(9, 3)
        Me.lstGameNames.Name = "lstGameNames"
        Me.lstGameNames.Size = New System.Drawing.Size(381, 145)
        Me.lstGameNames.TabIndex = 2
        '
        'lstStreamNames
        '
        Me.lstStreamNames.BackColor = System.Drawing.Color.Black
        Me.lstStreamNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstStreamNames.ContextMenuStrip = Me.cmsStreamer
        Me.lstStreamNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStreamNames.ForeColor = System.Drawing.Color.White
        Me.lstStreamNames.FormattingEnabled = True
        Me.lstStreamNames.Location = New System.Drawing.Point(9, 3)
        Me.lstStreamNames.Name = "lstStreamNames"
        Me.lstStreamNames.Size = New System.Drawing.Size(381, 145)
        Me.lstStreamNames.TabIndex = 3
        Me.lstStreamNames.Visible = False
        '
        'cmsStreamer
        '
        Me.cmsStreamer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem})
        Me.cmsStreamer.Name = "cmsStreamer"
        Me.cmsStreamer.Size = New System.Drawing.Size(97, 26)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'btnLoad
        '
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.Enabled = False
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.GlowColor = System.Drawing.Color.Cyan
        Me.btnLoad.Location = New System.Drawing.Point(10, 152)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.ShineColor = System.Drawing.Color.Gray
        Me.btnLoad.Size = New System.Drawing.Size(41, 22)
        Me.btnLoad.TabIndex = 12
        Me.btnLoad.Text = "Open"
        '
        'btnBack
        '
        Me.btnBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBack.Enabled = False
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.GlowColor = System.Drawing.Color.Cyan
        Me.btnBack.Location = New System.Drawing.Point(53, 152)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.ShineColor = System.Drawing.Color.Gray
        Me.btnBack.Size = New System.Drawing.Size(41, 22)
        Me.btnBack.TabIndex = 13
        Me.btnBack.Text = "Back"
        '
        'btnNext
        '
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.GlowColor = System.Drawing.Color.Cyan
        Me.btnNext.Location = New System.Drawing.Point(346, 151)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.ShineColor = System.Drawing.Color.Gray
        Me.btnNext.Size = New System.Drawing.Size(41, 22)
        Me.btnNext.TabIndex = 14
        Me.btnNext.Text = "Next"
        '
        'btnPrev
        '
        Me.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.GlowColor = System.Drawing.Color.Cyan
        Me.btnPrev.Location = New System.Drawing.Point(303, 151)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.ShineColor = System.Drawing.Color.Gray
        Me.btnPrev.Size = New System.Drawing.Size(41, 22)
        Me.btnPrev.TabIndex = 15
        Me.btnPrev.Text = "Prev"
        '
        'btnChatVS
        '
        Me.btnChatVS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChatVS.Enabled = False
        Me.btnChatVS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChatVS.GlowColor = System.Drawing.Color.Cyan
        Me.btnChatVS.Location = New System.Drawing.Point(96, 152)
        Me.btnChatVS.Name = "btnChatVS"
        Me.btnChatVS.ShineColor = System.Drawing.Color.Gray
        Me.btnChatVS.Size = New System.Drawing.Size(37, 22)
        Me.btnChatVS.TabIndex = 16
        Me.btnChatVS.Text = "Chat"
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.Black
        Me.txtSearch.ForeColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(6, 199)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(126, 20)
        Me.txtSearch.TabIndex = 17
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.White
        Me.lblSearch.Location = New System.Drawing.Point(14, 181)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(110, 15)
        Me.lblSearch.TabIndex = 18
        Me.lblSearch.Text = "Search For Games"
        '
        'btnSearch
        '
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.GlowColor = System.Drawing.Color.Cyan
        Me.btnSearch.Location = New System.Drawing.Point(138, 198)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.ShineColor = System.Drawing.Color.Gray
        Me.btnSearch.Size = New System.Drawing.Size(49, 22)
        Me.btnSearch.TabIndex = 19
        Me.btnSearch.Text = "Search"
        '
        'btnList
        '
        Me.btnList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnList.GlowColor = System.Drawing.Color.Cyan
        Me.btnList.Location = New System.Drawing.Point(135, 152)
        Me.btnList.Name = "btnList"
        Me.btnList.ShineColor = System.Drawing.Color.Gray
        Me.btnList.Size = New System.Drawing.Size(37, 22)
        Me.btnList.TabIndex = 20
        Me.btnList.Text = "List"
        '
        'frmViewStreams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(398, 223)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnChatVS)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lstGameNames)
        Me.Controls.Add(Me.lstStreamNames)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmViewStreams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Streams"
        Me.cmsStreamer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstGameNames As System.Windows.Forms.ListBox
    Friend WithEvents lstStreamNames As System.Windows.Forms.ListBox
    Friend WithEvents cmsStreamer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLoad As Glass.GlassButton
    Friend WithEvents btnBack As Glass.GlassButton
    Friend WithEvents btnNext As Glass.GlassButton
    Friend WithEvents btnPrev As Glass.GlassButton
    Friend WithEvents btnChatVS As Glass.GlassButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents btnSearch As Glass.GlassButton
    Friend WithEvents btnList As Glass.GlassButton
End Class
