'Code here largely based on the article at:
'http://www.codeguru.com/vb/gen/vb_system/keyboard/article.php/c4831/Managing-LowLevel-Keyboard-Hooks-with-the-Windows-API-for-VB-NET.htm


Option Strict On

Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Threading
Module modKeyboard
    Public Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As IntPtr) As Integer

    Public Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As IntPtr, ByVal dwThreadId As Integer) As IntPtr

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer

    Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer

    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    ' Low-Level Keyboard Constants
    Private Const HC_ACTION As Integer = 0
    Private Const LLKHF_EXTENDED As Integer = &H1
    Private Const LLKHF_INJECTED As Integer = &H10
    Private Const LLKHF_ALTDOWN As Integer = &H20
    Private Const LLKHF_UP As Integer = &H80

    ' Virtual Keys
    Public Const VK_TAB As Integer = &H9
    Public Const VK_CONTROL As Integer = &H11
    Public Const VK_ESCAPE As Integer = &H1B
    Public Const VK_DELETE As Integer = &H2E
    Public Const VK_WINDOWSL As Integer = &H5B
    Public Const VK_WINDOWSR As Integer = &H5C
    Public Const VK_LSHIFT As Integer = &HA0
    Public Const VK_RSHIFT As Integer = &HA1

    Private Const WH_KEYBOARD_LL As Integer = 13&
    Public KeyboardHandle As IntPtr


    ' Implement this function to block as many
    ' key combinations as you'd like
    Public Function IsHooked(ByRef Hookstruct As KBDLLHOOKSTRUCT) As Boolean


        If (Hookstruct.vkCode = VK_ESCAPE) And CBool(GetAsyncKeyState(VK_CONTROL) And &H8000) Then
            Return True
        ElseIf (Hookstruct.vkCode = VK_TAB) And CBool(Hookstruct.flags And LLKHF_ALTDOWN) Then
            Return True
        ElseIf (Hookstruct.vkCode = VK_ESCAPE) And CBool(Hookstruct.flags And LLKHF_ALTDOWN) Then
            Return True
        ElseIf Hookstruct.vkCode = VK_WINDOWSL Or Hookstruct.vkCode = VK_WINDOWSR Then
            Return True
        ElseIf (Hookstruct.vkCode = VK_DELETE) And CBool(GetAsyncKeyState(VK_CONTROL)) And CBool(GetAsyncKeyState(&H12)) Then
            Return True
        End If
        Return False
    End Function


    Public Function KeyboardCallback(ByVal Code As Integer, _
    ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        If (Code = HC_ACTION) Then
            If (IsHooked(lParam)) Then
                Return 1
            End If
        End If
        Return CallNextHookEx(KeyboardHandle, Code, wParam, lParam)
    End Function


    Public Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer

    <MarshalAs(UnmanagedType.FunctionPtr)> Private callback As KeyboardHookDelegate

    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)

        KeyboardHandle = SetWindowsHookEx(WH_KEYBOARD_LL, callback, Marshal.GetHINSTANCE([Assembly].GetExecutingAssembly.GetModules()(0)), 0)

    End Sub

    Public Sub UnhookKeyboard()
        If (KeyboardHandle <> IntPtr.Zero) Then
            Call UnhookWindowsHookEx(KeyboardHandle)
        End If
    End Sub

End Module