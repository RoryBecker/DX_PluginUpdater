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
    Public Property FindRefactoringPlugins() As Boolean
    Public Property FindCodeGenPlugins() As Boolean
    Public Property FindNavigationalPlugins() As Boolean
    Public Property FindCodeIssuePlugins() As Boolean
    Public Property FindPaintingPlugins() As Boolean
    Public Property FindMiscPlugins() As Boolean
    Public Property UserUnderstandsWarning() As Boolean
#End Region

#Region "Constants"
    Public Const SETTING_SECTION As String = "PluginUpdater"

    Public Const SETTING_CheckForUpdatesOnStartup As String = "CheckForUpdatesOnStartup"
    Public Const DEFAULT_CheckForPluginUpdatesOnStartup As YesNoAskEnum = YesNoAskEnum.No

    Public Const SETTING_RestartDXCore As String = "RestartDXCore"
    Public Const DEFAULT_RestartDXCore As YesNoAskEnum = YesNoAskEnum.Ask

    Public Const SETTING_UserUnderstandsWarning As String = "UserUnderstandsWarning"
    Public Const DEFAULT_UserUnderstandsWarning As Boolean = False

    Public Const SETTING_PromptBeforeUpdate As String = "PromptBeforeUpdate"
    Public Const DEFAULT_PromptBeforeUpdate As Boolean = True

    Public Const SETTING_FindAllPlugins As String = "FindAllPlugins"
    Public Const DEFAULT_FindAllPlugins As Boolean = True

    Public Const SETTING_FindRefactoringPlugins As String = "FindRefactoringPlugins"
    Public Const DEFAULT_FindRefactoringPlugins As Boolean = True

    Public Const SETTING_FindCodeGenPlugins As String = "FindCodeGenPlugins"
    Public Const DEFAULT_FindCodeGenPlugins As Boolean = True

    Public Const SETTING_FindNavigationalPlugins As String = "FindNavigationalPlugins"
    Public Const DEFAULT_FindNavigationalPlugins As Boolean = True

    Public Const SETTING_FindCodeIssuePlugins As String = "FindCodeIssuePlugins"
    Public Const DEFAULT_FindCodeIssuePlugins As Boolean = True

    Public Const SETTING_FindPaintingPlugins As String = "FindPaintingPlugins"
    Public Const DEFAULT_FindPaintingPlugins As Boolean = True

    Public Const SETTING_FindMiscPlugins As String = "FindMiscPlugins"
    Public Const DEFAULT_FindMiscPlugins As Boolean = True

#End Region
#Region "Construction"
    Public Sub New()
        PromptBeforeUpdate = DEFAULT_PromptBeforeUpdate
        RestartDXCore = DEFAULT_RestartDXCore
        CheckForPluginUpdatesOnStartup = DEFAULT_CheckForPluginUpdatesOnStartup

        UserUnderstandsWarning = DEFAULT_UserUnderstandsWarning
        FindAllPlugins = DEFAULT_FindAllPlugins
        FindRefactoringPlugins = DEFAULT_FindRefactoringPlugins
        FindCodeGenPlugins = DEFAULT_FindCodeGenPlugins
        FindNavigationalPlugins = DEFAULT_FindNavigationalPlugins
        FindCodeIssuePlugins = DEFAULT_FindCodeIssuePlugins
        FindPaintingPlugins = DEFAULT_FindPaintingPlugins
        FindMiscPlugins = DEFAULT_FindMiscPlugins
    End Sub
#End Region
    Public Shared Function LoadSettings(ByVal Storage As DecoupledStorage) As PluginSettings
        Dim Settings As New PluginSettings
        Using StorageInternal = Storage
            Settings.UserUnderstandsWarning = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_UserUnderstandsWarning, DEFAULT_UserUnderstandsWarning)
            Settings.PromptBeforeUpdate = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, DEFAULT_PromptBeforeUpdate)
            Settings.RestartDXCore = Storage.ReadEnum(Of YesNoAskEnum)(SETTING_SECTION, SETTING_RestartDXCore, DEFAULT_RestartDXCore)
            Settings.CheckForPluginUpdatesOnStartup = Storage.ReadEnum(Of YesNoAskEnum)(SETTING_SECTION, SETTING_CheckForUpdatesOnStartup, DEFAULT_CheckForPluginUpdatesOnStartup)

            Settings.FindAllPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindAllPlugins, DEFAULT_FindAllPlugins)
            Settings.FindRefactoringPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindRefactoringPlugins, DEFAULT_FindRefactoringPlugins)
            Settings.FindCodeGenPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindCodeGenPlugins, DEFAULT_FindCodeGenPlugins)
            Settings.FindNavigationalPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindNavigationalPlugins, DEFAULT_FindNavigationalPlugins)
            Settings.FindCodeIssuePlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindCodeIssuePlugins, DEFAULT_FindCodeIssuePlugins)
            Settings.FindPaintingPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindPaintingPlugins, DEFAULT_FindPaintingPlugins)
            Settings.FindMiscPlugins = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_FindMiscPlugins, DEFAULT_FindMiscPlugins)
        End Using
        Return Settings
    End Function
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Using StorageInternal = Storage
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_UserUnderstandsWarning, UserUnderstandsWarning)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, PromptBeforeUpdate)
            StorageInternal.WriteEnum(SETTING_SECTION, SETTING_RestartDXCore, RestartDXCore)
            StorageInternal.WriteEnum(SETTING_SECTION, SETTING_CheckForUpdatesOnStartup, CheckForPluginUpdatesOnStartup)

            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindAllPlugins, FindAllPlugins)

            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindRefactoringPlugins, FindRefactoringPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindCodeGenPlugins, FindCodeGenPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindNavigationalPlugins, FindNavigationalPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindCodeIssuePlugins, FindCodeIssuePlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindPaintingPlugins, FindPaintingPlugins)
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_FindMiscPlugins, FindMiscPlugins)

        End Using
    End Sub


End Class
