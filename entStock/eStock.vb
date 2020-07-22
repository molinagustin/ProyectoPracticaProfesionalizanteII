Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eStock
#Region "Campos"
    Private _IdStock As Integer
    Private _IdProdStock As Integer
    Private _StockExistencia As Double
#End Region

#Region "Propiedades"
    Public Property IdStock As Integer
        Get
            Return _IdStock
        End Get
        Set(value As Integer)
            _IdStock = value
        End Set
    End Property

    Public Property IdProdStock As Integer
        Get
            Return _IdProdStock
        End Get
        Set(value As Integer)
            If value > 0 Then
                _IdProdStock = value
            Else
                Throw New Exception("El valor de stock no pudo ser asignado a un producto valido")
            End If
        End Set
    End Property

    Public Property StockExistencia As Double
        Get
            Return _StockExistencia
        End Get
        Set(value As Double)
            If Not value.ToString.Trim = "" And value >= 0 Then
                _StockExistencia = value
            Else
                Throw New Exception("El valor de stock no puede ser negativo o estar vacio")
            End If
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eStocks y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerTodosStocks() As List(Of eStock)
        Dim listado As New List(Of eStock)
        'Uso el constructor para obtener directamente el listado de stocks
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM stock;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene el stock de un producto y lo devuelve
    ''' </summary>
    ''' <param name="IdProducto">Numero de ID del producto cuyo stock se quiere saber</param>
    ''' <returns></returns>
    Public Function ObtenerStockProducto(IdProducto As Integer) As eStock
        Dim stock As New eStock
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(stock, "SELECT * FROM stock WHERE IdProdStock = " & IdProducto)

        Return stock
    End Function

    ''' <summary>
    ''' Inserta los datos del stock de un producto en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarStock() As Integer
        Dim query As New clsArmadoQuery
        Dim registro As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With registro
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "stock")
            filas = .FilasAfectadas
        End With

        'Devuelvo las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Actualiza los datos del stock existente de un producto
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarStock(ByRef ObjetoNuevo As eStock) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "stock", "IdStock")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Stock")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function
#End Region
End Class