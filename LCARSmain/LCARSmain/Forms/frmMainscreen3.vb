
Public Class frmMainscreen3
    Implements IAutohide
    Dim isInit As Boolean = False
    Public modBusiness As New modBusiness

#Region " AutoHide "

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Bottom
    End Function

#End Region

    Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        modBusiness.ScreenIndex = ScreenIndex
        modBusiness.init(Me)
    End Sub


    Private Sub frmMainscreen3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.AllScreens(modBusiness.ScreenIndex).Bounds
        Me.Show()

        Application.DoEvents()

        modBusiness.mainTimer.Enabled = True
        isInit = True

        pnlMainBar_SizeChanged(New Object, New System.EventArgs)


    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If isInit = True Then

            If Me.WindowState <> FormWindowState.Minimized Then

                Dim MainWidth As Integer
                Dim mainLeft As Integer

                MainWidth = pnlMainBar.Width
                mainLeft = 0

                If modBusiness.progShowing And modBusiness.userButtonsShowing = False Then
                    MainWidth = pnlMainBar.Width - (pnlProgs.Right + 6)
                    mainLeft = pnlProgs.Right + 6
                ElseIf modBusiness.userButtonsShowing And modBusiness.progShowing = False Then
                    MainWidth = gridUserButtons.Left - 6
                    mainLeft = 0
                ElseIf modBusiness.userButtonsShowing And modBusiness.progShowing Then
                    MainWidth = (gridUserButtons.Left - 6) - (pnlProgs.Right + 6)
                    mainLeft = pnlProgs.Right + 6
                End If

                'We can use pnlProgs because it's anchored.
                pnlMain.Top = pnlProgs.Top
                pnlMain.Height = pnlProgs.Height
                pnlMain.Width = MainWidth
                pnlMain.Left = mainLeft

                pnlMainBar.Visible = True

                modBusiness.UpdateRegion()

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

        modBusiness.progShowing = pnlProgs.Visible
        modBusiness.userButtonsShowing = gridUserButtons.Visible
        pnlMainBar_SizeChanged(sender, e)
    End Sub



    Private Sub myDeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myDeactivate.Click, myDestruct.Click, myAlert.Click, myModeSelect.Click, myEngineering.Click, MyComp.Click, mySettings.Click
        myStartMenu.doClick(sender, e)
    End Sub

    Private Sub myPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myPhoto.Click, fbWebBrowser.Click, myRun.Click
        If myStartMenu.Visible Then
            myStartMenu.doClick(sender, e)
        End If
    End Sub

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        myStartMenu.doClick(sender, e)
    End Sub

    Private Sub myVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myVideos.Click, myMusic.Click
        If pnlProgs.Visible Then myStartMenu.doClick(sender, e)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen3
        End Get
    End Property
End Class