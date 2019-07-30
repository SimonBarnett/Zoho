Imports System.Timers
Imports Newtonsoft.Json

Public Class zoho_Token

    Private _timer As Timer

    Public Property access_token As String
    Public Property expires_in_sec As Integer
    Public Property api_domain As String
    Public Property token_type As String
    Public Property expires_in As Integer
    Public ReadOnly Property Expired As Boolean
        Get
            Return expires_in_sec < 60
        End Get
    End Property

    Sub New()
        _timer = New Timer()
        _timer.Interval = 1000 'Timer will trigger one second after start
        AddHandler _timer.Elapsed, AddressOf Timer_tick 'Timer will call this sub when done
        _timer.Start() 'Start the timer

    End Sub

    Private Sub Timer_tick(sender As Object, e As EventArgs)
        expires_in_sec -= 1

    End Sub

    Public Function toSerial() As String

        Dim s As New JsonSerializerSettings
        s.NullValueHandling = NullValueHandling.Ignore

        Return JsonConvert.SerializeObject(
            Me,
            Newtonsoft.Json.Formatting.Indented,
            s
        )

    End Function

End Class
