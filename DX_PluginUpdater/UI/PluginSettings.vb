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
#End Region

#Region "Constants"
    Public Const SETTING_SECTION As String = "PluginUpdater"

    Public Const SETTING_RestartDXCore As String = "RestartDXCore"
    Public Const SETTING_PromptBeforeUpdate As String = "PromptBeforeUpdate"
    Public Const DEFAULT_PromptBeforeUpdate As Boolean = True
    Public Const DEFAULT_RestartDXCore As YesNoAskEnum = YesNoAskEnum.Ask
#End Region
#Region "Construction"
    Public Sub New()
        PromptBeforeUpdate = DEFAULT_PromptBeforeUpdate
        RestartDXCore = DEFAULT_RestartDXCore
    End Sub
#End Region
    Public Shared Function LoadSettings(ByVal Storage As DecoupledStorage) As PluginSettings
        Dim Settings As New PluginSettings
        Using StorageInternal = Storage
            Settings.PromptBeforeUpdate = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, DEFAULT_PromptBeforeUpdate)
            Settings.RestartDXCore = Storage.ReadEnum(Of YesNoAskEnum)(SETTING_SECTION, SETTING_RestartDXCore, DEFAULT_RestartDXCore)
        End Using
        Return Settings
    End Function
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Using StorageInternal = Storage
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, PromptBeforeUpdate)
            StorageInternal.WriteEnum(SETTING_SECTION, SETTING_RestartDXCore, RestartDXCore)
        End Using
    End Sub


End Class
