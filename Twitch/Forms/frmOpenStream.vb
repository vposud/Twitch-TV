Public Class frmOpenStream
    Dim NewStreamProcess As New Process
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        'Loads a stream that is not from twitch.tv
        NewStreamProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        NewStreamProcess.StartInfo.CreateNoWindow = True
        NewStreamProcess.StartInfo.FileName = StreamlinkPath
        NewStreamProcess.StartInfo.Arguments = txtNewStream.Text & " best" & " --player=" & """" & VLCPath

        'Puts the loading on another thread to avoid frezeeing of the UI
        Dim t As New Threading.Thread(AddressOf OpenNewStream)
        t.IsBackground = True
        t.Start()

        'Saves in history
        SaveHistory(txtNewStream.Text)

        'Closes the form
        Me.Close()
    End Sub
    Private Sub OpenNewStream()
        'Streams the process
        NewStreamProcess.Start()
    End Sub
    Private Sub frmOpenStream_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtNewStream.Focus()
    End Sub
End Class