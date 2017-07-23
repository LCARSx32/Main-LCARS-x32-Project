Option Strict On

Imports System.IO

Module modCommon
    ''' <summary>
    ''' Formats a number of bytes with appropriate units
    ''' </summary>
    ''' <param name="bytes">Number of bytes to format</param>
    ''' <returns>String representation</returns>
    ''' <remarks>
    ''' Uses BINARY prefixes, not SI prefixes. This means each level is based on 
    ''' 1024, not 1000.
    ''' </remarks>
    Public Function ToDriveSize(ByVal bytes As Long) As String
        If bytes < 0 Then Return "-" & ToDriveSize(-1 * bytes)
        If bytes = 0 Then Return "0B"
        Dim units() As String = {"B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}

        Dim order As Integer = CInt(Math.Floor(Math.Log(bytes, 1024)))
        If order > units.GetUpperBound(0) Then
            order = units.GetUpperBound(0)
        End If
        Dim adjustedSize As Double = bytes / (1L << (order * 10))
        Return adjustedSize.ToString("N2") & units(order)
    End Function

    ''' <summary>
    ''' Recursively find the size of a directory and all contained files
    ''' </summary>
    ''' <param name="d">Directory to search</param>
    ''' <returns>Size of all files contained within the directory and its subdirectories</returns>
    ''' <remarks>
    ''' Inaccessible files or directories will report a size of zero.
    ''' </remarks>
    Public Function DirSize(ByVal d As DirectoryInfo) As Long
        Dim Size As Long = 0
        Try
            ' Add subdirectory sizes.
            Dim dis As DirectoryInfo() = d.GetDirectories()
            For Each di As DirectoryInfo In dis
                Size += DirSize(di)
            Next di
            ' Add file sizes.
            Dim fis As FileInfo() = d.GetFiles()
            For Each fi As FileInfo In fis
                Size += fi.Length
            Next fi
        Catch ex As IOException
            Return 0
        End Try
        Return Size
    End Function

    ''' <summary>
    ''' Generate a color for use with LCARS buttons from a file extension
    ''' </summary>
    ''' <param name="ext">File extension</param>
    ''' <returns>Hexadecimal notation for color</returns>
    Public Function getExtColor(ByVal ext As String) As String
        ext = ext.Replace(".", "").ToLower

        Dim c() As Integer = {150, 150, 150}
        For i As Integer = 0 To Math.Min(ext.Length - 1, 2)
            Dim ch As Char = ext.Chars(i)
            If Char.IsDigit(ch) Then
                c(i) = CInt((((Convert.ToInt32(ch) - 48) * 157) / 10) + 98)
            Else
                c(i) = CInt((((Convert.ToInt32(ch) - 97) * 157) / 25) + 98)
            End If
            If c(i) < 0 Then c(i) = 0
        Next
        Return System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(255, c(0), c(1), c(2)))
    End Function

    ''' <summary>
    ''' Check if a FileAttributes variable contains the specified flag or flags
    ''' </summary>
    ''' <param name="fileAttributes">Attributes to check</param>
    ''' <param name="flag">Flag(s) to find</param>
    ''' <returns>True if flag(s) is/are present</returns>
    Public Function FileHasFlag(ByVal fileAttributes As FileAttributes, ByVal flag As FileAttributes) As Boolean
        Return (fileAttributes And flag) = flag
    End Function
End Module
