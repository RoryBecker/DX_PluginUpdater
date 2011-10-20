Option Strict On
Option Infer On
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports System.Net
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices

Public Module IEnumerableExtensions
    <Extension()> _
    Public Function UnionWith(Of T)(ByVal Source As IEnumerable(Of T), ByVal [With] As IEnumerable(Of T)) As IEnumerable(Of T)
        Dim Result As New List(Of T)
        Result.AddRange(Source)
        For Each Item In [With]
            If Not Result.Contains(Item) Then
                Result.Add(Item)
            End If
        Next
        Return Result
    End Function
    <Extension()> _
    Public Function ExceptFor(Of T)(ByVal Source As IEnumerable(Of T), ByVal [Except] As IEnumerable(Of T)) As IEnumerable(Of T)
        Dim Result As New List(Of T)
        Result.AddRange(Source)
        For Each Item In [Except]
            If Result.Contains(Item) Then
                Result.Remove(Item)
            End If
        Next
        Return Result
    End Function
End Module
