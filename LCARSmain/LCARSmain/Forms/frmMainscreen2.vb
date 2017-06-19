Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class frmMainscreen2
    Implements IAutohide

    Dim isInit As Boolean = False
    Public myBusiness As New modBusiness

#Region " AutoHide "

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Bottom Or IAutohide.AutohideEdges.Right
    End Function

#End Region

    Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        myBusiness.ScreenIndex = ScreenIndex
        myBusiness.init(Me)
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

            'abExpand.Width = sbTL.Width
            'abExpand.Left = fbUBRight.Right - abExpand.Width

            pnlTray.Left = (sbTL.Left - pnlTray.Width) - 6
            pnlApps.Width = pnlTray.Left - pnlApps.Left

        Else
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

    Private Sub pnlMainBar_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainBar.SizeChanged
        If isInit = True Then
            Dim myRect As New Rectangle

            If myBusiness.progShowing Then
                myRect.X = pnlProgs.Right + 6
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
