Imports System.Net
Imports Newtonsoft.Json.Linq

Module PublicFunctions
    Public OpenChatString, ChromePath, VLCPath, PubCurrentStreamer, PubStreamSource As String
    Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean
    Public objIniFile As New IniFile(Application.StartupPath & "\Config.ini")
    Public PubTwitchButton As Button
    Public liveStreamerProcess As New Process
    Public StreamlinkPath = objIniFile.GetString("Twitch Settings", "Streamlink Path", Nothing)
    Public Function Get_ChannelID(ByVal Streamer As String)
        Dim responseString = ""
        Dim C_ID = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/search/channels?query=" & Streamer
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
            MsgBox(ex.Message, Title:="Get_ChannelID")
        End Try

        Dim obj As JObject = JObject.Parse(responseString)
        Dim twitchStreams As JArray = DirectCast(obj("channels"), JArray)
        If twitchStreams(0)("name") = Streamer Then
            C_ID = twitchStreams(0)("_id")
        End If
        Get_ChannelID = C_ID
    End Function
    Public Function Get_ID()
        Dim responseString = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/user"
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
            MsgBox(ex.Message, Title:="Get_ID")
        End Try

        Dim obj As JObject = JObject.Parse(responseString)
        Get_ID = obj("_id")
    End Function
    Public Function Get_Between(ByVal File_String As String, ByVal Start_Point As Integer, ByVal End_Point As Integer) As String
        Return File_String.Substring(Start_Point, End_Point - Start_Point)
    End Function
    Public Sub OpenTwitchStream()
        PubTwitchButton.Enabled = False
        liveStreamerProcess.Start() 'Starts the stream using livestreamer. Need to declare the process in the form it was loaded from so it doesn't open up another insatnce of the program. Don't know why
        System.Threading.Thread.Sleep(5000)

        'Tries to change the name of the window to the streamers name
        Dim Client2 As New WebClient
        Dim URL2 As String
        Try
            Client2.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
            URL2 = Client2.DownloadString("https://api.twitch.tv/kraken/streams/" & PubCurrentStreamer)
        Catch ex As WebException
            PubTwitchButton.Enabled = True
            Exit Sub
        End Try

        Try
            Dim token As JToken = JObject.Parse(URL2)
            Dim status As String = token.SelectToken("stream")("channel")("display_name")

            Dim procList() As Process = Process.GetProcessesByName("mpc-hc64")
            Dim p As Process
            Dim hwnd As Integer
            For Each p In procList
                If p.MainWindowTitle = "stdin" Then hwnd = p.MainWindowHandle
            Next
            SetWindowText(hwnd, status)
        Catch ex As Exception
            PubTwitchButton.Enabled = True
            Exit Sub
        End Try
        PubTwitchButton.Enabled = True
        SaveHistory(PubCurrentStreamer) 'Saves the history of the stream just opened
    End Sub
    Public Sub SaveHistory(ByVal Streamer As String)
        Try
            'Trys to load the History Amount from the settings. If it is blank then ask how many they want to save
            Dim HistoryAmount As Integer = objIniFile.GetInteger("Twitch Settings", "History Amount", Nothing)
            If HistoryAmount = Nothing Then
TryAgian1:
                Dim HisAmt As String = InputBox("Please input the amount of streams you want to save in history.", "History Amount", "10")
                If HisAmt = Nothing Then
                    MsgBox("You must enter a value greater then zero")
                    GoTo TryAgian1
                End If
                If IsNumeric(HisAmt) = False Then
                    MsgBox("You must enter a number")
                    GoTo TryAgian1
                End If
                objIniFile.WriteString("Twitch Settings", "History Amount", HisAmt)
                HistoryAmount = HisAmt
            End If

            'Reads the history file and puts it into a string so it can re write it with the new list
            Dim LinesCount As String() = IO.File.ReadAllLines(Application.StartupPath & "\History.txt")
            If LinesCount.Contains(Streamer) = False Then
                If LinesCount.Count >= HistoryAmount Then
                    Dim SW As New IO.StreamWriter(Application.StartupPath & "\History.txt", False)
                    SW.WriteLine(Streamer)
                    For i = 0 To HistoryAmount - 2
                        SW.WriteLine(LinesCount(i))
                    Next
                    SW.Close()
                Else
                    Dim SW2 As New IO.StreamWriter(Application.StartupPath & "\History.txt", False)
                    SW2.WriteLine(Streamer)
                    For Each StreamString As String In LinesCount
                        SW2.WriteLine(StreamString)
                    Next
                    SW2.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
