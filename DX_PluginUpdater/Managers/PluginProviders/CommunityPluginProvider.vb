Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Collections.Generic
Imports System
Public Class CommunityPluginProvider
    Inherits BaseRemotePluginProvider


    Private Const REGEX_PluginZipFile As String = "(?<Plugin>(\w|-|_)+)_(?<Version>\d+)\.zip"">"

    Private Function GetRootFolderMatches() As MatchCollection
        Dim Content = WebManager.GetUrlContentAsString(RemoteBasePluginFolder)
        Dim regex As Regex = New Regex(String.Format("<A HREF=""{0}(?<Plugin>(\w|-|_)+)/"">", RootDownloadFolder), RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        Return From match In regex.Matches(Content)
    End Function

    Public Function GetPluginReferencesQuick() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)()
        For Each Match In GetRootFolderMatches()
            Dim PluginName = Match.Groups("Plugin").Value
            Plugins.Add(New RemotePluginRef(PluginName, RemoteBasePluginFolder & PluginName))
        Next
        Return Plugins
    End Function
    Public Overrides Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        For Each Match In GetRootFolderMatches()
            Dim Plugin As RemotePluginRef = GetPluginReference(Match.Groups("Plugin").Value)
            If Plugin IsNot Nothing Then
                Plugins.Add(Plugin)
            End If
        Next
        Return Plugins
    End Function
End Class
