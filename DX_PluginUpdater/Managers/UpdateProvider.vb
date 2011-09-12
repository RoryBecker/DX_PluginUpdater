Imports System.Linq

Public Class UpdateProvider
    Private mLocalPluginProvider As LocalPluginProvider
    Private mCommunityPluginProvider As New CommunityPluginProvider
    Public Sub New(ByVal LocalPluginFolder As String)
        mLocalPluginProvider = New LocalPluginProvider(LocalPluginFolder)
    End Sub
    Public Function GetLocalUpdates() As List(Of RemotePluginRef)
        Dim Plugins As New List(Of RemotePluginRef)
        For Each LocalPlugin In mLocalPluginProvider.GetPluginReferences()
            Dim LatestPluginRef = mCommunityPluginProvider.GetPluginReference(LocalPlugin.PluginName)
            If LatestPluginRef IsNot Nothing _
                AndAlso LatestPluginRef.Version > LocalPlugin.Version Then
                Plugins.Add(LatestPluginRef)
            End If
        Next
        Return Plugins
    End Function
    Public Function GetUpdatesForPlugins(ByVal Plugins As IEnumerable(Of String)) As List(Of RemotePluginRef)
        Dim Updates As New List(Of RemotePluginRef)
        For Each PluginBaseName In Plugins
            Dim LocalPluginReference As RemotePluginRef = mLocalPluginProvider.GetPluginReference(PluginBaseName)
            Dim LocalVersion = If(LocalPluginReference Is Nothing, -1, LocalPluginReference.Version)
            Dim LatestPluginRef = mCommunityPluginProvider.GetPluginReference(PluginBaseName)
            If LatestPluginRef IsNot Nothing AndAlso LatestPluginRef.Version > LocalVersion Then
                Updates.Add(LatestPluginRef)
            End If
        Next
        Return Updates
    End Function
End Class