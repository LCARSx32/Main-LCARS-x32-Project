Public Class frmPic

#Region " Window Resizing "
    Declare Function RegisterWindowMessageA Lib "user32.dll" (ByVal lpString As String) As Integer
    Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public InterMsgID As Integer
    Const WM_COPYDATA As Integer = &H4A
    Dim x32Handle As IntPtr = IntPtr.Zero
    Public Const HWND_BROADCAST As Integer = &HFFFF

    Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cdData As Integer
        Public lpData As IntPtr
    End Structure
#End Region

    'a collection to hold the paths to our pictures

    Dim myFiles As New Collection

    'index keeps track of where we are in the array.  It represents the location of the current image.
    Dim index As Integer

    Private Sub frmPic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InterMsgID = RegisterWindowMessageA("LCARS_X32_MSG")
        x32Handle = GetSetting("LCARS x32", "Application", "MainWindowHandle", "0")
        SendMessage(x32Handle, InterMsgID, Me.Handle, 1)

        Me.Bounds = Screen.PrimaryScreen.WorkingArea

        'sets initial picture box status to empty & prevents icon from displaying in pic box
        picturebox1.InitialImage = Nothing

        'Extracts path from file clicked in folder views
        Dim file As String()
        file = Environment.GetCommandLineArgs()
        If file.Length > 1 Then
            TextBox3.Text = (file(1).ToString())
            'loads image into picturebox
            picturebox1.ImageLocation = TextBox3.Text

        Else

            If file.Length < 1 Then
                picturebox1.Image = Nothing
            End If
        End If

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = InterMsgID And m.LParam = 13 Then
            Me.Close()
            End

        ElseIf m.Msg = WM_COPYDATA And m.WParam = x32Handle And Not x32Handle = IntPtr.Zero Then
            Dim myData As New COPYDATASTRUCT
            myData = System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(COPYDATASTRUCT))

            Dim myRect As New Rectangle
            myRect = System.Runtime.InteropServices.Marshal.PtrToStructure(myData.lpData, GetType(Rectangle))

            If Not Me.Bounds = myRect Then
                Me.Bounds = myRect
            End If


        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub loadImages(ByVal curIndex As Integer)
        If myFiles.Count > 0 Then
            Dim lastIndex As Integer
            Dim nextIndex As Integer

            If curIndex > 1 Then
                lastIndex = curIndex - 1
            Else
                lastIndex = myFiles.Count
            End If

            If curIndex + 1 <= myFiles.Count Then
                nextIndex = curIndex + 1
            Else
                nextIndex = 1
            End If

            If Not picturebox1.Image Is Nothing Then
                picturebox1.Image.Dispose()
            End If

            Dim myinfo As New System.IO.FileInfo(myFiles(curIndex))

            picturebox1.Image = Image.FromFile(myFiles(curIndex))
            lblInfo.Text = myinfo.Name & vbNewLine & vbNewLine & _
                          "RESOLUTION: " & picturebox1.Image.Width & "x" & picturebox1.Image.Height & vbNewLine & _
                         "FILE SIZE: " & myinfo.Length & " bytes" & vbNewLine & _
           "CREATED: " & myinfo.CreationTime.ToShortDateString & vbNewLine & _
            "MODIFIED: " & myinfo.LastWriteTime.ToShortDateString & vbNewLine
            '"NAME: " & myinfo.FullName.ToString & vbNewLine


            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)



            lastIndex = Nothing
            nextIndex = Nothing
        End If

    End Sub



    Private Sub tmrShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrShow.Tick
        abNext_Click(sender, e)



    End Sub

    Private Sub sbShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbShow.Click



        tmrShow.Enabled = Not tmrShow.Enabled

        If tmrShow.Enabled = True Then
            sbShow.ButtonText = "Stop Slideshow"

        Else
            sbShow.ButtonText = "Start Slideshow"



        End If
    End Sub

    Private Sub sbBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbBrowse.Click
        Dim myDir As New FolderBrowserDialog
        Dim result As DialogResult

        result = myDir.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            Dim tmpFiles() As String = System.IO.Directory.GetFiles(myDir.SelectedPath)

            For Each curFile As String In tmpFiles
                Dim ext As String = System.IO.Path.GetExtension(curFile).ToLower

                If ext = ".jpg" Or ext = ".jpeg" Or ext = ".gif" Or ext = ".bmp" _
               Or ext = ".png" Or ext = ".tif" Or ext = ".tiff" Then
                    myFiles.Add(curFile)
                End If
                ext = Nothing
                curFile = Nothing
            Next

            tmpFiles = Nothing

            index = 1
            loadImages(index)

      

        End If

        Dim origpicboxwidth As Integer = picturebox1.Width
        TextBox1.Text = origpicboxwidth

        Dim origpicboxheight As Integer = picturebox1.Height
        TextBox2.Text = origpicboxheight




    End Sub

    Private Sub abNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abNext.Click

        If index + 1 > myFiles.Count Then
            ''we're past the end of the array, so start over
            index = 1
        Else
            index += 1
        End If

        loadImages(index)
    End Sub

    Private Sub abPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abPrev.Click

        picturebox1.SizeMode = PictureBoxSizeMode.Zoom

        If index > 1 Then
            index -= 1
        Else
            index = myFiles.Count
        End If

        loadImages(index)
    End Sub


    Private Sub fbZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbZoomOut.Click

        If picturebox1.Image IsNot Nothing Then

            picturebox1.Width = CInt(picturebox1.Width * 0.8)
            picturebox1.Height = CInt(picturebox1.Height * 0.8)

            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)

        End If

    End Sub

    Private Sub fbZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbZoomIn.Click

        If picturebox1.Image IsNot Nothing Then


            picturebox1.Width = CInt(picturebox1.Width * 1.2)
            picturebox1.Height = CInt(picturebox1.Height * 1.2)
            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)

        End If

    End Sub

    Private Sub fbActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbActual.Click

        If picturebox1.Image IsNot Nothing Then
            picturebox1.SizeMode = PictureBoxSizeMode.Zoom

            Dim origpicboxwidth As Integer
            origpicboxwidth = Convert.ToInt32(TextBox1.Text)
            origpicboxwidth = Integer.Parse(TextBox1.Text)

            Dim origpicboxheight As Integer
            origpicboxheight = Convert.ToInt32(TextBox2.Text)
            origpicboxheight = Integer.Parse(TextBox2.Text)

            picturebox1.Size = New Size(origpicboxwidth, origpicboxheight)

            Dim picboxlocx As Integer = 3
            Dim picboxlocy As Integer = 3
            picturebox1.Location = New Point(picboxlocx, picboxlocy)

            pbZoom.ButtonText = "ZOOM: " & Strings.FormatPercent(picturebox1.Width / picturebox1.Image.Width, 0)

  
        End If


    End Sub



    Private Sub ArrowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton1.Click


        If picturebox1.Image IsNot Nothing Then
            picturebox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            picturebox1.Refresh()
        End If

    End Sub

    Private Sub ArrowButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrowButton2.Click

        If picturebox1.Image IsNot Nothing Then
            picturebox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            picturebox1.Refresh()
        End If

    End Sub


    Private Sub sbExitMyComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExitMyComp.Click
        Me.Close()
        End
    End Sub



    Private Sub picturebox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles picturebox1.MouseEnter

        picturebox1.Focus()

    End Sub

  
    Private Sub dwn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwn.MouseDown
        If picturebox1.Image IsNot Nothing Then
            tmrdown.Enabled = True
        End If
    End Sub

    Private Sub dwn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwn.MouseUp
        tmrdown.Enabled = False
    End Sub
    Private Sub tmrdown_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrdown.Tick
        shiftdown()
    End Sub
    Private Sub shiftdown()
        Dim picboxlocy As Integer = picturebox1.Location.Y - 30
        Dim picboxlocx As Integer = picturebox1.Location.X
        picturebox1.Location = New Point(picboxlocx, picboxlocy)
    End Sub

    Private Sub lft_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lft.MouseDown
        If picturebox1.Image IsNot Nothing Then
            tmrleft.Enabled = True
        End If
    End Sub

    Private Sub lft_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lft.MouseUp
        tmrleft.Enabled = False
    End Sub

    Private Sub tmrleft_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrleft.Tick
        shiftleft()
    End Sub
    Private Sub shiftleft()

        Dim picboxlocy As Integer = picturebox1.Location.Y
        Dim picboxlocx As Integer = picturebox1.Location.X + 30
        picturebox1.Location = New Point(picboxlocx, picboxlocy)

    End Sub
    Private Sub rht_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rht.MouseDown
        If picturebox1.Image IsNot Nothing Then
            tmrright.Enabled = True
        End If
    End Sub

    Private Sub rht_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rht.MouseUp
        tmrright.Enabled = False
    End Sub

    Private Sub tmrright_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrright.Tick
        shiftright()
    End Sub

    Private Sub shiftright()

        Dim picboxlocy As Integer = picturebox1.Location.Y
        Dim picboxlocx As Integer = picturebox1.Location.X - 30
        picturebox1.Location = New Point(picboxlocx, picboxlocy)

    End Sub
    Private Sub up_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles up.MouseDown
        If picturebox1.Image IsNot Nothing Then
            tmrup.Enabled = True
        End If
    End Sub

    Private Sub up_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles up.MouseUp
        tmrup.Enabled = False
    End Sub

    Private Sub tmrup_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrup.Tick
        shiftup()
    End Sub

    Private Sub shiftup()

        Dim picboxlocy As Integer = picturebox1.Location.Y + 30
        Dim picboxlocx As Integer = picturebox1.Location.X
        picturebox1.Location = New Point(picboxlocx, picboxlocy)


    End Sub


End Class
