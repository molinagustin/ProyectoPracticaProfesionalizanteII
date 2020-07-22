Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class ePuntoVenta
#Region "Campos"
    Private _IdPuntoVta As Integer
    Private _Punto_Venta As String
    Private _Num_Puppeteer As Integer
#End Region

#Region "Propiedades"
    Public Property IdPuntoVta As Integer
        Get
            Return _IdPuntoVta
        End Get
        Set(value As Integer)
            _IdPuntoVta = value
        End Set
    End Property

    Public Property Punto_Venta As String
        Get
            Return _Punto_Venta
        End Get
        Set(value As String)
            _Punto_Venta = value.Trim()
        End Set
    End Property

    Public Property Num_Puppeteer As Integer
        Get
            Return _Num_Puppeteer
        End Get
        Set(value As Integer)
            _Num_Puppeteer = value
        End Set
    End Property
#End Region

#Region "Metodos"

#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene un listado de ePuntosVta y lo devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerPuntosVta() As List(Of ePuntoVenta)
        Dim listado As New List(Of ePuntoVenta)

        'Uso el constructor para obtener directamente el listado de puntos de venta
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM puntos_venta;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene un punto de venta y lo devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID del punto de venta</param>
    ''' <returns></returns>
    Public Function ObtenerPuntoVta(Id As Integer) As ePuntoVenta
        Dim punto As New ePuntoVenta
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(punto, "SELECT * FROM puntos_venta WHERE IdPuntoVta = " & Id)

        Return punto
    End Function

    ''' <summary>
    ''' Inserta los datos de un Punto de Venta en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarPuntoVta() As Integer
        Dim query As New clsArmadoQuery
        Dim puntoVta As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With puntoVta
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "puntos_venta")
            filas = .FilasAfectadas
        End With

        'Devuelvo las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Actualiza los datos de un punto de venta existente
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarPuntoVta(ByRef ObjetoNuevo As ePuntoVenta) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "puntos_venta", "IdPuntoVta")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Punto Venta")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function
#End Region
End Class
