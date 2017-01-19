Public Class frmMainscreen1
    Implements IAutohide

    Dim isInit As Boolean
    Public myBusiness As New modBusiness
#Region " AutoHide "

    Private Sub UpdateRegion()
        Dim myRegion As Region = New Region(New RectangleF(0, 0, Me.Width, Me.Height))
        Try
            Dim mainRect As New Rectangle
            mainRect.X = pnlMainBar.Left + pnlMain.Left + pnlMainContainer.Left
            mainRect.Y = pnlMainBar.Top + pnlMain.Top + pnlMainContainer.Top
            mainRect.Width = pnlMain.Width
            mainRect.Height = pnlMain.Height

            myRegion.Exclude(mainRect)
            Me.Region = myRegion
        Catch
        End Try
    End Sub

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Left
    End Function

#End Region

    Sub New(ByVal ScreenIndex As Integer)
        InitializeComponent()
        myBusiness.ScreenIndex = ScreenIndex
        myBusiness.init(Me)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Bounds = Screen.AllScreens(myBusiness.ScreenIndex).Bounds
        Me.Show()

        Application.DoEvents()


        isInit = True

        pnlMainBar_Resize(New Object, New System.EventArgs)
        myBusiness.mainTimer.Enabled = True
    End Sub

    Private Sub fbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        If pnlStart.Visible = False Then
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
        pnlStart.Visible = Not pnlStart.Visible

    End Sub


    Private Sub fbProgBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbProgBack.Click
        myBusiness.ProgBack()
    End Sub

    Private Sub abProgsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abProgsNext.Click
        myBusiness.nextProgPage()
    End Sub

    Private Sub abProgsBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abProgsBack.Click
        myBusiness.previousProgPage()
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

    Private Sub fbMyPictures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myPictures.Click
        If pnlStart.Visible = True Then myStartMenu.doClick(sender, e)

    End Sub

    Private Sub fbMyMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myMusic.Click
        myStartMenu.doClick(sender, e)

    End Sub

    Private Sub fbMyNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbMyNetwork.Click
        'Dim myComp As New frmMyComp
        'myComp.curPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        'MsgBox(myComp.curPath )

    End Sub

    Private Sub fbDesktop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbDesktop.Click
        Process.Start(Application.StartupPath & "\LCARSexplorer.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        myStartMenu.doClick(sender, e)

    End Sub


    Private Sub pnlMainBar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMainBar.Resize
        If isInit = True Then
            Dim myRect As New Rectangle

            myRect.Location = New Point(fbStartFill.Width + 6, FlatButton11.Bottom + 6)
            myRect.Size = New Size(pnlMainBar.Width - fbStartFill.Width - 6, pnlMainBar.Height - myRect.Top)

            If myBusiness.userButtonsShowing Then
                myRect.Width -= gridUserButtons.Width + 6
            Else
                myRect.Width = (pnlMainContainer.Width - pnlMain.Left)
            End If

            pnlMain.Bounds = myRect

            UpdateRegion()

        End If

    End Sub

    Private Sub myDocuments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myDocuments.Click
        If pnlStart.Visible = True Then myStartMenu.doClick(sender, e)
    End Sub

    Private Sub myRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myRun.Click
        If pnlStart.Visible = True Then myStartMenu.doClick(sender, e)
    End Sub


    Private Sub fbWebBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbWebBrowser.Click
        If pnlStart.Visible Then
            myStartMenu.doClick(sender, e)
        End If
    End Sub

    Private Sub myVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myVideos.Click
        If pnlStart.Visible Then myStartMenu.doClick(New Object, New EventArgs)
    End Sub

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen1
        End Get
    End Property
End Class

