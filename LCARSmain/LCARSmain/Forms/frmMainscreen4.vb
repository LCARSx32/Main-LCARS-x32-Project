
Public Class frmMainscreen4
    Implements IAutohide
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
        Return IAutohide.AutohideEdges.Top
    End Function

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

        Application.DoEvents()
        'AddHandler modBusiness.programsPageDataChanged, AddressOf programDataChanged


        myBusiness.mainTimer.Enabled = True
        isInit = True

        pnlMainBar_SizeChanged(New Object, New System.EventArgs)
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
                    MainWidth = gridUserButtons.Left - 6
                    mainLeft = 0
                ElseIf myBusiness.userButtonsShowing And myBusiness.progShowing Then
                    MainWidth = (gridUserButtons.Left - 6) - (pnlProgs.Right + 6)
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
        myBusiness.userButtonsShowing = gridUserButtons.Visible
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

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen4
        End Get
    End Property
End Class