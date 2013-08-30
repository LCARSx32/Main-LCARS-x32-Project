Imports System.Runtime.InteropServices

Public Class frmKeyboard

    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Long) As Integer


#Region " Send Windows Key "

    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Const WM_KEYDOWN = &H100
    Const WM_KEYUP = &H101
    Const VK_RETURN = &HD


    Private Const KEYEVENTF_EXTENDEDKEY As Long = &H1
    Private Const KEYEVENTF_KEYUP As Long = &H2
    Private Const VK_LWIN As Byte = &H5B
    Private Const VK_SCROLL = &H91
    Private Const VK_NUMLOCK = &H90
    Private Const VK_CAPITAL = &H14
    Private Const VK_ALT = &H12
    Private Const VK_TAB = &H9
    Private Const VK_0 = &H30
    Private Const VK_PRINT = &H2A








#End Region

#Region " Keep keyboard on top and don't activate "

    <DllImport("user32.dll")> _
    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As UInt32
    End Function

#End Region

#Region " Working Area "
    'Constants for setting the "working area" (the area programs load)
    Public Const SPI_SETWORKAREA = 47
    Public Const SPIF_SENDWININICHANGE = &H2
    Public Const SPIF_UPDATEINIFILE = &H1
    Public Const SPIF_change = SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE

    Public Structure RECT
        Dim Left_Renamed As Integer
        Dim Top_Renamed As Integer
        Dim Right_Renamed As Integer
        Dim Bottom_Renamed As Integer
    End Structure

    'used to set the working area
    ' <System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SystemParametersInfoA")> _
    Public Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Int32, ByVal uParam As Int32, ByVal lpvParam As IntPtr, ByVal fuWinIni As Int32) As Int32

#End Region


    Dim SHIFT As Boolean = False
    Dim CAPS As Boolean = False
    Dim CTRL As Boolean = False
    Dim ALT As Boolean = False
    Dim WIN As Boolean = False
    Dim tab As Boolean = False


    Dim buttons As New Collection
    Dim oWidth As Integer
    Dim oHeight As Integer
    Dim o2Width As Integer
    Dim o2Height As Integer
    Dim isInit As Boolean = False

    Dim uppercase As Boolean = False
    Dim numLockShift As Boolean = False

    Dim increment As Integer = 20

    Dim oLoc As Point
    Dim isMoving As Boolean = False

    Private Structure buttonData
        Dim width As Integer
        Dim height As Integer
        Dim left As Integer
        Dim top As Integer
        Dim control As LCARS.LCARSbuttonClass

    End Structure

    Private Sub frmKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oWidth = SplitContainer1.Panel1.Width
        oHeight = SplitContainer1.Panel1.Height

        o2Width = SplitContainer1.Panel2.Width
        o2Height = SplitContainer1.Panel2.Height

        ' style of window?
        Dim GWL_EXSTYLE As Integer = (-20)
        ' get - retrieves information about a specified window
        GetWindowLong(Me.Handle, GWL_EXSTYLE)
        ' set - changes the attribute of a specified window - I think this stops it being focused on
        SetWindowLong(Me.Handle, GWL_EXSTYLE, &H8000000)

        For Each myButton As Control In SplitContainer1.Panel1.Controls
            Dim newbutton As New buttonData
            newbutton.width = myButton.Width
            newbutton.height = myButton.Height
            newbutton.left = myButton.Left
            newbutton.top = myButton.Top
            newbutton.control = myButton
            buttons.Add(newbutton)

        Next

        For Each myButton As Control In SplitContainer1.Panel2.Controls
            Dim newbutton As New buttonData
            newbutton.width = myButton.Width
            newbutton.height = myButton.Height
            newbutton.left = myButton.Left
            newbutton.top = myButton.Top
            newbutton.control = myButton
            buttons.Add(newbutton)

        Next
        Dim myScreen As Screen = Screen.FromPoint(New Point(Me.Left, Me.Top))

        Dim tmpStr As String = GetSetting("x32_OSK", "Settings", "Size", myScreen.Bounds.Width * 0.75 & ", " & 250)
        Dim split() As String = tmpStr.Split(",")

        Me.Width = split(0)
        Me.Height = split(1)

        tmpStr = GetSetting("x32_OSK", "Settings", "Location", myScreen.Bounds.Left + myScreen.Bounds.Width * 0.125 & ", " & myScreen.Bounds.Height - Me.Height)

        split = tmpStr.Split(",")


        Me.Left = split(0)
        Me.Top = split(1)

        isInit = True

        Dim newWidth As Double = SplitContainer1.Panel1.Width / oWidth
        Dim newHeight As Double = SplitContainer1.Panel1.Height / oHeight

        SplitContainer1.Visible = False

        For i As Integer = 1 To buttons.Count
            buttons(i).Control.Left = buttons(i).left * newWidth
            buttons(i).control.top = buttons(i).top * newHeight
            buttons(i).Control.Width = buttons(i).width * newWidth
            buttons(i).Control.Height = buttons(i).height * newHeight

        Next

        SplitContainer1.Visible = True

        SaveSetting("x32_OSK", "Settings", "Size", Me.Width & ", " & Me.Height)
        My.Settings.Save()



        'frmKeyboard_ResizeEnd(sender, e)

        'Function Button code
        UserButtons.Hide()
        sbFn.Clickable = False
        sbFn.Color = LCARS.LCARScolorStyles.FunctionUnavailable

        loadFNbuttons()


        'If numbers lock is on, sets numbers lock button to primary colour.
        If GetKeyState(Keys.NumLock) = 1 Then
            btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction
        End If

        'If scroll lock is on, sets scroll lock button to primary colour.
        If GetKeyState(Keys.Scroll) = 1 Then
            btnScrollLock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            btnScrollLock.Color = LCARS.LCARScolorStyles.SystemFunction
        End If

        'Code for size mode on start up
        Dim mode As Boolean
        mode = My.Settings.Mode
        If mode = True Then
            sbNum_Click(sender, e)
        End If

        Me.Show()


    End Sub

    Public Sub loadFNbuttons()

        If My.Settings.FN1Name = "" Then
            sbFn1.ButtonText = "FN1"
        Else
            If Not My.Settings.FN1Name = "" Then
                sbFn1.ButtonText = My.Settings.FN1Name
            End If
        End If

        If My.Settings.FN2Name = "" Then
            sbFn2.ButtonText = "FN2"
        Else
            If Not My.Settings.FN2Name = "" Then
                sbFn2.ButtonText = My.Settings.FN2Name
            End If
        End If

        If My.Settings.FN3Name = "" Then
            sbFN3.ButtonText = "FN3"
        Else
            If Not My.Settings.FN3Name = "" Then
                sbFN3.ButtonText = My.Settings.FN3Name
            End If
        End If

        If My.Settings.FN4Name = "" Then
            sbFn4.ButtonText = "FN4"
        Else
            If Not My.Settings.FN4Name = "" Then
                sbFn4.ButtonText = My.Settings.FN4Name
            End If
        End If

        If My.Settings.FN5Name = "" Then
            sbFn5.ButtonText = "FN5"
        Else
            If Not My.Settings.FN5Name = "" Then
                sbFn5.ButtonText = My.Settings.FN5Name
            End If
        End If

        If My.Settings.FN6Name = "" Then
            sbFn6.ButtonText = "FN6"
        Else
            If Not My.Settings.FN6Name = "" Then
                sbFn6.ButtonText = My.Settings.FN6Name
            End If
        End If

        If My.Settings.FN7Name = "" Then
            sbFn7.ButtonText = "FN7"
        Else
            If Not My.Settings.FN7Name = "" Then
                sbFn7.ButtonText = My.Settings.FN7Name
            End If
        End If

        If My.Settings.FN8Name = "" Then
            sbFn8.ButtonText = "FN8"
        Else
            If Not My.Settings.FN8Name = "" Then
                sbFn8.ButtonText = My.Settings.FN8Name
            End If
        End If

        If My.Settings.FN9Name = "" Then
            sbFn9.ButtonText = "FN9"
        Else
            If Not My.Settings.FN9Name = "" Then
                sbFn9.ButtonText = My.Settings.FN9Name
            End If
        End If

        If My.Settings.FN10Name = "" Then
            sbFn10.ButtonText = "FN10"
        Else
            If Not My.Settings.FN10Name = "" Then
                sbFn10.ButtonText = My.Settings.FN10Name
            End If
        End If

        If My.Settings.FN11Name = "" Then
            sbFn11.ButtonText = "FN11"
        Else
            If Not My.Settings.FN11Name = "" Then
                sbFn11.ButtonText = My.Settings.FN11Name
            End If
        End If

        If My.Settings.FN12Name = "" Then
            sbFn12.ButtonText = "FN12"
        Else
            If Not My.Settings.FN12Name = "" Then
                sbFn12.ButtonText = My.Settings.FN12Name
            End If
        End If

    End Sub

    Public Sub frmKeyboard_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim newWidth As Double = SplitContainer1.Panel1.Width / oWidth
        Dim newHeight As Double = SplitContainer1.Panel1.Height / oHeight

        SplitContainer1.Visible = False

        For i As Integer = 1 To buttons.Count
            buttons(i).Control.Left = buttons(i).left * newWidth
            buttons(i).control.top = buttons(i).top * newHeight
            buttons(i).Control.Width = buttons(i).width * newWidth
            buttons(i).Control.Height = buttons(i).height * newHeight

        Next

        SplitContainer1.Visible = True

        SaveSetting("x32_OSK", "Settings", "Size", Me.Width & ", " & Me.Height)
        My.Settings.Save()


    End Sub


    Private Sub StandardKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sb1.Click, sb2.Click, sb3.Click, sb4.Click, sb5.Click, sb6.Click, sb7.Click, sb8.Click, sb9.Click, sb0.Click, sbSpace.Click, sbTilde.Click, sbMinus.Click, sbEqual.Click, sbBackSlash.Click, sbForwardSlash.Click, sbLBracket.Click, sbRBracket.Click, sbSemiColon.Click, sbQuote.Click, sbComma.Click, sbPeriod.Click, sbBack.Click, sbEnter.Click, sbESC.Click, sbF1.Click, sbF2.Click, sbF3.Click, sbF4.Click, sbF5.Click, sbF6.Click, sbF7.Click, sbF8.Click, sbF9.Click, sbF10.Click, sbF11.Click, sbF12.Click, sbDEL.Click, sbREnter.Click

        Dim keyData As String = ""




        If CTRL = True Then
            keyData &= "^"
        End If

        If ALT = True Then
            keyData &= "%"
        End If

        If SHIFT = True Then
            keyData &= "+"
        End If

        Try
            If keyData <> "" Then
                SendKeys.Send(keyData & "{" & sender.buttontext & "}")
            Else
                SendKeys.Send("{" & sender.buttontext & "}")
            End If
        Catch
            SendKeys.Send(sender.buttontext)
        End Try


        ' If ALT = True Then
        'Alt_Click(sender, e)
        'End If

        If CTRL = True Then
            Ctrl_Click(sender, e)
        End If

        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

        'If WIN = True Then
        'sbLWin_Click(sender, e)
        'End If
    End Sub

    Private Sub Shift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLShift.Click, sbRShift.Click
        SHIFT = Not SHIFT

        If SHIFT = True Then
            If CAPS = False Then
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel1.Controls
                    myButton.ButtonText = myButton.Data2
                Next
            Else
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel1.Controls
                    If Not (myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText)) Then
                        myButton.ButtonText = myButton.Data2
                    End If
                Next
            End If



            sbLShift.Color = LCARS.LCARScolorStyles.PrimaryFunction
            sbRShift.Color = LCARS.LCARScolorStyles.PrimaryFunction

        Else
            If CAPS = False Then
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel1.Controls
                    myButton.ButtonText = myButton.Data
                Next
            Else
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel1.Controls
                    If Not (myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText)) Then
                        myButton.ButtonText = myButton.Data
                    End If
                Next
            End If

            sbLShift.Color = LCARS.LCARScolorStyles.SystemFunction
            sbRShift.Color = LCARS.LCARScolorStyles.SystemFunction

        End If






        'code for the buttons on the number pad.

        If SHIFT = True Then

            If btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                    myButton.ButtonText = myButton.Data2
                Next
            Else
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                    If Not (myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText)) Then
                        myButton.ButtonText = myButton.Data
                    End If
                Next

            End If


            sbLShift.Color = LCARS.LCARScolorStyles.PrimaryFunction
            sbRShift.Color = LCARS.LCARScolorStyles.PrimaryFunction

        Else
            If SHIFT = False Then
                If btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
                    For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                        myButton.ButtonText = myButton.Data
                    Next
                Else
                    For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                        If Not (myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText)) Then
                            myButton.ButtonText = myButton.Data
                        End If
                    Next
                End If

                sbLShift.Color = LCARS.LCARScolorStyles.SystemFunction
                sbRShift.Color = LCARS.LCARScolorStyles.SystemFunction

            End If
        End If
    End Sub


    Private Sub sbCaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCaps.Click

        ' Sets up the on screen and real world keyboard Caps lock on or off.
        If sbCaps.Color = LCARS.LCARScolorStyles.SystemFunction Then
            Call keybd_event(VK_CAPITAL, 0, KEYEVENTF_EXTENDEDKEY, 0)
            Call keybd_event(VK_CAPITAL, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            sbCaps.Color = LCARS.LCARScolorStyles.PrimaryFunction 'CAPS LOCK ON
        Else
            If sbCaps.Color = LCARS.LCARScolorStyles.PrimaryFunction Then
                Call keybd_event(VK_CAPITAL, 0, KEYEVENTF_EXTENDEDKEY, 0)
                Call keybd_event(VK_CAPITAL, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
                sbCaps.Color = LCARS.LCARScolorStyles.SystemFunction 'CAPS LOCK OFF
            End If
        End If





    End Sub

    Private Sub sbTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbTab.Click


        tab = Not tab

        ' Simulate key press
        Call keybd_event(VK_TAB, 0, KEYEVENTF_EXTENDEDKEY, 0)
        Call keybd_event(VK_TAB, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)



    End Sub

    Private Sub sbRwin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbRwin.MouseDown, sbLWin.MouseDown

        'Enables timer to detect short or long click & release of windows keys
        Timer3.Enabled = True

    End Sub

    Private Sub sblwin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbRwin.MouseUp, sbLWin.MouseUp

        'Short windows key click event
        WIN = Not WIN
        If Timer3.Enabled = True Then
            Call keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0)
            Call keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            Exit Sub

        Else

            'Simulates windows key click & hold.
            If WIN = True Then
                Call keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0)
                sbLWin.Color = LCARS.LCARScolorStyles.PrimaryFunction
                sbRwin.Color = LCARS.LCARScolorStyles.PrimaryFunction
                Exit Sub

            Else
                ' Simulate key release
                If sbLWin.Color = LCARS.LCARScolorStyles.PrimaryFunction Then
                    Call keybd_event(VK_PRINT, 0, KEYEVENTF_EXTENDEDKEY, 0)
                    Call keybd_event(VK_PRINT, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
                    Call keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
                    sbRwin.Color = LCARS.LCARScolorStyles.SystemFunction
                    sbLWin.Color = LCARS.LCARScolorStyles.SystemFunction

                End If
            End If

        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        Timer3.Enabled = False

    End Sub


    Private Sub Ctrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRCtrl.Click, sbLCtrl.Click

        CTRL = Not CTRL

        If CTRL = True Then
            sbLCtrl.Color = LCARS.LCARScolorStyles.PrimaryFunction
            sbRCtrl.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            sbLCtrl.Color = LCARS.LCARScolorStyles.SystemFunction
            sbRCtrl.Color = LCARS.LCARScolorStyles.SystemFunction
        End If
    End Sub

    Private Sub Alt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLAlt.Click, sbRAlt.Click

        ALT = Not ALT

        If ALT = True Then

            ' Simulate key press
            Call keybd_event(VK_ALT, 0, KEYEVENTF_EXTENDEDKEY, 0)
            sbLAlt.Color = LCARS.LCARScolorStyles.PrimaryFunction
            sbRAlt.Color = LCARS.LCARScolorStyles.PrimaryFunction
            Timer2.Enabled = True
        Else
            ' Simulate key release
            Call keybd_event(VK_ALT, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            sbLAlt.Color = LCARS.LCARScolorStyles.SystemFunction
            sbRAlt.Color = LCARS.LCARScolorStyles.SystemFunction
        End If

    End Sub

    Private Sub frmKeyboard_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        If isMoving = False Then
            If isInit = True Then SaveSetting("x32_OSK", "Settings", "Location", Me.Left & ", " & Me.Top)
        End If

    End Sub

    Private Sub frmKeyboard_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub





    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oWidth += 74
        frmKeyboard_ResizeEnd(sender, e)

    End Sub




    Public Sub resizeWorkingArea(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim myArea As New RECT
        myArea.Left_Renamed = x
        myArea.Top_Renamed = y
        myArea.Right_Renamed = x + width
        myArea.Bottom_Renamed = y + height

        Dim ptr As IntPtr = IntPtr.Zero

        ptr = Marshal.AllocHGlobal(Marshal.SizeOf(myArea))

        Marshal.StructureToPtr(myArea, ptr, False)


        Dim i As Integer = SystemParametersInfo(SPI_SETWORKAREA, Marshal.SizeOf(myArea), ptr, SPIF_change)
    End Sub

    Private Sub pnlKeyboard_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub sbDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myKey As New LCARS.Controls.StandardButton


        myKey.ButtonText = "DELETE"


        StandardKey_Click(myKey, e)

    End Sub

    Private Sub StandardButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbTitle.Click

    End Sub

    Private Sub sbTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbTitle.MouseDown
        isMoving = True
        oLoc = New Point(MousePosition.X, MousePosition.Y)

    End Sub

    Private Sub sbTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbTitle.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Left += MousePosition.X - oLoc.X


            Me.Top += MousePosition.Y - oLoc.Y

            oLoc = New Point(MousePosition.X, MousePosition.Y)
            Application.DoEvents()
        End If
    End Sub

    Private Sub sbTitle_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sbTitle.MouseUp
        isMoving = False
        frmKeyboard_Move(sender, e)

    End Sub



    Public Sub sbIncrementPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        increment += 2
        lblIncrement.Text = increment & " PIXELS"
    End Sub

    Public Sub sbIncrementMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If increment > 2 Then increment -= 2
        lblIncrement.Text = increment & " PIXELS"
    End Sub

    Public Sub sbHeightPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Me.Height += increment
        Me.Top -= increment / 2
        frmKeyboard_ResizeEnd(sender, e)



    End Sub

    Public Sub sbHeightMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Me.Height -= increment
        Me.Top += increment / 2
        frmKeyboard_ResizeEnd(sender, e)


    End Sub

    Public Sub sbWidthPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Me.Width += increment
        Me.Left -= increment / 2
        frmKeyboard_ResizeEnd(sender, e)



    End Sub

    Public Sub sbWidthMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Me.Width -= increment
        Me.Left += increment / 2
        frmKeyboard_ResizeEnd(sender, e)



    End Sub


    Private Sub sbDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmKeyboard_ResizeEnd(sender, e)
        sbNum.Color = LCARS.LCARScolorStyles.MiscFunction
        sbNum.Clickable = True
    End Sub

    Private Sub sbChangeSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbChangeSize.Click

        'Resets form from extended keyboard to standard keyboard
        If sbNum.Color = LCARS.LCARScolorStyles.StaticBlue Then
            sbNum_Click(sender, e)
            Resize_Keypad.Show()
        Else

            'Displays the resize keypad form.
            Resize_Keypad.Show()

        End If

    End Sub

    Private Sub StandardButton1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton1.Click

        If sbNum.Color = LCARS.LCARScolorStyles.MiscFunction Then
            My.Settings.Mode = False
        Else
            If sbNum.Color = LCARS.LCARScolorStyles.StaticBlue Then
                My.Settings.Mode = True
            End If
        End If

        My.Settings.Save()
        Me.Close()
        End

    End Sub

    Private Sub sbNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbNum.Click

        If sbNum.Color = LCARS.LCARScolorStyles.MiscFunction Then
            Label1.Text = SplitContainer1.SplitterDistance
            Label2.Text = SplitContainer1.Panel2.Width
            Label3.Text = Me.Width


            Me.Width = Me.Width * 0.79
            SplitContainer1.Panel2Collapsed = True
            sbNum.Color = LCARS.LCARScolorStyles.StaticBlue


        Else

            If sbNum.Color = LCARS.LCARScolorStyles.StaticBlue Then

                Me.Width = Label3.Text
                sbNum.Color = LCARS.LCARScolorStyles.MiscFunction
                SplitContainer1.SplitterDistance = Label1.Text
                SplitContainer1.Panel2Collapsed = False


            End If
        End If

    End Sub


    Private Sub sbPgUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{pgup}")
    End Sub

    Private Sub sbPgDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SendKeys.Send("{pgdn}")
    End Sub

    Private Sub sbPgUp_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub sbRForwardSlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub sbPgUp_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPgUp.Click

        SendKeys.Send("{pgup}")

    End Sub

    Private Sub sbPgDown_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPgDown.Click

        SendKeys.Send("{pgdn}")

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub StandardButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub sbBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim myfile As New OpenFileDialog
        Dim result As DialogResult

        result = myfile.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            'txtUBLoc.Text = myfile.FileName
        End If

    End Sub


    Public Sub sbLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLock.Click

        If sbFn.Clickable = True Then
            sbFn.Clickable = False
            sbFn.Color = LCARS.LCARScolorStyles.FunctionUnavailable

        Else

            sbFn.Clickable = True
            sbFn.Color = LCARS.LCARScolorStyles.StaticTan

        End If

    End Sub

    Private Sub sbFn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn.Click

        UserButtons.Show()


    End Sub

    Private Sub sbFn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn1.Click

        If sbFn.Clickable = True Then
            My.Settings.FN1Name = UserButtons.txtUBName.Text
            My.Settings.FN1Path = UserButtons.txtUBLoc.Text
            sbFn1.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN1Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub sbFn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn2.Click

        If sbFn.Clickable = True Then
            My.Settings.FN2Name = UserButtons.txtUBName.Text
            My.Settings.FN2Path = UserButtons.txtUBLoc.Text
            sbFn2.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN2Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFN3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFN3.Click

        If sbFn.Clickable = True Then
            My.Settings.FN3Name = UserButtons.txtUBName.Text
            My.Settings.FN3Path = UserButtons.txtUBLoc.Text
            sbFN3.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN3Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn4.Click

        If sbFn.Clickable = True Then
            My.Settings.FN4Name = UserButtons.txtUBName.Text
            My.Settings.FN4Path = UserButtons.txtUBLoc.Text
            sbFn4.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN4Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn5.Click

        If sbFn.Clickable = True Then
            My.Settings.FN5Name = UserButtons.txtUBName.Text
            My.Settings.FN5Path = UserButtons.txtUBLoc.Text
            sbFn5.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN5Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn6.Click

        If sbFn.Clickable = True Then
            My.Settings.FN6Name = UserButtons.txtUBName.Text
            My.Settings.FN6Path = UserButtons.txtUBLoc.Text
            sbFn6.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN6Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn7.Click

        If sbFn.Clickable = True Then
            My.Settings.FN7Name = UserButtons.txtUBName.Text
            My.Settings.FN7Path = UserButtons.txtUBLoc.Text
            sbFn7.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN7Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn8.Click

        If sbFn.Clickable = True Then
            My.Settings.FN8Name = UserButtons.txtUBName.Text
            My.Settings.FN8Path = UserButtons.txtUBLoc.Text
            sbFn8.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN8Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn9.Click

        If sbFn.Clickable = True Then
            My.Settings.FN9Name = UserButtons.txtUBName.Text
            My.Settings.FN9Path = UserButtons.txtUBLoc.Text
            sbFn9.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN9Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn10.Click

        If sbFn.Clickable = True Then
            My.Settings.FN10Name = UserButtons.txtUBName.Text
            My.Settings.FN10Path = UserButtons.txtUBLoc.Text
            sbFn10.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN10Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn11.Click

        If sbFn.Clickable = True Then
            My.Settings.FN11Name = UserButtons.txtUBName.Text
            My.Settings.FN11Path = UserButtons.txtUBLoc.Text
            sbFn11.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN11Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub sbFn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbFn12.Click

        If sbFn.Clickable = True Then
            My.Settings.FN12Name = UserButtons.txtUBName.Text
            My.Settings.FN12Path = UserButtons.txtUBLoc.Text
            sbFn12.Text = UserButtons.txtUBName.Text
            My.Settings.Save()

        Else
            If Not UserButtons.Visible = True Then
                Try
                    Shell(My.Settings.FN12Path, vbMaximizedFocus)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub Arrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abUp.Click, abDown.Click, abLeft.Click, abRight.Click

        Dim myKey As New LCARS.Controls.StandardButton

        Select Case CType(sender, LCARS.Controls.ArrowButton).ArrowDirection
            Case LCARS.LCARSarrowDirection.Up
                myKey.ButtonText = "UP"
            Case LCARS.LCARSarrowDirection.Down
                myKey.ButtonText = "DOWN"
            Case LCARS.LCARSarrowDirection.Left
                myKey.ButtonText = "LEFT"
            Case LCARS.LCARSarrowDirection.Right
                myKey.ButtonText = "RIGHT"
        End Select

        StandardKey_Click(myKey, e)

    End Sub


    Private Sub sbR9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR9.Click

        Dim keyData As String = ""
        Dim NumLockState As Boolean


        If NumLockState <> True Then

            If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
                SendKeys.Send("{pgup}")
            Else
                SendKeys.Send("{9}")
            End If


            If SHIFT = True Then
                Shift_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub sbR8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR8.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{UP}")
        Else
            SendKeys.Send("{8}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR7.Click

        Dim keyData As String = ""
        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{HOME}")
        Else
            SendKeys.Send("{7}")
        End If

        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR6.Click

        Dim keyData As String = ""
        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then

            SendKeys.Send("{RIGHT}")
        Else
            SendKeys.Send("{6}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR5.Click

        Dim keyData As String = ""
        Dim NumLockState As Boolean


        If NumLockState <> True Then

            If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
                SendKeys.Send("{5}")
            Else
                SendKeys.Send("{5}")
            End If


            If SHIFT = True Then
                Shift_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub sbR4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR4.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{LEFT}")
        Else
            SendKeys.Send("{4}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR3.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{pgdn}")
        Else
            SendKeys.Send("{3}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR2.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{DOWN}")
        Else
            SendKeys.Send("{2}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR1.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{END}")
        Else
            SendKeys.Send("{1}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR0.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{INSERT}")
        Else
            SendKeys.Send("{0}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub



    Private Sub sbRForwardSlash_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRForwardSlash.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{/}")
        Else
            SendKeys.Send("{/}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbRMultiply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRMultiply.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{*}")
        Else
            SendKeys.Send("{*}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbRMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRMinus.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{-}")
        Else
            SendKeys.Send("{-}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbRPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRPlus.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{+}")
        Else
            SendKeys.Send("{+}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbREquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbREquals.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{=}")
        Else
            SendKeys.Send("{=}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbRPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRPeriod.Click

        Dim keyData As String = ""

        If SHIFT = True And btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then
            SendKeys.Send("{.}")
        Else
            SendKeys.Send("{.}")
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub btnscrllk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrollLock.Click


        If btnScrollLock.Color = LCARS.LCARScolorStyles.SystemFunction Then

            Call keybd_event(VK_SCROLL, 0, KEYEVENTF_EXTENDEDKEY, 0)
            Call keybd_event(VK_SCROLL, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            btnScrollLock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else

            If btnScrollLock.Color = LCARS.LCARScolorStyles.PrimaryFunction Then
                Call keybd_event(VK_SCROLL, 0, KEYEVENTF_EXTENDEDKEY, 0)
                Call keybd_event(VK_SCROLL, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
                btnScrollLock.Color = LCARS.LCARScolorStyles.SystemFunction
            End If

        End If




    End Sub

    Private Sub btnnumlok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnumlock.Click

        If btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then

            Call keybd_event(VK_NUMLOCK, 0, KEYEVENTF_EXTENDEDKEY, 0)
            Call keybd_event(VK_NUMLOCK, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            Call keybd_event(VK_NUMLOCK, 0, KEYEVENTF_EXTENDEDKEY, 0)
            Call keybd_event(VK_NUMLOCK, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction
        End If

        If btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction And SHIFT = True Then

            For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                myButton.ButtonText = myButton.Data2
            Next

        Else

            If btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction And SHIFT = True Then

                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                    myButton.ButtonText = myButton.Data
                Next

            End If
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'NUMBERS LOCK DETECTION
        'If numbers lock is on, sets numbers lock button to primary colour.
        If Control.IsKeyLocked(Keys.NumLock) Then
            If btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            If btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction Then btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction
        End If

        'SCROLL LOCK DETECTION
        'If scroll lock is on, sets scroll lock button to primary colour.
        If GetKeyState(Keys.Scroll) = 1 Then
            If btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction Then btnScrollLock.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            If btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction Then btnScrollLock.Color = LCARS.LCARScolorStyles.SystemFunction
        End If

        Dim newNumLockShift As Boolean = (btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction) Xor SHIFT


        If (btnnumlock.Color = LCARS.LCARScolorStyles.SystemFunction) And SHIFT = True Then

            For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                myButton.ButtonText = myButton.Data2
            Next
        Else
            If (btnnumlock.Color = LCARS.LCARScolorStyles.PrimaryFunction) And SHIFT = True Then
                For Each myButton As LCARS.LCARSbuttonClass In SplitContainer1.Panel2.Controls
                    myButton.ButtonText = myButton.Data
                Next
            End If
        End If


        'CAPS LOCK DETECTION
        'Syncronises the real world keyboard and on screen keyboard caps lock button.
        If Control.IsKeyLocked(Keys.CapsLock) Then
            If sbCaps.Color = LCARS.LCARScolorStyles.SystemFunction Then sbCaps.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            If CAPS = False Then
                If sbCaps.Color = LCARS.LCARScolorStyles.PrimaryFunction Then sbCaps.Color = LCARS.LCARScolorStyles.SystemFunction
            End If
        End If

        'True if the letters should be uppercase, false otherwise
        Dim newuppercase As Boolean = (sbCaps.Color = LCARS.LCARScolorStyles.PrimaryFunction) Xor (sbLShift.Color = LCARS.LCARScolorStyles.PrimaryFunction)
        If newuppercase And Not uppercase Then
            For Each mybutton As LCARS.LCARSbuttonClass In SplitContainer1.Panel1.Controls
                If mybutton.ButtonText.Length = 1 And Char.IsLetter(mybutton.ButtonText) Then
                    mybutton.ButtonText = mybutton.Data2
                End If
            Next
        ElseIf uppercase And Not newuppercase Then
            For Each mybutton As LCARS.LCARSbuttonClass In SplitContainer1.Panel1.Controls
                If mybutton.ButtonText.Length = 1 And Char.IsLetter(mybutton.ButtonText) Then
                    mybutton.ButtonText = mybutton.Data
                End If
            Next
        End If
        uppercase = newuppercase 'Update stored value so we don't redraw unnecessarily

    End Sub

    Private Sub sbA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbA.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{A}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{A}")
            Else
                SendKeys.Send("{a}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbB.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{B}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{B}")
            Else
                SendKeys.Send("{b}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbC.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{C}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{C}")
            Else
                SendKeys.Send("{c}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbD.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{D}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{D}")
            Else
                SendKeys.Send("{d}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbE.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{E}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{E}")
            Else
                SendKeys.Send("{e}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbF.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{F}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{F}")
            Else
                SendKeys.Send("{f}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbG.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{G}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{G}")
            Else
                SendKeys.Send("{g}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbH.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{H}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{H}")
            Else
                SendKeys.Send("{h}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbI.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{I}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{I}")
            Else
                SendKeys.Send("{i}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbJ.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{J}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{J}")
            Else
                SendKeys.Send("{j}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbK.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{K}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{K}")
            Else
                SendKeys.Send("{k}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbL.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{L}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{L}")
            Else
                SendKeys.Send("{l}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbM.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{M}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{M}")
            Else
                SendKeys.Send("{m}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbN.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{N}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{N}")
            Else
                SendKeys.Send("{n}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbO.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{O}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{O}")
            Else
                SendKeys.Send("{o}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbP.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{P}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{P}")
            Else
                SendKeys.Send("{p}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbQ.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{Q}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{Q}")
            Else
                SendKeys.Send("{q}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbR.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{R}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{R}")
            Else
                SendKeys.Send("{r}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbS.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{S}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{S}")
            Else
                SendKeys.Send("{s}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbT.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{T}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{T}")
            Else
                SendKeys.Send("{t}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbU.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{U}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{U}")
            Else
                SendKeys.Send("{u}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbV.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{V}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{V}")
            Else
                SendKeys.Send("{v}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbW.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{W}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{W}")
            Else
                SendKeys.Send("{w}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbX.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{X}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{X}")
            Else
                SendKeys.Send("{x}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbY.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{Y}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{Y}")
            Else
                SendKeys.Send("{y}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub

    Private Sub sbZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbZ.Click

        Dim keydata As String = ""

        If CAPS = True And SHIFT = False Then
            SendKeys.Send("{Z}")
        Else
            If CAPS = False And SHIFT = True Then
                SendKeys.Send("{Z}")
            Else
                SendKeys.Send("{z}")
            End If
        End If


        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        If sbRAlt.Color = LCARS.LCARScolorStyles.PrimaryFunction Then
            Alt_Click(sender, e)
        End If
        Timer2.Enabled = False
    End Sub
End Class