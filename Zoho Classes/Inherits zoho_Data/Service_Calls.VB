
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Service_Calls : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Service_Calls"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Service_Calls"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Service_Calls(r)

    End Function

End Class

Public Class Service_Calls : Inherits zoho_Data
Public Property Name As String
Public Property Customer_Number As String
Public Property Date_Service_Call_Opened As String
Public Property RMA_Number As String
Public Property Status_of_Call As String
Public Property Price_After_Discount As double?
Public Property VAT As double?
Public Property Total_Price As double?
Public Property Currency_Code As String
Public Property Customer_Site As zoho_lookup
Public Property Owner As zoho_lookup
Public Property Customer_Name As zoho_lookup
	Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Customer_Site = New zoho_LookUp
        Customer_Name = New zoho_LookUp
	Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
