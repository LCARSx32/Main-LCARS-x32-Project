Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class frmMainscreen2
    Implements IAutohide

    Private myBusiness As modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Bottom Or IAutohide.AutohideEdges.Right
    End Function

    Public Sub New(ByVal b As modBusiness)
        InitializeComponent()
        Me.myBusiness = b
    End Sub

    Private Sub myStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlStart.Visible = Not pnlStart.Visible
        myBusiness.progShowing = pnlStart.Visible
        myBusiness.userButtonsShowing = gridUserButtons.Visible
        pnlMainBar_SizeChanged(sender, e)
    End Sub

    Private Sub fbUserButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myUserButtons.Click
        fbUBEndcap.Visible = Not gridUserButtons.Visible
    End Sub

    Private Sub abExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abExpand.Click
        If abExpand.ArrowDirection = LCARS.LCARSarrowDirection.Up Then
            pnlTopPanel.Visible = False
            sbTL.Visible = True
            myBusiness.myClock = sbTL

            pnlApps.Top = 0
            pnlTray.Top = 0

            pnlMainBar.Top = pnlApps.Top + pnlApps.Height + 6
            pnlMainBar.Height = Me.ClientRectangle.Height - pnlMainBar.Top

            abExpand.ArrowDirection = LCARS.LCARSarrowDirection.Down

            pnlTray.Left = (sbTL.Left - pnlTray.Width) - 6
            pnlApps.Width = pnlTray.Left - pnlApps.Left

        Else
            sbTL.Visible = False
            pnlTopPanel.Visible = True
            myBusiness.myClock = myClock

            pnlApps.Top = (pnlTopPanel.Height - pnlApps.Height)
            pnlTray.Top = pnlApps.Top

            pnlMainBar.Top = pnlTopPanel.Height + 6
            pnlMainBar.Height = (Me.ClientRectangle.Height - pnlMainBar.Top)

            abExpand.ArrowDirection = LCARS.LCARSarrowDirection.Up

            pnlTray.Left = pnlTopPanel.Width - pnlTray.Width - 40
            pnlApps.Width = pnlTray.Left - pnlApps.Left
        End If
    End Sub

    Private Sub pnlMainBar_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If myBusiness IsNot Nothing AndAlso myBusiness.isInit Then
            Dim myRect As New Rectangle

            If myBusiness.progShowing Then
                myRect.X = pnlStart.Right + 6
            Else
                myRect.X = 0
            End If

            If myBusiness.userButtonsShowing Then
                myRect.Width = (gridUserButtons.Left - 6) - myRect.X
            Else
                myRect.Width = (fbBarRight.Left - 6) - myRect.X
            End If

            myRect.Y = pnlMainTop.Bottom + 6
            myRect.Height = (fbMainLower.Top - 6) - myRect.Y

            pnlMain.Bounds = myRect
            myBusiness.UpdateRegion()
        End If
    End Sub

    Private Sub pnlMainElbow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainElbow.Resize
        fbMain1.Width = myClock.Left - 6
        fbMain2.Width = pnlMainElbow.Width - (myClock.Right + 6)
        fbMain2.Left = myClock.Right + 6
    End Sub

    Private Sub startMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myEngineering.Click, mySettings.Click, myPhoto.Click, myDocuments.Click, myPictures.Click, myComp.Click, myVideos.Click, fbWebBrowser.Click, myRun.Click, myMusic.Click
        If pnlPrograms.Visible Then myStart_Click(sender, e)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen2
        End Get
    End Property
End Class
