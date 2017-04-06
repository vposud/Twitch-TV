Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class frmEditStreams
#Region "Declares"
    'Dim FTP_UP_Thread As New System.Threading.Thread(AddressOf FTP_Upload)
    'Dim FTP_DOWN_Thread As New System.Threading.Thread(AddressOf FTP_Download)
    Private Delegate Sub Notify()
    Private Stream_Dic As New Dictionary(Of String, String)
#End Region
#Region "Form Events"
    Private Sub frmEditStreams_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim t As New Threading.Thread(AddressOf Load_Streams)
        t.IsBackground = True
        t.Start()
    End Sub
#End Region
#Region "Functions"
    Private Sub Load_Streams()
        'Get list from twitch follows
        Dim responseString = ""
        Dim Total As Integer = 0
        Dim TotalLimt As Integer = -25
TryAgian:
        Try
            TotalLimt += 25
            Dim url = "https://api.twitch.tv/kraken/users/" & Get_ID() & "/follows/channels?offset=" & TotalLimt
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
        Dim twitchStreams As JArray = DirectCast(obj("follows"), JArray)
        Total = twitchStreams.Count / 25
        For i As Integer = 0 To twitchStreams.Count - 1
            Dim streamer As String = twitchStreams(i)("channel")("name")
            Dim stream_id As String = twitchStreams(i)("channel")("_id")
            'Adds all streamers to a string with a comma seperating them
            lstEditStreams.Items.Add(streamer)
            Stream_Dic.Add(streamer, stream_id)
        Next
        For i = 1 To Total
            GoTo TryAgian
        Next
    End Sub
#End Region
#Region "Button Clicks"
    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        'Removes a channel from your following list
        If lstEditStreams.SelectedIndex < 0 Then Exit Sub
        Dim ChannelID = Stream_Dic.Item(lstEditStreams.SelectedItem)
        Dim responseString = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/users/" & Get_ID() & "/follows/channels/" & ChannelID
            Dim request As HttpWebRequest = WebRequest.Create(url)
            request.Method = "DELETE"
            request.Accept = "application/vnd.twitchtv.v5+json"
            request.Headers.Add("Authorization", "OAuth " & objIniFile.GetString("Twitch Settings", "Password", Nothing))
            request.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
            Dim ws = request.GetResponse()
            Using stream As System.IO.Stream = ws.GetResponseStream()
                Dim reader As New IO.StreamReader(stream, System.Text.Encoding.UTF8)
                responseString = reader.ReadToEnd()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, Title:="Remove")
            Exit Sub
        End Try
        lstEditStreams.Items.RemoveAt(lstEditStreams.SelectedIndex)
        lstEditStreams.SelectedIndex = 0
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Adds a channel from your following list
        Dim New_Streamer As String
        New_Streamer = InputBox("Type the Twitch name of the streamer you want to add", "Add Streamer")
        If New_Streamer = "" Then Exit Sub

        Dim responseString = ""
        Try
            Dim url = "https://api.twitch.tv/kraken/users/" & Get_ID() & "/follows/channels/" & Get_ChannelID(New_Streamer)
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
        lstEditStreams.Items.Clear()
        Stream_Dic.Clear()
        Call Load_Streams()
    End Sub
#End Region
#Region "FTP"
    'Private Sub FTP_Upload()
    '    Try
    '        Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(FtpDir & "streams.txt"), System.Net.FtpWebRequest)
    '        clsRequest.Credentials = New System.Net.NetworkCredential(Account, Password)
    '        clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

    '        ' read in file...
    '        Dim bFile() As Byte = System.IO.File.ReadAllBytes(Application.StartupPath & "\streams.txt")

    '        ' upload file...
    '        Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
    '        clsStream.Write(bFile, 0, bFile.Length)
    '        clsStream.Close()
    '        clsStream.Dispose()
    '        MsgBox("Upload Successful")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Private Sub FTP_Download()
    '    Dim buffer(1023) As Byte ' Allocate a read buffer of 1kB size
    '    Dim bytesIn As Integer ' Number of bytes read to buffer
    '    Dim totalBytesIn As Integer ' Total number of bytes received (= filesize)
    '    Dim output As IO.Stream ' A file to save response
    '    Try
    '        Dim FTPRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(FtpDir & "streams.txt"), System.Net.FtpWebRequest)

    '        ' No credentials needed in this case. Usually you need to provide them. Catch the appropriate error if/when credentials are wrong!
    '        FTPRequest.Credentials = New System.Net.NetworkCredential(Account, Password)
    '        ' Send a request to download a file
    '        FTPRequest.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
    '        ' FTP server return a _response_ to your request
    '        Dim stream As System.IO.Stream = FTPRequest.GetResponse.GetResponseStream

    '        ' If you need the length of the file, send a request Ftp.GetFileSize and read the response
    '        'Dim length As Integer = CInt(FTPRequest.GetResponse.ContentLength)

    '        ' Write the content to the output file
    '        output = System.IO.File.Create(Application.StartupPath & "\streams.txt")
    '        bytesIn = 1 ' Set initial value to 1 to get into loop. We get out of the loop when bytesIn is zero
    '        Do Until bytesIn < 1
    '            bytesIn = stream.Read(buffer, 0, 1024) ' Read max 1024 bytes to buffer and get the actual number of bytes received
    '            If bytesIn > 0 Then
    '                ' Dump the buffer to a file
    '                output.Write(buffer, 0, bytesIn)
    '                ' Calc total filesize
    '                totalBytesIn += bytesIn
    '                ' Show user the filesize
    '                Application.DoEvents()
    '            End If
    '        Loop
    '        ' Close streams
    '        output.Close()
    '        stream.Close()
    '        Call Load_Streams()
    '        MsgBox("Update Successful")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
#End Region
End Class