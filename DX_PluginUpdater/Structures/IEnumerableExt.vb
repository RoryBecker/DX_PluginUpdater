Imports System.Linq

Public Module IEnumerableExt
#Region "Subtraction"
    Public Function Subtract(Of T As PluginRef)(ByVal Source As IEnumerable(Of RemotePluginRef), ByVal ToSubtract As IEnumerable(Of T)) As IEnumerable(Of RemotePluginRef)
        Return Subtract(Source, From Plugin In ToSubtract Select Plugin.PluginName)
    End Function
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
End Module
