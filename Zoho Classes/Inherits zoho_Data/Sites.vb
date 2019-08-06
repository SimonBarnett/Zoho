Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Sites : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Sites"
        End Get
    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Sites"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 2
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New zoho_Site(r)

    End Function

End Class

Public Class zoho_Site : Inherits zoho_Data

    <JsonIgnore>
    Public Property DESTCODE As Integer

    Public Property id As String
    Public Property Name As String
    Public Property Site_Description As String
    Public Property Site_Email As String
    Public Property Phone As String
    Public Property Address_1 As String
    Public Property Address_2 As String
    Public Property Address_3 As String
    Public Property Address_4 As String
    Public Property Address_5 As String
    Public Property Post_Code As String
    Public Property Country As String
    Public Property In_Use As Boolean?

    ' Lookups
    Public Property Contact As zoho_LookUp
    Public Property Company As zoho_LookUp
    Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update DESTCODES set " &
                            "ZOHO_ID = '{1}', " &
                            "ZOHO_LASTSEND = {2}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where DESTCODE = {0}",
                            DESTCODE,
                            .details.id,
                            DateDiff(
                                DateInterval.Minute,
                                #01/01/1988#,
                                .details.Modified_Time
                            ).ToString
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

                Case Else
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update DESTCODES set " &
                            "ZOHO_FAILMESS = '{1}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where DESTCODE = {0}",
                            DESTCODE,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub

    Public Sub New(r As SqlDataReader)

        Contact = New zoho_LookUp
        Company = New zoho_LookUp
        Owner = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
