Public Class Stock

    Private mTalle As String
    Private mCantidad As String

    Public Property Talle() As String
        Get
            Return mTalle
        End Get
        Set(ByVal value As String)
            mTalle = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return mCantidad
        End Get
        Set(ByVal value As Integer)
            mCantidad = value
        End Set
    End Property


End Class