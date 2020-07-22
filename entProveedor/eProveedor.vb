Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eProveedor
#Region "Campos"
    Private _IdProveedor As Integer
    Private _NombreProveedor As String
    Private _DomicilioProveedor As String
    Private _Telefono As String
    Private _CorreoElectronico As String
    Private _Activo As Integer
#End Region

#Region "Propidades"
    Public Property IdProveedor As Integer
        Get
            Return _IdProveedor
        End Get
        Set(value As Integer)
            _IdProveedor = value
        End Set
    End Property

    Public Property NombreProveedor As String
        Get
            Return _NombreProveedor
        End Get
        Set(value As String)
            'No se comprueban numeros porque algunos proveedores tendran numeros en sus razones sociales
            If Not value.Trim().Length > 40 Then
                If Not value.Trim() = "" Then
                    _NombreProveedor = value.Trim()
                Else
                    Throw New Exception("El Nombre Proveedor no debe estar vacio")
                End If
            Else
                Throw New Exception("El largo del Nombre Proveedor no debe ser mayor a 40 caracteres")
            End If
        End Set
    End Property

    Public Property DomicilioProveedor As String
        Get
            Return _DomicilioProveedor
        End Get
        Set(value As String)
            If Not value.Trim().Length > 35 Then
                _DomicilioProveedor = value.Trim()
            Else
                Throw New Exception("El largo del Domicilio Proveedor no debe ser mayor a 35 caracteres")
            End If
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            'Solo se comprueba que sea numerico
            If IsNumeric(value) Or value.ToString.Trim = "" Then
                _Telefono = value.Trim()
            Else
                Throw New Exception("No se admiten caracteres no numericos en el telefono")
            End If

        End Set
    End Property

    Public Property CorreoElectronico As String
        Get
            Return _CorreoElectronico
        End Get
        Set(value As String)
            _CorreoElectronico = value.Trim()
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

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eProveedores y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerProveedores() As List(Of eProveedor)
        Dim listado As New List(Of eProveedor)
        'Uso el constructor para obtener directamente el listado de proveedores
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM proveedores WHERE Activo = 1;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene un proveedor y lo devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID del proveedor</param>
    ''' <returns></returns>
    Public Function ObtenerProveedor(Id As Integer) As eProveedor
        Dim proveedor As New eProveedor
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(proveedor, "SELECT * FROM proveedores WHERE IdProveedor = " & Id)

        Return proveedor
    End Function

    ''' <summary>
    ''' Inserta los datos de un proveedor en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarProveedor() As Integer
        Dim query As New clsArmadoQuery
        Dim proveedor As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With proveedor
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "proveedores")
            filas = .FilasAfectadas
        End With

        'Devuelvo las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Actualiza los datos de un proveedor existente
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarProveedor(ByRef ObjetoNuevo As eProveedor) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "proveedores", "IdProveedor")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Proveedor")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Obtener los datos de un proveedor segun su nombre
    ''' </summary>
    ''' <param name="nombre">Nombre del proveedor</param>
    ''' <returns></returns>
    Public Function obtenerProveedorNombre(nombre As String) As eProveedor
        Dim prove As New eProveedor

        'Uso el constructor vacio
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(prove, "SELECT * FROM proveedores WHERE NombreProveedor = '" & nombre & "'")

        Return prove
    End Function
#End Region
End Class
