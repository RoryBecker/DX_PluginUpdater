Option Infer On
Option Strict On
Imports DevExpress.CodeRush.Core
Imports System.Linq
Imports DX_PluginUpdater.IEnumerableExt
Imports System

Public Class PlugIn1
    Private Const ACTION_UpdatePlugins As String = "UpdatePlugins"
    'DXCore-generated code...
    Private Output As OutputWriter
#Region " InitializePlugIn "
    Public Overrides Sub InitializePlugIn()
        MyBase.InitializePlugIn()
        Call LoadSettings()
        Call RegisterUpdatePluginsCommand()
        Call RegisterFindNewPlugins()
        AddHandler EventNexus.DXCoreLoaded, AddressOf EventNexus_DXCoreLoaded
        Output = New OutputWriter("Plugin Updater")
        Call CheckForUpdates()
    End Sub
#End Region
#Region " FinalizePlugIn "
    Public Overrides Sub FinalizePlugIn()
        'TODO: Add your finalization code here.
        RemoveHandler EventNexus.DXCoreLoaded, AddressOf EventNexus_DXCoreLoaded
        MyBase.FinalizePlugIn()
        Output = Nothing
    End Sub
#End Region

#Region "Constants"
    Private Const MenuCaption_Update_Plugins As String = "Update Plugins"
    Private Const MenuCaption_Find_Plugins As String = "Find New Plugins"
    Private Const CommunitySiteRootPluginUrl As String = "http://www.rorybecker.co.uk/DevExpress/Community/Plugins/"
#End Region
#Region "Settings"

    Dim Settings As PluginSettings
    Private Sub LoadSettings()
        Settings = PluginSettings.LoadSettings(Options1.Storage)
    End Sub
#End Region
#Region "User Interface"
    Public Sub SetMenuBeginGroupByCaption(Caption As String, BeginGroupValue As Boolean)
        Dim Menu = CodeRush.Menus.DXCore.FindByCaption(Caption)
        If Not Menu Is Nothing Then
            Menu.BeginGroup = BeginGroupValue
        End If
    End Sub
    Public Sub SetMenuPositionAfterByCaption(MenuCaption As String, RelativeCaption As String)
        Dim Menu = CodeRush.Menus.DXCore.FindByCaption(MenuCaption)
        If Menu Is Nothing Then
            Exit Sub
        End If
        Dim RelativeMenu = CodeRush.Menus.DXCore.FindByCaption(RelativeCaption)
        If RelativeMenu Is Nothing Then
            Exit Sub
        End If
        Menu.MoveTo(RelativeMenu.Index)
    End Sub
    Private Sub EventNexus_DXCoreLoaded(ByVal ea As DXCoreLoadedEventArgs)
        Call SetMenuPositionAfterByCaption(MenuCaption_Update_Plugins, "&New Plug-in...")
        Call SetMenuPositionAfterByCaption(MenuCaption_Find_Plugins, MenuCaption_Update_Plugins)
    End Sub
    Public Sub ShowMessage(message As String)
        CodeRush.ApplicationObject.StatusBar.Text = message
        Output.Writeline(message)
    End Sub


#End Region
    Private Sub RestartDXCore(ByVal Count As Integer)
        If Count <= 0 Then
            Return
        End If

        Select Case Settings.RestartDXCore
            Case YesNoAskEnum.Yes
                DXCoreOps.RestartDXCore()
            Case YesNoAskEnum.Ask
                If MsgBox(String.Format("{0} plugins were downloaded and installed. Would you like to restart the DXCore in order to load them?", Count), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    DXCoreOps.RestartDXCore()
                End If
            Case YesNoAskEnum.No
                ' Do nothing. On Purpose :)
        End Select
    End Sub
    Private Sub CheckForUpdates()
        Select Case Settings.CheckForPluginUpdatesOnStartup
            Case YesNoAskEnum.Ask
                If MsgBox("Would you like to check for Plugin updates now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CodeRush.Actions.Item(ACTION_UpdatePlugins).DoExecute()
                End If
            Case YesNoAskEnum.Yes
                CodeRush.Actions.Item(ACTION_UpdatePlugins).DoExecute()
            Case YesNoAskEnum.No
                ' Do nothing. On Purpose :)
        End Select
    End Sub
#Region "Action: Update Existing Plugins"
    ' ProposedOption: Don't Prompt
    ' SubOption: UpdateEverything
    ' SubOption: ExcludePlugins
    ' ProposedOption: RestartDXCore: Yes/No/Ask
    Public Sub RegisterUpdatePluginsCommand()
        Dim UpdatePlugins As New DevExpress.CodeRush.Core.Action(components)
        CType(UpdatePlugins, System.ComponentModel.ISupportInitialize).BeginInit()
        UpdatePlugins.ActionName = ACTION_UpdatePlugins
        UpdatePlugins.ButtonText = MenuCaption_Update_Plugins ' Used if button is placed on a menu.
        UpdatePlugins.RegisterInCR = True
        UpdatePlugins.CommonMenu = DevExpress.CodeRush.Menus.VsCommonBar.DevExpress
        AddHandler UpdatePlugins.Execute, AddressOf UpdatePlugins_Execute
        CType(UpdatePlugins, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub UpdatePlugins_Execute(ByVal ea As ExecuteEventArgs)
        ' Providers
        Dim LocalPluginProvider = New LocalPluginProvider(CodeRush.Options.Paths.CommunityPlugInsPath)
        Dim CommunityPluginProvider = New CommunityPluginProvider(LocalPluginProvider, CommunitySiteRootPluginUrl)
        Dim PluginDownloader = New PluginDownloader(LocalPluginProvider, CommunityPluginProvider)

        ' Plugins
        Dim CommunityPlugins = CommunityPluginProvider.GetRemoteReferencesLatestAll
        Dim LocalPlugins = LocalPluginProvider.GetPluginReferences

        Dim SourcePlugins = LocalPlugins.Intersection(CommunityPlugins)
        Dim PickedPlugins As IEnumerable(Of RemotePluginRef) = SourcePlugins
        If Settings.PromptBeforeUpdate Then
            PickedPlugins = PluginPicker.GetPlugins(SourcePlugins, PickedVsUnPickedEnum.Picked)
        End If

        ' Action
        Dim UpdatedPlugins = PluginDownloader.DownloadPlugins(PickedPlugins, AddressOf ShowMessage, True)
        Call ShowMessage(String.Format("{0} plugins found. {1} plugins updated.", PickedPlugins.Count, UpdatedPlugins.Count))
        RestartDXCore(UpdatedPlugins.Count)
    End Sub
#End Region

#Region "Action: Find New (Recommended) Plugins"
    ' ProposedOption: Show Recommended only.
    ' ProposedOption: Show All Plugins (excluding Unstable)

    ' ProposedOption: Show Navigation Plugins
    ' ProposedOption: Show Refactoring Plugins
    ' ProposedOption: Show Visualization Plugins

    Public Sub RegisterFindNewPlugins()
        Dim FindNewPlugins As New DevExpress.CodeRush.Core.Action(components)
        CType(FindNewPlugins, System.ComponentModel.ISupportInitialize).BeginInit()
        FindNewPlugins.ActionName = "FindNewPlugins"
        FindNewPlugins.ButtonText = MenuCaption_Find_Plugins ' Used if button is placed on a menu.
        FindNewPlugins.RegisterInCR = True
        FindNewPlugins.CommonMenu = DevExpress.CodeRush.Menus.VsCommonBar.DevExpress
        AddHandler FindNewPlugins.Execute, AddressOf FindNewPlugins_Execute
        CType(FindNewPlugins, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub FindNewPlugins_Execute(ByVal ea As ExecuteEventArgs)
        ' Providers
        Dim LocalPluginProvider = New LocalPluginProvider(CodeRush.Options.Paths.CommunityPlugInsPath)
        Dim CommunityPluginProvider = New CommunityPluginProvider(LocalPluginProvider, CommunitySiteRootPluginUrl)
        Dim PluginDownloader = New PluginDownloader(LocalPluginProvider, CommunityPluginProvider)
        Dim RecommendedPlugins = FeedPluginProvider.GetFeedXML(CommunitySiteRootPluginUrl & "RecommendedPlugins.xml").GetPluginReferences

        ' Plugins
        Dim PluginsWithUpdates = Subtract(RecommendedPlugins, LocalPluginProvider.GetPluginReferences)

        Dim ChosenPlugins = PluginPicker.GetPlugins(PluginsWithUpdates, PickedVsUnPickedEnum.Picked)

        ' Action
        Dim UpdatedPlugins = PluginDownloader.DownloadPlugins(ChosenPlugins, AddressOf ShowMessage, True)
        Call ShowMessage(String.Format("{0} plugins chosen. {1} plugins downloaded.", ChosenPlugins.Count, UpdatedPlugins.Count))
        RestartDXCore(UpdatedPlugins.Count)
    End Sub

#End Region

    Private Sub PlugIn1_OptionsChanged(ea As DevExpress.CodeRush.Core.OptionsChangedEventArgs) Handles Me.OptionsChanged
        If ea.OptionsPages.Contains(GetType(Options1)) Then
            LoadSettings()
        End If
    End Sub
End Class
