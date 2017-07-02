Public Class frmMainscreen1
    Implements IAutohide

    Dim isInit As Boolean
    Public myBusiness As New modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Left
    End Function

    Public Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        myBusiness.ScreenIndex = ScreenIndex
        myBusiness.init(Me)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.AllScreens(myBusiness.ScreenIndex).Bounds
        Me.Show()
        Application.DoEvents()
        isInit = True
        pnlMainBar_Resize(sender, e)
        myBusiness.mainTimer.Enabled = True
    End Sub

    Private Sub myStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlStart.Visible = Not pnlStart.Visible
        If pnlStart.Visible Then
            fbBlock.Visible = False
            elbStart.Visible = True
            Application.DoEvents()
            pnlMainContainer.Width = Me.Width - pnlStart.Width
            pnlMainContainer.Left = pnlStart.Width
            pnlStart.BringToFront()
        Else
            elbStart.Visible = False
            fbBlock.Visible = True
            Application.DoEvents()
            pnlMainContainer.Width = Me.Width
            pnlMainContainer.Left = 0
        End If
        pnlMainBar_Resize(sender, e)
    End Sub

    Private Sub pnlMainContainer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainContainer.Resize
        pnlMainBar_Resize(sender, e)
    End Sub

    Private Sub ArrowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton1.Click
        If Not pnlMainBar.Top = 0 Then
            pnlMainBar.Top = 0
            myClock.Visible = False
            pnlMainBar.Height = Me.Height
            ArrowButton1.ArrowDirection = LCARS.LCARSarrowDirection.Down
            myBusiness.myClock = fbClock
        Else
            pnlMainBar.Top = Elbow2.Bottom + 6
            pnlMainBar.Height = Me.Height - Elbow2.Bottom - 6
            myClock.Visible = True
            ArrowButton1.ArrowDirection = LCARS.LCARSarrowDirection.Up
            myBusiness.myClock = myClock
            fbClock.ButtonText = "X32"
        End If
    End Sub

    Private Sub startMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myPictures.Click, myMusic.Click, myDocuments.Click, myRun.Click, fbWebBrowser.Click, myVideos.Click
        If pnlStart.Visible Then myStartMenu.doClick(sender, e)
    End Sub

    Private Sub fbMyNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyNetwork.Click
        'TODO: Not implemented yet
    End Sub

    Private Sub fbDesktop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDesktop.Click
        'TODO: Move to modBusiness as optional component
        Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        myStartMenu.doClick(sender, e)
    End Sub

    Private Sub pnlMainBar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainBar.Resize
        If isInit Then
            Dim myRect As New Rectangle

            myRect.Location = New Point(fbStartFill.Width + 6, FlatButton11.Bottom + 6)
            myRect.Size = New Size(pnlMainBar.Width - fbStartFill.Width - 6, pnlMainBar.Height - myRect.Top)

            If myBusiness.userButtonsShowing Then
                myRect.Width -= gridUserButtons.Width + 6
            Else
                myRect.Width = (pnlMainContainer.Width - pnlMain.Left)
            End If

            pnlMain.Bounds = myRect

            myBusiness.UpdateRegion()
        End If
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen1
        End Get
    End Property
End Class

