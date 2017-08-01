Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports LCARS.LightweightControls

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
        Protected myList As New List(Of ILightweightControl)
        Dim oldMouseMoveControl As ILightweightControl
        Dim oldMouseDownPoint As Point
        Dim oldMouseDownControl As ILightweightControl
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
        Public Sub Add(ByVal item As ILightweightControl)
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
        Private Sub drawButton(ByVal sender As ILightweightControl)
            Try
                Dim g As Graphics = Me.CreateGraphics()
                g.DrawImage(sender.GetBitmap(), New Point(sender.Bounds.Left, sender.Bounds.Top))
                g.Dispose()
            Catch ex As InvalidOperationException
                'The control tried to update itself from a timer at the same time.
            End Try
        End Sub
        ''' <summary>
        ''' Finds the topmost visible control whose bounds contain the given point if existant
        ''' </summary>
        ''' <param name="pt">Point to search for</param>
        ''' <returns>Control found or Nothing</returns>
        Public Function ControlFromPoint(ByVal pt As Point) As ILightweightControl
            For i As Integer = myList.Count - 1 To 0 Step -1
                If Not myList(i).HoldDraw AndAlso myList(i).Bounds.Contains(pt) Then
                    Return myList(i)
                End If
            Next
            Return Nothing
        End Function
        ''' <summary>
        ''' Clears all current controls from the control
        ''' </summary>
        Public Sub Clear()
            oldMouseDownControl = Nothing
            oldMouseMoveControl = Nothing
            For Each mybutton As ILightweightControl In myList
                RemoveHandler mybutton.Update, AddressOf drawButton
            Next
            myList.Clear()
            Me.CreateGraphics().Clear(Color.Black)
        End Sub
        'Passes MouseDown events to the child controls
        Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
            oldMouseDownPoint = e.Location
            oldMouseDownControl = ControlFromPoint(e.Location)
            If oldMouseDownControl IsNot Nothing Then
                oldMouseDownControl.doEvent(ILightweightControl.LightweightEvents.MouseDown)
            End If
        End Sub
        'Passes MouseUp and click events to the child controls if applicable
        Private Sub Me_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
            Dim localPoint As Point = e.Location
            'Cache this value against the click event destroying the control
            Dim ctrl As ILightweightControl = oldMouseDownControl
            If ctrl IsNot Nothing Then
                If localPoint = oldMouseDownPoint Then
                    ctrl.doClick()
                End If
                ctrl.doEvent(ILightweightControl.LightweightEvents.MouseUp)
            End If
        End Sub
        'Passes MouseOver events to the child controls as MouseMove, MouseEnter, and MouseLeave events
        Private Sub Me_MouseOver(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
            Dim newMove As ILightweightControl = ControlFromPoint(e.Location)
            If oldMouseMoveControl IsNot newMove Then
                If oldMouseMoveControl IsNot Nothing Then
                    oldMouseMoveControl.doEvent(ILightweightControl.LightweightEvents.MouseLeave)
                End If
                If newMove IsNot Nothing Then
                    newMove.doEvent(ILightweightControl.LightweightEvents.MouseEnter)
                End If
                oldMouseMoveControl = newMove
            ElseIf oldMouseMoveControl IsNot Nothing Then
                oldMouseMoveControl.doEvent(ILightweightControl.LightweightEvents.MouseMove)
            End If
        End Sub

        Private Sub Me_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
            If oldMouseMoveControl IsNot Nothing Then
                oldMouseMoveControl.doEvent(ILightweightControl.LightweightEvents.MouseLeave)
            End If
        End Sub

        'Passes DoubleClick events to the child controls
        Private Sub Me_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
            Dim localPoint As Point = PointToClient(Cursor.Position)
            Dim ctrl As ILightweightControl = ControlFromPoint(localPoint)
            If ctrl IsNot Nothing Then
                ctrl.doEvent(ILightweightControl.LightweightEvents.DoubleClick)
            End If
        End Sub

        'Updates colors of child controls
        Private Sub ReloadColors() Handles _colorsAvailable.ColorsUpdated
            Dim temp As IColorable
            For Each mycontrol As ILightweightControl In myList
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
        Default Public Property Items(ByVal index As Integer) As ILightweightControl
            Get
                Return myList(index)
            End Get
            Set(ByVal value As ILightweightControl)
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
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
        <DefaultValue(False)> _
        Public Property Beeping() As Boolean Implements IBeeping.Beeping
            Get
                Return _beeping
            End Get
            Set(ByVal value As Boolean)
                _beeping = value
                Dim temp As IBeeping
                For Each mycontrol As ILightweightControl In myList
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
