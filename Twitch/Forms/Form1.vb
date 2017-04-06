Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class Form1
#Region "Declares"
    Public lstAllWindows As New Windows.Forms.ListBox
    Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean
    Public Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Public Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    Public Declare Auto Function GetWindowRect Lib "User32.dll" (ByVal hWnd As IntPtr, ByRef rect As RECT) As Integer

    Const GW_HWNDNEXT As Integer = 2
    Private Declare Function apiGetWindow Lib "user32" Alias "GetWindow" (ByVal hwnd As Integer, ByVal wCmd As Integer) As Integer
    Private Declare Function apiGetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
    Private Declare Function apiGetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer
    Private Declare Function apiGetTopWindow Lib "user32" Alias "GetTopWindow" (ByVal hwnd As Integer) As Integer
    Private Declare Function apiGetDesktopWindow Lib "user32" Alias "GetDesktopWindow" () As Integer
    Private Declare Function apiShowOwnedPopups Lib "user32" Alias "ShowOwnedPopups" (ByVal hWnd As Integer, ByVal fShow As Integer) As Integer
    Private Declare Function apiAnyPopup Lib "user32" Alias "AnyPopup" () As Integer
    Private Declare Function apiGetLastActivePopup Lib "user32" Alias "GetLastActivePopup" (ByVal hWndOwnder As Integer) As Integer
    Private ElapsedTime As Integer, Mouse_Point_Tooltip
    Private Stream_Dic As New Dictionary(Of String, String)
    Private Delegate Sub Notify(ByVal Streamer As String)
    Private Count, MainThread As Threading.Thread
    Private FollowList As String
#End Region
#Region "Main Checker"
    Private Sub NotifyPopup(ByVal Streamer As String)
        'Popup notifcations when a streamer comes online
        If InvokeRequired Then
            Invoke(New Notify(AddressOf NotifyPopup), New Object() {Streamer})
            Exit Sub
        End If
        If frmNotify.Visible = True Then
            Dim frm As New frmNotify
            frm.Show()
            frm.lblStreamer.Text = Streamer
        Else
            frmNotify.Show()
            frmNotify.lblStreamer.Text = Streamer
        End If
    End Sub
    Private Sub GetListOfFollows()
        'Gets a list of channels that the user is following
        FollowList = ""
        Dim responseString = ""
TryAgian:
        Try
            Dim url = "https://api.twitch.tv/kraken/streams/followed?limit=100"
            Dim request As HttpWebRequest = WebRequest.Create(url)
            request.Method = "GET"
            request.Accept = "application/vnd.twitchtv.v5+json"
            request.Headers.Add("Authorization", "OAuth " & objIniFile.GetString("Twitch Settings", "Password", Nothing))
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
        Dim twitchStreams As JArray = DirectCast(obj("streams"), JArray)
        For i As Integer = 0 To twitchStreams.Count - 1
            Dim streamer As String = twitchStreams(i)("channel")("_id")
            'Adds all streamers to a string with a comma seperating them
            FollowList += streamer & ","
        Next
    End Sub
    Private Sub MainCheckVer2()
        'Turns on the counter to count down to the next reset
        Count = New System.Threading.Thread(AddressOf CountDownTimer)
        Count.IsBackground = True
        Dim StopWatch As New Stopwatch
        StopWatch.Start()
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim URL As String = ""
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Calls the fuction to get all channels that the user is following
        Call GetListOfFollows()
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Tries to open up the API stream if it fails wait 5 seconds and then try agian until it works
        Dim responseString As String = ""
        Dim ws As System.Net.WebResponse
TryAgian:
        Try
            URL = "https://api.twitch.tv/kraken/streams/?channel=" & FollowList
            Dim request As HttpWebRequest = WebRequest.Create(URL)
            request.Method = "GET"
            request.Accept = "application/vnd.twitchtv.v5+json"
            request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
            ws = request.GetResponse()
            Using stream As System.IO.Stream = ws.GetResponseStream()
                Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                responseString = reader.ReadToEnd()
            End Using
        Catch ex As Exception
            System.Threading.Thread.Sleep(5000)
            GoTo TryAgian
        End Try
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Adds the old streamlist to a new array to store the old data to check if new streams were added to the list
        Dim StreamsOld As New ArrayList
        For i = 0 To lstStreams.Items.Count - 1
            Dim Stream As String = Get_Between(lstStreams.Items.Item(i), lstStreams.Items.Item(i).ToString.IndexOf("(") + 1, lstStreams.Items.Item(i).ToString.IndexOf(")"))
            StreamsOld.Add(Stream)
        Next
        lstStreams.Items.Clear()
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Gets the game,viewer,streamer,and status of the current stream
        Dim obj As JObject = JObject.Parse(responseString)
        Dim twitchStreams As JArray = DirectCast(obj("streams"), JArray)
        For i As Integer = 0 To twitchStreams.Count - 1
            Dim game As String = twitchStreams(i)("game")
            Dim viewers As String = twitchStreams(i)("viewers")
            Dim currentstreamer As String = twitchStreams(i)("channel")("display_name")
            Dim status As String = twitchStreams(i)("channel")("status")
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Adds the status to a dictonrey with a username so when you highlight over it it displays the status
            If Stream_Dic.ContainsKey(currentstreamer) Then
                Stream_Dic.Item(currentstreamer) = status
            Else
                Stream_Dic.Add(currentstreamer, status)
            End If
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'If the check box Notifications is checked then move on and if no window is fullscreened
            If chkNotify.Checked = True And FullscrenWindowExists() = False Then
                'If the stream is recently added to the list display a notifcation that the stream has come on
                If StreamsOld.Contains(currentstreamer) Then
                    'Don't pop up a notification if streamer is already in the list
                Else
                    Dim NotifyThread = New Threading.Thread(Sub() NotifyPopup(currentstreamer))
                    NotifyThread.IsBackground = True
                    NotifyThread.Start()
                End If
            End If
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Adds the stream to the listbox
            lstStreams.Items.Add(viewers & " - " & "(" & currentstreamer & ")" & " - " & game)
        Next
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Enabled buttons and stops the count down and restarts it all over agian
        StopWatch.Stop()
        ElapsedTime = StopWatch.Elapsed.Seconds
        StopWatch.Reset()
        Count.Start()
    End Sub
#End Region
#Region "Opening of new streams"
    Private Sub cmsTray_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmsTray.ItemClicked
        'Gets the current streamer
        Dim StartPoint, EndPoint As Integer
        StartPoint = e.ClickedItem.Text.IndexOf("(") + 1
        EndPoint = e.ClickedItem.Text.LastIndexOf(")")
        'Calls the public load stream function. Need to pass a button variable and a streamer variable
        PubTwitchButton = btnLoad
        PubCurrentStreamer = e.ClickedItem.Text.Substring(StartPoint, EndPoint - StartPoint)
        liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        liveStreamerProcess.StartInfo.CreateNoWindow = True
        liveStreamerProcess.StartInfo.FileName = StreamlinkPath
        liveStreamerProcess.StartInfo.Arguments = "twitch.tv/" & PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        Dim t As New Threading.Thread(AddressOf OpenTwitchStream)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub lststreams_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstStreams.MouseDoubleClick
        'Calls the public load stream function. Need to pass a button variable and a streamer variable
        PubTwitchButton = btnLoad
        PubCurrentStreamer = lstStreams.SelectedItem.ToString.Substring(lstStreams.SelectedItem.ToString.IndexOf("(") + 1, lstStreams.SelectedItem.ToString.IndexOf(")") - lstStreams.SelectedItem.ToString.IndexOf("(") - 1)
        liveStreamerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        liveStreamerProcess.StartInfo.CreateNoWindow = True
        liveStreamerProcess.StartInfo.FileName = StreamlinkPath
        liveStreamerProcess.StartInfo.Arguments = "twitch.tv/" & PubCurrentStreamer & " Best" & " --player=" & """" & VLCPath
        Dim t As New Threading.Thread(AddressOf OpenTwitchStream)
        t.IsBackground = True
        t.Start()
    End Sub
#End Region
#Region "Get Window Stuff"
    Private Function GetWindows() As String
        On Error Resume Next
        Dim hwnd As Integer
        Dim s1 As String
        Dim s2 As String
        hwnd = apiGetTopWindow(apiGetDesktopWindow)
        s1 = ""
        s2 = ""
        Do
            s2 = GetWindowName(hwnd)
            lstAllWindows.Items.Add(s2)

            s1 = s1 & " - " & s2
            hwnd = apiGetWindow(hwnd, GW_HWNDNEXT)
            If hwnd = 0 Then
                GetWindows = s1
                Exit Do
            End If
        Loop
    End Function
    Public Function GetWindowName(ByVal hWnd As Integer) As String
        On Error Resume Next
        Dim tLength As Integer
        Dim rValue As Integer
        Dim wName As String
        tLength = apiGetWindowTextLength(hWnd) + 4
        wName = ""
        wName = wName.PadLeft(tLength) 'add buffer
        rValue = apiGetWindowText(hWnd, wName, tLength)
        wName = wName.Substring(0, rValue) 'strip buffer
        GetWindowName = wName.ToLower
    End Function
#End Region
#Region "Form Events"
    Private Sub lstStreams_KeyDown(sender As Object, e As KeyEventArgs) Handles lstStreams.KeyDown
        If e.Alt = True And e.KeyCode = Keys.O Then
            Process.Start(Application.StartupPath)
        End If
    End Sub
    Private Sub lstStreams_MouseMove(sender As Object, e As MouseEventArgs) Handles lstStreams.MouseMove
        Dim Mouse_Point As Integer = lstStreams.IndexFromPoint(e.Location)
        If Mouse_Point <= -1 Then Exit Sub
        If Mouse_Point = Mouse_Point_Tooltip Then

        Else
            Dim Streamer As String = Get_Between(lstStreams.Items.Item(Mouse_Point).ToString, lstStreams.Items.Item(Mouse_Point).ToString.IndexOf("(") + 1, lstStreams.Items.Item(Mouse_Point).ToString.LastIndexOf(")"))
            ToolTip_lstStreams.SetToolTip(lstStreams, Stream_Dic.Item(Streamer))
        End If
        Mouse_Point_Tooltip = Mouse_Point
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set's the stream quaility to source
        ComboBox1.SelectedIndex = 0
        'Allows for mutliple threading the Noob way
        Control.CheckForIllegalCrossThreadCalls = False
        'Calls the main checker
        MainThread = New System.Threading.Thread(AddressOf MainCheckVer2)
        MainThread.Start()
        'Set's the path to google chrome and VLC
        VLCPath = objIniFile.GetString("Twitch Settings", "VLC Path", Nothing)
    End Sub
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Minimized
                NotifyIcon2.Visible = True
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub NotifyIcon2_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon2.MouseDoubleClick
        Try
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = True
            Me.TopMost = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CopyUrlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyUrlToolStripMenuItem.Click
        Clipboard.SetText("http://www.twitch.tv/" & lstStreams.SelectedItem.ToString.Substring(lstStreams.SelectedItem.ToString.IndexOf("(") + 1, lstStreams.SelectedItem.ToString.IndexOf(")") - lstStreams.SelectedItem.ToString.IndexOf("(") - 1))
    End Sub
    Private Sub CopyTitleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTitleToolStripMenuItem.Click
        Dim Streamer = lstStreams.SelectedItem.ToString.Substring(lstStreams.SelectedItem.ToString.IndexOf("(") + 1, lstStreams.SelectedItem.ToString.IndexOf(")") - lstStreams.SelectedItem.ToString.IndexOf("(") - 1)
        Clipboard.SetText(Stream_Dic.Item(Streamer))
    End Sub
    Private Sub lblTimeCount_MouseEnter(sender As Object, e As EventArgs) Handles lblTimeCount.MouseEnter
        lblTimeCount.ForeColor = Color.Aqua
    End Sub
    Private Sub lblTimeCount_MouseLeave(sender As Object, e As EventArgs) Handles lblTimeCount.MouseLeave
        lblTimeCount.ForeColor = Color.White
    End Sub
    Private Sub chkNotify_MouseEnter(sender As Object, e As EventArgs) Handles chkNotify.MouseEnter
        chkNotify.ForeColor = Color.Aqua
    End Sub
    Private Sub chkNotify_MouseLeave(sender As Object, e As EventArgs) Handles chkNotify.MouseLeave
        chkNotify.ForeColor = Color.White
    End Sub
#End Region
#Region "Button Clicks"
    Private Sub btnNonTwitch_Click(sender As Object, e As EventArgs) Handles btnNonTwitch.Click
        frmOpenStream.Show()
    End Sub
    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        frmHistory.Show()
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Process.Start(Application.StartupPath & "\config.ini")
    End Sub
    Private Sub NotifyIcon2_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon2.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsTray.Items.Clear()
            For i = 0 To lstStreams.Items.Count - 1
                cmsTray.Items.Add(lstStreams.Items.Item(i))
            Next
        End If
    End Sub
    Private Sub btnChat_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChat.Click
        Process.Start(Application.StartupPath & "/Chatty/Chatty.jar", "-connect " & "-channel " & lstStreams.SelectedItem.ToString.Substring(lstStreams.SelectedItem.ToString.IndexOf("(") + 1, lstStreams.SelectedItem.ToString.IndexOf(")") - lstStreams.SelectedItem.ToString.IndexOf("(") - 1))
    End Sub
    Private Sub btnLoad_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Call lststreams_MouseDoubleClick(sender, e)
    End Sub
    Private Sub btnViewGames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewGames.Click
        frmViewStreams.Show()
    End Sub
    Private Sub btnFeatured_Click(sender As Object, e As EventArgs) Handles btnFeatured.Click
        frmViewFeatured.Show()
    End Sub
    Private Sub btnSpeedRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeedRun.Click
        frmSpeedRun.Show()
    End Sub
    Private Sub btnEditStreams_Click(sender As System.Object, e As System.EventArgs) Handles btnEditStreams.Click
        frmEditStreams.Show()
    End Sub
    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        If lstStreams.SelectedIndex < 0 Then Exit Sub
        frmInfo.Show()
        frmInfo.DoStreamInfo(lstStreams.SelectedItem.ToString.Substring(lstStreams.SelectedItem.ToString.IndexOf("(") + 1, lstStreams.SelectedItem.ToString.IndexOf(")") - lstStreams.SelectedItem.ToString.IndexOf("(") - 1))
    End Sub
    Private Sub lstStreams_MouseDown(sender As Object, e As MouseEventArgs) Handles lstStreams.MouseDown
        Dim index As Integer, pt As New Point(e.X, e.Y)
        index = lstStreams.IndexFromPoint(pt)
        If e.Button = MouseButtons.Right And index >= 0 And index < lstStreams.Items.Count Then
            lstStreams.ClearSelected()
            lstStreams.SelectedIndex = index
        ElseIf e.Button = MouseButtons.Left And index >= 0 And index < lstStreams.Items.Count Then
            lstStreams.ClearSelected()
            lstStreams.SelectedIndex = index
        End If
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Count.IsAlive = True Then
            Count.Abort()
        End If
        If MainThread.IsAlive = True Then
            MainThread.Abort()
        End If
        MainThread = New System.Threading.Thread(AddressOf MainCheckVer2)
        MainThread.Start()
    End Sub
#End Region
#Region "Functions"
    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure
    Private Function FullscrenWindowExists() As Boolean
        'Checks if there is a fullscreen window
        Dim clsScreen As System.Drawing.Rectangle = Screen.GetBounds(New System.Drawing.Point(0, 0))
        For Each clsProcess As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
            Dim clsRect As New RECT
            Try
                If GetWindowRect(clsProcess.MainWindowHandle, clsRect) <> 0 Then
                    If clsRect.Top <= 0 And clsRect.Left <= 0 And clsRect.Right >= clsScreen.Width And clsRect.Bottom >= clsScreen.Height Then
                        If clsProcess.ProcessName = "mpc-hc64" Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            Catch
                'some processes might exist before we get to them, causing an error...
            End Try
        Next
    End Function
    Private Function Get_Between(ByVal File_String As String, ByVal Start_Point As Integer, ByVal End_Point As Integer) As String
        Return File_String.Substring(Start_Point, End_Point - Start_Point)
    End Function
    Private Sub CountDownTimer()
        Dim Count As Integer = 180 - ElapsedTime
        Dim Secs As Integer = 60 - ElapsedTime
        Dim Mins As Integer = 2
        Do Until Count = 0
            If Count = 120 Then Mins = 1
            If Count = 60 Then Mins = 0
            If Secs = 0 Then Secs = 60
            Count = Count - 1
            Secs = Secs - 1
            Select Case Secs
                Case 9 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "09"
                Case 8 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "08"
                Case 7 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "07"
                Case 6 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "06"
                Case 5 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "05"
                Case 4 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "04"
                Case 3 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "03"
                Case 2 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "02"
                Case 1 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "01"
                Case 0 : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & "00"
                Case Else : lblTimeCount.Text = "Time Until Next Refresh - " & Mins.ToString & ":" & Secs.ToString
            End Select
            System.Threading.Thread.Sleep(1000)
        Loop
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MainThread = New System.Threading.Thread(AddressOf MainCheckVer2)
        MainThread.Start()
    End Sub
    Private Sub GetReverOrder()
        Dim lsttemp As New ListBox
        lsttemp.Items.AddRange(lstStreams.Items)

        Dim GetNumber As Integer

        For i = 0 To lsttemp.Items.Count - 1
            Try
                GetNumber = lsttemp.Items.Item(i).ToString.Substring(0, lsttemp.Items.Item(i).ToString.IndexOf(" "))
            Catch ex As Exception
                GetNumber = 1
            End Try
            Select Case GetNumber.ToString.Length
                Case 6
                    lsttemp.Items.Item(i) = "0" & lsttemp.Items.Item(i)
                Case 5
                    lsttemp.Items.Item(i) = "00" & lsttemp.Items.Item(i)
                Case 4
                    lsttemp.Items.Item(i) = "000" & lsttemp.Items.Item(i)
                Case 3
                    lsttemp.Items.Item(i) = "0000" & lsttemp.Items.Item(i)
                Case 2
                    lsttemp.Items.Item(i) = "00000" & lsttemp.Items.Item(i)
                Case 1
                    lsttemp.Items.Item(i) = "000000" & lsttemp.Items.Item(i)
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
            lsttemp.Items.Item(i) = lsttemp.Items.Item(i).ToString.Trim("00000")
            lsttemp.Items.Item(i) = lsttemp.Items.Item(i).ToString.Trim("000000")
        Next

        lstStreams.Items.Clear()
        lstStreams.Items.AddRange(lsttemp.Items)
    End Sub
#End Region
End Class
