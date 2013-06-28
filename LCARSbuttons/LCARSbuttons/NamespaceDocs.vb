'Namespace LCARS
''' <summary>
''' Contains classes and components required for all LCARS programs
''' </summary>
''' <remarks>
''' This assembly is critical to the functioning of all LCARS programs that use it. It should not be edited by anyone
''' who does not know what they're doing. If in doubt, contact the current lead developer and ask about your modification.
''' Bad Things will happen if you make a mistake in editing it.
''' </remarks>
<System.Runtime.CompilerServices.CompilerGenerated()> _
Class NamespaceDoc
End Class
Namespace Controls
    ''' <summary>
    ''' Contains all fully functional controls that can be used.
    ''' </summary>
    ''' <remarks>
    ''' Most controls you use will be in this namespace. The Generic Button (LCARSButtonClass) is not in this namespace
    ''' because it is not intended to be used in the form designer, despite the fact it easily could be. All controls have
    ''' been well-tested, but if any bugs are found, please contact the lead developer as soon as possible. They should be
    ''' just dropped into forms like any standard Windows-style button.
    ''' </remarks>
    <System.Runtime.CompilerServices.CompilerGenerated()> _
    Class NamespaceDoc
    End Class
End Namespace

Namespace LightweightControls
    ''' <summary>
    ''' Contains all lightweight controls.
    ''' </summary>
    ''' <remarks>
    ''' These controls are windowless, so they do not use any system handles. This allows them to be instantiated in great number,
    ''' with far less overhead than a standard control. They rely on their parent window to pass them events and draw them to the
    ''' screen, but otherwise encapsulate the full functionality of an LCARS button. Please see the <see cref="Controls.ButtonGrid">ButtonGrid</see>
    ''' control for an example of using them and the <see cref="LightweightControls.LCFlatButton">LCFlatButton</see> for
    ''' an example implementation of a lightweight control.
    ''' </remarks>
    <System.Runtime.CompilerServices.CompilerGenerated()> _
        Class NamespaceDoc
    End Class
End Namespace
