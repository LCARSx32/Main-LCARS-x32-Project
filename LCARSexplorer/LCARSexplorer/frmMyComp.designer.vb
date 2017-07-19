<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMyComp
    Inherits LCARS.LCARSForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim LcarScolor1 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.pnlVisible = New System.Windows.Forms.Panel
        Me.tmrMouseSelect = New System.Windows.Forms.Timer(Me.components)
        Me.pnlEdit = New System.Windows.Forms.Panel
        Me.sbRename = New LCARS.Controls.StandardButton
        Me.sbCut = New LCARS.Controls.StandardButton
        Me.sbPaste = New LCARS.Controls.StandardButton
        Me.sbDelete = New LCARS.Controls.StandardButton
        Me.sbCopy = New LCARS.Controls.StandardButton
        Me.pnlOptionalComponents = New System.Windows.Forms.Panel
        Me.sbEdit = New LCARS.Controls.StandardButton
        Me.sbFormat = New LCARS.Controls.StandardButton
        Me.sbOpenWith = New LCARS.Controls.StandardButton
        Me.sbNewFolder = New LCARS.Controls.StandardButton
        Me.pnlShortcuts = New System.Windows.Forms.Panel
        Me.pnlSystemDefined = New System.Windows.Forms.Panel
        Me.fbShortcutsBorder = New LCARS.Controls.FlatButton
        Me.sbSaveCurrent = New LCARS.Controls.StandardButton
        Me.sbEnterPath = New LCARS.Controls.StandardButton
        Me.sbVideos = New LCARS.Controls.StandardButton
        Me.sbMusic = New LCARS.Controls.StandardButton
        Me.sbPictures = New LCARS.Controls.StandardButton
        Me.sbDocuments = New LCARS.Controls.StandardButton
        Me.sbDesktop = New LCARS.Controls.StandardButton
        Me.sbMyComp = New LCARS.Controls.StandardButton
        Me.elbShortcutsBottom = New LCARS.Controls.Elbow
        Me.elbShortcutsTop = New LCARS.Controls.Elbow
        Me.sbClose = New LCARS.Controls.StandardButton
        Me.sbGoTo = New LCARS.Controls.StandardButton
        Me.sbOptions = New LCARS.Controls.StandardButton
        Me.tbTitle = New LCARS.Controls.TextButton
        Me.sbUpDir = New LCARS.Controls.StandardButton
        Me.fbActionsBorderRight = New LCARS.Controls.FlatButton
        Me.fbActionsBorderLeft = New LCARS.Controls.FlatButton
        Me.sbRefresh = New LCARS.Controls.StandardButton
        Me.sbProperties = New LCARS.Controls.StandardButton
        Me.elbActionsTop = New LCARS.Controls.Elbow
        Me.elbActionsBottom = New LCARS.Controls.Elbow
        Me.gridMyComp = New LCARS.Controls.ButtonGrid
        Me.pnlEdit.SuspendLayout()
        Me.pnlOptionalComponents.SuspendLayout()
        Me.pnlSystemDefined.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVisible
        '
        Me.pnlVisible.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVisible.Location = New System.Drawing.Point(533, 241)
        Me.pnlVisible.Name = "pnlVisible"
        Me.pnlVisible.Size = New System.Drawing.Size(87, 281)
        Me.pnlVisible.TabIndex = 54
        '
        'tmrMouseSelect
        '
        Me.tmrMouseSelect.Interval = 500
        '
        'pnlEdit
        '
        Me.pnlEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEdit.Controls.Add(Me.sbRename)
        Me.pnlEdit.Controls.Add(Me.sbCut)
        Me.pnlEdit.Controls.Add(Me.sbPaste)
        Me.pnlEdit.Controls.Add(Me.sbDelete)
        Me.pnlEdit.Controls.Add(Me.sbCopy)
        Me.pnlEdit.Location = New System.Drawing.Point(425, 207)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(95, 163)
        Me.pnlEdit.TabIndex = 93
        Me.pnlEdit.Visible = False
        '
        'sbRename
        '
        Me.sbRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbRename.Beeping = False
        Me.sbRename.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRename.ButtonText = "RENAME"
        Me.sbRename.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbRename.ButtonTextHeight = 14
        Me.sbRename.Clickable = False
        Me.sbRename.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbRename.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbRename.Data = Nothing
        Me.sbRename.Data2 = Nothing
        Me.sbRename.FlashInterval = 500
        Me.sbRename.holdDraw = False
        Me.sbRename.Lit = False
        Me.sbRename.Location = New System.Drawing.Point(5, 3)
        Me.sbRename.Name = "sbRename"
        Me.sbRename.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRename.Size = New System.Drawing.Size(87, 26)
        Me.sbRename.TabIndex = 53
        Me.sbRename.Text = "RENAME"
        '
        'sbCut
        '
        Me.sbCut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCut.Beeping = False
        Me.sbCut.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbCut.ButtonText = "CUT"
        Me.sbCut.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbCut.ButtonTextHeight = 14
        Me.sbCut.Clickable = True
        Me.sbCut.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbCut.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCut.Data = Nothing
        Me.sbCut.Data2 = Nothing
        Me.sbCut.FlashInterval = 500
        Me.sbCut.holdDraw = False
        Me.sbCut.Lit = True
        Me.sbCut.Location = New System.Drawing.Point(5, 99)
        Me.sbCut.Name = "sbCut"
        Me.sbCut.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCut.Size = New System.Drawing.Size(87, 26)
        Me.sbCut.TabIndex = 44
        Me.sbCut.Text = "CUT"
        '
        'sbPaste
        '
        Me.sbPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbPaste.Beeping = False
        Me.sbPaste.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbPaste.ButtonText = "PASTE"
        Me.sbPaste.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbPaste.ButtonTextHeight = 14
        Me.sbPaste.Clickable = True
        Me.sbPaste.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbPaste.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbPaste.Data = Nothing
        Me.sbPaste.Data2 = Nothing
        Me.sbPaste.FlashInterval = 500
        Me.sbPaste.holdDraw = False
        Me.sbPaste.Lit = True
        Me.sbPaste.Location = New System.Drawing.Point(5, 67)
        Me.sbPaste.Name = "sbPaste"
        Me.sbPaste.RedAlert = LCARS.LCARSalert.Normal
        Me.sbPaste.Size = New System.Drawing.Size(87, 26)
        Me.sbPaste.TabIndex = 43
        Me.sbPaste.Text = "PASTE"
        '
        'sbDelete
        '
        Me.sbDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbDelete.Beeping = False
        Me.sbDelete.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbDelete.ButtonText = "DELETE"
        Me.sbDelete.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbDelete.ButtonTextHeight = 14
        Me.sbDelete.Clickable = True
        Me.sbDelete.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbDelete.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDelete.Data = Nothing
        Me.sbDelete.Data2 = Nothing
        Me.sbDelete.FlashInterval = 500
        Me.sbDelete.holdDraw = False
        Me.sbDelete.Lit = True
        Me.sbDelete.Location = New System.Drawing.Point(5, 131)
        Me.sbDelete.Name = "sbDelete"
        Me.sbDelete.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDelete.Size = New System.Drawing.Size(87, 26)
        Me.sbDelete.TabIndex = 45
        Me.sbDelete.Text = "DELETE"
        '
        'sbCopy
        '
        Me.sbCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCopy.Beeping = False
        Me.sbCopy.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbCopy.ButtonText = "COPY"
        Me.sbCopy.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbCopy.ButtonTextHeight = 14
        Me.sbCopy.Clickable = True
        Me.sbCopy.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbCopy.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCopy.Data = Nothing
        Me.sbCopy.Data2 = Nothing
        Me.sbCopy.FlashInterval = 500
        Me.sbCopy.holdDraw = False
        Me.sbCopy.Lit = True
        Me.sbCopy.Location = New System.Drawing.Point(5, 35)
        Me.sbCopy.Name = "sbCopy"
        Me.sbCopy.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCopy.Size = New System.Drawing.Size(87, 26)
        Me.sbCopy.TabIndex = 42
        Me.sbCopy.Text = "COPY"
        '
        'pnlOptionalComponents
        '
        Me.pnlOptionalComponents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOptionalComponents.Controls.Add(Me.sbEdit)
        Me.pnlOptionalComponents.Controls.Add(Me.sbFormat)
        Me.pnlOptionalComponents.Controls.Add(Me.sbOpenWith)
        Me.pnlOptionalComponents.Controls.Add(Me.sbNewFolder)
        Me.pnlOptionalComponents.Location = New System.Drawing.Point(533, 251)
        Me.pnlOptionalComponents.Name = "pnlOptionalComponents"
        Me.pnlOptionalComponents.Size = New System.Drawing.Size(87, 259)
        Me.pnlOptionalComponents.TabIndex = 53
        Me.pnlOptionalComponents.Visible = False
        '
        'sbEdit
        '
        Me.sbEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbEdit.Beeping = False
        Me.sbEdit.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbEdit.ButtonText = "EDIT"
        Me.sbEdit.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbEdit.ButtonTextHeight = 14
        Me.sbEdit.Clickable = True
        Me.sbEdit.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbEdit.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbEdit.Data = Nothing
        Me.sbEdit.Data2 = Nothing
        Me.sbEdit.FlashInterval = 500
        Me.sbEdit.holdDraw = False
        Me.sbEdit.Lit = True
        Me.sbEdit.Location = New System.Drawing.Point(0, 3)
        Me.sbEdit.Name = "sbEdit"
        Me.sbEdit.RedAlert = LCARS.LCARSalert.Normal
        Me.sbEdit.Size = New System.Drawing.Size(87, 26)
        Me.sbEdit.TabIndex = 52
        Me.sbEdit.Text = "EDIT"
        '
        'sbFormat
        '
        Me.sbFormat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbFormat.Beeping = False
        Me.sbFormat.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbFormat.ButtonText = "FORMAT"
        Me.sbFormat.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbFormat.ButtonTextHeight = 14
        Me.sbFormat.Clickable = True
        Me.sbFormat.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbFormat.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbFormat.Data = Nothing
        Me.sbFormat.Data2 = Nothing
        Me.sbFormat.FlashInterval = 500
        Me.sbFormat.holdDraw = False
        Me.sbFormat.Lit = True
        Me.sbFormat.Location = New System.Drawing.Point(0, 35)
        Me.sbFormat.Name = "sbFormat"
        Me.sbFormat.RedAlert = LCARS.LCARSalert.Normal
        Me.sbFormat.Size = New System.Drawing.Size(87, 26)
        Me.sbFormat.TabIndex = 52
        Me.sbFormat.Text = "FORMAT"
        '
        'sbOpenWith
        '
        Me.sbOpenWith.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOpenWith.Beeping = False
        Me.sbOpenWith.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbOpenWith.ButtonText = "OPEN WITH"
        Me.sbOpenWith.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbOpenWith.ButtonTextHeight = 14
        Me.sbOpenWith.Clickable = True
        Me.sbOpenWith.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbOpenWith.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOpenWith.Data = Nothing
        Me.sbOpenWith.Data2 = Nothing
        Me.sbOpenWith.FlashInterval = 500
        Me.sbOpenWith.holdDraw = False
        Me.sbOpenWith.Lit = True
        Me.sbOpenWith.Location = New System.Drawing.Point(0, 99)
        Me.sbOpenWith.Name = "sbOpenWith"
        Me.sbOpenWith.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOpenWith.Size = New System.Drawing.Size(87, 26)
        Me.sbOpenWith.TabIndex = 42
        Me.sbOpenWith.Text = "OPEN WITH"
        '
        'sbNewFolder
        '
        Me.sbNewFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbNewFolder.Beeping = False
        Me.sbNewFolder.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbNewFolder.ButtonText = "NEW FOLDER"
        Me.sbNewFolder.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbNewFolder.ButtonTextHeight = 14
        Me.sbNewFolder.Clickable = True
        Me.sbNewFolder.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbNewFolder.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbNewFolder.Data = Nothing
        Me.sbNewFolder.Data2 = Nothing
        Me.sbNewFolder.FlashInterval = 500
        Me.sbNewFolder.holdDraw = False
        Me.sbNewFolder.Lit = True
        Me.sbNewFolder.Location = New System.Drawing.Point(0, 67)
        Me.sbNewFolder.Name = "sbNewFolder"
        Me.sbNewFolder.RedAlert = LCARS.LCARSalert.Normal
        Me.sbNewFolder.Size = New System.Drawing.Size(87, 26)
        Me.sbNewFolder.TabIndex = 42
        Me.sbNewFolder.Text = "NEW FOLDER"
        '
        'pnlShortcuts
        '
        Me.pnlShortcuts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlShortcuts.AutoScroll = True
        Me.pnlShortcuts.Location = New System.Drawing.Point(107, 26)
        Me.pnlShortcuts.Name = "pnlShortcuts"
        Me.pnlShortcuts.Size = New System.Drawing.Size(95, 267)
        Me.pnlShortcuts.TabIndex = 94
        '
        'pnlSystemDefined
        '
        Me.pnlSystemDefined.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSystemDefined.AutoScroll = True
        Me.pnlSystemDefined.Controls.Add(Me.pnlShortcuts)
        Me.pnlSystemDefined.Controls.Add(Me.fbShortcutsBorder)
        Me.pnlSystemDefined.Controls.Add(Me.sbSaveCurrent)
        Me.pnlSystemDefined.Controls.Add(Me.sbEnterPath)
        Me.pnlSystemDefined.Controls.Add(Me.sbVideos)
        Me.pnlSystemDefined.Controls.Add(Me.sbMusic)
        Me.pnlSystemDefined.Controls.Add(Me.sbPictures)
        Me.pnlSystemDefined.Controls.Add(Me.sbDocuments)
        Me.pnlSystemDefined.Controls.Add(Me.sbDesktop)
        Me.pnlSystemDefined.Controls.Add(Me.sbMyComp)
        Me.pnlSystemDefined.Controls.Add(Me.elbShortcutsBottom)
        Me.pnlSystemDefined.Controls.Add(Me.elbShortcutsTop)
        Me.pnlSystemDefined.Location = New System.Drawing.Point(317, 177)
        Me.pnlSystemDefined.Name = "pnlSystemDefined"
        Me.pnlSystemDefined.Size = New System.Drawing.Size(200, 326)
        Me.pnlSystemDefined.TabIndex = 94
        Me.pnlSystemDefined.Visible = False
        '
        'fbShortcutsBorder
        '
        Me.fbShortcutsBorder.Beeping = False
        Me.fbShortcutsBorder.ButtonText = ""
        Me.fbShortcutsBorder.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbShortcutsBorder.ButtonTextHeight = 14
        Me.fbShortcutsBorder.Clickable = False
        Me.fbShortcutsBorder.Color = LCARS.LCARScolorStyles.StaticTan
        Me.fbShortcutsBorder.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbShortcutsBorder.Data = Nothing
        Me.fbShortcutsBorder.Data2 = Nothing
        Me.fbShortcutsBorder.FlashInterval = 500
        Me.fbShortcutsBorder.holdDraw = False
        Me.fbShortcutsBorder.Lit = True
        Me.fbShortcutsBorder.Location = New System.Drawing.Point(3, 43)
        Me.fbShortcutsBorder.Name = "fbShortcutsBorder"
        Me.fbShortcutsBorder.RedAlert = LCARS.LCARSalert.Normal
        Me.fbShortcutsBorder.Size = New System.Drawing.Size(5, 240)
        Me.fbShortcutsBorder.TabIndex = 95
        '
        'sbSaveCurrent
        '
        Me.sbSaveCurrent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSaveCurrent.Beeping = False
        Me.sbSaveCurrent.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbSaveCurrent.ButtonText = "SAVE CURRENT"
        Me.sbSaveCurrent.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSaveCurrent.ButtonTextHeight = 14
        Me.sbSaveCurrent.Clickable = True
        Me.sbSaveCurrent.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbSaveCurrent.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbSaveCurrent.Data = Nothing
        Me.sbSaveCurrent.Data2 = Nothing
        Me.sbSaveCurrent.FlashInterval = 500
        Me.sbSaveCurrent.holdDraw = False
        Me.sbSaveCurrent.Lit = True
        Me.sbSaveCurrent.Location = New System.Drawing.Point(14, 253)
        Me.sbSaveCurrent.Name = "sbSaveCurrent"
        Me.sbSaveCurrent.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSaveCurrent.Size = New System.Drawing.Size(87, 26)
        Me.sbSaveCurrent.TabIndex = 52
        Me.sbSaveCurrent.Text = "SAVE CURRENT"
        '
        'sbEnterPath
        '
        Me.sbEnterPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbEnterPath.Beeping = False
        Me.sbEnterPath.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbEnterPath.ButtonText = "ENTER PATH"
        Me.sbEnterPath.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbEnterPath.ButtonTextHeight = 14
        Me.sbEnterPath.Clickable = True
        Me.sbEnterPath.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbEnterPath.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbEnterPath.Data = Nothing
        Me.sbEnterPath.Data2 = Nothing
        Me.sbEnterPath.FlashInterval = 500
        Me.sbEnterPath.holdDraw = False
        Me.sbEnterPath.Lit = True
        Me.sbEnterPath.Location = New System.Drawing.Point(14, 221)
        Me.sbEnterPath.Name = "sbEnterPath"
        Me.sbEnterPath.RedAlert = LCARS.LCARSalert.Normal
        Me.sbEnterPath.Size = New System.Drawing.Size(87, 26)
        Me.sbEnterPath.TabIndex = 52
        Me.sbEnterPath.Text = "ENTER PATH"
        '
        'sbVideos
        '
        Me.sbVideos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbVideos.Beeping = False
        Me.sbVideos.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbVideos.ButtonText = "MY VIDEOS"
        Me.sbVideos.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbVideos.ButtonTextHeight = 14
        Me.sbVideos.Clickable = True
        Me.sbVideos.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbVideos.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbVideos.Data = Nothing
        Me.sbVideos.Data2 = Nothing
        Me.sbVideos.FlashInterval = 500
        Me.sbVideos.holdDraw = False
        Me.sbVideos.Lit = True
        Me.sbVideos.Location = New System.Drawing.Point(14, 189)
        Me.sbVideos.Name = "sbVideos"
        Me.sbVideos.RedAlert = LCARS.LCARSalert.Normal
        Me.sbVideos.Size = New System.Drawing.Size(87, 26)
        Me.sbVideos.TabIndex = 52
        Me.sbVideos.Text = "MY VIDEOS"
        '
        'sbMusic
        '
        Me.sbMusic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbMusic.Beeping = False
        Me.sbMusic.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbMusic.ButtonText = "MY MUSIC"
        Me.sbMusic.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbMusic.ButtonTextHeight = 14
        Me.sbMusic.Clickable = True
        Me.sbMusic.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbMusic.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbMusic.Data = Nothing
        Me.sbMusic.Data2 = Nothing
        Me.sbMusic.FlashInterval = 500
        Me.sbMusic.holdDraw = False
        Me.sbMusic.Lit = True
        Me.sbMusic.Location = New System.Drawing.Point(14, 157)
        Me.sbMusic.Name = "sbMusic"
        Me.sbMusic.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMusic.Size = New System.Drawing.Size(87, 26)
        Me.sbMusic.TabIndex = 52
        Me.sbMusic.Text = "MY MUSIC"
        '
        'sbPictures
        '
        Me.sbPictures.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbPictures.Beeping = False
        Me.sbPictures.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbPictures.ButtonText = "MY PICTURES"
        Me.sbPictures.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbPictures.ButtonTextHeight = 14
        Me.sbPictures.Clickable = True
        Me.sbPictures.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbPictures.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbPictures.Data = Nothing
        Me.sbPictures.Data2 = Nothing
        Me.sbPictures.FlashInterval = 500
        Me.sbPictures.holdDraw = False
        Me.sbPictures.Lit = True
        Me.sbPictures.Location = New System.Drawing.Point(14, 125)
        Me.sbPictures.Name = "sbPictures"
        Me.sbPictures.RedAlert = LCARS.LCARSalert.Normal
        Me.sbPictures.Size = New System.Drawing.Size(87, 26)
        Me.sbPictures.TabIndex = 52
        Me.sbPictures.Text = "MY PICTURES"
        '
        'sbDocuments
        '
        Me.sbDocuments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbDocuments.Beeping = False
        Me.sbDocuments.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbDocuments.ButtonText = "MY DOCUMENTS"
        Me.sbDocuments.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbDocuments.ButtonTextHeight = 14
        Me.sbDocuments.Clickable = True
        Me.sbDocuments.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbDocuments.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDocuments.Data = Nothing
        Me.sbDocuments.Data2 = Nothing
        Me.sbDocuments.FlashInterval = 500
        Me.sbDocuments.holdDraw = False
        Me.sbDocuments.Lit = True
        Me.sbDocuments.Location = New System.Drawing.Point(14, 93)
        Me.sbDocuments.Name = "sbDocuments"
        Me.sbDocuments.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDocuments.Size = New System.Drawing.Size(87, 26)
        Me.sbDocuments.TabIndex = 52
        Me.sbDocuments.Text = "MY DOCUMENTS"
        '
        'sbDesktop
        '
        Me.sbDesktop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbDesktop.Beeping = False
        Me.sbDesktop.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbDesktop.ButtonText = "DESKTOP"
        Me.sbDesktop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbDesktop.ButtonTextHeight = 14
        Me.sbDesktop.Clickable = True
        Me.sbDesktop.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbDesktop.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbDesktop.Data = Nothing
        Me.sbDesktop.Data2 = Nothing
        Me.sbDesktop.FlashInterval = 500
        Me.sbDesktop.holdDraw = False
        Me.sbDesktop.Lit = True
        Me.sbDesktop.Location = New System.Drawing.Point(14, 61)
        Me.sbDesktop.Name = "sbDesktop"
        Me.sbDesktop.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDesktop.Size = New System.Drawing.Size(87, 26)
        Me.sbDesktop.TabIndex = 52
        Me.sbDesktop.Text = "DESKTOP"
        '
        'sbMyComp
        '
        Me.sbMyComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbMyComp.Beeping = False
        Me.sbMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbMyComp.ButtonText = "MY COMPUTER"
        Me.sbMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbMyComp.ButtonTextHeight = 14
        Me.sbMyComp.Clickable = True
        Me.sbMyComp.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbMyComp.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbMyComp.Data = Nothing
        Me.sbMyComp.Data2 = Nothing
        Me.sbMyComp.FlashInterval = 500
        Me.sbMyComp.holdDraw = False
        Me.sbMyComp.Lit = True
        Me.sbMyComp.Location = New System.Drawing.Point(14, 29)
        Me.sbMyComp.Name = "sbMyComp"
        Me.sbMyComp.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMyComp.Size = New System.Drawing.Size(87, 26)
        Me.sbMyComp.TabIndex = 52
        Me.sbMyComp.Text = "MY COMPUTER"
        '
        'elbShortcutsBottom
        '
        Me.elbShortcutsBottom.Beeping = False
        Me.elbShortcutsBottom.ButtonHeight = 20
        Me.elbShortcutsBottom.ButtonText = ""
        Me.elbShortcutsBottom.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.elbShortcutsBottom.ButtonTextHeight = 14
        Me.elbShortcutsBottom.ButtonWidth = 5
        Me.elbShortcutsBottom.Clickable = False
        Me.elbShortcutsBottom.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.elbShortcutsBottom.CustomAlertColor = System.Drawing.Color.Empty
        Me.elbShortcutsBottom.Data = Nothing
        Me.elbShortcutsBottom.Data2 = Nothing
        Me.elbShortcutsBottom.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbShortcutsBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbShortcutsBottom.FlashInterval = 500
        Me.elbShortcutsBottom.holdDraw = False
        Me.elbShortcutsBottom.Lit = True
        Me.elbShortcutsBottom.Location = New System.Drawing.Point(3, 289)
        Me.elbShortcutsBottom.Name = "elbShortcutsBottom"
        Me.elbShortcutsBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.elbShortcutsBottom.Size = New System.Drawing.Size(197, 34)
        Me.elbShortcutsBottom.TabIndex = 53
        '
        'elbShortcutsTop
        '
        Me.elbShortcutsTop.Beeping = False
        Me.elbShortcutsTop.ButtonHeight = 20
        Me.elbShortcutsTop.ButtonText = "SYSTEM SHORTCUTS"
        Me.elbShortcutsTop.ButtonTextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.elbShortcutsTop.ButtonTextHeight = 14
        Me.elbShortcutsTop.ButtonWidth = 5
        Me.elbShortcutsTop.Clickable = False
        Me.elbShortcutsTop.Color = LCARS.LCARScolorStyles.StaticBlue
        Me.elbShortcutsTop.CustomAlertColor = System.Drawing.Color.Empty
        Me.elbShortcutsTop.Data = Nothing
        Me.elbShortcutsTop.Data2 = Nothing
        Me.elbShortcutsTop.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbShortcutsTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbShortcutsTop.FlashInterval = 500
        Me.elbShortcutsTop.holdDraw = False
        Me.elbShortcutsTop.Lit = True
        Me.elbShortcutsTop.Location = New System.Drawing.Point(3, 3)
        Me.elbShortcutsTop.Name = "elbShortcutsTop"
        Me.elbShortcutsTop.RedAlert = LCARS.LCARSalert.Normal
        Me.elbShortcutsTop.Size = New System.Drawing.Size(197, 34)
        Me.elbShortcutsTop.TabIndex = 53
        Me.elbShortcutsTop.Text = "SYSTEM SHORTCUTS"
        '
        'sbClose
        '
        Me.sbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbClose.Beeping = False
        Me.sbClose.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbClose.ButtonText = "X"
        Me.sbClose.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbClose.ButtonTextHeight = 20
        Me.sbClose.Clickable = True
        Me.sbClose.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbClose.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbClose.Data = Nothing
        Me.sbClose.Data2 = Nothing
        Me.sbClose.FlashInterval = 500
        Me.sbClose.holdDraw = False
        Me.sbClose.Lit = True
        Me.sbClose.Location = New System.Drawing.Point(607, 4)
        Me.sbClose.Name = "sbClose"
        Me.sbClose.RedAlert = LCARS.LCARSalert.Normal
        Me.sbClose.Size = New System.Drawing.Size(29, 29)
        Me.sbClose.TabIndex = 54
        Me.sbClose.Text = "X"
        '
        'sbGoTo
        '
        Me.sbGoTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbGoTo.Beeping = False
        Me.sbGoTo.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbGoTo.ButtonText = "GO TO"
        Me.sbGoTo.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbGoTo.ButtonTextHeight = 14
        Me.sbGoTo.Clickable = True
        Me.sbGoTo.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbGoTo.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbGoTo.Data = Nothing
        Me.sbGoTo.Data2 = Nothing
        Me.sbGoTo.FlashInterval = 500
        Me.sbGoTo.holdDraw = False
        Me.sbGoTo.Lit = True
        Me.sbGoTo.Location = New System.Drawing.Point(533, 177)
        Me.sbGoTo.Name = "sbGoTo"
        Me.sbGoTo.RedAlert = LCARS.LCARSalert.Normal
        Me.sbGoTo.Size = New System.Drawing.Size(87, 26)
        Me.sbGoTo.TabIndex = 42
        Me.sbGoTo.Text = "GO TO"
        '
        'sbOptions
        '
        Me.sbOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOptions.Beeping = False
        Me.sbOptions.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbOptions.ButtonText = "OPTIONS"
        Me.sbOptions.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbOptions.ButtonTextHeight = 14
        Me.sbOptions.Clickable = True
        Me.sbOptions.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbOptions.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOptions.Data = Nothing
        Me.sbOptions.Data2 = Nothing
        Me.sbOptions.FlashInterval = 500
        Me.sbOptions.holdDraw = False
        Me.sbOptions.Lit = True
        Me.sbOptions.Location = New System.Drawing.Point(533, 145)
        Me.sbOptions.Name = "sbOptions"
        Me.sbOptions.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOptions.Size = New System.Drawing.Size(87, 26)
        Me.sbOptions.TabIndex = 42
        Me.sbOptions.Text = "OPTIONS"
        '
        'tbTitle
        '
        Me.tbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTitle.Beeping = True
        Me.tbTitle.ButtonText = "MY COMPUTER"
        Me.tbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tbTitle.ButtonTextHeight = 32
        Me.tbTitle.ButtonType = LCARS.Controls.TextButton.TextButtonType.DoublePills
        Me.tbTitle.Clickable = False
        Me.tbTitle.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.tbTitle.CustomAlertColor = System.Drawing.Color.Empty
        Me.tbTitle.Data = Nothing
        Me.tbTitle.Data2 = Nothing
        Me.tbTitle.FlashInterval = 500
        Me.tbTitle.holdDraw = False
        Me.tbTitle.Lit = True
        Me.tbTitle.Location = New System.Drawing.Point(6, 4)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.tbTitle.Size = New System.Drawing.Size(595, 32)
        Me.tbTitle.TabIndex = 92
        Me.tbTitle.Text = "MY COMPUTER"
        '
        'sbUpDir
        '
        Me.sbUpDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUpDir.Beeping = False
        Me.sbUpDir.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbUpDir.ButtonText = "UP A DIRECTORY"
        Me.sbUpDir.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbUpDir.ButtonTextHeight = 14
        Me.sbUpDir.Clickable = True
        Me.sbUpDir.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbUpDir.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbUpDir.Data = Nothing
        Me.sbUpDir.Data2 = Nothing
        Me.sbUpDir.FlashInterval = 500
        Me.sbUpDir.holdDraw = False
        Me.sbUpDir.Lit = False
        Me.sbUpDir.Location = New System.Drawing.Point(533, 113)
        Me.sbUpDir.Name = "sbUpDir"
        Me.sbUpDir.RedAlert = LCARS.LCARSalert.Normal
        Me.sbUpDir.Size = New System.Drawing.Size(87, 26)
        Me.sbUpDir.TabIndex = 57
        Me.sbUpDir.Text = "UP A DIRECTORY"
        '
        'fbActionsBorderRight
        '
        Me.fbActionsBorderRight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbActionsBorderRight.Beeping = False
        Me.fbActionsBorderRight.ButtonText = ""
        Me.fbActionsBorderRight.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbActionsBorderRight.ButtonTextHeight = 14
        Me.fbActionsBorderRight.Clickable = False
        Me.fbActionsBorderRight.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.fbActionsBorderRight.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbActionsBorderRight.Data = Nothing
        Me.fbActionsBorderRight.Data2 = Nothing
        Me.fbActionsBorderRight.FlashInterval = 500
        Me.fbActionsBorderRight.holdDraw = False
        Me.fbActionsBorderRight.Lit = True
        Me.fbActionsBorderRight.Location = New System.Drawing.Point(626, 49)
        Me.fbActionsBorderRight.Name = "fbActionsBorderRight"
        Me.fbActionsBorderRight.RedAlert = LCARS.LCARSalert.Normal
        Me.fbActionsBorderRight.Size = New System.Drawing.Size(10, 508)
        Me.fbActionsBorderRight.TabIndex = 29
        '
        'fbActionsBorderLeft
        '
        Me.fbActionsBorderLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbActionsBorderLeft.Beeping = False
        Me.fbActionsBorderLeft.ButtonText = ""
        Me.fbActionsBorderLeft.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.fbActionsBorderLeft.ButtonTextHeight = 14
        Me.fbActionsBorderLeft.Clickable = False
        Me.fbActionsBorderLeft.Color = LCARS.LCARScolorStyles.StaticTan
        Me.fbActionsBorderLeft.CustomAlertColor = System.Drawing.Color.Empty
        Me.fbActionsBorderLeft.Data = Nothing
        Me.fbActionsBorderLeft.Data2 = Nothing
        Me.fbActionsBorderLeft.FlashInterval = 500
        Me.fbActionsBorderLeft.holdDraw = False
        Me.fbActionsBorderLeft.Lit = True
        Me.fbActionsBorderLeft.Location = New System.Drawing.Point(522, 93)
        Me.fbActionsBorderLeft.Name = "fbActionsBorderLeft"
        Me.fbActionsBorderLeft.RedAlert = LCARS.LCARSalert.Normal
        Me.fbActionsBorderLeft.Size = New System.Drawing.Size(5, 419)
        Me.fbActionsBorderLeft.TabIndex = 51
        '
        'sbRefresh
        '
        Me.sbRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbRefresh.Beeping = False
        Me.sbRefresh.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbRefresh.ButtonText = "REFRESH"
        Me.sbRefresh.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbRefresh.ButtonTextHeight = 14
        Me.sbRefresh.Clickable = True
        Me.sbRefresh.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbRefresh.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbRefresh.Data = Nothing
        Me.sbRefresh.Data2 = Nothing
        Me.sbRefresh.FlashInterval = 500
        Me.sbRefresh.holdDraw = False
        Me.sbRefresh.Lit = True
        Me.sbRefresh.Location = New System.Drawing.Point(533, 209)
        Me.sbRefresh.Name = "sbRefresh"
        Me.sbRefresh.RedAlert = LCARS.LCARSalert.Normal
        Me.sbRefresh.Size = New System.Drawing.Size(87, 26)
        Me.sbRefresh.TabIndex = 47
        Me.sbRefresh.Text = "REFRESH"
        '
        'sbProperties
        '
        Me.sbProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbProperties.Beeping = False
        Me.sbProperties.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbProperties.ButtonText = "PROPERTIES"
        Me.sbProperties.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbProperties.ButtonTextHeight = 14
        Me.sbProperties.Clickable = True
        Me.sbProperties.Color = LCARS.LCARScolorStyles.MiscFunction
        Me.sbProperties.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbProperties.Data = Nothing
        Me.sbProperties.Data2 = Nothing
        Me.sbProperties.FlashInterval = 500
        Me.sbProperties.holdDraw = False
        Me.sbProperties.Lit = True
        Me.sbProperties.Location = New System.Drawing.Point(533, 81)
        Me.sbProperties.Name = "sbProperties"
        Me.sbProperties.RedAlert = LCARS.LCARSalert.Normal
        Me.sbProperties.Size = New System.Drawing.Size(87, 26)
        Me.sbProperties.TabIndex = 47
        Me.sbProperties.Text = "PROPERTIES"
        '
        'elbActionsTop
        '
        Me.elbActionsTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbActionsTop.Beeping = False
        Me.elbActionsTop.ButtonHeight = 25
        Me.elbActionsTop.ButtonText = "ACTIONS"
        Me.elbActionsTop.ButtonTextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.elbActionsTop.ButtonTextHeight = 14
        Me.elbActionsTop.ButtonWidth = 5
        Me.elbActionsTop.Clickable = False
        Me.elbActionsTop.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.elbActionsTop.CustomAlertColor = System.Drawing.Color.Empty
        Me.elbActionsTop.Data = Nothing
        Me.elbActionsTop.Data2 = Nothing
        Me.elbActionsTop.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbActionsTop.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.UpperLeft
        Me.elbActionsTop.FlashInterval = 500
        Me.elbActionsTop.holdDraw = False
        Me.elbActionsTop.Lit = True
        Me.elbActionsTop.Location = New System.Drawing.Point(522, 49)
        Me.elbActionsTop.Name = "elbActionsTop"
        Me.elbActionsTop.RedAlert = LCARS.LCARSalert.Normal
        Me.elbActionsTop.Size = New System.Drawing.Size(113, 38)
        Me.elbActionsTop.TabIndex = 49
        Me.elbActionsTop.Text = "ACTIONS"
        '
        'elbActionsBottom
        '
        Me.elbActionsBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elbActionsBottom.Beeping = False
        Me.elbActionsBottom.ButtonHeight = 25
        Me.elbActionsBottom.ButtonText = ""
        Me.elbActionsBottom.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.elbActionsBottom.ButtonTextHeight = 14
        Me.elbActionsBottom.ButtonWidth = 5
        Me.elbActionsBottom.Clickable = False
        Me.elbActionsBottom.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.elbActionsBottom.CustomAlertColor = System.Drawing.Color.Empty
        Me.elbActionsBottom.Data = Nothing
        Me.elbActionsBottom.Data2 = Nothing
        Me.elbActionsBottom.ElbowRatio = New System.Drawing.Point(1, 1)
        Me.elbActionsBottom.ElbowStyle = LCARS.Controls.Elbow.LCARSelbowStyles.LowerLeft
        Me.elbActionsBottom.FlashInterval = 500
        Me.elbActionsBottom.holdDraw = False
        Me.elbActionsBottom.Lit = True
        Me.elbActionsBottom.Location = New System.Drawing.Point(522, 518)
        Me.elbActionsBottom.Name = "elbActionsBottom"
        Me.elbActionsBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.elbActionsBottom.Size = New System.Drawing.Size(113, 39)
        Me.elbActionsBottom.TabIndex = 50
        '
        'gridMyComp
        '
        Me.gridMyComp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridMyComp.Beeping = False
        Me.gridMyComp.ColorsAvailable = LcarScolor1
        Me.gridMyComp.ControlAddingDirection = LCARS.Controls.ButtonGrid.ControlDirection.Vertical
        Me.gridMyComp.ControlPadding = 5
        Me.gridMyComp.ControlSize = New System.Drawing.Size(150, 30)
        Me.gridMyComp.CurrentPage = 1
        Me.gridMyComp.Location = New System.Drawing.Point(9, 50)
        Me.gridMyComp.MinimumSize = New System.Drawing.Size(155, 35)
        Me.gridMyComp.Name = "gridMyComp"
        Me.gridMyComp.Size = New System.Drawing.Size(508, 503)
        Me.gridMyComp.TabIndex = 97
        Me.gridMyComp.Text = "ButtonGrid1"
        '
        'frmMyComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 562)
        Me.Controls.Add(Me.gridMyComp)
        Me.Controls.Add(Me.pnlSystemDefined)
        Me.Controls.Add(Me.pnlEdit)
        Me.Controls.Add(Me.sbClose)
        Me.Controls.Add(Me.sbGoTo)
        Me.Controls.Add(Me.sbOptions)
        Me.Controls.Add(Me.tbTitle)
        Me.Controls.Add(Me.sbUpDir)
        Me.Controls.Add(Me.fbActionsBorderRight)
        Me.Controls.Add(Me.fbActionsBorderLeft)
        Me.Controls.Add(Me.sbRefresh)
        Me.Controls.Add(Me.sbProperties)
        Me.Controls.Add(Me.elbActionsTop)
        Me.Controls.Add(Me.elbActionsBottom)
        Me.Controls.Add(Me.pnlOptionalComponents)
        Me.Controls.Add(Me.pnlVisible)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmMyComp"
        Me.Text = "My Computer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEdit.ResumeLayout(False)
        Me.pnlOptionalComponents.ResumeLayout(False)
        Me.pnlSystemDefined.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbOptions As LCARS.Controls.StandardButton
    Friend WithEvents sbProperties As LCARS.Controls.StandardButton
    Friend WithEvents pnlVisible As System.Windows.Forms.Panel
    Friend WithEvents tmrMouseSelect As System.Windows.Forms.Timer
    Friend WithEvents sbUpDir As LCARS.Controls.StandardButton
    Friend WithEvents sbClose As LCARS.Controls.StandardButton
    Friend WithEvents sbRename As LCARS.Controls.StandardButton
    Friend WithEvents sbCopy As LCARS.Controls.StandardButton
    Friend WithEvents sbPaste As LCARS.Controls.StandardButton
    Friend WithEvents sbCut As LCARS.Controls.StandardButton
    Friend WithEvents sbDelete As LCARS.Controls.StandardButton
    Friend WithEvents fbActionsBorderRight As LCARS.Controls.FlatButton
    Friend WithEvents elbActionsTop As LCARS.Controls.Elbow
    Friend WithEvents fbActionsBorderLeft As LCARS.Controls.FlatButton
    Friend WithEvents elbActionsBottom As LCARS.Controls.Elbow
    Friend WithEvents tbTitle As LCARS.Controls.TextButton
    Friend WithEvents pnlEdit As System.Windows.Forms.Panel
    Friend WithEvents sbNewFolder As LCARS.Controls.StandardButton
    Friend WithEvents sbOpenWith As LCARS.Controls.StandardButton
    Friend WithEvents sbFormat As LCARS.Controls.StandardButton
    Friend WithEvents sbEdit As LCARS.Controls.StandardButton
    Friend WithEvents pnlOptionalComponents As System.Windows.Forms.Panel
    Friend WithEvents sbGoTo As LCARS.Controls.StandardButton
    Friend WithEvents pnlShortcuts As System.Windows.Forms.Panel
    Friend WithEvents sbRefresh As LCARS.Controls.StandardButton
    Friend WithEvents pnlSystemDefined As System.Windows.Forms.Panel
    Friend WithEvents sbMyComp As LCARS.Controls.StandardButton
    Friend WithEvents sbDocuments As LCARS.Controls.StandardButton
    Friend WithEvents sbDesktop As LCARS.Controls.StandardButton
    Friend WithEvents sbVideos As LCARS.Controls.StandardButton
    Friend WithEvents sbMusic As LCARS.Controls.StandardButton
    Friend WithEvents sbPictures As LCARS.Controls.StandardButton
    Friend WithEvents elbShortcutsTop As LCARS.Controls.Elbow
    Friend WithEvents fbShortcutsBorder As LCARS.Controls.FlatButton
    Friend WithEvents elbShortcutsBottom As LCARS.Controls.Elbow
    Friend WithEvents sbEnterPath As LCARS.Controls.StandardButton
    Friend WithEvents sbSaveCurrent As LCARS.Controls.StandardButton
    Friend WithEvents gridMyComp As LCARS.Controls.ButtonGrid

End Class
