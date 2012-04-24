
Imports DevExpress.CodeRush.Core

Public Class PluginSettings
#Region "Properties"
    Public PromptBeforeUpdate As Boolean
#End Region

#Region "Constants"
    Public Const SETTING_SECTION As String = "PluginUpdater"

    Public Const SETTING_PromptBeforeUpdate As String = "PromptBeforeUpdate"
    Public Const DEFAULT_PromptBeforeUpdate As Boolean = True
#End Region
#Region "Construction"
    Public Sub New()
        PromptBeforeUpdate = DEFAULT_PromptBeforeUpdate
    End Sub
#End Region
    Public Shared Function LoadSettings(ByVal Storage As DecoupledStorage) As PluginSettings
        Dim Settings As New PluginSettings
        Using StorageInternal = Storage
            Settings.PromptBeforeUpdate = StorageInternal.ReadBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, DEFAULT_PromptBeforeUpdate)
        End Using
        Return Settings
    End Function
    Public Sub Save(ByVal Storage As DecoupledStorage)
        Dim Settings As New PluginSettings
        Using StorageInternal = Storage
            StorageInternal.WriteBoolean(SETTING_SECTION, SETTING_PromptBeforeUpdate, Me.PromptBeforeUpdate)
        End Using
    End Sub
End Class
