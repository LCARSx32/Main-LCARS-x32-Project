Imports System.Drawing
Imports System.Windows.Forms
Imports LCARS.LightweightControls

Namespace Controls
    ''' <summary>
    ''' Displays an LCARS Earth calendar
    ''' </summary>
    <System.ComponentModel.DefaultEvent("SelectedDateChanged")> _
        Public Class LCARSCalender
        Inherits Windows.Forms.Control
        ''' <summary>
        ''' Raised when the selected date changes.
        ''' </summary>
        ''' <param name="SelectedDate">Currently selected date</param>
        Public Event SelectedDateChanged(ByVal SelectedDate As DateTime)
        'Global Variables
        Dim _year As Integer = 2000
        Dim _month As Integer = 1
        Dim _selectedDate As DateTime
        Dim _padding As Integer = 5
        'Permanent Controls
        Dim buttonContainer As New WindowlessContainer
        Dim myYearButton As New LCFlatButton
        Dim myYearRight As New LCArrowButton
        Dim myYearLeft As New LCArrowButton
        Dim myMonthButton As New LCFlatButton
        Dim myMonthRight As New LCArrowButton
        Dim myMonthLeft As New LCArrowButton
        Dim myDays As New WindowlessContainer
        Dim mySunday As New LCFlatButton
        Dim myMonday As New LCFlatButton
        Dim myTuesday As New LCFlatButton
        Dim myWednesday As New LCFlatButton
        Dim myThursday As New LCFlatButton
        Dim myFriday As New LCFlatButton
        Dim mySaturday As New LCFlatButton

        ''' <summary>
        ''' Months recognized by this control
        ''' </summary>
        Public Enum Months
            January = 1
            February = 2
            March = 3
            April = 4
            May = 5
            June = 6
            July = 7
            August = 8
            September = 9
            October = 10
            November = 11
            December = 12
        End Enum
#Region " Properties "
        ''' <summary>
        ''' Currently selected year
        ''' </summary>
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                If value < 10000 And value > 0 Then
                    _year = value
                    myYearButton.Text = _year
                    ShowDays()
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Set
        End Property
        ''' <summary>
        ''' Currently selected month
        ''' </summary>
        Public Property Month() As Months
            Get
                Return _month
            End Get
            Set(ByVal value As Months)
                _month = value
                Select Case _month
                    Case 1
                        myMonthButton.Text = "January"
                    Case 2
                        myMonthButton.Text = "February"
                    Case 3
                        myMonthButton.Text = "March"
                    Case 4
                        myMonthButton.Text = "April"
                    Case 5
                        myMonthButton.Text = "May"
                    Case 6
                        myMonthButton.Text = "June"
                    Case 7
                        myMonthButton.Text = "July"
                    Case 8
                        myMonthButton.Text = "August"
                    Case 9
                        myMonthButton.Text = "September"
                    Case 10
                        myMonthButton.Text = "October"
                    Case 11
                        myMonthButton.Text = "November"
                    Case 12
                        myMonthButton.Text = "December"
                End Select
                ShowDays()
            End Set
        End Property
        ''' <summary>
        ''' Amount of padding to put between buttons in calendar
        ''' </summary>
        Public Property ButtonPadding() As Integer
            Get
                Return _padding
            End Get
            Set(ByVal value As Integer)
                If value >= 0 Then
                    _padding = value
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Set
        End Property
        ''' <summary>
        ''' Currently selected date
        ''' </summary>
        Public Property SelectedDate() As DateTime
            Get
                Return _selectedDate
            End Get
            Set(ByVal value As DateTime)
                _selectedDate = value
                Year = _selectedDate.Year
                Month = _selectedDate.Month
            End Set
        End Property
#End Region

#Region " Event Handlers "
        Private Sub YearUp()
            If _year < 9999 Then
                Year += 1
            End If
        End Sub
        Private Sub YearDown()
            If _year > 1 Then
                Year -= 1
            End If
        End Sub
        Private Sub MonthUp()
            If _month < 12 Then
                Month += 1
            Else
                YearUp()
                Month = 1
            End If
        End Sub
        Private Sub MonthDown()
            If _month > 1 Then
                Month -= 1
            Else
                YearDown()
                Month = 12
            End If
        End Sub
        Private Sub Day_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            For Each mybutton As FlatButton In myDays.Controls
                mybutton.RedAlert = LCARSalert.Normal
            Next
            CType(sender, LCFlatButton).RedAlert = LCARSalert.White
            _selectedDate = CType(CType(sender, LCFlatButton).Data, DateTime)
            RaiseEvent SelectedDateChanged(SelectedDate)
        End Sub
#End Region

        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height - _padding) / 9 - _padding)
            'Year buttons
            With myYearLeft
                .Bounds = New Rectangle(0, 0, standardSize.Width, standardSize.Height)
                .ArrowDirection = LCARSarrowDirection.Left
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myYearLeft.Click, AddressOf YearDown
            buttonContainer.Add(myYearLeft)
            With myYearRight
                .Bounds = New Rectangle(Me.Size.Width - standardSize.Width, 0, standardSize.Width, standardSize.Height)
                .ArrowDirection = LCARSarrowDirection.Right
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myYearRight.Click, AddressOf YearUp
            buttonContainer.Add(myYearRight)
            With myYearButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = 0
                .Left = standardSize.Width + _padding
                .Clickable = False
                .TextAlign = ContentAlignment.MiddleCenter
                .Text = _year
            End With
            buttonContainer.Add(myYearButton)
            'Month buttons
            With myMonthLeft
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Top = standardSize.Height + _padding
                .Left = 0
                .ArrowDirection = LCARSarrowDirection.Left
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myMonthLeft.Click, AddressOf MonthDown
            buttonContainer.Add(myMonthLeft)
            With myMonthRight
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Top = standardSize.Height + _padding
                .Left = Me.Size.Width - standardSize.Width
                .ArrowDirection = LCARSarrowDirection.Right
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myMonthRight.Click, AddressOf MonthUp
            buttonContainer.Add(myMonthRight)
            With myMonthButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = standardSize.Height + _padding
                .Left = standardSize.Width + _padding
                .Clickable = False
                .TextAlign = ContentAlignment.MiddleCenter
                Select Case _month
                    Case 1
                        .Text = "January"
                    Case 2
                        .Text = "February"
                    Case 3
                        .Text = "March"
                    Case 4
                        .Text = "April"
                    Case 5
                        .Text = "May"
                    Case 6
                        .Text = "June"
                    Case 7
                        .Text = "July"
                    Case 8
                        .Text = "August"
                    Case 9
                        .Text = "September"
                    Case 10
                        .Text = "October"
                    Case 11
                        .Text = "November"
                    Case 12
                        .Text = "December"
                End Select
            End With
            buttonContainer.Add(myMonthButton)
            'Day of Week buttons
            With mySunday
                .Top = (standardSize.Height + _padding) * 2
                .Left = 0
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Sunday"
                .Clickable = False
            End With
            buttonContainer.Add(mySunday)
            With myMonday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 1
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Monday"
                .Clickable = False
            End With
            buttonContainer.Add(myMonday)
            With myTuesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 2
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Tuesday"
                .Clickable = False
            End With
            buttonContainer.Add(myTuesday)
            With myWednesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 3
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Wednesday"
                .Clickable = False
            End With
            buttonContainer.Add(myWednesday)
            With myThursday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 4
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Thursday"
                .Clickable = False
            End With
            buttonContainer.Add(myThursday)
            With myFriday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 5
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Friday"
                .Clickable = False
            End With
            buttonContainer.Add(myFriday)
            With mySaturday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 6
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .Text = "Saturday"
                .Clickable = False
            End With
            buttonContainer.Add(mySaturday)
            With buttonContainer
                .Size = Me.Size
                .Location = New Point(0, 0)
            End With
            Me.Controls.Add(buttonContainer)
            'Panel to hold all the individual date buttons
            With myDays
                .Top = (standardSize.Height + _padding) * 3
                .Left = 0
                .Width = Me.Size.Width
                .Height = Me.Size.Height - .Top
            End With
            ShowDays()
            Me.Controls.Add(myDays)
            myDays.BringToFront()
        End Sub
        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.BackColor = Color.Black
            Me.Size = New Size(250, 250)
            Me.ResumeLayout()
        End Sub
        Private Sub ShowDays()
            myDays.Clear()
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height + _padding) / 9 - _padding)
            Dim i As Integer
            Dim j As Integer
            Dim x As Integer = 1
            For i = 0 To 5
                For j = 0 To 6
                    Dim mybutton As New LCFlatButton
                    Dim myDate As DateTime
                    Try
                        myDate = New DateTime(Year, Month, x)
                        If myDate.DayOfWeek = j Then
                            With mybutton
                                .Height = standardSize.Height
                                .Width = standardSize.Width
                                .Top = i * (standardSize.Height + _padding)
                                .Left = (j) * (standardSize.Width + _padding)
                                .TextAlign = ContentAlignment.MiddleCenter
                                .Text = x
                                .Data = myDate
                                If .Data = New Date(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day) Then
                                    .RedAlert = LCARSalert.White
                                End If
                            End With
                            AddHandler mybutton.Click, AddressOf Day_Click
                            myDays.Add(mybutton)
                            x += 1
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Next
        End Sub
        Private Sub Calender_Resize() Handles Me.Resize
            With buttonContainer
                .Width = Me.Width
                .Height = Me.Height
            End With
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height - _padding) / 9 - _padding)
            'Year buttons
            With myYearLeft
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Top = 0
                .Left = 0
            End With
            With myYearRight
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Top = 0
                .Left = Me.Size.Width - standardSize.Width
            End With
            With myYearButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = 0
                .Left = standardSize.Width + _padding
            End With
            'Month buttons
            With myMonthLeft
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Top = standardSize.Height + _padding
                .Left = 0
            End With
            With myMonthRight
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Top = standardSize.Height + _padding
                .Left = Me.Size.Width - standardSize.Width
            End With
            With myMonthButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = standardSize.Height + _padding
                .Left = standardSize.Width + _padding
            End With
            'Day of Week buttons
            With mySunday
                .Top = (standardSize.Height + _padding) * 2
                .Left = 0
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            With myMonday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 1
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            With myTuesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 2
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            With myWednesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 3
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            With myThursday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 4
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            With myFriday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 5
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            With mySaturday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 6
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            'Panel to hold all the individual date buttons
            With myDays
                .Top = (standardSize.Height + _padding) * 3
                .Left = 0
                .Width = Me.Size.Width
                .Height = Me.Size.Height - .Top
            End With
            ShowDays()
        End Sub
    End Class
End Namespace