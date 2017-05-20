Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports LCARSmain

<TestClass()> Public Class GlobalAtomTests

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

    Private Const aName As String = "Test Atom String."

    <TestMethod()> Public Sub TestCreateDestroy()
        Dim myAtom As GlobalAtom
        myAtom = New GlobalAtom(aName)
        Assert.AreNotEqual(Of Short)(0, myAtom.Value)
        myAtom.Dispose()
        Try
            Dim value As Short = myAtom.Value
            Assert.Fail("No exception occurred")
        Catch ex As ObjectDisposedException
        End Try
    End Sub

    <TestMethod()> Public Sub TestCreateInvalidName()
        Dim myAtom As GlobalAtom
        Try
            myAtom = New GlobalAtom("A very long name that isn't valid in this context. A very long name that isn't valid in this context. A very long name that isn't valid in this context. A very long name that isn't valid in this context. A very long name that isn't valid in this context. And over the limit.")
            Assert.Fail("No exception occurred")
        Catch ex As ArgumentException
        End Try
    End Sub

    <TestMethod()> Public Sub TestGetName()
        Dim myAtom As GlobalAtom
        myAtom = New GlobalAtom(aName)
        Dim val As Short = myAtom.Value
        Assert.AreEqual(Of String)(aName, GlobalAtom.SafeGlobalGetAtomName(myAtom.Value))
        myAtom.Dispose()
        Assert.AreEqual(Of String)("", GlobalAtom.SafeGlobalGetAtomName(val))
    End Sub

    <TestMethod()> Public Sub TestFindAtom()
        Dim myAtom As GlobalAtom
        myAtom = New GlobalAtom(aName)
        Assert.AreEqual(Of Short)(myAtom.Value, GlobalAtom.SafeGlobalFindAtom(aName))
        myAtom.Dispose()
        Assert.AreEqual(Of Short)(0, GlobalAtom.SafeGlobalFindAtom(aName))
    End Sub
End Class
