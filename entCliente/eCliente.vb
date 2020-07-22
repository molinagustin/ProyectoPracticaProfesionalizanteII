Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eCliente
#Region "Campos"
    Private _IdCliente As Integer
    Private _NombreCliente As String
    Private _TipoDocumento As Integer
    Private _NumeroDocumento As String 'Sirve para guardar CUIT tambien
    Private _Domicilio As String
    Private _CondicionIva As Integer
    Private _Localidad As Integer
    Private _Activo As Integer
#End Region

#Region "Propiedades"
    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return _NombreCliente
        End Get
        Set(value As String)
            If Not value.Trim().Length > 40 And Not value.Trim() = "" And Not IsNumeric(value.Trim()) Then
                _NombreCliente = value.Trim()
            Else
                Throw New Exception("Largo y/o contenido de Nombre incorrecto")
            End If
        End Set
    End Property

    Public Property TipoDocumento As Integer
        Get
            Return _TipoDocumento
        End Get
        Set(value As Integer)
            _TipoDocumento = value
        End Set
    End Property

    Public Property NumeroDocumento As String
        Get
            Return _NumeroDocumento
        End Get
        Set(value As String)
            'Solo se comprueba la longitud, el tipo de caracter se comprueba en el formulario
            If value.Trim().Length >= 7 And value.Trim().Length <= 11 Then
                _NumeroDocumento = value.Trim()
            Else
                Throw New Exception("Largo de contenido en Numero Documento incorrecto")
            End If
        End Set
    End Property

    Public Property Domicilio As String
        Get
            Return _Domicilio
        End Get
        Set(value As String)
            If Not value.Trim().Length > 35 And Not value.Trim() = "" Then
                _Domicilio = value.Trim()
            Else
                Throw New Exception("Largo y/o contenido de Direccion incorrecto")
            End If
        End Set
    End Property

    Public Property CondicionIva As Integer
        Get
            Return _CondicionIva
        End Get
        Set(value As Integer)
            _CondicionIva = value
        End Set
    End Property

    Public Property Localidad As Integer
        Get
            Return _Localidad
        End Get
        Set(value As Integer)
            If value > 0 Then
                _Localidad = value
            Else
                Throw New Exception("Debe seleccionar una Localidad")
            End If
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
    ''' Obtiene una lista de eClientes y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerClientes() As List(Of eCliente)
        Dim listado As New List(Of eCliente)

        'Uso el constructor para obtener directamente el listado de clientes
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM clientes WHERE Activo = 1;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene un cliente y lo devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID a consultar del cliente</param>
    ''' <returns></returns>
    Public Function ObtenerCliente(Id As Integer) As eCliente
        Dim cliente As New eCliente
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(cliente, "SELECT * FROM clientes WHERE Activo = 1 AND IdCliente = " & Id)

        Return cliente
    End Function

    ''' <summary>
    ''' Inserta un cliente a la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarCliente() As Integer
        Dim query As New clsArmadoQuery
        Dim cliente As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With cliente
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "clientes")
            filas = .FilasAfectadas
        End With

        'Devuelvo las filas afectas
        Return filas
    End Function

    ''' <summary>
    ''' Actualiza los datos un cliente ya existente
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar del tipo eCliente</param>
    ''' <returns></returns>
    Public Function ActualizarCliente(ByRef ObjetoNuevo As eCliente) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "clientes", "IdCliente")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Cliente")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function
#End Region
End Class
