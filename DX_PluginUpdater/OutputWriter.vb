Imports DevExpress.CodeRush.Core

Public Class OutputWriter
    Private OutputPane As EnvDTE.OutputWindowPane
#Region "Construction"
    Public Sub New(ByVal WindowName As String)
        InitializeVSPaneIfNeeded(WindowName)
    End Sub
#End Region
#Region "Initialisation"
    Private Sub InitializeVSPaneIfNeeded(ByVal WindowName As String)
        If OutputPane IsNot Nothing Then
            Return
        End If
        Dim wnd As EnvDTE.Window = CodeRush.ApplicationObject.Windows.Item(EnvDTE.Constants.vsWindowKindOutput)
        If wnd Is Nothing Then
            Return
        End If
        Dim Window As EnvDTE.OutputWindow = TryCast(wnd.[Object], EnvDTE.OutputWindow)
        If Window Is Nothing Then
            Return
        End If
        Try
            OutputPane = Window.OutputWindowPanes.Item(WindowName)
        Catch
            OutputPane = Window.OutputWindowPanes.Add(WindowName)
        End Try
    End Sub
#End Region

    Public Sub Clear()
        If OutputPane Is Nothing Then
            Return
        End If
        OutputPane.Clear()
    End Sub


    Public Sub Writeline(text As String)
        InitializeVSPaneIfNeeded("CR_WriteToOutput")
        If OutputPane Is Nothing OrElse String.IsNullOrEmpty(text) Then
            Return
        End If
        '_DxCoreTestPane.Activate();
        OutputPane.OutputString(text & Environment.NewLine)
    End Sub
End Class
