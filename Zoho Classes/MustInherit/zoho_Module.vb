Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public MustInherit Class zoho_Module : Implements IDisposable

    Public Enum eMethod
        INSERT
        UPDATE

    End Enum

#Region "Properties"

    <JsonIgnore>
    MustOverride ReadOnly Property EndPoint As String

    <JsonIgnore>
    MustOverride ReadOnly Property sqlView As String

    <JsonIgnore>
    MustOverride ReadOnly Property rowCount As Integer

    Private _Method As String
    Public ReadOnly Property Method As eMethod
        Get
            Return _Method
        End Get
    End Property

#End Region

#Region "Methods"

    MustOverride Function zoho_item(ByRef r As SqlDataReader) As zoho_Data

    Sub Process(Method As eMethod, ParamArray triggers() As String)

        _Method = Method
        Do

            Using cn As New SqlConnection(My.Settings.ConnStr)
                cn.Open()

                Using z As New zoho_envelope(Me, triggers)
                    z.cmd.Connection = cn

                    Using r As SqlDataReader = z.cmd.ExecuteReader()
                        If Not r.HasRows Then Exit Do

                        While r.Read
                            z.data.Add(zoho_item(r))

                        End While

                    End Using

                    'Console.WriteLine(z.toSerial)
                    z.Send(cn)

                End Using

            End Using

        Loop

    End Sub

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
