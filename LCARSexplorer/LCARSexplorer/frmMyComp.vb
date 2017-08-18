Imports System.IO
Imports LCARS.UI
Imports LCARS.LightweightControls

'To do:
'Finish file associations
'Improve context menu

Public Class frmMyComp
    Inherits LCARS.LCARSForm

#Region " Enum "
    Private Enum SelectMode
        Clear = 0
        Add = 1
        Symmetric = 2
    End Enum
#End Region

#Region " Global Variables "

    Public curPath As String = My.Settings.startDir
    Dim selectedButtons As New HashSet(Of LCARS.IDataControl)
    Dim selMode As SelectMode
    Dim selStart As Point
    Dim clickStart As DateTime
    Dim moved As Boolean
    Dim mySelection As New frmSelect()
    Dim selectTime As TimeSpan = TimeSpan.FromMilliseconds(500)
    Dim WithEvents clipListener As New ClipboardListener(Me)

#End Region

#Region " Selection Support "
    Private ReadOnly Property cancelClick() As Boolean
        Get
            Return moved OrElse (Now - clickStart) > selectTime
        End Get
    End Property

    Private Sub OnSelectStart()
        If My.Computer.Keyboard.ShiftKeyDown Then
            selMode = SelectMode.Add
        ElseIf My.Computer.Keyboard.CtrlKeyDown Then
            selMode = SelectMode.Symmetric
        Else
            selMode = SelectMode.Clear
            For Each myButton As LCComplexButton In selectedButtons
                myButton.RedAlert = LCARS.LCARSalert.Normal
            Next
            selectedButtons.clear()
        End If
    End Sub

    Private Sub OnSelectionChanged()
        Dim oneSelected As Boolean = (selectedButtons.Count = 1)
        sbRename.Lit = oneSelected
        sbRename.Clickable = oneSelected
        sbOpenWith.Lit = oneSelected
        Dim atLeastOne As Boolean = (selectedButtons.Count > 0)
        sbProperties.Lit = atLeastOne
    End Sub

    Private Sub item_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        clickStart = Now
    End Sub

    Private Sub item_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' This is a Click handler, rather than a MouseUp handler because Click events
        ' are raised before MouseUp events, and if the Click handler takes more than
        ' 500 ms to complete, the file would be selected. Therefore, this has to be
        ' processed (and added) before the main click handler.
        If Not moved AndAlso (Now - clickStart) > selectTime Then
            Dim ctrl As LCComplexButton = DirectCast(sender, LCComplexButton)
            If selMode = SelectMode.Symmetric And selectedButtons.contains(ctrl) Then
                selectedButtons.remove(ctrl)
                ctrl.RedAlert = LCARS.LCARSalert.Normal
            Else
                selectedButtons.add(ctrl)
                ctrl.RedAlert = LCARS.LCARSalert.White
            End If
        End If
    End Sub

    Private Sub pnlMyComp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseDown
        If e.Button <> Windows.Forms.MouseButtons.Left Then Return
        OnSelectStart()
        moved = False
        selStart = e.Location
    End Sub

    Private Sub pnlMyComp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            moved = True
            Dim selectionRect As Rectangle = getSelectionRect(e.Location)
            mySelection.Bounds = gridMyComp.RectangleToScreen(selectionRect)
            If Not mySelection.Visible Then
                mySelection.Show()
            End If

            checkSelected(selectionRect)
        End If
    End Sub

    Private Sub pnlMyComp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseUp
        If moved Then
            checkSelected(getSelectionRect(e.Location), True)
        End If
        mySelection.Hide()
        OnSelectionChanged()
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
        For i As Integer = gridMyComp.CurrentPage * gridMyComp.PageSize _
                To Math.Min(gridMyComp.Count - 1, _
                            (gridMyComp.CurrentPage + 1) * gridMyComp.PageSize - 1)
            myButton = DirectCast(gridMyComp.Items(i), LCComplexButton)

            If myButton.Bounds.IntersectsWith(selectionRect) Then
                If selMode = SelectMode.Symmetric Then
                    If selectedButtons.contains(myButton) Then
                        myButton.RedAlert = LCARS.LCARSalert.Normal
                        If rememberSelection Then selectedButtons.remove(myButton)
                    Else
                        myButton.RedAlert = LCARS.LCARSalert.White
                        If rememberSelection Then selectedButtons.add(myButton)
                    End If
                Else
                    myButton.RedAlert = LCARS.LCARSalert.White
                    If rememberSelection Then
                        selectedButtons.add(myButton)
                    End If
                End If
            Else
                If selectedButtons.contains(myButton) Then
                    myButton.RedAlert = LCARS.LCARSalert.White
                Else
                    myButton.RedAlert = LCARS.LCARSalert.Normal
                End If
            End If
        Next
    End Sub
#End Region

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
        Clipboard_Changed(Me, EventArgs.Empty)
        OnSelectionChanged()
        loadShortcuts()
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
            myButton.Data = myDrive.RootDirectory.FullName()
            myButton.Beeping = beeping
            myButton.HoldDraw = False
            AddHandler myButton.MouseDown, AddressOf item_MouseDown
            AddHandler myButton.Click, AddressOf item_Click

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

            gridMyComp.Add(myButton)
        Next
    End Sub

    Private Sub offlineDrive_Click(ByVal sender As Object, ByVal e As EventArgs)
        If cancelClick Then Return
        MsgBox("Drive not ready.", MsgBoxStyle.OkOnly, "Drive offline")
    End Sub

    Private Sub directory_click(ByVal sender As Object, ByVal e As EventArgs)
        If cancelClick Then Return
        loadDir(CStr(DirectCast(sender, LCComplexButton).Data))
    End Sub

    Private Sub reparsePoint_Click(ByVal sender As Object, ByVal e As EventArgs)
        If cancelClick Then Return
        MsgBox("Reparse points cannot (yet) be traversed", _
               MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, _
               "Not available")
    End Sub

    Public Sub loadDir(ByVal newpath As String)
        If newpath = "" Then
            loadMyComp()
        Else
            Dim myDir As DirectoryInfo = New DirectoryInfo(newpath)
            Dim infos() As FileSystemInfo
            Try
                infos = myDir.GetFileSystemInfos()
            Catch ex As Exception
                MsgBox(String.Format("Unable to access path: {0}", newpath), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Access Denied")
                Return
            End Try

            curPath = newpath
            sbUpDir.Lit = True
            pnlVisible.Visible = True

            Dim title As String = Path.GetFileNameWithoutExtension(curPath)
            If title <> "" Then
                gridMyComp.Text = title
            Else
                gridMyComp.Text = newpath
            End If

            gridMyComp.Clear()
            gridMyComp.ControlSize = New Size(300, 30)
            Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
            For Each curItem As FileSystemInfo In infos
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
                myButton.Text = curItem.Name
                myButton.Data = curItem.FullName
                myButton.Beeping = beeping
                myButton.HoldDraw = False
                If My.Settings.dimHidden Then myButton.Lit = Not hidden

                AddHandler myButton.MouseDown, AddressOf item_MouseDown
                AddHandler myButton.Click, AddressOf item_Click

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

                gridMyComp.Add(myButton)
            Next
        End If
    End Sub

    Private Sub myFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If cancelClick Then Return
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
        dialog.Focus()
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

    Private Sub Clipboard_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles clipListener.ClipboardChanged
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
            Dim path As String = DirectCast(selectedButtons.first().Data, String)
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
            If (mySelect.DialogResult = Windows.Forms.DialogResult.OK) Then
                Dim newProg As String = mySelect.ReturnPath
                Shell("""" & newProg & """" & " """ & CStr(selectedButtons.first().Data) & """", AppWinStyle.NormalFocus)
            End If
        Else
            MsgBox("Please select one file", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub sbOptions_Click(ByVal senter As System.Object, ByVal e As System.EventArgs) Handles sbOptions.Click
        frmOptions.ShowDialog()
        loadDir(curPath)
        loadShortcuts()
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
        If cancelClick Then Return
        LCARS.Alerts.ActivateAlert("Red", Me.Handle)
        MsgBox("Error: Access Denied", MsgBoxStyle.Critical, "Access Denied")
        LCARS.Alerts.DeactivateAlert(Me.Handle)
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
            loadDir(newPath)
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