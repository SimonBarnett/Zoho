Public Class zoho_Profiles : Inherits zoho_Request

    Public profiles As New List(Of zoho_profile)

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.com/crm/v2/settings/profiles"
        End Get
    End Property

End Class

Public Class zoho_profile : Inherits base_schema

    Public Property name As String
    Public Property modified_by As String
    Public Property description As String
    Public Property id As String
    Public Property category As Boolean

End Class