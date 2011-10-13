Option Strict On
Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports DevExpress.CodeRush.Core

Public Class CommunityPluginProvider
    Inherits BaseRemotePluginProvider
#Region "Fields"
    Private Const RootDownloadFolder As String = "/DevExpress/Community/Plugins/"
    Public Const RemoteBasePluginFolder As String = "http://www.rorybecker.co.uk" & RootDownloadFolder
    Private Const REGEX_SpecificPluginZipFile As String = "(?<Plugin>({0}))_(?<Version>\d+)\.zip"">"
    Private Const REGEX_PluginZipFile As String = "(?<Plugin>(\w|-|_)+)_(?<Version>\d+)\.zip"">"
#End Region
    Private PluginDownloader As New PluginDownloader(CodeRush.Options.Paths.CommunityPlugInsPath)
    Private Function GetRootFolderMatches() As MatchCollection
        Dim Content = WebManager.GetUrlContentAsString(RemoteBasePluginFolder)
        Dim regex As Regex = New Regex(String.Format("<A HREF=""{0}(?<Plugin>(\w|-|_)+)/"">", RootDownloadFolder), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        Return regex.Matches(Content)
    End Function
    Private Function GetPluginCommunityFolderUrl(ByVal PluginName As String) As String
        Return String.Format("{0}{1}", RemoteBasePluginFolder, PluginName)
    End Function

    Private Function GetSpecificPluginRegex(ByVal PluginName As String) As System.Text.RegularExpressions.Regex
        Return New System.Text.RegularExpressions.Regex(String.Format(REGEX_SpecificPluginZipFile, PluginName), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    End Function
#Region "GetPluginReferences"
    Public Overrides Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        For Each Match As Match In GetRootFolderMatches()
            Dim PluginName As String = Match.Groups("Plugin").Value
            Dim Plugin As RemotePluginRef = GetLatestCommunityPluginReference(PluginName)
            If Plugin IsNot Nothing Then
                Plugins.Add(Plugin)
            End If
        Next
        Return Plugins
    End Function
    Public Function GetPluginReferencesQuick() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)()
        For Each Match As Match In GetRootFolderMatches()
            Dim PluginName = Match.Groups("Plugin").Value
            Plugins.Add(New RemotePluginRef(PluginName, RemoteBasePluginFolder & PluginName))
        Next
        Return Plugins
    End Function
    Public Function GetLatestCommunityPluginReference(ByVal PluginName As String) As RemotePluginRef
        Return PluginDownloader.GetReferenceToLatestVersion(PluginName, Me.GetPluginCommunityFolderUrl(PluginName))
    End Function
#End Region
    Public Function GetPluginNames() As IEnumerable(Of String)
        Return From Plugin As RemotePluginRef In GetPluginReferences() _
            Select Plugin.PluginName
    End Function

End Class
