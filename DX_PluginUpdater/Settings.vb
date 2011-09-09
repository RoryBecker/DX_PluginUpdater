Public Class Settings
#Region "Fields"
    Private mOnlyShowUpdates As Boolean
    Private mPlugins As String()
    Private mForceUpdates As Boolean
#End Region
#Region "Properties"
    Public Property Plugins() As String()
        Get
            Return mPlugins
        End Get
        Set(ByVal value As String())
            mPlugins = value
        End Set
    End Property

    Public Property OnlyShowUpdates As Boolean
        Get
            Return mOnlyShowUpdates
        End Get
        Set(ByVal Value As Boolean)
            mOnlyShowUpdates = Value
        End Set
    End Property
    Public Property ForceUpdates() As Boolean
        Get
            Return mForceUpdates
        End Get
        Set(ByVal value As Boolean)
            mForceUpdates = value
        End Set
    End Property
#End Region

End Class
