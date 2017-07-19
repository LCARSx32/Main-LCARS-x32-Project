Option Strict Off
Imports System.IO
Imports Microsoft.Win32
Imports LCARS.UI

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
    Dim selectedButtons As New Collection
    Dim selStart As Point
    Dim curSelected As LCARS.LightweightControls.LCComplexButton
    Dim cancelClick As Boolean
    Dim mySelection As New frmSelect
    Dim showSystem As Boolean = False 'flag to show system files and folders
    Dim myShift As Boolean = False
    Dim nextInChain As IntPtr

    Private Delegate Sub NoArgs()

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



    Private Sub frmMyComp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.PageDown Then
            If gridMyComp.CurrentPage + 1 < gridMyComp.PageCount Then
                gridMyComp.CurrentPage += 1
            End If
        ElseIf e.KeyData = Keys.PageUp Then
            If gridMyComp.CurrentPage > 0 Then
                gridMyComp.CurrentPage -= 1
            End If
        ElseIf e.KeyData = Keys.Shift Then
            myShift = True
        End If

    End Sub
    Private Sub myKeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.ShiftKey Then
            myShift = False
        End If
    End Sub


    Private Sub frmMyComp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Command() <> "" Then
            If Directory.Exists(Command) Then
                curPath = Command()
            End If
        End If
        nextInChain = SetClipboardViewer(Me.Handle)

        LCARS.SetBeeping(Me)
        loadDir(curPath)
    End Sub

    Private Sub loadMyComp()
        Dim myDrives() As DriveInfo = DriveInfo.GetDrives
        gridMyComp.ControlSize = New Size((gridMyComp.Width - 38) \ 2, 30)
        gridMyComp.Clear()


        tbTitle.ButtonText = "MY COMPUTER"
        Me.Text = "MY COMPUTER"

        Do Until pnlVisible.Controls.Count = 0
            pnlOptionalComponents.Controls.Add(pnlVisible.Controls(0))
        Loop
        pnlEdit.Visible = False

        Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
        For Each myDrive As DriveInfo In myDrives
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
                If My.Settings.ClickMode = "Single" Then
                    AddHandler myButton.Click, AddressOf drive_click
                Else
                    AddHandler myButton.DoubleClick, AddressOf drive_click
                End If
            Else
                myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                myButton.Text = "DRIVE OFFLINE (" & myDrive.Name & ")"
                myButton.SideText = "--"
                If My.Settings.ClickMode = "Single" Then
                    AddHandler myButton.Click, AddressOf OfflineDrive_click
                Else
                    AddHandler myButton.DoubleClick, AddressOf OfflineDrive_click
                End If
            End If

            AddHandler myButton.MouseDown, AddressOf drive_MouseDown
            AddHandler myButton.MouseUp, AddressOf drive_MouseUp

            myButton.Data = myDrive.Name
            myButton.Beeping = beeping
            myButton.HoldDraw = False

            gridMyComp.Add(myButton)
        Next

    End Sub


    Private Sub drive_click(ByVal sender As Object, ByVal e As EventArgs)
        If (cancelClick = False And CType(sender, LCARS.LightweightControls.LCComplexButton).SideText <> "--") Then
            loadDir(CType(sender, LCARS.LightweightControls.LCComplexButton).Data)
        End If
    End Sub

    Private Sub drive_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If tmrMouseSelect.Enabled = False Then
            selectedButtons.Clear()
            checkSelected(0, 0, 0, 0)
            curSelected = CType(sender, LCARS.LightweightControls.LCComplexButton)
            tmrMouseSelect.Enabled = True
        End If
    End Sub

    Private Sub drive_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        curSelected = Nothing
        tmrMouseSelect.Enabled = False
        cancelClick = False
    End Sub

    Private Sub OfflineDrive_click(ByVal sender As Object, ByVal e As EventArgs)
        myErrorAlert(sender, e)
    End Sub

    Public Sub loadDir(ByVal newpath As String)
        If newpath = "" Then
            loadMyComp()
        Else
            sbUpDir.Lit = True

            pnlVisible.Controls.Add(sbEdit)
            pnlVisible.Controls.Add(sbNewFolder) 'Adding the new folder button
            pnlVisible.Controls.Add(sbOpenWith) 'Adding the open with button

            Dim myDir As DirectoryInfo = New DirectoryInfo(newpath)

            curPath = newpath
            Dim CurItems As New List(Of FileSystemInfo)

            Dim title As String = System.IO.Path.GetFileNameWithoutExtension(curPath)
            If title <> "" Then
                tbTitle.ButtonText = title
                Me.Text = title
            Else
                tbTitle.ButtonText = newpath
                Me.Text = newpath
            End If


            'get directories and add them to the list
            For Each curDir As DirectoryInfo In myDir.GetDirectories
                Try
                    If My.Settings.check Then
                        curDir.GetDirectories()
                    End If
                    Dim dirAttr As FileAttributes = curDir.Attributes
                    If (dirAttr <> FileAttributes.Hidden Or My.Settings.showHidden = True) And (dirAttr <> FileAttributes.System Or showSystem = True) Then
                        CurItems.Add(curDir)
                    End If
                Catch ex As Exception

                End Try
            Next
            'get files and add them to the list
            For Each curFile As FileInfo In myDir.GetFiles
                Try
                    If My.Settings.check Then
                        Dim blank As String = curFile.Extension
                    End If
                    Dim fileAttr As FileAttributes = curFile.Attributes
                    If (fileAttr <> FileAttributes.Hidden Or My.Settings.showHidden = True) And (fileAttr <> FileAttributes.System Or showSystem = True) Then
                        CurItems.Add(curFile)
                    End If
                Catch ex As Exception
                End Try
            Next

            gridMyComp.Clear()
            gridMyComp.ControlSize = New Size(300, 30)
            Dim beeping As Boolean = LCARS.x32.modSettings.ButtonBeep
            For Each curItem As FileSystemInfo In CurItems

                Dim myButton As New LCARS.LightweightControls.LCComplexButton()

                myButton.HoldDraw = True

                If curItem.GetType() Is GetType(DirectoryInfo) Then
                    Try
                        Dim curDir As DirectoryInfo = CType(curItem, DirectoryInfo)
                        myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
                        myButton.SideText = curDir.GetDirectories.GetUpperBound(0) + 1 & "." & curDir.GetFiles.GetUpperBound(0) + 1
                        If My.Settings.ClickMode = "Single" Then
                            AddHandler myButton.Click, AddressOf drive_click
                        Else
                            AddHandler myButton.DoubleClick, AddressOf drive_click
                        End If
                    Catch ex As Exception
                        myButton.SideText = "--"
                        myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                        If My.Settings.ClickMode = "Single" Then
                            AddHandler myButton.Click, AddressOf myErrorAlert
                        Else
                            AddHandler myButton.DoubleClick, AddressOf myErrorAlert
                        End If
                    End Try

                Else
                    Try
                        If My.Settings.ColorFiles Then
                            Dim mycolors() As String = myButton.ColorsAvailable.getColors
                            mycolors(2) = getExtColor(Path.GetExtension(curItem.Name))
                            myButton.ColorsAvailable.setColors(mycolors)
                        End If

                        myButton.Color = LCARS.LCARScolorStyles.MiscFunction
                        Dim ext As String = Path.GetExtension(curItem.FullName).Replace(".", "")
                        If ext <> "" Then
                            If ext.Length > 6 Then
                                ext = ext.Substring(1, 6) & "."
                            End If
                            myButton.SideText = ext.ToUpper  'ToDriveSize(curItem.Value.Length, True)
                        Else
                            myButton.SideText = "---"
                        End If
                        If My.Settings.ClickMode = "Single" Then
                            AddHandler myButton.Click, AddressOf myFile_Click
                        Else
                            AddHandler myButton.DoubleClick, AddressOf myFile_Click
                        End If

                    Catch ex As Exception
                        myButton.SideText = "--"
                        myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                        If My.Settings.ClickMode = "Single" Then
                            AddHandler myButton.Click, AddressOf myErrorAlert
                        Else
                            AddHandler myButton.DoubleClick, AddressOf myErrorAlert
                        End If
                    End Try

                End If


                AddHandler myButton.MouseDown, AddressOf drive_MouseDown
                AddHandler myButton.MouseUp, AddressOf drive_MouseUp

                myButton.Text = curItem.Name
                myButton.Data = curItem.FullName
                myButton.Beeping = beeping
                myButton.HoldDraw = False

                gridMyComp.Add(myButton)

            Next

        End If

    End Sub

    Private Sub myFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (cancelClick = False And CType(sender, LCARS.LightweightControls.LCComplexButton).SideText <> "--") Then
            Try
                Dim myNewProcess As New System.Diagnostics.ProcessStartInfo
                Dim myProcess As Process

                myNewProcess.FileName = sender.data
                myNewProcess.WorkingDirectory = curPath
                myProcess = Process.Start(myNewProcess)
            Catch
                Try
                    Shell(sender.data, AppWinStyle.NormalFocus)
                Catch ex As Exception
                    MsgBox("Error: " & vbNewLine & vbNewLine & ex.Message)
                End Try
            End Try
        End If
    End Sub

    Private Sub pnlMyComp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseDown 'pnlMyComp.MouseDown
        selectedButtons.Clear()
        checkSelected(0, 0, 0, 0)
        selStart = e.Location
    End Sub

    Private Sub pnlMyComp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseMove ' pnlMyComp.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            tmrMouseSelect.Enabled = False
            Dim x1, x2, y1, y2 As Integer

            If e.X > selStart.X Then
                x1 = selStart.X
                x2 = e.X
            Else
                x1 = e.X
                x2 = selStart.X
            End If

            If e.Y > selStart.Y Then
                y1 = selStart.Y
                y2 = e.Y
            Else
                y1 = e.Y
                y2 = selStart.Y
            End If

            mySelection.Bounds = gridMyComp.RectangleToScreen(New Rectangle(x1, y1, x2 - x1, y2 - y1))
            If mySelection.Visible = False Then
                mySelection.Show()
            End If

            checkSelected(x1, y1, x2, y2)
        End If
    End Sub

    Private Sub checkSelected(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal rememberSelection As Boolean = False)
        Dim myButton As LCARS.LightweightControls.LCComplexButton
        For i As Integer = 0 To gridMyComp.Count - 1
            myButton = CType(gridMyComp.Items(i), LCARS.LightweightControls.LCComplexButton)
            If myButton.Bounds.Bottom > y1 And myButton.Top < y2 And myButton.Bounds.Right > x1 And myButton.Left < x2 And myButton.HoldDraw = False Then
                If myButton.RedAlert <> LCARS.LCARSalert.White Then
                    myButton.RedAlert = LCARS.LCARSalert.White
                End If
                If rememberSelection Then
                    selectedButtons.Add(CType(myButton, LCARS.LightweightControls.LCComplexButton))
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

    Private Sub pnlMyComp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridMyComp.MouseUp ' pnlMyComp.MouseUp
        If Not e.Location = selStart Then
            Dim x1, x2, y1, y2 As Integer

            If e.X > selStart.X Then
                x1 = selStart.X
                x2 = e.X
            Else
                x1 = e.X
                x2 = selStart.X
            End If

            If e.Y > selStart.Y Then
                y1 = selStart.Y
                y2 = e.Y
            Else
                y1 = e.Y
                y2 = selStart.Y
            End If

            checkSelected(x1, y1, x2, y2, True)
        End If
        mySelection.Hide()
    End Sub


    Private Sub sbProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProperties.Click
        If selectedButtons.Count > 0 Then
            Dim props As New frmProperties(selectedButtons)
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

        If curPath <> "" Then
            curPath = curPath.Substring(0, Len(curPath) - 1)
            If InStr(curPath, "\") > 0 Then
                curPath = curPath.Substring(0, InStrRev(curPath, "\") - 1)
                If curPath.Length = 2 Then
                    curPath += "\"
                End If
                loadDir(curPath)
            Else
                sbUpDir.Lit = False
                curPath = ""
                loadMyComp()
            End If
        End If
    End Sub


    Private Sub sbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDelete.Click
        Dim result As MsgBoxResult

        result = MsgBox("Are you sure you want to delete the selected file(s)/folder(s)?!", MsgBoxStyle.YesNo, "DELETE?")

        If result = MsgBoxResult.Yes Then
            Dim myfiles(-1) As String
            For Each myButton As LCARS.LightweightControls.LCComplexButton In selectedButtons
                ReDim Preserve myfiles(myfiles.GetUpperBound(0) + 1)
                myfiles(myfiles.GetUpperBound(0)) = myButton.Data
            Next
            Dim form As New frmCopying(myfiles, "", frmCopying.FileActions.Delete)
            AddHandler form.TaskCompleted, AddressOf Task_Finished
            form.Show()
        End If

    End Sub

    Private Sub sbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCopy.Click
        Dim myfiles(-1) As String

        For Each myButton As LCARS.LightweightControls.LCComplexButton In selectedButtons
            ReDim Preserve myfiles(myfiles.GetUpperBound(0) + 1)
            myfiles(myfiles.GetUpperBound(0)) = myButton.Data
        Next

        If Not myfiles Is Nothing Then
            Dim myStream As New MemoryStream(4)
            Dim bytes(3) As Byte
            bytes(0) = 5
            bytes(1) = 0
            bytes(2) = 0
            bytes(3) = 0

            myStream.Write(bytes, 0, bytes.Length)
            Dim data_object As New DataObject()
            data_object.SetData("FileDrop", True, myfiles)
            data_object.SetData("Preferred DropEffect", myStream)

            Clipboard.Clear()
            Clipboard.SetDataObject(data_object, True)

        End If
    End Sub

    Private Sub sbCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCut.Click

        Dim myfiles(-1) As String

        For Each myButton As LCARS.LightweightControls.LCComplexButton In selectedButtons
            ReDim Preserve myfiles(myfiles.GetUpperBound(0) + 1)
            myfiles(myfiles.GetUpperBound(0)) = myButton.Data
        Next

        If Not myfiles Is Nothing Then
            Dim myStream As New MemoryStream(4)
            Dim bytes(3) As Byte
            bytes(0) = 2
            bytes(1) = 0
            bytes(2) = 0
            bytes(3) = 0

            myStream.Write(bytes, 0, bytes.Length)
            Dim data_object As New DataObject()
            data_object.SetData("FileDrop", True, myfiles)
            data_object.SetData("Preferred DropEffect", myStream)

            Clipboard.Clear()
            Clipboard.SetDataObject(data_object, True)

        End If
    End Sub

    Private Sub Clipboard_Changed()
        If Clipboard.ContainsFileDropList Then
            sbPaste.Lit = True
            sbPaste.Clickable = True
        Else
            sbPaste.Lit = False
            sbPaste.Clickable = False
        End If
    End Sub

    Private Sub sbPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPaste.Click
        If Clipboard.ContainsFileDropList = True Then
            Dim data As IDataObject = Clipboard.GetDataObject

            Dim files() As String = DirectCast(Clipboard.GetData(DataFormats.FileDrop), String())
            Dim MyStream As MemoryStream = DirectCast(data.GetData("Preferred DropEffect", True), MemoryStream)
            Dim flag As Integer = MyStream.ReadByte

            If flag = 2 Then
                'cut
                Dim form As New frmCopying(files, curPath, frmCopying.FileActions.Cut)
                AddHandler form.TaskCompleted, AddressOf Task_Finished
                form.Show()
                Clipboard.Clear()
            Else
                'copy
                Dim form As New frmCopying(files, curPath, frmCopying.FileActions.Copy)
                AddHandler form.TaskCompleted, AddressOf Task_Finished
                form.Show()
            End If
        End If
    End Sub

    Private Sub CopyPaths(ByVal SourcePaths() As String, ByVal Dest As String, ByVal delete As Boolean)

        For Each myPath As String In SourcePaths
            If Directory.Exists(myPath) Then
                If (Directory.Exists(Dest + "\" + System.IO.Path.GetFileNameWithoutExtension(myPath))) Then
                    If (MsgBox("Merge with existing directory " & System.IO.Path.GetFileNameWithoutExtension(myPath) & "?", MsgBoxStyle.YesNo, "Merge Directory?") = MsgBoxResult.Yes) Then
                        My.Computer.FileSystem.CopyDirectory(myPath, Dest + "\" + System.IO.Path.GetFileNameWithoutExtension(myPath), True)
                        If delete = True Then
                            My.Computer.FileSystem.DeleteDirectory(myPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                    End If
                Else
                    My.Computer.FileSystem.CreateDirectory(Dest + "\" + System.IO.Path.GetFileNameWithoutExtension(myPath))
                    My.Computer.FileSystem.CopyDirectory(myPath, Dest + "\" + System.IO.Path.GetFileNameWithoutExtension(myPath))
                    If delete = True Then
                        My.Computer.FileSystem.DeleteDirectory(myPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                End If
            Else
                If File.Exists(myPath) Then

                    Dim destFile As String = Dest & "\" & Path.GetFileName(myPath)

                    If File.Exists(Dest & "\" & Path.GetFileName(myPath)) Then
                        Dim result As MsgBoxResult = MsgBox("Overwrite file " & Path.GetFileName(myPath) & "?", MsgBoxStyle.YesNo, "OVERWRITE FILE?")

                        If result = MsgBoxResult.Yes Then
                            If delete = True Then
                                File.Delete(destFile)
                                File.Move(myPath, destFile)
                            Else
                                File.Delete(destFile)
                                File.Copy(myPath, destFile)
                            End If
                        End If

                    Else
                        If delete = True Then
                            File.Move(myPath, destFile)
                        Else
                            File.Copy(myPath, destFile)
                        End If
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub sbRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbRename.Click
        If selectedButtons.Count = 1 Then
            Dim path As String = CStr(CType(selectedButtons(1), LCARS.LightweightControls.LCComplexButton).Data)
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
        strName = inputbox("Enter the name of the new folder", "New Folder")
        If (curPath.EndsWith("\")) Then
            strName = curPath + strName
        Else
            strName = curPath + "\" + strName
        End If
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
                Shell("""" & newProg & """" & " """ & selectedButtons(1).data.ToString() & """", AppWinStyle.NormalFocus)
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
        pnlSystemDefined.Visible = False
        If (pnlEdit.Visible = False) Then
            pnlEdit.Visible = True
            pnlEdit.BringToFront()
        Else
            pnlEdit.Visible = False
        End If
    End Sub

    Private Sub sbGoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGoTo.Click
        pnlEdit.Visible = False
        If (pnlSystemDefined.Visible = True) Then
            pnlSystemDefined.Visible = False
        Else
            loadShortcuts()
            pnlSystemDefined.Visible = True
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
        loadDir(sender.data)
    End Sub
    Private Sub myErrorAlert(ByVal sender As Object, ByVal e As EventArgs)
        LCARS.Alerts.ActivateAlert("Red", Me.Handle)
        MsgBox("Error: Access Denied", MsgBoxStyle.Critical, "Access Denied")
        LCARS.Alerts.DeactivateAlert(Me.Handle)
        Try
            CType(sender, LCARS.LCARSbuttonClass).RedAlert = LCARS.LCARSalert.Normal
        Catch ex As Exception
        End Try
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
                result = myReg.GetValue("My Video")
                SaveSetting("LCARS x32", "Application", "Videos", result)
            Catch ex As Exception
            End Try
            If result = "" Then
                Dim res As DialogResult = MsgBox("Unable to find ""My Videos"". Would you like to manually set the path?", MsgBoxStyle.YesNo)
                If res = DialogResult.Yes Then
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
        Me.Invoke(New NoArgs(AddressOf Reload))
    End Sub

    Private Sub Reload()
        loadDir(curPath)
    End Sub
End Class