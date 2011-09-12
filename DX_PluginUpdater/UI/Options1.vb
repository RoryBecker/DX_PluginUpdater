Option Strict On
Option Infer On
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports System.Net
Imports System.IO
Imports System.Linq
<UserLevel(UserLevel.NewUser)> _
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
        Return "Community\Plugins"
    End Function
#End Region
#Region " GetPageName "
    Public Shared Function GetPageName() As String
        Return "PluginUpdater"
    End Function
#End Region

#Region "Fields"
    Private ReadOnly mCommunityPluginProvider As New CommunityPluginProvider
    Private ReadOnly mLocalPluginProvider As New LocalPluginProvider(CodeRush.Options.Paths.CommunityPlugInsPath)
    Private ReadOnly mPluginDownloader As New PluginDownloader(CodeRush.Options.Paths.CommunityPlugInsPath)
#End Region
    Private mSettings As New Settings
#Region "Utility"
    Private Sub AddMessage(ByVal Message As String)
        If Message = String.Empty OrElse Message.Trim = String.Empty Then
            Exit Sub
        End If
        txtLog.AppendText(Environment.NewLine & Message)
        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.ScrollToCaret()
    End Sub

    Private Sub AddPlugins(ByVal Plugins As IEnumerable(Of String))
        For Each Plugin In Plugins
            If txtMultiplePlugins.Text.Trim <> String.Empty AndAlso Not txtMultiplePlugins.Text.EndsWith(Environment.NewLine) Then
                txtMultiplePlugins.AppendText(Environment.NewLine)
            End If
            txtMultiplePlugins.AppendText(Plugin & Environment.NewLine)
        Next
    End Sub

    Private Sub AddPlugins(ByVal Plugins As IEnumerable(Of RemotePluginRef))
        Dim PluginNames = From Plugin As RemotePluginRef In Plugins
                          Select Plugin.PluginName
        Call AddPlugins(PluginNames)
    End Sub
#End Region
#Region "UI Events"
#Region "Update"
    Private Sub cmdUpdateMultiplePlugins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMultiplePlugins.Click
        Dim PluginNames = txtMultiplePlugins.Lines
        For Each PluginName In PluginNames
            AddMessage(mPluginDownloader.TryInstallPlugin(PluginName, chkOnlyShowUpdates.Checked, chkForceUpdate.Checked))
        Next
        Call AddMessage("All Plugins Checked.")
    End Sub
    Private Sub cmdUpdateMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMe.Click
        mPluginDownloader.DownloadAndInstallPlugin(mCommunityPluginProvider.GetPluginReference("DX_PluginUpdater"))
    End Sub
#End Region

#Region "Clear"
    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        txtLog.Clear()
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtMultiplePlugins.Clear()
    End Sub
#End Region

#Region "List Population"
    Private Sub cmdAddFromLocalMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFromLocalMachine.Click
        Dim LocalPlugins = mLocalPluginProvider.GetPluginReferences
        Dim PickedPlugins = PluginPicker.PickPlugins(LocalPlugins)
        Call AddPlugins(PickedPlugins)
    End Sub
    Private Sub cmdAddFromCommunitySite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFromCommunitySite.Click
        Dim CommunityPlugins = mCommunityPluginProvider.GetPluginNames
        Dim PickedPlugins = PluginPicker.PickPlugins(CommunityPlugins)
        Call AddPlugins(PickedPlugins)
    End Sub
    Private Sub cmdAddFromNewPlugins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFromNewPlugins.Click
        Dim CommunityPlugins = mCommunityPluginProvider.GetPluginNames
        Dim LocalPlugins = mLocalPluginProvider.GetPluginNames

        Dim PickedPlugins = PluginPicker.PickPlugins(CommunityPlugins.Except(LocalPlugins))
        Call AddPlugins(PickedPlugins)
    End Sub
#End Region

    Private Sub cmdOpenPluginFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPluginFolder.Click
        System.Diagnostics.Process.Start(CodeRush.Options.Paths.CommunityPlugInsPath)
    End Sub
#End Region
#Region "Options"
    Private Sub Options1_PreparePage(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.PreparePage
        mSettings.Load(ea.Storage)
        Call AssignFrom(mSettings)
    End Sub

    Private Sub AssignFrom(ByVal Settings As Settings)
        txtMultiplePlugins.Lines = Settings.Plugins
        chkOnlyShowUpdates.Checked = Settings.OnlyShowUpdates
        chkForceUpdate.Checked = Settings.ForceUpdates
    End Sub

    Private Sub Options1_CommitChanges(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.CommitChangesEventArgs) Handles Me.CommitChanges
        mSettings.Plugins = txtMultiplePlugins.Lines
        mSettings.OnlyShowUpdates = chkOnlyShowUpdates.Checked
        mSettings.ForceUpdates = chkForceUpdate.Checked
        mSettings.Save(ea.Storage)
    End Sub

    Private Sub Options1_RestoreDefaults(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageEventArgs) Handles Me.RestoreDefaults
        Call AssignFrom(New Settings)
    End Sub
#End Region
End Class
