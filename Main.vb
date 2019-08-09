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

            Do
                Try
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

                    Using links As New zoho_Module_CustomerLinks
                        With links
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With

                    End Using

                    Using parts As New zoho_Module_Part_Catalogue
                        With parts
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With

                    End Using

                    Using pl As New zoho_Module_Customer_Price_Lists
                        With pl
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With
                    End Using

                    Using custpl As New zoho_Module_Customers_X_Price_Lists
                        With custpl
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With
                    End Using

                    Using pprice As New zoho_Module_Part_Prices
                        With pprice
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With
                    End Using

                    Using ord As New zoho_Module_Custom_Trutex_Orders
                        With ord
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With
                    End Using

                    Using ordi As New zoho_Module_Custom_Trutex_Order_Lines
                        With ordi
                            .Process(zoho_Module.eMethod.UPDATE, "workflow")
                            .Process(zoho_Module.eMethod.INSERT, "workflow")

                        End With
                    End Using

                Catch ex As Exception
                    Threading.Thread.Sleep(5000)

                Finally
                    Threading.Thread.Sleep(2000)

                End Try

            Loop

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            args.Log(ex.Message)

        Finally
            args.wait()

        End Try

    End Sub

End Module
