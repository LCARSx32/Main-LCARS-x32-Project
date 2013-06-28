Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls
    <System.ComponentModel.DefaultEvent("SelectedDateChanged")> _
    Public Class LCARSCalender
        Inherits Windows.Forms.Control
        Public Event SelectedDateChanged(ByVal SelectedDate As DateTime)
        'Global Variables
        Dim _year As Integer = 2000
        Dim _month As Integer = 1
        Dim _selectedDate As DateTime
        Dim _padding As Integer = 5
        'Permanent Controls
        Dim myYearButton As New FlatButton
        Dim myYearRight As New ArrowButton
        Dim myYearLeft As New ArrowButton
        Dim myMonthButton As New FlatButton
        Dim myMonthRight As New ArrowButton
        Dim myMonthLeft As New ArrowButton
        Dim myDays As New Panel
        Dim mySunday As New FlatButton
        Dim myMonday As New FlatButton
        Dim myTuesday As New FlatButton
        Dim myWednesday As New FlatButton
        Dim myThursday As New FlatButton
        Dim myFriday As New FlatButton
        Dim mySaturday As New FlatButton

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
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                If value < 10000 And value > 0 Then
                    _year = value
                    myYearButton.ButtonText = _year
                    ShowDays()
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Set
        End Property
        Public Property Month() As Months
            Get
                Return _month
            End Get
            Set(ByVal value As Months)
                _month = value
                Select Case _month
                    Case 1
                        myMonthButton.ButtonText = "January"
                    Case 2
                        myMonthButton.ButtonText = "February"
                    Case 3
                        myMonthButton.ButtonText = "March"
                    Case 4
                        myMonthButton.ButtonText = "April"
                    Case 5
                        myMonthButton.ButtonText = "May"
                    Case 6
                        myMonthButton.ButtonText = "June"
                    Case 7
                        myMonthButton.ButtonText = "July"
                    Case 8
                        myMonthButton.ButtonText = "August"
                    Case 9
                        myMonthButton.ButtonText = "September"
                    Case 10
                        myMonthButton.ButtonText = "October"
                    Case 11
                        myMonthButton.ButtonText = "November"
                    Case 12
                        myMonthButton.ButtonText = "December"
                End Select
                ShowDays()
            End Set
        End Property
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
        Public Property SelectedDate() As DateTime
            Get
                Return _selectedDate
            End Get
            Set(ByVal value As DateTime)
                _selectedDate = value
                Year = _selectedDate.Year
                Month = _selectedDate.Month
                'ShowDays()
            End Set
        End Property
#End Region

#Region " Event Handlers "
        Public Sub YearUp()
            If _year < 9999 Then
                Year += 1
            End If
        End Sub
        Public Sub YearDown()
            If _year > 1 Then
                Year -= 1
            End If
        End Sub
        Public Sub MonthUp()
            If _month < 12 Then
                Month += 1
            Else
                YearUp()
                Month = 1
            End If
        End Sub
        Public Sub MonthDown()
            If _month > 1 Then
                Month -= 1
            Else
                YearDown()
                Month = 12
            End If
        End Sub
        Public Sub Day_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            For Each mybutton As FlatButton In myDays.Controls
                mybutton.RedAlert = LCARSalert.Normal
            Next
            CType(sender, FlatButton).RedAlert = LCARSalert.White
            _selectedDate = CType(CType(sender, FlatButton).Data, DateTime)
            RaiseEvent SelectedDateChanged(SelectedDate)
        End Sub
#End Region

        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height - _padding) / 9 - _padding)
            'Year buttons
            With myYearLeft
                .Size = standardSize
                .Top = 0
                .Left = 0
                .ArrowDirection = LCARSarrowDirection.Left
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myYearLeft.Click, AddressOf YearDown
            Me.Controls.Add(myYearLeft)
            With myYearRight
                .Size = standardSize
                .Top = 0
                .Left = Me.Size.Width - standardSize.Width
                .ArrowDirection = LCARSarrowDirection.Right
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myYearRight.Click, AddressOf YearUp
            Me.Controls.Add(myYearRight)
            With myYearButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = 0
                .Left = standardSize.Width + _padding
                .Clickable = False
                .ButtonTextAlign = ContentAlignment.MiddleCenter
                .ButtonText = _year
            End With
            Me.Controls.Add(myYearButton)
            'Month buttons
            With myMonthLeft
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = 0
                .ArrowDirection = LCARSarrowDirection.Left
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myMonthLeft.Click, AddressOf MonthDown
            Me.Controls.Add(myMonthLeft)
            With myMonthRight
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = Me.Size.Width - standardSize.Width
                .ArrowDirection = LCARSarrowDirection.Right
                .Color = LCARScolorStyles.MiscFunction
            End With
            AddHandler myMonthRight.Click, AddressOf MonthUp
            Me.Controls.Add(myMonthRight)
            With myMonthButton
                .Height = standardSize.Height
                .Width = Me.Size.Width - 2 * (standardSize.Width + _padding)
                .Top = standardSize.Height + _padding
                .Left = standardSize.Width + _padding
                .Clickable = False
                .ButtonTextAlign = ContentAlignment.MiddleCenter
                Select Case _month
                    Case 1
                        .ButtonText = "January"
                    Case 2
                        .ButtonText = "February"
                    Case 3
                        .ButtonText = "March"
                    Case 4
                        .ButtonText = "April"
                    Case 5
                        .ButtonText = "May"
                    Case 6
                        .ButtonText = "June"
                    Case 7
                        .ButtonText = "July"
                    Case 8
                        .ButtonText = "August"
                    Case 9
                        .ButtonText = "September"
                    Case 10
                        .ButtonText = "October"
                    Case 11
                        .ButtonText = "November"
                    Case 12
                        .ButtonText = "December"
                End Select
            End With
            Me.Controls.Add(myMonthButton)
            'Day of Week buttons
            With mySunday
                .Top = (standardSize.Height + _padding) * 2
                .Left = 0
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Sunday"
                .Clickable = False
            End With
            Me.Controls.Add(mySunday)
            With myMonday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 1
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Monday"
                .Clickable = False
            End With
            Me.Controls.Add(myMonday)
            With myTuesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 2
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Tuesday"
                .Clickable = False
            End With
            Me.Controls.Add(myTuesday)
            With myWednesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 3
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Wednesday"
                .Clickable = False
            End With
            Me.Controls.Add(myWednesday)
            With myThursday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 4
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Thursday"
                .Clickable = False
            End With
            Me.Controls.Add(myThursday)
            With myFriday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 5
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Friday"
                .Clickable = False
            End With
            Me.Controls.Add(myFriday)
            With mySaturday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 6
                .Height = standardSize.Height
                .Width = standardSize.Width
                .Color = LCARScolorStyles.CriticalFunction
                .ButtonText = "Saturday"
                .Clickable = False
            End With
            Me.Controls.Add(mySaturday)
            'Panel to hold all the individual date buttons
            With myDays
                .Top = (standardSize.Height + _padding) * 3
                .Left = 0
                .Width = Me.Size.Width
                .Height = Me.Size.Height - .Top
            End With
            ShowDays()
            Me.Controls.Add(myDays)
        End Sub
        Public Sub InitializeComponent()
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()
            Me.SuspendLayout()
            Me.BackColor = Color.Black
            Me.Size = New Size(250, 250)
            Me.ResumeLayout()
        End Sub
        Public Sub ShowDays()
            myDays.Controls.Clear()
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height + _padding) / 9 - _padding)
            Dim i As Integer
            Dim j As Integer
            Dim x As Integer = 1
            For i = 0 To 5
                For j = 0 To 6
                    Dim mybutton As New FlatButton
                    Dim myDate As DateTime
                    Try
                        myDate = New DateTime(Year, Month, x)
                        If myDate.DayOfWeek = j Then
                            With mybutton
                                .Size = standardSize
                                .Top = i * (standardSize.Height + _padding)
                                .Left = (j) * (standardSize.Width + _padding)
                                .ButtonTextAlign = ContentAlignment.MiddleCenter
                                .ButtonText = x
                                .Data = myDate
                                If .Data = New Date(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day) Then
                                    .RedAlert = LCARSalert.White
                                End If
                            End With
                            AddHandler mybutton.Click, AddressOf Day_Click
                            myDays.Controls.Add(mybutton)
                            x += 1
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Next
        End Sub
        Public Sub Calender_Resize() Handles Me.Resize
            Dim standardSize As New Size((Me.Size.Width + _padding) / 7 - _padding, (Me.Size.Height - _padding) / 9 - _padding)
            'Year buttons
            With myYearLeft
                .Size = standardSize
                .Top = 0
                .Left = 0
            End With
            With myYearRight
                .Size = standardSize
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
                .Size = standardSize
                .Top = standardSize.Height + _padding
                .Left = 0
            End With
            With myMonthRight
                .Size = standardSize
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
            Me.Controls.Add(mySunday)
            With myMonday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 1
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myMonday)
            With myTuesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 2
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myTuesday)
            With myWednesday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 3
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myWednesday)
            With myThursday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 4
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myThursday)
            With myFriday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 5
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(myFriday)
            With mySaturday
                .Top = (standardSize.Height + _padding) * 2
                .Left = (standardSize.Width + _padding) * 6
                .Height = standardSize.Height
                .Width = standardSize.Width
            End With
            Me.Controls.Add(mySaturday)
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