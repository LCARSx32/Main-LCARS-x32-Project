Imports System.Collections.Generic

''' <summary>
''' Basic implementation of a hash set
''' </summary>
''' <typeparam name="T">Type of data to store</typeparam>
''' <remarks>
''' This is a partial re-implementation of the HashSet(Of T) class in the .NET framework v3.5
''' or above. Because LCARS currently uses the .NET framework v2.0, we don't have that. In the
''' event that we do make the transition, this class should be deleted in favor of the framework
''' class that will have much better performance. (If there were an simple way to make this a
''' compile error on newer versions I would do so. As it is, there should be a warning thrown.)
''' </remarks>
Public Class HashSet(Of T)
    Implements IEnumerable(Of T)
    ''' <summary>
    ''' Handles the hashtable operations
    ''' </summary>
    Dim data As New Dictionary(Of T, Object)()

    Public Function add(ByVal item As T) As Boolean
        If data.ContainsKey(item) Then
            Return False
        Else
            data.Add(item, Nothing)
        End If
    End Function

    Public Sub clear()
        data.Clear()
    End Sub

    Public Function contains(ByVal item As T) As Boolean
        Return data.ContainsKey(item)
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return data.Count
        End Get
    End Property

    Public Function first() As T
        For Each item As T In data.Keys
            Return item
        Next
        Return Nothing
    End Function

    Public Function remove(ByVal item As T) As Boolean
        If data.ContainsKey(item) Then
            data.Remove(item)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of T) Implements System.Collections.Generic.IEnumerable(Of T).GetEnumerator
        Return data.Keys.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return data.Keys.GetEnumerator()
    End Function
End Class
