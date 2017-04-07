Public Class frmHistory

    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Streamer As String In IO.File.ReadAllLines(Application.StartupPath & "\History.txt")
            lstHistory.Items.Add(Streamer)
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstHistory.Items.Clear()
        Dim SW As New IO.StreamWriter(Application.StartupPath & "\History.txt", False)
        SW.Write("")
        SW.Close()
    End Sub

    Private Sub lstHistory_DoubleClick(sender As Object, e As EventArgs) Handles lstHistory.DoubleClick
        If lstHistory.SelectedItem.ToString.Contains("/") Then
            'If the stream contains a / then it isnt a twitch stream so load a new twitch stream
            PubTwitchButton = Form1.btnLoad
            PubCurrentStreamer = lstHistory.SelectedItem
            liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            liveStreamerProcess.StartInfo.CreateNoWindow = True
            liveStreamerProcess.StartInfo.FileName = StreamlinkPath
            liveStreamerProcess.StartInfo.Arguments = PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        Else
            'Loads a new twitch stream
            PubTwitchButton = Form1.btnLoad
            PubCurrentStreamer = lstHistory.SelectedItem
            liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            liveStreamerProcess.StartInfo.CreateNoWindow = True
            liveStreamerProcess.StartInfo.FileName = StreamlinkPath
            liveStreamerProcess.StartInfo.Arguments = "twitch.tv/" & PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        End If

        Dim t As New Threading.Thread(AddressOf OpenTwitchStream)
        t.IsBackground = True
        t.Start()
    End Sub
End Class