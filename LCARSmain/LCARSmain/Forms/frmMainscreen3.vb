
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
        '  Me.WindowState = FormWindowState.Maximized
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

                'If ProgShowing Then
                '    MainWidth -= pnlProgs.Right + 7 'pnlUserButtons.Right - (pnlProgs.Right + 10)
                '    mainLeft = pnlProgs.Right + 10
                'End If

                'If UserButtonsShowing Then
                '    MainWidth -= pnlUserButtons.Width + 10
                'End If

                pnlMain.Top = 32
                pnlMain.Height = Me.Height - 64
                pnlMain.Width = MainWidth
                pnlMain.Left = mainLeft

                pnlMainBar.Visible = True

                UpdateRegion()

            End If

        End If

    End Sub

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


    Private Sub myProgsBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myProgsBack.Click
        modBusiness.previousProgPage()

    End Sub

    Private Sub myProgsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myProgsNext.Click
        modBusiness.nextProgPage()

    End Sub

    Private Sub myProgBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myProgBack.Click
        modBusiness.ProgBack()

    End Sub

    'Private Sub pnlApps_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles pnlApps.ControlAdded
    '    UpdateWidth()
    'End Sub

    'Private Sub pnlApps_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles pnlApps.ControlRemoved
    '    UpdateWidth()
    'End Sub

    'Private Sub UpdateWidth()
    '    pnlApps.Width = (((pnlApps.Controls.Count - 2) / 2) * 134) + 60
    'End Sub


    Private Sub myPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myPhoto.Click, fbWebBrowser.Click, myRun.Click
        If myStartMenu.Visible Then
            myStartMenu.doClick(sender, e)
        End If
    End Sub

    Private Sub StandardButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardButton1.Click
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