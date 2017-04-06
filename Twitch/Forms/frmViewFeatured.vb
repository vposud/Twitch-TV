Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class frmViewFeatured
    Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean

#Region "Form Events"
    Private Sub frmViewFeatured_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim t As New Threading.Thread(AddressOf LoadFeatured)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub LoadFeatured()
        Dim responseString = ""
TryAgian:
        Try
            Dim url = "https://api.twitch.tv/kraken/streams/featured"
            Dim request As HttpWebRequest = WebRequest.Create(url)
            request.Method = "GET"
            request.Accept = "application/vnd.twitchtv.v5+json"
            request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
            Dim ws = request.GetResponse()
            Using stream As System.IO.Stream = ws.GetResponseStream()
                Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                responseString = reader.ReadToEnd()
            End Using
        Catch ex As Exception
            Threading.Thread.Sleep(5000)
            GoTo TryAgian
        End Try

        Dim obj As JObject = JObject.Parse(responseString)
        Dim twitchStreams As JArray = DirectCast(obj("featured"), JArray)
        For i As Integer = 0 To twitchStreams.Count - 1
            Dim streamer As String = twitchStreams(i)("stream")("channel")("display_name")
            Dim viewers As String = twitchStreams(i)("stream")("viewers")
            Dim game As String = twitchStreams(i)("stream")("game")
            Dim gameviewer As String = game & " (" & viewers & ")"
            lstStreamNames.Items.Add(viewers & " - " & "(" & streamer & ")" & " - " & game)
        Next
    End Sub
    Private Sub lstStreamNames_DoubleClick(sender As Object, e As EventArgs) Handles lstStreamNames.DoubleClick
        'Calls the public load stream function. Need to pass a button variable and a streamer variable
        PubTwitchButton = Form1.btnLoad
        PubCurrentStreamer = lstStreamNames.SelectedItem.ToString.Substring(lstStreamNames.SelectedItem.ToString.IndexOf("(") + 1, lstStreamNames.SelectedItem.ToString.IndexOf(")") - lstStreamNames.SelectedItem.ToString.IndexOf("(") - 1)
        liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        liveStreamerProcess.StartInfo.CreateNoWindow = True
        liveStreamerProcess.StartInfo.FileName = StreamlinkPath
        liveStreamerProcess.StartInfo.Arguments = "twitch.tv/" & PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        Dim t As New Threading.Thread(AddressOf OpenTwitchStream)
        t.IsBackground = True
        t.Start()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim responseString = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/users/" & Get_ID() & "/follows/channels/" & Get_ChannelID(lstStreamNames.SelectedItem.ToString.Substring(lstStreamNames.SelectedItem.ToString.IndexOf("(") + 1, lstStreamNames.SelectedItem.ToString.IndexOf(")") - lstStreamNames.SelectedItem.ToString.IndexOf("(") - 1))
            Dim request As HttpWebRequest = WebRequest.Create(url)
            request.Method = "PUT"
            request.Accept = "application/vnd.twitchtv.v5+json"
            request.Headers.Add("Authorization", "OAuth " & objIniFile.GetString("Twitch Settings", "Password", Nothing))
            request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
            Dim ws = request.GetResponse()
            Using stream As System.IO.Stream = ws.GetResponseStream()
                Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                responseString = reader.ReadToEnd()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, Title:="Add")
            Exit Sub
        End Try
    End Sub
#End Region
End Class