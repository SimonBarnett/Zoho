
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Custom_Trutex_Orders : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Custom_Trutex_Orders"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Custom_Trutex_Orders"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Custom_Trutex_Orders(r)

    End Function

End Class

Public Class Custom_Trutex_Orders : Inherits zoho_Data

    <JsonIgnore>
    Public Property ORD As Integer

    Public Property id As String
    Public Property Customer_Number As String
    Public Property Priority_Date_of_Sales_Order As String
    Public Property Name As String
    Public Property Status As String
    Public Property Type_of_Sale_Description As String
    Public Property Type_of_Sale_Code As String
    Public Property To_Consignment_Warehouse_Name As String
    Public Property To_Consignment_Warehouse_Code As String
    Public Property Price_Quote_Number As String
    Public Property Customer_PO As String
    Public Property Customer_PO_Details As String
    Public Property Price_List As String
    Public Property Price_after_Discount1 As Double?
    Public Property VAT1 As Double?
    Public Property Final_Price1 As Double?
    Public Property Currency_Code As String
    Public Property Payment_Terms_Description As String
    Public Property Payment_Terms_Code As String
    Public Property Order_Received_Date As String
    Public Property Site_Contact As String
    Public Property Site_Phone_Number As String
    Public Property Street_Address As String
    Public Property Address_2 As String
    Public Property Address_3 As String
    Public Property City As String
    Public Property County As String
    Public Property Post_Code As String
    Public Property Country As String
    Public Property Details As String
    Public Property Customer As zoho_LookUp
    Public Property Price_List_Looked_Up As zoho_LookUp
    Public Property Site_Code As zoho_LookUp
    'Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update ORDERS set " &
                            "ZOHO_ID = '{1}', " &
                            "ZOHO_LASTSEND = {2}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where ORD = {0}",
                            ORD,
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
                            "update ORDERS set " &
                            "ZOHO_FAILMESS = '{1}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where ORD = {0}",
                            ORD,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub

    Public Sub New(r As SqlDataReader)

        Customer = New zoho_LookUp
        Price_List_Looked_Up = New zoho_LookUp
        Site_Code = New zoho_LookUp
        'Owner = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
