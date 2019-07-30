Imports System.IO
Imports Newtonsoft.Json

Class oAuth

    Private _token As zoho_Token
    Public Property Token As zoho_Token
        Get
            If _token.Expired Then
                RefreshToken()
            End If
            Return _token

        End Get

        Set(value As zoho_Token)
            _token = value
        End Set

    End Property

    Sub New()
        RefreshToken()

    End Sub

    Private Sub RefreshToken()

        Console.Write(String.Format("Requesting security token from {0}...", My.Settings.Accounts_URL))

        Dim requestStream As Stream = Nothing
        Dim uploadResponse As Net.HttpWebResponse = Nothing
        Dim uploadRequest As Net.HttpWebRequest = CType(
            Net.HttpWebRequest.Create(
                String.Format(
                "https://{0}/oauth/v2/token?grant_type=refresh_token&client_id={1}&client_secret={2}&refresh_token={3}",
                My.Settings.Accounts_URL,
                My.Settings.client_id,
                My.Settings.client_secret,
                My.Settings.refresh_token
            )
        ), Net.HttpWebRequest)

        With uploadRequest
            .Method = "POST"
            .Proxy = Nothing

        End With

        Dim reader As New StreamReader(uploadRequest.GetResponse().GetResponseStream)

        _token = JsonConvert.DeserializeObject(reader.ReadToEnd, GetType(zoho_Token))

        Console.WriteLine("Ok.")
        Console.WriteLine(_token.toSerial)

    End Sub

End Class
