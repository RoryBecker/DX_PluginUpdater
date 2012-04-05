Option Strict On
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text

Public Class Result
    ReadOnly mMessage As String
    ReadOnly mResult As Boolean
    Public Sub New(ByVal Result As Boolean, ByVal Message As String)
        mMessage = Message
        mResult = Result

    End Sub
    Public ReadOnly Property Result() As Boolean
        Get
            Return mResult
        End Get
    End Property
    Public ReadOnly Property Message() As String
        Get
            Return mMessage
        End Get
    End Property
End Class
