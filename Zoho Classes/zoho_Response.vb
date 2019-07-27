Public Class zoho_Responses

    Public data As New List(Of zoho_Response)

End Class

Public Class zoho_Response
    Public Property code As String
    Public Property message As String
    Public Property status As String
    Public Property details As zoho_Response_Detail

End Class

Public Class zoho_Response_Detail
    Public Property id As String
    Public Property Created_Time As Date
    Public Property Created_By As zoho_LookUp
    Public Property Modified_Time As Date
    Public Property Modified_By As zoho_LookUp

End Class