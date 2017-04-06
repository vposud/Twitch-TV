Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class frmViewStreams
    Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean
    Dim lstStreamNames1 As New ListBox
    Dim Offset, OffsetStreams, OffsetSearch As Integer
    Dim IfSearched As Boolean

#Region "Form Events"
    Private Sub frmViewStreams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim t As New Threading.Thread(AddressOf LoadGames)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub lstStreamNames_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstStreamNames.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = lstStreamNames.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                lstStreamNames.SelectedItem = lstStreamNames.Items(index)
            End If
        End If
    End Sub
    Private Sub lstStreamNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstStreamNames.SelectedIndexChanged
        lstStreamNames1.SelectedIndex = lstStreamNames.SelectedIndex
    End Sub
    Private Sub lstStreamNames_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstStreamNames.KeyUp
        If e.KeyCode = Keys.Back Then
            lstStreamNames.Visible = False
            lstGameNames.Visible = True
            btnLoad.Enabled = False
            btnBack.Enabled = False
            btnChatVS.Enabled = False
            btnNext.Enabled = True
            btnPrev.Enabled = True
            btnSearch.Enabled = True
        End If
    End Sub
    Private Sub lstStreamNames_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstStreamNames.MouseDoubleClick
        PubTwitchButton = btnLoad
        PubCurrentStreamer = lstStreamNames1.SelectedItem
        liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        liveStreamerProcess.StartInfo.CreateNoWindow = True
        liveStreamerProcess.StartInfo.FileName = StreamlinkPath
        liveStreamerProcess.StartInfo.Arguments = "twitch.tv/" & PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        Dim t As New Threading.Thread(AddressOf OpenTwitchStream)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub lstGameNames_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstGameNames.MouseDoubleClick
        If lstGameNames.Items.Count <= 0 Then Exit Sub
        Dim responseString = ""
        Dim obj As New JObject
        Dim twitchStreams As New JArray

        btnLoad.Enabled = True
        btnBack.Enabled = True
        btnChatVS.Enabled = True
        'btnNext.Enabled = False
        'btnPrev.Enabled = False
        btnSearch.Enabled = False
        lstGameNames.Visible = False
        lstStreamNames.Visible = True
        lstStreamNames.Items.Clear()
        lstStreamNames1.Items.Clear()

        If IfSearched = True Then
TryAgian:
            Try
                Dim url = "https://api.twitch.tv/kraken/streams?game=" & lstGameNames.SelectedItem
                Dim request As HttpWebRequest = WebRequest.Create(url)
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

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("streams"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("channel")("display_name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim twitchname As String = twitchStreams(i)("channel")("name")
                Dim gameviewer As String = name & " (" & viewers & ")"
                lstStreamNames.Items.Add(gameviewer)
                lstStreamNames1.Items.Add(twitchname)
            Next

        Else

TryAgian2:
            Try
                Dim url = "https://api.twitch.tv/kraken/streams?game=" & lstGameNames.SelectedItem.ToString.Substring(0, lstGameNames.SelectedItem.ToString.LastIndexOf("(") - 1)
                Dim request As HttpWebRequest = WebRequest.Create(url)
                request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
                Dim ws = request.GetResponse()
                Using stream As System.IO.Stream = ws.GetResponseStream()
                    Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                    responseString = reader.ReadToEnd()
                End Using
            Catch ex As Exception
                Threading.Thread.Sleep(5000)
                GoTo TryAgian2
            End Try

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("streams"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("channel")("display_name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim twitchname As String = twitchStreams(i)("channel")("name")
                Dim gameviewer As String = name & " (" & viewers & ")"
                lstStreamNames.Items.Add(gameviewer)
                lstStreamNames1.Items.Add(twitchname)
            Next
        End If
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Dim responseString = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/users/" & objIniFile.GetString("Twitch Settings", "Username", Nothing) & "/follows/channels/" & lstStreamNames1.SelectedItem
            Dim request As HttpWebRequest = WebRequest.Create(url)
            request.Method = "PUT"
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
    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Call lstStreamNames_MouseDoubleClick(sender, e)
    End Sub
    Private Sub GlassButton1_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        'Sets the stream off to zero
        OffsetStreams = 0

        'Changes the buttons to be visble or not visble
        lstStreamNames.Visible = False
        lstGameNames.Visible = True
        btnLoad.Enabled = False
        btnBack.Enabled = False
        btnChatVS.Enabled = False
        btnSearch.Enabled = True
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim responseString = ""
        Dim obj As New JObject
        Dim twitchStreams As New JArray

        'If the search button was pressed then scroll through the search result streams
        If IfSearched = True And lstStreamNames.Visible = True Then
            lstStreamNames.Items.Clear()
            lstStreamNames1.Items.Clear()
            OffsetSearch += 25
TryAgian3:
            Try
                Dim url = "https://api.twitch.tv/kraken/streams?game=" & lstGameNames.SelectedItem & "&offset=" & OffsetSearch
                Dim request As HttpWebRequest = WebRequest.Create(url)
                request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
                Dim ws = request.GetResponse()
                Using stream As System.IO.Stream = ws.GetResponseStream()
                    Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                    responseString = reader.ReadToEnd()
                End Using
            Catch ex As Exception
                Threading.Thread.Sleep(5000)
                GoTo TryAgian3
            End Try

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("streams"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("channel")("display_name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim twitchname As String = twitchStreams(i)("channel")("name")
                Dim gameviewer As String = name & " (" & viewers & ")"
                lstStreamNames.Items.Add(gameviewer)
                lstStreamNames1.Items.Add(twitchname)
            Next

            'If the stream list is visble then allow scrolling through
        ElseIf lstStreamNames.Visible = True Then
            'Clears the stream list and sets the stream offset to plus 25
            lstStreamNames.Items.Clear()
            lstStreamNames1.Items.Clear()
            OffsetStreams += 25
TryAgian2:
            Try
                Dim url = "https://api.twitch.tv/kraken/streams?game=" & lstGameNames.SelectedItem.ToString.Substring(0, lstGameNames.SelectedItem.ToString.LastIndexOf("(") - 1) & "&offset=" & OffsetStreams
                Dim request As HttpWebRequest = WebRequest.Create(url)
                request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
                Dim ws = request.GetResponse()
                Using stream As System.IO.Stream = ws.GetResponseStream()
                    Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                    responseString = reader.ReadToEnd()
                End Using
            Catch ex As Exception
                Threading.Thread.Sleep(5000)
                GoTo TryAgian2
            End Try

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("streams"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("channel")("display_name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim twitchname As String = twitchStreams(i)("channel")("name")
                Dim gameviewer As String = name & " (" & viewers & ")"
                lstStreamNames.Items.Add(gameviewer)
                lstStreamNames1.Items.Add(twitchname)
            Next

            'If the game list is visble then allow scrolling through
        ElseIf lstGameNames.Visible = True Then
            'Clears the gamelist and sets the offset to plus 20
            lstGameNames.Items.Clear()
            Offset += 20
TryAgian:
            Try
                Dim url = "https://api.twitch.tv/kraken/games/top?limit=20&offset=" & Offset
                Dim request As HttpWebRequest = WebRequest.Create(url)
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

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("top"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim game As String = twitchStreams(i)("game")("name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim gameviewer As String = game & " (" & viewers & ")"
                lstGameNames.Items.Add(gameviewer)
            Next
        End If
    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim responseString = ""
        Dim obj As New JObject
        Dim twitchStreams As New JArray

        'If the search button was pressed then scroll through the search result streams
        If IfSearched = True And lstStreamNames.Visible = True Then
            If OffsetSearch = 0 Then Exit Sub
            lstStreamNames.Items.Clear()
            lstStreamNames1.Items.Clear()
            OffsetSearch -= 25
TryAgian3:
            Try
                Dim url = "https://api.twitch.tv/kraken/streams?game=" & lstGameNames.SelectedItem & "&offset=" & OffsetSearch
                Dim request As HttpWebRequest = WebRequest.Create(url)
                request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
                Dim ws = request.GetResponse()
                Using stream As System.IO.Stream = ws.GetResponseStream()
                    Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                    responseString = reader.ReadToEnd()
                End Using
            Catch ex As Exception
                Threading.Thread.Sleep(5000)
                GoTo TryAgian3
            End Try

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("streams"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("channel")("display_name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim twitchname As String = twitchStreams(i)("channel")("name")
                Dim gameviewer As String = name & " (" & viewers & ")"
                lstStreamNames.Items.Add(gameviewer)
                lstStreamNames1.Items.Add(twitchname)
            Next

            'If the stream list is visble then allow scrolling through
        ElseIf lstStreamNames.Visible = True Then
            'If the stream offset is 0 then exit the sub
            If OffsetStreams = 0 Then Exit Sub
            lstStreamNames.Items.Clear()
            lstStreamNames1.Items.Clear()
            'Sets the stream offset to minus 25
            OffsetStreams -= 25
TryAgian2:
            Try
                Dim url = "https://api.twitch.tv/kraken/streams?game=" & lstGameNames.SelectedItem.ToString.Substring(0, lstGameNames.SelectedItem.ToString.LastIndexOf("(") - 1) & "&offset=" & OffsetStreams
                Dim request As HttpWebRequest = WebRequest.Create(url)
                request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
                Dim ws = request.GetResponse()
                Using stream As System.IO.Stream = ws.GetResponseStream()
                    Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                    responseString = reader.ReadToEnd()
                End Using
            Catch ex As Exception
                Threading.Thread.Sleep(5000)
                GoTo TryAgian2
            End Try

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("streams"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("channel")("display_name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim twitchname As String = twitchStreams(i)("channel")("name")
                Dim gameviewer As String = name & " (" & viewers & ")"
                lstStreamNames.Items.Add(gameviewer)
                lstStreamNames1.Items.Add(twitchname)
            Next

            'If the game list is visble then allow scrolling through
        ElseIf lstGameNames.Visible = True Then
            'If the offset is 0 exit the sub
            If Offset = 0 Then Exit Sub
            lstGameNames.Items.Clear()
            'Sets the offset to minus 20
            Offset -= 20
TryAgian:
            Try
                Dim url = "https://api.twitch.tv/kraken/games/top?limit=20&offset=" & Offset
                Dim request As HttpWebRequest = WebRequest.Create(url)
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

            obj = JObject.Parse(responseString)
            twitchStreams = DirectCast(obj("top"), JArray)
            For i As Integer = 0 To twitchStreams.Count - 1
                Dim game As String = twitchStreams(i)("game")("name")
                Dim viewers As String = twitchStreams(i)("viewers")
                Dim gameviewer As String = game & " (" & viewers & ")"
                lstGameNames.Items.Add(gameviewer)
            Next
        End If
    End Sub
    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        'Tells the program the search button was not pressed
        IfSearched = False

        'Resets the offset to zero
        Offset = 0
        OffsetStreams = 0
        OffsetSearch = 0

        lstStreamNames.Items.Clear()
        lstStreamNames1.Items.Clear()
        lstGameNames.Items.Clear()
        lstStreamNames.Visible = False
        lstGameNames.Visible = True
        btnLoad.Enabled = False
        btnBack.Enabled = False
        btnChatVS.Enabled = False
        btnNext.Enabled = True
        btnPrev.Enabled = True
        btnSearch.Enabled = True


        Dim t As New Threading.Thread(AddressOf LoadGames)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Creates/runs the search thread
        Dim t As New Threading.Thread(AddressOf Search)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub btnChatVS_Click(sender As Object, e As EventArgs) Handles btnChatVS.Click
        Process.Start(Application.StartupPath & "/Twitch Chat.exe", lstStreamNames1.SelectedItem)
    End Sub
#End Region

#Region "Functions"
    Private Sub LoadGames()
        Dim responseString = ""
TryAgian:
        Try
            Dim url = "https://api.twitch.tv/kraken/games/top?limit=20&offset=0"
            Dim request As HttpWebRequest = WebRequest.Create(url)
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
        Dim twitchStreams As JArray = DirectCast(obj("top"), JArray)
        For i As Integer = 0 To twitchStreams.Count - 1
            Dim game As String = twitchStreams(i)("game")("name")
            Dim viewers As String = twitchStreams(i)("viewers")
            Dim gameviewer As String = game & " (" & viewers & ")"
            lstGameNames.Items.Add(gameviewer)
        Next
    End Sub
    Private Sub Search()
        'If the search textbox is empty exit sub
        If txtSearch.Text = "" Then Exit Sub

        'Clear the gamename list to get ready to populate it with the new games
        lstGameNames.Items.Clear()

        Dim responseString = ""

TryAgian:
        Try
            Dim url = "https://api.twitch.tv/kraken/search/games?q=" & txtSearch.Text & "&type=suggest&live=true"
            Dim request As HttpWebRequest = WebRequest.Create(url)
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
        Dim twitchStreams As JArray = DirectCast(obj("games"), JArray)
        For i As Integer = 0 To twitchStreams.Count - 1
            Dim game As String = twitchStreams(i)("name")
            lstGameNames.Items.Add(game)
        Next

        'Tells the program the search button was pressed
        IfSearched = True

        'After the search clear the text box
        txtSearch.Text = ""
    End Sub
#End Region

End Class