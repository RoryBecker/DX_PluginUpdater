Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text

Public Class PluginManager
#Region "Fields"
    ReadOnly mLocalPluginFolder As String
    Private Const mRemoteBasePluginFolder As String = "http://www.rorybecker.co.uk/DevExpress/Plugins/Community"
    Private ReadOnly WebManager As New WebManager()
#End Region
#Region "Construction"
    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginFolder = LocalPluginFolder
    End Sub
#End Region

#Region "Get Names"
    Public Function GetCommunityPluginNames() As IEnumerable(Of String)
        Dim Plugins As New List(Of String)

        Dim Content = WebManager.GetUrlContentAsString(mRemoteBasePluginFolder)
        Dim regex As Regex = New Regex("<A HREF=""/DevExpress/Plugins/Community/(?<Plugin>(\w|-|_)+)/"">", _
                                        RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        For Each Match In regex.Matches(Content)
            Plugins.Add(Match.Groups("Plugin").Value)
        Next
        Return Plugins
    End Function
    Public Function GetLocalPluginNames() As IEnumerable(Of String)
        Return From file In New DirectoryInfo(mLocalPluginFolder).GetFiles("*.dll").Cast(Of FileInfo)()
               Select file.Name.Substring(0, file.Name.Length - 4)
    End Function
#End Region
#Region "Get Plugin References"
    Public Function GetCommunityPluginReferences() As IEnumerable(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        Dim Content = WebManager.GetUrlContentAsString(mRemoteBasePluginFolder)
        Dim regex As Regex = New Regex("<A HREF=""/DevExpress/Plugins/Community/(?<Plugin>(\w|-|_)+)/"">", _
                                        RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        For Each Match In regex.Matches(Content)
            Dim Plugin As RemotePluginRef = GetLatestRemoteVersionOfPlugin(Match.Groups("Plugin").Value)
            If Plugin IsNot Nothing Then
                Plugins.Add(Plugin)
            End If
        Next
        Return Plugins
    End Function
    Public Function GetLocalPluginReference(ByVal PluginName As String) As PluginRef
        Try
            Dim TheFile = New FileInfo(String.Format("{0}\{1}.dll", mLocalPluginFolder, PluginName))
            Return New PluginRef(TheFile.NameWithoutExtension, GetLocalPluginRevision(TheFile))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetLocalPluginReferences() As IEnumerable(Of PluginRef)
        Return From TheFile In GetLocalPluginDlls() _
               Where Not Exclusions.List.Contains(TheFile.NameWithoutExtension) _
               Select New PluginRef(TheFile.NameWithoutExtension, _
                                    GetLocalPluginVersion(TheFile.NameWithoutExtension))
    End Function
#End Region
#Region "Get Local"
    Public Function GetLocalUpdates() As List(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        For Each LocalPlugin In GetLocalPluginReferences()
            Dim LatestPluginRef = GetLatestRemoteVersionOfPlugin(LocalPlugin.BaseName)
            If LatestPluginRef IsNot Nothing _
                AndAlso LatestPluginRef.Version > LocalPlugin.Version Then
                Plugins.Add(LatestPluginRef)
            End If
        Next
        Return Plugins
    End Function
    Private Function GetLocalPluginDlls() As FileInfo()
        Return New DirectoryInfo(mLocalPluginFolder).GetFiles("*.dll").Cast(Of FileInfo)()
    End Function

    Private Function MethodName(ByVal File As FileInfo) As Boolean
        Return File.Exists
    End Function
    Private Function GetLocalPluginVersion(ByVal PluginBaseName As String) As Integer
        Dim File As FileInfo = New FileInfo(String.Format("{0}\{1}.dll", mLocalPluginFolder, PluginBaseName))
        If Not File.Exists() Then
            Return 0
        End If
        Return GetLocalPluginRevision(File)
    End Function
    Private Function GetLocalPluginRevision(ByVal PluginFile As FileInfo) As Integer
        Return FileVersionInfo.GetVersionInfo(PluginFile.FullName).ProductPrivatePart
    End Function
#End Region
#Region "GetUpdates"
    Public Function GetUpdatesForPlugins(ByVal Plugins As IEnumerable(Of String)) As List(Of RemotePluginRef)
        Dim Updates As New List(Of RemotePluginRef)
        For Each PluginBaseName In Plugins
            Dim LocalVersion = GetLocalPluginVersion(PluginBaseName)
            Dim LatestPluginRef = GetLatestRemoteVersionOfPlugin(PluginBaseName)
            If LatestPluginRef IsNot Nothing AndAlso LatestPluginRef.Version > LocalVersion Then
                Updates.Add(LatestPluginRef)
            End If
        Next
        Return Updates
    End Function
#End Region
#Region "Utils"
    'Public Function PluginUpdateExists(ByVal PluginName As String) As Boolean
    '    Dim LocalVersion = GetLocalPluginVersion(PluginName)
    '    Return PluginUpdateExists(PluginName, LocalVersion)
    'End Function

    'Public Function PluginUpdateExists(ByVal PluginName As String, ByVal LocalVersion As Integer) As Boolean
    '    Dim Updates As List(Of RemotePluginRef) = GetUpdatesForPlugins(New String() {PluginName})
    '    If Updates.Count = 0 Then
    '        Return False
    '    End If
    '    If Updates(0).Version <= LocalVersion Then
    '        Return False
    '    End If
    '    Return True
    'End Function
    Public Function GetLatestRemoteVersionOfPlugin(ByVal PluginName As String) As RemotePluginRef
        Dim URL = GetPluginFolderUrl(PluginName)
        Dim Content = WebManager.GetUrlContentAsString(URL)
        If Content.Contains("Oops") Then
            Return Nothing
        End If
        Dim LatestPlugin As RemotePluginRef = Nothing
        Dim regex As Regex = New Regex("/(?<Plugin>(\w|-|_)+)_(?<Version>\d+)\.zip"">", _
                                  RegexOptions.CultureInvariant Or RegexOptions.Compiled)
        For Each Match In regex.Matches(Content)
            Dim Plugin As RemotePluginRef = New RemotePluginRef(Match.Groups("Plugin").Value, _
                                                    CInt(Match.Groups("Version").Value), _
                                                    GetPluginFolderUrl(Match.Groups("Plugin").Value))

            If LatestPlugin Is Nothing _
                OrElse Plugin.Version > LatestPlugin.Version Then
                LatestPlugin = Plugin
            End If
        Next
        Return LatestPlugin
    End Function

#End Region



#Region "Download"
    Public Function DownloadAndInstallPlugin(ByVal PluginName As String) As String
        Return DownloadAndInstallPlugin(GetLatestRemoteVersionOfPlugin(PluginName))
    End Function
    Public Function DownloadAndInstallPlugin(ByVal Plugin As RemotePluginRef) As String
        Try
            Dim FileBytes = WebManager.DownloadResource(Plugin.RemoteZipFileUrl)
            Using ToStreamVariable As Stream = ToStream(FileBytes)
                WebManager.Unzip(ToStreamVariable, mLocalPluginFolder)
            End Using
        Catch ex As Exception
            Return ex.Message
        End Try
        Return String.Format("Downloaded and installed version {0} of plugin {1}", Plugin.Version, Plugin.BaseName)
    End Function
    Public Function TryInstallPlugin(ByVal PluginName As String, Optional ByVal ShowUpdatesOnly As Boolean = False) As String
        PluginName = PluginName.Trim
        If PluginName = String.Empty Then
            Return String.Empty
        End If
        Dim LocalPlugin = GetLocalPluginReference(PluginName)
        Dim Update = GetLatestRemoteVersionOfPlugin(PluginName)
        Select Case True
            Case Update Is Nothing
                If Not ShowUpdatesOnly Then
                    Return String.Format("No versions of plugin {0} found on the community site.", PluginName)
                End If
            Case LocalPlugin Is Nothing OrElse LocalPlugin.Version < Update.Version
                Return DownloadAndInstallPlugin(PluginName)
            Case LocalPlugin.Version >= Update.Version
                If Not ShowUpdatesOnly Then
                    Return String.Format("Plugin {0} is already up to date.", PluginName)
                End If
            Case Else
                Return String.Empty
        End Select
    End Function
#End Region
    Private Function GetPluginFolderUrl(ByVal PluginName As String) As String
        Return String.Format("{0}/{1}", mRemoteBasePluginFolder, PluginName)
    End Function
    Public Function UpdatePlugins(ByVal PluginNames As String()) As String
        Dim ResultsBuilder = New StringBuilder()
        For Each PluginName In PluginNames
            ResultsBuilder.AppendLine(TryInstallPlugin(PluginName))
        Next
        Return ResultsBuilder.ToString()
    End Function

End Class