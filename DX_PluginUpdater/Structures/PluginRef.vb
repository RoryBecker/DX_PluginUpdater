
Public Class PluginRef
#Region "Fields"
    Protected mBaseName As String
    Protected mVersion As Integer
#End Region
#Region "Construction"
    Public Sub New(ByVal BaseName As String, ByVal Version As Integer)
        mBaseName = BaseName
        mVersion = Version
    End Sub
#End Region
#Region "Properties"
    Public ReadOnly Property BaseName() As String
        Get
            Return mBaseName
        End Get
    End Property
    Public ReadOnly Property Version() As Integer
        Get
            Return mVersion
        End Get
    End Property
    Public ReadOnly Property DllFilename() As String
        Get
            Return String.Format("{0}.dll", BaseName)
        End Get
    End Property
#End Region
End Class