Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Account : Inherits zoho_Data

    <JsonIgnore>
    Public Property CUST As Integer
    Public Property Address_2 As String
    Public Property Address_3 As String
    Public Property AgentCode_Account_Manager As String
    Public Property Billing_City As String
    Public Property Billing_Code As String
    Public Property Billing_Country As String
    Public Property Billing_Customer_Number As String
    Public Property Billing_State As String
    Public Property Billing_Street As String
    Public Property Company_Email As String
    Public Property Company_Number As String
    Public Property Country_Code1 As String
    Public Property Credit_Balance As Double?
    Public Property Credit_Currency_1 As String
    Public Property Credit_Hold_Date As Date?
    Public Property Credit_Limit As Double?
    Public Property Customer_Group_Code_1 As String
    Public Property Customer_Number As String
    Public Property Customer_Group_Name1 As String
    Public Property Customer_Status_1 As String
    Public Property Account_Name As String
    Public Property Date_Account_Opened As Date?
    Public Property Description As String
    Public Property Fax As String
    Public Property On_Credit_Hold As Boolean
    Public Property Payment_Terms_Code_1 As String
    Public Property Payment_Terms_Description_1 As String
    Public Property Phone As String
    Public Property Shipment_Mode_Code_1 As String
    Public Property Shipment_Mode_Name_1 As String
    Public Property VAT_Number As String
    Public Property Website As String

    ' Lookup properties
    Public Property Billing_Customer_Name As zoho_LookUp
    Public Property Owner As zoho_LookUp

    'Public Property Portal_Contact As zoho_LookUp

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Accounts"
        End Get

    End Property

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        Select Case resp.code.ToUpper
            Case "SUCCESS"
                Dim cmd As New SqlCommand(
                    String.Format(
                        "update CUSTOMERS set " &
                        "ZOHO_ID = '{1}', " &
                        "ZOHO_LASTSEND = {2}, " &
                        "ZOHO_SENT = 'Y' " &
                        "where CUST = {0}",
                        CUST,
                        resp.details.id,
                        DateDiff(DateInterval.Minute, #01/01/1988#, Now).ToString
                    ),
                    cn
                )
                cmd.ExecuteNonQuery()

        End Select

    End Sub

    Public Sub New(r As SqlDataReader)

        Billing_Customer_Name = New zoho_LookUp
        Owner = New zoho_LookUp
        'Portal_Contact = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
