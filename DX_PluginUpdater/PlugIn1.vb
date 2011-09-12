Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports DevExpress.CodeRush.PlugInCore
Imports DevExpress.CodeRush.StructuralParser

Public Class PlugIn1

	'DXCore-generated code...
#Region " InitializePlugIn "
	Public Overrides Sub InitializePlugIn()
		MyBase.InitializePlugIn()
        Call RegisterUpdatePluginsCommand()
        Call RegisterConfigurePluginUpdaterCommand()
    End Sub
#End Region
#Region " FinalizePlugIn "
    Public Overrides Sub FinalizePlugIn()
        'TODO: Add your finalization code here.

        MyBase.FinalizePlugIn()
    End Sub
#End Region
    Public Sub RegisterUpdatePluginsCommand()
        Dim UpdatePlugins As New DevExpress.CodeRush.Core.Action(components)
        CType(UpdatePlugins, System.ComponentModel.ISupportInitialize).BeginInit()
        UpdatePlugins.ActionName = "UpdatePlugins"
        UpdatePlugins.ButtonText = "Update Plugins..." ' Used if button is placed on a menu.
        UpdatePlugins.RegisterInCR = True
        AddHandler UpdatePlugins.Execute, AddressOf UpdatePlugins_Execute
        CType(UpdatePlugins, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub UpdatePlugins_Execute(ByVal ea As ExecuteEventArgs)
        Dim PluginDownloader = New PluginDownloader(CodeRush.Options.Paths.CommunityPlugInsPath)
        Call PluginDownloader.UpdatePlugins(Options1.LoadSettings(Options1.Storage).Plugins)
    End Sub
    Public Sub RegisterConfigurePluginUpdaterCommand()
        Dim ConfigurePluginUpdater As New DevExpress.CodeRush.Core.Action(components)
        CType(ConfigurePluginUpdater, System.ComponentModel.ISupportInitialize).BeginInit()
        ConfigurePluginUpdater.ActionName = "ConfigurePluginUpdater"
        ConfigurePluginUpdater.ButtonText = "Configure Plugin Updater" ' Used if button is placed on a menu.
        ConfigurePluginUpdater.RegisterInCR = True
        AddHandler ConfigurePluginUpdater.Execute, AddressOf ConfigurePluginUpdater_Execute
        CType(ConfigurePluginUpdater, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub ConfigurePluginUpdater_Execute(ByVal ea As ExecuteEventArgs)
        CodeRush.Options.Show("Community\Plugins\PluginUpdater")
    End Sub
End Class