Imports System.Windows.Forms
Imports System.IO

Public Class LCARSfileBrowseDialog
    Public Enum LCARSDialogType
        Save = 0
        Open = 1
        FolderChooser = 2
    End Enum

    Dim _dialogType As LCARSDialogType = LCARSDialogType.Save
    Dim _fullscreen As Boolean = False

    Dim merged() As String
    Dim curDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.System)

    Dim isInit As Boolean = False


    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Bounds = screen.primaryscreen.bounds

    End Sub
    Sub New(ByVal DialogType As LCARSDialogType)
        InitializeComponent()
        Me.DialogType = DialogType
        Me.Bounds = Screen.PrimaryScreen.Bounds

    End Sub

    Public Property Fullscreen() As Boolean
        Get
            Return _fullscreen
        End Get
        Set(ByVal value As Boolean)
            _fullscreen = value
            If Fullscreen = True Then
                Me.Bounds = Screen.PrimaryScreen.Bounds
            Else
                Me.Bounds = Screen.PrimaryScreen.WorkingArea
            End If
        End Set
    End Property

    Public Property DialogType() As LCARSDialogType
        Get
            Return _dialogType
        End Get
        Set(ByVal value As LCARSDialogType)
            _dialogType = value

            Select Case DialogType
                Case LCARSDialogType.Save
                    sbTitle.ButtonText = "SAVE"
                    sbTitleBottom.ButtonText = "SAVE"
                Case LCARSDialogType.Open
                    sbTitle.ButtonText = "OPEN"
                    sbTitleBottom.ButtonText = "OPEN"
                Case LCARSDialogType.FolderChooser
                    sbTitle.ButtonText = "FOLDER CHOOSER"
                    sbTitleBottom.ButtonText = "FOLDER CHOOSER"
            End Select
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return txtFileName.Text
        End Get
        Set(ByVal value As String)
            txtFileName.Text = value
        End Set
    End Property

    Private Sub LCARSfileBrowseDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()

        loadDir(curDir)
        isInit = True
    End Sub


    Private Sub loadDir(ByVal dir As String)
        Dim x, y As Integer

        ReDim merged(-1)
        pnlFiles.Controls.Clear()

        If dir = "" Then
            'load My Computer.
            Dim myDrives() As DriveInfo = System.IO.DriveInfo.GetDrives

            For Each mydrive As DriveInfo In myDrives
                ReDim Preserve merged(merged.Length)
                merged(merged.GetUpperBound(0)) = mydrive.Name
            Next

        Else
            Dim myDirs() As String = Directory.GetDirectories(dir)
            Dim myFiles() As String = Directory.GetFiles(dir, cboFilter.Text)


            curDir = dir
            ReDim merged((myDirs.Length + myFiles.Length) - 1)

            Try
                Array.Copy(myDirs, merged, myDirs.Length)
                Array.Copy(myFiles, 0, merged, myDirs.Length, myFiles.Length)
            Catch
            End Try
        End If
        x = 6
        y = 6


        For Each myPath As String In merged
            Dim mybutton As New LCARS.Controls.StandardButton
            Dim myname As String = Path.GetFileName(myPath)

            If myname = "" Then myname = myPath

            mybutton.ButtonText = myname
            mybutton.Location = New System.Drawing.Point(x, y)
            mybutton.Width = 200
            mybutton.Height = 35
            mybutton.ButtonTextAlign = Drawing.ContentAlignment.BottomRight
            mybutton.Data = myPath


            If File.Exists(myPath) = False Then
                'It's a directory
                Dim dirInfo As New DirectoryInfo(myPath)

                mybutton.Color = LCARScolorStyles.NavigationFunction
                AddHandler mybutton.Click, AddressOf myDir_Click
            Else
                'it's a file
                mybutton.Color = LCARScolorStyles.MiscFunction
                AddHandler mybutton.Click, AddressOf myFile_Click
            End If


            pnlFiles.Controls.Add(mybutton)

            If y + (mybutton.Height * 2) + 6 < pnlFiles.Height Then
                y += mybutton.Height + 6
            Else
                If x + (mybutton.Width * 2) + 6 < pnlFiles.Width Then
                    x += mybutton.Width + 6
                    y = 6
                Else
                    Exit For
                End If
            End If
        Next


    End Sub

    Private Sub myDir_Click(ByVal Sender As Object, ByVal e As EventArgs)
        loadDir(Sender.data)
    End Sub

    Private Sub myFile_Click(ByVal sender As Object, ByVal e As EventArgs)
        LCARS.UI.MsgBox(sender.data)
    End Sub

    Private Sub LCARSfileBrowseDialog_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Me.Fullscreen = _fullscreen

    End Sub

    Private Sub sbSaveCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSaveCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub sbSaveOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbSaveOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub cboFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFilter.KeyDown
        If e.KeyData = Keys.Enter Then
            loadDir(curDir)
            e.Handled = True
        End If
    End Sub

    Private Sub cboFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFilter.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)

    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        If isInit = True Then loadDir(curDir)

    End Sub

   
    Private Sub sbMyDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbMyDocs.Click
        loadDir(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
    End Sub

    Private Sub sbDesktop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbDesktop.Click
        loadDir(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))

    End Sub

    Private Sub sbNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbNetwork.Click
        LCARS.UI.MsgBox("This function is not yet available.", MsgBoxStyle.OkCancel, "ERROR:")

    End Sub

    Private Sub fbUpDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbUpDir.Click
        Dim newdir As String = Path.GetDirectoryName(curDir)
        loadDir(newdir)
    End Sub
End Class