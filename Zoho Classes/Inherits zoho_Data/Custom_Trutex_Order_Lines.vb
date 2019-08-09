
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Custom_Trutex_Order_Lines : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Custom_Trutex_Order_Lines"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Custom_Trutex_Order_Lines"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New zoho_Account(r)

    End Function

End Class

Public Class Custom_Trutex_Order_Lines : Inherits zoho_Data

    <JsonIgnore>
    Public Property ORDI As Integer

    Public Property id As String
    Public Property Name As String
    Public Property Part_Description As String
    Public Property Part_Status As String
    Public Property Quantity As Integer?
    Public Property Reserved_Quantity As String
    Public Property Price As String
    Public Property Unit_Price_including_VAT As Double?
    Public Property Price_Source As String
    Public Property Customer_Requested_Date As String
    Public Property Ship_Due_Date As String
    Public Property Balance_Quantity_Outstanding As Integer?
    Public Property Closed As Boolean?
    Public Property Extended_Total_Price As Double?
    Public Property Line_Type As String
    Public Property Part_Code As zoho_LookUp
    Public Property Custom_Trutex_Order As zoho_LookUp

    'Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update ORDERITEMS set " &
                            "ZOHO_ID = '{1}', " &
                            "ZOHO_LASTSEND = {2}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where ORDI = {0}",
                            ORDI,
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
                            "update ORDERITEMS set " &
                            "ZOHO_FAILMESS = '{1}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where ORDI = {0}",
                            ORDI,
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
        Custom_Trutex_Order = New zoho_LookUp
        'Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
