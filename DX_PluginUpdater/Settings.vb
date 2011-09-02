Public Class Settings
    Private mPlugins As String()
    Public Property Plugins() As String()
        Get
            Return mPlugins
        End Get
        Set(ByVal value As String())
            mPlugins = value
        End Set
    End Property

End Class
