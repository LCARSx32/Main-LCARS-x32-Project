Imports System.Windows.Forms
Imports System.Drawing

Namespace Controls
    ''' <summary>
    ''' Aligns a set of lightweight controls to a grid, and passes events to them.
    ''' </summary>
    ''' <remarks>
    ''' The ButtonGrid control is designed to allow the display of large quantities of data without using a separate control for
    ''' each button. The upper limit for using windowed controls is about 500 before the program runs out of handles, but with 
    ''' windowless controls, the upper limit is defined by the computer's memory capacity. For obvious reasons, don't try to add
    ''' more controls than the maximum value of an integer.
    ''' <br />
    ''' Controls are stored internally in a list(of T) object initialized to store controls as an ILightweightControl interface.
    ''' This provides bare-minimum access to the control for redrawing and passing of events. In a future version, a generic ButtonGrid
    ''' may be provided to allow for more specific typing, but such a control would not be able to be added to a form in the designer.
    ''' </remarks>
    Public Class ButtonGrid
        Inherits LCARS.Controls.WindowlessContainer
        ''' <summary>
        ''' Direction to add controls in.
        ''' </summary>
        Public Enum ControlDirection
            ''' <summary>
            ''' Add controls vertically in columns
            ''' </summary>
            Vertical = 0
            ''' <summary>
            ''' Add controls horizontally in rows.
            ''' </summary>
            Horizontal = 1
        End Enum

        Dim componentWidth As Integer = 150
        Dim componentHeight As Integer = 70
        Dim myScroll As LCARS.Controls.TrackBar
        Dim myPadding As Integer = 5
        Dim curPage As Integer = 0
        Dim pageSize As Integer = 1
        Dim _direction As ControlDirection = ControlDirection.Vertical
        Dim oldSize As Size

        ''' <summary>
        ''' Returns a new instance of the ButtonGrid control
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
            myScroll = New LCARS.Controls.TrackBar()
            Me.MinimumSize = New Size(50, 50)
            With myScroll
                .Width = Me.Width
                .Height = 30
                .Left = 0
                .Top = Me.Height - .Height
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            End With
            AddHandler myScroll.Scroll, AddressOf myScroll_Scroll
            Me.Controls.Add(myScroll)
        End Sub
        Private Sub Me_ControlAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LightweightControlAdded
            RearrangeButtons()
        End Sub
        Private Sub Me_Resize() Handles Me.Resize
            Me.Invalidate() 'Ensures that the control is repainted
        End Sub
        'Handles this control's paint event, and resizes controls to match.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            If Not oldSize = Me.Size Then 'Needed to rearrange everything
                'If the control is resized, this fires before the Resize event does.
                RearrangeButtons()
                oldSize = Me.Size
            End If
            MyBase.OnPaint(e)
        End Sub
        'Rearranges all buttons to align to the grid and redraws them. Does not trigger a paint event.
        Private Sub RearrangeButtons()
            If myList.Count > 0 Then
                Dim columnNumber As Integer = Me.Width \ (componentWidth + myPadding)
                If columnNumber = 0 Then
                    columnNumber = 1
                End If
                Dim mywidth As Integer = CInt(Me.Width / columnNumber - myPadding)
                Dim rowNumber As Integer = (Me.Height - myScroll.Height) \ (componentHeight + myPadding)
                If rowNumber = 0 Then
                    rowNumber = 1
                End If
                'Dim myheight As Integer = (Me.Height - myScroll.Height) / (rowNumber + myPadding)
                pageSize = columnNumber * rowNumber
                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim i As Integer = 0
                Dim newBounds As System.Drawing.Rectangle
                Dim pages As Integer
                curPage = 0
                myScroll.CurrentPage = 0
                If _direction = ControlDirection.Vertical Then
                    Do While i < myList.Count
                        Do While y < rowNumber And i < myList.Count
                            newBounds = New Rectangle((x Mod columnNumber) * (mywidth + myPadding), y * (componentHeight + myPadding), mywidth, componentHeight)
                            If x > columnNumber - 1 Then
                                myList(i).HoldDraw = True
                            End If
                            myList(i).Bounds = newBounds
                            y += 1
                            i += 1
                        Loop
                        y = 0
                        x += 1
                    Loop
                    pages = x \ columnNumber
                    If x Mod columnNumber > 0 Then
                        pages += 1
                    End If
                Else
                    Do While i < myList.Count
                        Do While x < columnNumber And i < myList.Count
                            newBounds = New Rectangle((x) * (mywidth + myPadding), (y Mod rowNumber) * (componentHeight + myPadding), mywidth, componentHeight)
                            If y > rowNumber - 1 Then
                                myList(i).HoldDraw = True
                            End If
                            myList(i).Bounds = newBounds
                            x += 1
                            i += 1
                        Loop
                        x = 0
                        y += 1
                    Loop
                    pages = y \ rowNumber
                    If y Mod rowNumber > 0 Then
                        pages += 1
                    End If
                End If
                myScroll.Pages = pages
            End If
        End Sub
        'Handles the scroll events of the trackbar on this control
        Private Sub myScroll_Scroll(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.CreateGraphics().Clear(Me.BackColor)
            curPage = myScroll.CurrentPage
            For i As Integer = 0 To myList.Count - 1

                If i >= pageSize * (curPage) And i < pageSize * (curPage + 1) Then
                    myList(i).HoldDraw = False
                Else
                    myList(i).HoldDraw = True
                End If
            Next
        End Sub

#Region " Properties "
        ''' <summary>
        ''' Sets the display size of the controls
        ''' </summary>
        ''' <value>New size for the controls</value>
        ''' <returns>Current size of the controls</returns>
        ''' <remarks>
        ''' If this is made user-configurable, be sure to test for absurd values. The control drawing may fail
        ''' at very small sizes. Also, beware of text clipping.<br />
        ''' Important note: The width set here is a minimum. The controls will by dynamically sized to take up the full width of the
        ''' grid. The height, however, will be used directly.
        ''' </remarks>
        Public Property ControlSize() As Size
            Get
                Return New Size(componentWidth, componentHeight)
            End Get
            Set(ByVal value As Size)
                componentWidth = value.Width
                componentHeight = value.Height
                Me.MinimumSize = New Size(value.Width + myPadding, value.Height + myPadding)
                RearrangeButtons()
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' The amount of padding between controls.
        ''' </summary>
        ''' <value>New padding value</value>
        ''' <returns>Current padding value</returns>
        ''' <exception cref="IndexOutOfRangeException">
        ''' An IndexOutOfRangeException will be thrown if an attempt is made to access a control index that has not been assigned.
        ''' </exception>
        ''' <remarks>
        ''' This padding value is approximate, but should be exact except under very rare conditions. On occasion, the rounding used
        ''' to position controls may vary it by one pixel.<br />
        ''' Note that setting this to its current value will not trigger a redraw.
        ''' </remarks>
        Public Property ControlPadding() As Integer
            Get
                Return myPadding
            End Get
            Set(ByVal value As Integer)
                If Not value = myPadding Then
                    myPadding = value
                    RearrangeButtons()
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Direction to add controls in
        ''' </summary>
        ''' <value>New direction</value>
        ''' <returns>Old direction</returns>
        ''' <remarks>
        ''' This cannot be set for individual controls; all controls will be rearranged to follow the new direction.
        ''' <br />
        ''' Setting this property to its current value will not trigger a redraw.
        ''' </remarks>
        Public Property ControlAddingDirection() As ControlDirection
            Get
                Return _direction
            End Get
            Set(ByVal value As ControlDirection)
                If Not value = _direction Then
                    _direction = value
                    RearrangeButtons()
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Returns current page displayed
        ''' </summary>
        Public Property CurrentPage() As Integer
            Get
                Return myScroll.CurrentPage
            End Get
            Set(ByVal value As Integer)
                myScroll.CurrentPage = value
            End Set
        End Property

        ''' <summary>
        ''' Returns a count of pages that can be displayed
        ''' </summary>
        ''' <remarks>
        ''' The PageCount will always be at least one.
        ''' </remarks>
        Public ReadOnly Property PageCount() As Integer
            Get
                Return myScroll.Pages
            End Get
        End Property
#End Region
    End Class
End Namespace