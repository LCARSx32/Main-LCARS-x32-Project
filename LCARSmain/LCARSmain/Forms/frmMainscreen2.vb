Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class frmMainscreen2
    Implements IAutohide

#Region " API CALLS "

    'Constants for controling the montitor state
    Const HWND_BROADCAST As Integer = &HFFFF
    Const SC_MONITORPOWER As Integer = &HF170
    Const WM_SYSCOMMAND As Short = &H112S

    'Constants for controling apps inside LCARS x32
    Private Const SW_MINIMIZE As Integer = 6
    Private Const SW_MAXIMIZE As Integer = 3
    Private Const SW_RESTORE As Integer = 9


    'used for loading apps inside of LCARS x32
    Declare Function ShowWindow Lib "user32" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Boolean
    Declare Function SetParent Lib "user32" (ByVal hWndChild As System.IntPtr, ByVal hWndNewParent As System.IntPtr) As System.IntPtr
    Declare Function GetParent Lib "user32" (ByVal hWnd As System.IntPtr) As System.IntPtr
    'used for turning on and off screen
    Declare Function SendMessage Lib "user32" (ByVal Handle As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Public Const GWL_STYLE = -16&
    Public Const WS_DLGFRAME = &H400000



    <DllImport("User32.dll", EntryPoint:="GetWindowLong")> _
    Friend Shared Function GetWindowLong(ByVal hwnd As IntPtr, ByVal index As Integer) As Integer
    End Function

    <DllImport("User32.dll", EntryPoint:="SetWindowLong")> _
    Friend Shared Function SetWindowLong(ByVal hwnd As IntPtr, ByVal index As Integer, ByVal style As Integer) As Integer
    End Function


#End Region


    Private Declare Function GetAsyncKeyState Lib "user32" _
     (ByVal Key As Keys) As Integer


    Dim gameOn As Boolean = False
    Dim isInit As Boolean = False


    Public myBusiness As New modBusiness

#Region " AutoHide "

    Private Sub UpdateRegion()
        Dim myRegion As Region = New Region(New RectangleF(0, 0, Me.Width, Me.Height))
        Try
            Dim mainRect As New Rectangle
            mainRect.X = pnlMainBar.Left + pnlMain.Left
            mainRect.Y = pnlMainBar.Top + pnlMain.Top
            mainRect.Width = pnlMain.Width
            mainRect.Height = pnlMain.Height

            myRegion.Exclude(mainRect)
            Me.Region = myRegion
        Catch
        End Try
    End Sub

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Bottom Or IAutohide.AutohideEdges.Right
    End Function

#End Region




    Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        myBusiness.ScreenIndex = ScreenIndex
        myBusiness.init(Me)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Application.DoEvents()
        End
    End Sub


    Private Sub fbPrograms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        If pnlProgs.Visible = True Then
            pnlProgs.Visible = False
        Else
            pnlProgs.Visible = True
            pnlPrograms.Visible = True
        End If

        myBusiness.progShowing = pnlProgs.Visible
        myBusiness.userButtonsShowing = gridUserButtons.Visible

        pnlMainBar_SizeChanged(sender, e)

    End Sub


    Private Sub fbUserButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myUserButtons.Click
        If gridUserButtons.Visible = True Then
            fbUBEndcap.Visible = False
        Else
            fbUBEndcap.Visible = True
        End If


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'tmrClock_Tick(sender, e)


        pnlMainBar.Visible = False
        pnlTopPanel.Visible = False
        pnlApps.Visible = False

        Me.Bounds = Screen.AllScreens(myBusiness.ScreenIndex).Bounds
        Application.DoEvents()

        pnlMainBar.Visible = True
        pnlTopPanel.Visible = True
        pnlApps.Visible = True

        Me.Show()


        isInit = True
        pnlMainBar_SizeChanged(sender, e)
        myBusiness.mainTimer.Enabled = True
    End Sub

    'Public Sub GameLoop()
    '    Dim fireRate As Integer = 20
    '    Dim fireCount As Integer = 20
    '    Do Until gameOn = False

    '        If gameOn Then

    '            If keyPressed(Keys.A) Then
    '                If pnlEnterprise.Left > 10 Then
    '                    pnlEnterprise.Left -= 5
    '                Else
    '                    pnlEnterprise.Left = 0
    '                End If
    '            End If


    '            If keyPressed(Keys.D) Then
    '                If pnlEnterprise.Left + pnlEnterprise.Width < pnlGame.Width - 10 Then
    '                    pnlEnterprise.Left += 5
    '                Else
    '                    pnlEnterprise.Left = pnlGame.Width - pnlEnterprise.Width
    '                End If
    '            End If

    '            If keyPressed(Keys.W) Then
    '                If pnlEnterprise.Top > 10 Then
    '                    pnlEnterprise.Top -= 5
    '                Else
    '                    pnlEnterprise.Top = 0
    '                End If
    '            End If

    '            If keyPressed(Keys.S) Then
    '                If pnlEnterprise.Top + pnlEnterprise.Height < pnlGame.Height - 10 Then
    '                    pnlEnterprise.Top += 5
    '                Else
    '                    pnlEnterprise.Top = pnlGame.Height - pnlEnterprise.Height
    '                End If
    '            End If

    '            If keyPressed(Keys.Space) Then
    '                If fireCount = fireRate Then
    '                    Beep()
    '                    fireCount = 0
    '                Else
    '                    fireCount += 1
    '                End If
    '            End If
    '        End If

    '        Threading.Thread.Sleep(10)
    '    Loop

    'End Sub

    Private Function keyPressed(ByVal keycode As Keys) As Boolean
        If GetAsyncKeyState(keycode) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub abExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abExpand.Click
        If abExpand.ArrowDirection = LCARS.LCARSarrowDirection.Up Then
            pnlTopPanel.Visible = False

            fbTL.Visible = True
            sbTL.Visible = True
            fbTL.BringToFront()
            myBusiness.myClock = fbTL


            pnlApps.Top = 5
            pnlTray.Top = 5

            pnlMainBar.Top = pnlApps.Top + pnlApps.Height + 6
            pnlMainBar.Height = Me.ClientRectangle.Height - pnlMainBar.Top

            abExpand.ArrowDirection = LCARS.LCARSarrowDirection.Down

            'abExpand.Width = sbTL.Width
            'abExpand.Left = fbUBRight.Right - abExpand.Width

            pnlTray.Left = (sbTL.Left - pnlTray.Width) - 6
            pnlApps.Width = pnlTray.Left - pnlApps.Left

        Else
            fbTL.Visible = False
            sbTL.Visible = False
            myBusiness.myClock = Me.myClock

            pnlApps.Top = (pnlTopPanel.Height - pnlApps.Height)
            pnlTray.Top = pnlApps.Top

            pnlMainBar.Top = pnlTopPanel.Height + 6
            pnlMainBar.Height = (Me.ClientRectangle.Height - pnlMainBar.Top)

            pnlTopPanel.Visible = True

            abExpand.ArrowDirection = LCARS.LCARSarrowDirection.Up

            pnlTray.Left = pnlTopPanel.Width - pnlTray.Width - 40
            pnlApps.Width = pnlTray.Left - pnlApps.Left
        End If
    End Sub

    'Private Sub sbNeutral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If pnlMyApp.Visible = False Then
    '        gameOn = True
    '        Dim mythread As Threading.Thread = New Threading.Thread(AddressOf GameLoop)
    '        mythread.Start()
    '        pnlMyApp.Visible = True
    '        pnlMyApp.BringToFront()
    '        sbNeutral.Flash = False
    '    Else
    '        pnlMyApp.Visible = False
    '        sbNeutral.Flash = True
    '        gameOn = False
    '    End If
    'End Sub

    'Private Sub abMyApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    pnlMyApp.Visible = False
    '    sbNeutral.Flash = True
    '    gameOn = False

    'End Sub

    'Private Sub pnlGame_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.WindowState <> FormWindowState.Minimized Then
    '        If gameOn Then
    '            If Not pnlEnterprise.Left > 0 Then
    '                pnlEnterprise.Left = 0
    '            End If

    '            If Not pnlEnterprise.Left + pnlEnterprise.Width < pnlGame.Width Then
    '                pnlEnterprise.Left = pnlGame.Width - pnlEnterprise.Width
    '            End If

    '            If Not pnlEnterprise.Top > 10 Then
    '                pnlEnterprise.Top = 0
    '            End If

    '            If Not pnlEnterprise.Top + pnlEnterprise.Height < pnlGame.Height Then
    '                pnlEnterprise.Top = pnlGame.Height - pnlEnterprise.Height
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub pnlGame_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If pnlGame.Visible = True Then
    '        gameOn = True
    '        tmrGame.Enabled = True
    '        Dim myGameLoop As Threading.Thread
    '        myGameLoop = New Threading.Thread(AddressOf GameLoop)
    '        myGameLoop.Start()

    '    Else
    '        gameOn = False
    '        tmrGame.Enabled = True
    '    End If
    'End Sub

    'Private Sub tmrGame_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGame.Tick
    '    Static intCount As Integer = 0
    '    If pnlWarBird.Top < pnlGame.Height Then
    '        pnlWarBird.Top += 1

    '        If intCount = 100 Then
    '            For Each myControl As LCARS.LCARSbuttonClass In pnlWarBird.Controls
    '                myControl.Lit = False
    '                Application.DoEvents()
    '            Next
    '            pnlWarBird.Visible = True
    '            intCount += 1

    '        ElseIf intCount = 200 Then
    '            pnlWarBird.Visible = False
    '            For Each myControl As LCARS.LCARSbuttonClass In pnlWarBird.Controls
    '                myControl.Lit = True
    '                Application.DoEvents()
    '            Next
    '            pnlWarBird.Visible = True
    '            intCount += 1

    '        ElseIf intCount = 300 Then
    '            pnlWarBird.Visible = False
    '            For Each myControl As LCARS.LCARSbuttonClass In pnlWarBird.Controls
    '                myControl.Lit = False
    '                Application.DoEvents()
    '            Next
    '            pnlWarBird.Visible = True
    '            intCount += 1
    '        ElseIf intCount = 400 Then
    '            pnlWarBird.Visible = False
    '            intCount = 0
    '        Else
    '            intCount += 1
    '        End If
    '    Else
    '        pnlWarBird.Top = -pnlWarBird.Height

    '    End If
    'End Sub

    Private Sub fbProgBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbProgBack.Click
        myBusiness.ProgBack()
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If isInit = True Then
            Dim myRect As New Rectangle

            If myBusiness.progShowing Then
                myRect.X = pnlProgs.Right + 6
            Else
                myRect.X = 6
            End If

            If myBusiness.userButtonsShowing Then
                myRect.Width = (gridUserButtons.Left - 6) - myRect.X
            Else
                myRect.Width = (fbBarRight.Left - 6) - myRect.X
            End If



            myRect.Y = pnlMainTop.Bottom + 6
            myRect.Height = (fbMainLower.Top - 6) - myRect.Y

            pnlMain.Bounds = myRect

            UpdateRegion()
        End If
    End Sub

    Private Sub abProgsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abProgsNext.Click
        myBusiness.nextProgPage()
    End Sub

    Private Sub abProgsBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abProgsBack.Click
        myBusiness.previousProgPage()
    End Sub

    Private Sub pnlMainElbow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainElbow.Resize
        fbMain1.Width = myClock.Left - 6
        fbMain2.Width = pnlMainElbow.Width - (myClock.Right + 6)
        fbMain2.Left = myClock.Right + 6
    End Sub

    Private Sub myEngineering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myEngineering.Click, mySettings.Click, myPhoto.Click, myDocuments.Click, myPictures.Click, myComp.Click, myVideos.Click, fbWebBrowser.Click, myRun.Click, myMusic.Click
        If pnlPrograms.Visible Then
            fbPrograms_Click(sender, e)
        End If
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen2
        End Get
    End Property
End Class
