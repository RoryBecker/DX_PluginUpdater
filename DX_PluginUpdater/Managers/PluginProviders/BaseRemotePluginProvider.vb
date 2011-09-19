Imports System.Linq
Imports System.Text.RegularExpressions

Public MustInherit Class BaseRemotePluginProvider
    Public MustOverride Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
    Protected ReadOnly WebManager As New WebManager()

End Class
