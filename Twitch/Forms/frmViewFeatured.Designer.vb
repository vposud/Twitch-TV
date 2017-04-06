<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewFeatured
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewFeatured))
        Me.lstStreamNames = New System.Windows.Forms.ListBox()
        Me.cmsStreamer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsStreamer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstStreamNames
        '
        Me.lstStreamNames.BackColor = System.Drawing.Color.Black
        Me.lstStreamNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstStreamNames.ContextMenuStrip = Me.cmsStreamer
        Me.lstStreamNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStreamNames.ForeColor = System.Drawing.Color.White
        Me.lstStreamNames.FormattingEnabled = True
        Me.lstStreamNames.Location = New System.Drawing.Point(6, 3)
        Me.lstStreamNames.Name = "lstStreamNames"
        Me.lstStreamNames.Size = New System.Drawing.Size(422, 171)
        Me.lstStreamNames.TabIndex = 3
        '
        'cmsStreamer
        '
        Me.cmsStreamer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem})
        Me.cmsStreamer.Name = "cmsStreamer"
        Me.cmsStreamer.Size = New System.Drawing.Size(153, 48)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'frmViewFeatured
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(434, 180)
        Me.Controls.Add(Me.lstStreamNames)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmViewFeatured"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Featured"
        Me.cmsStreamer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstStreamNames As System.Windows.Forms.ListBox
    Friend WithEvents cmsStreamer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
