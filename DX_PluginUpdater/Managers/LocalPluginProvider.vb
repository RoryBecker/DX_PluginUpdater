Imports System.IO
Imports System.Linq
Imports DX_PluginUpdater.FileInfoExtensions

Public Class LocalPluginProvider
#Region "Fields"
    ReadOnly mLocalPluginFolder As String
#End Region
#Region "Construction"
    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginFolder = LocalPluginFolder
    End Sub
#End Region
#Region "Readonly Properties"
    Public ReadOnly Property LocalPluginFolder() As String
        Get
            Return mLocalPluginFolder
        End Get
    End Property
#End Region
    Public Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Dim Results As New List(Of RemotePluginRef)
        For Each TheFile As FileInfo In GetLocalPluginDlls()
            Dim BaseName As String = TheFile.NameWithoutExtension
            If Exclusions.List.Contains(BaseName) Then
                Continue For
            End If
            Dim PluginReference = GetPluginReference(BaseName)
            If PluginReference Is Nothing Then
                Continue For
            End If
            Results.Add(PluginReference)
        Next
        Return Results
    End Function
    Public Function GetPluginReference(ByVal PluginName As String) As RemotePluginRef
        Try
            Dim TheFile = New FileInfo(String.Format("{0}\{1}.dll", mLocalPluginFolder, PluginName))
            Return New RemotePluginRef(TheFile.NameWithoutExtension, CommunityPluginProvider.RemoteBasePluginFolder & TheFile.NameWithoutExtension, GetLocalPluginRevision(TheFile))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function PluginExists(ByVal Plugin As RemotePluginRef) As Boolean
        Return New DirectoryInfo(mLocalPluginFolder).GetFiles(Plugin.DllFilename).Count > 0
    End Function
    Private Function GetLocalPluginDlls() As FileInfo()
        Return New DirectoryInfo(mLocalPluginFolder).GetFiles("*.dll").Cast(Of FileInfo)()
    End Function

    Private Function GetLocalPluginRevision(ByVal PluginFile As FileInfo) As Integer
        Return FileVersionInfo.GetVersionInfo(PluginFile.FullName).ProductPrivatePart
    End Function

End Class