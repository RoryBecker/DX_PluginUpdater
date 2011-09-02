Imports System.Text.RegularExpressions
Imports NUnit.Framework
Imports DX_PluginUpdater
<TestFixture()> _
Public Class FunctionalTests
    Private Const mLocalPluginFolder As String = "C:\Users\Rory.Becker\Documents\DevExpress\IDE Tools\Community\PlugIns"
    <Test()> _
    Public Sub UpdateSpecificPlugins_Test()
        Dim PluginManager As New PluginManager(mLocalPluginFolder)
        Dim PluginNames As List(Of String) = New List(Of String)(New String() {"CR_StyleNinja"})
        Dim Updates = PluginManager.GetUpdatesForPlugins(PluginNames)

        If Updates.Count > 0 AndAlso MsgBox(String.Format("{0} plugin updates are available", Updates.Count), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each Update As RemotePluginRef In Updates
                PluginManager.DownloadAndInstallPlugin(Update)
            Next
        End If
    End Sub

    <Test()> _
    Public Sub GetUpdatablePlugins_Test()
        Dim PluginManager As New PluginManager(mLocalPluginFolder)
        Dim UpdatablePlugins = PluginManager.GetLocalUpdates()
        For Each Plugin In UpdatablePlugins
            PluginManager.DownloadAndInstallPlugin(Plugin)
        Next
    End Sub
    <Test()> _
    Public Sub GetAllCommunityPlugins_Test()
        Dim PluginManager As New PluginManager(mLocalPluginFolder)
        Dim PluginNames = PluginManager.GetCommunityPluginNames()
        For Each PluginName In PluginNames
            Dim Plugin = PluginManager.GetLatestVersionOfPlugin(PluginName)
            PluginManager.DownloadAndInstallPlugin(Plugin)
        Next
    End Sub
    <Test()> _
    Public Sub RemoveExtension_Test()
        Assert.AreEqual("Fred", New System.IO.FileInfo("Fred.Extension").NameWithoutExtension)
    End Sub

End Class
