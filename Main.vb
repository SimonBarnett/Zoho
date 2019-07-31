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

            'Dim c As New zoho_Users()
            'c.Send()

            Using acc As New zoho_Module_Account
                With acc
                    '.Columns("CUST", "id", "AgentCode_Account_Manager", "AgentName_Account_Manager")
                    '.Process(zoho_Module.eMethod.CUSTOM, "workflow")

                    .Process(zoho_Module.eMethod.UPDATE, "workflow")
                    .Process(zoho_Module.eMethod.INSERT, "workflow")

                End With

            End Using

            Using contact As New zoho_Module_Contacts
                With contact
                    .Process(zoho_Module.eMethod.UPDATE, "workflow")
                    .Process(zoho_Module.eMethod.INSERT, "workflow")

                End With

            End Using

            Using site As New zoho_Module_Sites
                With site
                    .Process(zoho_Module.eMethod.UPDATE, "workflow")
                    .Process(zoho_Module.eMethod.INSERT, "workflow")

                End With

            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            args.Log(ex.Message)

        Finally
            args.wait()

        End Try

    End Sub

End Module
