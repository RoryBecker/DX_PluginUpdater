Imports DevExpress.CodeRush.Core

Public Class Settings
#Region "Constants"
    Private Const Section As String = "PluginUpdater"
    Private Const Setting_PluginNames As String = "PluginNames"
    Private Const Setting_OnlyShowUpdates As String = "OnlyShowUpdates"
    Private Const Setting_ForceUpdates As String = "ForceUpdate"
#End Region
#Region "Fields"
    Private mPlugins As String()
    Private mOnlyShowUpdates As Boolean = False
    Private mForceUpdates As Boolean = False
#End Region
#Region "Properties"
    Public Property Plugins() As String()
        Get
            Return mPlugins
        End Get
        Set(ByVal value As String())
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
#End Region
    Public Sub Load(ByVal Storage As DecoupledStorage)
        Plugins = Storage.ReadStrings(Section, Setting_PluginNames)
        OnlyShowUpdates = Storage.ReadBoolean(Section, Setting_OnlyShowUpdates)
        ForceUpdates = Storage.ReadBoolean(Section, Setting_ForceUpdates)
    End Sub
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Storage.WriteStrings(Section, Setting_PluginNames, Plugins)
        Storage.WriteBoolean(Section, Setting_OnlyShowUpdates, OnlyShowUpdates)
        Storage.WriteBoolean(Section, Setting_ForceUpdates, ForceUpdates)
    End Sub
End Class
