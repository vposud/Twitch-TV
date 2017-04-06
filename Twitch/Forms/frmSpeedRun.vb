Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class frmSpeedRun
#Region "Delcares"
    Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean
#End Region
#Region "Form Events"
    Private Sub btnChatSR_Click(sender As Object, e As EventArgs) Handles btnChatSR.Click
        If frmChat.Visible = True Then
            Dim frm As New frmChat
            frm.Text = lstSpeedRun.SelectedItem.ToString.Substring(lstSpeedRun.SelectedItem.ToString.IndexOf("(") + 1, lstSpeedRun.SelectedItem.ToString.IndexOf(")") - lstSpeedRun.SelectedItem.ToString.IndexOf("(") - 1)
            frm.Show()
        Else
            frmChat.Text = lstSpeedRun.SelectedItem.ToString.Substring(lstSpeedRun.SelectedItem.ToString.IndexOf("(") + 1, lstSpeedRun.SelectedItem.ToString.IndexOf(")") - lstSpeedRun.SelectedItem.ToString.IndexOf("(") - 1)
            frmChat.Show()
        End If
    End Sub
    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Call lstSpeedRun_DoubleClick(sender, e)
    End Sub
    Private Sub lstSpeedRun_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSpeedRun.DoubleClick
        PubTwitchButton = btnLoad
        PubCurrentStreamer = lstSpeedRun.SelectedItem.ToString.Substring(lstSpeedRun.SelectedItem.ToString.IndexOf("(") + 1, lstSpeedRun.SelectedItem.ToString.IndexOf(")") - lstSpeedRun.SelectedItem.ToString.IndexOf("(") - 1)
        liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        liveStreamerProcess.StartInfo.CreateNoWindow = True
        liveStreamerProcess.StartInfo.FileName = StreamlinkPath
        liveStreamerProcess.StartInfo.Arguments = "twitch.tv/" & PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        Dim t As New Threading.Thread(AddressOf OpenTwitchStream)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub lstSpeedRun_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSpeedRun.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = lstSpeedRun.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                lstSpeedRun.SelectedItem = lstSpeedRun.Items(index)
            End If
        End If
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        'Adds stream to the follow list
        Dim responseString = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/users/" & Get_ID() & "/follows/channels/" & Get_ChannelID(lstSpeedRun.SelectedItem.ToString.Substring(lstSpeedRun.SelectedItem.ToString.IndexOf("(") + 1, lstSpeedRun.SelectedItem.ToString.IndexOf(")") - lstSpeedRun.SelectedItem.ToString.IndexOf("(") - 1))
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
    Private Sub frmSpeedRun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim t As New Threading.Thread(AddressOf LoadGames)
        t.IsBackground = True
        t.Start()
    End Sub
#End Region
#Region "Functions"
    Private Sub LoadGames()
        Try
            Dim url = "http://api.speedrunslive.com/frontend/streams"
            Dim request As HttpWebRequest = WebRequest.Create(url)
            Dim ws = request.GetResponse()

            Dim responseString = ""
            Using stream As System.IO.Stream = ws.GetResponseStream()
                Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                responseString = reader.ReadToEnd()
            End Using

            Dim obj As JObject = JObject.Parse(responseString)

            Dim twitchStreams As JArray = DirectCast(obj("_source")("channels"), JArray)

            For i As Integer = 0 To twitchStreams.Count - 1
                Dim name As String = twitchStreams(i)("name")
                Dim viewers As String = twitchStreams(i)("current_viewers")
                Dim game As String = twitchStreams(i)("meta_game")
                Dim fulltitle As String = viewers & " - " & "(" & name & ")" & " - " & game
                lstSpeedRun.Items.Add(fulltitle)
            Next
            GetReverOrder()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetReverOrder()
        Dim lsttemp As New ListBox
        lsttemp.Items.AddRange(lstSpeedRun.Items)

        Dim GetNumber As Integer

        For i = 0 To lsttemp.Items.Count - 1
            Try
                GetNumber = lsttemp.Items.Item(i).ToString.Substring(0, lsttemp.Items.Item(i).ToString.IndexOf(" "))
            Catch ex As Exception
                GetNumber = 1
            End Try
            Select Case GetNumber.ToString.Length
                Case 4
                    lsttemp.Items.Item(i) = "0" & lsttemp.Items.Item(i)
                Case 3
                    lsttemp.Items.Item(i) = "00" & lsttemp.Items.Item(i)
                Case 2
                    lsttemp.Items.Item(i) = "000" & lsttemp.Items.Item(i)
                Case 1
                    lsttemp.Items.Item(i) = "0000" & lsttemp.Items.Item(i)
            End Select
        Next

        lsttemp.Sorted = True
        lsttemp.Sorted = False

        Dim myLBitems As New List(Of String)
        For Each item As String In lsttemp.Items
            myLBitems.Add(item)
        Next
        lsttemp.Items.Clear()
        For i As Integer = myLBitems.Count - 1 To 0 Step -1
            lsttemp.Items.Add(myLBitems(i))
        Next

        For i = 0 To lsttemp.Items.Count - 1
            lsttemp.Items.Item(i) = lsttemp.Items.Item(i).ToString.Trim("0")
            lsttemp.Items.Item(i) = lsttemp.Items.Item(i).ToString.Trim("00")
            lsttemp.Items.Item(i) = lsttemp.Items.Item(i).ToString.Trim("000")
            lsttemp.Items.Item(i) = lsttemp.Items.Item(i).ToString.Trim("0000")
        Next

        lstSpeedRun.Items.Clear()
        lstSpeedRun.Items.AddRange(lsttemp.Items)
    End Sub
#End Region
End Class