
Public Class frmMainscreen3
    Implements IAutohide

    Private myBusiness As modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Bottom
    End Function

    Public Sub New(ByVal b As modBusiness)
        InitializeComponent()
        Me.myBusiness = b
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If myBusiness IsNot Nothing AndAlso myBusiness.isInit Then
            Dim MainWidth As Integer = pnlMainBar.Width
            Dim mainLeft As Integer = 0

            If myBusiness.progShowing And Not myBusiness.userButtonsShowing Then
                MainWidth = pnlMainBar.Width - (pnlStart.Right + 6)
                mainLeft = pnlStart.Right + 6
            ElseIf myBusiness.userButtonsShowing And Not myBusiness.progShowing Then
                MainWidth = gridUserButtons.Left - 6
                mainLeft = 0
            ElseIf myBusiness.userButtonsShowing And myBusiness.progShowing Then
                MainWidth = (gridUserButtons.Left - 6) - (pnlStart.Right + 6)
                mainLeft = pnlStart.Right + 6
            End If

            'We can use pnlStart because it's anchored.
            pnlMain.Bounds = New Rectangle(mainLeft, pnlStart.Top, MainWidth, pnlStart.Height)
            myBusiness.UpdateRegion()
        End If
    End Sub

    Private Sub myStartMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlStart.Visible = Not pnlStart.Visible
        myBusiness.progShowing = pnlStart.Visible
        myBusiness.userButtonsShowing = gridUserButtons.Visible
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