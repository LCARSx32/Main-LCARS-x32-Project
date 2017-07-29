Imports System.IO
Imports LCARS.UI
Imports Microsoft.Win32
Imports LCARS.LightweightControls
Public Class frmFileSelect

    Dim curPath As String = ""
    Dim extensions As New List(Of String)
    Dim _selectedPath As String = ""
    Dim oloc As Point

    Private Sub sbUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUp.Click
        If curPath = "" Then Return
        loadDir(Path.GetDirectoryName(curPath))
    End Sub
    Private Sub loadMyComp()
        gridMyComp.Clear()

        gridMyComp.Text = "MY COMPUTER"
        sbUp.Lit = False

        Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
        For Each myDrive As DriveInfo In DriveInfo.GetDrives()
            Dim myButton As New LCARS.LightweightControls.LCComplexButton 'LCARS.Controls.ComplexButton
            myButton.HoldDraw = True

            If myDrive.IsReady Then
                myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
                If myDrive.VolumeLabel = "" Then
                    myButton.Text = "Local Disk (" & myDrive.Name & ")"
                Else
                    myButton.Text = myDrive.VolumeLabel & " (" & myDrive.Name & ")"
                End If
                myButton.SideText = ToDriveSize(myDrive.TotalSize)
                associateClickHandler(myButton, AddressOf directory_click)
            Else
                myButton.Color = LCARS.LCARScolorStyles.FunctionUnavailable
                myButton.Text = "DRIVE OFFLINE (" & myDrive.Name & ")"
                myButton.SideText = "--"
                associateClickHandler(myButton, AddressOf offlineDrive_Click)
            End If

            myButton.Data = myDrive.RootDirectory.FullName()
            myButton.Beeping = beeping
            myButton.HoldDraw = False

            gridMyComp.Add(myButton)
        Next
    End Sub

    Private Sub offlineDrive_Click(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox("Drive not ready.", MsgBoxStyle.OkOnly, "Drive offline")
        DirectCast(sender, LCComplexButton).RedAlert = LCARS.LCARSalert.Normal
    End Sub

    Private Sub reparsePoint_Click(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox("Reparse points cannot (yet) be traversed", _
               MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, _
               "Not available")
        DirectCast(sender, LCComplexButton).RedAlert = LCARS.LCARSalert.Normal
    End Sub

    Private Sub directory_click(ByVal sender As Object, ByVal e As EventArgs)
        loadDir(CStr(CType(sender, LCARS.LightweightControls.LCComplexButton).Data))
    End Sub

    Public Sub loadDir(ByVal newpath As String)
        If newpath = "" Then
            loadMyComp()
        Else
            sbUp.Lit = True

            Dim myDir As DirectoryInfo = New DirectoryInfo(newpath)

            curPath = newpath

            Dim title As String = Path.GetFileNameWithoutExtension(curPath)
            If title <> "" Then
                gridMyComp.Text = title
            Else
                gridMyComp.Text = newpath
            End If

            Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
            gridMyComp.Clear()
            gridMyComp.ControlSize = New Size(300, 30)
            For Each curItem As FileSystemInfo In myDir.GetFileSystemInfos()
                Dim fileAttr As FileAttributes = curItem.Attributes
                Dim hidden As Boolean = FileHasFlag(fileAttr, FileAttributes.Hidden)
                Dim system As Boolean = FileHasFlag(fileAttr, FileAttributes.System)
                Dim directory As Boolean = FileHasFlag(fileAttr, FileAttributes.Directory)
                Dim reparsePoint As Boolean = FileHasFlag(fileAttr, FileAttributes.ReparsePoint)
                Dim canStat As Boolean = True
                Dim subDirs() As FileSystemInfo = Nothing
                If directory And Not reparsePoint Then
                    Try
                        subDirs = DirectCast(curItem, DirectoryInfo).GetDirectories()
                    Catch ex As Exception
                        canStat = False
                    End Try
                End If
                If hidden And Not My.Settings.showHidden Or _
                    system And Not My.Settings.showSystem Or _
                    reparsePoint And Not My.Settings.showReparse Or _
                    My.Settings.check And Not canStat Then
                    Continue For
                End If

                Dim myButton As New LCComplexButton()

                myButton.HoldDraw = True

                If My.Settings.dimHidden Then myButton.Lit = Not hidden

                If reparsePoint Then
                    myButton.Color = LCARS.LCARScolorStyles.FunctionUnavailable
                    myButton.SideText = "--"
                    associateClickHandler(myButton, AddressOf reparsePoint_Click)
                ElseIf directory Then
                    If canStat Then
                        Dim curDir As DirectoryInfo = CType(curItem, DirectoryInfo)
                        myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
                        myButton.SideText = subDirs.Length & "." & curDir.GetFiles().Length
                        associateClickHandler(myButton, AddressOf directory_click)
                    Else
                        myButton.SideText = "--"
                        myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                        associateClickHandler(myButton, AddressOf myErrorAlert)
                    End If
                Else
                    Dim ext As String = Path.GetExtension(curItem.FullName)
                    Dim match As Boolean = False
                    For Each myExt As String In extensions
                        If (ext = myExt And ext <> "") Then
                            match = True
                            Exit For
                        End If
                    Next
                    If Not match Then Continue For

                    If My.Settings.ColorFiles Then
                        Dim mycolors() As String = myButton.ColorsAvailable.getColors
                        mycolors(LCARS.LCARScolorStyles.MiscFunction) = getExtColor(Path.GetExtension(curItem.Name))
                        myButton.ColorsAvailable.setColors(mycolors)
                    End If

                    myButton.Color = LCARS.LCARScolorStyles.MiscFunction
                    If ext <> "" Then
                        If ext.Length > 6 Then
                            ext = ext.Substring(0, 6) & "."
                        End If
                        myButton.SideText = ext.ToUpper
                    Else
                        myButton.SideText = "---"
                    End If
                    associateClickHandler(myButton, AddressOf myFile_Click)
                End If

                myButton.Text = curItem.Name
                myButton.Data = curItem.FullName
                myButton.Beeping = beeping
                myButton.HoldDraw = False

                gridMyComp.Add(myButton)
            Next
        End If

    End Sub

    Private Sub myFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As LCComplexButton = DirectCast(sender, LCComplexButton)
        lblCurrentSelected.Text = btn.Text
        _selectedPath = CStr(btn.Data)
    End Sub
    Private Sub frmFileSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCurrentSelected.Text = ""
        loadDir(curPath)
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        If _selectedPath = "" Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    Public Sub New(Optional ByVal startDir As String = "", Optional ByVal filters As String = "", Optional ByVal title As String = "")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        curPath = startDir
        extensions.AddRange(filters.Split(","c))
        Dim myBuilder As New System.Text.StringBuilder()
        For Each myext As String In extensions
            myBuilder.AppendLine(myext)
        Next
        fbExt.Text = myBuilder.ToString()
        hpPrompt.Text = title
    End Sub

    Public ReadOnly Property ReturnPath() As String
        Get
            Return _selectedPath
        End Get
    End Property

    'moving dialog box

    Private Sub elbTop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles elbTop.MouseDown
        oloc = New Point(MousePosition.X, MousePosition.Y)
    End Sub

    Private Sub elbTop_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles elbTop.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Left += MousePosition.X - oloc.X
            Me.Top += MousePosition.Y - oloc.Y
            oloc = New Point(MousePosition.X, MousePosition.Y)
            Application.DoEvents()
        End If
    End Sub
    Private Sub myErrorAlert(ByVal sender As Object, ByVal e As System.EventArgs)
        LCARS.Alerts.ActivateAlert("Red", Me.Handle)
        MsgBox("Error: Access Denied", MsgBoxStyle.Critical, "Access Denied")
        LCARS.Alerts.DeactivateAlert(Me.Handle)
    End Sub
    'Changes page on mouse scroll
    Private Sub Me_MouseScroll(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            If gridMyComp.CurrentPage > 0 Then
                gridMyComp.CurrentPage -= 1
            End If
        Else
            If gridMyComp.CurrentPage - 1 < gridMyComp.PageCount Then
                gridMyComp.CurrentPage += 1
            End If
        End If
    End Sub

    Private Sub gridMyComp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridMyComp.TextChanged
        Me.Text = gridMyComp.Text
        hpLocation.Text = gridMyComp.Text
    End Sub
End Class
