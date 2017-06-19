
Public Class frmMainscreen4
    Implements IAutohide
    Dim isInit As Boolean = False
    Public myBusiness As New modBusiness

#Region " AutoHide "

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
        Me.Show()

        Application.DoEvents()

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

                mainHeight = Screen.AllScreens(myBusiness.ScreenIndex).Bounds.Height - (myStartMenu.Bottom + 6)
                mainLeft = 0
                mainTop = myStartMenu.Bottom + 6

                If myBusiness.progShowing And Not myBusiness.userButtonsShowing Then
                    MainWidth = pnlMainBar.Width - (pnlProgs.Right + 6)
                    mainLeft = pnlProgs.Right + 6
                ElseIf myBusiness.userButtonsShowing And Not myBusiness.progShowing Then
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

                myBusiness.UpdateRegion()
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

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen4
        End Get
    End Property
End Class