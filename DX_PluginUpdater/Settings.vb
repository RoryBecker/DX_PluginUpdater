Imports DevExpress.CodeRush.Core

Public Class Settings
#Region "Constants"
    Private Const Section As String = "PluginUpdater"
    Private Const Setting_PluginNames As String = "PluginNames"
    Private Const Setting_OnlyShowUpdates As String = "OnlyShowUpdates"
    Private Const Setting_ForceUpdates As String = "ForceUpdate"
    Private Const Setting_ShowAllCommunityPlugins As String = "ShowAllCommunityPlugins"
    Private Const Setting_AllLocalNew As String = "AllLocalNew"
#End Region
#Region "Fields"
    Private mPluginNames As String()
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
    Public Property PluginNames() As String()
        Get
            Return mPluginNames
        End Get
        Set(ByVal value As String())
            mPluginNames = value
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
        PluginNames = Storage.ReadStrings(Section, Setting_PluginNames)
        OnlyShowUpdates = Storage.ReadBoolean(Section, Setting_OnlyShowUpdates)
        ForceUpdates = Storage.ReadBoolean(Section, Setting_ForceUpdates)

        ShowAllCommunityPlugins = Storage.ReadBoolean(Section, Setting_ShowAllCommunityPlugins)
        AllLocalNew = Storage.ReadString(Section, Setting_AllLocalNew)
    End Sub
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Storage.WriteStrings(Section, Setting_PluginNames, PluginNames)
        Storage.WriteBoolean(Section, Setting_OnlyShowUpdates, OnlyShowUpdates)
        Storage.WriteBoolean(Section, Setting_ForceUpdates, ForceUpdates)

        Storage.WriteBoolean(Section, Setting_ShowAllCommunityPlugins, ShowAllCommunityPlugins)
        Storage.ReadString(Section, Setting_AllLocalNew, AllLocalNew)
    End Sub
End Class

