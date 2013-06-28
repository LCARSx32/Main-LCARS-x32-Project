Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design.Serialization


Namespace Controls
    'The x32TabControl is made of two main parts:  The x32TabControl itself, and x32TabPages that get added
    'to it (just like the Windows Tab Control).

#Region " The Tab Control "

#Region " x32TabControl "

    'Set the defualt event to "SelectedTabChanged" (just makes it easier on the user).  At the same
    'time, apply the 'x32TabControlDesigner' which handles how x32TabControls interact with the 
    'Windows Form Designer (more info in the 'x32TabControlDesigner' class).
    <System.ComponentModel.DefaultEvent("SelectedTabChanged"), Designer(GetType(x32TabControlDesigner))> _
    Public Class x32TabControl
        Inherits Windows.Forms.Control


        'This is a global variable to hold the tabpages collection.  An underscore is used to 
        'denote that there is a property by the same name that this variable is linked to.
        Dim _TabPages As New x32TabPageCollection(Me)
        'The currently active tab.
        Dim _SelectedTab As x32TabPage

        'In case it's not obvious, this is the elbow in the top right of the x32TabControl.
        Dim topElbow As New LCARS.Controls.Elbow
        'Likewise, this is the heading bar at the very top of the control
        Dim myHeading As New FlatButton
        'and the buttonPanel that holds the tab buttons along the right side
        Public buttonPanel As New Panel
        'This label is used to display a message explaining how to add tabs when none
        'have been added and the control is in 'design time'.
        Dim message As New Label

        'An event that fires when a new tab has been selected.  Very useful for the user.
        Public Event SelectedTabChanged(ByVal Tab As x32TabPage, ByVal TabIndex As Integer)

        'Don't show it in the 'Properties' page, and remember it when the form is closed 
        '(Serialize it)
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property TabPages() As x32TabPageCollection
            'Returns a collection containing all of the tabs currently on the x32TabControl.
            Get
                Return _TabPages
            End Get
        End Property

        'Don't show it in the 'Properties' page
        <Browsable(False)> _
        Public Property SelectedTab() As x32TabPage
            'Gets or sets the tab that is currently selected.  What more can I say?
            Get
                Return _SelectedTab
            End Get
            Set(ByVal value As x32TabPage)
                _SelectedTab = value
                If _SelectedTab IsNot Nothing Then
                    'As long as the selected tab is something, show it.
                    ChangeTab(_SelectedTab)
                End If

            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            'Create the controls that make up the tabcontrol.  

            'These are:

            'The heading above the tab area (very top),
            With myHeading
                .ButtonText = ""
                .Width = Me.Width - 126
                .Height = 20
                .Left = 0
                .Top = 0
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                .Color = LCARScolorStyles.LCARSDisplayOnly
                .ButtonTextAlign = ContentAlignment.BottomLeft
            End With

            Me.Controls.Add(myHeading)

            'The elbow in the top right of the tabcontrol,
            With topElbow
                .ElbowStyle = Elbow.LCARSelbowStyles.UpperRight
                .ButtonHeight = 20
                .ButtonWidth = 100
                .Width = 120
                .Height = 75
                .Left = Me.Width - .Width
                .Top = 0
                .ButtonText = "TABS"
                .ButtonTextAlign = ContentAlignment.BottomRight
                .Color = LCARScolorStyles.StaticTan
                .Clickable = False
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            End With

            Me.Controls.Add(topElbow)


            'And the panel that contains the buttons that act as the 'Tabs'.
            With buttonPanel
                .Width = 100
                .Height = Me.Height - topElbow.Bottom
                .Top = topElbow.Bottom
                .Left = Me.Width - .Width
                .BackColor = Color.Black
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            End With

            Me.Controls.Add(buttonPanel)

            TabPagesChanged()
            topElbow.SendToBack()
        End Sub

        Private Sub InitializeComponent()
            'Sets the default values for the x32TabControl.

            'Allow this control to contain other controls
            Me.SetStyle(ControlStyles.ContainerControl, True)
            Me.UpdateStyles()

            'Don't redraw the control until we're done making changes.
            Me.SuspendLayout()

            Me.BackColor = Color.Black
            Me.Size = New System.Drawing.Size(400, 400)

            'Ok, now we can allow the control to draw again.
            Me.ResumeLayout(False)
        End Sub


        Friend Sub TabPagesChanged()
            'This Sub is called whenever a tab has been added or removed from the TabPages collection.

            'Remove all of the tabs from the control
            For Each mycontrol As Control In Me.Controls
                If mycontrol.GetType Is GetType(LCARS.Controls.x32TabPage) Then
                    Me.Controls.Remove(mycontrol)
                End If

            Next

            'Remove the tab's button from the buttonPanel.
            buttonPanel.Controls.Clear()

            'Add all of the tabs back to the control, so now the new ones are there, too 
            '(or old ones are gone...)
            For Each mytab As x32TabPage In Me.TabPages
                Me.Controls.Add(mytab)

                'Set the size of the tab equal to the area we want the tab to cover.  Basically,
                'everwhere our heading, elbow, and buttonpanel are not.
                mytab.Width = Me.Width - 110
                mytab.Height = Me.Height - 26
                mytab.Location = New Point(0, 26)

                'Set the anchor so the tab will resize with the tabcontrol
                mytab.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right

                'Now that we have the tab added to the tab control, we need to create a button
                'that will bring it to the front when the user clicks it.
                Dim mybutton As New FlatButton
                mybutton.Width = 100
                mybutton.Height = 35
                mybutton.ButtonText = mytab.Text
                mybutton.ButtonTextAlign = ContentAlignment.BottomRight

                'It might be a good idea to make it so the user can select the color of the
                'tab.  It would make things more consistant.  For now, they are just set to 
                'MiscFunction.
                mybutton.Color = LCARScolorStyles.MiscFunction

                'Button beeping also needs to be handled.  I'm working on a way for new controls
                'and community made programs to easily interface with LCARSmain so they know when
                'they need to turn beeping on/off or when the colors have changed.
                mybutton.Beeping = False

                'position the button based on how many buttons are already there.
                mybutton.Top = (buttonPanel.Controls.Count * 41) + 6
                mybutton.Left = 0

                'By setting the button's 'Tag' property to the Tab it is associated with,
                'we can easily tell what button goes with what tab.
                mybutton.Tag = mytab

                'Make the button call "myButton_Click" whenever someone clicks on it.
                AddHandler mybutton.Click, AddressOf myButton_Click
                buttonPanel.Controls.Add(mybutton)
            Next


            'If there's any room left after all of tabs have been made, we need to fill the
            'empty space with another button that isn't clickable.
            If (buttonPanel.Controls.Count * 41) + 6 < buttonPanel.Height Then
                Dim mybutton As New FlatButton

                With mybutton
                    .Width = 100

                    'Start at the bottom of the last button
                    .Top = (buttonPanel.Controls.Count * 41) + 6

                    'and end at the bottom of the tab control.
                    .Height = buttonPanel.Height - .Top

                    .Color = LCARScolorStyles.StaticTan
                    .Clickable = False
                    .ButtonTextAlign = ContentAlignment.BottomRight

                    'have the button resize with the control.  We don't want it to get wider,
                    'that 100px so we leave AnchorStyles.Right out of the code.
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
                    buttonPanel.Controls.Add(mybutton)
                End With
            End If

            'If the "SelectedTab" property isn't set, then select the first tab added to the control.
            If SelectedTab Is Nothing Or TabPages.Contains(SelectedTab) = False Then
                If TabPages.Count > 0 Then
                    SelectedTab = TabPages(0)
                Else
                    SelectedTab = Nothing
                End If
            End If

            'There's a label placed on the form if no tabs have been added that explains how to 
            'add tabs to the control.  This message is only shown if there are no tabs and the 
            'control is in 'Design Time' (not executing, but rather in the designer).
            If TabPages.Count > 0 Then
                message.Visible = False
            Else
                message.Visible = True
            End If

            'Bring the tab that is currently set as selected to the front.
            ChangeTab(_SelectedTab)
        End Sub

        Private Sub ChangeTab(ByVal Tab As x32TabPage)
            'Brings the provided tab to the front of all of the other tabs and sets it as 
            'the selected tab. 

            'NOTE: _SelectedTab is used because if we used the property to set the selected tab, 
            'we would get into an 'endless loop' because the 'SelectedTab' property calls 
            ''ChangeTab' which in turn would call 'SelectedTab' again.  Not good!
            If Tab IsNot Nothing Then
                Tab.BringToFront()
                _SelectedTab = Tab

                'Set the heading(the bar at the top)'s text to the tab's text
                myHeading.text = Tab.Text

                'Set the selected tabs button's color to white and all of the others to 'MiscFunction'
                For Each mybutton As FlatButton In buttonPanel.Controls
                    If mybutton.Tag Is Tab Then
                        mybutton.Color = LCARScolorStyles.PrimaryFunction
                    Else
                        mybutton.Color = LCARScolorStyles.MiscFunction
                    End If
                Next
            End If

            'Let the user of the control know that a tab has been selected.
            RaiseEvent SelectedTabChanged(Tab, TabPages.indexOf(Tab))

        End Sub

        Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Handles the user clicking on one of the tab buttons.

            '"Sender" is the button that the user clicked.  We can use it's tag property (that
            'was set in the 'TabPagesChanged' Sub) to bring the tab associated with this button to 
            'the front.
            ChangeTab(sender.tag)
        End Sub


        Private Sub LCARStabControl_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
            'This event fires when the control is added to the form or moved from one control to 
            'another.  The reason the following code is here rather than in the 'New' or 
            'InitializeComponents' Subs is because we have to wait until the control has been added
            'to the form or another control before we can check if any of those controls are running
            'in design time.

            'Here, we're checking if the control is running in "Design Time" or "Run Time".
            'Design Time is when you are editing the form in the designer.  Run Time is when you
            'execute the program.  We don't want to show a message explaining how to use the
            'x32TabControl unless they are a programmer!
            If IsDesignerHosted And Me.Controls.Contains(message) = False Then
                With message
                    .AutoSize = True
                    .Text = "There are currently no tabs." & vbNewLine & _
                              "Right click on the elbow and choose" & vbNewLine & _
                              "'Add Tab' to add new tabs to the control."

                    'Center the message in the Tab area.
                    .Left = ((Me.Width - 112) / 2) - (.Width / 2)
                    .Top = (Me.Height / 2) - (.Height / 2)

                    .ForeColor = Color.White

                    'by removing all of it's anchors, the control will stay centered.
                    .Anchor = AnchorStyles.None

                    Me.Controls.Add(message)

                    'It's sent to the back just in case a tab is there.  It shouldn't be, but if
                    'it is, this line ensures that the message is hidden behind it.
                    Me.SendToBack()
                End With
            End If
        End Sub

        Public ReadOnly Property IsDesignerHosted() As Boolean
            'Thanks to this (http://decav.com/blogs/andre/archive/2007/04/18/1078.aspx) 
            'website for explaining how to tell if you are in design time (editor) or run 
            'time (executing/running) whichi is what the below code does.

            Get
                Dim ctrl As Control = Me
                While ctrl IsNot Nothing
                    If ctrl.Site Is Nothing Then
                        'If a control does not have a site, then it's definately in 'Run Time'.
                        Return False
                    End If
                    If ctrl.Site.DesignMode = True Then
                        Return True
                    End If

                    'Check the control's parent to make sure it's not running in design time.
                    'if any of them are, then the whole program is.
                    ctrl = ctrl.Parent
                End While
                Return False
            End Get
        End Property

        Private Sub LCARStabControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
            'Fires when the x32TabControl is resized.

            'For whatever reason, anchors alone weren't working, so I had to add code here to move
            'the main components of the x32TabControl whenever the control was resized.
            topElbow.Left = Me.Width - topElbow.Width
            topElbow.Top = 0

            buttonPanel.Top = topElbow.Bottom
            buttonPanel.Left = Me.Width - buttonPanel.Width
            buttonPanel.Height = Me.Height - buttonPanel.Top

            myHeading.Width = Me.Width - 126
            myHeading.Top = 0
            myHeading.Left = 0
        End Sub
    End Class

#End Region

#Region " x32TabControlDesigner "

    'The x32TabControlDesigner allows us to control how the x32TabControl behaves when in "Design 
    'Time". It's the way we allow the user to right click on the elbow and choose 'Add Tab', and 
    'to allow them to click on the tab buttons. 
    Public Class x32TabControlDesigner
        'We had to import some extra classes to be able to use this, so scroll all the way up to
        'see which ones (they are commented).
        Inherits ControlDesigner

        'This holds a reference to the x32TabControl currently being modified.
        Dim myControl As x32TabControl

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            '"Component" is passed to the designer by the x32TabControl when it is added to a form.
            'We have to convert it from an IComponent to an x32TabControl.  Since it's actually 
            'already just an x32TabControl, we can use DirectCast to change it's type (just to 
            'make it easy on ourselves later).
            myControl = DirectCast(component, x32TabControl)

            'Here we're adding an event handler that will fire when something is added to our
            'control--in our case, x32TabPages.
            Dim c As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            AddHandler c.ComponentRemoving, AddressOf OnComponentRemoving
        End Sub

        Private Sub OnComponentRemoving(ByVal sender As Object, ByVal e As ComponentEventArgs)
            'This sub is fired when a control is removed from our x32TabControl.

            'A lot of this was modified from code I found at: http://www.divelements.com/net/articles/designers/collectioncontrols.asp
            'It's a great article and helped A LOT.

            Dim c As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            Dim mytabPage As x32TabPage
            Dim h As IDesignerHost = DirectCast(GetService(GetType(IDesignerHost)), IDesignerHost)
            Dim i As Integer

            'If the user is removing a TabPage
            If TypeOf e.Component Is x32TabPage Then
                mytabPage = DirectCast(e.Component, x32TabPage)
                If myControl.TabPages.Contains(mytabPage) Then
                    c.OnComponentChanging(myControl, Nothing)
                    myControl.TabPages.Remove(mytabPage)
                    c.OnComponentChanged(myControl, Nothing, Nothing, Nothing)
                    Return
                End If
            End If

            'If the user is removing the control itself, remove all of the TabPages first.
            If e.Component Is myControl Then
                For i = myControl.TabPages.Count - 1 To 0 Step -1
                    mytabPage = myControl.TabPages(i)
                    c.OnComponentChanging(myControl, Nothing)
                    myControl.TabPages.Remove(mytabPage)
                    h.DestroyComponent(mytabPage)
                    c.OnComponentChanged(myControl, Nothing, Nothing, Nothing)
                Next
            End If
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            Dim c As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)

            'Unhook events
            RemoveHandler c.ComponentRemoving, AddressOf OnComponentRemoving

            MyBase.Dispose(disposing)
        End Sub

        Public Overrides ReadOnly Property AssociatedComponents() As System.Collections.ICollection
            'This and the 'OnComponentRemoving' sub are used to keep the "TabPages" Collection in
            'tact when the form is reloaded (called 'serialization').
            Get
                Return myControl.TabPages
            End Get
        End Property

        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            'Adds the 'Add Tab' option to the right click (context) menu of the x32TabControl and
            'associates the menu item with the 'AddTab' sub.
            Get
                Dim myVerbs As New DesignerVerbCollection()

                'Create the verb to add a tab
                myVerbs.Add(New DesignerVerb("&Add Tab", AddressOf AddTab))
                Return myVerbs
            End Get
        End Property

        Private Sub AddTab(ByVal sender As Object, ByVal e As EventArgs)
            'I don't understand everthing that goes on here.  I know that the end result is a new
            'tab being added to the x32TabPageControl.

            'Our new tab
            Dim mytabpage As x32TabPage

            'An instance of the IDesignerHost interface which allows us to create transactions
            'in the designer.
            Dim myHost As IDesignerHost = DirectCast(GetService(GetType(IDesignerHost)), IDesignerHost)

            'A transaction.  From what I read, I believe that this just allows our "Add Tab" to 
            'be undone using the "Undo" button.
            Dim myTransaction As DesignerTransaction

            'This is used to call events that are also used in the Undo and Redo functions.
            Dim myChangeService As IComponentChangeService = DirectCast(GetService(GetType(IComponentChangeService)), IComponentChangeService)

            'Set the name of the transaction.  I believe this also sets the starting point.
            myTransaction = myHost.CreateTransaction("Add Tab")
            'Create a new x32TabPage using the DesignerHost.
            mytabpage = DirectCast(myHost.CreateComponent(GetType(x32TabPage)), x32TabPage)
            'Let Visual Studio know we changed a component (our x32TabControl)
            myChangeService.OnComponentChanging(myControl, Nothing)
            'Add the tabpage to the tabcontrol.
            myControl.TabPages.Add(mytabpage)
            'Visual Studio... we changed it again.
            myChangeService.OnComponentChanged(myControl, Nothing, Nothing, Nothing)
            'Finish the transaction so it knows when the "undo" should stop.
            myTransaction.Commit()
        End Sub

        Protected Overrides Function GetHitTest(ByVal point As System.Drawing.Point) As Boolean
            'GetHitTest is allows us to make controls clickable during design time.  For example,
            'on the x32TabControl, you'll notice that even in the designer, you can switch tabs
            'by clicking on the relevant tab button.  Take this sub out and that won't work any
            'more.

            'Make sure that we have been added to a control. Otherwise, there's no point.
            If Me.Control IsNot Nothing Then

                'Convert the point from screen coordinates to coordinates based on our x32TabControl
                Dim mypoint As Point = CType(Me.Control, x32TabControl).buttonPanel.PointToClient(point)
                'Find out what control is under the mouse at that point.
                Dim child As Control = CType(Me.Control, x32TabControl).buttonPanel.GetChildAtPoint(mypoint)

                'If there's nothing under the mouse, don't bother.
                If child IsNot Nothing Then
                    If TypeOf child Is FlatButton Then
                        'If the control under the mouse is a flatbutton, let us click on it.
                        Return True
                    Else
                        'Otherwise... no clicky.
                        Return MyBase.GetHitTest(point)
                    End If
                End If
            End If

        End Function
    End Class

#End Region

#Region " x32TabCollection "

    Public Class x32TabPageCollection
        Inherits CollectionBase
        'This class keeps track of all the tabs on the x32TabControl.  It's a fairly simple class,
        'as the 'CollectionBase' class does all of the heavy lifting.

        'The x32TabControl the current instance of x32TabCollection is running inside of
        Private Parent As x32TabControl

        Friend Sub New(ByVal Control As x32TabControl)
            'When an x32TabControl creates it's TabPages collection, it passes itself as the single
            'parameter so we can tell what x32TabControl goes with the collection.
            Me.Parent = Control
        End Sub

        Default Public ReadOnly Property Item(ByVal Index As Integer) As x32TabPage
            'Returns whatever tabpage is at the given index.
            Get
                Return DirectCast(List(Index), x32TabPage)
            End Get
        End Property

        Public Function Contains(ByVal tab As x32TabPage) As Boolean
            'Returns 'true' if the tab is in the collection and 'false' if it is not.
            Return List.Contains(tab)
        End Function

        Public Function Add(ByVal tab As x32TabPage) As Integer
            'Adds the supplied tab to the tab collection and returns it's new index
            Dim i As Integer
            i = List.Add(tab)
            Parent.TabPagesChanged()
            Return i
        End Function

        Public Function indexOf(ByVal tab As x32TabPage)
            'Returns the index of the given tab in the collection
            Return List.IndexOf(tab)
        End Function

        Public Sub Remove(ByVal Tab As x32TabPage)
            'Removes the given tab from the collection.  I know... duh. But comments are necessary evils.
            List.Remove(Tab)
            Tab = Nothing
            Parent.TabPagesChanged()
        End Sub
    End Class

#End Region

#End Region

#Region " Tab Pages "

#Region " x32TabPage "

    'Associate the x32TabPageDesigner with the x32TabPage class, Associate it also with the
    'x32TabPageConverter (used in the serialization process), don't show it in the toolbox, and
    'allow x32TabPages to have other controls drug-and-dropped onto them.
    <Designer(GetType(x32TabPageDesigner)), TypeConverter(GetType(x32TabPageConverter)), DesignTimeVisible(False), ToolboxItem(False), Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", GetType(IDesigner))> _
    Public Class x32TabPage
        Inherits Control

        'The text of the x32TabPage (what shows on the button and the heading).
        Dim _text As String = "NEW TAB"

        Sub New()
            _text = "NEW TAB"
            'This is LCARS after all.  We can't settle for a gray background.
            Me.BackColor = Color.Black
        End Sub

        Sub New(ByVal TabText As String)
            _text = TabText
            Me.BackColor = Color.Black
        End Sub

        Public Overrides Property Text() As String
            'Gets or sets the tabs button and heading text.
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                'It's LCARS.  Text is UPPER CASE! unless it isn't...
                _text = value.ToUpper

                If Me.Parent IsNot Nothing Then
                    'Update the tabs
                    CType(Me.Parent, x32TabControl).TabPagesChanged()
                End If
            End Set
        End Property

    End Class

#End Region

#Region " x32TabPageDesigner "

    Public Class x32TabPageDesigner
        Inherits ParentControlDesigner
        'Specifies how the x32TabPage interacts with the user in the Windows Form Designer.
        'Basically, all this class does is locks the x32TabControl so it can't be moved or
        'resized.  

        'Our parent control
        Dim myControl As x32TabPage

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            myControl = DirectCast(component, x32TabPage)
        End Sub

        Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
            'SelectionRules.Locked prevents the user from being able to move or resize the 
            'x32TabPage in the designer.
            Get
                Return SelectionRules.Locked
            End Get
        End Property
    End Class

#End Region

#Region " x32TabPageConverter "

    Friend Class x32TabPageConverter
        Inherits TypeConverter

        'A class to convert x32TabPages during the serialization process.  Don't ask me, I pretty
        'much just changed the word 'button' from the example to 'x32TabPage' and it worked...

        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destType As Type) As Boolean
            If destType Is GetType(InstanceDescriptor) Then
                Return True
            End If

            Return MyBase.CanConvertTo(context, destType)
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
            If destType Is GetType(InstanceDescriptor) Then
                Dim ci As System.Reflection.ConstructorInfo = GetType(x32TabPage).GetConstructor(System.Type.EmptyTypes)

                Return New InstanceDescriptor(ci, Nothing, False)
            End If

            Return MyBase.ConvertTo(context, culture, value, destType)
        End Function
    End Class

#End Region

#End Region
End Namespace