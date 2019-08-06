
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Customer_Price_Lists : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Customer_Price_Lists"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Customer_Price_Lists"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Customer_Price_Lists(r)

    End Function

End Class

Public Class Customer_Price_Lists : Inherits zoho_Data

    <JsonIgnore>
    Public Property PLIST As Integer

    Public Property id As String
    Public Property Name As String
    Public Property List_Description As String
    Public Property Currency_Code As String
    Public Property Valid_List_Date As String
    Public Property In_Use As Boolean?

    Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update PRICELIST set " &
                            "ZOHO_ID = '{1}', " &
                            "ZOHO_LASTSEND = {2}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where PLIST = {0}",
                            PLIST,
                            .details.id,
                            DateDiff(
                                DateInterval.Minute,
                                #01/01/1988#,
                                .details.Modified_Time
                            ).ToString
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

                Case Else
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update PRICELIST set " &
                            "ZOHO_FAILMESS = '{1}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where PLIST = {0}",
                            PLIST,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub


    Public Sub New(r As SqlDataReader)

        Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
