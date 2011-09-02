Imports System.Net
Imports System.IO
Imports Ionic.Zip

Public Class WebManager
    Private WebClient = New System.Net.WebClient
    Public Function GetUrlContentAsString(ByVal Url As String) As String
        Dim Request As WebRequest = WebRequest.Create(Url)
        Dim Response As WebResponse = Request.GetResponse()
        Dim Reader As StreamReader = New StreamReader(Response.GetResponseStream())
        Return Reader.ReadToEnd
    End Function
    Public Function DownloadResource(ByVal RemoteZipFileUrl As String) As Byte()
        Return WebClient.DownloadData(RemoteZipFileUrl)
    End Function
    Public Sub Unzip(ByVal FileStream As Stream, ByVal PluginFolder As String)
        Using zip1 As ZipFile = ZipFile.Read(FileStream)
            Dim e As ZipEntry
            For Each e In zip1
                e.Extract(PluginFolder, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using
    End Sub
End Class