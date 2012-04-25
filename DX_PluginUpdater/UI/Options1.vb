Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
<UserLevel(UserLevel.Advanced)> _
Public Class Options1

    'DXCore-generated code...
#Region " Initialize "
    Protected Overrides Sub Initialize()
        MyBase.Initialize()

        'TODO: Add your initialization code here.
    End Sub
#End Region

#Region " GetCategory "
    Public Shared Function GetCategory() As String
        Return "Community"
    End Function
#End Region
#Region " GetPageName "
    Public Shared Function GetPageName() As String
        Return "Plugin Updater"
    End Function
#End Region
    Private PluginSettings As New PluginSettings
    Public Function LoadSettings(ByVal ea As OptionsPageStorageEventArgs) As PluginSettings
        Return PluginSettings.LoadSettings(ea.Storage)
    End Function
    Private Sub Options1_RestoreDefaults(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageEventArgs) Handles Me.RestoreDefaults
        ' Setup defaults here
        chkPromptBeforeUpdating.Checked = PluginSettings.DEFAULT_PromptBeforeUpdate
        ynaRestartDXCore.YesNoAskValue = PluginSettings.DEFAULT_RestartDXCore
    End Sub

    Private Sub Options1_PreparePage(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.PreparePage
        ' Load options here
        Dim Settings = PluginSettings.LoadSettings(Options1.Storage)
        chkPromptBeforeUpdating.Checked = Settings.PromptBeforeUpdate
        ynaRestartDXCore.YesNoAskValue = Settings.RestartDXCore
    End Sub

    Private Sub Options1_CommitChanges(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.CommitChangesEventArgs) Handles Me.CommitChanges
        ' Save changes here.
        Dim Settings As New PluginSettings
        Settings.PromptBeforeUpdate = chkPromptBeforeUpdating.Checked
        Settings.RestartDXCore = ynaRestartDXCore.YesNoAskValue

        Settings.Save(Options1.Storage)
    End Sub


    Private Sub Options1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
