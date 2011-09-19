Imports System.Xml
Imports System.Xml.Linq
Public Class PluginRef
    Protected mPluginName As String
    Protected mVersion As Integer
    Public Sub New(ByVal PluginName As String, ByVal Version As Integer)
        mPluginName = PluginName
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
End Class