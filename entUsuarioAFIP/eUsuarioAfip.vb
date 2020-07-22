Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eUsuarioAfip
#Region "Campos"
    Private _IdUsuarioAfip As Integer
    Private _NombreUsuario As String
    Private _ClaveFiscal As String
#End Region

#Region "Propiedades"
    Public Property IdUsuarioAfip As Integer
        Get
            Return _IdUsuarioAfip
        End Get
        Set(value As Integer)
            _IdUsuarioAfip = value
        End Set
    End Property

    Public Property NombreUsuario As String
        Get
            Return _NombreUsuario
        End Get
        Set(value As String)
            If IsNumeric(value) Then
                If value.Trim().Length = 11 Then
                    _NombreUsuario = value.Trim()
                Else
                    Throw New Exception("El usuario debe estar compuesto por 11 numeros sin espacio, guion o caracteres especiales")
                End If
            Else
                Throw New Exception("El valor del usuario solo debe ser numerico")
            End If
        End Set
    End Property

    Public Property ClaveFiscal As String
        Get
            Return _ClaveFiscal
        End Get
        Set(value As String)
            If Not value.Trim().Length > 30 Then
                If Not value.Trim().Length < 11 Then
                    _ClaveFiscal = value.Trim()
                Else
                    Throw New Exception("La clave fiscal debe tener una longitud de 11 caracteres minimo")
                End If
            Else
                Throw New Exception("La contraseña no puede exceder los 30 caracteres")
            End If
        End Set
    End Property
#End Region

#Region "Metodos"

#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eUsuarioAFIP y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerUsuarios() As List(Of eUsuarioAfip)
        Dim listado As New List(Of eUsuarioAfip)

        'Uso el constructor para obtener directamente el listado de usuarios AFIP
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM usuarios_afip;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene un usuario y lo devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID del usuario</param>
    ''' <returns></returns>
    Public Function ObtenerUsuario(Id As Integer) As eUsuarioAfip
        Dim usuario As New eUsuarioAfip
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(usuario, "SELECT * FROM usuarios_afip WHERE IdUsuarioAfip = " & Id)

        Return usuario
    End Function

    ''' <summary>
    ''' Inserta los datos de un usuario en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarUsuario() As Integer
        Dim query As New clsArmadoQuery
        Dim usuario As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With usuario
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "usuarios_afip")
            filas = .FilasAfectadas
        End With

        'Devuelve las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Actualiza los datos de un usuario existente
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarUsuario(ByRef ObjetoNuevo As eUsuarioAfip) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "usuarios_afip", "IdUsuarioAfip")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Usuario AFIP")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function
#End Region
End Class
