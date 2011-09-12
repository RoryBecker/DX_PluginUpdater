Imports System.Linq
Public Interface IPluginProvider
    Function GetPluginNames() As IEnumerable(Of String)
    Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
    Function GetPluginReference(ByVal PluginName As String) As RemotePluginRef
End Interface
