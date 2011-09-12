Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Collections.Generic
Public Class CommunityPluginProvider
    Public Const RemoteBasePluginFolder As String = "http://www.rorybecker.co.uk/DevExpress/Plugins/Community/"
    Private ReadOnly WebManager As New WebManager()

    Public Function GetPluginNames() As IEnumerable(Of String)
        Dim Plugins As New List(Of String)

        Dim Content = WebManager.GetUrlContentAsString(RemoteBasePluginFolder)
        Dim regex As Regex = New Regex("<A HREF=""/DevExpress/Plugins/Community/(?<Plugin>(\w|-|_)+)/"">", _
                                        RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        For Each Match In regex.Matches(Content)
            Plugins.Add(Match.Groups("Plugin").Value)
        Next
        Return Plugins
    End Function
    Public Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        Dim Content = WebManager.GetUrlContentAsString(RemoteBasePluginFolder)
        Dim regex As Regex = New Regex("<A HREF=""/DevExpress/Plugins/Community/(?<Plugin>(\w|-|_)+)/"">", _
                                        RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        For Each Match In regex.Matches(Content)
            Dim Plugin As RemotePluginRef = GetPluginReference(Match.Groups("Plugin").Value)
            If Plugin IsNot Nothing Then
                Plugins.Add(Plugin)
            End If
        Next
        Return Plugins
    End Function
    Public Function GetPluginReferences(ByVal LocalPlugins As IEnumerable(Of PluginRef)) As IEnumerable(Of RemotePluginRef)
        Dim Results As New List(Of RemotePluginRef)
        For Each PluginRef As PluginRef In LocalPlugins
            Dim RemoteReference = GetPluginReference(PluginRef.PluginName)
            If RemoteReference IsNot Nothing Then
                Results.Add(RemoteReference)
            End If
        Next
        Return Results
    End Function
    Public Function GetPluginReference(ByVal PluginName As String) As RemotePluginRef
        Dim URL = GetPluginFolderUrl(PluginName)
        Dim Content As String = String.Empty
        If Not WebManager.ContentIsNot404(URL, Content) Then
            Return Nothing
        End If
        Dim LatestPlugin As RemotePluginRef = Nothing
        Dim regex As Regex = New Regex("/(?<Plugin>(\w|-|_)+)_(?<Version>\d+)\.zip"">", _
                                  RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        For Each Match In regex.Matches(Content)
            Dim Plugin As RemotePluginRef = New RemotePluginRef(Match.Groups("Plugin").Value, _
                                                    GetPluginFolderUrl(Match.Groups("Plugin").Value), _
                                                    CInt(Match.Groups("Version").Value) _
                                                    )

            If LatestPlugin Is Nothing _
                OrElse Plugin.Version > LatestPlugin.Version Then
                LatestPlugin = Plugin
            End If
        Next
        Return LatestPlugin
    End Function
    Private Function GetPluginFolderUrl(ByVal PluginName As String) As String
        Return String.Format("{0}{1}", RemoteBasePluginFolder, PluginName)
    End Function
End Class
