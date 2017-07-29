<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngineering
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tmrSysMon = New System.Windows.Forms.Timer(Me.components)
        Me.lblMemTotal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.liMem = New LCARS.Controls.LevelIndicator
        Me.liProc = New LCARS.Controls.LevelIndicator
        Me.sbExitMyComp = New LCARS.Controls.StandardButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMan = New System.Windows.Forms.Label
        Me.lblModel = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblOSver = New System.Windows.Forms.Label
        Me.lblOS = New System.Windows.Forms.Label
        Me.lblOSpart = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblOSDir = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblBootupState = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblSystemName = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblLogProcCount = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblPysProcCount = New System.Windows.Forms.Label
        Me.pnlWMIdata = New System.Windows.Forms.Panel
        Me.label18 = New System.Windows.Forms.Label
        Me.lblMemInfo = New System.Windows.Forms.Label
        Me.lblWMImessage = New System.Windows.Forms.Label
        Me.TextButton1 = New LCARS.Controls.TextButton
        Me.pnlWMIdata.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(15, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Processor Usage"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(137, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Memory Usage (%)"
        '
        'tmrSysMon
        '
        Me.tmrSysMon.Interval = 1000
        '
        'lblMemTotal
        '
        Me.lblMemTotal.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemTotal.ForeColor = System.Drawing.Color.Orange
        Me.lblMemTotal.Location = New System.Drawing.Point(13, 499)
        Me.lblMemTotal.Name = "lblMemTotal"
        Me.lblMemTotal.Size = New System.Drawing.Size(226, 37)
        Me.lblMemTotal.TabIndex = 4
        Me.lblMemTotal.Text = "0"
        Me.lblMemTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(63, 471)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 28)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Total Physical Memory"
        '
        'liMem
        '
        Me.liMem.Beeping = True
        Me.liMem.ButtonText = "50%"
        Me.liMem.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.liMem.Clickable = False
        Me.liMem.Location = New System.Drawing.Point(157, 126)
        Me.liMem.Name = "liMem"
        Me.liMem.Size = New System.Drawing.Size(79, 342)
        Me.liMem.TabIndex = 77
        Me.liMem.Text = "50%"
        Me.liMem.Value = 50
        '
        'liProc
        '
        Me.liProc.Beeping = True
        Me.liProc.ButtonText = "50%"
        Me.liProc.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.liProc.Clickable = False
        Me.liProc.Location = New System.Drawing.Point(34, 126)
        Me.liProc.Name = "liProc"
        Me.liProc.Size = New System.Drawing.Size(79, 342)
        Me.liProc.TabIndex = 76
        Me.liProc.Text = "50%"
        Me.liProc.Value = 50
        '
        'sbExitMyComp
        '
        Me.sbExitMyComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbExitMyComp.ButtonStyle = LCARS.Controls.StandardButton.LCARSbuttonStyles.RoundedSquare
        Me.sbExitMyComp.ButtonText = "X"
        Me.sbExitMyComp.ButtonTextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.sbExitMyComp.Color = LCARS.LCARScolorStyles.FunctionOffline
        Me.sbExitMyComp.Location = New System.Drawing.Point(599, 12)
        Me.sbExitMyComp.Name = "sbExitMyComp"
        Me.sbExitMyComp.Size = New System.Drawing.Size(29, 29)
        Me.sbExitMyComp.TabIndex = 72
        Me.sbExitMyComp.Text = "X"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("LCARS", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(13, 538)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 37)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "0"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMan
        '
        Me.lblMan.AutoSize = True
        Me.lblMan.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMan.ForeColor = System.Drawing.Color.Orange
        Me.lblMan.Location = New System.Drawing.Point(145, 41)
        Me.lblMan.Name = "lblMan"
        Me.lblMan.Size = New System.Drawing.Size(16, 21)
        Me.lblMan.TabIndex = 79
        Me.lblMan.Text = "--"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.Orange
        Me.lblModel.Location = New System.Drawing.Point(145, 62)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(16, 21)
        Me.lblModel.TabIndex = 80
        Me.lblModel.Text = "--"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("LCARS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Orange
        Me.Label5.Location = New System.Drawing.Point(101, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 28)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "SYSTEM INFORMATION:"
        '
        'lblOSver
        '
        Me.lblOSver.AutoSize = True
        Me.lblOSver.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSver.ForeColor = System.Drawing.Color.Orange
        Me.lblOSver.Location = New System.Drawing.Point(145, 104)
        Me.lblOSver.Name = "lblOSver"
        Me.lblOSver.Size = New System.Drawing.Size(16, 21)
        Me.lblOSver.TabIndex = 83
        Me.lblOSver.Text = "--"
        '
        'lblOS
        '
        Me.lblOS.AutoSize = True
        Me.lblOS.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOS.ForeColor = System.Drawing.Color.Orange
        Me.lblOS.Location = New System.Drawing.Point(145, 83)
        Me.lblOS.Name = "lblOS"
        Me.lblOS.Size = New System.Drawing.Size(16, 21)
        Me.lblOS.TabIndex = 82
        Me.lblOS.Text = "--"
        '
        'lblOSpart
        '
        Me.lblOSpart.AutoSize = True
        Me.lblOSpart.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSpart.ForeColor = System.Drawing.Color.Orange
        Me.lblOSpart.Location = New System.Drawing.Point(145, 125)
        Me.lblOSpart.Name = "lblOSpart"
        Me.lblOSpart.Size = New System.Drawing.Size(16, 21)
        Me.lblOSpart.TabIndex = 84
        Me.lblOSpart.Text = "--"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Orange
        Me.Label6.Location = New System.Drawing.Point(13, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 21)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "OS PARTITION:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Orange
        Me.Label7.Location = New System.Drawing.Point(13, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 21)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "OS VERSION:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Orange
        Me.Label8.Location = New System.Drawing.Point(13, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 21)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "OPERATING SYSTEM:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Orange
        Me.Label9.Location = New System.Drawing.Point(13, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 21)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "MODEL:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Orange
        Me.Label10.Location = New System.Drawing.Point(13, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 21)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "MANUFACTURER:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Orange
        Me.Label11.Location = New System.Drawing.Point(13, 146)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 21)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "OS DIRECTORY:"
        '
        'lblOSDir
        '
        Me.lblOSDir.AutoSize = True
        Me.lblOSDir.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSDir.ForeColor = System.Drawing.Color.Orange
        Me.lblOSDir.Location = New System.Drawing.Point(145, 146)
        Me.lblOSDir.Name = "lblOSDir"
        Me.lblOSDir.Size = New System.Drawing.Size(16, 21)
        Me.lblOSDir.TabIndex = 90
        Me.lblOSDir.Text = "--"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Orange
        Me.Label12.Location = New System.Drawing.Point(13, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 21)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "BOOTUP STATE:"
        '
        'lblBootupState
        '
        Me.lblBootupState.AutoSize = True
        Me.lblBootupState.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBootupState.ForeColor = System.Drawing.Color.Orange
        Me.lblBootupState.Location = New System.Drawing.Point(145, 167)
        Me.lblBootupState.Name = "lblBootupState"
        Me.lblBootupState.Size = New System.Drawing.Size(16, 21)
        Me.lblBootupState.TabIndex = 92
        Me.lblBootupState.Text = "--"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Orange
        Me.Label13.Location = New System.Drawing.Point(13, 188)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 21)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "SYSTEM NAME:"
        '
        'lblSystemName
        '
        Me.lblSystemName.AutoSize = True
        Me.lblSystemName.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemName.ForeColor = System.Drawing.Color.Orange
        Me.lblSystemName.Location = New System.Drawing.Point(145, 188)
        Me.lblSystemName.Name = "lblSystemName"
        Me.lblSystemName.Size = New System.Drawing.Size(16, 21)
        Me.lblSystemName.TabIndex = 94
        Me.lblSystemName.Text = "--"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Orange
        Me.Label14.Location = New System.Drawing.Point(13, 230)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 21)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "LOGICAL PROCESSORS:"
        '
        'lblLogProcCount
        '
        Me.lblLogProcCount.AutoSize = True
        Me.lblLogProcCount.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogProcCount.ForeColor = System.Drawing.Color.Orange
        Me.lblLogProcCount.Location = New System.Drawing.Point(145, 230)
        Me.lblLogProcCount.Name = "lblLogProcCount"
        Me.lblLogProcCount.Size = New System.Drawing.Size(16, 21)
        Me.lblLogProcCount.TabIndex = 96
        Me.lblLogProcCount.Text = "--"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Orange
        Me.Label15.Location = New System.Drawing.Point(13, 209)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(119, 21)
        Me.Label15.TabIndex = 99
        Me.Label15.Text = "PHYSICAL PROCESSORS:"
        '
        'lblPysProcCount
        '
        Me.lblPysProcCount.AutoSize = True
        Me.lblPysProcCount.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPysProcCount.ForeColor = System.Drawing.Color.Orange
        Me.lblPysProcCount.Location = New System.Drawing.Point(145, 209)
        Me.lblPysProcCount.Name = "lblPysProcCount"
        Me.lblPysProcCount.Size = New System.Drawing.Size(16, 21)
        Me.lblPysProcCount.TabIndex = 98
        Me.lblPysProcCount.Text = "--"
        '
        'pnlWMIdata
        '
        Me.pnlWMIdata.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWMIdata.AutoScroll = True
        Me.pnlWMIdata.Controls.Add(Me.label18)
        Me.pnlWMIdata.Controls.Add(Me.lblMemInfo)
        Me.pnlWMIdata.Controls.Add(Me.Label14)
        Me.pnlWMIdata.Controls.Add(Me.lblLogProcCount)
        Me.pnlWMIdata.Controls.Add(Me.Label15)
        Me.pnlWMIdata.Controls.Add(Me.lblPysProcCount)
        Me.pnlWMIdata.Controls.Add(Me.Label13)
        Me.pnlWMIdata.Controls.Add(Me.lblSystemName)
        Me.pnlWMIdata.Controls.Add(Me.Label12)
        Me.pnlWMIdata.Controls.Add(Me.lblBootupState)
        Me.pnlWMIdata.Controls.Add(Me.Label11)
        Me.pnlWMIdata.Controls.Add(Me.lblOSDir)
        Me.pnlWMIdata.Controls.Add(Me.Label6)
        Me.pnlWMIdata.Controls.Add(Me.Label7)
        Me.pnlWMIdata.Controls.Add(Me.Label8)
        Me.pnlWMIdata.Controls.Add(Me.Label9)
        Me.pnlWMIdata.Controls.Add(Me.Label10)
        Me.pnlWMIdata.Controls.Add(Me.lblOSpart)
        Me.pnlWMIdata.Controls.Add(Me.lblOSver)
        Me.pnlWMIdata.Controls.Add(Me.lblOS)
        Me.pnlWMIdata.Controls.Add(Me.lblModel)
        Me.pnlWMIdata.Controls.Add(Me.lblMan)
        Me.pnlWMIdata.Controls.Add(Me.Label5)
        Me.pnlWMIdata.Location = New System.Drawing.Point(273, 98)
        Me.pnlWMIdata.Name = "pnlWMIdata"
        Me.pnlWMIdata.Size = New System.Drawing.Size(355, 477)
        Me.pnlWMIdata.TabIndex = 100
        Me.pnlWMIdata.Visible = False
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.ForeColor = System.Drawing.Color.Orange
        Me.label18.Location = New System.Drawing.Point(13, 263)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(78, 21)
        Me.label18.TabIndex = 101
        Me.label18.Text = "MEMORY INFO:"
        '
        'lblMemInfo
        '
        Me.lblMemInfo.AutoSize = True
        Me.lblMemInfo.Font = New System.Drawing.Font("LCARS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemInfo.ForeColor = System.Drawing.Color.Orange
        Me.lblMemInfo.Location = New System.Drawing.Point(145, 263)
        Me.lblMemInfo.Name = "lblMemInfo"
        Me.lblMemInfo.Size = New System.Drawing.Size(16, 21)
        Me.lblMemInfo.TabIndex = 100
        Me.lblMemInfo.Text = "--"
        '
        'lblWMImessage
        '
        Me.lblWMImessage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblWMImessage.AutoSize = True
        Me.lblWMImessage.Font = New System.Drawing.Font("LCARS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWMImessage.ForeColor = System.Drawing.Color.White
        Me.lblWMImessage.Location = New System.Drawing.Point(35, 47)
        Me.lblWMImessage.Name = "lblWMImessage"
        Me.lblWMImessage.Size = New System.Drawing.Size(418, 48)
        Me.lblWMImessage.TabIndex = 100
        Me.lblWMImessage.Text = "WMI Core is not installed on this computer.  WMI Core extends the amount, detail," & _
            " " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and accuracy of the information available on this page."
        Me.lblWMImessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblWMImessage.Visible = False
        '
        'TextButton1
        '
        Me.TextButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextButton1.Beeping = True
        Me.TextButton1.ButtonText = "ENGINEERING"
        Me.TextButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TextButton1.ButtonTextHeight = 32
        Me.TextButton1.Location = New System.Drawing.Point(12, 12)
        Me.TextButton1.Name = "TextButton1"
        Me.TextButton1.Size = New System.Drawing.Size(580, 32)
        Me.TextButton1.TabIndex = 101
        Me.TextButton1.Text = "ENGINEERING"
        '
        'frmEngineering
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 587)
        Me.Controls.Add(Me.TextButton1)
        Me.Controls.Add(Me.lblWMImessage)
        Me.Controls.Add(Me.liMem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.liProc)
        Me.Controls.Add(Me.sbExitMyComp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMemTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlWMIdata)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEngineering"
        Me.Text = "Main Engineering"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlWMIdata.ResumeLayout(False)
        Me.pnlWMIdata.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tmrSysMon As System.Windows.Forms.Timer
    Friend WithEvents lblMemTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sbExitMyComp As LCARS.Controls.StandardButton
    Friend WithEvents liProc As LCARS.Controls.LevelIndicator
    Friend WithEvents liMem As LCARS.Controls.LevelIndicator
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMan As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblOSver As System.Windows.Forms.Label
    Friend WithEvents lblOS As System.Windows.Forms.Label
    Friend WithEvents lblOSpart As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblOSDir As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblBootupState As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSystemName As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblLogProcCount As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblPysProcCount As System.Windows.Forms.Label
    Friend WithEvents pnlWMIdata As System.Windows.Forms.Panel
    Friend WithEvents lblWMImessage As System.Windows.Forms.Label
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents lblMemInfo As System.Windows.Forms.Label
    Friend WithEvents TextButton1 As LCARS.Controls.TextButton
End Class
