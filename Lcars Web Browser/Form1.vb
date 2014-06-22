Public Class form1
#Region " Window Resizing "
    Dim WithEvents interop As New LCARS.x32Interop

    Private Sub interop_BeepingChanged(ByVal Beeping As Boolean) Handles interop.BeepingChanged
        LCARS.SetBeeping(Me, Beeping)
    End Sub

    Private Sub interop_ColorsChanged() Handles interop.ColorsChanged
        LCARS.UpdateColors(Me)
    End Sub

    Private Sub interop_LCARSx32Closing() Handles interop.LCARSx32Closing
        Application.Exit()
    End Sub

#End Region

    Dim int1 As Integer = 0
    Private Enum exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum

    Private Enum execopt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOP_PROMPTUSER = 1
        OLECMDEXECOP_DONTPROMPTUSER = 2
        OLECMDEXECOP_SHOWHELP = 3
    End Enum

    Private Sub loading(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserProgressChangedEventArgs)
        ProgressBar1.Maximum = e.MaximumProgress
        ProgressBar1.Value = e.CurrentProgress

    End Sub

    Private Sub browser_done(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        'changes title of tab (WebPage) to webpage document title. 
        TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
        TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString

        sitesecurity()

    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click

        'This routine displays the selected tab url in the address bar when switching tabs.
        TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString
        sitesecurity()

    End Sub

    Private Sub sitesecurity()

        'Identifies secure websites and displays padlock symbol
        Dim webaddress As String
        webaddress = TextBox1.Text
        If webaddress.StartsWith("https:") Then
            PictureBox1.Visible = True
            FlatButton5.Width = 65

        ElseIf webaddress.StartsWith("http:") Then
            PictureBox1.Visible = False
            FlatButton5.Width = 95

        End If

    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        interop.Init()
        Me.Bounds = Screen.PrimaryScreen.WorkingArea

        'For zoom function
        FlatButton15.Visible = False
        FlatButton16.Visible = False

        'For secure website button display
        PictureBox1.Visible = False
        FlatButton5.Width = 95

        'Start animation
        Me.Visible = True
        AnimatePanel()

        'Load Bookmark items from Favlist
        For Each item As String In My.Settings.favList
            ListBox1.Items.Add(item)
        Next

        'Load bookmark system defaults
        FlatButton17.Clickable = False
        FlatButton17.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        FlatButton18.Clickable = False
        FlatButton18.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        GroupBox1.Visible = False

        'For secure website button display
        PictureBox1.Visible = False
        FlatButton5.Width = 95

        Dim browser As New WebBrowser
        TabControl1.TabPages.Add("NEW PAGE")
        browser.Name = "WebBrowser1"
        browser.Dock = DockStyle.Fill
        TabControl1.SelectedTab.Controls.Add(browser)


        'Extracts path from file clicked in folder views
        Dim file As String()
        file = Environment.GetCommandLineArgs()
        If file.Length > 1 Then
            Label4.Text = (file(1).ToString())
            'loads file into webbrowser
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(Label4.Text)
        End If


        AddHandler browser.ProgressChanged, AddressOf loading
        AddHandler browser.DocumentCompleted, AddressOf browser_done
        'AddHandler browser.NewWindow, AddressOf 
        int1 = int1 + 1
        If Label4.Text = "" Then
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()
            TextBox1.AutoCompleteMode = AutoCompleteMode.Suggest
            TextBox1.AutoCompleteSource = AutoCompleteSource.HistoryList
        End If

        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ScriptErrorsSuppressed = True
        LCARS.SetBeeping(Me, GetSetting("LCARS x32", "Application", "ButtonBeep", "TRUE"))
    End Sub

    Private Sub browser_newWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
        'CType(sender, WebBrowser).Url
    End Sub

    Public Class IEGetFavorites

        Public Shared Function GetFavoritesfromIE() As List(Of String)
            Dim list As New List(Of String)
            Try
                For Each favorites As String In _
                My.Computer.FileSystem.GetFiles(System.Environment.GetFolderPath(Environment.SpecialFolder.Favorites), _
                                                FileIO.SearchOption.SearchAllSubDirectories, "*.url")
                    Using sr As System.IO.StreamReader = New System.IO.StreamReader(favorites)
                        While Not sr.EndOfStream
                            Dim line As String = sr.ReadLine()
                            If line.Contains("BASEURL=") Then
                                list.Add(line.Replace("BASEURL=", ""))
                                Exit While
                            End If
                        End While
                    End Using
                Next
            Catch
                Return Nothing

            End Try
            Return list
        End Function
    End Class


    Private Sub FlatButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton17.Click

        'IMPORTS INTERNET EXPLORER FAVORITES


        ListBox1.Items.Clear()
        Try
            Dim list As New List(Of String)(IEGetFavorites.GetFavoritesfromIE())
            If list IsNot Nothing Then
                Me.ListBox1.Items.AddRange(list.ToArray())
            End If
        Catch ex As Exception

        End Try

        updatefavlist()

    End Sub

    Private Sub FlatButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton18.Click

        'DELETES ALL BOOKMARKS FROM APPLICATION



        My.Settings.favList.Clear()
        ListBox1.Items.Clear()
        My.Settings.Save()

    End Sub

    Private Sub FlatButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton12.Click

        'OPENS BOOKMARKS MENU SYSTEM 



        If TabControl1.Visible = True Then
            TabControl1.Visible = False
        Else : TabControl1.Visible = True
        End If

        If GroupBox1.Visible = False Then
            GroupBox1.Visible = True
        Else : GroupBox1.Visible = False
        End If

    End Sub


    Private Sub FlatButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton20.Click

        'DELETE INDIVIDUAL BOOKMARK


        My.Settings.favList.Remove(ListBox1.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        My.Settings.Save()

    End Sub

    Private Sub FlatButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton19.Click

        'ADDS URL TO BOOKMARKS



        My.Settings.favList.Add(TextBox1.Text)
        ListBox1.Items.Add(TextBox1.Text)
        My.Settings.Save()

    End Sub

    Private Sub updatefavlist()

        For Each item As String In ListBox1.Items
            My.Settings.favList.Add(item)
        Next
        My.Settings.Save()

    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick

        'NAVIGATE TO BOOKMARK.
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ListBox1.SelectedItem.ToString)
        GroupBox1.Visible = False
        TabControl1.Visible = True

    End Sub


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'Added by Ray Phillips 5/28/09

        'Allows the user to hit "Enter" when enterering text rather than having
        'to click on a button.  The textbox's "Multiline" property must be set 
        'to "TRUE" in order for this code to fire.  If multiline is false, windows
        'ignores the "Enter" key on textboxes.

        'The keycode for "Enter" is 13.  
        'Keycodes are the ASCII number for a character.
        If e.KeyChar = Chr(13) Then
            'Simulate clicking on the "Navigate" button.
            FlatButton4_Click(sender, New System.EventArgs)
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        'Converts the text in textbox1 to uppercase letters, then
        'puts the cursor back where it was in the textbox.

        Dim SelStart As Integer = TextBox1.SelectionStart

        TextBox1.Text = TextBox1.Text.ToLower
        TextBox1.SelectionStart = SelStart


    End Sub

    'Save Settings when closing form  
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.Save()
    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click


        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()

    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click



        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Stop()
    End Sub

    Private Sub FlatButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton6.Click



        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ScriptErrorsSuppressed = True


    End Sub

    Private Sub FlatButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton7.Click



        Dim browser As New WebBrowser
        TabControl1.TabPages.Add("NEW PAGE")
        TabControl1.SelectTab(int1)
        browser.Name = "WebBrowser1"
        browser.Dock = DockStyle.Fill
        TabControl1.SelectedTab.Controls.Add(browser)
        AddHandler browser.ProgressChanged, AddressOf loading
        AddHandler browser.DocumentCompleted, AddressOf browser_done
        int1 = int1 + 1

        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ScriptErrorsSuppressed = True


    End Sub

    Private Sub FlatButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton8.Click



        If Not TabControl1.TabPages.Count = 1 Then
            TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex)
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
            int1 = int1 - 1
        End If

    End Sub

    Private Sub Arrowbutton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arrowbutton1.Click



        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()

    End Sub

    Private Sub Arrowbutton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arrowbutton2.Click


        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()

    End Sub

    Private Sub FlatButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton4.Click




        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ScriptErrorsSuppressed = True

    End Sub


    Private Sub FlatButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton5.Click




        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ScriptErrorsSuppressed = True



    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton3.Click



        My.Settings.Save()
        Me.Close()
        End
    End Sub

    Private Sub AnimatePanel()

        'Animation sequence for buttons & elbows
        Dim interval As Integer = 25
        Dim index As Integer
        Dim makevisible As Boolean = True

        If makevisible = True Then
            Me.Visible = True
            Do Until index = Int(Replace(Me.Tag, ".", ""))

                For Each myControl As Control In Me.Controls
                    Try
                        If myControl.Tag = index Then
                            myControl.Visible = True
                            Application.DoEvents()

                        End If
                    Catch ex As Exception

                    End Try

                Next

                index += 1
                Threading.Thread.Sleep(interval)
                Application.DoEvents()

            Loop
        Else

            If Not Me.Tag Is Nothing Then
                If InStr(Me.Tag.ToString, ".") > 0 Then
                    index = Int(Replace(Me.Tag, ".", "")) - 1
                End If
            End If

            Do Until index = -1
                For Each myControl As Control In Me.Controls
                    Try
                        If myControl.Tag = index Then
                            myControl.Visible = False
                            Application.DoEvents()
                        End If
                    Catch ex As Exception

                    End Try
                Next
                index -= 1
                Application.DoEvents()
                Threading.Thread.Sleep(interval)
            Loop

            Me.Visible = False
            GC.Collect()

        End If

    End Sub

    Private Sub FlatButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton14.Click

        Try

            Dim res As Object = Nothing
            Dim myweb As Object

            myweb = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ActiveXInstance
            myweb.execWB(exec.OLECMDID_OPTICAL_ZOOM, execopt.OLECMDEXECOP_DONTPROMPTUSER, 120, IntPtr.Zero)

            FlatButton15.Visible = True
            FlatButton14.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub FlatButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton15.Click

        Try

            Dim res As Object = Nothing
            Dim myweb As Object

            myweb = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ActiveXInstance
            myweb.execWB(exec.OLECMDID_OPTICAL_ZOOM, execopt.OLECMDEXECOP_DONTPROMPTUSER, 150, IntPtr.Zero)

            FlatButton16.Visible = True
            FlatButton15.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub FlatButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton16.Click

        Try



            Dim res As Object = Nothing
            Dim myweb As Object

            myweb = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ActiveXInstance
            myweb.execWB(exec.OLECMDID_OPTICAL_ZOOM, execopt.OLECMDEXECOP_DONTPROMPTUSER, 100, IntPtr.Zero)

            FlatButton14.Visible = True
            FlatButton16.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        MessageBox.Show("This symbol shows that the site uses hypertext transfer with SSL/TLS protocol for ancryption and security. However this does NOT guarantee that the site is secure or safe to use. Website security should be verified independantly.")

    End Sub

    Private Sub Elbow1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Elbow1.Click

        'Locks the import favorites and delete all bookmarks feature


        If FlatButton17.Clickable = False Then
            FlatButton17.Clickable = True
            FlatButton17.Color = LCARS.LCARScolorStyles.MiscFunction
        ElseIf FlatButton17.Clickable = True Then
            FlatButton17.Clickable = False
            FlatButton17.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        End If

        If FlatButton18.Clickable = False Then
            FlatButton18.Clickable = True
            FlatButton18.Color = LCARS.LCARScolorStyles.MiscFunction
        ElseIf FlatButton18.Clickable = True Then
            FlatButton18.Clickable = False
            FlatButton18.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        End If

    End Sub

    Private Sub FlatButton33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton33.Click


        If FlatButton17.Clickable = False Then
            FlatButton17.Clickable = True
            FlatButton17.Color = LCARS.LCARScolorStyles.MiscFunction
        ElseIf FlatButton17.Clickable = True Then
            FlatButton17.Clickable = False
            FlatButton17.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        End If

        If FlatButton18.Clickable = False Then
            FlatButton18.Clickable = True
            FlatButton18.Color = LCARS.LCARScolorStyles.MiscFunction
        ElseIf FlatButton18.Clickable = True Then
            FlatButton18.Clickable = False
            FlatButton18.Color = LCARS.LCARScolorStyles.FunctionUnavailable
        End If

    End Sub

    Private Sub form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged, Me.SizeChanged
        Dim adjustedBounds As Rectangle = Screen.FromHandle(Me.Handle).WorkingArea
        adjustedBounds.Location -= Screen.FromHandle(Me.Handle).Bounds.Location
        If Not Me.MaximizedBounds = adjustedBounds Then
            Me.MaximizedBounds = adjustedBounds
        End If
    End Sub
End Class
