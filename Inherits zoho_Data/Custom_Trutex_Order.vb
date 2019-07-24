Imports Newtonsoft.Json

Public Class zoho_Order : Inherits zoho_Data

    Sub New()
        PriceListLookup = New zoho_LookUp
        SiteCode = New zoho_LookUp
        Owner = New zoho_LookUp
        Customer = New zoho_LookUp

    End Sub

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Custom_Trutex_Orders"
        End Get
    End Property

    <JsonProperty("Price_List_Looked_Up")>
    Public Property PriceListLookup As zoho_LookUp

    <JsonProperty("Site_Code")>
    Public Property SiteCode As zoho_LookUp

    <JsonProperty("Owner")>
    Public Property Owner As zoho_LookUp

    <JsonProperty("Customer")>
    Public Property Customer As zoho_LookUp

    <JsonProperty("Customer_Number")>
    Public Property CustomerNumber As String

    <JsonProperty("Priority_Date_of_Sales_Order")>
    Public Property PriorityDateOfSalesOrder As String

    <JsonProperty("Name")>
    Public Property Name As String

    <JsonProperty("Status")>
    Public Property Status As String

    <JsonProperty("Type_of_Sale_Description")>
    Public Property TypeOfSaleDescription As String

    <JsonProperty("Type_of_Sale_Code")>
    Public Property TypeOfSaleCode As String

    <JsonProperty("To_Consignment_Warehouse_Name")>
    Public Property ToConsignmentWarehouseName As String

    <JsonProperty("To_Consignment_Warehouse_Code")>
    Public Property ToConsignmentWarehouseCode As String

    <JsonProperty("Price_Quote_Number")>
    Public Property PriceQuoteNumber As String

    <JsonProperty("Customer_PO")>
    Public Property CustomerPO As String

    <JsonProperty("Customer_PO_Details")>
    Public Property CustomerPODetails As String

    <JsonProperty("Price_List")>
    Public Property PriceList As String

    <JsonProperty("Price_after_Discount1")>
    Public Property PriceAfterDiscount As Double?

    <JsonProperty("VAT1")>
    Public Property VAT As Double?

    <JsonProperty("Final_Price1")>
    Public Property FinalPrice As Double?

    <JsonProperty("Currency_Code")>
    Public Property CurrencyCode As String

    <JsonProperty("Payment_Terms_Description")>
    Public Property PaymentTermsDescription As String

    <JsonProperty("Payment_Terms_Code")>
    Public Property PaymentTermsCode As String

    <JsonProperty("Order_Received_Date")>
    Public Property OrderReceivedDate As Date?

    <JsonProperty("Site_Contact")>
    Public Property SiteContact As String

    <JsonProperty("Site_Phone_Number")>
    Public Property SitePhoneNumber As String

    <JsonProperty("Street_Address")>
    Public Property StreetAddress As String

    <JsonProperty("Address_2")>
    Public Property Address2 As String

    <JsonProperty("Address_3")>
    Public Property Address3 As String

    <JsonProperty("City")>
    Public Property City As String

    <JsonProperty("County")>
    Public Property County As String

    <JsonProperty("Post_Code")>
    Public Property PostCode As String

    <JsonProperty("Country")>
    Public Property Country As String

    <JsonProperty("Details")>
    Public Property Details As String

End Class
