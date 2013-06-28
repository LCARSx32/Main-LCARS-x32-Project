Imports System.IO
Imports Microsoft.Win32
Public Class frmFileSelect

    Dim curPath As String = ""
    Dim CurItems As New exCollection
    Dim beeping As Boolean = False
    Dim bpp As Integer 'buttons per page
    Dim cancelClick As Boolean = False
    Dim pageCount As Integer
    Dim curPage As Integer
    Dim extensions() As String = {}
    Dim myResult As Windows.Forms.DialogResult
    Dim oloc As Point

    Private Sub sbUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUp.Click

        If curPath <> "" Then
            curPath = curPath.Substring(0, Len(curPath) - 1)
            If InStr(curPath, "\") > 0 Then
                curPath = curPath.Substring(0, InStrRev(curPath, "\") - 1)
                If curPath.Length = 2 Then
                    curPath += "\"
                End If
                loadDir(curPath)
            Else
                sbUp.Lit = False
                curPath = ""
                loadMyComp()
            End If
        End If
    End Sub
    Private Sub loadMyComp()
        Dim myDrives() As DriveInfo = DriveInfo.GetDrives
        Dim ButtonTop As Integer = 17
        Dim ButtonLeft As Integer = 0
        Dim ButtonWidth As Integer = pnlMyComp.Width - 20
        pnlMyComp.Controls.Clear()
        hpLocation.ButtonText = "MY COMPUTER"
        For Each myDrive As DriveInfo In myDrives
            Dim myButton As New LCARS.Controls.ComplexButton
            myButton.holdDraw = True

            If myDrive.IsReady Then
                myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
                myButton.ButtonText = myDrive.VolumeLabel & " (" & myDrive.Name & ")"
                myButton.SideText = ToDriveSize(myDrive.TotalSize)
                AddHandler myButton.Click, AddressOf drive_click
            Else
                myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                myButton.ButtonText = "DRIVE OFFLINE (" & myDrive.Name & ")"
                myButton.SideText = "--"
                AddHandler myButton.Click, AddressOf OfflineDrive_click
            End If
            myButton.Data = myDrive.Name
            myButton.Width = ButtonWidth
            myButton.Left = ButtonLeft
            myButton.Top = ButtonTop
            myButton.Height = 30
            myButton.Beeping = beeping
            myButton.holdDraw = False

            pnlMyComp.Controls.Add(myButton)

            If ButtonTop + 65 < pnlMyComp.Height Then
                ButtonTop += 35
            Else
                ButtonTop = 17
                If ButtonLeft + ((ButtonWidth * 2) + 8) < pnlMyComp.Width Then
                    ButtonLeft += ButtonWidth + 8
                Else
                    Exit For
                End If
            End If
        Next

    End Sub
    Private Function ToDriveSize(ByVal bytes As Decimal, Optional ByVal Round As Boolean = False) As String
        Dim mySize As String = ""
        Dim SizeCount As Decimal = bytes
        Dim Remainder As Integer = 0
        Dim SizeType As String = "B"


        If SizeCount > 1024 Then
            SizeType = "KB"
            SizeCount = SizeCount / 1024

            If SizeCount > 1024 Then
                SizeType = "MB"
                SizeCount = SizeCount / 1024

                If SizeCount > 1024 Then
                    SizeType = "GB"
                    SizeCount = SizeCount / 1024

                    If SizeCount > 1024 Then
                        SizeType = "TB"
                        SizeCount = SizeCount / 1024

                        If SizeCount > 1024 Then
                            SizeType = "HB"
                            SizeCount = SizeCount / 1024
                        End If
                    End If
                End If
            End If
        End If

        If Round = True Then
            Return Math.Round(SizeCount) & SizeType
        Else
            Return SizeCount.ToString("N2") & SizeType
        End If
    End Function

    Private Sub drive_click(ByVal sender As Object, ByVal e As EventArgs)
        If cancelClick = False Then
            loadDir(CType(sender, LCARS.LCARSbuttonClass).Data)
        End If
    End Sub


    Private Sub OfflineDrive_click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Public Sub loadDir(ByVal path As String)
        If path = "" Then
            loadMyComp()
        Else
            Dim myDir As DirectoryInfo = New DirectoryInfo(path)

            curPath = path
            CurItems.Clear()

            Dim title As String = System.IO.Path.GetFileNameWithoutExtension(curPath)
            If title <> "" Then
                hpLocation.ButtonText = title
            Else
                hpLocation.ButtonText = path
            End If



            For Each curDir As DirectoryInfo In myDir.GetDirectories
            	Try
                    curDir.GetDirectories()
                    CurItems.Add(curDir, "dir")
                Catch ex As Exception

                End Try
            Next

            For Each curFile As FileInfo In myDir.GetFiles
                Dim i As Integer = 1
                Try
                    Dim blank As String = curFile.Extension

                    While (i < extensions.Length)
                        If (curFile.Extension = extensions(i) And curFile.Extension <> "") Then
                            CurItems.Add(curFile, "file")
                        End If
                        i += 1
                    End While
                Catch ex As Exception
                End Try
            Next

            CalcPages()

            loadPage(0)
        End If

    End Sub

    Private Sub CalcPages()
        Dim x As Integer = 15
        Dim y As Integer = 17

        y = (pnlMyComp.Height - 17) \ 35
        x = (pnlMyComp.Width - 30) \ 308
        bpp = 0
        Do
            If y + 65 < pnlMyComp.Height Then
                y += 35
                bpp += 1
            Else
                If x + 608 < pnlMyComp.Width Then
                    bpp += 1
                    y = 17
                    x += 308
                Else
                    Exit Do
                End If
            End If
        Loop




        PageCount = CurItems.Count \ bpp

        If CurItems.Count Mod bpp > 0 Then
            PageCount += 1
        End If
        scrlBar.Visible = False
        If (pageCount > 1) Then
            scrlBar.Maximum = pageCount - 1
            scrlBar.Value = 0
            scrlBar.Visible = True
        End If
    End Sub

    Public Sub loadPage(Optional ByVal startIndex As Integer = 0)
        pnlMyComp.Visible = False
        curPage = startIndex
        sbUp.Lit = True


        Dim ButtonTop As Integer = 17
        Dim ButtonLeft As Integer = 0
        Dim intloop As Integer

        pnlMyComp.Controls.Clear()

        For intloop = startIndex To CurItems.Count - 1

            Dim curItem As exCollectionItem = CurItems.Item(intloop)
            Dim myButton As New LCARS.Controls.ComplexButton

            myButton.holdDraw = True

            If curItem.Key = "dir" Then
                Try
                    myButton.Color = LCARS.LCARScolorStyles.NavigationFunction
                    myButton.SideText = curItem.Value.GetDirectories.GetUpperBound(0) + 1 & "." & curItem.Value.GetFiles.GetUpperBound(0) + 1
                    AddHandler myButton.Click, AddressOf drive_click
                Catch ex As Exception
                    myButton.SideText = "--"
                    myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                    AddHandler myButton.Click, AddressOf myErrorAlert
                End Try

            Else
                Try
                    'Dim mycolors() As String = myButton.ColorsAvailable.getColors
                    'mycolors(2) = getExtColor(Path.GetExtension(curItem.Value.name))
                    'myButton.ColorsAvailable.setColors(mycolors)

                    myButton.Color = LCARS.LCARScolorStyles.MiscFunction
                    Dim ext As String = Path.GetExtension(curItem.Value.FullName).Replace(".", "")
                    If ext <> "" Then
                        If ext.Length > 6 Then
                            ext = ext.Substring(1, 6) & "."
                        End If
                        myButton.SideText = ext.ToUpper  'ToDriveSize(curItem.Value.Length, True)
                    Else
                        myButton.SideText = "---"
                    End If
                    AddHandler myButton.Click, AddressOf myFile_Click
                Catch ex As Exception
                    myButton.SideText = "--"
                    myButton.Color = LCARS.LCARScolorStyles.FunctionOffline
                    AddHandler myButton.Click, AddressOf myErrorAlert
                End Try

            End If

            myButton.ButtonText = curItem.Value.name
            myButton.Data = curItem.Value.FullName
            myButton.Width = pnlMyComp.Width - 20
            myButton.Left = ButtonLeft
            myButton.Top = ButtonTop
            myButton.Height = 25
            myButton.Beeping = beeping
            myButton.holdDraw = False

            pnlMyComp.Controls.Add(myButton)

            If ButtonTop + 65 < pnlMyComp.Height Then
                ButtonTop += 35
            Else
                ButtonTop = 17
                If ButtonLeft + 608 < pnlMyComp.Width Then
                    ButtonLeft += 308
                Else
                    Exit For
                End If
            End If
        Next

        pnlMyComp.Visible = True

    End Sub
    Private Sub myFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblCurrentSelected.Text = sender.data
    End Sub
    Private Sub frmFileSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCurrentSelected.Text = ""
        loadDir(curPath)
    End Sub

    Private Sub sbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        Result = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub scrlBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlBar.Scroll
        loadPage(scrlBar.Value * 8)
    End Sub

    Private Sub sbOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbOK.Click
        If (lblCurrentSelected.Text <> "") Then
            result = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Public Sub New(Optional ByVal startDir As String = "", Optional ByVal filters As String = "", Optional ByVal title As String = "")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        curPath = startDir
        While (filters.Length > 0)
            Dim index As Integer = filters.IndexOf(",")
            If (index <> 0) Then
                extensions = extend(extensions, filters.Substring(0, index))
                fbExt.Text += filters.Substring(0, index) & vbNewLine
                filters = filters.Remove(0, index + 1)
            End If
        End While
        hpPrompt.Text = title
    End Sub
    Public Property Result() As Windows.Forms.DialogResult
        Get
            Return myResult
        End Get
        Set(ByVal value as Windows.Forms.DialogResult)
            myResult = value
        End Set
    End Property
    Public ReadOnly Property ReturnPath() As String
        Get
            Return lblCurrentSelected.Text
        End Get
    End Property
    Private Function extend(ByVal array() As String, ByVal item As String) As String()
        ReDim Preserve array(array.Length + 1)
        array(array.Length - 1) = item
        Return array
    End Function
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
        MsgBox("Error: Access Denied")
    End Sub
End Class
