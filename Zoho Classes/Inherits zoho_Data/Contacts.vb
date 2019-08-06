Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Contacts : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Contacts"
        End Get
    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Contacts"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New zoho_Contact(r)

    End Function

End Class

Public Class zoho_Contact : Inherits zoho_Data

    <JsonIgnore>
    Public Property PHONEid As Integer

    Public Property id As String
    Public Property Contact_Status1 As String
    Public Property Description As String
    Public Property Title As String
    Public Property Salutation As String
    Public Property First_Name As String
    Public Property Last_Name As String
    Public Property Mobile As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Main_Contact As Boolean?
    Public Property Invoice_Contact As Boolean?
    Public Property Customer_Statement_Contact As Boolean?
    Public Property Sales_Order_Contact As Boolean?
    Public Property Shipment_Contact As Boolean?

    ' Lookups
    Public Property Account_Name As zoho_LookUp
    Public Property Site As zoho_LookUp
    Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update PHONEBOOK set " &
                            "ZOHO_ID = '{1}', " &
                            "ZOHO_LASTSEND = {2}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where PHONE = {0}",
                            PHONEid,
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
                            "update PHONEBOOK set " &
                            "ZOHO_FAILMESS = '{1}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where PHONE = {0}",
                            PHONEid,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub

    Public Sub New(r As SqlDataReader)

        Account_Name = New zoho_LookUp
        Site = New zoho_LookUp
        Owner = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
