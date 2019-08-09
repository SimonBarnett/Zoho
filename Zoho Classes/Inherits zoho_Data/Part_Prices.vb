
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Part_Prices : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Part_Prices"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Part_Prices"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Part_Prices(r)

    End Function

End Class

Public Class Part_Prices : Inherits zoho_Data

    <JsonIgnore>
    Public Property PLIST As Integer
    <JsonIgnore>
    Public Property PLDATE As Integer
    <JsonIgnore>
    Public Property PART As Integer
    <JsonIgnore>
    Public Property QUANT As Integer

    Public Property id As String
    Public Property Name As String
    Public Property Quantity As String
    Public Property Price As String
    Public Property Price_including_VAT As String
    Public Property Currency_Code1 As String
    Public Property VAT_Group_Code1 As String

    Public Property Part_Code As zoho_LookUp
    Public Property Customer_Price_List As zoho_LookUp
    'Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update PARTPRICE set " &
                            "ZOHO_ID = '{4}', " &
                            "ZOHO_LASTSEND = {5}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where PLIST={0} AND PLDATE= {1} AND PART = {2} AND QUANT = {3}",
                            PLIST, PLDATE, PART, QUANT,
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
                            "update PARTPRICE set " &
                            "ZOHO_FAILMESS = '{4}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where PLIST={0} AND PLDATE= {1} AND PART = {2} AND QUANT = {3}",
                            PLIST, PLDATE, PART, QUANT,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub


    Public Sub New(r As SqlDataReader)

        Part_Code = New zoho_LookUp
        Customer_Price_List = New zoho_LookUp
        'Owner = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
