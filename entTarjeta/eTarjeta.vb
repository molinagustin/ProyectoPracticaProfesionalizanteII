Imports CapaDatos
Public Class eTarjeta
#Region "Campos"
    Private _IdTarjeta As Integer
    Private _NombreTarj As String
    Private _TipoTarj As Integer
#End Region

#Region "Propiedades"
    Public Property IdTarjeta As Integer
        Get
            Return _IdTarjeta
        End Get
        Set(value As Integer)
            _IdTarjeta = value
        End Set
    End Property

    Public Property NombreTarj As String
        Get
            Return _NombreTarj
        End Get
        Set(value As String)
            _NombreTarj = value
        End Set
    End Property

    Public Property TipoTarj As Integer
        Get
            Return _TipoTarj
        End Get
        Set(value As Integer)
            _TipoTarj = value
        End Set
    End Property
#End Region

#Region "Metodos"

#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de las tarjetas de debito y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerTarjetasDebito() As List(Of eTarjeta)
        'Creo un listado
        Dim listado As New List(Of eTarjeta)

        'Uso el constructor para obtener directamente el listado de tarjetas
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM tarjetas WHERE TipoTarj = 1;")

        'Devuelvo la lista
        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una lista de las tarjetas de credito y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerTarjetasCredito() As List(Of eTarjeta)
        'Creo un listado
        Dim listado As New List(Of eTarjeta)

        'Uso el constructor para obtener directamente el listado de tarjetas
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM tarjetas WHERE TipoTarj = 2;")

        'Devuelvo la lista
        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una tarjeta en particular
    ''' </summary>
    ''' <param name="Id">Numero de Id de la tarjeta a consultar</param>
    ''' <returns></returns>
    Public Function ObtenerTarjeta(Id As Integer) As eTarjeta
        'Creo un nuevo objeto
        Dim tarjeta As New eTarjeta
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(tarjeta, "SELECT * FROM tarjetas WHERE IdTarjeta = " & Id)

        Return tarjeta
    End Function
#End Region
End Class
