<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LCARSfileBrowseDialog
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LCARSfileBrowseDialog))
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFileName = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.pnlFiles = New System.Windows.Forms.Panel
        Me.cboFilter = New System.Windows.Forms.ComboBox
        Me.fbUpDir = New LCARS.Controls.FlatButton
        Me.sbSaveOK = New LCARS.Controls.StandardButton
        Me.sbSaveCancel = New LCARS.Controls.StandardButton
        Me.sbMyComp = New LCARS.Controls.StandardButton
        Me.sbMyDocs = New LCARS.Controls.StandardButton
        Me.sbNetwork = New LCARS.Controls.StandardButton
        Me.sbTitleBottom = New LCARS.Controls.StandardButton
        Me.sbDesktop = New LCARS.Controls.StandardButton
        Me.sbTitle = New LCARS.Controls.StandardButton
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(25, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "LOCATION JUMP"
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileName.ForeColor = System.Drawing.Color.Orange
        Me.lblFileName.Location = New System.Drawing.Point(12, 458)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(67, 24)
        Me.lblFileName.TabIndex = 10
        Me.lblFileName.Text = "FILE NAME:"
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.BackColor = System.Drawing.Color.Orange
        Me.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFileName.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.ForeColor = System.Drawing.Color.Black
        Me.txtFileName.Location = New System.Drawing.Point(85, 457)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(199, 28)
        Me.txtFileName.TabIndex = 9
        '
        'pnlFiles
        '
        Me.pnlFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiles.Location = New System.Drawing.Point(149, 78)
        Me.pnlFiles.Name = "pnlFiles"
        Me.pnlFiles.Size = New System.Drawing.Size(516, 338)
        Me.pnlFiles.TabIndex = 8
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.cboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFilter.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilter.ForeColor = System.Drawing.Color.Orange
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Items.AddRange(New Object() {"*.TXT", "*.RTF", "*.DOC", "*.*"})
        Me.cboFilter.Location = New System.Drawing.Point(290, 457)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(121, 32)
        Me.cboFilter.TabIndex = 13
        Me.cboFilter.Text = "*.TXT"
        '
        'fbUpDir
        '
        Me.fbUpDir.BackgroundImage = CType(resources.GetObject("fbUpDir.BackgroundImage"), System.Drawing.Image)
        Me.fbUpDir.Beeping = False
        Me.fbUpDir.ButtonText = "UP A DIRECTORY"
        Me.fbUpDir.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.fbUpDir.ButtonTextHeight = 14
        Me.fbUpDir.Clickable = True
        Me.fbUpDir.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.fbUpDir.Data = Nothing
        Me.fbUpDir.Data2 = Nothing
        Me.fbUpDir.FlashInterval = 500
        Me.fbUpDir.holdDraw = False
        Me.fbUpDir.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbUpDir.lblTextLoc = New System.Drawing.Point(0, 0)
        Me.fbUpDir.lblTextSize = New System.Drawing.Point(106, 35)
        Me.fbUpDir.lblTextVisible = True
        Me.fbUpDir.Lit = True
        Me.fbUpDir.Location = New System.Drawing.Point(155, 37)
        Me.fbUpDir.Name = "fbUpDir"
        Me.fbUpDir.RedAlert = LCARS.LCARSalert.Normal
        Me.fbUpDir.Size = New System.Drawing.Size(106, 35)
        Me.fbUpDir.TabIndex = 12
        Me.fbUpDir.Text = "UP A DIRECTORY"
        '
        'sbSaveOK
        '
        Me.sbSaveOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSaveOK.BackgroundImage = CType(resources.GetObject("sbSaveOK.BackgroundImage"), System.Drawing.Image)
        Me.sbSaveOK.Beeping = False
        Me.sbSaveOK.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbSaveOK.ButtonText = "OK"
        Me.sbSaveOK.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSaveOK.ButtonTextHeight = 14
        Me.sbSaveOK.Clickable = True
        Me.sbSaveOK.Color = LCARS.LCARScolorStyles.PrimaryFunction
        Me.sbSaveOK.Data = Nothing
        Me.sbSaveOK.Data2 = Nothing
        Me.sbSaveOK.FlashInterval = 500
        Me.sbSaveOK.holdDraw = False
        Me.sbSaveOK.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSaveOK.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbSaveOK.lblTextSize = New System.Drawing.Point(78, 35)
        Me.sbSaveOK.lblTextVisible = True
        Me.sbSaveOK.Lit = True
        Me.sbSaveOK.Location = New System.Drawing.Point(433, 454)
        Me.sbSaveOK.Name = "sbSaveOK"
        Me.sbSaveOK.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSaveOK.Size = New System.Drawing.Size(113, 35)
        Me.sbSaveOK.TabIndex = 3
        Me.sbSaveOK.Text = "OK"
        '
        'sbSaveCancel
        '
        Me.sbSaveCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSaveCancel.BackgroundImage = CType(resources.GetObject("sbSaveCancel.BackgroundImage"), System.Drawing.Image)
        Me.sbSaveCancel.Beeping = False
        Me.sbSaveCancel.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbSaveCancel.ButtonText = "CANCEL"
        Me.sbSaveCancel.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbSaveCancel.ButtonTextHeight = 14
        Me.sbSaveCancel.Clickable = True
        Me.sbSaveCancel.Color = LCARS.LCARScolorStyles.CriticalFunction
        Me.sbSaveCancel.Data = Nothing
        Me.sbSaveCancel.Data2 = Nothing
        Me.sbSaveCancel.FlashInterval = 500
        Me.sbSaveCancel.holdDraw = False
        Me.sbSaveCancel.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSaveCancel.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbSaveCancel.lblTextSize = New System.Drawing.Point(78, 35)
        Me.sbSaveCancel.lblTextVisible = True
        Me.sbSaveCancel.Lit = True
        Me.sbSaveCancel.Location = New System.Drawing.Point(552, 454)
        Me.sbSaveCancel.Name = "sbSaveCancel"
        Me.sbSaveCancel.RedAlert = LCARS.LCARSalert.Normal
        Me.sbSaveCancel.Size = New System.Drawing.Size(113, 35)
        Me.sbSaveCancel.TabIndex = 2
        Me.sbSaveCancel.Text = "CANCEL"
        '
        'sbMyComp
        '
        Me.sbMyComp.BackgroundImage = CType(resources.GetObject("sbMyComp.BackgroundImage"), System.Drawing.Image)
        Me.sbMyComp.Beeping = False
        Me.sbMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbMyComp.ButtonText = "MY COMPUTER"
        Me.sbMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbMyComp.ButtonTextHeight = 14
        Me.sbMyComp.Clickable = True
        Me.sbMyComp.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbMyComp.Data = Nothing
        Me.sbMyComp.Data2 = Nothing
        Me.sbMyComp.FlashInterval = 500
        Me.sbMyComp.holdDraw = False
        Me.sbMyComp.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbMyComp.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbMyComp.lblTextSize = New System.Drawing.Point(90, 35)
        Me.sbMyComp.lblTextVisible = True
        Me.sbMyComp.Lit = True
        Me.sbMyComp.Location = New System.Drawing.Point(12, 67)
        Me.sbMyComp.Name = "sbMyComp"
        Me.sbMyComp.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMyComp.Size = New System.Drawing.Size(125, 35)
        Me.sbMyComp.TabIndex = 4
        Me.sbMyComp.Text = "MY COMPUTER"
        '
        'sbMyDocs
        '
        Me.sbMyDocs.BackgroundImage = CType(resources.GetObject("sbMyDocs.BackgroundImage"), System.Drawing.Image)
        Me.sbMyDocs.Beeping = False
        Me.sbMyDocs.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbMyDocs.ButtonText = "MY DOCUMENTS"
        Me.sbMyDocs.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbMyDocs.ButtonTextHeight = 14
        Me.sbMyDocs.Clickable = True
        Me.sbMyDocs.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbMyDocs.Data = Nothing
        Me.sbMyDocs.Data2 = Nothing
        Me.sbMyDocs.FlashInterval = 500
        Me.sbMyDocs.holdDraw = False
        Me.sbMyDocs.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbMyDocs.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbMyDocs.lblTextSize = New System.Drawing.Point(90, 35)
        Me.sbMyDocs.lblTextVisible = True
        Me.sbMyDocs.Lit = True
        Me.sbMyDocs.Location = New System.Drawing.Point(12, 108)
        Me.sbMyDocs.Name = "sbMyDocs"
        Me.sbMyDocs.RedAlert = LCARS.LCARSalert.Normal
        Me.sbMyDocs.Size = New System.Drawing.Size(125, 35)
        Me.sbMyDocs.TabIndex = 5
        Me.sbMyDocs.Text = "MY DOCUMENTS"
        '
        'sbNetwork
        '
        Me.sbNetwork.BackgroundImage = CType(resources.GetObject("sbNetwork.BackgroundImage"), System.Drawing.Image)
        Me.sbNetwork.Beeping = False
        Me.sbNetwork.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbNetwork.ButtonText = "NETWORK"
        Me.sbNetwork.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbNetwork.ButtonTextHeight = 14
        Me.sbNetwork.Clickable = True
        Me.sbNetwork.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbNetwork.Data = Nothing
        Me.sbNetwork.Data2 = Nothing
        Me.sbNetwork.FlashInterval = 500
        Me.sbNetwork.holdDraw = False
        Me.sbNetwork.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbNetwork.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbNetwork.lblTextSize = New System.Drawing.Point(90, 35)
        Me.sbNetwork.lblTextVisible = True
        Me.sbNetwork.Lit = False
        Me.sbNetwork.Location = New System.Drawing.Point(12, 190)
        Me.sbNetwork.Name = "sbNetwork"
        Me.sbNetwork.RedAlert = LCARS.LCARSalert.Normal
        Me.sbNetwork.Size = New System.Drawing.Size(125, 35)
        Me.sbNetwork.TabIndex = 7
        Me.sbNetwork.Text = "NETWORK"
        '
        'sbTitleBottom
        '
        Me.sbTitleBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitleBottom.BackgroundImage = CType(resources.GetObject("sbTitleBottom.BackgroundImage"), System.Drawing.Image)
        Me.sbTitleBottom.Beeping = True
        Me.sbTitleBottom.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbTitleBottom.ButtonText = "SAVE"
        Me.sbTitleBottom.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbTitleBottom.ButtonTextHeight = 14
        Me.sbTitleBottom.Clickable = True
        Me.sbTitleBottom.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.sbTitleBottom.Data = Nothing
        Me.sbTitleBottom.Data2 = Nothing
        Me.sbTitleBottom.FlashInterval = 500
        Me.sbTitleBottom.holdDraw = False
        Me.sbTitleBottom.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitleBottom.lblTextLoc = New System.Drawing.Point(11, 0)
        Me.sbTitleBottom.lblTextSize = New System.Drawing.Point(637, 22)
        Me.sbTitleBottom.lblTextVisible = True
        Me.sbTitleBottom.Lit = True
        Me.sbTitleBottom.Location = New System.Drawing.Point(6, 495)
        Me.sbTitleBottom.Name = "sbTitleBottom"
        Me.sbTitleBottom.RedAlert = LCARS.LCARSalert.Normal
        Me.sbTitleBottom.Size = New System.Drawing.Size(659, 22)
        Me.sbTitleBottom.TabIndex = 1
        Me.sbTitleBottom.Text = "SAVE"
        '
        'sbDesktop
        '
        Me.sbDesktop.BackgroundImage = CType(resources.GetObject("sbDesktop.BackgroundImage"), System.Drawing.Image)
        Me.sbDesktop.Beeping = False
        Me.sbDesktop.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbDesktop.ButtonText = "DESKTOP"
        Me.sbDesktop.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbDesktop.ButtonTextHeight = 14
        Me.sbDesktop.Clickable = True
        Me.sbDesktop.Color = LCARS.LCARScolorStyles.NavigationFunction
        Me.sbDesktop.Data = Nothing
        Me.sbDesktop.Data2 = Nothing
        Me.sbDesktop.FlashInterval = 500
        Me.sbDesktop.holdDraw = False
        Me.sbDesktop.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbDesktop.lblTextLoc = New System.Drawing.Point(17, 0)
        Me.sbDesktop.lblTextSize = New System.Drawing.Point(90, 35)
        Me.sbDesktop.lblTextVisible = True
        Me.sbDesktop.Lit = True
        Me.sbDesktop.Location = New System.Drawing.Point(12, 149)
        Me.sbDesktop.Name = "sbDesktop"
        Me.sbDesktop.RedAlert = LCARS.LCARSalert.Normal
        Me.sbDesktop.Size = New System.Drawing.Size(125, 35)
        Me.sbDesktop.TabIndex = 6
        Me.sbDesktop.Text = "DESKTOP"
        '
        'sbTitle
        '
        Me.sbTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitle.BackgroundImage = CType(resources.GetObject("sbTitle.BackgroundImage"), System.Drawing.Image)
        Me.sbTitle.Beeping = True
        Me.sbTitle.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.Pill
        Me.sbTitle.ButtonText = "SAVE"
        Me.sbTitle.ButtonTextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.sbTitle.ButtonTextHeight = 14
        Me.sbTitle.Clickable = True
        Me.sbTitle.Color = LCARS.LCARScolorStyles.LCARSDisplayOnly
        Me.sbTitle.Data = Nothing
        Me.sbTitle.Data2 = Nothing
        Me.sbTitle.FlashInterval = 500
        Me.sbTitle.holdDraw = False
        Me.sbTitle.lblTextAnchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbTitle.lblTextLoc = New System.Drawing.Point(11, 0)
        Me.sbTitle.lblTextSize = New System.Drawing.Point(637, 22)
        Me.sbTitle.lblTextVisible = True
        Me.sbTitle.Lit = True
        Me.sbTitle.Location = New System.Drawing.Point(6, 6)
        Me.sbTitle.Name = "sbTitle"
        Me.sbTitle.RedAlert = LCARS.LCARSalert.Normal
        Me.sbTitle.Size = New System.Drawing.Size(659, 22)
        Me.sbTitle.TabIndex = 0
        Me.sbTitle.Text = "SAVE"
        '
        'LCARSfileBrowseDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(671, 524)
        Me.Controls.Add(Me.cboFilter)
        Me.Controls.Add(Me.fbUpDir)
        Me.Controls.Add(Me.pnlFiles)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.sbSaveOK)
        Me.Controls.Add(Me.sbSaveCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.sbMyComp)
        Me.Controls.Add(Me.sbMyDocs)
        Me.Controls.Add(Me.sbNetwork)
        Me.Controls.Add(Me.sbTitleBottom)
        Me.Controls.Add(Me.sbDesktop)
        Me.Controls.Add(Me.sbTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LCARSfileBrowseDialog"
        Me.Text = "LCARSfileBrowseDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents pnlFiles As System.Windows.Forms.Panel
    Friend WithEvents sbNetwork As LCARS.Controls.StandardButton
    Friend WithEvents sbDesktop As LCARS.Controls.StandardButton
    Friend WithEvents sbMyDocs As LCARS.Controls.StandardButton
    Friend WithEvents sbMyComp As LCARS.Controls.StandardButton
    Friend WithEvents sbSaveOK As LCARS.Controls.StandardButton
    Friend WithEvents sbSaveCancel As LCARS.Controls.StandardButton
    Friend WithEvents sbTitleBottom As LCARS.Controls.StandardButton
    Friend WithEvents sbTitle As LCARS.Controls.StandardButton
    Friend WithEvents fbUpDir As LCARS.Controls.FlatButton
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
End Class
