
Public Class frmMainscreen4
    Implements IAutohide
    Dim isInit As Boolean = False
    Public myBusiness As New modBusiness

#Region " AutoHide "

    Public autohide As IAutohide.AutoHideModes = IAutohide.AutoHideModes.Disabled
    Dim hideCount As Integer = 0


    Private Function FindRoot(ByVal hWnd As Int32) As Int32
        Do
            Dim parent_hwnd As Int32 = GetParent(hWnd)
            If parent_hwnd = 0 Then Return hWnd
            hWnd = parent_hwnd
        Loop
    End Function

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

    Public Sub SetAutoHide(ByVal value As IAutohide.AutoHideModes) Implements IAutohide.SetAutoHide
        autohide = value
        If autohide = IAutohide.AutoHideModes.Disabled Then
            tmrAutoHide.Enabled = False
            hideCount = 0
            ' pnlMainBar.Height = Me.Height
            pnlMainBar_SizeChanged(New Object, New System.EventArgs)
            Me.Visible = True
        Else
            tmrAutoHide.Enabled = True
        End If
    End Sub

    Private Sub tmrAutoHide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAutoHide.Tick
        If Not autohide = IAutohide.AutoHideModes.Disabled Then
            Dim myPoint As POINTAPI
            myPoint.X = MousePosition.X
            myPoint.Y = MousePosition.Y

            Dim rootHwnd As IntPtr = FindRoot(WindowFromPoint(myPoint))

            If rootHwnd = Me.Handle Or _
             myPoint.Y < 1 Or _
             myBusiness.progShowing = True Or myBusiness.userButtonsShowing = True Then

                hideCount = 0
                ' pnlMainBar.Height = Me.Height
                pnlMainBar_SizeChanged(sender, e)
                Me.Visible = True

            End If


            If hideCount <= 30 Then
                hideCount += 1
            Else
                autohide = IAutohide.AutoHideModes.Hidden
                pnlMain.Bounds = Screen.AllScreens(myBusiness.ScreenIndex).Bounds
                UpdateRegion()
                Me.Visible = False
                ' pnlMainBar.Height = Screen.AllScreens(modBusiness.ScreenIndex).Bounds.Height + 70
            End If
        Else
            tmrAutoHide.Enabled = False
        End If

    End Sub

#End Region


    Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        myBusiness.ScreenIndex = ScreenIndex
        myBusiness.init(Me)
    End Sub


    Private Sub frmMainscreen3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.AllScreens(myBusiness.ScreenIndex).Bounds
        '  Me.WindowState = FormWindowState.Maximized
        Me.Show()
        AddHandler myBusiness.programsPageDataChanged, AddressOf programDataChanged

        Application.DoEvents()
        'AddHandler modBusiness.programsPageDataChanged, AddressOf programDataChanged


        myBusiness.mainTimer.Enabled = True
        isInit = True

        pnlMainBar_SizeChanged(New Object, New System.EventArgs)
    End Sub
    Private Sub programDataChanged(ByVal data As String)
        fbProgramPages.ButtonText = data
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If isInit = True Then

            If Me.WindowState <> FormWindowState.Minimized Then

                Dim MainWidth As Integer
                Dim mainHeight As Integer
                Dim mainLeft As Integer
                Dim mainTop As Integer

                MainWidth = pnlMainBar.Width

                mainHeight = Screen.AllScreens(myBusiness.ScreenIndex).Bounds.Height - (myStartMenu.Bottom + 12)
                mainLeft = 0
                mainTop = myStartMenu.Bottom + 6

                If myBusiness.progShowing And myBusiness.userButtonsShowing = False Then
                    MainWidth = pnlMainBar.Width - (pnlProgs.Right + 6)
                    mainLeft = pnlProgs.Right + 6
                ElseIf myBusiness.userButtonsShowing And myBusiness.progShowing = False Then
                    MainWidth = pnlUserButtons.Left - 6
                    mainLeft = 0
                ElseIf myBusiness.userButtonsShowing And myBusiness.progShowing Then
                    MainWidth = (pnlUserButtons.Left - 6) - (pnlProgs.Right + 6)
                    mainLeft = pnlProgs.Right + 6
                End If

                'If ProgShowing Then
                '    MainWidth -= pnlProgs.Right + 7 'pnlUserButtons.Right - (pnlProgs.Right + 10)
                '    mainLeft = pnlProgs.Right + 10
                'End If

                'If UserButtonsShowing Then
                '    MainWidth -= pnlUserButtons.Width + 10
                'End If


                pnlMain.Width = MainWidth
                pnlMain.Height = mainHeight
                pnlMain.Left = mainLeft
                pnlMain.Top = mainTop


                pnlMainBar.Visible = True

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

            End If

        End If

    End Sub


    Private Sub myStartMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        If pnlProgs.Visible = True Then
            pnlProgs.Visible = False
        Else
            pnlProgs.Visible = True
            pnlPrograms.Visible = True
        End If

        myBusiness.progShowing = pnlProgs.Visible
        myBusiness.userButtonsShowing = pnlUserButtons.Visible
        pnlMainBar_SizeChanged(sender, e)
    End Sub

    Private Sub myProgsBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myProgsBack.Click
        myBusiness.previousProgPage()

    End Sub

    Private Sub myProgsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myProgsNext.Click
        myBusiness.nextProgPage()

    End Sub

    Private Sub myProgBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myProgBack.Click
        myBusiness.ProgBack()

    End Sub

    Private Sub frmMainscreen3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        hideCount = 0
    End Sub


End Class