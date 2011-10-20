Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Public Class PluginDownloader
    Private ReadOnly mLocalPluginProvider As LocalPluginProvider
    Private WebManager As New WebManager
    Private Const REGEX_SpecificPluginZipFile As String = "(?<Plugin>({0}))_(?<Version>\d+)\.zip"">"


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
        Dim Update As RemotePluginRef = GetReferenceToLatestVersion(RemotePlugin)
        Select Case True
            Case Update Is Nothing
                If ShowUpdatesOnly Then
                    Return String.Empty
                End If
                Return String.Format("No versions of plugin {0} found on the community site.", Update.PluginName)
            Case LocalPlugin Is Nothing OrElse LocalPlugin.Version < Update.Version OrElse Force
                Return DownloadAndInstallPlugin(Update)
            Case LocalPlugin.Version >= Update.Version
                If ShowUpdatesOnly Then
                    Return String.Empty
                End If
                Return String.Format("Plugin {0} is already up to date.", Update.PluginName)
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
    Private Function GetSpecificPluginRegex(ByVal PluginName As String) As System.Text.RegularExpressions.Regex
        Return New System.Text.RegularExpressions.Regex(String.Format(REGEX_SpecificPluginZipFile, PluginName), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    End Function
    Public Function GetReferenceToLatestVersion(ByVal RemotePlugin As RemotePluginRef) As RemotePluginRef
        Return GetReferenceToLatestVersion(RemotePlugin.PluginName, RemotePlugin.RemoteFolderUrl)
    End Function
    Public Function GetReferenceToLatestVersion(ByVal PluginName As String, ByVal RemoteFolderUrl As String) As RemotePluginRef
        Dim Source As String = String.Empty
        If WebManager.ContentIs404(RemoteFolderUrl, Source) Then
            Return Nothing
        End If
        Dim Results = GetSpecificPluginRegex(PluginName).Matches(Source)
        Dim LatestPlugin As RemotePluginRef = Nothing
        For Each Match As Match In Results
            Dim Plugin As RemotePluginRef = New RemotePluginRef(PluginName, RemoteFolderUrl, CInt(Match.Groups("Version").Value))
            If LatestPlugin Is Nothing OrElse Plugin.Version > LatestPlugin.Version Then
                LatestPlugin = Plugin
            End If
        Next
        Return LatestPlugin
    End Function
End Class