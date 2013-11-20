Public Class MovimientosGestion

    Private mGestion As String
    Private mCliente As String
    Private mDisfraz As String
    Private mEstado As String
    Private mOperacionId As Integer
    Private mMovId As Integer
    Private mFecDevolucion As DateTime

    Public Property Gestion() As String
        Get
            Return mGestion
        End Get
        Set(ByVal value As String)
            mGestion = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return mCliente
        End Get
        Set(ByVal value As String)
            mCliente = value
        End Set
    End Property

    Public Property Disfraz() As String
        Get
            Return mDisfraz
        End Get
        Set(ByVal value As String)
            mDisfraz = value
        End Set
    End Property

    Public Property OperacionId() As Integer
        Get
            Return mOperacionId
        End Get
        Set(ByVal value As Integer)
            mOperacionId = value
        End Set
    End Property


    Public Property FecDevolucion() As DateTime
        Get
            Return mFecDevolucion
        End Get
        Set(ByVal value As DateTime)
            mFecDevolucion = value
        End Set
    End Property

    Public Property MovId() As Integer
        Get
            Return mMovId
        End Get
        Set(ByVal value As Integer)
            mMovId = value
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

End Class
