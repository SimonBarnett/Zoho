Imports System.IO
Imports Newtonsoft.Json

Public MustInherit Class zoho_Request

    Public MustOverride ReadOnly Property EndPoint As String

    Public Function Send() As Object

        Dim requestStream As Stream = Nothing
        Dim uploadResponse As Net.HttpWebResponse = Nothing
        Dim uploadRequest As Net.HttpWebRequest =
            CType(Net.HttpWebRequest.Create(EndPoint), Net.HttpWebRequest)

        With uploadRequest
            .Method = "GET"
            .Proxy = Nothing
            .ContentType = "text/json"
            .Headers.Add(
                String.Format(
                    "Authorization:Zoho-oauthtoken {0}",
                    auth.Token.access_token
                )
            )

        End With

        With uploadRequest.GetResponse()
            Dim reader As New StreamReader(.GetResponseStream)
            Return JsonConvert.DeserializeObject(
                reader.ReadToEnd,
                Me.GetType()
            )

        End With

    End Function

End Class
