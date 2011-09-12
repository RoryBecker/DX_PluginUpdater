Imports System.Xml
Imports System.Xml.Linq
Public Class PluginRef
    Protected mPluginName As String
    Protected mVersion As Integer
    Public Sub New(ByVal PluginName As String, ByVal Version As Integer)
        mPluginName = PluginName
        mVersion = Version
    End Sub
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
End Class
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

End Class