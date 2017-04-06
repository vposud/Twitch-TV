<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistory))
        Me.lstHistory = New System.Windows.Forms.ListBox()
        Me.btnClear = New Glass.GlassButton()
        Me.SuspendLayout()
        '
        'lstHistory
        '
        Me.lstHistory.BackColor = System.Drawing.Color.Black
        Me.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHistory.ForeColor = System.Drawing.Color.White
        Me.lstHistory.FormattingEnabled = True
        Me.lstHistory.Location = New System.Drawing.Point(5, 5)
        Me.lstHistory.Name = "lstHistory"
        Me.lstHistory.Size = New System.Drawing.Size(325, 197)
        Me.lstHistory.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.GlowColor = System.Drawing.Color.Cyan
        Me.btnClear.Location = New System.Drawing.Point(140, 208)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.ShineColor = System.Drawing.Color.Gray
        Me.btnClear.Size = New System.Drawing.Size(55, 22)
        Me.btnClear.TabIndex = 23
        Me.btnClear.Text = "Clear"
        '
        'frmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(335, 236)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lstHistory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstHistory As System.Windows.Forms.ListBox
    Friend WithEvents btnClear As Glass.GlassButton
End Class
