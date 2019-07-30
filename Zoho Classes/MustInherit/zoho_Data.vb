Imports System.Data.SqlClient

Public MustInherit Class zoho_Data : Inherits base_schema

    MustOverride Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    Sub PopulateData(r As SqlDataReader)
        For i As Integer = 0 To r.FieldCount - 1
            If Len(r(i)) > 0 Then
                Try
                    Dim ob As Object = Me
                    Dim name As String = r.GetName(i)

                    While InStr(name, ".") > 0
                        ob = CallByName(ob, Split(name, ".")(0), CallType.Get)
                        name = name.Substring(InStr(name, "."))
                    End While

                    CallByName(ob, name, CallType.Set, r(i))


                Catch ex As Exception
                    Console.WriteLine("Missing property: {0}", r.GetName(i))

                End Try

            End If

        Next

    End Sub

End Class