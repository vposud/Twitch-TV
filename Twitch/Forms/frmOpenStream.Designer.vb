<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenStream
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenStream))
        Me.btnLoad = New Glass.GlassButton()
        Me.txtNewStream = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.GlowColor = System.Drawing.Color.Cyan
        Me.btnLoad.Location = New System.Drawing.Point(92, 37)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.ShineColor = System.Drawing.Color.Gray
        Me.btnLoad.Size = New System.Drawing.Size(44, 22)
        Me.btnLoad.TabIndex = 12
        Me.btnLoad.Text = "Open"
        '
        'txtNewStream
        '
        Me.txtNewStream.BackColor = System.Drawing.Color.Black
        Me.txtNewStream.ForeColor = System.Drawing.Color.White
        Me.txtNewStream.Location = New System.Drawing.Point(11, 11)
        Me.txtNewStream.Name = "txtNewStream"
        Me.txtNewStream.Size = New System.Drawing.Size(206, 20)
        Me.txtNewStream.TabIndex = 13
        '
        'frmOpenStream
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(228, 68)
        Me.Controls.Add(Me.txtNewStream)
        Me.Controls.Add(Me.btnLoad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmOpenStream"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open Stream"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLoad As Glass.GlassButton
    Friend WithEvents txtNewStream As TextBox
End Class
