Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_CustomerLinks : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/CustomerLinks"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_CustomerLinks"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New CustomerLink(r)

    End Function

End Class

Public Class CustomerLink  : Inherits zoho_Data
	Public Property Default_School As Boolean?
	Public Property Generated_by_Priority As Boolean?
	Public Property School_Number As String
	Public Property School_Customer As String
	Public Property Owner As zoho_lookup
	Public Property LinkingFrom As zoho_lookup
	Public Property LinkingTo As zoho_lookup
	Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Owner = New zoho_LookUp
        LinkingFrom = New zoho_LookUp
        LinkingTo = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class
