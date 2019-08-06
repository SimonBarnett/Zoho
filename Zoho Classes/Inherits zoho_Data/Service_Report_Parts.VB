
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Service_Report_Parts : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Service_Report_Parts"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Service_Report_Parts"
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

Public Class Service_Report_Parts : Inherits zoho_Data
    Public Property id As String
    Public Property Name As String
    Public Property Part_Description As String
Public Property Planned_returned_Quantity As integer?
Public Property Actual_returned_Quantity As integer?
Public Property Planned_Quantity As integer?
Public Property Actual_Quantity As integer?
Public Property Planned_Defect_Description As String
Public Property Planned_Defect_Code As String
Public Property Defect_Code As String
Public Property Description_of_Defect As String
Public Property Call_Type As String
Public Property Part_Number As zoho_lookup
Public Property Owner As zoho_lookup
Public Property Service_Call As zoho_lookup
	Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Part_Number = New zoho_LookUp
        Service_Call = New zoho_LookUp
	Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class

