Option Strict On
Imports System.Text.RegularExpressions
Imports System.Linq

Public Class CommunityPluginProvider
#Region "Fields"
    Private ReadOnly mRemoteBasePluginUrl As String
    Private ReadOnly WebManager As New WebManager()
    Private ReadOnly mLocalPluginProvider As LocalPluginProvider
#End Region
    Public Sub New(LocalPluginProvider As LocalPluginProvider, ByVal BasePluginUrl As String)
        mRemoteBasePluginUrl = BasePluginUrl
        mLocalPluginProvider = LocalPluginProvider
    End Sub


#Region "GetPluginReferences"
    Public Function GetRemoteReferencesLatestAll() As IEnumerable(Of RemotePluginRef)
        Dim Content = WebManager.GetUrlContentAsString(mRemoteBasePluginUrl)
        Dim REGEX_PluginZipFile As String = mRemoteBasePluginUrl & "(?<Folder>.+)/(?<Plugin>.+)_(?<Version>\d+)\.zip"
        Dim regex As Regex = New Regex(REGEX_PluginZipFile, RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        Dim Results As New List(Of RemotePluginRef)
        For Each Match As Match In regex.Matches(Content)
            Results.Add(New RemotePluginRef(Match.Groups("Plugin").Value,
                                            mRemoteBasePluginUrl & Match.Groups("Plugin").Value,
                                            CInt(Match.Groups("Version").Value)))
        Next
        Dim ExcludedPlugins = FeedPluginProvider.GetFeedXML(mRemoteBasePluginUrl & "ExcludePlugins.xml").GetPluginReferences
        Return Subtract(Results, ExcludedPlugins)

    End Function
    Public Function GetRemoteReferenceLatestSpecific(ByVal PluginName As String) As RemotePluginRef
        Dim RemoteFolderUrl As String = mRemoteBasePluginUrl & PluginName
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
