Option Strict On
Imports DevExpress.CodeRush.Core
Imports System.Configuration
Public Enum YesNoAskEnum
    Ask
    Yes
    No
End Enum
Public Class PluginSettings
#Region "Properties"
    Public PromptBeforeUpdate As Boolean
    Public Property RestartDXCore() As YesNoAskEnum
    Public Property CheckForPluginUpdatesOnStartup() As YesNoAskEnum
    Public Property FindAllPlugins() As Boolean
    Public Property FindRecommendedPluginsOnly() As Boolean
    Public Property FindRefactoringPlugins() As Boolean
    Public Property FindCodeGenPlugins() As Boolean
    Public Property FindNavigationalPlugins() As Boolean
#End Region

#Region "Constants"
    Public Const SETTING_SECTION As String = "PluginUpdater"

    Public Const SETTING_CheckForUpdatesOnStartup As String = "CheckForUpdatesOnStartup"
    Public Const DEFAULT_CheckForPluginUpdatesOnStartup As YesNoAskEnum = YesNoAskEnum.No

    Public Const SETTING_RestartDXCore As String = "RestartDXCore"
    Public Const DEFAULT_RestartDXCore As YesNoAskEnum = YesNoAskEnum.Ask

    Public Const SETTING_PromptBeforeUpdate As String = "PromptBeforeUpdate"
    Public Const DEFAULT_PromptBeforeUpdate As Boolean = True

    Public Const SETTING_FindAllPlugins As String = "FindAllPlugins"
    Public Const DEFAULT_FindAllPlugins As Boolean = True

    Public Const SETTING_FindRecommendedPluginsOnly As String = "FindRecommendedPluginsOnly"
    Public Const DEFAULT_FindRecommendedPluginsOnly As Boolean = False

    Public Const SETTING_FindRefactoringPlugins As String = "FindRefactoringPlugins"
    Public Const DEFAULT_FindRefactoringPlugins As Boolean = True

    Public Const SETTING_FindCodeGenPlugins As String = "FindCodeGenPlugins"
    Public Const DEFAULT_FindCodeGenPlugins As Boolean = True

    Public Const SETTING_FindNavigationalPlugins As String = "FindNavigationalPlugins"
    Public Const DEFAULT_FindNavigationalPlugins As Boolean = True

#End Region
#Region "Construction"
    Public Sub New()
        PromptBeforeUpdate = DEFAULT_PromptBeforeUpdate
        RestartDXCore = DEFAULT_RestartDXCore
        CheckForPluginUpdatesOnStartup = DEFAULT_CheckForPluginUpdatesOnStartup

        FindAllPlugins = DEFAULT_FindAllPlugins
        FindRecommendedPluginsOnly = DEFAULT_FindRecommendedPluginsOnly
        FindRefactoringPlugins = DEFAULT_FindRefactoringPlugins
        FindCodeGenPlugins = DEFAULT_FindCodeGenPlugins
        FindNavigationalPlugins = DEFAULT_FindNavigationalPlugins
    End Sub
#End Region
    Public Shared Function LoadSettings(ByVal Storage As DecoupledStorage) As PluginSettings
        Dim Settings As New PluginSettings
        Using StorageInternal = Storage
            Settings.PromptBeforeUpdate = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, DEFAULT_PromptBeforeUpdate)
            Settings.RestartDXCore = Storage.ReadEnum(Of YesNoAskEnum)(SETTING_SECTION, SETTING_RestartDXCore, DEFAULT_RestartDXCore)
            Settings.CheckForPluginUpdatesOnStartup = Storage.ReadEnum(Of YesNoAskEnum)(SETTING_SECTION, SETTING_CheckForUpdatesOnStartup, DEFAULT_CheckForPluginUpdatesOnStartup)

            Settings.FindAllPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindAllPlugins, DEFAULT_FindAllPlugins)
            Settings.FindRecommendedPluginsOnly = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindRecommendedPluginsOnly, DEFAULT_FindRecommendedPluginsOnly)
            Settings.FindRefactoringPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindRefactoringPlugins, DEFAULT_FindRefactoringPlugins)
            Settings.FindCodeGenPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindCodeGenPlugins, DEFAULT_FindCodeGenPlugins)
            Settings.FindNavigationalPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindNavigationalPlugins, DEFAULT_FindNavigationalPlugins)
        End Using
        Return Settings
    End Function
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Using StorageInternal = Storage
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, PromptBeforeUpdate)
            StorageInternal.WriteEnum(SETTING_SECTION, SETTING_RestartDXCore, RestartDXCore)
            StorageInternal.WriteEnum(SETTING_SECTION, SETTING_CheckForUpdatesOnStartup, CheckForPluginUpdatesOnStartup)

            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindAllPlugins, FindAllPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindRecommendedPluginsOnly, FindRecommendedPluginsOnly)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindRefactoringPlugins, FindRefactoringPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindCodeGenPlugins, FindCodeGenPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindNavigationalPlugins, FindNavigationalPlugins)

        End Using
    End Sub


End Class
