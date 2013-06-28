'This file contains controls that are still works in progress. They are generally nonfunctional at
'the moment. If you complete a control, move it to its own file(s) in the proper folder(s).

Option Strict On


Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports LCARS.LCARScolor
Imports System.Windows.Forms

'Added for TabPanel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design.Serialization



Namespace Controls
#Region " ScrollPanel (Not finished!) "

    Public Class ScrollPanel
        Inherits Windows.Forms.Control

        ' Inherits LCARS.LCARSbuttonClass

        Sub New()
            Me.SetStyle(ControlStyles.ContainerControl, True)
        End Sub
    End Class

    '#Region " Option Button "

    '    <System.ComponentModel.DefaultEvent("Click")> _
    '    Public Class OptionButton
    '        Inherits LCARS.LCARSbuttonClass

    '#Region " Control Design Information "
    '        Public Sub New()
    '            MyBase.New()

    '            'This call is required by the Windows Form Designer.
    '            InitializeComponent()

    '            'Add any initialization after the InitializeComponent() call

    '        End Sub

    '        'UserControl1 overrides dispose to clean up the component list.
    '        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    '            If disposing Then
    '                If Not (components Is Nothing) Then
    '                    components.Dispose()
    '                End If
    '            End If
    '            MyBase.Dispose(disposing)
    '        End Sub

    '        'Required by the Windows Form Designer
    '        Private components As System.ComponentModel.IContainer

    '        'NOTE: The following procedure is required by the Windows Form Designer
    '        'It can be modified using the Windows Form Designer.  
    '        'Do not modify it using the code editor.

    '        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '            Me.SuspendLayout()
    '            '
    '            'StandardButton
    '            '
    '            Me.Name = "StandardButton"
    '            Me.Size = New System.Drawing.Size(200, 100)
    '            Me.ResumeLayout(False)

    '        End Sub
    '#End Region

    '#Region " Enums "

    '        Public Enum LCARSButtonStyle
    '            left = 0
    '            right = 1
    '        End Enum

    '#End Region

    '#Region " Global Varibles "
    '        Dim myButtonType As LCARSButtonStyle = LCARSButtonStyle.right
    '#End Region

    '#Region " Properties "
    '        Public Property ButtonStyle() As LCARSButtonStyle
    '            Get
    '                Return myButtonType
    '            End Get
    '            Set(ByVal value As LCARSButtonStyle)
    '                myButtonType = value
    '                Me.DrawAllButtons()
    '            End Set
    '        End Property
    '#End Region

    '#Region " Subs "


    '        Public Overrides Sub GenericButton_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
    '            CheckForIllegalCrossThreadCalls = False
    '        End Sub

    '#End Region

    '#Region " Draw Standard Button "

    '        Public Overrides Function DrawButton() As Bitmap
    '            Dim mybitmap As Bitmap
    '            Dim g As Graphics
    '            Dim myBrush As New Drawing.SolidBrush(ColorsAvailable.getColor(Me.Color))
    '            Dim halfHeight As Integer
    '            Dim quarterHeight As Integer
    '            Dim quarterWidth As Integer

    '            If Me.RedAlert = LCARSalert.Red Then
    '                myBrush = New Drawing.SolidBrush(Drawing.Color.Red)
    '            ElseIf Me.RedAlert = LCARSalert.White Then
    '                myBrush = New Drawing.SolidBrush(Drawing.Color.White)
    '            End If

    '            mybitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
    '            g = Graphics.FromImage(mybitmap)

    '            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height)

    '            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

    '            halfHeight = Me.Height \ 2
    '            quarterHeight = Me.Height \ 4
    '            quarterWidth = Me.Width \ 4



    '            If myButtonType = LCARSButtonStyle.right Then
    '                g.FillEllipse(myBrush, 0, 0, Me.Size.Height, Me.Size.Height)
    '                g.FillRectangle(myBrush, halfHeight, 0, Me.Size.Width - Me.Size.Height, Me.Size.Height)
    '                g.FillEllipse(myBrush, Me.Size.Width - Me.Size.Height, 0, Me.Size.Height, Me.Size.Height)


    '                lblText.Location = New Point(Me.Height \ 2, 0)
    '                lblText.Size = New Size(Me.Width - Me.Height, Me.Height)

    '            Else
    '                g.FillEllipse(myBrush, New Rectangle(0, 0, quarterHeight, quarterHeight))
    '                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, 0, quarterHeight, quarterHeight))
    '                g.FillEllipse(myBrush, New Rectangle(0, Me.Height - quarterHeight, quarterHeight, quarterHeight))
    '                g.FillEllipse(myBrush, New Rectangle(Me.Width - quarterHeight, Me.Height - quarterHeight, quarterHeight, quarterHeight))

    '                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, 0, Me.Width - quarterHeight, quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, Me.Height - quarterHeight, Me.Width - quarterHeight, quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(0, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(Me.Width - quarterHeight, quarterHeight \ 2, quarterHeight, Me.Height - quarterHeight))
    '                g.FillRectangle(myBrush, New Rectangle(quarterHeight \ 2, quarterHeight \ 2, Me.Width - quarterHeight, Me.Height - quarterHeight))

    '                Select Case myButtonType
    '                    Case LCARSbuttonStyles.RoundedSquareSlant

    '                        Dim slant As Bitmap = New Bitmap(mybitmap)

    '                        Dim mypoints(2) As Point

    '                        mypoints(0) = New Point(Me.Width \ 4, 0)
    '                        mypoints(1) = New Point(Me.Width, 0)
    '                        mypoints(2) = New Point(0, Me.Height)

    '                        g.FillRectangle(Brushes.Black, mybitmap.GetBounds(System.Drawing.GraphicsUnit.Pixel))
    '                        g.DrawImage(slant, mypoints)

    '                        lblText.Location = New Point(Me.Width \ 4, 0)
    '                        lblText.Size = New Size(Me.Width - (Me.Width \ 2), Me.Height)
    '                    Case Else
    '                        lblText.Location = New Point(0, 0)
    '                        lblText.Size = New Size(Me.Width, Me.Height)
    '                End Select

    '            End If




    '            Return mybitmap
    '        End Function

    '#End Region

    '    End Class
    '#End Region
#End Region

#Region " Data Grid (Not Finished!) "

    '#Region " Data Grid Class "
    '    <Designer(GetType(DataGridDesigner))> _
    '    Public Class DataGrid
    '        Inherits System.Windows.Forms.Control

    '#Region " Global Variables "
    '        Private itemList() As GridItem
    '        Public Columns As New List(Of Column)
    '        Private _showHeaders As Boolean = True
    '        Private _dataColor As LCARScolorStyles = LCARScolorStyles.Orange
    '        Private _headerColor As LCARScolorStyles = LCARScolorStyles.StaticBlue
    '        Private _ColumnSizeMode As ColumnWidthMode = ColumnWidthMode.Absolute
    '        Public ColorsAvailible As New LCARS.LCARScolor()
    '#End Region

    '#Region " Enum "
    '        Public Enum ColumnWidthMode
    '            Relative = 0
    '            Absolute = 1
    '        End Enum
    '#End Region

    '#Region " Subs "
    '        Public Sub New()
    '            'mycol.title = "Test2"
    '            'mycol.width = -1
    '            'Columns.Add(mycol)
    '            'AddColumn("", 0)

    '            Me.BackColor = Drawing.Color.Black
    '            ColorsAvailible.ReloadColors()
    '            AddHandler Me.Paint, AddressOf Redraw
    '        End Sub

    '        Public Sub Redraw(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
    '            Dim g As Graphics = e.Graphics
    '            Dim drawfont As New Font("LCARS", 18, FontStyle.Regular, GraphicsUnit.Point, 0)
    '            Dim headerBrush As New Drawing.SolidBrush(Drawing.Color.Cyan) 'ColorsAvailible.getColor(_headerColor))
    '            Dim dataBrush As New Drawing.SolidBrush(Drawing.Color.Orange) 'ColorsAvailible.getColor(_dataColor))
    '            'g.DrawString("Test", New Font("LCARS", 14, FontStyle.Regular, GraphicsUnit.Point, 0), Brushes.Orange, 0, 0)

    '            'Find absolute column widths
    '            Dim columnwidths(Columns.Count - 1) As Integer
    '            Dim total As Integer = 0
    '            Dim remainderIndex As New List(Of Integer)
    '            For i As Integer = 0 To Columns.Count - 1
    '                If _ColumnSizeMode = ColumnWidthMode.Absolute Then
    '                    columnwidths(i) = Columns(i).width
    '                Else
    '                    columnwidths(i) = Columns(i).width * Me.Width
    '                End If
    '                If columnwidths(i) = -1 Then
    '                    remainderIndex.Add(i)
    '                Else
    '                    total += columnwidths(i)
    '                End If
    '            Next
    '            'Go back and fill in remainder widths
    '            If remainderIndex.Count > 0 Then
    '                For Each myremainder As Integer In remainderIndex
    '                    columnwidths(myremainder) = (Me.Width - total) / remainderIndex.Count
    '                Next
    '            End If
    '            If ShowHeaders Then
    '                Dim curleft As Integer = 0
    '                For i As Integer = 0 To Columns.Count - 1
    '                    g.DrawString(Columns(i).title, drawfont, headerBrush, curleft, 0)
    '                    curleft += columnwidths(i)
    '                Next
    '            End If
    '        End Sub

    '        Public Sub AddColumn(ByVal Name As String, ByVal Width As Decimal)
    '            Dim mycol As New Column(Name, Width)
    '            Columns.Add(mycol)
    '            Me.Invalidate()
    '        End Sub
    '#End Region

    '#Region " Properties "

    '        Public Property ShowHeaders() As Boolean
    '            Get
    '                Return _showHeaders
    '            End Get
    '            Set(ByVal value As Boolean)
    '                _showHeaders = value
    '                Me.Invalidate()
    '            End Set
    '        End Property

    '        Public Property Color() As LCARScolorStyles
    '            Get
    '                Return _dataColor
    '            End Get
    '            Set(ByVal value As LCARScolorStyles)
    '                _dataColor = value
    '                Me.Invalidate()
    '            End Set
    '        End Property

    '        Public Property HeaderColor() As LCARScolorStyles
    '            Get
    '                Return _headerColor
    '            End Get
    '            Set(ByVal value As LCARScolorStyles)
    '                _headerColor = value
    '                Me.Invalidate()
    '            End Set
    '        End Property

    '        Public Property ColumnSizeMode() As ColumnWidthMode
    '            Get
    '                Return _ColumnSizeMode
    '            End Get
    '            Set(ByVal value As ColumnWidthMode)
    '                _ColumnSizeMode = value
    '                Me.Invalidate()
    '            End Set
    '        End Property
    '#End Region

    '    End Class
    '#End Region

    '#Region " Column Class "
    '    Public Class Column
    '        Private _width As Decimal
    '        Private _title As String
    '        Public Event ColumnSizeChanged()
    '        Public Event ColumnTextChanged()
    '        Public Sub New(ByVal ColumnTitle As String, ByVal ColumnWidth As Decimal)
    '            _width = ColumnWidth
    '            _title = ColumnTitle
    '        End Sub
    '        Public Property Width() As String
    '            Get
    '                Return _width
    '            End Get
    '            Set(ByVal value As String)
    '                _width = value
    '                RaiseEvent ColumnSizeChanged()
    '            End Set
    '        End Property
    '        Public Property Title() As String
    '            Get
    '                Return _title
    '            End Get
    '            Set(ByVal value As String)
    '                _title = value
    '                RaiseEvent ColumnTextChanged()
    '            End Set
    '        End Property
    '    End Class
    '#End Region

    '#Region " GridItem Class "
    '    Public Class GridItem
    '        Private _items() As Object
    '        Private _highlightColor As LCARScolorStyles = LCARScolorStyles.PrimaryFunction
    '        Public Event ItemChanged()

    '        Public Sub New(ByVal length As Integer)
    '            ReDim _items(length)
    '        End Sub

    '        Public Function getString(ByVal index As Integer) As String
    '            Dim myString As String = index.ToString()
    '            If ReferenceEquals(myString.GetType(), _items(index).GetType()) Then
    '                myString = CType(_items(index), String)
    '            Else
    '                myString = _items(index).ToString()
    '            End If
    '            Return myString
    '        End Function

    '        Public Property items(ByVal index As Integer) As Object
    '            Get
    '                Return _items(index)
    '            End Get
    '            Set(ByVal value As Object)
    '                _items(index) = value
    '                RaiseEvent ItemChanged()
    '            End Set
    '        End Property

    '        Public Property HighlightColor() As LCARScolorStyles
    '            Get
    '                Return _highlightColor
    '            End Get
    '            Set(ByVal value As LCARScolorStyles)
    '                _highlightColor = value
    '                RaiseEvent ItemChanged()
    '            End Set
    '        End Property
    '    End Class
    '#End Region

    '#Region " Data Grid Designer "
    '    Public Class DataGridDesigner
    '        Inherits ControlDesigner

    '        Dim myDataGrid As DataGrid
    '        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
    '            MyBase.Initialize(component)
    '            myDataGrid = DirectCast(Me.Control, DataGrid)
    '        End Sub
    '        Protected Overrides Sub PostFilterProperties(ByVal Properties As System.Collections.IDictionary)
    '            Properties.Remove("BackColor")
    '            Properties.Remove("Text")
    '        End Sub

    '        Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
    '            MyBase.OnPaintAdornments(pe)
    '            pe.Graphics.DrawRectangle(Pens.White, 0, 0, Me.Control.Size.Width - 1, Me.Control.Size.Height - 1)
    '        End Sub

    '        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
    '            Get
    '                Dim myVerbs As New DesignerVerbCollection
    '                myVerbs.Add(New DesignerVerb("Add Column", New EventHandler(AddressOf OnAddColumn)))
    '                myVerbs.Add(New DesignerVerb("Remove Column", New EventHandler(AddressOf OnRemoveColumn)))
    '                Return myVerbs
    '            End Get
    '        End Property

    '        Private Sub OnAddColumn()
    '            'This only shows up in design time
    '            myDataGrid.AddColumn("test", 100)
    '            MsgBox("Add column")
    '        End Sub

    '        Private Sub OnRemoveColumn()
    '            MsgBox("Remove Column")
    '        End Sub
    '    End Class
    '#End Region

#End Region

End Namespace
