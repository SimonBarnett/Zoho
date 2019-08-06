Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_CustomerLinks : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/CustomerLinks"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_CustomerLinks"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New CustomerLink(r)

    End Function

End Class

Public Class CustomerLink : Inherits zoho_Data

    <JsonIgnore>
    Public Property SCHOOL As Integer

    <JsonIgnore>
    Public Property SHOP As Integer

    Public Property id As String
    Public Property Default_School As Boolean?
	Public Property Generated_by_Priority As Boolean?
	Public Property School_Number As String
	Public Property School_Customer As String
    'Public Property Owner As zoho_lookup
    Public Property LinkingFrom As zoho_LookUp
    Public Property LinkingTo As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update ZTRX_SCHOOLS set " &
                            "ZOHO_ID = '{2}', " &
                            "ZOHO_LASTSEND = {3}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where SCHOOL = {0} AND SHOP = {1}",
                            SCHOOL,
                            SHOP,
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
                            "update ZTRX_SCHOOLS set " &
                            "ZOHO_FAILMESS = '{2}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where SCHOOL = {0} AND SHOP = {1}",
                            SCHOOL,
                            SHOP,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub

    Public Sub New(r As SqlDataReader)

        'Owner = New zoho_LookUp
        LinkingFrom = New zoho_LookUp
        LinkingTo = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
