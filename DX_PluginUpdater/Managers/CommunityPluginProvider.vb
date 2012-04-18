Option Strict On
Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports DevExpress.CodeRush.Core

Public Class CommunityPluginProvider
#Region "Fields"
    Private Const RootDownloadFolder As String = "/DevExpress/Community/Plugins/"
    Private Const RemoteBasePluginAddress As String = "http://www.rorybecker.co.uk" & RootDownloadFolder
    Private Const RemoteLatestVersionsPage As String = "http://www.rorybecker.co.uk" & RootDownloadFolder & "LatestVersions/"
    Private ReadOnly WebManager As New WebManager()
    Private ReadOnly mLocalPluginProvider As LocalPluginProvider
#End Region
    Public Sub New(LocalPluginProvider As LocalPluginProvider)
        mLocalPluginProvider = LocalPluginProvider
    End Sub
#Region "GetPluginReferences"
    Public Function GetPluginReferencesNew() As IEnumerable(Of RemotePluginRef)
        Dim CommunityPlugins = GetRemoteReferencesLatestAll().ToList
        Dim LocalPlugins = mLocalPluginProvider.GetPluginReferences.ToList
        Dim Results As New List(Of RemotePluginRef)
        For Each Item In CommunityPlugins
            If Not LocalPlugins.Contains(Item) Then
                Results.Add(Item)
            End If
        Next
        Return Results
    End Function
    Public Function GetRemoteReferencesLatestOf(ByVal LocalPlugins As IEnumerable(Of PluginRef)) As IEnumerable(Of RemotePluginRef)
        Dim LocalPluginNames = From Plugin In LocalPlugins Select Plugin.PluginName
        Return From Reference In GetRemoteReferencesLatestAll()
               Where LocalPluginNames.Contains(Reference.PluginName)
    End Function
    Public Function GetRemoteReferencesLatestAll() As IEnumerable(Of RemotePluginRef)
        Dim Content = WebManager.GetUrlContentAsString(RemoteLatestVersionsPage)
        Dim REGEX_PluginZipFile As String = RemoteBasePluginAddress & "(?<Folder>.+)/(?<Plugin>.+)_(?<Version>\d+)\.zip"
        Dim regex As Regex = New Regex(REGEX_PluginZipFile, RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        Dim Results As New List(Of RemotePluginRef)
        For Each Match As Match In regex.Matches(Content)
            Results.Add(New RemotePluginRef(Match.Groups("Plugin").Value,
                                            RemoteBasePluginAddress & Match.Groups("Plugin").Value,
                                            CInt(Match.Groups("Version").Value)))
        Next
        Return Results
    End Function
    Public Function GetRemoteReferenceLatestSpecific(ByVal PluginName As String) As RemotePluginRef
        Dim RemoteFolderUrl As String = RemoteBasePluginAddress & PluginName
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
    Private Function GetSpecificPluginRegex(ByVal PluginName As String) As Regex
        Const REGEX_SpecificPluginZipFile As String = "(?<Plugin>({0}))_(?<Version>\d+)\.zip"">"
        Return New Regex(String.Format(REGEX_SpecificPluginZipFile, PluginName), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    End Function
#End Region
End Class
