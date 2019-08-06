
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
    Public Property id As String
    Public Property Name As String
Public Property Quantity As String
Public Property Price As String
Public Property Price_including_VAT As String
Public Property Currency_Code1 As String
Public Property VAT_Group_Code1 As String
Public Property Part_Code As zoho_lookup
Public Property Customer_Price_List As zoho_lookup
Public Property Owner As zoho_lookup
	Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Part_Code = New zoho_LookUp
        Customer_Price_List = New zoho_LookUp
	Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
