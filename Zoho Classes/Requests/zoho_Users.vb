Public Class zoho_Users : Inherits zoho_Request

    Public profiles As New List(Of zoho_User)

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.com/crm/v2/users?type=AllUsers"
        End Get
    End Property


End Class

Public Class zoho_User : Inherits base_schema

End Class