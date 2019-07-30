Public Class zoho_Roles : Inherits zoho_Request

    Public profiles As New List(Of zoho_Role)

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.com/crm/v2/settings/roles"
        End Get
    End Property

End Class

Public Class zoho_Role : Inherits base_schema

    Public Property display_label As String
    Public Property name As String
    Public Property id As String
    Public Property reporting_to As zoho_LookUp
    Public Property admin_user As Boolean

End Class