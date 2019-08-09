Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class zoho_envelope : Inherits base_schema

    Public data As New List(Of zoho_Data)
    Public trigger As New List(Of String)

    Private _zModule As zoho_Module

#Region "Constructor"

    Public Sub New(ByRef zModule As zoho_Module, ParamArray triggers() As String)

        _zModule = zModule
        For Each str As String In triggers
            trigger.Add(str)

        Next

        Dim cmdstr As New StringBuilder
        With _zModule
            cmdstr.AppendFormat(
                "Select top {0} ",
                .rowCount.ToString
            )
            Select Case .Method
                Case zoho_Module.eMethod.CUSTOM
                    For Each str As String In .Custom_Columns
                        cmdstr.Append(str)
                        If Not str = .Custom_Columns.Last Then
                            cmdstr.Append(", ")

                        Else
                            cmdstr.Append(" ")

                        End If
                    Next

                Case Else
                    cmdstr.Append("* ")

            End Select

            cmdstr.AppendFormat(
                "from {0} ",
                .sqlView
            )

            Select Case .Method
                Case zoho_Module.eMethod.INSERT
                    cmdstr.Append("where id = ''")

                Case zoho_Module.eMethod.UPDATE, zoho_Module.eMethod.CUSTOM
                    cmdstr.Append("where id <> ''")

            End Select

        End With

        _cmd = New SqlCommand(cmdstr.ToString)

    End Sub

#End Region

#Region "Properties"

    Dim _cmd As SqlCommand
    <JsonIgnore>
    Public Property cmd As SqlCommand
        Get
            Return _cmd
        End Get
        Set(value As SqlCommand)
            _cmd = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub Send(cn As SqlConnection)

        Dim resp As zoho_Responses
        Dim requestStream As Stream = Nothing
        Dim uploadResponse As Net.HttpWebResponse = Nothing
        Dim uploadRequest As Net.HttpWebRequest =
            CType(Net.HttpWebRequest.Create(_zModule.EndPoint), Net.HttpWebRequest)

        With uploadRequest
            Select Case _zModule.Method
                Case zoho_Module.eMethod.INSERT
                    .Method = "POST"

                Case zoho_Module.eMethod.UPDATE, zoho_Module.eMethod.CUSTOM
                    .Method = "PUT"

            End Select

            .Proxy = Nothing
            .ContentType = "text/json"
            .Headers.Add(
                String.Format(
                    "Authorization:Zoho-oauthtoken {0}",
                    auth.Token.access_token
                )
            )

        End With

        Dim myEncoder As New System.Text.ASCIIEncoding
        Dim ms As MemoryStream = New MemoryStream(myEncoder.GetBytes(toSerial))

        requestStream = uploadRequest.GetRequestStream()

        ' Upload the JSON
        Dim buffer(1024) As Byte
        Dim bytesRead As Integer

        While True
            bytesRead = ms.Read(buffer, 0, buffer.Length)

            If bytesRead = 0 Then
                Exit While
            End If

            requestStream.Write(buffer, 0, bytesRead)

        End While

        requestStream.Close()

        With uploadRequest.GetResponse()
            Dim reader As New StreamReader(.GetResponseStream)
            resp = JsonConvert.DeserializeObject(
                reader.ReadToEnd,
                GetType(zoho_Responses)
            )

        End With

        For i As Integer = 0 To data.Count - 1
            'If args.Keys.Contains("v") Then
            Console.WriteLine(data(i).toSerial)
            Console.WriteLine(resp.data(i).toSerial)

            'End If

            data(i).HandleResponse(cn, resp.data(i))

        Next

    End Sub

#End Region

End Class
