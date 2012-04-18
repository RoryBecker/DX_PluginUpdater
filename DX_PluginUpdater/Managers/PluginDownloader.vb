Option Strict On
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Public Class PluginDownloader
#Region "Fields"
    Private ReadOnly mCommunityPluginProvider As CommunityPluginProvider
    Private ReadOnly mLocalPluginProvider As LocalPluginProvider
#End Region
    'Public Sub New(ByVal LocalPluginProvider As LocalPluginProvider)
    'End Sub

    Public Sub New(ByVal LocalPluginProvider As LocalPluginProvider, ByVal CommunityPluginProvider As CommunityPluginProvider)
        mCommunityPluginProvider = CommunityPluginProvider
        mLocalPluginProvider = LocalPluginProvider
    End Sub
    Public Function DownloadPlugins(ByVal Plugins As IEnumerable(Of RemotePluginRef), PostDownloadAction As Action(Of String), Optional ByVal ShowUpdatesOnly As Boolean = False) As List(Of RemotePluginRef)
        Dim UpdatedPlugins As New List(Of RemotePluginRef)
        For Each Plugin In Plugins
            Dim Result As Result = TryInstallPlugin(Plugin.PluginName, ShowUpdatesOnly)
            If PostDownloadAction IsNot Nothing Then
                PostDownloadAction.Invoke(Result.Message)
            End If
            If Result.Result Then
                UpdatedPlugins.Add(Plugin)
            End If
        Next
        Return UpdatedPlugins
    End Function


    Private Function TryInstallPlugin(ByVal PluginName As String, Optional ByVal ShowUpdatesOnly As Boolean = False, Optional ByVal Force As Boolean = False) As Result
        If PluginName = String.Empty Then
            Return New Result(False, String.Empty)
        End If
        Dim LocalPlugin As PluginRef = mLocalPluginProvider.GetPluginReference(PluginName)
        Dim Update As RemotePluginRef = mCommunityPluginProvider.GetRemoteReferenceLatestSpecific(PluginName)
        Select Case True
            Case Update Is Nothing
                Return New Result(False, String.Format("No versions of plugin {0} found on the community site.", PluginName))
            Case LocalPlugin Is Nothing
                Return DownloadAndInstallPlugin(Update)
            Case LocalPlugin.Version < Update.Version OrElse Force
                Return DownloadAndInstallPlugin(Update)
            Case LocalPlugin.Version >= Update.Version
                Return New Result(False, String.Format("Plugin {0} is already up to date.", Update.PluginName))
            Case Else
                Return New Result(False, String.Empty)
        End Select
    End Function

    Private Function DownloadAndInstallPlugin(ByVal Plugin As RemotePluginRef) As Result
        Dim WebManager As New WebManager()
        Dim FileBytes = WebManager.DownloadResource(Plugin.RemoteZipFileUrl)
        Using ToStreamVariable As Stream = ToStream(FileBytes)
            WebManager.Unzip(ToStreamVariable, mLocalPluginProvider.LocalPluginFolder)
        End Using
        Return New Result(True, String.Format("Downloaded and installed version {0} of plugin {1}", Plugin.Version, Plugin.PluginName))
    End Function
End Class