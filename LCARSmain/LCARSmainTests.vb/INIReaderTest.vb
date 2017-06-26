Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports LCARSmain
Imports System.Environment


'''<summary>
'''This is a test class for INIReaderTest and is intended
'''to contain all INIReaderTest Unit Tests
'''</summary>
<TestClass()> _
Public Class INIReaderTest


    Private testContextInstance As TestContext
    Private Const testINIfile As String = "test.ini"

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
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

    <ClassCleanup()> _
    Public Shared Sub MyClassCleanup()
        If IO.File.Exists(testINIfile) Then
            IO.File.Delete(testINIfile)
        End If
    End Sub

    '''<summary>
    '''Test for getValue()
    '''</summary>
    <TestMethod()> _
    Public Sub getValueTest()
        IO.File.WriteAllText(testINIfile, "[Section]" & NewLine & "a=b")
        Dim target As INIReader = New INIReader(testINIfile)
        Dim section As String = "Section"
        'Try existing value
        Assert.AreEqual("b", target.getValue(section, "a"))
        'Try missing value
        Assert.AreSame(Nothing, target.getValue(section, "b"))
        'Try missing section
        Assert.AreSame(Nothing, target.getValue("Bogus", "a"))
        'Try missing value with default
        Assert.AreEqual(section, target.getValue(section, "b", section))
        'Try missing section and value with default
        Assert.AreEqual(section, target.getValue("Bogus", "a", section))
    End Sub

    ''' <summary>
    ''' Test correct handling of an empty file
    ''' </summary>
    <TestMethod()> _
    Public Sub TestEmptyINI()
        IO.File.WriteAllText(testINIfile, "")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(0, target.getSections().Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of an empty section within the file
    ''' </summary>
    <TestMethod()> _
    Public Sub TestEmptySection()
        IO.File.WriteAllText(testINIfile, "[section]")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(1, target.getSections().Count)
        Assert.AreEqual(0, target.getKeys("section").Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of comments and blank lines
    ''' </summary>
    <TestMethod()> _
    Public Sub TestComments()
        IO.File.WriteAllText(testINIfile, "; [section]" & NewLine & NewLine & ";a=b")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(0, target.getSections().Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of values outside of a valid section
    ''' </summary>
    <TestMethod()> _
    Public Sub TestMissingSection()
        IO.File.WriteAllText(testINIfile, "a=b")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(0, target.getSections().Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of whitespace
    ''' </summary>
    <TestMethod()> _
    Public Sub TestWhitespaceHandling()
        IO.File.WriteAllText(testINIfile, "[section]" & NewLine _
                             & "a=b" & NewLine _
                             & " c = d " & NewLine _
                             & " contains space = also contains space ")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual("b", target.getValue("section", "a"))
        Assert.AreEqual("d", target.getValue("section", "c"))
        Assert.AreEqual("also contains space", target.getValue("section", "contains space"))
    End Sub

    ''' <summary>
    ''' Test correct handling of duplicate sections
    ''' </summary>
    <TestMethod()> _
    Public Sub TestDuplicateSections()
        IO.File.WriteAllText(testINIfile, "[section]" & NewLine _
                             & "a=b" & NewLine _
                             & "[section2]" & NewLine _
                             & "[section]" & NewLine _
                             & "c=d")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual("b", target.getValue("section", "a"))
        Assert.AreEqual("d", target.getValue("section", "c"))
        Assert.AreEqual(2, target.getSections.Count)
        Assert.AreEqual(2, target.getKeys("section").Count)
        Assert.AreEqual(0, target.getKeys("section2").Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of duplicate keys
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub TestDuplicateKeys()
        IO.File.WriteAllText(testINIfile, "[section]" & NewLine _
                             & "a=b" & NewLine _
                             & "a=c")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual("b", target.getValue("section", "a"))
        Assert.AreEqual(1, target.getSections.Count)
        Assert.AreEqual(1, target.getKeys("section").Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of case sensitivity and insensitivity
    ''' </summary>
    <TestMethod()> _
    Public Sub TestCaseSensitivity()
        IO.File.WriteAllText(testINIfile, "[section]" & NewLine _
                             & "a=b")
        Const expected As String = "b"
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(expected, target.getValue("section", "a"))
        Assert.AreEqual(expected, target.getValue("Section", "a"))
        Assert.AreEqual(expected, target.getValue("section", "A"))
        Assert.AreEqual(expected, target.getValue("Section", "A"))
        target = New INIReader(testINIfile, True)
        Assert.AreEqual(expected, target.getValue("section", "a"))
        Assert.AreSame(Nothing, target.getValue("Section", "a"))
        Assert.AreSame(Nothing, target.getValue("section", "A"))
        Assert.AreSame(Nothing, target.getValue("Section", "A"))
    End Sub

    ''' <summary>
    ''' Test correct handling of a key with an empty value
    ''' </summary>
    <TestMethod()> _
    Public Sub TestEmptyValue()
        IO.File.WriteAllText(testINIfile, "[section]" & NewLine _
                             & "a=" & NewLine _
                             & "b = ")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual("", target.getValue("section", "a"))
        Assert.AreEqual("", target.getValue("section", "b"))
    End Sub

    ''' <summary>
    ''' Test correct handling of malformed section headers
    ''' </summary>
    <TestMethod()> _
    Public Sub TestBadSectionHeaders()
        IO.File.WriteAllText(testINIfile, "section" & NewLine _
                             & "section]" & NewLine _
                             & "[section" & NewLine _
                             & "]section]" & NewLine _
                             & "[section[" & NewLine _
                             & "[section)" & NewLine _
                             & "[section]with extra text" & NewLine _
                             & "a=b")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(0, target.getSections().Count)
    End Sub

    ''' <summary>
    ''' Test correct handling of malformed key entries
    ''' </summary>
    <TestMethod()> _
    Public Sub TestBadValues()
        IO.File.WriteAllText(testINIfile, "[section]" & NewLine _
                             & "noEquals" & NewLine _
                             & " = noKey" & NewLine _
                             & "=Leading=Equals")
        Dim target As New INIReader(testINIfile)
        Assert.AreEqual(0, target.getKeys("section").Count)
    End Sub
End Class
