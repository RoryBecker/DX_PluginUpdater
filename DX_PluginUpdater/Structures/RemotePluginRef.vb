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