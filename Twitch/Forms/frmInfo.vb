Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class frmInfo
    Public Sub DoStreamInfo(ByVal Streamer As String)
        Dim Client2 As New WebClient
        Dim URL2 As String
        Try
            Client2.Headers.Add("Client-ID", "4zeqxj7zalq572vvqtnzbr2i4yhy5qj")
            URL2 = Client2.DownloadString("https://api.twitch.tv/kraken/streams/" & Streamer)
        Catch ex As WebException
            Exit Sub
        End Try

        Try
            Dim token As JToken = JObject.Parse(URL2)
            Dim status As String = token.SelectToken("stream")("channel")("status")
            Dim delay As String = token.SelectToken("stream")("channel")("delay")
            Dim totalviews As String = token.SelectToken("stream")("channel")("views")
            Dim totalfollowers As String = token.SelectToken("stream")("channel")("followers")
            Dim streampicture As String = token.SelectToken("stream")("preview")("medium")

            Me.Text = Streamer
            lblStatus.Text = "Status: " & status
            lbldelay.Text = "Delay: " & delay
            lblTotalViews.Text = "Total Views: " & totalviews
            lblFollowers.Text = "Total Followers: " & totalfollowers
            PictureBox1.ImageLocation = streampicture
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub lblStatus_MouseEnter(sender As Object, e As EventArgs) Handles lblStatus.MouseEnter
        lblStatus.ForeColor = Color.Aqua
    End Sub

    Private Sub lblStatus_MouseLeave(sender As Object, e As EventArgs) Handles lblStatus.MouseLeave
        lblStatus.ForeColor = Color.White
    End Sub

    Private Sub lblTotalViews_MouseEnter(sender As Object, e As EventArgs) Handles lblTotalViews.MouseEnter
        lblTotalViews.ForeColor = Color.Aqua
    End Sub

    Private Sub lblTotalViews_MouseLeave(sender As Object, e As EventArgs) Handles lblTotalViews.MouseLeave
        lblTotalViews.ForeColor = Color.White
    End Sub

    Private Sub lblFollowers_MouseEnter(sender As Object, e As EventArgs) Handles lblFollowers.MouseEnter
        lblFollowers.ForeColor = Color.Aqua
    End Sub

    Private Sub lblFollowers_MouseLeave(sender As Object, e As EventArgs) Handles lblFollowers.MouseLeave
        lblFollowers.ForeColor = Color.White
    End Sub

    Private Sub lbldelay_MouseEnter(sender As Object, e As EventArgs) Handles lbldelay.MouseEnter
        lbldelay.ForeColor = Color.Aqua
    End Sub

    Private Sub lbldelay_MouseLeave(sender As Object, e As EventArgs) Handles lbldelay.MouseLeave
        lbldelay.ForeColor = Color.White
    End Sub
End Class