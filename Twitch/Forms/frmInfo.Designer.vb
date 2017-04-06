<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfo))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lbldelay = New System.Windows.Forms.Label()
        Me.lblTotalViews = New System.Windows.Forms.Label()
        Me.lblFollowers = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 200)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(9, 228)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(47, 15)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Status: "
        '
        'lbldelay
        '
        Me.lbldelay.AutoSize = True
        Me.lbldelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldelay.ForeColor = System.Drawing.Color.White
        Me.lbldelay.Location = New System.Drawing.Point(9, 315)
        Me.lbldelay.Name = "lbldelay"
        Me.lbldelay.Size = New System.Drawing.Size(44, 15)
        Me.lbldelay.TabIndex = 2
        Me.lbldelay.Text = "Delay: "
        '
        'lblTotalViews
        '
        Me.lblTotalViews.AutoSize = True
        Me.lblTotalViews.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalViews.ForeColor = System.Drawing.Color.White
        Me.lblTotalViews.Location = New System.Drawing.Point(9, 257)
        Me.lblTotalViews.Name = "lblTotalViews"
        Me.lblTotalViews.Size = New System.Drawing.Size(75, 15)
        Me.lblTotalViews.TabIndex = 3
        Me.lblTotalViews.Text = "Total Views: "
        '
        'lblFollowers
        '
        Me.lblFollowers.AutoSize = True
        Me.lblFollowers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFollowers.ForeColor = System.Drawing.Color.White
        Me.lblFollowers.Location = New System.Drawing.Point(9, 286)
        Me.lblFollowers.Name = "lblFollowers"
        Me.lblFollowers.Size = New System.Drawing.Size(96, 15)
        Me.lblFollowers.TabIndex = 4
        Me.lblFollowers.Text = "Total Followers: "
        '
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(338, 347)
        Me.Controls.Add(Me.lblFollowers)
        Me.Controls.Add(Me.lblTotalViews)
        Me.Controls.Add(Me.lbldelay)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Info"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lbldelay As System.Windows.Forms.Label
    Friend WithEvents lblTotalViews As System.Windows.Forms.Label
    Friend WithEvents lblFollowers As System.Windows.Forms.Label
End Class
