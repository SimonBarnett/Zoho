Imports Newtonsoft.Json

Public MustInherit Class zoho_Data

    <JsonIgnore>
    MustOverride ReadOnly Property EndPoint As String

End Class

Public Class zoho_envelope : Implements IDisposable

    Public data As New List(Of zoho_Data)

    Private _trigger As String
    Public Property trigger As String
        Get
            Return _trigger
        End Get
        Set(value As String)
            _trigger = value
        End Set
    End Property

    Public Sub New(Optional trigger As String = "workflow")
        _trigger = trigger

    End Sub

    Public Function toSerial() As String

        Dim s As New JsonSerializerSettings
        s.NullValueHandling = NullValueHandling.Ignore

        Return JsonConvert.SerializeObject(
            Me,
            Newtonsoft.Json.Formatting.Indented,
            s
        )

    End Function

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
