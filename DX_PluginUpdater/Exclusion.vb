Option Strict On
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports System.Net
Imports System.IO
Imports System.Linq

Public Class Exclusion
    Public Shared Function Exclusions() As List(Of String)
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
        "Xceed.Ftp"})

    End Function
End Class