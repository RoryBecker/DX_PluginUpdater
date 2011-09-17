Imports System.Linq
Imports System.Text.RegularExpressions

Public MustInherit Class BaseRemotePluginProvider
    Protected ReadOnly WebManager As New WebManager()
    Public Function GetPluginNames() As IEnumerable(Of String)
        Return From Plugin As RemotePluginRef In GetPluginReferences() _
            Select Plugin.PluginName
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
    Public MustOverride Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
    Public Const RemoteBasePluginFolder As String = "http://www.rorybecker.co.uk" & RootDownloadFolder
    Protected Const RootDownloadFolder As String = "/DevExpress/Plugins/Community/"
    Protected Function GetPluginFolderUrl(ByVal PluginName As String) As String
        Return String.Format("{0}{1}", RemoteBasePluginFolder, PluginName)
    End Function
    Private Const REGEX_SpecificPluginZipFile As String = "(?<Plugin>({0})_(?<Version>\d+)\.zip"">"
    Private Function ExtractZipReferences(ByVal Content As String, ByVal Regex As System.Text.RegularExpressions.Regex) As RemotePluginRef
        Dim LatestPlugin As RemotePluginRef = Nothing
        For Each Match In Regex.Matches(Content)
            Dim Plugin As RemotePluginRef = New RemotePluginRef(Match.Groups("Plugin").Value, GetPluginFolderUrl(Match.Groups("Plugin").Value), CInt(Match.Groups("Version").Value))
            If LatestPlugin Is Nothing OrElse Plugin.Version > LatestPlugin.Version Then
                LatestPlugin = Plugin
            End If
        Next
        Return LatestPlugin
    End Function
    Public Function GetPluginReference(ByVal PluginName As String) As RemotePluginRef
        Dim URL = GetPluginFolderUrl(PluginName)
        Dim Content As String = String.Empty
        If Not WebManager.ContentIsNot404(URL, Content) Then
            Return Nothing
        End If
        Return ExtractZipReferences(Content, GetSpecificPluginRegex(PluginName))
    End Function
    Private Shared Function GetSpecificPluginRegex(ByVal PluginName As String) As System.Text.RegularExpressions.Regex
        Return New System.Text.RegularExpressions.Regex(REGEX_SpecificPluginZipFile, RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    End Function

End Class
