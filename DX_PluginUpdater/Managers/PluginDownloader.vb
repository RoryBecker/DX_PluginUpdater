Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Public Class PluginDownloader
    Private ReadOnly mLocalPluginProvider As LocalPluginProvider
    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginProvider = New LocalPluginProvider(LocalPluginFolder)
    End Sub

    Public Function UpdatePlugins(ByVal Plugins As RemotePluginRef()) As String
        Dim ResultsBuilder = New StringBuilder()
        For Each Plugin In Plugins
            ResultsBuilder.AppendLine(TryInstallPlugin(Plugin))
        Next
        Return ResultsBuilder.ToString()
    End Function

    Public Function TryInstallPlugin(ByVal RemotePlugin As RemotePluginRef, Optional ByVal ShowUpdatesOnly As Boolean = False, Optional ByVal Force As Boolean = False) As String
        If RemotePlugin.PluginName = String.Empty Then
            Return String.Empty
        End If
        Dim LocalPlugin As PluginRef = mLocalPluginProvider.GetPluginReference(RemotePlugin.PluginName)
        Dim Update As RemotePluginRef = RemotePlugin
        Select Case True
            Case Update Is Nothing
                If ShowUpdatesOnly Then
                    Return String.Empty
                End If
                Return String.Format("No versions of plugin {0} found on the community site.", RemotePlugin.PluginName)
            Case LocalPlugin Is Nothing OrElse LocalPlugin.Version < Update.Version OrElse Force
                Return DownloadAndInstallPlugin(RemotePlugin)
            Case LocalPlugin.Version >= Update.Version
                If ShowUpdatesOnly Then
                    Return String.Empty
                End If
                Return String.Format("Plugin {0} is already up to date.", RemotePlugin.PluginName)
            Case Else
                Return String.Empty
        End Select
    End Function
    Public Function DownloadAndInstallPlugin(ByVal Plugin As RemotePluginRef) As String
        Try
            Dim WebManager As New WebManager()
            Dim FileBytes = WebManager.DownloadResource(Plugin.RemoteZipFileUrl)
            Using ToStreamVariable As Stream = ToStream(FileBytes)
                WebManager.Unzip(ToStreamVariable, mLocalPluginProvider.LocalPluginFolder)
            End Using
        Catch ex As Exception
            Return ex.Message
        End Try
        Return String.Format("Downloaded and installed version {0} of plugin {1}", Plugin.Version, Plugin.PluginName)
    End Function
End Class