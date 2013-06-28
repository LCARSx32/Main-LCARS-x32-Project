''' <summary>
''' Contains methods for handling and converting stardates
''' </summary>
''' <remarks>Previously in StardateLibrary.dll. Moved here for simplicity. Generally only the static methods are used.</remarks>
Public Class Stardate
    Dim mydate As Date
    Dim mystardate As Double
    Dim base As Integer = 2323
    ''' <summary>
    ''' Create a new stardate object from a standard date
    ''' </summary>
    ''' <param name="newdate">Standard date</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal newdate As Date)
        mydate = newdate
        mystardate = getStardate(newdate)
    End Sub
    ''' <summary>
    ''' Create a new stardate object from a decimal stardate
    ''' </summary>
    ''' <param name="newstardate">Decimal representation of a stardate.</param>
    ''' <remarks>There's no validation for this, but for current dates it will be negative.</remarks>
    Public Sub New(ByVal newstardate As Double)
        mystardate = newstardate
        mydate = getEarthDate(Me)
    End Sub
    ''' <summary>
    ''' Returns the stardate as a string with two decimal places
    ''' </summary>
    ''' <returns>Approximate string representation of stardate</returns>
    ''' <remarks>Saves you some work, and gives you the date as it would normally be spoken.</remarks>
    Public Overrides Function ToString() As String
        Return Stardate.ToString("F2")
    End Function
    ''' <summary>
    ''' Returns a stardate from the given standard date, using the supplied datebase
    ''' </summary>
    ''' <param name="convertdate">Date to convert</param>
    ''' <param name="datebase">Year to base stardate on. Generally 2323 is used.</param>
    ''' <returns>Decimal representation of stardate.</returns>
    ''' <remarks>One of the two functions you are likely to use.</remarks>
    Shared Function getStardate(ByVal convertdate As Date, Optional ByVal datebase As Integer = 2323) As Double
        Dim x As Integer
        If Date.IsLeapYear(convertdate.Year) Then
            x = 366
        Else
            x = 365
        End If
        Dim earthdatetime As Double = convertdate.Year + 1 / x * (convertdate.DayOfYear - 1 + convertdate.Hour / 24 + convertdate.Minute / 1440 + convertdate.Second / 86400)
        Return 1000 * (earthdatetime - datebase)
    End Function
    ''' <summary>
    ''' Returns a standard date from the given stardate, using the supplied datebase
    ''' </summary>
    ''' <param name="convertdate">Stardate to be converted.</param>
    ''' <param name="datebase">Datebase used for stardate.</param>
    ''' <returns>Standard date equivalent of the stardate</returns>
    ''' <remarks> If you used something other than 2323, set the datebase!</remarks>
    Overloads Shared Function getEarthDate(ByVal convertdate As Stardate, Optional ByVal datebase As Integer = 2323) As Date
        Dim earthdatetime As Double = convertdate.Stardate / 1000 + datebase
        Dim myyear As Integer = Math.Floor(earthdatetime)
        Dim x As Integer = 365
        If Date.IsLeapYear(myyear) Then
            x = 366
        End If
        earthdatetime = (earthdatetime - myyear) * x
        Dim myday As Integer = Math.Floor(earthdatetime)
        earthdatetime = (earthdatetime - myday) * 24
        Dim myhour As Integer = Math.Floor(earthdatetime)
        earthdatetime = (earthdatetime - myhour) * 60
        Dim myminute As Integer = Math.Floor(earthdatetime)
        earthdatetime = (earthdatetime - myminute) * 60
        Dim mysecond As Integer = Math.Floor(earthdatetime)
        Dim month As Integer = 1
        If (myday - 31 > 0) Then
            myday -= 31
            month += 1
            If (myday - (28 + x - 365) > 0) Then
                myday -= (28 + x - 365)
                month += 1
                If (myday - 31 > 0) Then
                    myday -= 31
                    month += 1
                    If (myday - 30 > 0) Then
                        myday -= 30
                        month += 1
                        If (myday - 31 > 0) Then
                            myday -= 30
                            month += 1
                            If (myday - 30 > 0) Then
                                myday -= 30
                                month += 1
                                If (myday - 31 > 0) Then
                                    myday -= 30
                                    month += 1
                                    If (myday - 31 > 0) Then
                                        myday -= 30
                                        month += 1
                                        If (myday - 30 > 0) Then
                                            myday -= 30
                                            month += 1
                                            If (myday - 31 > 0) Then
                                                myday -= 30
                                                month += 1
                                                If (myday - 30 > 0) Then
                                                    myday -= 30
                                                    month += 1
                                                    If (myday - 31 > 0) Then
                                                        myday -= 30
                                                        month += 1
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Dim mynewdate As Date = New Date(myyear, month, myday, myhour, myminute, mysecond)
        Return mynewdate
    End Function
    ''' <summary>
    ''' Returns a standard date from the given stardate, using the supplied datebase
    ''' </summary>
    ''' <param name="convertdate">Decimal representation of the stardate</param>
    ''' <param name="datebase">Datebase used for stardate.</param>
    ''' <returns>Standard date equivalent of the stardate</returns>
    ''' <remarks>Stub to call overloaded function. No savings to use one or the other.</remarks>
    Overloads Shared Function getEarthDate(ByVal convertdate As Double, Optional ByVal datebase As Integer = 2323) As Date
        getearthdate(New Stardate(convertdate), datebase)
    End Function
    ''' <summary>
    ''' Returns the stardate stored by this object as a decimal
    ''' </summary>
    ''' <value>Decimal representation of stardate.</value>
    ''' <returns>Decimal representation of stardate.</returns>
    ''' <remarks></remarks>
    Public Property Stardate() As Double
        Get
            Return mystardate
        End Get
        Set(ByVal value As Double)
            mystardate = value
            mydate = getEarthDate(Me)
        End Set
    End Property
    ''' <summary>
    ''' Returns the date stored by this object as a date
    ''' </summary>
    ''' <value>Standard date</value>
    ''' <returns>Standard date</returns>
    ''' <remarks></remarks>
    Public Property EarthDate() As Date
        Get
            Return mydate
        End Get
        Set(ByVal value As Date)
            mydate = value
            mystardate = getStardate(value)
        End Set
    End Property
    ''' <summary>
    ''' Determines if the two stardates are equal
    ''' </summary>
    ''' <param name="obj">Stardate to be compared</param>
    ''' <returns>True if both are stardates and are equal</returns>
    ''' <remarks></remarks>
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj.GetType.Equals(Me.GetType()) Then
            If Me.Stardate = CType(obj, Stardate).Stardate Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
