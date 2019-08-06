
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Part_Catalogue : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Part_Catalogue"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Part_Catalogue"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Part_Catalogue(r)

    End Function

End Class

Public Class Part_Catalogue : Inherits zoho_Data

    <JsonIgnore>
    Public Property PART As Integer

    Public Property id As String
    Public Property Name As String
    Public Property Part_Description As String
    Public Property Bar_Code_Number As String
    Public Property Base_Product_Description As String
    Public Property Status_of_Part As String
    Public Property Range As String
    Public Property VAT_Group_Code As String
    Public Property Base_Product As Boolean?
    Public Property Is_this_Separate As Boolean?
    Public Property Available_for_Sale As String
    Public Property Valid_To As String
    Public Property Valid_From As String
    Public Property Standard_Cost As String
    Public Property Cost As String
    Public Property Currency_Code As String
    Public Property Base_Product_Code As zoho_LookUp
    Public Property School_Number As zoho_LookUp
    Public Property Owner As zoho_LookUp

    Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)


        With resp
            Select Case .code.ToUpper
                Case "SUCCESS"
                    Dim cmd As New SqlCommand(
                        String.Format(
                            "update PART set " &
                            "ZOHO_ID = '{1}', " &
                            "ZOHO_LASTSEND = {2}, " &
                            "ZOHO_SENT = 'Y' " &
                            "where PART = {0}",
                            PART,
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
                            "update PART set " &
                            "ZOHO_FAILMESS = '{1}', " &
                            "ZOHO_FAIL = 'Y' " &
                            "where PART = {0}",
                            PART,
                            .message
                        ),
                        cn
                    )
                    cmd.ExecuteNonQuery()

            End Select

        End With

    End Sub

    Public Sub New(r As SqlDataReader)

        Base_Product_Code = New zoho_LookUp
        School_Number = New zoho_LookUp
        Owner = New zoho_LookUp

        PopulateData(r)

    End Sub

End Class
