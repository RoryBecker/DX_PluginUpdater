Option Strict On
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Public Class PluginDownloader
    Private ReadOnly mLocalPluginProvider As LocalPluginProvider
    Private ReadOnly WebManager As New WebManager()

    Private Const REGEX_SpecificPluginZipFile As String = "(?<Plugin>({0}))_(?<Version>\d+)\.zip"">"


    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginProvider = New LocalPluginProvider(LocalPluginFolder)
    End Sub

    Public Function UpdateLocalPlugins(Action As Action(Of String), Optional ByVal ShowUpdatesOnly As Boolean = False) As List(Of RemotePluginRef)
        Return UpdatePlugins(mLocalPluginProvider.GetPluginReferences, Action, ShowUpdatesOnly)
    End Function
    Public Function UpdatePlugins(ByVal Plugins As IEnumerable(Of RemotePluginRef), Action As Action(Of String), Optional ByVal ShowUpdatesOnly As Boolean = False) As List(Of RemotePluginRef)
        Dim UpdatedPlugins As New List(Of RemotePluginRef)
        For Each Plugin In Plugins
            Dim Result As Result = TryInstallPlugin(Plugin, ShowUpdatesOnly)
            Action.Invoke(Result.Message)
            If Result.Result Then
                UpdatedPlugins.Add(Plugin)
            End If
        Next
        Return UpdatedPlugins
    End Function

    Public Function TryInstallPlugin(ByVal RemotePlugin As RemotePluginRef, Optional ByVal ShowUpdatesOnly As Boolean = False, Optional ByVal Force As Boolean = False) As Result
        If RemotePlugin.PluginName = String.Empty Then
            Return New Result(False, String.Empty)
        End If
        Dim LocalPlugin As PluginRef = mLocalPluginProvider.GetPluginReference(RemotePlugin.PluginName)
        Dim Update As RemotePluginRef = GetReferenceToLatestVersion(RemotePlugin)
        Select Case True
            Case Update Is Nothing
                Return New Result(False, String.Format("No versions of plugin {0} found on the community site.", RemotePlugin.PluginName))
            Case LocalPlugin.Version < Update.Version OrElse Force
                Return DownloadAndInstallPlugin(Update)
            Case LocalPlugin.Version >= Update.Version
                Return New Result(False, String.Format("Plugin {0} is already up to date.", Update.PluginName))
            Case Else
                Return New Result(False, String.Empty)
        End Select
    End Function
    Public Function DownloadAndInstallPlugin(ByVal Plugin As RemotePluginRef) As Result
        Try
            Dim WebManager As New WebManager()
            Dim FileBytes = WebManager.DownloadResource(Plugin.RemoteZipFileUrl)
            Using ToStreamVariable As Stream = ToStream(FileBytes)
                WebManager.Unzip(ToStreamVariable, mLocalPluginProvider.LocalPluginFolder)
            End Using
        Catch ex As Exception
            Return New Result(False, ex.Message)
        End Try
        Return New Result(True, String.Format("Downloaded and installed version {0} of plugin {1}", Plugin.Version, Plugin.PluginName))
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
    Private Function GetSpecificPluginRegex(ByVal PluginName As String) As System.Text.RegularExpressions.Regex
        Return New System.Text.RegularExpressions.Regex(String.Format(REGEX_SpecificPluginZipFile, PluginName), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    End Function
End Class