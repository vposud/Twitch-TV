Imports System.Net
Imports Newtonsoft.Json.Linq
Imports TechLifeForum

Public Class frmChat
    Dim username As String = objIniFile.GetString("Twitch Settings", "Username", Nothing)
    Dim password As String = objIniFile.GetString("Twitch Settings", "Password", Nothing)
    Dim SubIcon As String
    Dim VScrollB As Boolean = True
    Dim Price As Boolean = False
    Dim tCheckMouse As New Threading.Thread(AddressOf CheckMouse)
    Dim WithEvents IRC As New IrcClient("irc.twitch.tv", 6667)

#Region "IRC"
    Private Sub IRC_RawMessage(sender As Object, e As RawMessageEventArgs) Handles IRC.RawMessage
        Try
            If e.RawMessage.Contains("@color") Then
                Dim IrcColor = Get_Between(e.RawMessage, e.RawMessage.IndexOf("@color=") + 7, e.RawMessage.IndexOf(";display-name="))
                Dim IrcName = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";display-name=") + 14, e.RawMessage.IndexOf(";emotes="))
                Dim IrcName2 = Get_Between(e.RawMessage, e.RawMessage.IndexOf(" :") + 2, e.RawMessage.IndexOf("!"))
                Dim IrcEmotes As String = ""
                If e.RawMessage.Contains(";sent-ts=") Then
                    IrcEmotes = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";emotes=") + 8, e.RawMessage.IndexOf(";sent-ts="))
                Else
                    IrcEmotes = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";emotes=") + 8, e.RawMessage.IndexOf(";mod="))
                End If
                Dim IrcEmotesSplit = IrcEmotes.Split("/")
                Dim IrcSubscriber As String = ""
                If e.RawMessage.Contains(";tmi-sent-ts=") Then
                    IrcSubscriber = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";subscriber=") + 12, e.RawMessage.IndexOf(";tmi-sent-ts="))
                Else
                    IrcSubscriber = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";subscriber=") + 12, e.RawMessage.IndexOf(";turbo="))
                End If
                Dim IrcTurbo = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";turbo=") + 7, e.RawMessage.IndexOf(";user-type="))
                Dim IrcType = Get_Between(e.RawMessage, e.RawMessage.IndexOf(";user-type=") + 11, e.RawMessage.IndexOf(" :"))
                Dim IrcMessage = e.RawMessage.Substring(e.RawMessage.IndexOf("PRIVMSG #" & Me.Text.ToLower & " :") + 11 + Me.Text.Length)
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'If the user is the broadcaster then set a broadcaster image
                If IrcName2 = Me.Text.ToLower Then
                    Dim Badge As Image = Image.FromFile(Application.StartupPath & "\images\global\broadcaster.png")
                    Clipboard.SetImage(Badge)
                    RichTextBox1.ReadOnly = False
                    RichTextBox1.Paste()
                    RichTextBox1.ReadOnly = True
                End If
                'If the user is a staff set a staff image
                If IrcType = "staff" Then
                    Dim Badge As Image = Image.FromFile(Application.StartupPath & "\images\global\staff.png")
                    Clipboard.SetImage(Badge)
                    RichTextBox1.ReadOnly = False
                    RichTextBox1.Paste()
                    RichTextBox1.ReadOnly = True
                End If
                'If the user is a mod set a mod image
                If IrcType = "mod" Then
                    Dim Badge As Image = Image.FromFile(Application.StartupPath & "\images\global\mod.png")
                    Clipboard.SetImage(Badge)
                    RichTextBox1.ReadOnly = False
                    RichTextBox1.Paste()
                    RichTextBox1.ReadOnly = True
                End If
                'If the user is a sub then use the sub icon
                If IrcSubscriber = "1" Then
                    'If cache emotes is checked on then download and save the sub icon otherwise just dislay it
                    Dim Badge As Image
                    If objIniFile.GetString("Twitch Settings", "Cache Emotes", Nothing) = "True" Then
                        If IO.File.Exists(Application.StartupPath & "\images\subs\" & Me.Text.ToLower & ".png") = False Then
                            Dim WebClient = New System.Net.WebClient()
                            WebClient.DownloadFile(SubIcon, Application.StartupPath & "\images\subs\" & Me.Text.ToLower & ".png")
                        End If
                        Badge = Image.FromFile(Application.StartupPath & "\images\subs\" & Me.Text.ToLower & ".png")
                    Else
                        Badge = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(SubIcon)))
                    End If

                    Clipboard.SetImage(Badge)
                    RichTextBox1.ReadOnly = False
                    RichTextBox1.Paste()
                    RichTextBox1.ReadOnly = True
                    RichTextBox1.AppendText(" ")
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'If the color is black set it to red instead
                If IrcColor = "#000000" Then IrcColor = "#FF0000"
                'If there is no color then color it red
                If IrcColor = "" Then IrcColor = "#FF0000"
                'Sets the color of the username to the color they selected on twitch
                RichTextBox1.SelectionColor = ColorTranslator.FromHtml(IrcColor)
                'If display name is blank then use the second name
                If IrcName = "" Then
                    RichTextBox1.AppendText(IrcName2)
                Else
                    RichTextBox1.AppendText(IrcName)
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Emotes
                If IrcEmotes <> "" And objIniFile.GetString("Twitch Settings", "Display Emotes", Nothing) = "True" Then
                    'Sorts the emote list
                    Dim EmoteSplitArray, EmoteSplitSort As New ArrayList
                    For Each String1 As String In IrcEmotesSplit
                        Dim EmoteNum = String1.Split(":")
                        Dim EmoteSpot = EmoteNum(1).Split(",")
                        For Each String2 As String In EmoteSpot
                            EmoteSplitArray.Add(EmoteNum(0) & ":" & String2)
                            Dim StartPos As String() = String2.Split("-")
                            Dim Num As Integer = (StartPos(0))
                            EmoteSplitSort.Add(Num)
                        Next
                    Next

                    EmoteSplitSort.Sort()
                    IrcEmotes = ""

                    For Each String1 As String In EmoteSplitSort
                        For Each String2 As String In EmoteSplitArray
                            Dim EmoteNum = String2.Split(":")
                            Dim EmoteSpot = EmoteNum(1).Split(",")
                            Dim StartPos As String() = EmoteSpot(0).Split("-")
                            If String1 = StartPos(0) Then
                                IrcEmotes += String2 & "/"
                            End If
                        Next
                    Next
                    IrcEmotesSplit = IrcEmotes.TrimEnd("/").Split("/")

                    'Sets the emote in the message if there is one
                    Dim IntStart As Integer = 0
                    RichTextBox1.SelectionColor = Color.White
                    RichTextBox1.AppendText(": ")
                    For i = 0 To IrcEmotesSplit.Length - 1
                        Dim EmoteNum = IrcEmotesSplit(i).Split(":")
                        Dim EmoteSpot = EmoteNum(1).Split(",")

                        'If cache emotes is checked on then download and save the emote
                        If objIniFile.GetString("Twitch Settings", "Cache Emotes", Nothing) = "True" Then
                            If IO.File.Exists(Application.StartupPath & "\images\emotes\" & EmoteNum(0) & ".png") = False Then
                                Dim WebClient = New System.Net.WebClient()
                                WebClient.DownloadFile("http://static-cdn.jtvnw.net/emoticons/v1/" & EmoteNum(0) & "/1.0", Application.StartupPath & "\images\emotes\" & EmoteNum(0) & ".png")
                            End If
                        End If

                        For i2 = 0 To EmoteSpot.Length - 1
                            Dim EmoteStartEnd = EmoteSpot(i2).Split("-")
                            RichTextBox1.AppendText(IrcMessage.Substring(IntStart, EmoteStartEnd(0) - IntStart))

                            'If cache emotes is checked on use the downloaded emote otherwise download it and use that
                            Dim Badge As Image
                            If objIniFile.GetString("Twitch Settings", "Cache Emotes", Nothing) = "True" Then
                                Badge = Image.FromFile(Application.StartupPath & "\images\emotes\" & EmoteNum(0) & ".png")
                            Else
                                Badge = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData("http://static-cdn.jtvnw.net/emoticons/v1/" & EmoteNum(0) & "/1.0")))
                            End If

                            Clipboard.SetImage(Badge)
                            RichTextBox1.ReadOnly = False
                            RichTextBox1.Paste()
                            RichTextBox1.ReadOnly = True

                            IntStart = EmoteStartEnd(1) + 1
                        Next
                    Next
                    RichTextBox1.AppendText(vbNewLine)
                Else
                    'If there is no emote just do a normal message
                    RichTextBox1.SelectionColor = Color.White
                    RichTextBox1.AppendText(": " & IrcMessage & vbNewLine)
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'If the scroll wheel is not being clicked then scroll the window to the bottom
                If VScrollB = True Then
                    RichTextBox1.ScrollToCaret()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub IRC_OnConnect(sender As Object, e As EventArgs) Handles IRC.OnConnect
        'Request tags to get color, sub and other stuff
        IRC.SendRaw("CAP REQ :twitch.tv/tags")
        'Join the channel
        IRC.SendRaw("JOIN :#" & Me.Text.ToLower)
        RichTextBox1.AppendText("Connected to " & Me.Text.ToLower & "!" & vbNewLine)
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Gets the sub icon
        Dim Client2 As New WebClient
        Dim URL2 As String = ""
        Try
            URL2 = Client2.DownloadString("https://api.twitch.tv/kraken/chat/" & Me.Text.ToLower & "/badges")
        Catch ex As WebException
        End Try
        Try
            Dim token As JToken = JObject.Parse(URL2)
            SubIcon = token.SelectToken("subscriber")("image")
        Catch ex As Exception
            'No sub icon
        End Try
    End Sub
#End Region

#Region "Functions"
    Private Sub CheckMouse()
        'Checks to see if the left mouse button is clicked and if it is then don't scroll the chat window down
        While MouseButtons = Windows.Forms.MouseButtons.Left
            VScrollB = False
            Threading.Thread.Sleep(2000)
        End While
        VScrollB = True
    End Sub
#End Region

#Region "Form Events"
    Private Sub frmChat_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        IRC.Disconnect()
    End Sub
    Private Sub frmChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Connects to the Twitch IRC
        IRC.Nick = username
        IRC.ServerPass = password
        IRC.Connect()
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If TextBox1.Text = "" Then Exit Sub

        'If /clear is typed then clear the chat window
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBox1.Text = "/clear" Then
                RichTextBox1.Clear()
                TextBox1.Clear()
                TextBox1.Focus()
                RichTextBox1.SelectionColor = Color.Orange
                RichTextBox1.AppendText("Chat window cleared" & vbNewLine)
                Exit Sub
            End If

            'if /price is typed then turn on the function to send what the channel host says
            If TextBox1.Text = "/price" Then
                If Price = False Then
                    Price = True
                    RichTextBox1.SelectionColor = Color.Orange
                    RichTextBox1.AppendText("Price turned on" & vbNewLine)
                    TextBox1.Clear()
                    TextBox1.Focus()
                    Exit Sub
                End If
                If Price = True Then
                    Price = False
                    RichTextBox1.SelectionColor = Color.Orange
                    RichTextBox1.AppendText("Price turned off" & vbNewLine)
                    TextBox1.Clear()
                    TextBox1.Focus()
                    Exit Sub
                End If
            End If

            'Sends the message and displays it in the richtextbox
            IRC.SendMessage("#" & Me.Text.ToLower, TextBox1.Text)
            RichTextBox1.SelectionColor = Color.Green
            RichTextBox1.AppendText(username)
            RichTextBox1.SelectionColor = Color.White
            RichTextBox1.AppendText(": " & TextBox1.Text & vbNewLine)
            RichTextBox1.ScrollToCaret()
            TextBox1.Clear()
            TextBox1.Focus()
        End If
    End Sub
    Private Sub RichTextBox1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Process.Start(e.LinkText)
    End Sub
    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        Dim maxsize As Int32 = 5000 'Deletes the text once it gets to a certian amount of total lines
        Dim dropsize As Int32 = maxsize / 4
        If RichTextBox1.Text.Length > maxsize Then
            RichTextBox1.ReadOnly = False

            Dim endmarker As Int32 = RichTextBox1.Text.IndexOf(ControlChars.Lf, dropsize) + 1
            If endmarker < dropsize Then
                endmarker = dropsize
            End If

            RichTextBox1.[Select](0, endmarker)
            RichTextBox1.Cut()
        End If
        RichTextBox1.ReadOnly = True
    End Sub
    Private Sub RichTextBox1_VScroll(sender As Object, e As EventArgs) Handles RichTextBox1.VScroll
        'If the scroll bar is clicked then run the checkmouse function
        If tCheckMouse.IsAlive = False Then
            tCheckMouse = New Threading.Thread(AddressOf CheckMouse)
            tCheckMouse.IsBackground = True
            tCheckMouse.Start()
        End If
    End Sub
#End Region

End Class