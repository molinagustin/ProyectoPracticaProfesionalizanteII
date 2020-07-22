Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eRubro
#Region "Campos"
    Private _IdRubro As Integer
    Private _NombreRubro As String
    Private _Activo As Integer
#End Region

#Region "Propiedades"
    Public Property IdRubro As Integer
        Get
            Return _IdRubro
        End Get
        Set(value As Integer)
            _IdRubro = value
        End Set
    End Property

    Public Property NombreRubro As String
        Get
            Return _NombreRubro
        End Get
        Set(value As String)
            If Not value.Trim().Length > 20 Then
                _NombreRubro = value.Trim()
            Else
                Throw New Exception("El Nombre de Rubro no puede ser mayor a 20 caracteres")
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

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eRubros y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerRubros() As List(Of eRubro)
        Dim listado As New List(Of eRubro)

        'Uso el constructor para obtener directamente el listado de rubros
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM rubros WHERE Activo = 1;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene los datos de un rubro y lo devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID del rubro</param>
    ''' <returns></returns>
    Public Function ObtenerRubro(Id As Integer) As eRubro
        Dim rubro As New eRubro
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(rubro, "SELECT * FROM rubros WHERE IdRubro = " & Id)

        Return rubro
    End Function

    ''' <summary>
    ''' Inserta los datos de un rubro en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarRubro() As Integer
        Dim query As New clsArmadoQuery
        Dim rubro As New clsEjecucionQuery
        Dim filas As Short

        'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
        With rubro
            .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
            .Comando = query.insertarNuevoRegistro(Me, "rubros")
            filas = .FilasAfectadas
        End With

        'Devuelve las filas afectadas
        Return filas
    End Function

    ''' <summary>
    ''' Actualiza los datos de un rubro existente
    ''' </summary>
    ''' <param name="ObjetoNuevo">Objeto con los datos a actualizar</param>
    ''' <returns></returns>
    Public Function ActualizarRubro(ByRef ObjetoNuevo As eRubro) As Integer
        Dim filas As Integer
        Dim query As New clsArmadoQuery
        Dim capa As New clsEjecucionQuery

        Try
            'Le asigno las propiedades al objeto (internamente se ejecutan los metodos para armado y ejecucion de la query)
            With capa
                .ModoProceso = clsEjecucionQuery.TipoProceso.NonQuery
                .Comando = query.actualizarRegistro(Me, ObjetoNuevo, "rubros", "IdRubro")
                filas = .FilasAfectadas
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Entidad Rubro")
        End Try

        'Devuelve las filas afectadas
        Return filas
    End Function
#End Region
End Class
