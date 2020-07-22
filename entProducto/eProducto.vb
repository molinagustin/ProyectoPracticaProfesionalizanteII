Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data.MySqlClient
Public Class eProducto
#Region "Campos"
    Private _IdProducto As Integer
    Private _NombreProducto As String
    Private _Rubro As Integer
    Private _PrecioCosto As Double
    Private _PrecioFinal As Double
    Private _Proveedor As Integer
    Private _UnidadMedida As Integer
    Private _Activo As Integer
#End Region

#Region "Propiedades"
    Public Property IdProducto As Integer
        Get
            Return _IdProducto
        End Get
        Set(value As Integer)
            _IdProducto = value
        End Set
    End Property

    Public Property NombreProducto As String
        Get
            Return _NombreProducto
        End Get
        Set(value As String)
            'No hace falta comprobar si posee numeros porque algunos productos lo requeriran (Ej. Galletas por 100gr.)
            If Not value.Trim().Length > 35 And Not value.Trim() = "" Then
                _NombreProducto = value.Trim()
            Else
                Throw New Exception("Largo de Nombre Producto incorrecto")
            End If
        End Set
    End Property

    Public Property Rubro As Integer
        Get
            Return _Rubro
        End Get
        Set(value As Integer)
            If value > 0 Then
                _Rubro = value
            Else
                Throw New Exception("Debe seleccionar un rubro")
            End If
        End Set
    End Property

    Public Property PrecioCosto As Double
        Get
            Return _PrecioCosto
        End Get
        Set(value As Double)
            'La comprobacion de caracteres se hace sobre  el formulario
            If Not value.ToString.Trim() = "" And value > 0 Then
                _PrecioCosto = value
            Else
                Throw New Exception("El Precio de Costo no puede estar vacio o ser nulo")
            End If
        End Set
    End Property

    Public Property PrecioFinal As Double
        Get
            Return _PrecioFinal
        End Get
        Set(value As Double)
            'La comprobacion de caracteres se hace sobre  el formulario
            If Not value.ToString.Trim() = "" And value > 0 Then
                _PrecioFinal = value
            Else
                Throw New Exception("El Precio final no puede estar vacio o ser nulo")
            End If
        End Set
    End Property

    Public Property Proveedor As Integer
        Get
            Return _Proveedor
        End Get
        Set(value As Integer)
            If value > 0 Then
                _Proveedor = value
            Else
                Throw New Exception("Debe seleccionar un Proveedor")
            End If
        End Set
    End Property

    Public Property UnidadMedida As Integer
        Get
            Return _UnidadMedida
        End Get
        Set(value As Integer)
            _UnidadMedida = value
        End Set
    End Property

    Public Property Activo As Integer
        Get
            Return _Activo
        End Get
        Set(value As Integer)
            _Activo = value
        End Set
    End Property
#End Region

#Region "Metodos"

#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eProductos y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerProductos() As List(Of eProducto)
        Dim listado As New List(Of eProducto)

        'Uso el constructor para obtener directamente el listado de productos
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM productos WHERE Activo = 1 ORDER BY NombreProducto;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtener los datos de un producto y devolverlo
    ''' </summary>
    ''' <param name="Id">Numero de ID del producto</param>
    ''' <returns></returns>
    Public Function ObtenerProducto(Id As Integer) As eProducto
        Dim producto As New eProducto
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(producto, "SELECT * FROM productos WHERE IdProducto = " & Id)

        Return producto
    End Function

    ''' <summary>
    ''' Inserta los datos de un producto en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarProducto() As Integer
        Dim query As New clsArmadoQuery
        Dim producto As New clsEjecucionQuery
        Dim registro As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With producto
            .ModoProceso = clsEjecucionQuery.TipoProceso.Scalar
            .Comando = query.insertarNuevoRegistro(Me, "productos")
            registro = .IdNuevoRegistro
        End With

        'Devuelvo el id del registro
        Return registro
    End Function

    ''' <summary>
    ''' Actualizar los datos de un producto existente en la base de datos
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarProducto(ByRef ObjetoNuevo As eProducto) As Integer
        Dim filas As Integer = 0
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "productos", "IdProducto")
                If query.Flag = True Then
                    filas = .FilasAfectadas
                End If
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Producto")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function
#End Region
End Class
