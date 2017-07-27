<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProperties
    Inherits LCARS.LCARSForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlDrive = New System.Windows.Forms.Panel
        Me.lblDriveType = New LCARS.Controls.LCARSLabel
        Me.lblDriveTypeLabel = New LCARS.Controls.LCARSLabel
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
        Me.pnlDrive.SuspendLayout()
        Me.pnlMultiple.SuspendLayout()
        Me.pnlFolder.SuspendLayout()
        Me.pnlFile.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pnlDrive.Location = New System.Drawing.Point(12, 58)
        Me.pnlDrive.Name = "pnlDrive"
        Me.pnlDrive.Size = New System.Drawing.Size(436, 325)
        Me.pnlDrive.TabIndex = 96
        Me.pnlDrive.Visible = False
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
        Me.liDrive.DialogResult = System.Windows.Forms.DialogResult.None
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
        'pnlMultiple
        '
        Me.pnlMultiple.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMultiple.Controls.Add(Me.lblMultipleOut)
        Me.pnlMultiple.Location = New System.Drawing.Point(12, 58)
        Me.pnlMultiple.Name = "pnlMultiple"
        Me.pnlMultiple.Size = New System.Drawing.Size(436, 319)
        Me.pnlMultiple.TabIndex = 99
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
        Me.pnlFolder.Location = New System.Drawing.Point(12, 60)
        Me.pnlFolder.Name = "pnlFolder"
        Me.pnlFolder.Size = New System.Drawing.Size(436, 323)
        Me.pnlFolder.TabIndex = 98
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
        Me.pnlFile.Location = New System.Drawing.Point(12, 60)
        Me.pnlFile.Name = "pnlFile"
        Me.pnlFile.Size = New System.Drawing.Size(436, 323)
        Me.pnlFile.TabIndex = 97
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
        Me.sbChangeProgram.DialogResult = System.Windows.Forms.DialogResult.None
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
        Me.lblPropTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblPropTitle.Name = "lblPropTitle"
        Me.lblPropTitle.Size = New System.Drawing.Size(344, 52)
        Me.lblPropTitle.TabIndex = 95
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
        Me.sbCloseProperties.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCloseProperties.FlashInterval = 500
        Me.sbCloseProperties.holdDraw = False
        Me.sbCloseProperties.Lit = True
        Me.sbCloseProperties.Location = New System.Drawing.Point(363, 400)
        Me.sbCloseProperties.Name = "sbCloseProperties"
        Me.sbCloseProperties.RedAlert = LCARS.LCARSalert.Normal
        Me.sbCloseProperties.Size = New System.Drawing.Size(87, 26)
        Me.sbCloseProperties.TabIndex = 94
        Me.sbCloseProperties.Text = "CLOSE"
        '
        'frmProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.sbCloseProperties
        Me.ClientSize = New System.Drawing.Size(462, 438)
        Me.Controls.Add(Me.pnlDrive)
        Me.Controls.Add(Me.pnlMultiple)
        Me.Controls.Add(Me.pnlFolder)
        Me.Controls.Add(Me.pnlFile)
        Me.Controls.Add(Me.lblPropTitle)
        Me.Controls.Add(Me.sbCloseProperties)
        Me.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Orange
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "frmProperties"
        Me.Text = "frmProperties"
        Me.pnlDrive.ResumeLayout(False)
        Me.pnlDrive.PerformLayout()
        Me.pnlMultiple.ResumeLayout(False)
        Me.pnlMultiple.PerformLayout()
        Me.pnlFolder.ResumeLayout(False)
        Me.pnlFolder.PerformLayout()
        Me.pnlFile.ResumeLayout(False)
        Me.pnlFile.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDrive As System.Windows.Forms.Panel
    Friend WithEvents lblDriveType As LCARS.Controls.LCARSLabel
    Friend WithEvents lblDriveTypeLabel As LCARS.Controls.LCARSLabel
    Friend WithEvents liDrive As LCARS.Controls.LevelIndicator
    Friend WithEvents lblUsed As System.Windows.Forms.Label
    Friend WithEvents lblFreeLabel As System.Windows.Forms.Label
    Friend WithEvents lblFree As System.Windows.Forms.Label
    Friend WithEvents lblFreeSpace As System.Windows.Forms.Label
    Friend WithEvents lblFileSystemLabel As System.Windows.Forms.Label
    Friend WithEvents lblFS As System.Windows.Forms.Label
    Friend WithEvents lblCapacity As System.Windows.Forms.Label
    Friend WithEvents lblUsedLabel As System.Windows.Forms.Label
    Friend WithEvents lblCapacityLabel As System.Windows.Forms.Label
    Friend WithEvents lblDrive As System.Windows.Forms.Label
    Friend WithEvents pnlMultiple As System.Windows.Forms.Panel
    Friend WithEvents lblMultipleOut As System.Windows.Forms.Label
    Friend WithEvents pnlFolder As System.Windows.Forms.Panel
    Friend WithEvents lblFolderSizeValue As System.Windows.Forms.Label
    Friend WithEvents lblFolderSize As System.Windows.Forms.Label
    Friend WithEvents lblContainsValue As System.Windows.Forms.Label
    Friend WithEvents lblFolderCreatedValue As System.Windows.Forms.Label
    Friend WithEvents lblFolderPathValue As System.Windows.Forms.Label
    Friend WithEvents lblContains As System.Windows.Forms.Label
    Friend WithEvents lblFolderCreated As System.Windows.Forms.Label
    Friend WithEvents lblFolderPath As System.Windows.Forms.Label
    Friend WithEvents pnlFile As System.Windows.Forms.Panel
    Friend WithEvents lblSizeValue As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents sbChangeProgram As LCARS.Controls.StandardButton
    Friend WithEvents lblCreatedValue As System.Windows.Forms.Label
    Friend WithEvents lblModified As System.Windows.Forms.Label
    Friend WithEvents lblModifiedValue As System.Windows.Forms.Label
    Friend WithEvents lblOpensWith As System.Windows.Forms.Label
    Friend WithEvents lblAccessed As System.Windows.Forms.Label
    Friend WithEvents lblOpensWithValue As System.Windows.Forms.Label
    Friend WithEvents lblAccessedValue As System.Windows.Forms.Label
    Friend WithEvents lblPathValue As System.Windows.Forms.Label
    Friend WithEvents lblCreated As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblPropTitle As System.Windows.Forms.Label
    Friend WithEvents sbCloseProperties As LCARS.Controls.StandardButton
End Class
