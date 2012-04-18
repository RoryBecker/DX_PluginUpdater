Option Strict On
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
    Public Function GetPluginReferences() As IEnumerable(Of PluginRef)
        Dim Results As New List(Of PluginRef)
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
            'Return New RemotePluginRef(TheFile.NameWithoutExtension, CommunityPluginProvider.RemoteBasePluginFolder & TheFile.NameWithoutExtension, GetLocalPluginRevision(TheFile))
            Return New PluginRef(TheFile.NameWithoutExtension, GetLocalPluginRevision(TheFile))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetLocalPluginDlls() As FileInfo()
        Dim LocalPluginFolder = New DirectoryInfo(mLocalPluginFolder)
        Return LocalPluginFolder.GetFiles("*.dll")
    End Function

    Private Function GetLocalPluginRevision(ByVal PluginFile As FileInfo) As Integer
        Return FileVersionInfo.GetVersionInfo(PluginFile.FullName).ProductPrivatePart
    End Function

End Class