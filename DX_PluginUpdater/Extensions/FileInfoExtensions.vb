Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices

Public Module FileInfoExtensions
    <Extension()> _
    Public Function NameWithoutExtension(ByVal Source As FileInfo) As String
        Return Source.Name.Substring(0, Source.Name.Length - Source.Extension.Length)
    End Function
End Module