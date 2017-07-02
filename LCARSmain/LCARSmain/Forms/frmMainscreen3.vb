
Public Class frmMainscreen3
    Implements IAutohide
    Dim isInit As Boolean = False
    Public modBusiness As New modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Bottom
    End Function

    Public Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        modBusiness.ScreenIndex = ScreenIndex
        modBusiness.init(Me)
    End Sub

    Private Sub frmMainscreen3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.AllScreens(modBusiness.ScreenIndex).Bounds
        Me.Show()
        Application.DoEvents()
        isInit = True
        pnlMainBar_SizeChanged(New Object, New System.EventArgs)
        modBusiness.mainTimer.Enabled = True
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If isInit Then
            Dim MainWidth As Integer = pnlMainBar.Width
            Dim mainLeft As Integer = 0

            If modBusiness.progShowing And Not modBusiness.userButtonsShowing Then
                MainWidth = pnlMainBar.Width - (pnlProgs.Right + 6)
                mainLeft = pnlProgs.Right + 6
            ElseIf modBusiness.userButtonsShowing And Not modBusiness.progShowing Then
                MainWidth = gridUserButtons.Left - 6
                mainLeft = 0
            ElseIf modBusiness.userButtonsShowing And modBusiness.progShowing Then
                MainWidth = (gridUserButtons.Left - 6) - (pnlProgs.Right + 6)
                mainLeft = pnlProgs.Right + 6
            End If

            'We can use pnlProgs because it's anchored.
            pnlMain.Bounds = New Rectangle(mainLeft, pnlProgs.Top, MainWidth, pnlProgs.Height)
            modBusiness.UpdateRegion()
        End If
    End Sub

    Private Sub myStartMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlProgs.Visible = Not pnlProgs.Visible
        modBusiness.progShowing = pnlProgs.Visible
        modBusiness.userButtonsShowing = gridUserButtons.Visible
        pnlMainBar_SizeChanged(sender, e)
    End Sub

    Private Sub startMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myDeactivate.Click, myDestruct.Click, myAlert.Click, myModeSelect.Click, myEngineering.Click, MyComp.Click, mySettings.Click, myPhoto.Click, fbWebBrowser.Click, myRun.Click, myVideos.Click, myMusic.Click, myDocuments.Click, myPictures.Click
        If myStartMenu.Visible Then myStartMenu.doClick(sender, e)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen3
        End Get
    End Property
End Class