Option Strict On
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
    Private ReadOnly mPluginManager As PluginManager = New PluginManager(CodeRush.Options.Paths.CommunityPlugInsPath)
#End Region
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

    Private Sub AddPlugins(ByVal Plugins As IEnumerable(Of PluginRef))
        Dim PluginNames = From Plugin As PluginRef In Plugins
                          Select Plugin.BaseName
        Call AddPlugins(PluginNames)
    End Sub
#End Region
#Region "UI Events"
#Region "Update"
    Private Sub cmdUpdateMultiplePlugins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMultiplePlugins.Click
        Dim PluginNames = txtMultiplePlugins.Lines
        For Each PluginName In PluginNames
            AddMessage(mPluginManager.TryInstallPlugin(PluginName, chkOnlyShowUpdates.Checked))
        Next
        Call AddMessage("All Plugins Checked.")
    End Sub
    Private Sub cmdUpdateMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMe.Click
        mPluginManager.DownloadAndInstallPlugin(mPluginManager.GetLatestRemoteVersionOfPlugin("DX_PluginUpdater"))
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
        Dim LocalPlugins = mPluginManager.GetLocalPluginReferences
        Dim PickedPlugins = PluginPicker.PickPlugins(LocalPlugins)
        Call AddPlugins(PickedPlugins)
    End Sub
    Private Sub cmdAddFromCommunitySite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFromCommunitySite.Click
        Dim CommunityPlugins = mPluginManager.GetCommunityPluginNames
        Dim PickedPlugins = PluginPicker.PickPlugins(CommunityPlugins)
        Call AddPlugins(PickedPlugins)
    End Sub
    Private Sub cmdAddFromNewPlugins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddFromNewPlugins.Click
        Dim CommunityPlugins = mPluginManager.GetCommunityPluginNames
        Dim LocalPlugins = mPluginManager.GetLocalPluginNames

        Dim PickedPlugins = PluginPicker.PickPlugins(CommunityPlugins.Except(LocalPlugins))
        Call AddPlugins(PickedPlugins)
    End Sub
#End Region

    Private Sub cmdOpenPluginFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPluginFolder.Click
        System.Diagnostics.Process.Start(CodeRush.Options.Paths.CommunityPlugInsPath)
    End Sub

    Public Shared Function LoadSettings(ByVal Storage As DecoupledStorage) As Settings
        Return New Settings() With {.Plugins = Storage.ReadStrings("PluginUpdater", "PluginNames")}
    End Function
#End Region
#Region "Options"
    Private Sub Options1_PreparePage(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.PreparePage
        Dim Settings = LoadSettings(ea.Storage)
        txtMultiplePlugins.Lines = Settings.Plugins
    End Sub

    Private Sub Options1_CommitChanges(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.CommitChangesEventArgs) Handles Me.CommitChanges
        ea.Storage.WriteStrings("PluginUpdater", "PluginNames", txtMultiplePlugins.Lines)
    End Sub

    Private Sub Options1_RestoreDefaults(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageEventArgs) Handles Me.RestoreDefaults
        txtMultiplePlugins.Text = String.Empty
    End Sub
#End Region
End Class
