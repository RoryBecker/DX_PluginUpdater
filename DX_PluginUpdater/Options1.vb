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
    Private Sub TryGetPlugin(ByVal PluginName As String)
        PluginName = PluginName.Trim
        If PluginName <> String.Empty Then
            If mPluginManager.PluginUpdateExists(PluginName) Then
                AddMessage(mPluginManager.DownloadAndInstallPlugin(PluginName))
            Else
                AddMessage(String.Format("No update currently exists for plugin {0}.", PluginName))
            End If
        End If
    End Sub
    Private Sub AddMessage(ByVal Message As String)
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

    Private Sub cmdOpenPluginFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPluginFolder.Click
        System.Diagnostics.Process.Start(CodeRush.Options.Paths.CommunityPlugInsPath)
    End Sub
    Private Sub cmdCheckForMultipleUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckForMultipleUpdates.Click
        For Each PluginName In Split(txtMultiplePlugins.Text, Environment.NewLine)
            TryGetPlugin(PluginName)
        Next
        Call AddMessage("All Plugins Checked.")
    End Sub

    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        txtLog.Clear()
    End Sub

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
    Private Sub cmdNewPlugins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewPlugins.Click
        Dim CommunityPlugins = mPluginManager.GetCommunityPluginNames
        Dim LocalPlugins = mPluginManager.GetLocalPluginNames

        Dim PickedPlugins = PluginPicker.PickPlugins(CommunityPlugins.Except(LocalPlugins))
        Call AddPlugins(PickedPlugins)
    End Sub
    Private Sub cmdUpdateMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMe.Click
        mPluginManager.DownloadAndInstallPlugin(mPluginManager.GetLatestVersionOfPlugin("DX_PluginUpdater"))
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtMultiplePlugins.Clear()
    End Sub
#End Region
End Class