Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data

Public Class eLocalidad
#Region "Campos"
    Private _IdLocalidad As Integer
    Private _NombreLocalidad As String
    Private _CP As String
    Private _Provincia As Integer
#End Region

#Region "Propiedades"
    Public Property IdLocalidad As Integer
        Get
            Return _IdLocalidad
        End Get
        Set(value As Integer)
            _IdLocalidad = value
        End Set
    End Property

    Public Property NombreLocalidad As String
        Get
            Return _NombreLocalidad
        End Get
        Set(value As String)
            If Not value.Trim().Length > 45 And Not value.Trim() = "" And Not IsNumeric(value.Trim()) Then
                _NombreLocalidad = value.Trim()
            Else
                Throw New Exception("Largo y/o contenido de Nombre Localidad incorrecto")
            End If
        End Set
    End Property

    Public Property CP As String
        Get
            Return _CP
        End Get
        Set(value As String)
            If Not value.Trim().Length > 5 And Not value.Trim() = "" And IsNumeric(value.Trim()) Then
                _CP = value.Trim()
            Else
                Throw New Exception("Largo y/o contenido de Codigo Postal incorrecto")
            End If
        End Set
    End Property

    Public Property Provincia As Integer
        Get
            Return _Provincia
        End Get
        Set(value As Integer)
            _Provincia = value
        End Set
    End Property
#End Region

#Region "Metodos"

#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eLocalidades y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerLocalidades() As List(Of eLocalidad)
        Dim listado As New List(Of eLocalidad)

        'Uso el constructor para pasar los datos y realizar la ejecucion interna
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM localidades;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una lista de eLocalidades por provincia y la devuelve
    ''' </summary>
    ''' <param name="IdProv">Numero de ID de la provincia</param>
    ''' <returns></returns>
    Public Function ObtenerLocalidades(IdProv As Integer) As List(Of eLocalidad)
        Dim listado As New List(Of eLocalidad)

        'Uso el constructor para pasar los datos y realizar la ejecucion interna
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM localidades WHERE Provincia = " & CStr(IdProv)) 'La conversion a string del ID no es necesaria

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una localidad por su ID y devuelve sus datos como objeto
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Function ObtenerLocalidad(Id As Integer) As eLocalidad
        Dim localidad As New eLocalidad

        'Uso el constructor vacio
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(localidad, "SELECT * FROM localidades WHERE IdLocalidad = " & Id)

        Return localidad
    End Function

    ''' <summary>
    ''' Obtiene una localidad por su nombre y devuelve sus datos
    ''' </summary>
    ''' <param name="Nombre">Nombre de la localidad</param>
    ''' <returns></returns>
    Public Function ObtenerLocalidadNombre(Nombre As String) As eLocalidad
        Dim localidad As New eLocalidad

        'Uso el constructor vacio
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(localidad, "SELECT * FROM localidades WHERE NombreLocalidad = '" & Nombre & "'")

        Return localidad
    End Function

    ''' <summary>
    ''' Inserta una nueva localidad en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarLocalidad() As Integer
        Dim query As New clsArmadoQuery
        Dim localidad As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With localidad
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "localidades")
            filas = .FilasAfectadas
        End With

        'Devuelvo las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Actualizo los datos de una localidad existente
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarLocalidad(ByRef ObjetoNuevo As eLocalidad) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "localidades", "IdLocalidad")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Localidad")
        End Try

        'Devuelvo las filas afectadas
        Return filas
    End Function
#End Region
End Class
