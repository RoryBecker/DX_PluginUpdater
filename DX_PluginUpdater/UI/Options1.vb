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
    Private ReadOnly mRoryPluginProvider As New FeedPluginProvider("http://rorybecker.co.uk/DevExpress/community/plugins/RoryPlugins.xml")
    Private ReadOnly mCRFWPluginProvider As New FeedPluginProvider("http://rorybecker.co.uk/DevExpress/community/plugins/CRFWPlugins.xml")
    Private ReadOnly mLocalPluginProvider As New LocalPluginProvider(CodeRush.Options.Paths.CommunityPlugInsPath)
    Private ReadOnly mPluginDownloader As New PluginDownloader(CodeRush.Options.Paths.CommunityPlugInsPath)
    Private ReadOnly NoPlugins As IEnumerable(Of RemotePluginRef) = From item In New String() {} Select New RemotePluginRef(item, "")
    Private mSettings As New Settings
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

#End Region

#Region "UI Events"
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshPluginList()
    End Sub
    Private Sub cmdUpdatePlugins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdatePlugins.Click
        For Each Plugin As RemotePluginRef In GetTickedPlugins()
            AddMessage(mPluginDownloader.TryInstallPlugin(Plugin, chkOnlyShowUpdates.Checked, chkForceUpdate.Checked))
        Next
        Call AddMessage("All Plugins Checked.")
    End Sub
    Private Sub cmdUpdateMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMe.Click
        Dim Plugin As RemotePluginRef = mCommunityPluginProvider.GetLatestCommunityPluginReference("DX_PluginUpdater")
        mPluginDownloader.DownloadAndInstallPlugin(Plugin)
    End Sub
    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        txtLog.Clear()
    End Sub
    Private Sub cmdOpenPluginFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPluginFolder.Click
        System.Diagnostics.Process.Start(CodeRush.Options.Paths.CommunityPlugInsPath)
    End Sub
#End Region
#Region "Options"
    Private Sub Options1_PreparePage(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.PreparePage
        mSettings.Load(ea.Storage)
        Call AssignFrom(mSettings)
        RefreshPluginList()
    End Sub

    Private Sub AssignFrom(ByVal Settings As Settings)
        Dim AllLocalNew As String = Settings.AllLocalNew
        optAll.Checked = AllLocalNew.ToLower = "all"
        optLocal.Checked = AllLocalNew.ToLower = "local"
        optNew.Checked = AllLocalNew.ToLower = "new"
        chkLstPlugins.Items.Clear()
        chkLstPlugins.Items.AddRange(Settings.Plugins)
        chkIncludeCommunitySite.Checked = Settings.ShowAllCommunityPlugins
        chkOnlyShowUpdates.Checked = Settings.OnlyShowUpdates
        chkForceUpdate.Checked = Settings.ForceUpdates
    End Sub

    Private Sub Options1_CommitChanges(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.CommitChangesEventArgs) Handles Me.CommitChanges
        mSettings.OnlyShowUpdates = chkOnlyShowUpdates.Checked
        mSettings.ForceUpdates = chkForceUpdate.Checked
        mSettings.Save(ea.Storage)
    End Sub

    Private Sub Options1_RestoreDefaults(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageEventArgs) Handles Me.RestoreDefaults
        Call AssignFrom(New Settings)
    End Sub
#End Region

    Public Sub RefreshPluginList()
        ' Update Plugins shown on tabPlugins
        Dim FeedPlugins = GetFeedPlugins(txtFeeds.Text)
        Dim CustomPlugins = GetCustomPlugins(txtCustom.Text)
        Dim CommunityPlugins = GetCommunityPlugins()
        Dim Exclusions = GetFeedPlugins(CommunityPluginProvider.RemoteBasePluginFolder & "ExcludePlugins.xml")
        Dim Unstable = GetFeedPlugins(CommunityPluginProvider.RemoteBasePluginFolder & "UnstablePlugins.xml")
        Dim TickedPlugins As IEnumerable(Of RemotePluginRef) = NoPlugins 'Temporary
        Dim AllPlugins = TickedPlugins _
                         .Union(FeedPlugins) _
                         .Union(CustomPlugins) _
                         .Union(CommunityPlugins) _
                         .Except(Exclusions) _
                         .Except(Unstable)
        RepopulatePluginList(AllPlugins)
    End Sub
    Private Sub RepopulatePluginList(ByVal AllPlugins As IEnumerable(Of RemotePluginRef))
        chkLstPlugins.Items.Clear()
        For Each Plugin In From Item In AllPlugins Where Included(Item) Order By Item.PluginName
            chkLstPlugins.Items.Add(Plugin)
        Next
    End Sub
    Private Function Included(ByVal Plugin As RemotePluginRef) As Boolean
        If optAll.Checked Then
            Return True
        End If
        If optNew.Checked AndAlso Not mLocalPluginProvider.PluginExists(Plugin) Then
            Return True
        End If
        If optLocal.Checked AndAlso mLocalPluginProvider.PluginExists(Plugin) Then
            Return True
        End If
        Return False
    End Function
    Public Function GetTickedPlugins() As IEnumerable(Of RemotePluginRef)
        Return From item In chkLstPlugins.CheckedItems Select TryCast(item, RemotePluginRef)
    End Function
#Region "Get Plugins"
    Private Function GetCommunityPlugins() As IEnumerable(Of RemotePluginRef)
        Dim CommunityPlugins As IEnumerable(Of RemotePluginRef) = Nothing
        If chkIncludeCommunitySite.Checked Then
            CommunityPlugins = From Plugin In mCommunityPluginProvider.GetPluginReferencesQuick()
        Else
            CommunityPlugins = NoPlugins
        End If
        Return CommunityPlugins
    End Function
    Private Function GetCustomPlugins(ByVal Source As String) As IEnumerable(Of RemotePluginRef)
        Dim CustomPluginNames As String() = GetFeedNames(Source)

        Dim CustomPlugins = _
            From Name As String In CustomPluginNames _
            Select mCommunityPluginProvider.GetLatestCommunityPluginReference(Name)
        Return CustomPlugins
    End Function
    Private Function GetFeedNames(ByVal Source As String) As String()
        Dim FeedNames As String() = Split(Source.Trim, Environment.NewLine)
        If FeedNames.Count = 1 AndAlso FeedNames(0).Trim = "" Then
            FeedNames = New String() {}
        End If
        Return FeedNames
    End Function
    Private Function GetFeedPlugins(ByVal Source As String) As IEnumerable(Of RemotePluginRef)
        Dim FeedNames As String() = GetFeedNames(Source)
        Dim FeedPlugins = _
                    From URL As String In FeedNames, plugin In New FeedPluginProvider(URL).GetPluginReferences() _
                    Select plugin
        Return FeedPlugins
    End Function
#End Region
#Region "Links"
    Private Function CurrentPluginName() As String
        Dim SelectedItems As IEnumerable(Of RemotePluginRef) = _
            From item In chkLstPlugins.SelectedItems Select TryCast(item, RemotePluginRef)
        Return If(SelectedItems.Any, SelectedItems.First.PluginName, "")
    End Function

    Private Sub chkLstPlugins_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstPlugins.SelectedIndexChanged
        Dim PluginName As String = CurrentPluginName()
        lnkWiki.Text = "Wiki: " & PluginName
        lnkBinaries.Text = "Binaries:" & PluginName
        lnkSource.Text = "Source: " & PluginName
    End Sub
    Public Const BaseWikiUrl As String = "http://code.google.com/p/dxcorecommunityplugins/wiki/"
    Public Const BaseBinaryUrl As String = "http://www.rorybecker.co.uk/DevExpress/Plugins/Community/"
    Public Const BaseSourceUrl As String = "http://code.google.com/p/dxcorecommunityplugins/source/browse/trunk/"

    Private Sub lnkWiki_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkWiki.LinkClicked
        System.Diagnostics.Process.Start(BaseWikiUrl & CurrentPluginName())
    End Sub

    Private Sub lnkBinaries_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBinaries.LinkClicked
        System.Diagnostics.Process.Start(BaseBinaryUrl & CurrentPluginName())
    End Sub

    Private Sub lnkSource_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSource.LinkClicked
        System.Diagnostics.Process.Start(BaseSourceUrl & CurrentPluginName())
    End Sub
#End Region

    Private Sub cmdRestartDXCore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestartDXCore.Click
        If MsgBox("Are you sure you want to restart the DXCore?", vbYesNo) = MsgBoxResult.Yes Then
            Call DXCoreOps.RestartDXCore()
        End If
    End Sub
End Class
