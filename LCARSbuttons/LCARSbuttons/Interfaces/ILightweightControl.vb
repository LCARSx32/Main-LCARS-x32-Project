Imports System.Drawing
Namespace LightweightControls

    ''' <summary>
    ''' Defines the interface for a lightweight control.
    ''' </summary>
    ''' <remarks>
    ''' <p>This is the bare minimum required for a lightweight control to function.</p>
    ''' <p>For an example implementation, see the <see cref="LightweightControls.LCStandardButton">LCStandardButton</see>.</p>
    ''' </remarks>
    Public Interface ILightweightControl
        ''' <summary>
        ''' Describes events that can be raised by a lightweight control
        ''' </summary>
        Enum LightweightEvents
            Click = 0
            MouseDown = 1
            MouseUp = 2
            MouseEnter = 3
            MouseLeave = 4
            Update = 5
            DoubleClick = 6
            MouseMove = 7
        End Enum

        ''' <summary>
        ''' Returns the bitmap drawn to memory.
        ''' </summary>
        ''' <returns>An image with the control's interface.</returns>
        ''' <remarks>
        ''' A poorly-designed implementation of this interface may throw an exception if the bitmap has not already been drawn.
        ''' </remarks>
        Function GetBitmap() As Bitmap
        ''' <summary>
        ''' Redraws the control.
        ''' </summary>
        ''' <remarks>
        ''' <p>The implementation of this sub should raise the <see cref="Update">Update</see> event after completion.</p>
        ''' <p>If the control is multithreaded, ensure that there is some method of synchronizing access to the bitmap.
        ''' Otherwise, a race condition will result, and the control could throw GDI+ exceptions.</p>
        ''' </remarks>
        Sub Redraw()
        ''' <summary>
        ''' Raises the click event for a control.
        ''' </summary>
        ''' <remarks>This is a shortcut method of using doEvent to raise a click event, and is slightly faster.</remarks>
        Sub doClick()
        ''' <summary>
        ''' Raises an event on the control
        ''' </summary>
        ''' <param name="eventName">The name of the event to raise</param>
        ''' <remarks>
        ''' This just sends events to the lightweight control, where they are then raised to be handled by other code. A control does
        ''' not necessarily have to act on all events received, but it must be able to receive them.
        ''' </remarks>
        Sub doEvent(ByVal eventName As LightweightEvents)
        '''<summary>
        ''' Sets the lightweight control's parent.
        ''' </summary>
        ''' <remarks>
        ''' If the control is multithreaded, and must update its interface from a separate thread, the reference passed
        ''' by this sub will permit it to marshal those calls into the user-interface thread. Lightweight controls that 
        ''' do not need this capability can implement this as an empty sub. All container controls should call this immediately upon
        ''' adding a lightweight control.
        ''' </remarks>
        Sub SetParent(ByVal NewParent As System.Windows.Forms.Control)
        ''' <summary>
        ''' The bounds of the control
        ''' </summary>
        ''' <value>The current bounds of the control</value>
        ''' <returns>The new bounds of the control</returns>
        ''' <remarks>
        ''' These bounds are in pixels for a parent control's client area.
        ''' </remarks>
        Property Bounds() As Rectangle
        ''' <summary>
        ''' The width of the control.
        ''' </summary>
        ''' <value>The current width of the control</value>
        ''' <returns>The new width for the control</returns>
        ''' <remarks>
        ''' This should be an alias for Bounds.Width, and is included to make handling lightweight controls more similar to standard
        ''' controls.
        ''' </remarks>
        Property Width() As Integer
        ''' <summary>
        ''' The height of the control.
        ''' </summary>
        ''' <value>The new height for the control</value>
        ''' <returns>The current height of the control</returns>
        ''' <remarks>
        ''' This should be an alias for Bounds.Height, and is included to make handling lightweight controls more similar to standard
        ''' controls.
        ''' </remarks>
        Property Height() As Integer
        ''' <summary>
        ''' Prevents the control from redrawing if set to true
        ''' </summary>
        ''' <value>New HoldDraw value</value>
        ''' <returns>Current HoldDraw value</returns>
        ''' <remarks>
        ''' This property should intercept all redraw and other update commands until it is set to false. This is to permit the setting
        ''' of multiple properties in quick succession without redrawing each time. Parent controls should use this to maximum
        ''' effect with hidden controls.
        ''' </remarks>
        Property HoldDraw() As Boolean
        ''' <summary>
        ''' The left coordinate of the control's bounds
        ''' </summary>
        ''' <value>New left coordinate</value>
        ''' <returns>Current left coordinate</returns>
        ''' <remarks>This is a shortcut access to Bounds.Left</remarks>
        Property Left() As Integer
        ''' <summary>
        ''' Top coordinate of control's bounds
        ''' </summary>
        ''' <value>New top coordinate</value>
        ''' <returns>Current top coordinate</returns>
        ''' <remarks>This is a shortcut access to Bounds.Top</remarks>
        Property Top() As Integer
        ''' <summary>
        ''' The text of the control
        ''' </summary>
        ''' <value>New text for the control</value>
        ''' <returns>Current text of the control</returns>
        ''' <remarks>
        ''' This property must be implemented, but can otherwise be ignored if so desired.
        ''' </remarks>
        Property Text() As String
        ''' <summary>
        ''' Fired when the button has been drawn to memory
        ''' </summary>
        ''' <remarks>
        ''' This event is raised whenever a control needs to be redrawn. The implementation of this interface is responsible for 
        ''' raising it after redrawing due to property changes.
        ''' </remarks>
        Event Update(ByVal sender As ILightweightControl)
    End Interface
End Namespace
