
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
Public Class RemotePluginRef
    Inherits PluginRef

#Region "Fields"
    ReadOnly mRemoteFolderUrl As String
#End Region
#Region "SimpleProperties"
    Public ReadOnly Property RemoteFolderUrl() As String
        Get
            Return mRemoteFolderUrl
        End Get
    End Property
    Public ReadOnly Property RemoteZipFileUrl() As String
        Get
            Return String.Format("{0}/{1}", mRemoteFolderUrl, ZipFilename)
        End Get
    End Property
    Public ReadOnly Property ZipFilename() As String
        Get
            Return String.Format("{0}_{1}.zip", BaseName, Version)
        End Get
    End Property
#End Region
#Region "Construction"
    Public Sub New(ByVal BaseName As String, ByVal Version As Integer, ByVal RemoteFolderUrl As String)
        MyBase.New(BaseName, Version)
        mRemoteFolderUrl = RemoteFolderUrl
    End Sub

#End Region


End Class