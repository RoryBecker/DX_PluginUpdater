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
        If WebManager.ContentIsNot404(mFeedUrl, Content) Then
            Return Nothing ' 404
        End If
        Return XElement.Parse(Content)
    End Function
    Public Overrides Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Return From Plugin In GetFeedXML().<Plugins>.<Plugin>
               Select New RemotePluginRef(Plugin.@Name, Plugin.Parent.@BaseFolder)
    End Function

    Public Function GetPluginReferencesQuick() As IEnumerable(Of RemotePluginRef)

    End Function
End Class
