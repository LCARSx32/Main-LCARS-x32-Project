Public Class frmMainscreen1
    Implements IAutohide

    Private myBusiness As modBusiness

    Public Function getAutohideEdges() As IAutohide.AutohideEdges Implements IAutohide.getAutohideEdges
        Return IAutohide.AutohideEdges.Top Or IAutohide.AutohideEdges.Left
    End Function

    Public Sub New(ByVal b As modBusiness)
        InitializeComponent()
        Me.myBusiness = b
    End Sub

    Private Sub myStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myStartMenu.Click
        pnlStart.Visible = Not pnlStart.Visible
        fbBlock.Visible = Not pnlStart.Visible
        elbStart.Visible = pnlStart.Visible
        If pnlStart.Visible Then
            pnlMainContainer.Left = pnlStart.Width
            pnlMainContainer.Width = Me.Width - pnlStart.Width
        Else
            pnlMainContainer.Left = 0
            pnlMainContainer.Width = Me.Width
        End If
    End Sub

    Private Sub ArrowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton1.Click
        If Not pnlMainBar.Top = 0 Then
            pnlMainBar.Top = 0
            pnlMainBar.Height = Me.Height
            ArrowButton1.ArrowDirection = LCARS.LCARSarrowDirection.Down
            myBusiness.myClock = fbClock
        Else
            pnlMainBar.Top = Elbow2.Bottom + 6
            pnlMainBar.Height = Me.Height - Elbow2.Bottom - 6
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

    Public Shared ReadOnly Property ScreenImage() As Image
        Get
            Return My.Resources.frmmainscreen1
        End Get
    End Property

    Private Sub myUserButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myUserButtons.Click
        If gridUserButtons.Visible Then
            pnlMain.Width += gridUserButtons.Width + 6
        Else
            pnlMain.Width -= gridUserButtons.Width + 6
        End If
    End Sub
End Class

