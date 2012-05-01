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
        chkUserUnderstandsWarning.Checked = PluginSettings.DEFAULT_UserUnderstandsWarning
        chkFindPromptBeforeUpdating.Checked = PluginSettings.DEFAULT_PromptBeforeUpdate
        ynaRestartDXCore.YesNoAskValue = PluginSettings.DEFAULT_RestartDXCore
        ynaCheckForPluginUpdatesOnStartup.YesNoAskValue = PluginSettings.DEFAULT_CheckForPluginUpdatesOnStartup

        optAllPlugins.Checked = PluginSettings.DEFAULT_FindAllPlugins
        optSelectedPlugins.Checked = Not PluginSettings.DEFAULT_FindAllPlugins

        chkFindNavigationPlugins.Checked = PluginSettings.DEFAULT_FindNavigationalPlugins
        chkFindCodeGenPlugins.Checked = PluginSettings.DEFAULT_FindCodeGenPlugins
        chkFindRefactoringPlugins.Checked = PluginSettings.DEFAULT_FindRefactoringPlugins
        chkFindCodeIssuePlugins.Checked = PluginSettings.DEFAULT_FindCodeIssuePlugins
        chkFindPaintingPlugins.Checked = PluginSettings.DEFAULT_FindPaintingPlugins
        chkFindMiscPlugins.Checked = PluginSettings.DEFAULT_FindMiscPlugins
    End Sub

    Private Sub Options1_PreparePage(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.PreparePage
        ' Load options here
        Dim Settings = PluginSettings.LoadSettings(Options1.Storage)
        chkUserUnderstandsWarning.Checked = Settings.UserUnderstandsWarning
        chkFindPromptBeforeUpdating.Checked = Settings.PromptBeforeUpdate
        ynaRestartDXCore.YesNoAskValue = Settings.RestartDXCore
        ynaCheckForPluginUpdatesOnStartup.YesNoAskValue = Settings.CheckForPluginUpdatesOnStartup

        optAllPlugins.Checked = Settings.FindAllPlugins
        optSelectedPlugins.Checked = Not Settings.FindAllPlugins

        chkFindNavigationPlugins.Checked = Settings.FindNavigationalPlugins
        chkFindCodeGenPlugins.Checked = Settings.FindCodeGenPlugins
        chkFindRefactoringPlugins.Checked = Settings.FindRefactoringPlugins
        chkFindCodeIssuePlugins.Checked = Settings.FindCodeIssuePlugins
        chkFindPaintingPlugins.Checked = Settings.FindPaintingPlugins
        chkFindMiscPlugins.Checked = Settings.FindMiscPlugins
    End Sub

    Private Sub Options1_CommitChanges(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.CommitChangesEventArgs) Handles Me.CommitChanges
        ' Save changes here.
        Dim Settings As New PluginSettings

        Settings.UserUnderstandsWarning = chkUserUnderstandsWarning.Checked
        Settings.PromptBeforeUpdate = chkFindPromptBeforeUpdating.Checked
        Settings.RestartDXCore = ynaRestartDXCore.YesNoAskValue
        Settings.CheckForPluginUpdatesOnStartup = ynaCheckForPluginUpdatesOnStartup.YesNoAskValue

        Settings.FindAllPlugins = optAllPlugins.Checked

        Settings.FindCodeGenPlugins = chkFindCodeGenPlugins.Checked
        Settings.FindNavigationalPlugins = chkFindNavigationPlugins.Checked
        Settings.FindRefactoringPlugins = chkFindRefactoringPlugins.Checked
        Settings.FindCodeIssuePlugins = chkFindCodeIssuePlugins.Checked
        Settings.FindPaintingPlugins = chkFindPaintingPlugins.Checked
        Settings.FindMiscPlugins = chkFindMiscPlugins.Checked

        Settings.Save(Options1.Storage)
    End Sub

    Private Sub cmdFindNewPlugins_Click(sender As System.Object, e As System.EventArgs) Handles cmdFindNewPlugins.Click
        CodeRush.Actions.Item(PlugIn1.ACTION_FindNewPlugins).DoExecute()
    End Sub

    Private Sub optAllPlugins_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAllPlugins.CheckedChanged
        chkFindCodeGenPlugins.Enabled = Not optAllPlugins.Checked
        chkFindRefactoringPlugins.Enabled = Not optAllPlugins.Checked
        chkFindNavigationPlugins.Enabled = Not optAllPlugins.Checked
        chkFindCodeIssuePlugins.Enabled = Not optAllPlugins.Checked
        chkFindPaintingPlugins.Enabled = Not optAllPlugins.Checked
        chkFindMiscPlugins.Enabled = Not optAllPlugins.Checked
    End Sub

    Private Sub cmdUpdatePluginsNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdUpdatePluginsNow.Click
        CodeRush.Actions.Item(PlugIn1.ACTION_UpdatePlugins).DoExecute()
    End Sub
End Class
