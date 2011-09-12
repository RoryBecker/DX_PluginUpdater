
Public Class RemotePluginRef
#Region "Fields"
    Protected mPluginName As String
    Protected mVersion As Integer
    ReadOnly mRemoteFolderUrl As String
#End Region
#Region "Construction"
    Public Sub New(ByVal PluginName As String, Optional ByVal Version As Integer = 0, Optional ByVal RemoteFolderUrl As String = "")
        mPluginName = PluginName
        mVersion = Version
        mRemoteFolderUrl = RemoteFolderUrl
    End Sub
#End Region
#Region "Properties"
    Public ReadOnly Property PluginName() As String
        Get
            Return mPluginName
        End Get
    End Property
    Public ReadOnly Property Version() As Integer
        Get
            Return mVersion
        End Get
    End Property
    Public ReadOnly Property DllFilename() As String
        Get
            Return String.Format("{0}.dll", PluginName)
        End Get
    End Property
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
            Return String.Format("{0}_{1}.zip", PluginName, Version)
        End Get
    End Property
#End Region
End Class