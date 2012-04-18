Option Infer On
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports DevExpress.CodeRush.PlugInCore
Imports DevExpress.CodeRush.StructuralParser
Imports System.Text
Imports DevExpress.CodeRush.Menus
Imports System.Threading
Imports System.Linq

Public Class PlugIn1
    Private Const MenuCaption_Update_Plugins As String = "Update Plugins"
    Private Const MenuCaption_Find_Plugins As String = "Find New Plugins"

    'DXCore-generated code...
#Region " InitializePlugIn "
    Public Overrides Sub InitializePlugIn()
        MyBase.InitializePlugIn()
        Call RegisterUpdatePluginsCommand()
        Call CreateFindNewPlugins()
        AddHandler EventNexus.DXCoreLoaded, AddressOf EventNexus_DXCoreLoaded
    End Sub
#End Region
#Region " FinalizePlugIn "
    Public Overrides Sub FinalizePlugIn()
        'TODO: Add your finalization code here.
        RemoveHandler EventNexus.DXCoreLoaded, AddressOf EventNexus_DXCoreLoaded
        MyBase.FinalizePlugIn()
    End Sub
#End Region
#Region "Menu Functions"
    Public Sub SetMenuBeginGroupByCaption(Caption As String, BeginGroupValue As Boolean)
        'Dim Enumerator = CodeRush.Menus.DXCore.GetEnumerator
        'Do While Enumerator.MoveNext
        '    Enumerator.Current.BeginGroup = True
        'Loop
        'Do While Enumerator.MoveNext
        '    If Enumerator.Current.Caption = Caption Then
        '        Enumerator.Current.BeginGroup = BeginGroupValue
        '        Exit Do
        '    End If
        'Loop
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
#End Region

    Private Sub EventNexus_DXCoreLoaded(ByVal ea As DXCoreLoadedEventArgs)
        Call SetMenuPositionAfterByCaption(MenuCaption_Update_Plugins, "&New Plug-in...")
        Call SetMenuPositionAfterByCaption(MenuCaption_Find_Plugins, MenuCaption_Update_Plugins)
        'Call SetMenuBeginGroupByCaption(MenuCaption_Update_Plugins, False)
    End Sub

    Public Sub RegisterUpdatePluginsCommand()
        Dim UpdatePlugins As New DevExpress.CodeRush.Core.Action(components)
        CType(UpdatePlugins, System.ComponentModel.ISupportInitialize).BeginInit()
        UpdatePlugins.ActionName = "UpdatePlugins"
        UpdatePlugins.ButtonText = MenuCaption_Update_Plugins ' Used if button is placed on a menu.
        UpdatePlugins.RegisterInCR = True
        UpdatePlugins.CommonMenu = DevExpress.CodeRush.Menus.VsCommonBar.DevExpress
        AddHandler UpdatePlugins.Execute, AddressOf UpdatePlugins_Execute
        CType(UpdatePlugins, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub UpdatePlugins_Execute(ByVal ea As ExecuteEventArgs)
        ' Providers
        Dim LocalPluginProvider = New LocalPluginProvider(CodeRush.Options.Paths.CommunityPlugInsPath)
        Dim CommunityPluginProvider = New CommunityPluginProvider(LocalPluginProvider)
        Dim PluginDownloader = New PluginDownloader(LocalPluginProvider, CommunityPluginProvider)

        ' Plugins
        Dim LocalPlugins = LocalPluginProvider.GetPluginReferences
        Dim UnpickedPlugins = PluginPicker.GetPlugins(LocalPlugins, PickedVsUnPickedEnum.Unpicked)
        Dim PluginsToUpdate = LocalPlugins.Except(UnpickedPlugins)

        ' Action
        Dim UpdatedPlugins = PluginDownloader.DownloadPlugins(PluginsToUpdate, AddressOf ShowMessage, True)
        Call ShowMessage(String.Format("{0} plugins found. {1} plugins updated.", PluginsToUpdate.Count, UpdatedPlugins.Count))
    End Sub

    Public Sub ShowMessage(message As String)
        CodeRush.ApplicationObject.StatusBar.Text = message
    End Sub
    Public Sub CreateFindNewPlugins()
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
        Dim CommunityPluginProvider = New CommunityPluginProvider(LocalPluginProvider)
        Dim PluginDownloader = New PluginDownloader(LocalPluginProvider, CommunityPluginProvider)

        ' Plugins
        Dim CommunityPlugins = CommunityPluginProvider.GetPluginReferencesNew()
        Dim ChosenPlugins = PluginPicker.GetPlugins(CommunityPlugins, PickedVsUnPickedEnum.Picked)

        ' Action
        Dim UpdatedPlugins = PluginDownloader.DownloadPlugins(ChosenPlugins, AddressOf ShowMessage, True)
        Call ShowMessage(String.Format("{0} plugins chosen. {1} plugins downloaded.", ChosenPlugins.Count, UpdatedPlugins.Count))
    End Sub
End Class