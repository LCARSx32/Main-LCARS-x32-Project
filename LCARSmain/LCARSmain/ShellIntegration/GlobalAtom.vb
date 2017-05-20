Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class GlobalAtom
    Implements IDisposable

#Region " Windows API "

    Private Declare Auto Function GlobalAddAtom Lib "Kernel32" (ByVal lpString As String) As Short

    Private Declare Auto Function GlobalGetAtomName Lib "Kernel32" (ByVal nAtom As Short, _
                                                                    ByVal lpBuffer As String, _
                                                                    ByVal nSize As Integer) _
                                                                    As UInteger
    Private Declare Auto Function GlobalFindAtom Lib "Kernel32" (ByVal lpString As String) As Short
    Private Declare Auto Function GlobalDeleteAtom Lib "Kernel32" (ByVal nAtom As Short) As Short
    Private Const ERROR_SUCCESS As Integer = 0
    Private Const ERROR_FILE_NOT_FOUND As Integer = 2
    Private Const ERROR_INVALID_HANDLE As Integer = 6
    Private Declare Sub SetLastError Lib "Kernel32" (ByVal dwErrCode As Integer)

#End Region

    'TODO: Check to see what errors get thrown to see if any can be handled locally.
    Private Shared Function SafeGlobalAddAtom(ByVal lpString As String) As Short
        Dim ret As Short = GlobalAddAtom(lpString)
        If ret = 0 Then
            Dim err As Integer = Marshal.GetLastWin32Error()
            Throw New Win32Exception(err, "Error adding global atom")
        End If
        Return ret
    End Function
    ''' <summary>
    ''' Find the string name of an atom in the global atom table.
    ''' </summary>
    ''' <param name="nAtom">Atom to search for</param>
    ''' <returns>Non-empty string on success</returns>
    ''' <remarks>
    ''' The unmanaged function GlobalGetAtomName is not case-sensitive. The string returned will be
    ''' the originally registered name of the atom. Do not assume that this is the same case as the 
    ''' name that you registered.
    ''' </remarks>
    Public Shared Function SafeGlobalGetAtomName(ByVal nAtom As Short) As String
        'Atom names can be a maximum of 255 bytes. Let's add one for safety.
        Const AtomNameLen As Integer = 256
        Dim buffer As String = Space(AtomNameLen)
        Dim ret As UInteger = GlobalGetAtomName(nAtom, buffer, AtomNameLen)
        If ret = 0 Then
            Dim err As Integer = Marshal.GetLastWin32Error()
            Select Case err
                Case ERROR_INVALID_HANDLE
                    Return ""
                Case Else
                    Throw New Win32Exception(err, "Error retrieving global atom name")
            End Select
        End If
        Return Left(buffer, ret)
    End Function
    ''' <summary>
    ''' Finds a string within the global atom table and returns its atom if existant
    ''' </summary>
    ''' <param name="lpString">String to find</param>
    ''' <returns>Non-zero Short on success</returns>
    ''' <remarks>
    ''' The unmanaged function GlobalFindAtom is not case-sensitive; however, the case of the
    ''' originally registered atom is preserved.
    ''' </remarks>
    Public Shared Function SafeGlobalFindAtom(ByVal lpString As String) As Short
        Dim ret As Short = GlobalFindAtom(lpString)
        If ret = 0 Then
            Dim err As Integer = Marshal.GetLastWin32Error()
            Select Case err
                Case ERROR_FILE_NOT_FOUND
                    Return 0
                Case Else
                    Throw New Win32Exception(err, "Error finding atom")
            End Select
        End If
        Return ret
    End Function

    Private Shared Sub SafeGlobalDeleteAtom(ByVal nAtom As Short)
        SetLastError(ERROR_SUCCESS)
        GlobalDeleteAtom(nAtom) 'Always returns zero
        Dim err As Integer = Marshal.GetLastWin32Error()
        If err <> ERROR_SUCCESS Then
            Throw New Win32Exception(err, "Error deleting atom")
        End If
    End Sub

    Private _name As String
    Private _val As Short

    Public Sub New(ByVal name As String)
        If name.Length > 255 Then
            Throw New ArgumentException("Atom names cannot be more than 255 characters")
        End If
        _name = name
        _val = SafeGlobalAddAtom(_name)
    End Sub

    Public ReadOnly Property Value() As Short
        Get
            If disposed Then Throw New ObjectDisposedException("Global atom")
            Return _val
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

#Region " IDisposable Support "
    Private disposed As Boolean = False

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                ' Free  managed objects. (None)
            End If

            'TODO: Find out what errors could occur here.
            SafeGlobalDeleteAtom(_val)
        End If
        Me.disposed = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Me.Dispose(False)
    End Sub
#End Region

End Class
