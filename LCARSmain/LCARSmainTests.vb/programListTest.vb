Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports LCARSmain

<TestClass()> Public Class programListTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region
    Private Const testDir As String = "ProgramListTest"
    Private Const testDir2 As String = "ProgramListTest2"
    Private Const testEmptyDir As String = "EmptyDir"
    Private Const testSubdirPfx As String = "Subdir"
    Private Const testFilePfx As String = "File"

    '''<summary>
    '''A test for mergeDirs
    '''</summary>
    <TestMethod(), _
     DeploymentItem("LCARSmain.exe")> _
    Public Sub mergeDirsTest()
        Dim dir1 As New programList.DirectoryStartItem() With {.Name = "T"}
        Dim dir2 As New programList.DirectoryStartItem() With {.Name = "S"}
        'Test merging empty directories
        programList_Accessor.mergeDirs(dir1, dir2)
        Assert.AreEqual("T", dir1.Name)
        Assert.AreEqual(0, dir1.subItems.Count)
        Assert.AreEqual("S", dir2.Name)
        Assert.AreEqual(0, dir2.subItems.Count)
        'Test merging different items
        Dim s1 As New FileStartItem() With {.Name = "s1"}
        dir1.subItems.Add(s1)
        Dim s2 As New FileStartItem() With {.Name = "s2"}
        dir2.subItems.Add(s2)
        programList_Accessor.mergeDirs(dir1, dir2)
        Assert.AreEqual(2, dir1.subItems.Count)
        Assert.AreSame(s1, dir1.subItems(0))
        Assert.AreSame(s2, dir1.subItems(1))
        Assert.AreEqual(1, dir2.subItems.Count)
        Assert.AreSame(s2, dir2.subItems(0))
        'Test merging identical items
        Dim s3 As New FileStartItem() With {.Name = "s2"}
        dir2.subItems.Clear()
        dir2.subItems.Add(s3)
        programList_Accessor.mergeDirs(dir1, dir2)
        Assert.AreEqual(2, dir1.subItems.Count)
        Assert.AreSame(s3, dir1.subItems(1))
    End Sub

    '''<summary>
    '''Test getting programs from a single directory
    '''</summary>
    <TestMethod(), _
     DeploymentItem("LCARSmain.exe")> _
    Public Sub GetProgramsTest()
        Directory.CreateDirectory(testDir)
        Directory.CreateDirectory(testEmptyDir)
        For i As Integer = 0 To 9
            Dim subdirPath As String = testDir & Path.DirectorySeparatorChar & testSubdirPfx & i.ToString()
            Directory.CreateDirectory(subdirPath)
            File.Create(subdirPath & Path.DirectorySeparatorChar & testFilePfx & i.ToString())
        Next
        Dim actual As programList.DirectoryStartItem = programList_Accessor.GetPrograms(testDir)
        Assert.AreEqual(Nothing, actual.Name)
        Assert.AreEqual(Nothing, actual.icon)
        Assert.AreEqual(10, actual.subItems.Count)
        For i As Integer = 0 To 9
            Assert.AreEqual(testSubdirPfx & i.ToString(), actual.subItems(i).Name)
            Dim subdir As DirectoryStartItem = CType(actual.subItems(i), programList.DirectoryStartItem)
            Assert.AreEqual(1, subdir.subItems.Count)
            Dim item As StartItem = subdir.subItems(0)
            Assert.AreEqual(testFilePfx & i.ToString(), item.Name)
            Assert.AreSame(GetType(FileStartItem), item.GetType())
        Next
    End Sub
End Class
