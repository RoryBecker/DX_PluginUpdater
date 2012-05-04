Imports System.Linq
Public Class PluginRef
    Protected mDescription As String
    Protected mPluginName As String
    Protected mVersion As Integer
    Public Sub New(ByVal PluginName As String, ByVal Version As Integer, Optional Description As String = "")
        mDescription = Description
        mPluginName = PluginName.Trim
        mVersion = Version
    End Sub
    Public ReadOnly Property PluginName() As String
        Get
            Return mPluginName
        End Get
    End Property
    Public ReadOnly Property Version() As Integer
        Get
            Return mVersion
        End Get
    End Property
    Public ReadOnly Property DllFilename() As String
        Get
            Return String.Format("{0}.dll", PluginName)
        End Get
    End Property
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property
End Class