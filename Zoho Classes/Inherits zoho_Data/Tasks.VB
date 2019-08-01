

Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Tasks : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Tasks"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Tasks"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New zoho_Tasks(r)

    End Function

End Class

Public Class zoho_Tasks : Inherits zoho_Data
    Public Property Subject As String
    <JsonProperty("$se_module")>
    Public Property se_module As String
    Public Property Generated_by As String
    Public Property Status As String
    Public Property Due_Date As String
    Public Property Task_Code As String
    Public Property Description As String
    Public Property Explanation_of_Task As String
    Public Property Date_Recorded_with_Timestamp As DateTime?
    Public Property Associated_Document_Number As String
    Public Property Associated_Document_Description As String
    Public Property Order_Received_Date As String
    Public Property Closed_Time As DateTime?
    Public Property Priority As String
    Public Property Owner As zoho_LookUp
    Public Property Who_Id As zoho_LookUp
    Public Property What_Id As zoho_LookUp
    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Who_Id = New zoho_LookUp
        What_Id = New zoho_LookUp
        Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
