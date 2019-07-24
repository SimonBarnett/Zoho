Imports System.IO
Imports System.Net

Module oAuth

    Sub main()

        Dim z As New zoho_envelope()
        Dim acc As New zoho_Account
        Dim ord As New zoho_Order

        z.data.Add(acc)
        z.data.Add(ord)

        Console.Write(z.toSerial)

        Try
            'https://accounts.zoho.eu/oauth/v2/token?grant_type=authorization_code&client_id=1000.M31IZQXEBYRM38870QRPIKWTJT4A6R&client_secret=9bab95f464faf563041172fadd019610e4dc8ef452&code=1000.dc0ed7e65c3ba0b46e485fc121eee7a5.6dfd607e87c9e8410acb365ff67cd8ad&redirect_uri=http://priority.trutex.com/api/oauth2.callback


            Dim Accounts_URL As String = "accounts.zoho.eu"
            Dim refresh_token As String = "1000.2f4ee9ada222b1e5dfc752e6a1ffefe4.e238194f5f8d641d5aa038ee3f0e4599"
            Dim client_id As String = "1000.M31IZQXEBYRM38870QRPIKWTJT4A6R"
            Dim client_secret As String = "9bab95f464faf563041172fadd019610e4dc8ef452"

            Dim url As String = String.Format(
                "https://{0}/oauth/v2/token?grant_type=refresh_token&client_id={1}&client_secret={2}&refresh_token={3}",
                Accounts_URL,
                client_id,
                client_secret,
                refresh_token
            )

            Dim requestStream As Stream = Nothing
            Dim uploadResponse As Net.HttpWebResponse = Nothing
            Dim uploadRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(url), Net.HttpWebRequest)

            With uploadRequest
                .Method = "POST"
                .Proxy = Nothing

            End With

            Dim reader As New StreamReader(uploadRequest.GetResponse().GetResponseStream)
            Console.Write(reader.ReadToEnd)
            Console.ReadKey()

            Beep()

        Catch ex As Exception
            Beep()

        End Try

    End Sub

End Module
