Option Strict On
Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Collections.Generic
Imports System
Public Class CommunityPluginProvider
    Inherits BaseRemotePluginProvider
#Region "Fields"
    Private Const RootDownloadFolder As String = "/DevExpress/Community/Plugins/"
    Public Const RemoteBasePluginFolder As String = "http://www.rorybecker.co.uk" & RootDownloadFolder
    Private Const REGEX_SpecificPluginZipFile As String = "(?<Plugin>({0}))_(?<Version>\d+)\.zip"">"
    Private Const REGEX_PluginZipFile As String = "(?<Plugin>(\w|-|_)+)_(?<Version>\d+)\.zip"">"
#End Region

    Private Function GetRootFolderMatches() As MatchCollection
        Dim Content = WebManager.GetUrlContentAsString(RemoteBasePluginFolder)
        Dim regex As Regex = New Regex(String.Format("<A HREF=""{0}(?<Plugin>(\w|-|_)+)/"">", RootDownloadFolder), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        Return regex.Matches(Content)
    End Function
    Private Function GetPluginCommunityFolderUrl(ByVal PluginName As String) As String
        Return String.Format("{0}{1}", RemoteBasePluginFolder, PluginName)
    End Function
    Private Function ExtractZipReferences(ByVal Content As String, ByVal Regex As System.Text.RegularExpressions.Regex) As RemotePluginRef
        Dim LatestPlugin As RemotePluginRef = Nothing
        For Each Match As Match In Regex.Matches(Content)
            Dim Plugin As RemotePluginRef = New RemotePluginRef(Match.Groups("Plugin").Value, GetPluginCommunityFolderUrl(Match.Groups("Plugin").Value), CInt(Match.Groups("Version").Value))
            If LatestPlugin Is Nothing OrElse Plugin.Version > LatestPlugin.Version Then
                LatestPlugin = Plugin
            End If
        Next
        Return LatestPlugin
    End Function
    Private Function GetSpecificPluginRegex(ByVal PluginName As String) As System.Text.RegularExpressions.Regex
        Return New System.Text.RegularExpressions.Regex(String.Format(REGEX_SpecificPluginZipFile, PluginName), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    End Function
#Region "GetPluginReferences"
    Public Function GetPluginReference(ByVal PluginName As String) As RemotePluginRef
        Dim URL = GetPluginCommunityFolderUrl(PluginName)
        Dim Content As String = String.Empty
        If WebManager.ContentIs404(URL, Content) Then
            Return Nothing
        End If
        Return ExtractZipReferences(Content, GetSpecificPluginRegex(PluginName))
    End Function
    Public Overloads Function GetPluginReferences(ByVal LocalPlugins As IEnumerable(Of PluginRef)) As IEnumerable(Of RemotePluginRef)
        Dim Results As New List(Of RemotePluginRef)
        For Each PluginRef As PluginRef In LocalPlugins
            Dim RemoteReference = GetPluginReference(PluginRef.PluginName)
            If RemoteReference IsNot Nothing Then
                Results.Add(RemoteReference)
            End If
        Next
        Return Results
    End Function
    Public Overrides Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        For Each Match As Match In GetRootFolderMatches()
            Dim Plugin As RemotePluginRef = GetPluginReference(Match.Groups("Plugin").Value)
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
#End Region
    Public Function GetPluginNames() As IEnumerable(Of String)
        Return From Plugin As RemotePluginRef In GetPluginReferences() _
            Select Plugin.PluginName
    End Function

End Class
