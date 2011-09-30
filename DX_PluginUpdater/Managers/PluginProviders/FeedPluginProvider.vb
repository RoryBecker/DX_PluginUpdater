Imports System.Linq
Imports System.Collections.Generic
Imports System.Xml.Linq

Public Class FeedPluginProvider
    Inherits BaseRemotePluginProvider
    ReadOnly mFeedUrl As String
    Public Sub New(ByVal FeedUrl As String)
        mFeedUrl = FeedUrl
    End Sub
    Private Function GetFeedXML() As XElement
        Dim Content As String = String.Empty
        If WebManager.ContentIs404(mFeedUrl, Content) Then
            ' 404
            Return <Doc><Plugins/></Doc> ' Return no Plugins
            ' Should probably log this.
        End If
        Return XElement.Parse(Content)
    End Function
    Public Overrides Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Return From Plugin In GetFeedXML().<Plugins>.<Plugin>
               Select New RemotePluginRef(Plugin.@Name, Plugin.Parent.@BaseFolder & Plugin.@Name)
    End Function

    Public Function GetPluginReferencesQuick() As IEnumerable(Of RemotePluginRef)
        Return GetPluginReferences()
    End Function
End Class
