Option Strict On
Imports System.Linq

Public Class Exclusions
    Public Shared Function List() As List(Of String)
        Return New List(Of String)(New String() { _
        "DevExpress.CodeRush.Controls.Design", _
        "DevExpress.DXCore.Controls.XtraEditors.v6.3.Design", _
        "DevExpress.DXCore.Controls.XtraGrid.v6.3.Design", _
        "DevExpress.DXCore.Controls.XtraLayout.v6.3.Design", _
        "Ninject", _
        "nunit.framework", _
        "Xceed.Compression", _
        "Xceed.Compression.Formats", _
        "Xceed.FileSystem", _
        "Xceed.Ftp", _
        "Ionic.Zip.Reduced"})

    End Function
End Class