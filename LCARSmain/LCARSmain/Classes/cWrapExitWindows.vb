Imports System.Runtime.InteropServices

Public Class cWrapExitWindows

    Private Declare Function ExitWindowsEx Lib "user32.dll" (ByVal uFlags As Int32, ByVal dwReserved As Int32) As Boolean
    Private Declare Function GetCurrentProcess Lib "kernel32.dll" () As IntPtr
    Private Declare Sub OpenProcessToken Lib "advapi32.dll" (ByVal ProcessHandle As IntPtr, ByVal DesiredAccess As Int32, ByRef TokenHandle As IntPtr)
    Private Declare Sub LookupPrivilegeValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" (ByVal lpSystemName As String, ByVal lpName As String, ByRef lpLuid As Long)
    Private Declare Function AdjustTokenPrivileges Lib "advapi32.dll" (ByVal TokenHandle As IntPtr, ByVal DisableAllPrivileges As Boolean, ByRef NewState As LUID, ByVal BufferLength As Int32, ByVal PreviousState As IntPtr, ByVal ReturnLength As IntPtr) As Boolean

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Friend Structure LUID
        Public Count As Integer
        Public LUID As Long
        Public Attribute As Integer
    End Structure

    Public Enum Action
        LogOff = 0
        Shutdown = 1
        Restart = 2
        PowerOff = 8
    End Enum

    Public Sub ExitWindows(ByVal how As Action, Optional ByVal Forced As Boolean = True)
        Dim TokenPrivilege As LUID
        Dim hProcess As IntPtr = GetCurrentProcess()
        Dim hToken As IntPtr = IntPtr.Zero
        OpenProcessToken(hProcess, &H28, hToken)
        TokenPrivilege.Count = 1
        TokenPrivilege.LUID = 0
        TokenPrivilege.Attribute = 2
        LookupPrivilegeValue(Nothing, "SeShutdownPrivilege", TokenPrivilege.LUID)
        AdjustTokenPrivileges(hToken, False, TokenPrivilege, 0, IntPtr.Zero, IntPtr.Zero)
        If Forced Then
            ExitWindowsEx(how + 4, 0)
        Else
            ExitWindowsEx(how, 0)
        End If
    End Sub

End Class
