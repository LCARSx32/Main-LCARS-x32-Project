Imports System.Runtime.InteropServices

Public Class frmKeyboard

#Region " Send Windows Key "

    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Const WM_KEYDOWN = &H100
    Const WM_KEYUP = &H101
    Const VK_RETURN = &HD

    Private Const KEYEVENTF_EXTENDEDKEY As Long = &H1
    Private Const KEYEVENTF_KEYUP As Long = &H2
    Private Const VK_LWIN As Byte = &H5B

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

    Dim buttons As New Collection
    Dim oWidth As Integer
    Dim oHeight As Integer
    Dim isInit As Boolean = False

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

    Private Sub StandardKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbA.Click, sbB.Click, sbC.Click, sbD.Click, sbE.Click, sbF.Click, sbG.Click, sbH.Click, sbI.Click, sbJ.Click, sbK.Click, sbL.Click, sbM.Click, sbN.Click, sbO.Click, sbP.Click, sbQ.Click, sbR.Click, sbS.Click, sbT.Click, sbU.Click, sbV.Click, sbW.Click, sbX.Click, sbY.Click, sbZ.Click, sb1.Click, sb2.Click, sb3.Click, sb4.Click, sb5.Click, sb6.Click, sb7.Click, sb8.Click, sb9.Click, sb0.Click, sbSpace.Click, sbTilde.Click, sbMinus.Click, sbEqual.Click, sbBackSlash.Click, sbForwardSlash.Click, sbLBracket.Click, sbRBracket.Click, sbSemiColon.Click, sbQuote.Click, sbComma.Click, sbPeriod.Click, sbTab.Click, sbBack.Click, sbEnter.Click, sbESC.Click, sbF1.Click, sbF2.Click, sbF3.Click, sbF4.Click, sbF5.Click, sbF6.Click, sbF7.Click, sbF8.Click, sbF9.Click, sbF10.Click, sbF11.Click, sbF12.Click

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


        If ALT = True Then
            Alt_Click(sender, e)
        End If

        If CTRL = True Then
            Ctrl_Click(sender, e)
        End If

        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

        If WIN = True Then
            sbLWin_Click(sender, e)
        End If
    End Sub

    Private Sub Shift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLShift.Click, sbRShift.Click
        SHIFT = Not SHIFT

        If SHIFT = True Then
            If CAPS = False Then
                For Each myButton As LCARS.LCARSbuttonClass In pnlKeyboard.Controls
                    myButton.ButtonText = myButton.Data2
                Next
            Else
                For Each myButton As LCARS.LCARSbuttonClass In pnlKeyboard.Controls
                    If Not (myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText)) Then
                        myButton.ButtonText = myButton.Data2
                    End If
                Next
            End If

            sbLShift.Color = LCARS.LCARScolorStyles.PrimaryFunction
            sbRShift.Color = LCARS.LCARScolorStyles.PrimaryFunction

        Else
            If CAPS = False Then
                For Each myButton As LCARS.LCARSbuttonClass In pnlKeyboard.Controls
                    myButton.ButtonText = myButton.Data
                Next
            Else
                For Each myButton As LCARS.LCARSbuttonClass In pnlKeyboard.Controls
                    If Not (myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText)) Then
                        myButton.ButtonText = myButton.Data
                    End If
                Next
            End If

            sbLShift.Color = LCARS.LCARScolorStyles.SystemFunction
            sbRShift.Color = LCARS.LCARScolorStyles.SystemFunction

        End If

    End Sub




    Private Sub sbCaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCaps.Click
        CAPS = Not CAPS

        If SHIFT = True Then
            Shift_Click(sender, e)
        End If

        If CAPS = True Then
            For Each myButton As LCARS.LCARSbuttonClass In pnlKeyboard.Controls
                If myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText) Then
                    myButton.ButtonText = myButton.Data2
                End If

            Next
            sbCaps.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            For Each myButton As LCARS.LCARSbuttonClass In pnlKeyboard.Controls
                If myButton.ButtonText.Length = 1 And Char.IsLetter(myButton.ButtonText) Then
                    myButton.ButtonText = myButton.Data
                End If

            Next
            sbCaps.Color = LCARS.LCARScolorStyles.SystemFunction
        End If
    End Sub

    Private Sub sbLWin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLWin.Click


        WIN = Not WIN

        If WIN = True Then
            ' Simulate key press
            Call keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0)
            sbLWin.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
            ' Simulate key release
            Call keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
            sbLWin.Color = LCARS.LCARScolorStyles.SystemFunction
        End If





    End Sub

   
    'Private Sub tmrLastActive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLastActive.Tick
    '    If GetForegroundWindow <> Me.Handle Then
    '        foreWindow = GetForegroundWindow
    '    End If
    'End Sub


    Private Sub frmKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oWidth = pnlKeyboard.Width
        oHeight = pnlKeyboard.Height


        ' style of window?
        Dim GWL_EXSTYLE As Integer = (-20)
        ' get - retrieves information about a specified window
        GetWindowLong(Me.Handle, GWL_EXSTYLE)
        ' set - changes the attribute of a specified window - I think this stops it being focused on
        SetWindowLong(Me.Handle, GWL_EXSTYLE, &H8000000)
      
        For Each myButton As Control In pnlKeyboard.Controls
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
        Me.Show()

        Me.Left = split(0)
        Me.Top = split(1)

        isInit = True

        frmKeyboard_ResizeEnd(sender, e)

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
            sbLAlt.Color = LCARS.LCARScolorStyles.PrimaryFunction
            sbRAlt.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Else
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

    Private Sub frmKeyboard_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim newWidth As Double = pnlKeyboard.Width / oWidth
        Dim newHeight As Double = pnlKeyboard.Height / oHeight

        pnlKeyboard.Visible = False

        For i As Integer = 1 To buttons.Count
            buttons(i).Control.Left = buttons(i).left * newWidth
            buttons(i).control.top = buttons(i).top * newHeight
            buttons(i).Control.Width = buttons(i).width * newWidth
            buttons(i).Control.Height = buttons(i).height * newHeight
        Next

        pnlKeyboard.Visible = True

        SaveSetting("x32_OSK", "Settings", "Size", Me.Width & ", " & Me.Height)


    End Sub

    Private Sub sbRwin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRwin.Click

    End Sub

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oWidth += 74
        frmKeyboard_ResizeEnd(sender, e)

    End Sub

   

    Private Sub Arrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abUp.Click, abDown.Click, abRight.Click, abLeft.Click

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

    Private Sub pnlKeyboard_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlKeyboard.Paint

    End Sub

    Private Sub sbDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDEL.Click
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

   

    Private Sub sbIncrementPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbIncrementPlus.Click
        increment += 2
        lblincrement.text = increment & " PIXELS"
    End Sub

    Private Sub sbIncrementMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbIncrementMinus.Click
        If increment > 2 Then increment -= 2
        lblIncrement.Text = increment & " PIXELS"
    End Sub

    Private Sub sbHeightPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbHeightPlus.Click
        Me.Height += increment
        Me.Top -= increment / 2
        frmKeyboard_ResizeEnd(sender, e)

    End Sub

    Private Sub sbHeightMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbHeightMinus.Click
        Me.Height -= increment
        Me.Top += increment / 2
        frmKeyboard_ResizeEnd(sender, e)

    End Sub

    Private Sub sbWidthPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbWidthPlus.Click
        Me.Width += increment
        Me.Left -= increment / 2
        frmKeyboard_ResizeEnd(sender, e)
    End Sub

    Private Sub sbWidthMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbWidthMinus.Click
        Me.Width -= increment
        Me.Left += increment / 2
        frmKeyboard_ResizeEnd(sender, e)

    End Sub

   
    Private Sub sbDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDone.Click
        frmKeyboard_ResizeEnd(sender, e)
        pnlResize.Visible = False
    End Sub

    Private Sub sbChangeSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbChangeSize.Click
        pnlResize.Visible = True

    End Sub

    Private Sub StandardButton1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton1.Click
        Me.Close()

    End Sub
End Class