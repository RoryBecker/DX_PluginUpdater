Imports NUnit.Framework

<TestFixture()> _
Public Class IO_Tests
    <Test()> _
    Public Sub RemoveExtension_Test()
        Assert.AreEqual("MyFile", New System.IO.FileInfo("MyFile.Extension").NameWithoutExtension)
    End Sub
End Class