
Public Class RemotePluginRef
    Inherits PluginRef
#Region "Fields"
    ReadOnly mRemoteFolderUrl As String
#End Region
#Region "Construction"
    Public Sub New(ByVal PluginName As String,
                   Optional ByVal RemoteFolderUrl As String = "", _
                   Optional ByVal Version As Integer = 0)
        MyBase.new(PluginName, Version)
        mRemoteFolderUrl = RemoteFolderUrl
    End Sub
#End Region
#Region "Properties"
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

    Private Function Serialize() As String
        Return <Reference>
                   <Name>PluginName</Name>
                   <Version></Version>
               </Reference>.ToString
    End Function
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim OtherPlugin = TryCast(obj, RemotePluginRef)
        If OtherPlugin Is Nothing Then
            Return False
        End If
        If OtherPlugin.PluginName <> Me.PluginName Then
            Return False
        End If
        If OtherPlugin.RemoteFolderUrl <> RemoteFolderUrl Then
            Return False
        End If
        Return True
    End Function

End Class