Option Strict On

Imports System.IO

Module modCommon
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

    Public Function DirSize(ByVal d As DirectoryInfo) As Long
        Dim Size As Long = 0
        ' Add file sizes.
        Try
            Dim fis As FileInfo() = d.GetFiles()
            For Each fi As FileInfo In fis
                Size += fi.Length
            Next fi
            ' Add subdirectory sizes.
            Dim dis As DirectoryInfo() = d.GetDirectories()
            For Each di As DirectoryInfo In dis
                Size += DirSize(di)
            Next di
        Catch ex As IOException
            Return 0
        End Try
        Return Size
    End Function
End Module
