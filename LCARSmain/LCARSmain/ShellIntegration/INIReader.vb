Option Strict On

Imports System.IO
Imports System.Text.RegularExpressions

Public Class INIReader
    Private data As Dictionary(Of String, Dictionary(Of String, String))
    Private sections() As String

    Private Shared headerRegex As New Regex("\[(.+)\]", RegexOptions.Compiled)
    Private Shared lineRegex As New Regex("([^=]+)=(.+)", RegexOptions.Compiled)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="INIpath">Path to INI file to read</param>
    ''' <remarks></remarks>
    ''' <exception cref="System.IO.FileNotFoundException">INI file does not exist</exception>
    ''' <exception cref="System.IO.IOException">IOException occurred during read</exception>
    ''' <exception cref="OutOfMemoryException">Insufficient memory to read the file</exception>
    Public Sub New(ByVal INIpath As String, Optional ByVal caseSensitive As Boolean = False)
        If Not File.Exists(INIpath) Then
            Throw New FileNotFoundException("Bad INI file path", INIpath)
        End If
        If caseSensitive Then
            data = New Dictionary(Of String, Dictionary(Of String, String))()
        Else
            data = New Dictionary(Of String, Dictionary(Of String, String))(StringComparer.OrdinalIgnoreCase)
        End If
        Dim sectionDict As Dictionary(Of String, String) = Nothing
        Dim sectionName As String = Nothing
        Dim line As String
        Using myReader As New IO.StreamReader(File.OpenRead(INIpath))
            Do
                line = myReader.ReadLine()
                If line Is Nothing Then Exit Do
                line = line.Trim()
                'Check for comments and blank lines
                If line.StartsWith(";") Then Continue Do
                If line = "" Then Continue Do
                'Try matching section header
                Dim m As Match = headerRegex.Match(line)
                If m.Success Then
                    sectionName = m.Groups(1).Value
                    If data.ContainsKey(sectionName) Then
                        sectionDict = data.Item(sectionName)
                    Else
                        If caseSensitive Then
                            sectionDict = New Dictionary(Of String, String)()
                        Else
                            sectionDict = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
                        End If
                        data.Add(sectionName, sectionDict)
                    End If
                    Continue Do
                End If
                'Try matching a line if we are in a valid section
                If sectionDict Is Nothing Then Continue Do
                m = lineRegex.Match(line)
                If m.Success Then
                    If Not sectionDict.ContainsKey(m.Groups(1).Value) Then
                        sectionDict.Add(m.Groups(1).Value, m.Groups(2).Value)
                    End If
                End If
            Loop
        End Using
    End Sub

    Public Function getValue(ByVal section As String, ByVal name As String, Optional ByVal defaultValue As String = Nothing) As String
        Dim sectionDict As Dictionary(Of String, String) = Nothing
        If Not data.TryGetValue(section, sectionDict) Then Return defaultValue
        Dim value As String = Nothing
        If sectionDict.TryGetValue(name, value) Then
            Return value
        Else
            Return defaultValue
        End If
    End Function

    Public Function getSections() As String()
        If sections Is Nothing Then
            Dim sList As New List(Of String)(data.Keys.Count)
            For Each mySection As String In data.Keys
                sList.Add(mySection)
            Next
            sections = sList.ToArray()
        End If
        Return sections
    End Function

    Public Function getKeys(ByVal section As String) As String()
        If Not data.ContainsKey(section) Then Return Nothing
        Dim sectionDict As Dictionary(Of String, String) = data(section)
        Dim sList As New List(Of String)(sectionDict.Keys.Count)
        For Each myKey As String In sectionDict.Keys
            sList.Add(myKey)
        Next
        Return sList.ToArray()
    End Function

End Class
