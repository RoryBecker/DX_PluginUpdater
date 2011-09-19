Imports System.IO
Imports System.Linq
Imports DX_PluginUpdater.FileInfoExtensions

Public Class LocalPluginProvider
    ReadOnly mLocalPluginFolder As String
    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginFolder = LocalPluginFolder
    End Sub
    Public Function GetPluginNames() As IEnumerable(Of String)
        Return From file In New DirectoryInfo(mLocalPluginFolder).GetFiles("*.dll").Cast(Of FileInfo)()
               Select file.Name.Substring(0, file.Name.Length - 4)
    End Function
    Public Function GetPluginReferences() As IEnumerable(Of PluginRef) 
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
    Public Function GetPluginReference(ByVal PluginName As String) As PluginRef
        Try
            Dim TheFile = New FileInfo(String.Format("{0}\{1}.dll", mLocalPluginFolder, PluginName))
            Return New RemotePluginRef(TheFile.NameWithoutExtension, "", GetLocalPluginRevision(TheFile))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetLocalPluginDlls() As FileInfo()
        Return New DirectoryInfo(mLocalPluginFolder).GetFiles("*.dll").Cast(Of FileInfo)()
    End Function

    Private Function GetLocalPluginRevision(ByVal PluginFile As FileInfo) As Integer
        Return FileVersionInfo.GetVersionInfo(PluginFile.FullName).ProductPrivatePart
    End Function

End Class