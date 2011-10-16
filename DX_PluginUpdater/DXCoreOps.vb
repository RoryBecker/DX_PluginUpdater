Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports DevExpress.CodeRush.PlugInCore
Imports DevExpress.CodeRush.StructuralParser
Imports DXCoreEngine = DevExpress.CodeRush.Core.CodeRush
Imports Extensibility
Imports System.Threading
Imports EnvDTE

Public Class DXCoreOps
    Private Shared DTE As EnvDTE.DTE
    Public Sub RestartDXCore()
        Dim context As SynchronizationContext = SynchronizationContext.Current
        If Not context Is Nothing Then

            context.Post(AddressOf UnloadCallback, Nothing)
            DTE = CodeRush.ApplicationObject
            context.Post(AddressOf LoadCallback, Nothing)
        End If
    End Sub
#Region "UnloadCallback"
    Sub UnloadCallback(ByVal state As Object)
        If (DXCoreEngine.LoaderEngine IsNot Nothing) Then
            DXCoreEngine.LoaderEngine.UnloadCore(ext_DisconnectMode.ext_dm_UserClosed)
        End If
    End Sub
#End Region
    Sub LoadCallback(ByVal state As Object)
        If (DTE Is Nothing) Then
            Return
        End If
        DTE.ExecuteCommand("Tools.LoadDXCore")
        DTE = Nothing
    End Sub
End Class
