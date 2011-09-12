Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Public Class PluginDownloader
    Dim mLocalPluginFolder As String = String.Empty
    Private mLocalPluginProvider As LocalPluginProvider
    Private mCommunityPluginProvider As New CommunityPluginProvider
    Private ReadOnly WebManager As New WebManager()
    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginProvider = New LocalPluginProvider(LocalPluginFolder)
    End Sub

    Public Function UpdatePlugins(ByVal PluginNames As String()) As String
        Dim ResultsBuilder = New StringBuilder()
        For Each PluginName In PluginNames
            ResultsBuilder.AppendLine(TryInstallPlugin(PluginName))
        Next
        Return ResultsBuilder.ToString()
    End Function
    Public Function TryInstallPlugin(ByVal PluginName As String, Optional ByVal ShowUpdatesOnly As Boolean = False, Optional ByVal Force As Boolean = False) As String
        PluginName = PluginName.Trim
        If PluginName = String.Empty Then
            Return String.Empty
        End If
        Dim LocalPlugin = mLocalPluginProvider.GetPluginReference(PluginName)
        Dim Update = mCommunityPluginProvider.GetPluginReference(PluginName)
        Select Case True
            Case Update Is Nothing
                If ShowUpdatesOnly Then
                    Return String.Empty
                End If
                Return String.Format("No versions of plugin {0} found on the community site.", PluginName)
            Case LocalPlugin Is Nothing OrElse LocalPlugin.Version < Update.Version OrElse Force
                Return DownloadAndInstallPlugin(PluginName)
            Case LocalPlugin.Version >= Update.Version
                If ShowUpdatesOnly Then
                    Return String.Empty
                End If
                Return String.Format("Plugin {0} is already up to date.", PluginName)
            Case Else
                Return String.Empty
        End Select
    End Function

    Public Function DownloadAndInstallPlugin(ByVal PluginName As String) As String
        Return DownloadAndInstallPlugin(mCommunityPluginProvider.GetPluginReference(PluginName))
    End Function
    Public Function DownloadAndInstallPlugin(ByVal Plugin As RemotePluginRef) As String
        Try
            Dim FileBytes = WebManager.DownloadResource(Plugin.RemoteZipFileUrl)
            Using ToStreamVariable As Stream = ToStream(FileBytes)
                WebManager.Unzip(ToStreamVariable, mLocalPluginFolder)
            End Using
        Catch ex As Exception
            Return ex.Message
        End Try
        Return String.Format("Downloaded and installed version {0} of plugin {1}", Plugin.Version, Plugin.PluginName)
    End Function
End Class