Public Class frmSettings
#Region "Load/Save"
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads the settings
        Try
            txtTwitchUser.Text = objIniFile.GetString("Twitch Settings", "Username", Nothing)
            txtTwitchPass.Text = objIniFile.GetString("Twitch Settings", "Password", Nothing)
            txtVLCPath.Text = objIniFile.GetString("Twitch Settings", "VLC Path", Nothing)

            txtFTPAccount.Text = objIniFile.GetString("Twitch Settings", "FTP Account", Nothing)
            txtFTPPW.Text = objIniFile.GetString("Twitch Settings", "FTP Password", Nothing)
            txtFTPDirectory.Text = objIniFile.GetString("Twitch Settings", "FTP Directory", Nothing)

            txtHistoryAmount.Text = objIniFile.GetString("Twitch Settings", "History Amount", Nothing)

            If objIniFile.GetString("Twitch Settings", "Display Emotes", Nothing) = "True" Then
                chkEmotes.CheckState = CheckState.Checked
            Else
                chkEmotes.CheckState = CheckState.Unchecked
            End If

            If objIniFile.GetString("Twitch Settings", "Cache Emotes", Nothing) = "True" Then
                chkCacheEmotes.CheckState = CheckState.Checked
            Else
                chkCacheEmotes.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Saves the settings
        Try
            objIniFile.WriteString("Twitch Settings", "Username", txtTwitchUser.Text)
            objIniFile.WriteString("Twitch Settings", "Password", txtTwitchPass.Text)
            objIniFile.WriteString("Twitch Settings", "VLC Path", txtVLCPath.Text)

            objIniFile.WriteString("Twitch Settings", "FTP Account", txtFTPAccount.Text)
            objIniFile.WriteString("Twitch Settings", "FTP Password", txtFTPPW.Text)
            objIniFile.WriteString("Twitch Settings", "FTP Directory", txtFTPDirectory.Text)

            objIniFile.WriteString("Twitch Settings", "History Amount", txtHistoryAmount.Text)

            If chkEmotes.CheckState = CheckState.Checked Then
                objIniFile.WriteString("Twitch Settings", "Display Emotes", "True")
            Else
                objIniFile.WriteString("Twitch Settings", "Display Emotes", "False")
            End If

            If chkCacheEmotes.CheckState = CheckState.Checked Then
                objIniFile.WriteString("Twitch Settings", "Cache Emotes", "True")
            Else
                objIniFile.WriteString("Twitch Settings", "Cache Emotes", "False")
            End If

        Catch ex As Exception
        End Try
        'Saves the chrome path
        VLCPath = txtVLCPath.Text
        Me.Close()
    End Sub
#End Region
#Region "Colors"
    Private Sub chkCacheEmotes_MouseEnter(sender As Object, e As EventArgs) Handles chkCacheEmotes.MouseEnter
        chkCacheEmotes.ForeColor = Color.Cyan
        ToolTip1.SetToolTip(chkCacheEmotes, "Check to download and save emotes to the images/emotes folder for faster performance")
    End Sub
    Private Sub chkCacheEmotes_MouseLeave(sender As Object, e As EventArgs) Handles chkCacheEmotes.MouseLeave
        chkCacheEmotes.ForeColor = Color.White
    End Sub
    Private Sub chkEmotes_MouseEnter(sender As Object, e As EventArgs) Handles chkEmotes.MouseEnter
        chkEmotes.ForeColor = Color.Cyan
        ToolTip1.SetToolTip(chkEmotes, "Check to display emotes in chat")
    End Sub
    Private Sub chkEmotes_MouseLeave(sender As Object, e As EventArgs) Handles chkEmotes.MouseLeave
        chkEmotes.ForeColor = Color.White
    End Sub
    Private Sub txtHistoryAmount_MouseEnter(sender As Object, e As EventArgs) Handles txtHistoryAmount.MouseEnter
        txtHistoryAmount.ForeColor = Color.Cyan
    End Sub
    Private Sub txtHistoryAmount_MouseLeave(sender As Object, e As EventArgs) Handles txtHistoryAmount.MouseLeave
        txtHistoryAmount.ForeColor = Color.White
    End Sub
    Private Sub txtTwitchUser_MouseEnter(sender As Object, e As EventArgs) Handles txtTwitchUser.MouseEnter
        txtTwitchUser.ForeColor = Color.Cyan
    End Sub
    Private Sub txtTwitchUser_MouseLeave(sender As Object, e As EventArgs) Handles txtTwitchUser.MouseLeave
        txtTwitchUser.ForeColor = Color.White
    End Sub
    Private Sub txtTwitchPass_MouseEnter(sender As Object, e As EventArgs) Handles txtTwitchPass.MouseEnter
        txtTwitchPass.ForeColor = Color.Cyan
    End Sub
    Private Sub txtTwitchPass_MouseLeave(sender As Object, e As EventArgs) Handles txtTwitchPass.MouseLeave
        txtTwitchPass.ForeColor = Color.White
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub txtVLCPath_MouseEnter(sender As Object, e As EventArgs) Handles txtVLCPath.MouseEnter
        txtVLCPath.ForeColor = Color.Cyan
    End Sub
    Private Sub txtVLCPath_MouseLeave(sender As Object, e As EventArgs) Handles txtVLCPath.MouseLeave
        txtVLCPath.ForeColor = Color.White
    End Sub
    Private Sub txtFTPAccount_MouseEnter(sender As Object, e As EventArgs) Handles txtFTPAccount.MouseEnter
        txtFTPAccount.ForeColor = Color.Cyan
    End Sub
    Private Sub txtFTPAccount_MouseLeave(sender As Object, e As EventArgs) Handles txtFTPAccount.MouseLeave
        txtFTPAccount.ForeColor = Color.White
    End Sub
    Private Sub txtFTPPW_MouseEnter(sender As Object, e As EventArgs) Handles txtFTPPW.MouseEnter
        txtFTPPW.ForeColor = Color.Cyan
    End Sub
    Private Sub txtFTPPW_MouseLeave(sender As Object, e As EventArgs) Handles txtFTPPW.MouseLeave
        txtFTPPW.ForeColor = Color.White
    End Sub
    Private Sub txtFTPDirectory_MouseEnter(sender As Object, e As EventArgs) Handles txtFTPDirectory.MouseEnter
        txtFTPDirectory.ForeColor = Color.Cyan
    End Sub
    Private Sub txtFTPDirectory_MouseLeave(sender As Object, e As EventArgs) Handles txtFTPDirectory.MouseLeave
        txtFTPDirectory.ForeColor = Color.White
    End Sub
#End Region
#Region "Random"
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHistoryAmount.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region
#Region "ToolTips"
    Private Sub Label9_MouseEnter(sender As Object, e As EventArgs) Handles Label9.MouseEnter
        ToolTip1.SetToolTip(Label9, "Sets the amount of streams to store in history")
    End Sub
    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        ToolTip1.SetToolTip(Label3, "Sets the path to VLC player for viewing streams")
    End Sub
    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        ToolTip1.SetToolTip(Label5, "Sets the FTP account name used for backing up your streamer list to an FTP server")
    End Sub
    Private Sub Label6_MouseEnter(sender As Object, e As EventArgs) Handles Label6.MouseEnter
        ToolTip1.SetToolTip(Label6, "Sets the FTP password for the account")
    End Sub
    Private Sub Label7_MouseEnter(sender As Object, e As EventArgs) Handles Label7.MouseEnter
        ToolTip1.SetToolTip(Label7, "Sets the FTP directory to store the list of streamers. An example of this would be " & Chr(34) & "ftp://SERVERNAME/Twitch/" & Chr(34) & " the last line must have a /")
    End Sub
#End Region
End Class