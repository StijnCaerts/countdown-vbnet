Public Class FormCountdown
    Dim timeLeft As Integer = DateDiff(DateInterval.Second, Now, CDate("01 Jan 2015 00:00:00"))

    Private Sub FormCountdown_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateLabelTime()
        FormCountdown_Resize()
        Timer1.Interval = 1000
        Timer1.Start()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If timeLeft > 0 Then
            timeLeft -= 1
            updateLabelTime()
        Else
            Timer1.Stop()
            newYear()
        End If
    End Sub

    Private Sub updateLabelTime()
        Dim hours As Integer
        Dim minutes As Integer
        Dim seconds As Integer

        hours = timeLeft \ 3600
        minutes = (timeLeft - hours * 3600) \ 60
        seconds = timeLeft - hours * 3600 - minutes * 60

        LabelTime.Text = Format(hours, "00") & " : " & Format(minutes, "00") & " : " & Format(seconds, "00")
    End Sub

    Private Sub newYear()
        LabelTime.Text = "Happy New Year!"
        FormCountdown_Resize()

        LabelTime.ForeColor = Color.DarkSlateBlue
        Me.BackColor = Color.Gold
    End Sub

    Private Sub FormCountdown_Resize() Handles Me.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            LabelTime.Font = New Font("Trebuchet MS", (Me.ClientSize.Width / LabelTime.Text.Length) * 1.125)
            LabelTime.Left = (Me.ClientSize.Width - LabelTime.Width) / 2
            LabelTime.Top = (Me.ClientSize.Height - LabelTime.Height) / 2
        End If
        
    End Sub
End Class
