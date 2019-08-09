
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Customers_X_Price_Lists : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Customers_X_Price_Lists"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Customers_X_Price_Lists"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Customers_X_Price_Lists(r)

    End Function

End Class

Public Class Customers_X_Price_Lists : Inherits zoho_Data

    <JsonIgnore>
    Public CUST As Integer

    <JsonIgnore>
    Public PLIST As Integer

    Public Property id As String
    Public Property Price_List_Priority As String
    Public Property Customer_Price_Lists As zoho_LookUp
    Public Property Customers As zoho_LookUp
    Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update CUSTPLIST set " &
                            "ZOHO_ID = '{2}', " &
                            "ZOHO_LASTSEND = {3}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where CUST = {0} AND PLIST = {1}",
                            CUST,
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
                            "update CUSTPLIST set " &
                            "ZOHO_FAILMESS = '{2}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where CUST = {0} AND PLIST = {1}",
                            CUST,
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

        Customer_Price_Lists = New zoho_LookUp
        Customers = New zoho_LookUp
        Owner = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
