Imports System.Linq
Imports System.Runtime.CompilerServices

Public Module IEnumerableExt
#Region "Subtraction"
    <Extension()> _
    Public Function Subtract(Of T As PluginRef)(ByVal Source As IEnumerable(Of RemotePluginRef), ByVal ToSubtract As IEnumerable(Of T)) As IEnumerable(Of RemotePluginRef)
        Return Subtract(Source, From Plugin In ToSubtract Select Plugin.PluginName)
    End Function
    <Extension()> _
    Public Function Subtract(ByVal Source As IEnumerable(Of RemotePluginRef), ByVal ToSubtractNames As IEnumerable(Of String)) As IEnumerable(Of RemotePluginRef)
        Dim Results As New List(Of RemotePluginRef)
        For Each Item In Source
            If Not ToSubtractNames.Contains(Item.PluginName) Then
                Results.Add(Item)
            End If
        Next
        Return Results
    End Function
#End Region
    <Extension()> _
    Public Function Intersection(Of T As PluginRef)(ByVal Source As IEnumerable(Of T), ByVal CommunityPlugins As IEnumerable(Of RemotePluginRef)) As IEnumerable(Of RemotePluginRef)
        Dim PickedPluginNames = From Plugin In Source _
                                Select Plugin.PluginName
        Return From RemotePlugin In CommunityPlugins _
               Where PickedPluginNames.Contains(RemotePlugin.PluginName)
    End Function
End Module
