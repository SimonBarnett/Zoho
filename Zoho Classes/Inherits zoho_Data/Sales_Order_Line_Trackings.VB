
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Sales_Order_Line_Trackings : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Sales_Order_Line_Trackings"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Sales_Order_Line_Trackings"
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

Public Class Sales_Order_Line_Trackings : Inherits zoho_Data
Public Property Name As String
    Public Property [Date] As String
    Public Property Quantity As integer?
Public Property Inventory_Transaction_Type As String
Public Property Document_Number As String
Public Property Sales_Order_Line As zoho_lookup
Public Property Trutex_Sales_Order As zoho_lookup
Public Property Owner As zoho_lookup
	Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Sales_Order_Line = New zoho_LookUp
        Trutex_Sales_Order = New zoho_LookUp
	Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
