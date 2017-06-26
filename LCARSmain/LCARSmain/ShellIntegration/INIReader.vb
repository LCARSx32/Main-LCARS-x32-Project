Option Strict On

Imports System.IO
Imports System.Text.RegularExpressions

''' <summary>
''' Reads an INI file and stores its data in an easily queryable form.
''' </summary>
''' <remarks>
''' This class is designed to read a standard INI file, then store the data for
''' later reference. After the file has been read, all query operations are
''' approximately O(1).
''' 
''' Supported format:
''' 
''' Section headers are denoted as the section name within a set of brackets [].
''' There may be any amount of whitespace before or after the brackets, and the
''' section name may contain any character except a newline. No other characters
''' are permitted on the same line, including comments.
''' 
''' Comment lines are indicated by the first non-whitespace character being a
''' semicolon (;). Comment lines are ignored for processing.
''' 
''' Key-value entries consist of a name followed by an equals sign and a value.
''' Leading and trailing whitespace for both names and values is ignored. Names
''' and values may contain whitespace, but not as the first or last character.
''' 
''' Invalid lines of the file will be ignored. Duplicate section headers are
''' treated as a continuation of the first section with that name. Duplicate key
''' names are ignored, and only the first value is recorded.
''' </remarks>
Public Class INIReader
    'Stores the INI file's data
    Private data As Dictionary(Of String, Dictionary(Of String, String))

    ''' <summary>
    ''' Matches the section header of an INI file
    ''' </summary>
    ''' <remarks>
    ''' Assumes that leading and trailing whitespace has already been removed.
    ''' Requires an opening and closing bracket with at least one non-newline
    ''' character between them. First capture group is the section name.
    ''' </remarks>
    Private Shared headerRegex As New Regex("^\[(.+)\]$", RegexOptions.Compiled)
    ''' <summary>
    ''' Matches a key-value statement in an INI file
    ''' </summary>
    ''' <remarks>
    ''' Assumes that leading and trailing whitespace has already been removed.
    ''' Matches non-equals sign characters up until an equals sign, which may
    ''' have any amount of whitespace on either side. Remainder of the string
    ''' is matched as the value. First capture group is the key, second is the
    ''' value.
    ''' </remarks>
    Private Shared lineRegex As New Regex("^([^=]+?)\s*=\s*(.*)$", RegexOptions.Compiled)

    ''' <summary>
    ''' Create a new INIReader instance
    ''' </summary>
    ''' <param name="INIpath">Path to INI file to read</param>
    ''' <param name="caseSensitive">Case-sensitivity of key matching. Defaults to non-case sensitive.</param>
    ''' <remarks></remarks>
    ''' <exception cref="FileNotFoundException">INI file does not exist</exception>
    ''' <exception cref="IOException">IOException occurred during read</exception>
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

    ''' <summary>
    ''' Query the INI file data for a value
    ''' </summary>
    ''' <param name="section">Section to query</param>
    ''' <param name="name">Key to get the value for</param>
    ''' <param name="defaultValue">Default value to return if key or section do not exist</param>
    ''' <returns>Value requested or default value</returns>
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

    ''' <summary>
    ''' Get all sections defined in the INI file
    ''' </summary>
    ''' <returns>IEnumerable(Of String) with all section names</returns>
    Public Function getSections() As IEnumerable(Of String)
        Return data.Keys
    End Function

    ''' <summary>
    ''' Get all keys defined in a given section
    ''' </summary>
    ''' <param name="section">Section to query</param>
    ''' <returns>IEnumerable(of String) with section names if section exists, otherwise Nothing</returns>
    Public Function getKeys(ByVal section As String) As IEnumerable(Of String)
        If Not data.ContainsKey(section) Then Return Nothing
        Return data(section).Keys
    End Function

End Class
