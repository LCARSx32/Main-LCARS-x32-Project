Imports System.IO
''' <summary>
''' Contains methods for reading and modifying a version definition file.
''' </summary>
''' <remarks></remarks>
Public Class ProgramVersions
    Public Structure ComponentVersion
        Dim ComponentName As String
        Dim ComponentVersion As String
    End Structure
    Private myFilePath As String
    Private myGlobalVersion As String
    Private myVersionList As New List(Of ComponentVersion)

    ''' <summary>
    ''' Creates a new instance of the ProgramVersions object
    ''' </summary>
    ''' <param name="filePath">Path of the versions file to load</param>
    ''' <remarks>The calling application is responsible for verifying that the file exists.</remarks>
    Public Sub New(ByVal filePath As String)
        loadFile(filePath)
    End Sub

    Private Sub loadFile(ByVal file As String)
        myFilePath = file
        Using myReader As New StreamReader(file)
            myGlobalVersion = myReader.ReadLine()
            While myReader.Peek() <> -1
                Dim myComponent As New ComponentVersion
                myComponent.ComponentName = myReader.ReadLine()
                myComponent.ComponentVersion = myReader.ReadLine()
                myVersionList.Add(myComponent)
            End While
        End Using
    End Sub

    ''' <summary>
    ''' Searches current file and gets current version of a component.
    ''' </summary>
    ''' <param name="Component">Name of the component being looked up.</param>
    ''' <returns>A string representing the version of the component requested.</returns>
    ''' <remarks>Will return "" if there is no data for the component.</remarks>
    Public Function getVersion(ByVal Component As String) As String
        Dim myVersion As String = ""
        For Each myElement As ComponentVersion In myVersionList
            If myElement.ComponentName = Component Then
                myVersion = myElement.ComponentVersion
                Exit For
            End If
        Next
        Return myVersion
    End Function

    ''' <summary>
    ''' Gets global program version
    ''' </summary>
    ''' <returns>String version designation</returns>
    ''' <remarks></remarks>
    Public Function getGlobalVersion() As String
        Return myGlobalVersion
    End Function

    ''' <summary>
    ''' Updates version of specified component
    ''' </summary>
    ''' <param name="component">Name of component to be updated.</param>
    ''' <param name="version">New version designation</param>
    ''' <remarks>Will create a new entry if component entry not already extant. Does not save changes.</remarks>
    Public Sub UpdateVersion(ByVal component As String, ByVal version As String)
        Dim found As Boolean = False
        Dim temp As New ComponentVersion With {.ComponentName = component, .ComponentVersion = version}
        For i As Integer = 0 To myVersionList.Count - 1
            If myVersionList(i).ComponentName = component Then
                myVersionList(i) = temp
                found = True
                Exit For
            End If
        Next
        If Not found Then
            myVersionList.Add(temp)
        End If
    End Sub

    ''' <summary>
    ''' Updates global version
    ''' </summary>
    ''' <param name="newVersion">New global version designation</param>
    ''' <remarks>Does not save changes.</remarks>
    Public Sub UpdateGlobalVersion(ByVal newVersion As String)
        myGlobalVersion = newVersion
    End Sub

    ''' <summary>
    ''' Saves all changes to the file.
    ''' </summary>
    ''' <remarks>Should be called after all changes have been made, just prior to update sequence completion.</remarks>
    Public Sub SaveFile()
        Using myWriter As New System.IO.StreamWriter(myFilePath, False)
            myWriter.WriteLine(myGlobalVersion)
            For Each myElement As ComponentVersion In myVersionList
                myWriter.WriteLine(myElement.ComponentName)
                myWriter.WriteLine(myElement.ComponentVersion)
            Next
        End Using
    End Sub
End Class
