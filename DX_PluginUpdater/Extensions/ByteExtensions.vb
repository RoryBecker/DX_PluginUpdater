Imports System.IO


Public Module ByteExtensions
    Public Function ToStream(ByVal Source As Byte()) As Stream
        Dim Stream As MemoryStream = New MemoryStream(Source)
        Stream.Seek(0, 0)
        Return Stream
    End Function
End Module
