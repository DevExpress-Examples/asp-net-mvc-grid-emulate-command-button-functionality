Imports System
Imports System.ComponentModel.DataAnnotations

Public Class Person
    Public Sub New()
        PersonID = 0
        FirstName = String.Empty
        MiddleName = String.Empty
        LastName = String.Empty
    End Sub

    Public Sub New(ByVal id As Integer, ByVal firstName As String, ByVal middleName As String, ByVal lastName As String)
        Me.PersonID = id
        Me.FirstName = firstName
        Me.MiddleName = middleName
        Me.LastName = lastName
    End Sub

    Private privatePersonID As Integer
    <Key()> _
    Public Property PersonID() As Integer
        Get
            Return privatePersonID
        End Get
        Set(ByVal value As Integer)
            privatePersonID = value
        End Set
    End Property

    Private privateFirstName As String
    <Required(ErrorMessage:="First Name is required")> _
    Public Property FirstName() As String
        Get
            Return privateFirstName
        End Get
        Set(ByVal value As String)
            privateFirstName = value
        End Set
    End Property

    Private privateMiddleName As String
    Public Property MiddleName() As String
        Get
            Return privateMiddleName
        End Get
        Set(ByVal value As String)
            privateMiddleName = value
        End Set
    End Property

    Private privateLastName As String
    <Required(ErrorMessage:="Last Name is required")> _
    Public Property LastName() As String
        Get
            Return privateLastName
        End Get
        Set(ByVal value As String)
            privateLastName = value
        End Set
    End Property
End Class
