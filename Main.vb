Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json

Module Main

    Public args As clArg
    Public cn As SqlConnection
    Public auth As oAuth

    Sub Main(arg() As String)

        Try
            args = New clArg(arg)
            auth = New oAuth

            Do
                Using cn As New SqlConnection(My.Settings.ConnStr)
                    cn.Open()

                    Using z As New zoho_envelope(
                        "Select top 2 * from zoho_Accounts",
                        cn
                    )
                        Using r As SqlDataReader = z.cmd.ExecuteReader()
                            If Not r.HasRows Then Exit Do
                            While r.Read
                                z.data.Add(New zoho_Account(r))

                            End While

                        End Using

                        z.Send(cn)

                    End Using

                End Using

            Loop

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            args.Log(ex.Message)

        Finally

            args.wait()

        End Try

    End Sub

End Module
