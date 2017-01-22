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
        Dim LcarScolor2 As LCARS.LCARScolor = New LCARS.LCARScolor
        Me.pnlProperties = New System.Windows.Forms.Panel
        Me.pnlMultiple = New System.Windows.Forms.Panel
        Me.lblMultipleOut = New System.Windows.Forms.Label
        Me.pnlFolder = New System.Windows.Forms.Panel
        Me.lblFolderSizeValue = New System.Windows.Forms.Label
        Me.lblFolderSize = New System.Windows.Forms.Label
        Me.lblContainsValue = New System.Windows.Forms.Label
        Me.lblFolderCreatedValue = New System.Windows.Forms.Label
        Me.lblFolderPathValue = New System.Windows.Forms.Label
        Me.lblContains = New System.Windows.Forms.Label
        Me.lblFolderCreated = New System.Windows.Forms.Label
        Me.lblFolderPath = New System.Windows.Forms.Label
        Me.pnlDrive = New System.Windows.Forms.Panel
        Me.liDrive = New LCARS.Controls.LevelIndicator
        Me.lblUsed = New System.Windows.Forms.Label
        Me.lblFreeLabel = New System.Windows.Forms.Label
        Me.lblFree = New System.Windows.Forms.Label
        Me.lblFreeSpace = New System.Windows.Forms.Label
        Me.lblFileSystemLabel = New System.Windows.Forms.Label
        Me.lblFS = New System.Windows.Forms.Label
        Me.lblCapacity = New System.Windows.Forms.Label
        Me.lblUsedLabel = New System.Windows.Forms.Label
        Me.lblCapacityLabel = New System.Windows.Forms.Label
        Me.lblDrive = New System.Windows.Forms.Label
        Me.pnlFile = New System.Windows.Forms.Panel
        Me.lblSizeValue = New System.Windows.Forms.Label
        Me.lblSize = New System.Windows.Forms.Label
        Me.sbChangeProgram = New LCARS.Controls.StandardButton
        Me.lblCreatedValue = New System.Windows.Forms.Label
        Me.lblModified = New System.Windows.Forms.Label
        Me.lblModifiedValue = New System.Windows.Forms.Label
        Me.lblOpensWith = New System.Windows.Forms.Label
        Me.lblAccessed = New System.Windows.Forms.Label
        Me.lblOpensWithValue = New System.Windows.Forms.Label
        Me.lblAccessedValue = New System.Windows.Forms.Label
        Me.lblPathValue = New System.Windows.Forms.Label
        Me.lblCreated = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblPropTitle = New System.Windows.Forms.Label
        Me.sbCloseProperties = New LCARS.Controls.StandardButton
        Me.pnlVisible = New System.Windows.Forms.Panel
        Me.tmrMouseSelect = New System.Windows.Forms.Timer(Me.components)
        Me.pnlRename = New System.Windows.Forms.Panel
        Me.sbOK = New LCARS.Controls.StandardButton
        Me.txtNew = New System.Windows.Forms.TextBox
        Me.lblFileName = New System.Windows.Forms.Label
        Me.lblRename = New System.Windows.Forms.Label
        Me.sbCancel = New LCARS.Controls.StandardButton
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
        Me.lblDriveTypeLabel = New LCARS.Controls.LCARSLabel
        Me.lblDriveType = New LCARS.Controls.LCARSLabel
        Me.pnlProperties.SuspendLayout()
        Me.pnlMultiple.SuspendLayout()
        Me.pnlFolder.SuspendLayout()
        Me.pnlDrive.SuspendLayout()
        Me.pnlFile.SuspendLayout()
        Me.pnlRename.SuspendLayout()
        Me.pnlEdit.SuspendLayout()
        Me.pnlOptionalComponents.SuspendLayout()
        Me.pnlSystemDefined.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlProperties
        '
        Me.pnlProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlProperties.Controls.Add(Me.pnlDrive)
        Me.pnlProperties.Controls.Add(Me.pnlMultiple)
        Me.pnlProperties.Controls.Add(Me.pnlFolder)
        Me.pnlProperties.Controls.Add(Me.pnlFile)
        Me.pnlProperties.Controls.Add(Me.lblPropTitle)
        Me.pnlProperties.Controls.Add(Me.sbCloseProperties)
        Me.pnlProperties.Location = New System.Drawing.Point(6, 41)
        Me.pnlProperties.Name = "pnlProperties"
        Me.pnlProperties.Size = New System.Drawing.Size(497, 503)
        Me.pnlProperties.TabIndex = 48
        Me.pnlProperties.Visible = False
        '
        'pnlMultiple
        '
        Me.pnlMultiple.Controls.Add(Me.lblMultipleOut)
        Me.pnlMultiple.Location = New System.Drawing.Point(17, 62)
        Me.pnlMultiple.Name = "pnlMultiple"
        Me.pnlMultiple.Size = New System.Drawing.Size(470, 407)
        Me.pnlMultiple.TabIndex = 93
        Me.pnlMultiple.Visible = False
        '
        'lblMultipleOut
        '
        Me.lblMultipleOut.AutoSize = True
        Me.lblMultipleOut.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMultipleOut.ForeColor = System.Drawing.Color.Orange
        Me.lblMultipleOut.Location = New System.Drawing.Point(13, 31)
        Me.lblMultipleOut.Name = "lblMultipleOut"
        Me.lblMultipleOut.Size = New System.Drawing.Size(35, 21)
        Me.lblMultipleOut.TabIndex = 75
        Me.lblMultipleOut.Text = "Path: "
        '
        'pnlFolder
        '
        Me.pnlFolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFolder.Controls.Add(Me.lblFolderSizeValue)
        Me.pnlFolder.Controls.Add(Me.lblFolderSize)
        Me.pnlFolder.Controls.Add(Me.lblContainsValue)
        Me.pnlFolder.Controls.Add(Me.lblFolderCreatedValue)
        Me.pnlFolder.Controls.Add(Me.lblFolderPathValue)
        Me.pnlFolder.Controls.Add(Me.lblContains)
        Me.pnlFolder.Controls.Add(Me.lblFolderCreated)
        Me.pnlFolder.Controls.Add(Me.lblFolderPath)
        Me.pnlFolder.Location = New System.Drawing.Point(17, 64)
        Me.pnlFolder.Name = "pnlFolder"
        Me.pnlFolder.Size = New System.Drawing.Size(470, 407)
        Me.pnlFolder.TabIndex = 93
        Me.pnlFolder.Visible = False
        '
        'lblFolderSizeValue
        '
        Me.lblFolderSizeValue.AutoSize = True
        Me.lblFolderSizeValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderSizeValue.ForeColor = System.Drawing.Color.Orange
        Me.lblFolderSizeValue.Location = New System.Drawing.Point(72, 63)
        Me.lblFolderSizeValue.Name = "lblFolderSizeValue"
        Me.lblFolderSizeValue.Size = New System.Drawing.Size(25, 21)
        Me.lblFolderSizeValue.TabIndex = 91
        Me.lblFolderSizeValue.Text = "xkb"
        '
        'lblFolderSize
        '
        Me.lblFolderSize.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderSize.ForeColor = System.Drawing.Color.Orange
        Me.lblFolderSize.Location = New System.Drawing.Point(6, 63)
        Me.lblFolderSize.Name = "lblFolderSize"
        Me.lblFolderSize.Size = New System.Drawing.Size(64, 26)
        Me.lblFolderSize.TabIndex = 92
        Me.lblFolderSize.Text = "Size"
        '
        'lblContainsValue
        '
        Me.lblContainsValue.AutoSize = True
        Me.lblContainsValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContainsValue.ForeColor = System.Drawing.Color.Orange
        Me.lblContainsValue.Location = New System.Drawing.Point(71, 115)
        Me.lblContainsValue.Name = "lblContainsValue"
        Me.lblContainsValue.Size = New System.Drawing.Size(71, 21)
        Me.lblContainsValue.TabIndex = 52
        Me.lblContainsValue.Text = "X files, X dirs"
        '
        'lblFolderCreatedValue
        '
        Me.lblFolderCreatedValue.AutoSize = True
        Me.lblFolderCreatedValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderCreatedValue.ForeColor = System.Drawing.Color.Orange
        Me.lblFolderCreatedValue.Location = New System.Drawing.Point(71, 89)
        Me.lblFolderCreatedValue.Name = "lblFolderCreatedValue"
        Me.lblFolderCreatedValue.Size = New System.Drawing.Size(35, 21)
        Me.lblFolderCreatedValue.TabIndex = 52
        Me.lblFolderCreatedValue.Text = "x/x/x"
        '
        'lblFolderPathValue
        '
        Me.lblFolderPathValue.AutoEllipsis = True
        Me.lblFolderPathValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderPathValue.ForeColor = System.Drawing.Color.Orange
        Me.lblFolderPathValue.Location = New System.Drawing.Point(75, 33)
        Me.lblFolderPathValue.Name = "lblFolderPathValue"
        Me.lblFolderPathValue.Size = New System.Drawing.Size(378, 26)
        Me.lblFolderPathValue.TabIndex = 76
        Me.lblFolderPathValue.Text = "C:\"
        '
        'lblContains
        '
        Me.lblContains.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContains.ForeColor = System.Drawing.Color.Orange
        Me.lblContains.Location = New System.Drawing.Point(5, 115)
        Me.lblContains.Name = "lblContains"
        Me.lblContains.Size = New System.Drawing.Size(64, 26)
        Me.lblContains.TabIndex = 74
        Me.lblContains.Text = "Contains:"
        '
        'lblFolderCreated
        '
        Me.lblFolderCreated.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderCreated.ForeColor = System.Drawing.Color.Orange
        Me.lblFolderCreated.Location = New System.Drawing.Point(5, 89)
        Me.lblFolderCreated.Name = "lblFolderCreated"
        Me.lblFolderCreated.Size = New System.Drawing.Size(64, 26)
        Me.lblFolderCreated.TabIndex = 74
        Me.lblFolderCreated.Text = "Created:"
        '
        'lblFolderPath
        '
        Me.lblFolderPath.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderPath.ForeColor = System.Drawing.Color.Orange
        Me.lblFolderPath.Location = New System.Drawing.Point(6, 34)
        Me.lblFolderPath.Name = "lblFolderPath"
        Me.lblFolderPath.Size = New System.Drawing.Size(60, 29)
        Me.lblFolderPath.TabIndex = 75
        Me.lblFolderPath.Text = "Path: "
        '
        'pnlDrive
        '
        Me.pnlDrive.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDrive.Controls.Add(Me.lblDriveType)
        Me.pnlDrive.Controls.Add(Me.lblDriveTypeLabel)
        Me.pnlDrive.Controls.Add(Me.liDrive)
        Me.pnlDrive.Controls.Add(Me.lblUsed)
        Me.pnlDrive.Controls.Add(Me.lblFreeLabel)
        Me.pnlDrive.Controls.Add(Me.lblFree)
        Me.pnlDrive.Controls.Add(Me.lblFreeSpace)
        Me.pnlDrive.Controls.Add(Me.lblFileSystemLabel)
        Me.pnlDrive.Controls.Add(Me.lblFS)
        Me.pnlDrive.Controls.Add(Me.lblCapacity)
        Me.pnlDrive.Controls.Add(Me.lblUsedLabel)
        Me.pnlDrive.Controls.Add(Me.lblCapacityLabel)
        Me.pnlDrive.Controls.Add(Me.lblDrive)
        Me.pnlDrive.Location = New System.Drawing.Point(17, 64)
        Me.pnlDrive.Name = "pnlDrive"
        Me.pnlDrive.Size = New System.Drawing.Size(470, 407)
        Me.pnlDrive.TabIndex = 51
        Me.pnlDrive.Visible = False
        '
        'liDrive
        '
        Me.liDrive.Beeping = False
        Me.liDrive.ButtonText = "50%"
        Me.liDrive.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.liDrive.ButtonTextHeight = 14
        Me.liDrive.Clickable = False
        Me.liDrive.Color = LCARS.LCARScolorStyles.Orange
        Me.liDrive.Color2 = LCARS.LCARScolorStyles.FunctionUnavailable
        Me.liDrive.CustomAlertColor = System.Drawing.Color.Empty
        Me.liDrive.Data = Nothing
        Me.liDrive.Data2 = Nothing
        Me.liDrive.FlashInterval = 500
        Me.liDrive.holdDraw = False
        Me.liDrive.Lit = True
        Me.liDrive.Location = New System.Drawing.Point(148, 31)
        Me.liDrive.Name = "liDrive"
        Me.liDrive.RedAlert = LCARS.LCARSalert.Normal
        Me.liDrive.Size = New System.Drawing.Size(147, 164)
        Me.liDrive.TabIndex = 91
        Me.liDrive.Text = "50%"
        Me.liDrive.Value = 50
        '
        'lblUsed
        '
        Me.lblUsed.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsed.ForeColor = System.Drawing.Color.Orange
        Me.lblUsed.Location = New System.Drawing.Point(75, 63)
        Me.lblUsed.Name = "lblUsed"
        Me.lblUsed.Size = New System.Drawing.Size(62, 26)
        Me.lblUsed.TabIndex = 52
        Me.lblUsed.Text = "200GB"
        '
        'lblFreeLabel
        '
        Me.lblFreeLabel.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreeLabel.ForeColor = System.Drawing.Color.Orange
        Me.lblFreeLabel.Location = New System.Drawing.Point(9, 96)
        Me.lblFreeLabel.Name = "lblFreeLabel"
        Me.lblFreeLabel.Size = New System.Drawing.Size(64, 26)
        Me.lblFreeLabel.TabIndex = 90
        Me.lblFreeLabel.Text = "Free Space: "
        '
        'lblFree
        '
        Me.lblFree.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFree.ForeColor = System.Drawing.Color.Orange
        Me.lblFree.Location = New System.Drawing.Point(75, 96)
        Me.lblFree.Name = "lblFree"
        Me.lblFree.Size = New System.Drawing.Size(62, 26)
        Me.lblFree.TabIndex = 89
        Me.lblFree.Text = "200GB"
        '
        'lblFreeSpace
        '
        Me.lblFreeSpace.AutoSize = True
        Me.lblFreeSpace.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreeSpace.ForeColor = System.Drawing.Color.Orange
        Me.lblFreeSpace.Location = New System.Drawing.Point(206, 198)
        Me.lblFreeSpace.Name = "lblFreeSpace"
        Me.lblFreeSpace.Size = New System.Drawing.Size(30, 21)
        Me.lblFreeSpace.TabIndex = 88
        Me.lblFreeSpace.Text = "Free"
        '
        'lblFileSystemLabel
        '
        Me.lblFileSystemLabel.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileSystemLabel.ForeColor = System.Drawing.Color.Orange
        Me.lblFileSystemLabel.Location = New System.Drawing.Point(9, 129)
        Me.lblFileSystemLabel.Name = "lblFileSystemLabel"
        Me.lblFileSystemLabel.Size = New System.Drawing.Size(64, 26)
        Me.lblFileSystemLabel.TabIndex = 88
        Me.lblFileSystemLabel.Text = "File System:"
        '
        'lblFS
        '
        Me.lblFS.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFS.ForeColor = System.Drawing.Color.Orange
        Me.lblFS.Location = New System.Drawing.Point(75, 129)
        Me.lblFS.Name = "lblFS"
        Me.lblFS.Size = New System.Drawing.Size(62, 26)
        Me.lblFS.TabIndex = 87
        Me.lblFS.Text = "NTFS"
        '
        'lblCapacity
        '
        Me.lblCapacity.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity.ForeColor = System.Drawing.Color.Orange
        Me.lblCapacity.Location = New System.Drawing.Point(75, 33)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(62, 26)
        Me.lblCapacity.TabIndex = 76
        Me.lblCapacity.Text = "200GB"
        '
        'lblUsedLabel
        '
        Me.lblUsedLabel.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsedLabel.ForeColor = System.Drawing.Color.Orange
        Me.lblUsedLabel.Location = New System.Drawing.Point(9, 63)
        Me.lblUsedLabel.Name = "lblUsedLabel"
        Me.lblUsedLabel.Size = New System.Drawing.Size(64, 26)
        Me.lblUsedLabel.TabIndex = 74
        Me.lblUsedLabel.Text = "Used Space: "
        '
        'lblCapacityLabel
        '
        Me.lblCapacityLabel.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacityLabel.ForeColor = System.Drawing.Color.Orange
        Me.lblCapacityLabel.Location = New System.Drawing.Point(9, 34)
        Me.lblCapacityLabel.Name = "lblCapacityLabel"
        Me.lblCapacityLabel.Size = New System.Drawing.Size(60, 29)
        Me.lblCapacityLabel.TabIndex = 75
        Me.lblCapacityLabel.Text = "Capacity: "
        '
        'lblDrive
        '
        Me.lblDrive.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDrive.ForeColor = System.Drawing.Color.Orange
        Me.lblDrive.Location = New System.Drawing.Point(143, 1)
        Me.lblDrive.Name = "lblDrive"
        Me.lblDrive.Size = New System.Drawing.Size(156, 29)
        Me.lblDrive.TabIndex = 73
        Me.lblDrive.Text = "Drive C:"
        Me.lblDrive.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlFile
        '
        Me.pnlFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFile.Controls.Add(Me.lblSizeValue)
        Me.pnlFile.Controls.Add(Me.lblSize)
        Me.pnlFile.Controls.Add(Me.sbChangeProgram)
        Me.pnlFile.Controls.Add(Me.lblCreatedValue)
        Me.pnlFile.Controls.Add(Me.lblModified)
        Me.pnlFile.Controls.Add(Me.lblModifiedValue)
        Me.pnlFile.Controls.Add(Me.lblOpensWith)
        Me.pnlFile.Controls.Add(Me.lblAccessed)
        Me.pnlFile.Controls.Add(Me.lblOpensWithValue)
        Me.pnlFile.Controls.Add(Me.lblAccessedValue)
        Me.pnlFile.Controls.Add(Me.lblPathValue)
        Me.pnlFile.Controls.Add(Me.lblCreated)
        Me.pnlFile.Controls.Add(Me.lblPath)
        Me.pnlFile.Location = New System.Drawing.Point(17, 64)
        Me.pnlFile.Name = "pnlFile"
        Me.pnlFile.Size = New System.Drawing.Size(470, 407)
        Me.pnlFile.TabIndex = 91
        Me.pnlFile.Visible = False
        '
        'lblSizeValue
        '
        Me.lblSizeValue.AutoSize = True
        Me.lblSizeValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSizeValue.ForeColor = System.Drawing.Color.Orange
        Me.lblSizeValue.Location = New System.Drawing.Point(72, 63)
        Me.lblSizeValue.Name = "lblSizeValue"
        Me.lblSizeValue.Size = New System.Drawing.Size(25, 21)
        Me.lblSizeValue.TabIndex = 91
        Me.lblSizeValue.Text = "xkb"
        '
        'lblSize
        '
        Me.lblSize.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.ForeColor = System.Drawing.Color.Orange
        Me.lblSize.Location = New System.Drawing.Point(6, 63)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(64, 26)
        Me.lblSize.TabIndex = 92
        Me.lblSize.Text = "Size"
        '
        'sbChangeProgram
        '
        Me.sbChangeProgram.Beeping = False
        Me.sbChangeProgram.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbChangeProgram.ButtonText = "CHANGE"
        Me.sbChangeProgram.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.sbChangeProgram.ButtonTextHeight = 14
        Me.sbChangeProgram.Clickable = True
        Me.sbChangeProgram.Color = LCARS.LCARScolorStyles.SystemFunction
        Me.sbChangeProgram.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbChangeProgram.Data = Nothing
        Me.sbChangeProgram.Data2 = Nothing
        Me.sbChangeProgram.FlashInterval = 500
        Me.sbChangeProgram.holdDraw = False
        Me.sbChangeProgram.Lit = True
        Me.sbChangeProgram.Location = New System.Drawing.Point(9, 205)
        Me.sbChangeProgram.Name = "sbChangeProgram"
        Me.sbChangeProgram.RedAlert = LCARS.LCARSalert.Normal
        Me.sbChangeProgram.Size = New System.Drawing.Size(66, 20)
        Me.sbChangeProgram.TabIndex = 49
        Me.sbChangeProgram.Text = "CHANGE"
        '
        'lblCreatedValue
        '
        Me.lblCreatedValue.AutoSize = True
        Me.lblCreatedValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedValue.ForeColor = System.Drawing.Color.Orange
        Me.lblCreatedValue.Location = New System.Drawing.Point(71, 89)
        Me.lblCreatedValue.Name = "lblCreatedValue"
        Me.lblCreatedValue.Size = New System.Drawing.Size(35, 21)
        Me.lblCreatedValue.TabIndex = 52
        Me.lblCreatedValue.Text = "x/x/x"
        '
        'lblModified
        '
        Me.lblModified.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModified.ForeColor = System.Drawing.Color.Orange
        Me.lblModified.Location = New System.Drawing.Point(5, 122)
        Me.lblModified.Name = "lblModified"
        Me.lblModified.Size = New System.Drawing.Size(64, 26)
        Me.lblModified.TabIndex = 90
        Me.lblModified.Text = "Modified:"
        '
        'lblModifiedValue
        '
        Me.lblModifiedValue.AutoSize = True
        Me.lblModifiedValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModifiedValue.ForeColor = System.Drawing.Color.Orange
        Me.lblModifiedValue.Location = New System.Drawing.Point(71, 122)
        Me.lblModifiedValue.Name = "lblModifiedValue"
        Me.lblModifiedValue.Size = New System.Drawing.Size(35, 21)
        Me.lblModifiedValue.TabIndex = 89
        Me.lblModifiedValue.Text = "x/x/x"
        '
        'lblOpensWith
        '
        Me.lblOpensWith.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpensWith.ForeColor = System.Drawing.Color.Orange
        Me.lblOpensWith.Location = New System.Drawing.Point(5, 181)
        Me.lblOpensWith.Name = "lblOpensWith"
        Me.lblOpensWith.Size = New System.Drawing.Size(64, 26)
        Me.lblOpensWith.TabIndex = 88
        Me.lblOpensWith.Text = "Opens With: "
        '
        'lblAccessed
        '
        Me.lblAccessed.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessed.ForeColor = System.Drawing.Color.Orange
        Me.lblAccessed.Location = New System.Drawing.Point(5, 155)
        Me.lblAccessed.Name = "lblAccessed"
        Me.lblAccessed.Size = New System.Drawing.Size(64, 26)
        Me.lblAccessed.TabIndex = 88
        Me.lblAccessed.Text = "Accessed:"
        '
        'lblOpensWithValue
        '
        Me.lblOpensWithValue.AutoSize = True
        Me.lblOpensWithValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpensWithValue.ForeColor = System.Drawing.Color.Orange
        Me.lblOpensWithValue.Location = New System.Drawing.Point(71, 181)
        Me.lblOpensWithValue.Name = "lblOpensWithValue"
        Me.lblOpensWithValue.Size = New System.Drawing.Size(87, 21)
        Me.lblOpensWithValue.TabIndex = 87
        Me.lblOpensWithValue.Text = "example program"
        '
        'lblAccessedValue
        '
        Me.lblAccessedValue.AutoSize = True
        Me.lblAccessedValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessedValue.ForeColor = System.Drawing.Color.Orange
        Me.lblAccessedValue.Location = New System.Drawing.Point(71, 155)
        Me.lblAccessedValue.Name = "lblAccessedValue"
        Me.lblAccessedValue.Size = New System.Drawing.Size(35, 21)
        Me.lblAccessedValue.TabIndex = 87
        Me.lblAccessedValue.Text = "x/x/x"
        '
        'lblPathValue
        '
        Me.lblPathValue.AutoEllipsis = True
        Me.lblPathValue.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPathValue.ForeColor = System.Drawing.Color.Orange
        Me.lblPathValue.Location = New System.Drawing.Point(75, 33)
        Me.lblPathValue.Name = "lblPathValue"
        Me.lblPathValue.Size = New System.Drawing.Size(378, 26)
        Me.lblPathValue.TabIndex = 76
        Me.lblPathValue.Text = "C:\"
        '
        'lblCreated
        '
        Me.lblCreated.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreated.ForeColor = System.Drawing.Color.Orange
        Me.lblCreated.Location = New System.Drawing.Point(5, 89)
        Me.lblCreated.Name = "lblCreated"
        Me.lblCreated.Size = New System.Drawing.Size(64, 26)
        Me.lblCreated.TabIndex = 74
        Me.lblCreated.Text = "Created:"
        '
        'lblPath
        '
        Me.lblPath.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.Orange
        Me.lblPath.Location = New System.Drawing.Point(9, 34)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(60, 29)
        Me.lblPath.TabIndex = 75
        Me.lblPath.Text = "Path: "
        '
        'lblPropTitle
        '
        Me.lblPropTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropTitle.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropTitle.ForeColor = System.Drawing.Color.Orange
        Me.lblPropTitle.Location = New System.Drawing.Point(17, 13)
        Me.lblPropTitle.Name = "lblPropTitle"
        Me.lblPropTitle.Size = New System.Drawing.Size(470, 52)
        Me.lblPropTitle.TabIndex = 50
        Me.lblPropTitle.Text = "PROPERTIES"
        '
        'sbCloseProperties
        '
        Me.sbCloseProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCloseProperties.Beeping = False
        Me.sbCloseProperties.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCloseProperties.ButtonText = "CLOSE"
        Me.sbCloseProperties.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbCloseProperties.ButtonTextHeight = 14
        Me.sbCloseProperties.Clickable = True
        Me.sbCloseProperties.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbCloseProperties.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCloseProperties.Data = Nothing
        Me.sbCloseProperties.Data2 = Nothing
        Me.sbCloseProperties.FlashInterval = 500
        Me.sbCloseProperties.holdDraw = False
        Me.sbCloseProperties.Lit = True
        Me.sbCloseProperties.Location = New System.Drawing.Point(407, 477)
        Me.sbCloseProperties.Name = "sbCloseProperties"
        Me.sbCloseProperties.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCloseProperties.Size = New System.Drawing.Size(87, 26)
        Me.sbCloseProperties.TabIndex = 49
        Me.sbCloseProperties.Text = "CLOSE"
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
        'pnlRename
        '
        Me.pnlRename.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRename.Controls.Add(Me.sbOK)
        Me.pnlRename.Controls.Add(Me.txtNew)
        Me.pnlRename.Controls.Add(Me.lblFileName)
        Me.pnlRename.Controls.Add(Me.lblRename)
        Me.pnlRename.Controls.Add(Me.sbCancel)
        Me.pnlRename.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlRename.ForeColor = System.Drawing.Color.Orange
        Me.pnlRename.Location = New System.Drawing.Point(33, 40)
        Me.pnlRename.Name = "pnlRename"
        Me.pnlRename.Size = New System.Drawing.Size(470, 492)
        Me.pnlRename.TabIndex = 91
        Me.pnlRename.Visible = False
        '
        'sbOK
        '
        Me.sbOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbOK.Beeping = False
        Me.sbOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbOK.ButtonText = "OK"
        Me.sbOK.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbOK.ButtonTextHeight = 14
        Me.sbOK.Clickable = True
        Me.sbOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbOK.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbOK.Data = Nothing
        Me.sbOK.Data2 = Nothing
        Me.sbOK.FlashInterval = 500
        Me.sbOK.holdDraw = False
        Me.sbOK.Lit = True
        Me.sbOK.Location = New System.Drawing.Point(356, 456)
        Me.sbOK.Name = "sbOK"
        Me.sbOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbOK.Size = New System.Drawing.Size(87, 26)
        Me.sbOK.TabIndex = 55
        Me.sbOK.Text = "OK"
        '
        'txtNew
        '
        Me.txtNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNew.BackColor = System.Drawing.Color.Black
        Me.txtNew.Font = New System.Drawing.Font("LCARS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNew.ForeColor = System.Drawing.Color.Orange
        Me.txtNew.Location = New System.Drawing.Point(46, 243)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(397, 38)
        Me.txtNew.TabIndex = 54
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(42, 211)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(117, 24)
        Me.lblFileName.TabIndex = 53
        Me.lblFileName.Text = "File/Directory Name:"
        '
        'lblRename
        '
        Me.lblRename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRename.Font = New System.Drawing.Font("LCARS", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRename.ForeColor = System.Drawing.Color.Orange
        Me.lblRename.Location = New System.Drawing.Point(17, 0)
        Me.lblRename.Name = "lblRename"
        Me.lblRename.Size = New System.Drawing.Size(443, 52)
        Me.lblRename.TabIndex = 50
        Me.lblRename.Text = "RENAME"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.Beeping = False
        Me.sbCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbCancel.ButtonText = "CANCEL"
        Me.sbCancel.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbCancel.ButtonTextHeight = 14
        Me.sbCancel.Clickable = True
        Me.sbCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbCancel.CustomAlertColor = System.Drawing.Color.Empty
        Me.sbCancel.Data = Nothing
        Me.sbCancel.Data2 = Nothing
        Me.sbCancel.FlashInterval = 500
        Me.sbCancel.holdDraw = False
        Me.sbCancel.Lit = True
        Me.sbCancel.Location = New System.Drawing.Point(263, 456)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCancel.Size = New System.Drawing.Size(87, 26)
        Me.sbCancel.TabIndex = 49
        Me.sbCancel.Text = "CANCEL"
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
        Me.gridMyComp.ColorsAvailable = LcarScolor2
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
        'lblDriveTypeLabel
        '
        Me.lblDriveTypeLabel.AutoSize = True
        Me.lblDriveTypeLabel.Color = LCARS.LCARScolorStyles.Orange
        Me.lblDriveTypeLabel.Location = New System.Drawing.Point(9, 160)
        Me.lblDriveTypeLabel.Name = "lblDriveTypeLabel"
        Me.lblDriveTypeLabel.Size = New System.Drawing.Size(58, 21)
        Me.lblDriveTypeLabel.TabIndex = 92
        Me.lblDriveTypeLabel.Text = "Drive type:"
        Me.lblDriveTypeLabel.TextHeight = 14
        '
        'lblDriveType
        '
        Me.lblDriveType.AutoSize = True
        Me.lblDriveType.Color = LCARS.LCARScolorStyles.Orange
        Me.lblDriveType.Location = New System.Drawing.Point(75, 160)
        Me.lblDriveType.Name = "lblDriveType"
        Me.lblDriveType.Size = New System.Drawing.Size(57, 21)
        Me.lblDriveType.TabIndex = 92
        Me.lblDriveType.Text = "Removable"
        Me.lblDriveType.TextHeight = 14
        '
        'frmMyComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 562)
        Me.Controls.Add(Me.pnlProperties)
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
        Me.Controls.Add(Me.pnlRename)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmMyComp"
        Me.Text = "My Computer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlProperties.ResumeLayout(False)
        Me.pnlMultiple.ResumeLayout(False)
        Me.pnlMultiple.PerformLayout()
        Me.pnlFolder.ResumeLayout(False)
        Me.pnlFolder.PerformLayout()
        Me.pnlDrive.ResumeLayout(False)
        Me.pnlDrive.PerformLayout()
        Me.pnlFile.ResumeLayout(False)
        Me.pnlFile.PerformLayout()
        Me.pnlRename.ResumeLayout(False)
        Me.pnlRename.PerformLayout()
        Me.pnlEdit.ResumeLayout(False)
        Me.pnlOptionalComponents.ResumeLayout(False)
        Me.pnlSystemDefined.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbOptions As LCARS.Controls.StandardButton
    Friend WithEvents sbProperties As LCARS.Controls.StandardButton
    Friend WithEvents pnlProperties As System.Windows.Forms.Panel
    Friend WithEvents sbCloseProperties As LCARS.Controls.StandardButton
    Friend WithEvents pnlDrive As System.Windows.Forms.Panel
    Friend WithEvents lblPropTitle As System.Windows.Forms.Label
    Friend WithEvents lblUsed As System.Windows.Forms.Label
    Friend WithEvents pnlVisible As System.Windows.Forms.Panel
    Friend WithEvents lblDrive As System.Windows.Forms.Label
    Friend WithEvents lblUsedLabel As System.Windows.Forms.Label
    Friend WithEvents lblCapacityLabel As System.Windows.Forms.Label
    Friend WithEvents lblCapacity As System.Windows.Forms.Label
    Friend WithEvents lblFileSystemLabel As System.Windows.Forms.Label
    Friend WithEvents lblFS As System.Windows.Forms.Label
    Friend WithEvents tmrMouseSelect As System.Windows.Forms.Timer
    Friend WithEvents sbUpDir As LCARS.Controls.StandardButton
    Friend WithEvents pnlRename As System.Windows.Forms.Panel
    Friend WithEvents lblRename As System.Windows.Forms.Label
    Friend WithEvents sbCancel As LCARS.Controls.StandardButton
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents sbOK As LCARS.Controls.StandardButton
    Friend WithEvents lblFreeLabel As System.Windows.Forms.Label
    Friend WithEvents lblFree As System.Windows.Forms.Label
    Friend WithEvents sbClose As LCARS.Controls.StandardButton
    Friend WithEvents pnlFile As System.Windows.Forms.Panel
    Friend WithEvents lblCreatedValue As System.Windows.Forms.Label
    Friend WithEvents lblModified As System.Windows.Forms.Label
    Friend WithEvents lblModifiedValue As System.Windows.Forms.Label
    Friend WithEvents lblAccessed As System.Windows.Forms.Label
    Friend WithEvents lblAccessedValue As System.Windows.Forms.Label
    Friend WithEvents lblPathValue As System.Windows.Forms.Label
    Friend WithEvents lblCreated As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblSizeValue As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents lblOpensWith As System.Windows.Forms.Label
    Friend WithEvents sbChangeProgram As LCARS.Controls.StandardButton
    Friend WithEvents lblOpensWithValue As System.Windows.Forms.Label
    Friend WithEvents pnlFolder As System.Windows.Forms.Panel
    Friend WithEvents lblFolderSizeValue As System.Windows.Forms.Label
    Friend WithEvents lblFolderSize As System.Windows.Forms.Label
    Friend WithEvents lblFolderCreatedValue As System.Windows.Forms.Label
    Friend WithEvents lblFolderPathValue As System.Windows.Forms.Label
    Friend WithEvents lblFolderCreated As System.Windows.Forms.Label
    Friend WithEvents lblFolderPath As System.Windows.Forms.Label
    Friend WithEvents lblContainsValue As System.Windows.Forms.Label
    Friend WithEvents lblContains As System.Windows.Forms.Label
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
    Friend WithEvents liDrive As LCARS.Controls.LevelIndicator
    Friend WithEvents lblFreeSpace As System.Windows.Forms.Label
    Friend WithEvents sbRefresh As LCARS.Controls.StandardButton
    Friend WithEvents pnlMultiple As System.Windows.Forms.Panel
    Friend WithEvents lblMultipleOut As System.Windows.Forms.Label
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
    Friend WithEvents lblDriveTypeLabel As LCARS.Controls.LCARSLabel
    Friend WithEvents lblDriveType As LCARS.Controls.LCARSLabel

End Class
