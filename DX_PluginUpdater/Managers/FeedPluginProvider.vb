Imports System.Linq
Imports System.Collections.Generic
Imports System.Xml.Linq

Public Class FeedPluginProvider
    Private ReadOnly mWebManager As New WebManager()
    Private ReadOnly mFeedUrl As String
    Private mFeedXML As XElement
    Public Sub New(ByVal FeedUrl As String)
        mFeedUrl = FeedUrl
        Call RefreshFeedFromSource()
    End Sub
    Public Sub RefreshFeedFromSource()
        mFeedXML = GetFeedXML()
    End Sub
    Public Shared Function GetProvider(FeedUrl As String) As FeedPluginProvider
        Return New FeedPluginProvider(FeedUrl)
    End Function
    Public Function GetPluginReferences() As IEnumerable(Of RemotePluginRef)
        Return From Plugin In mFeedXML.<Plugins>.<Plugin>
               Select New RemotePluginRef(Plugin.@Name, Plugin.Parent.@BaseFolder & Plugin.@Name)
    End Function
    Public Function GetPluginReferencesWithCat(Category As String) As IEnumerable(Of RemotePluginRef)
        Return From Plugin In mFeedXML.<Plugins>.<Plugin>
               Where Plugin.@Categories.Split(",").ToList.Contains(Category)
               Select New RemotePluginRef(Plugin.@Name, Plugin.Parent.@BaseFolder & Plugin.@Name)
    End Function
    Private Function GetFeedXML() As XElement
        Dim Content As String = String.Empty
        If mWebManager.ContentIs404(mFeedUrl, Content) Then
            ' 404
            Return <Doc><Plugins/></Doc> ' Return no Plugins
            ' Should probably log this.
        End If
        Return XElement.Parse(Content)
    End Function
End Class
