Imports System.Text.RegularExpressions
Imports NUnit.Framework
Imports DX_PluginUpdater
Imports System.Security
Imports System.IO
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
<TestFixture()> _
Public Class NotReallyTests

    ' The tests in this file are not intended to be automated tests.
    ' They are more like bootstraped pieces of functionality that can be Started using a test runner

    Private Const mLocalPluginFolder As String = "C:\Users\Rory.Becker\Documents\DevExpress\IDE Tools\Community\PlugIns"
    <Test()> _
    Public Sub Install_AllCommunityPlugins_Test()
        Dim PluginDownloader As New PluginDownloader(mLocalPluginFolder)
        Dim CommunityPluginProvider As New CommunityPluginProvider

        Dim PluginNames = CommunityPluginProvider.GetPluginNames()
        For Each PluginName In PluginNames
            Dim Plugin = CommunityPluginProvider.GetLatestCommunityPluginReference(PluginName)
            PluginDownloader.DownloadAndInstallPlugin(Plugin)
        Next
    End Sub
End Class
