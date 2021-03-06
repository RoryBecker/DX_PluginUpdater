Imports System.Net
Imports System.IO
Imports Ionic.Zip

Public Class WebManager
    Private WebClient = New System.Net.WebClient
    Public Function ContentIs404(ByVal Url As String, ByRef Content As String) As Boolean
        Try
            Content = GetUrlContentAsString(Url)
            Return is404(Content)
        Catch ex As WebException
            Return CType(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.NotFound
        End Try
    End Function
    Public Function is404(ByVal Content As String) As Boolean
        Return Content.Contains("Oops")
    End Function
    Public Function GetUrlContentAsString(ByVal Url As String) As String
        Dim Request As WebRequest = WebRequest.Create(Url)
        Using Response As WebResponse = Request.GetResponse()
            Using Reader As StreamReader = New StreamReader(Response.GetResponseStream())
                Return Reader.ReadToEnd
            End Using
        End Using
    End Function
    Public Function DownloadResource(ByVal RemoteZipFileUrl As String) As Byte()
        Return WebClient.DownloadData(RemoteZipFileUrl)
    End Function
    Public Sub Unzip(ByVal FileStream As Stream, ByVal PluginFolder As String)
        Try
            Using zip1 As ZipFile = ZipFile.Read(FileStream)
                Dim e As ZipEntry
                For Each e In zip1
                    e.Extract(PluginFolder, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class