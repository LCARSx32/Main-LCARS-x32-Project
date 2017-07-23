Option Strict On
Imports System.IO
Imports Microsoft.Win32
Imports LCARS.UI
Imports LCARS.LightweightControls

'To do:
'Finish file associations
'Add support for arbitrary selections
'Improve context menu

Public Class frmMyComp
    Inherits LCARS.LCARSForm

#Region " API "
    Private Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Private Declare Auto Function SetClipboardViewer Lib "user32" (ByVal hWndNewViewer As IntPtr) As IntPtr

    Private Declare Auto Function ChangeClipboardChain Lib "user32" (ByVal hwndRemove As IntPtr, ByVal hwndNewNext As IntPtr) As Boolean

    Private Const WM_DESTROY As Integer = &H2
    Private Const WM_DRAWCLIPBOARD As Integer = &H308
    Private Const WM_CHANGECBCHAIN As Integer = &H30D
    Private Const WS_EX_APPWINDOW As Integer = &H40000
#End Region

#Region " Global Variables "

    Public curPath As String = My.Settings.startDir
    Dim selectedButtons As New List(Of LCComplexButton)
    Dim selStart As Point
    Dim curSelected As LCComplexButton
    Dim cancelClick As Boolean
    Dim mySelection As New frmSelect()
    Dim nextInChain As IntPtr

#End Region



    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_DRAWCLIPBOARD
                Clipboard_Changed()
                If nextInChain <> IntPtr.Zero Then
                    SendMessage(nextInChain, WM_DRAWCLIPBOARD, Nothing, Nothing)
                End If
                m.Result = IntPtr.Zero
            Case WM_CHANGECBCHAIN
                If m.WParam = nextInChain Then
                    nextInChain = m.LParam
                End If
                If nextInChain <> IntPtr.Zero Then
                    SendMessage(nextInChain, WM_CHANGECBCHAIN, m.WParam, m.LParam)
                End If
                m.Result = IntPtr.Zero
            Case WM_DESTROY
                ChangeClipboardChain(Me.Handle, nextInChain)
                MyBase.WndProc(m)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub



    Private Sub frmMyComp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.PageDown Then
            If gridMyComp.CurrentPage + 1 < gridMyComp.PageCount Then
                gridMyComp.CurrentPage += 1
            End If
        ElseIf e.KeyData = Keys.PageUp Then
            If gridMyComp.CurrentPage > 0 Then
                gridMyComp.CurrentPage -= 1
            End If
        End If
    End Sub

    Private Sub frmMyComp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Command() <> "" Then
            If Directory.Exists(Command) Then
                curPath = Command()
            End If
        End If
        nextInChain = SetClipboardViewer(Me.Handle)
        Clipboard_Changed()
        LCARS.SetBeeping(Me)
        loadDir(curPath)
    End Sub

    Private Sub loadMyComp()
        gridMyComp.Clear()
        gridMyComp.ControlSize = New Size((gridMyComp.Width - 38) \ 2, 30)

        gridMyComp.Text = "MY COMPUTER"
        sbUpDir.Lit = False

        pnlVisible.Visible = False
        pnlEdit.Visible = False

        Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
        For Each myDrive As DriveInfo In DriveInfo.GetDrives()
            Dim myButton As New LCComplexButton
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

            AddHandler myButton.MouseDown, AddressOf item_MouseDown
            AddHandler myButton.MouseUp, AddressOf item_MouseUp

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

    Private Sub directory_click(ByVal sender As Object, ByVal e As EventArgs)
        If Not cancelClick Then
            loadDir(CStr(CType(sender, LCComplexButton).Data))
        End If
    End Sub

    Private Sub reparsePoint_Click(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox("Reparse points cannot (yet) be traversed", _
               MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, _
               "Not available")
        DirectCast(sender, LCComplexButton).RedAlert = LCARS.LCARSalert.Normal
    End Sub

    Private Sub item_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Not tmrMouseSelect.Enabled Then
            selectedButtons.Clear()
            checkSelected(Rectangle.Empty)
            curSelected = CType(sender, LCComplexButton)
            tmrMouseSelect.Enabled = True
        End If
    End Sub

    Private Sub item_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        curSelected = Nothing
        tmrMouseSelect.Enabled = False
        cancelClick = False
    End Sub

    Private Sub associateClickHandler(ByVal control As LCComplexButton, ByVal handler As EventHandler)
        If My.Settings.ClickMode = "Single" Then
            AddHandler control.Click, handler
        Else
            AddHandler control.DoubleClick, handler
        End If
    End Sub

    Public Sub loadDir(ByVal newpath As String)
        If newpath = "" Then
            loadMyComp()
        Else
            sbUpDir.Lit = True

            pnlVisible.Visible = True

            Dim myDir As DirectoryInfo = New DirectoryInfo(newpath)

            curPath = newpath

            Dim title As String = Path.GetFileNameWithoutExtension(curPath)
            If title <> "" Then
                gridMyComp.Text = title
            Else
                gridMyComp.Text = newpath
            End If

            gridMyComp.Clear()
            gridMyComp.ControlSize = New Size(300, 30)
            Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
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
                    If My.Settings.ColorFiles Then
                        Dim mycolors() As String = myButton.ColorsAvailable.getColors
                        mycolors(LCARS.LCARScolorStyles.MiscFunction) = getExtColor(Path.GetExtension(curItem.Name))
                        myButton.ColorsAvailable.setColors(mycolors)
                    End If

                    myButton.Color = LCARS.LCARScolorStyles.MiscFunction
                    Dim ext As String = Path.GetExtension(curItem.FullName).Replace(".", "")
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

                AddHandler myButton.MouseDown, AddressOf item_MouseDown
                AddHandler myButton.MouseUp, AddressOf item_MouseUp

                myButton.Text = curItem.Name
                myButton.Data = curItem.FullName
                myButton.Beeping = beeping
                myButton.HoldDraw = False

                gridMyComp.Add(myButton)
            Next
        End If
    End Sub

    Private Sub myFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not cancelClick Then
            Dim btn As LCComplexButton = DirectCast(sender, LCComplexButton)
            Dim file As String = DirectCast(btn.Data, String)
            Try
                Dim myNewProcess As New System.Diagnostics.ProcessStartInfo
                Dim myProcess As Process

                myNewProcess.FileName = file
                myNewProcess.WorkingDirectory = curPath
                myProcess = Process.Start(myNewProcess)
            Catch
                Try
                    Shell(file, AppWinStyle.NormalFocus)
                Catch ex As Exception
                    MsgBox("Error: " & vbNewLine & vbNewLine & ex.Message)
                End Try
            End Try
        End If
    End Sub

    Private Sub pnlMyComp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseDown
        selectedButtons.Clear()
        checkSelected(Rectangle.Empty)
        selStart = e.Location
    End Sub

    Private Sub pnlMyComp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            tmrMouseSelect.Enabled = False
            Dim selectionRect As Rectangle = getSelectionRect(e.Location)
            mySelection.Bounds = gridMyComp.RectangleToScreen(selectionRect)
            If Not mySelection.Visible Then
                mySelection.Show()
            End If

            checkSelected(selectionRect)
        End If
    End Sub

    Private Function getSelectionRect(ByVal p As Point) As Rectangle
        Dim x1, x2, y1, y2 As Integer

        If p.X > selStart.X Then
            x1 = selStart.X
            x2 = p.X
        Else
            x1 = p.X
            x2 = selStart.X
        End If

        If p.Y > selStart.Y Then
            y1 = selStart.Y
            y2 = p.Y
        Else
            y1 = p.Y
            y2 = selStart.Y
        End If

        Return New Rectangle(x1, y1, x2 - x1, y2 - y1)
    End Function

    Private Sub checkSelected(ByVal selectionRect As Rectangle, Optional ByVal rememberSelection As Boolean = False)
        Dim myButton As LCComplexButton
        For i As Integer = 0 To gridMyComp.Count - 1
            myButton = DirectCast(gridMyComp.Items(i), LCComplexButton)

            If Not myButton.HoldDraw AndAlso myButton.Bounds.IntersectsWith(selectionRect) Then
                If myButton.RedAlert <> LCARS.LCARSalert.White Then
                    myButton.RedAlert = LCARS.LCARSalert.White
                End If
                If rememberSelection Then
                    selectedButtons.Add(myButton)
                End If
            Else
                If myButton.RedAlert <> LCARS.LCARSalert.Normal Then
                    myButton.RedAlert = LCARS.LCARSalert.Normal
                End If
            End If
        Next

        If selectedButtons.Count = 1 Then
            sbRename.Lit = True
            sbRename.Clickable = True
        Else
            sbRename.Lit = False
            sbRename.Clickable = False
        End If
    End Sub

    Private Sub pnlMyComp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseUp
        If Not e.Location = selStart Then
            checkSelected(getSelectionRect(e.Location), True)
        End If
        mySelection.Hide()
    End Sub


    Private Sub sbProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProperties.Click
        If selectedButtons.Count > 0 Then
            Dim props As New frmProperties(getSelectedFiles())
            dockDialog(props)
        Else
            MsgBox("No item selected.  Select an item by holding the mouse down for more than a second (it will stay white)." & vbNewLine & "You can also select multiple items by clicking in the back area and dragging around the desired items.", MsgBoxStyle.Exclamation, "ERROR: NO ITEM SLECTED")
        End If
    End Sub

    Private Sub dockDialog(ByVal dialog As Form)
        enableNavigation(False)
        AddHandler dialog.FormClosed, AddressOf dialog_closed
        dialog.Size = gridMyComp.Size
        dialog.Location = Point.Empty
        dialog.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        gridMyComp.Controls.Add(dialog)
        dialog.Show()
        dialog.BringToFront()
    End Sub

    Private Sub dialog_closed(ByVal sender As Object, ByVal e As EventArgs)
        gridMyComp.Controls.Remove(CType(sender, Form))
        enableNavigation(True)
    End Sub

    Public Sub enableNavigation(ByVal en As Boolean)
        pnlVisible.Enabled = en
        sbUpDir.Enabled = en
        sbProperties.Enabled = en
        sbOptions.Enabled = en
        sbGoTo.Enabled = en
        sbRefresh.Enabled = en
    End Sub
    Private Sub tmrMouseSelect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMouseSelect.Tick
        If Not curSelected Is Nothing Then
            cancelClick = True
            curSelected.RedAlert = LCARS.LCARSalert.White
            selectedButtons.Add(curSelected)
        End If
        tmrMouseSelect.Enabled = False
        If selectedButtons.Count = 1 Then
            sbRename.Lit = True
            sbRename.Clickable = True
        Else
            sbRename.Lit = False
            sbRename.Clickable = False
        End If
    End Sub

    Private Sub sbUpDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUpDir.Click
        If curPath = "" Then Return
        loadDir(Path.GetDirectoryName(curPath))
    End Sub

    Private Function getSelectedFiles() As String()
        Dim myFiles As New List(Of String)(selectedButtons.Count)
        For Each mybutton As LCComplexButton In selectedButtons
            myFiles.Add(DirectCast(mybutton.Data, String))
        Next
        Return myFiles.ToArray()
    End Function

    Private Sub sbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDelete.Click
        Dim result As MsgBoxResult = MsgBox( _
                "Are you sure you want to delete the selected file(s)/folder(s)?!", _
                MsgBoxStyle.YesNo, "DELETE?")

        If result = MsgBoxResult.Yes Then
            Dim form As New frmCopying(getSelectedFiles(), "", FileActions.Delete)
            AddHandler form.TaskCompleted, AddressOf Task_Finished
            form.Show()
        End If
    End Sub

    Private Sub sbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCopy.Click
        Dim myfiles() As String = getSelectedFiles()

        If myfiles.Length > 0 Then
            Dim myStream As New MemoryStream(4)
            Dim bytes() As Byte = {5, 0, 0, 0}

            myStream.Write(bytes, 0, bytes.Length)
            Dim data_object As New DataObject()
            data_object.SetData("FileDrop", True, myfiles)
            data_object.SetData("Preferred DropEffect", myStream)

            Clipboard.Clear()
            Clipboard.SetDataObject(data_object, True)

        End If
    End Sub

    Private Sub sbCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCut.Click
        Dim myfiles() As String = getSelectedFiles()

        If myfiles.Length > 0 Then
            Dim myStream As New MemoryStream(4)
            Dim bytes() As Byte = {2, 0, 0, 0}

            myStream.Write(bytes, 0, bytes.Length)
            Dim data_object As New DataObject()
            data_object.SetData("FileDrop", True, myfiles)
            data_object.SetData("Preferred DropEffect", myStream)

            Clipboard.Clear()
            Clipboard.SetDataObject(data_object, True)

        End If
    End Sub

    Private Sub Clipboard_Changed()
        sbPaste.Lit = Clipboard.ContainsFileDropList()
        sbPaste.Clickable = sbPaste.Lit
    End Sub

    Private Sub sbPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPaste.Click
        If Clipboard.ContainsFileDropList Then
            Dim data As IDataObject = Clipboard.GetDataObject

            Dim files() As String = DirectCast(Clipboard.GetData(DataFormats.FileDrop), String())
            Dim MyStream As MemoryStream = DirectCast(data.GetData("Preferred DropEffect", True), MemoryStream)
            Dim flag As Integer = MyStream.ReadByte

            If flag = 2 Then
                'cut
                Dim form As New frmCopying(files, curPath, FileActions.Cut)
                AddHandler form.TaskCompleted, AddressOf Task_Finished
                form.Show()
                Clipboard.Clear()
            Else
                'copy
                Dim form As New frmCopying(files, curPath, FileActions.Copy)
                AddHandler form.TaskCompleted, AddressOf Task_Finished
                form.Show()
            End If
        End If
    End Sub

    Private Sub sbRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRename.Click
        If selectedButtons.Count = 1 Then
            Dim path As String = DirectCast(selectedButtons(1).Data, String)
            Dim ren As New frmRename(path)
            dockDialog(ren)
            AddHandler ren.FormClosed, AddressOf dialog_closed_reload
            pnlEdit.Visible = False
        End If
    End Sub

    Private Sub dialog_closed_reload(ByVal sender As Object, ByVal e As EventArgs)
        Dim tmpPage As Integer = gridMyComp.CurrentPage
        loadDir(curPath)
        gridMyComp.CurrentPage = tmpPage
    End Sub

    Private Sub sbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbClose.Click
        Me.Close()
    End Sub

    Private Sub sbNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbNewFolder.Click
        Dim strName As String 'New Folder button added by Tim 5/26/11
        strName = inputbox("Enter the name of the new folder", "New Folder", "New Folder")
        strName = Path.Combine(curPath, strName)
        If Not Directory.Exists(strName) Then
            IO.Directory.CreateDirectory(strName)
            loadDir(curPath)
        End If
    End Sub

    Private Sub sbOpenWith_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOpenWith.Click
        If (selectedButtons.Count = 1) Then
            Dim mySelect As frmFileSelect = New frmFileSelect("C:\Program Files\", ".exe,.bat,", "Select program executable")
            mySelect.ShowDialog()
            If (mySelect.Result = Windows.Forms.DialogResult.OK) Then
                Dim newProg As String = mySelect.lblCurrentSelected.Text
                Shell("""" & newProg & """" & " """ & CStr(selectedButtons(1).Data) & """", AppWinStyle.NormalFocus)
            End If
        Else
            MsgBox("Please select one file", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub sbOptions_Click(ByVal senter As System.Object, ByVal e As System.EventArgs) Handles sbOptions.Click
        frmOptions.ShowDialog()
        loadDir(curPath)
    End Sub

    Private Sub sbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbEdit.Click
        pnlEdit.Visible = Not pnlEdit.Visible
        If pnlEdit.Visible Then
            pnlEdit.BringToFront()
            pnlSystemDefined.Visible = False
        End If
    End Sub

    Private Sub sbGoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGoTo.Click
        pnlSystemDefined.Visible = Not pnlSystemDefined.Visible
        If pnlSystemDefined.Visible Then
            pnlEdit.Visible = False
            loadShortcuts()
            pnlSystemDefined.BringToFront()
        End If
    End Sub
    Private Sub loadShortcuts()
        pnlShortcuts.Controls.Clear()
        For i As Integer = 0 To My.Settings.shortcuts.Count - 1
            Dim myShortcut As New LCARS.Controls.StandardButton
            With myShortcut
                .holdDraw = True
                .Data = My.Settings.shortcuts.Item(i)
                .Text = My.Settings.shortcutNames.Item(i)
                .ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
                .Color = LCARS.LCARScolorStyles.NavigationFunction
                .Width = 87
                .Height = 26
                .Left = 3
                .Top = i * 32 + 3
            End With
            AddHandler myShortcut.Click, AddressOf MyShortcut_Click
            myShortcut.holdDraw = False
            pnlShortcuts.Controls.Add(myShortcut)
        Next
    End Sub
    Private Sub MyShortcut_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pnlSystemDefined.Visible = False
        loadDir(CStr(CType(sender, LCComplexButton).Data))
    End Sub
    Private Sub myErrorAlert(ByVal sender As Object, ByVal e As EventArgs)
        LCARS.Alerts.ActivateAlert("Red", Me.Handle)
        MsgBox("Error: Access Denied", MsgBoxStyle.Critical, "Access Denied")
        LCARS.Alerts.DeactivateAlert(Me.Handle)
        DirectCast(sender, LCComplexButton).RedAlert = LCARS.LCARSalert.Normal
    End Sub

    Private Sub sbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRefresh.Click
        loadDir(curPath)
    End Sub

#Region " System-defined shortcuts "

    Private Sub sbMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbMyComp.Click
        pnlSystemDefined.Visible = False
        loadDir("")
    End Sub

    Private Sub sbDesktop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDesktop.Click
        pnlSystemDefined.Visible = False
        loadDir(My.Computer.FileSystem.SpecialDirectories.Desktop)
    End Sub

    Private Sub sbDocuments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDocuments.Click
        pnlSystemDefined.Visible = False
        loadDir(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
    End Sub

    Private Sub sbPictures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPictures.Click
        pnlSystemDefined.Visible = False
        loadDir(My.Computer.FileSystem.SpecialDirectories.MyPictures)
    End Sub

    Private Sub sbMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbMusic.Click
        pnlSystemDefined.Visible = False
        loadDir(My.Computer.FileSystem.SpecialDirectories.MyMusic)
    End Sub

    Private Sub sbVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbVideos.Click
        pnlSystemDefined.Visible = False
        Dim result As String = GetSetting("LCARS x32", "Application", "Videos", "")
        If result = "" Then
            Try
                Dim myReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
                myReg = myReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\explorer\Shell Folders\", False)
                result = CStr(myReg.GetValue("My Video"))
                SaveSetting("LCARS x32", "Application", "Videos", result)
            Catch ex As Exception
            End Try
            If result = "" Then
                Dim res As MsgBoxResult = MsgBox("Unable to find ""My Videos"". Would you like to manually set the path?", MsgBoxStyle.YesNo)
                If res = MsgBoxResult.Yes Then
                    result = inputbox("Input the complete path to your ""My Videos"" directory:", "Input My Videos directory")
                    If System.IO.Directory.Exists(result) Then
                        SaveSetting("LCARS x32", "Application", "Videos", result)
                        loadDir(result)
                    End If
                End If
            Else
                loadDir(result)
            End If
        Else
            loadDir(result)
        End If
    End Sub
#End Region

    Private Sub sbEnterPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbEnterPath.Click
        pnlSystemDefined.Visible = False
        Dim newPath As String = inputbox("Enter a path to go to.", "Enter Path", curPath)
        If Directory.Exists(newPath) And (Not newPath = "") Then
            curPath = newPath
            loadDir(curPath)
        End If
    End Sub

    Private Sub sbSaveCurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSaveCurrent.Click
        My.Settings.shortcuts.Add(curPath)
        My.Settings.shortcutNames.Add(tbTitle.Text)
        My.Settings.Save()
        loadShortcuts()
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

    Private Sub Task_Finished(ByVal sender As Object, ByVal e As System.EventArgs)
        loadDir(curPath)
    End Sub

    Private Sub gridMyComp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridMyComp.TextChanged
        Me.Text = gridMyComp.Text
        tbTitle.Text = gridMyComp.Text
    End Sub
End Class