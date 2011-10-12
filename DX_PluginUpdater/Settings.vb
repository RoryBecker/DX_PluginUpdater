Imports DevExpress.CodeRush.Core
Imports System.Linq
Imports System.Runtime.CompilerServices

Public Class Settings
#Region "Setting Defaults"
    Private Default_PluginNames As String()
    Const Default_AllLocalNew As String = "All"
    Const Default_ForceUpdates As Boolean = False
    Const Default_OnlyShowUpdates As Boolean = False
    Const Default_ShowAllCommunityPlugins As Boolean = False
#End Region
#Region "Setting Names"
    Private Const Section As String = "PluginUpdater"
    Private Const Setting_PluginNames As String = "PluginNames"
    Private Const Setting_OnlyShowUpdates As String = "OnlyShowUpdates"
    Private Const Setting_ForceUpdates As String = "ForceUpdate"
    Private Const Setting_ShowAllCommunityPlugins As String = "ShowAllCommunityPlugins"
    Private Const Setting_AllLocalNew As String = "AllLocalNew"
#End Region

#Region "Fields"
    Private mPlugins As RemotePluginRef()
    Private mOnlyShowUpdates As Boolean = False
    Private mForceUpdates As Boolean = False
    Private mShowAllCommunityPlugins As Boolean = False
    Private mAllLocalNew As String = "all"
#End Region
#Region "Properties"
    Public Property AllLocalNew() As String
        Get
            Return mAllLocalNew
        End Get
        Set(ByVal value As String)
            mAllLocalNew = value
        End Set
    End Property
    Public Property Plugins() As RemotePluginRef()
        Get
            Return mPlugins
        End Get
        Set(ByVal value As RemotePluginRef())
            mPlugins = value
        End Set
    End Property

    Public Property OnlyShowUpdates As Boolean
        Get
            Return mOnlyShowUpdates
        End Get
        Set(ByVal Value As Boolean)
            mOnlyShowUpdates = Value
        End Set
    End Property
    Public Property ForceUpdates() As Boolean
        Get
            Return mForceUpdates
        End Get
        Set(ByVal value As Boolean)
            mForceUpdates = value
        End Set
    End Property
    Public Property ShowAllCommunityPlugins() As Boolean
        Get
            Return mShowAllCommunityPlugins
        End Get
        Set(ByVal value As Boolean)
            mShowAllCommunityPlugins = value
        End Set
    End Property
#End Region
    Public Sub Load(ByVal Storage As DecoupledStorage)
        Plugins = (From plugin As String In Storage.ReadStrings(Section, Setting_PluginNames, Default_PluginNames) _
                                            Select plugin.ToRemotePluginRef).ToArray
        OnlyShowUpdates = Storage.ReadBoolean(Section, Setting_OnlyShowUpdates, Default_OnlyShowUpdates)
        ForceUpdates = Storage.ReadBoolean(Section, Setting_ForceUpdates, Default_ForceUpdates)

        ShowAllCommunityPlugins = Storage.ReadBoolean(Section, Setting_ShowAllCommunityPlugins, Default_ShowAllCommunityPlugins)
        AllLocalNew = Storage.ReadString(Section, Setting_AllLocalNew, Default_AllLocalNew)
    End Sub
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Dim PluginsAsStrings = (From plugin As RemotePluginRef In Plugins Select plugin.ToSerialisedString).ToArray
        Storage.WriteStrings(Section, Setting_PluginNames, PluginsAsStrings)
        Storage.WriteBoolean(Section, Setting_OnlyShowUpdates, OnlyShowUpdates)
        Storage.WriteBoolean(Section, Setting_ForceUpdates, ForceUpdates)

        Storage.WriteBoolean(Section, Setting_ShowAllCommunityPlugins, ShowAllCommunityPlugins)
        Storage.WriteString(Section, Setting_AllLocalNew, AllLocalNew)
    End Sub
End Class

Module StringExtensions
    <Extension()> _
    Public Function ToRemotePluginRef(ByVal Source As String) As RemotePluginRef
        Dim Parts = Source.Split("|")
        Dim Name As String = parts(0)
        Dim URL As String = String.Empty
        If Parts.Count = 2 Then
            URL = Parts(1)
        Else
            URL = CommunityPluginProvider.RemoteBasePluginFolder & Parts(0)
        End If
        Return New RemotePluginRef(name, url)
    End Function
    <Extension()> _
    Public Function ToSerialisedString(ByVal Source As RemotePluginRef) As String
        Dim Url As String = String.Empty
        If Source.RemoteFolderUrl = String.Empty Then
            Url = CommunityPluginProvider.RemoteBasePluginFolder
        Else
            Url = Source.RemoteFolderUrl
        End If
        Return Source.PluginName & "|" & Url
    End Function
End Module