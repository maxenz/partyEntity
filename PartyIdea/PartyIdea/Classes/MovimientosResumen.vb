Public Class MovimientosResumen

    Private mColor As String
    Private mEstado As String
    Private mCantidad As Integer

    Public Property Color() As String
        Get
            Return mColor
        End Get
        Set(ByVal value As String)
            mColor = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
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

