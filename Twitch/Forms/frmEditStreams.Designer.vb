<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditStreams
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditStreams))
        Me.btnRemove = New Glass.GlassButton()
        Me.lstEditStreams = New System.Windows.Forms.ListBox()
        Me.btnAdd = New Glass.GlassButton()
        Me.SuspendLayout()
        '
        'btnRemove
        '
        Me.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.GlowColor = System.Drawing.Color.Cyan
        Me.btnRemove.Location = New System.Drawing.Point(66, 223)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.ShineColor = System.Drawing.Color.Gray
        Me.btnRemove.Size = New System.Drawing.Size(55, 22)
        Me.btnRemove.TabIndex = 19
        Me.btnRemove.Text = "Remove"
        '
        'lstEditStreams
        '
        Me.lstEditStreams.BackColor = System.Drawing.Color.Black
        Me.lstEditStreams.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEditStreams.ForeColor = System.Drawing.Color.White
        Me.lstEditStreams.FormattingEnabled = True
        Me.lstEditStreams.ItemHeight = 15
        Me.lstEditStreams.Location = New System.Drawing.Point(2, 3)
        Me.lstEditStreams.Name = "lstEditStreams"
        Me.lstEditStreams.Size = New System.Drawing.Size(242, 214)
        Me.lstEditStreams.TabIndex = 20
        '
        'btnAdd
        '
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.GlowColor = System.Drawing.Color.Cyan
        Me.btnAdd.Location = New System.Drawing.Point(127, 223)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.ShineColor = System.Drawing.Color.Gray
        Me.btnAdd.Size = New System.Drawing.Size(55, 22)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.Text = "Add"
        '
        'frmEditStreams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(248, 253)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstEditStreams)
        Me.Controls.Add(Me.btnRemove)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEditStreams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Streams"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRemove As Glass.GlassButton
    Friend WithEvents lstEditStreams As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As Glass.GlassButton
End Class
