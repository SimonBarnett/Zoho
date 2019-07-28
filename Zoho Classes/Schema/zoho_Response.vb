Imports Newtonsoft.Json

Public Class zoho_Responses

    Public data As New List(Of zoho_Response)

End Class

Public Class zoho_Response
    Public Property code As String
    Public Property message As String
    Public Property status As String
    Public Property details As zoho_Response_Detail

    Public Function toSerial() As String

        Dim s As New JsonSerializerSettings
        s.NullValueHandling = NullValueHandling.Ignore

        Return JsonConvert.SerializeObject(
            Me,
            Newtonsoft.Json.Formatting.Indented,
            s
        )

    End Function

End Class

Public Class zoho_Response_Detail
    Public Property id As String
    Public Property Created_Time As Date
    Public Property Created_By As zoho_LookUp
    Public Property Modified_Time As Date
    Public Property Modified_By As zoho_LookUp

End Class