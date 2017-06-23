Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls
    ''' <summary>
    ''' Draws windowless controls and passes events to them.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    <System.ComponentModel.Designer(GetType(WindowlessDesigner))> _
        Public Class WindowlessContainer
        Inherits System.Windows.Forms.Control
        Implements LCARS.IColorable, IBeeping

        'Global Variables
        Protected myList As New List(Of LightweightControls.ILightweightControl)
        Dim oldMouseMovePoint As Point
        Dim oldMouseDownPoint As Point
        Dim _beeping As Boolean = GetSetting("LCARS x32", "Application", "ButtonBeep", "TRUE")
        Dim WithEvents _colorsAvailable As New LCARS.LCARScolor
        'Events
        ''' <summary>
        ''' Raised when a windowless control has been added.
        ''' </summary>
        Public Event LightweightControlAdded As EventHandler

        ''' <summary>
        ''' Adds a lightweight control to the current instance
        ''' </summary>
        ''' <param name="item">The lightweight control to add</param>
        ''' <remarks>
        ''' The lightweight control's parent property will be set to the current instance for the 
        ''' purposes of easier multithreading.
        ''' </remarks>
        Public Sub Add(ByVal item As LightweightControls.ILightweightControl)
            item.SetParent(Me)
            myList.Add(item)
            AddHandler item.Update, AddressOf drawButton
            RaiseEvent LightweightControlAdded(Me, New EventArgs)
            Me.Invalidate()
        End Sub
        ''' <summary>
        ''' Paints the windowless container and all visible windowless controls
        ''' </summary>
        ''' <param name="e">Standard paint event args</param>
        ''' <remarks>
        ''' Controls with their <see cref="LightweightControls.ilightweightcontrol.HoldDraw">HoldDraw
        ''' </see> property set will not be drawn. Controls will be drawn in the order they were added,
        ''' resulting in the last-added control having the highest z-order.
        ''' </remarks>
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g As Graphics = Me.CreateGraphics()
            g.Clear(Color.Black)
            For i As Integer = 0 To myList.Count - 1
                If Not myList(i).HoldDraw Then g.DrawImage(myList(i).GetBitmap(), myList(i).Bounds)
            Next
        End Sub
        Private Sub drawButton(ByVal sender As LightweightControls.ILightweightControl)
            Try
                Dim g As Graphics = Me.CreateGraphics()
                g.DrawImage(sender.GetBitmap(), New Point(sender.Bounds.Left, sender.Bounds.Top))
                g.Dispose()
            Catch ex As InvalidOperationException
                'The control tried to update itself from a timer at the same time.
            End Try
        End Sub
        ''' <summary>
        ''' Clears all current controls from the control
        ''' </summary>
        Public Sub Clear()
            For Each mybutton As LCARS.LightweightControls.ILightweightControl In myList
                RemoveHandler mybutton.Update, AddressOf drawButton
            Next
            myList.Clear()
            Me.CreateGraphics().Clear(Color.Black)
        End Sub
        'Passes MouseDown events to the child controls
        Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseDown
            Dim localPoint As Point = PointToClient(Cursor.Position)
            oldMouseDownPoint = localPoint
            For i As Integer = myList.Count - 1 To 0 Step -1
                If myList(i).Bounds.Contains(localPoint) And myList(i).HoldDraw = False Then
                    myList(i).doEvent(LightweightControls.ILightweightControl.LightweightEvents.MouseDown)
                    Exit For
                End If
            Next
        End Sub
        'Passes MouseUp and click events to the child controls if applicable
        Private Sub Me_MouseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseUp
            Dim localPoint As Point = PointToClient(Cursor.Position)
            For i As Integer = myList.Count - 1 To 0 Step -1
                Dim button As LightweightControls.ILightweightControl = myList(i)
                If button.Bounds.Contains(localPoint) And myList(i).HoldDraw = False Then
                    'If the mouse is still where it was, do a click event too.
                    If localPoint = oldMouseDownPoint Then
                        button.doClick()
                    End If
                    button.doEvent(LightweightControls.ILightweightControl.LightweightEvents.MouseUp)
                    Exit For
                End If
            Next
        End Sub
        'Passes MouseOver events to the child controls as MouseMove, MouseEnter, and MouseLeave events
        Private Sub Me_MouseOver(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseMove
            Dim localPoint As Point = PointToClient(Cursor.Position)
            Dim foundTop As Boolean = False 'Top level control found
            For i As Integer = myList.Count - 1 To 0 Step -1
                If Not myList(i).HoldDraw Then
                    If myList(i).Bounds.Contains(localPoint) And Not foundTop Then
                        If myList(i).Bounds.Contains(oldMouseMovePoint) Then
                            myList(i).doEvent(LightweightControls.ILightweightControl.LightweightEvents.MouseMove)
                        Else
                            myList(i).doEvent(LightweightControls.ILightweightControl.LightweightEvents.MouseEnter)
                        End If
                        foundTop = True
                    Else
                        If myList(i).Bounds.Contains(oldMouseMovePoint) Then
                            myList(i).doEvent(LightweightControls.ILightweightControl.LightweightEvents.MouseLeave)
                        End If
                    End If
                End If
            Next
            oldMouseMovePoint = localPoint
        End Sub

        Private Sub Me_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
            For i As Integer = myList.Count - 1 To 0 Step -1
                If Not myList(i).HoldDraw Then
                    If myList(i).Bounds.Contains(oldMouseMovePoint) Then
                        myList(i).doEvent(LightweightControls.ILightweightControl.LightweightEvents.MouseLeave)
                    End If
                End If
            Next
            oldMouseMovePoint = Nothing
        End Sub

        'Passes DoubleClick events to the child controls
        Private Sub Me_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
            Dim localPoint As Point = PointToClient(Cursor.Position)
            For i As Integer = myList.Count - 1 To 0 Step -1
                If Not myList(i).HoldDraw And myList(i).Bounds.Contains(localPoint) Then
                    myList(i).doEvent(LightweightControls.ILightweightControl.LightweightEvents.DoubleClick)
                    Exit For
                End If
            Next
        End Sub

        'Updates colors of child controls
        Private Sub ReloadColors() Handles _colorsAvailable.ColorsUpdated
            Dim temp As IColorable
            For Each mycontrol As LightweightControls.ILightweightControl In myList
                temp = TryCast(mycontrol, IColorable)
                If Not temp Is Nothing Then
                    temp.ColorsAvailable.ReloadColors()
                End If
            Next
        End Sub

#Region " Properties "
        ''' <summary>
        ''' Gives access to the windowless controls already added to the control.
        ''' </summary>
        ''' <param name="index">Zero-based index of the control to access</param>
        ''' <value>The control to assign at that point</value>
        ''' <returns>The current control at that point</returns>
        ''' <remarks>
        ''' This will allow direct access as in:
        ''' <code>
        ''' myGrid(6).Text = "The quick brown fox jumped over the lazy dogs."
        ''' </code>
        ''' However, this property can also be used to replace a control at a given point. Under no circumstances should this be
        ''' used to delete a control.
        ''' </remarks>
        Default Public Property Items(ByVal index As Integer) As LightweightControls.ILightweightControl
            Get
                Return myList(index)
            End Get
            Set(ByVal value As LightweightControls.ILightweightControl)
                myList(index) = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Returns the number of windowless controls in this instance
        ''' </summary>
        Public ReadOnly Property Count() As Integer
            Get
                Return myList.Count
            End Get
        End Property


        ''' <summary>
        ''' Allows access to the LCARS color class used by this control
        ''' </summary>
        ''' <remarks>
        ''' Setting this property will cause all subcontrols to reload their colors
        ''' </remarks>
        Public Property ColorsAvailable() As LCARScolor Implements IColorable.ColorsAvailable
            Get
                Return _colorsAvailable
            End Get
            Set(ByVal value As LCARScolor)
                _colorsAvailable = value
                ReloadColors()
            End Set
        End Property

        ''' <summary>
        ''' Allows beeping to be set for all current windowless controls
        ''' </summary>
        Public Property Beeping() As Boolean Implements IBeeping.Beeping
            Get
                Return _beeping
            End Get
            Set(ByVal value As Boolean)
                _beeping = value
                Dim temp As IBeeping
                For Each mycontrol As LCARS.LightweightControls.ILightweightControl In myList
                    temp = TryCast(mycontrol, IBeeping)
                    If Not temp Is Nothing Then
                        temp.Beeping = value
                    End If
                Next
            End Set
        End Property
#End Region
    End Class

    ''' <summary>
    ''' Designer for <see cref="WindowlessContainer">Windowless Container</see>
    ''' </summary>
    Public Class WindowlessDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        ''' <summary>
        ''' Paints a cyan border around the control to make it more visible.
        ''' </summary>
        ''' <param name="pe">PaintEventArgs used for drawing</param>
        Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
            pe.Graphics.DrawRectangle(Pens.Cyan, 0, 0, Me.Control.Size.Width - 1, Me.Control.Size.Height - 1)

            MyBase.OnPaintAdornments(pe)
        End Sub
    End Class
End Namespace
