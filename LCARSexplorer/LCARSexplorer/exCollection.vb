Option Strict Off

Public Class exCollection
    Inherits CollectionBase

    Public Sub Add(ByVal value As exCollectionItem)
        List.Add(value)
    End Sub

    Public Sub Add(ByVal Value As Object, Optional ByVal Key As String = "")
        Try
            Dim myItem As New exCollectionItem(Value, Key)
            List.Add(myItem)
        Catch ex As Exception
            MsgBox("Error adding: " & "[" & Key & "] " & Value)
        End Try
    End Sub

    Public Function Contains(ByVal value As exCollectionItem) As Boolean
        Return List.Contains(value)
    End Function

    Public Function IndexOf(ByVal value As exCollectionItem) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As exCollectionItem)
        List.Insert(index, value)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As exCollectionItem
        Get
            Return DirectCast(List.Item(index), exCollectionItem)
        End Get
    End Property

    Public Sub Remove(ByVal value As exCollectionItem)
        List.Remove(value)
    End Sub
End Class
''An expanded collection class.

'Dim Items(-1) As exCollectionItem

'Dim myItems As New Collection

'Public Sub AddItem(ByVal Value As Object, Optional ByVal Key As String = "")
'    Dim newItem As New exCollectionItem

'    newItem.Value = Value
'    newItem.Key = Key

'    ReDim Preserve Items(Items.GetUpperBound(0) + 1)
'    Items(Items.GetUpperBound(0)) = newItem

'End Sub

'Public Sub AddItem(ByVal Item As exCollectionItem)
'    ReDim Preserve Items(Items.GetUpperBound(0) + 1)
'    Items(Items.GetUpperBound(0)) = Item
'End Sub

'Public Sub AddItemAt(ByVal Index As Integer, ByVal Value As Object, Optional ByVal Key As String = "")
'    Dim buffer() As exCollectionItem = Items

'    ReDim Items(Items.GetUpperBound(0) + 1)

'    For intloop As Integer = 0 To buffer.GetUpperBound(0)
'        If intloop < Index Then
'            Items(intloop) = buffer(intloop)
'        ElseIf intloop = Index Then
'            Dim newItem As New exCollectionItem
'            newItem.Value = Value
'            newItem.Key = Key

'            Items(intloop) = newItem
'        Else
'            Items(intloop + 1) = buffer(intloop)
'        End If
'    Next

'    buffer = Nothing
'End Sub

'Public Sub RemoveItem(ByVal ItemToRemove As Object)
'    Dim buffer() As exCollectionItem = Items

'    ReDim Items(-1)

'    For Each myItem As Object In Items
'        If Not myItem = ItemToRemove Then
'            AddItem(buffer)
'        End If
'    Next
'End Sub

'Public Sub RemoveItemByKey(ByVal Key As String)
'    For Each myItem As exCollectionItem In Items
'        If myItem.Key = Key Then
'            RemoveItem(myItem)
'        End If
'    Next
'End Sub

'Public Sub RemoveItemAt(ByVal index As Integer)
'    If index < 0 Or index > Items.GetUpperBound(0) Then
'        Throw New Exception("The index is out of bounds!  The index must be between 0 and " & Items.GetUpperBound(0))
'    Else
'        Dim buffer() As exCollectionItem = Items
'        ReDim Items(buffer.GetUpperBound(0) - 1)

'        For intloop As Integer = 0 To buffer.GetUpperBound(0)
'            If intloop < index Then
'                Items(intloop) = buffer(intloop)
'            ElseIf intloop > index Then
'                Items(intloop - 1) = buffer(intloop)
'            End If
'        Next
'    End If
'End Sub

'Public Sub Clear()
'    ReDim Items(-1)
'End Sub

'Public ReadOnly Property Count() As Integer
'    Get
'        Return Items.GetUpperBound(0) + 1
'    End Get
'End Property

'Public Property Item(ByVal index As Integer) As exCollectionItem
'    Get
'        Return Items(index)
'    End Get
'    Set(ByVal value As exCollectionItem)
'        Items(index) = value
'    End Set
'End Property

Public Class exCollectionItem
    Dim _item As Object
    Dim _key As String

    Public Sub New(ByVal Value As Object, Optional ByVal Key As String = "")
        _item = Value
        _key = Key
    End Sub

    Public Property Value() As Object
        Get
            Return _item
        End Get
        Set(ByVal value As Object)
            _item = value
        End Set
    End Property

    Public Property Key() As Object
        Get
            Return _key
        End Get
        Set(ByVal value As Object)
            _key = value
        End Set
    End Property
End Class
