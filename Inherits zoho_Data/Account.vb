Imports Newtonsoft.Json

Public Class zoho_Account : Inherits zoho_Data

    <JsonProperty("Address_2")>
    Public Property Address2 As String

    <JsonProperty("Address_3")>
    Public Property Address3 As String

    <JsonProperty("AgentCode_Account_Manager")>
    Public Property AgentCodeAccountManager As String

    <JsonProperty("Billing_City")>
    Public Property BillingCity As String

    <JsonProperty("Billing_Code")>
    Public Property BillingCode As String

    <JsonProperty("Billing_Country")>
    Public Property BillingCountry As String

    <JsonProperty("Billing_Customer_Number")>
    Public Property BillingCustomerNumber As String

    <JsonProperty("Billing_Province")>
    Public Property BillingProvince As String

    <JsonProperty("Billing_Street")>
    Public Property BillingStreet As String

    <JsonProperty("Company_Email")>
    Public Property CompanyEmail As String

    <JsonProperty("Company_Number")>
    Public Property CompanyNumber As String

    <JsonProperty("Country_Code")>
    Public Property CountryCode As String

    <JsonProperty("Credit_Balance")>
    Public Property CreditBalance As String

    <JsonProperty("Credit_Currency")>
    Public Property CreditCurrency As String

    <JsonProperty("Credit_Hold_Date_Time")>
    Public Property CreditHoldDateTime As Date?

    <JsonProperty("Credit_Limit")>
    Public Property CreditLimit As String

    <JsonProperty("Customer_Group_Code")>
    Public Property CustomerGroupCode As String

    <JsonProperty("Status")>
    Public Property Status As String

    <JsonProperty("Account_Name")>
    Public Property AccountName As String

    <JsonProperty("Date_Account_Opened")>
    Public Property DateAccountOpened As Date?

    <JsonProperty("Description")>
    Public Property Description As String

    <JsonProperty("Fax")>
    Public Property Fax As String

    <JsonProperty("On_Credit_Hold")>
    Public Property OnCreditHold As Boolean = False

    <JsonProperty("Payment_Terms_Code")>
    Public Property PaymentTermsCode As String

    <JsonProperty("Payment_Terms_Description")>
    Public Property PaymentTermsDescription As String

    <JsonProperty("Phone")>
    Public Property Phone As String

    <JsonProperty("Shipment_Mode_Code")>
    Public Property ShipmentModeCode As String

    <JsonProperty("Shipment_Mode_Name")>
    Public Property ShipmentModeName As String

    <JsonProperty("VAT_Number")>
    Public Property VATNumber As String

    <JsonProperty("Website")>
    Public Property Website As String

    <JsonProperty("Billing_Customer_Name")>
    Public Property BillingCustomerName As zoho_LookUp

    <JsonProperty("Owner")>
    Public Property Owner As zoho_LookUp

    <JsonProperty("Portal_Contact")>
    Public Property PortalContact As zoho_LookUp

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Accounts"
        End Get

    End Property

    Public Sub New()
        BillingCustomerName = New zoho_LookUp
        Owner = New zoho_LookUp
        PortalContact = New zoho_LookUp

    End Sub

End Class
