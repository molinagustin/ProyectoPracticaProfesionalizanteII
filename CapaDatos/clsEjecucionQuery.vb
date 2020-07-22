Imports System.Reflection 'Esta libreria me otorga clases para poder consultar objetos y sus propiedades
Imports MySql.Data.MySqlClient
Imports UtilidadesSQL
Imports System.Configuration 'Libreria con clases que me permite acceder al App.config, entre otras mas
Public Class clsEjecucionQuery
#Region "Campos"
    'Enum para diferenciar el proceso a ejecutar
    Public Enum TipoProceso
        DataTable = 0
        Scalar = 1
        NonQuery = 2
    End Enum

    Private _ModoProceso As TipoProceso
    Private _QuerySQL As String
    Private _FilasAfectadas As Short
    Private _Comando As MySqlCommand
    Private _TablaDatos As New DataTable
    'Campo que sirve para guardar y devolver el numero de Id del registro generado
    Private _IdNuevoRegistro As Integer
#End Region

#Region "Propiedades"
    Public Property ModoProceso As TipoProceso
        Set(value As TipoProceso)
            _ModoProceso = value
        End Set
        Get
            Return _ModoProceso
        End Get
    End Property

    Public Property QuerySQL As String
        Set(value As String)
            _QuerySQL = value
        End Set
        Get
            Return _QuerySQL
        End Get
    End Property

    Public ReadOnly Property FilasAfectadas As Short
        Get
            'Ejecuto la funcion y devuelvo las filas afectadas
            EjecutarConsulta()
            Return _FilasAfectadas
        End Get
    End Property

    Public Property Comando As MySqlCommand
        Set(value As MySqlCommand)
            _Comando = value
        End Set
        Get
            Return _Comando
        End Get
    End Property

    Public ReadOnly Property TablaDatos As DataTable
        Get
            'Ejecuto la funcion y devuelvo la tabla llena
            EjecutarConsulta()
            Return _TablaDatos
        End Get
    End Property

    Public ReadOnly Property IdNuevoRegistro As Integer
        Get
            'Ejecuto la funcion y devuelvo las filas afectadas
            EjecutarConsulta()
            Return _IdNuevoRegistro
        End Get
    End Property
#End Region

#Region "Constructores"
    ''' <summary>
    ''' Constructor generico sin parametros
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Constructor con parametros y ejecucion de funcion llenarListaDeObjeto
    ''' </summary>
    ''' <param name="tipoObjeto">El tipo del objeto</param>
    ''' <param name="listaObjetos">Una lista de objetos iguales al tipo de objeto</param>
    ''' <param name="QuerySQL">La query a ejecutar</param>
    ''' <remarks></remarks>
    Public Sub New(tipoObjeto As Type, ByRef listaObjetos As Object, QuerySQL As String)
        'Ejecuto la funcion con los parametros
        llenarListaDeObjeto(tipoObjeto, listaObjetos, QuerySQL)
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Metodo que permite obtener un registro de una tabla de la base de datos
    ''' </summary>
    ''' <param name="objetoConDatos">El objeto que se llenara con los valores de las propiedades correspondientes del registro</param>
    ''' <param name="querySql">La query armada dirigida a la tabla y el registro correspondiente</param>
    ''' <remarks></remarks>
    Public Sub obtenerRegistro(ByRef objetoConDatos As Object, querySql As String)
        'Creo un objeto que sera el que contenga el String de la conexion a realizar
        Dim conexionSql As New clsConectorSql

        'El bloque using me permite crear objetos y utilizarlos pero cuando se terminan de usar se liberan de memoria
        Using conexionSql.conector
            'Creo un objeto del tipo TYPE para obtener el tipo del objeto pasado por parametro
            Dim objetoEntidad As Type = objetoConDatos.GetType

            'Creo un bojeto para guardar las propiedades del objeto pasado por parametro
            Dim propiedadEntidad() As PropertyInfo = objetoEntidad.GetProperties

            'Creo el comando para guardar la query, la conexion y luego ejecutar la consulta
            Dim comando As MySqlCommand = New MySqlCommand(querySql, conexionSql.conector)

            Try
                'Si la conexion con la base de datos esta cerrada, la abro
                If conexionSql.conector.State = ConnectionState.Closed Then
                    conexionSql.conector.Open()
                End If

                'El data reader se llena con elementos de la base de datos pero solo se puede leer secuencialmente hacia adelante, es decir no se pueder ir volviendo a otros campos.
                'El ExecuteReader envia la consulta a una Base de datos y crea un datareader, asi que le guardo ese datareader dentro del otro.
                Dim lectorDatos As MySqlDataReader = comando.ExecuteReader

                'Un campo para guardar el nombre de las propiedades recorridas
                Dim campoNombre As String

                'Mientras el lector de datos se pueda leer, se hace un for anidado para recorrer el nombre de las propiedades del objeto pasado por el metodo, e ir comparando el nombre con las columnas que trae el datareader
                While lectorDatos.Read
                    For campo As Int16 = 0 To propiedadEntidad.Length - 1
                        campoNombre = propiedadEntidad(campo).Name

                        'Ahora recorremos el datareader, el FieldCount es igual al Lenght
                        For columnaDR As Int16 = 0 To lectorDatos.FieldCount - 1
                            If campoNombre = lectorDatos.GetName(columnaDR) Then
                                'A la propiedad que tenga  el nombre correspondiente (campo) le vamos a asignar el valor de dicha propiedad al objeto que habiamos pasado en el metodo, y desde donde se pasan los valores, sera del DataReader y la columna que se emparejo correctamente
                                propiedadEntidad(campo).SetValue(objetoConDatos, lectorDatos.GetValue(columnaDR))
                            End If
                        Next
                    Next
                End While

                'Si surge un error del tipo SQL lanzo un mensaje con el error
            Catch er As MySqlException
                MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Ejecucion Query")

            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")

                'El finally se ejecuta siempre haya habido una excepcion o no
            Finally
                'Si la conexion continua abierta, la cierro
                If conexionSql.conector.State = ConnectionState.Open Then
                    conexionSql.conector.Close()
                End If
            End Try
            'Al finalizar el Using se libera de memoria los objetos creados aca dentro
        End Using
        'Al finalizar el sub, el objeto pasado por referencia ahora estara lleno de las propiedades y valores correspondientes de la entidad enviada
    End Sub

    ''' <summary>
    ''' Metodo que llenara un DataTable de los datos que obtenga de la base de datos segun la query pasada por parametro
    ''' </summary>
    ''' <param name="tablaDatos">La tabla a llenar con los datos</param>
    ''' <param name="query">La query armada para realizar la consulta</param>
    ''' <remarks></remarks>
    Public Sub obtenerRegistros(ByRef tablaDatos As DataTable, query As String)
        'Creo un objeto que sera el que contenga el String de la conexion a realizar
        Dim conexionSql As New clsConectorSql

        'El bloque using me permite crear objetos y utilizarlos pero cuando se terminan de usar se liberan de memoria
        Using conexionSql.conector
            'Creo un bojeto del tipo adaptador de datos de sql que realice la ejecucion de la query
            Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter(query, conexionSql.conector.ConnectionString)

            'Genero un bloque try para llenar la tabla de datos
            Try
                'Si la conexion con la base de datos esta cerrada, la abro
                If conexionSql.conector.State = ConnectionState.Closed Then
                    conexionSql.conector.Open()
                End If

                'Llamo al metodo FILL que me llena un DataTable
                adaptador.Fill(tablaDatos)

                'Si surge un error del tipo SQL lanzo un mensaje con el error
            Catch er As MySqlException
                MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Ejecucion Query")

                'Si surge un error menos especifico lanzo un mensaje con el error
            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")

                'El finally se ejecuta siempre haya habido una excepcion o no
            Finally
                'Si la conexion continua abierta, la cierro
                If conexionSql.conector.State = ConnectionState.Open Then
                    conexionSql.conector.Close()
                End If
            End Try
        End Using
        'Al finalizar el sub, la tabla pasada por referencia se encontrara llena de los registros consultados
    End Sub

    ''' <summary>
    ''' Metodo que permite llenar una lista de objetos con los datos consultados en la base de datos
    ''' </summary>
    ''' <param name="tipoEntidad">El tipo del objeto que llama al metodo</param>
    ''' <param name="ListaEntidad">Una lista del tipo apropiado para guardar los datos</param>
    ''' <param name="query">La query a ejecutar</param>
    ''' <remarks></remarks>
    Public Sub llenarListaDeObjeto(tipoEntidad As Type, ByRef ListaEntidad As Object, query As String)
        'Creo un objeto para guardar los datos de la conexion SQL desde sus metodos apropiados
        Dim ConexionSQL As New clsConectorSql

        'El bloque using me permite ejecutar instrucciones y al finalizar se libera de memoria los objetos creados
        Using ConexionSQL.conector
            'Guardo las propiedades del tipo de objeto pasado por parametro
            Dim pEntidad() As PropertyInfo = tipoEntidad.GetProperties

            'Guardo la query y la conexion en el comando
            Dim Comando As MySqlCommand = New MySqlCommand(query, ConexionSQL.conector)

            Try
                'Si la conexion esta cerrada, la abro
                If ConexionSQL.conector.State = ConnectionState.Closed Then
                    ConexionSQL.conector.Open()
                End If

                'Creo un lector de datos
                Dim LectorDeDatos As MySqlDataReader
                'Ejecuto la consulta y lleno el DataReader
                LectorDeDatos = Comando.ExecuteReader

                'Campo para guardar en nombre al recorrer las propiedades
                Dim campoNombre As String

                'Mientras el lector de datos contenga datos a leer, se ejecuta el bucle
                While LectorDeDatos.Read
                    'Creo un nuevo objeto y por medio del Activator.CreateInstance(tipoEntidad), le digo al nuevo objeto de que tipo tendra que ser en base al pasado por parametro
                    Dim registro As Object = Activator.CreateInstance(tipoEntidad)

                    'Hago 2 bucles anidados para recorrer las propiedades del objeto y del DataReader
                    For columna = 0 To pEntidad.Length - 1
                        'Guardo el nombre de la propiedad
                        campoNombre = pEntidad(columna).Name

                        For campo = 0 To LectorDeDatos.FieldCount - 1
                            'Si en campo del DataReader coincide con el de la propiedad, entro
                            If campoNombre = LectorDeDatos.GetName(campo) Then
                                'A la propiedad que se esta consultando del objeto, le asigno el valor del campo de la columna del DataReader comparada
                                pEntidad(columna).SetValue(registro, LectorDeDatos.GetValue(campo))
                            End If
                        Next
                    Next

                    'Cuando se finaliza cada bucle anidado, agrego al listado pasado por parametros un nuevo registro con los datos
                    ListaEntidad.Add(registro)
                End While

                'Si surge un error del tipo SQL lanzo un mensaje con el error
            Catch er As MySqlException
                MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Ejecucion Query")

                'Si surge un error estandar
            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")

                'El finally se ejecuta si o si
            Finally
                'Cierro la conexion si esta abierta
                If ConexionSQL.conector.State = ConnectionState.Open Then
                    ConexionSQL.conector.Close()
                End If
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Metodo para ejecutar la consulta contra la base de datos segun el tipo de proceso declarado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EjecutarConsulta()
        'Creo un objeto para guardar la conexion
        Dim conexionSql As New MySqlConnection
        'Creo un objeto para guardar los datos de la consulta desde el App.config
        Dim cadenaConexion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("MySQL")

        'Si la cadena de conexion no es nada, le asigno el string al MySqlConnection
        If Not cadenaConexion Is Nothing Then
            conexionSql.ConnectionString = cadenaConexion.ConnectionString
        End If

        'Segun el tipo de proceso es lo que hara
        Select Case Me.ModoProceso
            Case TipoProceso.DataTable
                'Bloque using para liberar de memoria los objetos creados al final
                Using conexionSql
                    'Objeto adaptador para guardar la query y los datos de la conexion
                    Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter(QuerySQL, conexionSql)

                    Try
                        'Uso el metodo del adaptador y lleno la tabla
                        adaptador.Fill(_TablaDatos)

                        'Si surge algun error del tipo MySql
                    Catch er As MySqlException
                        MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Ejecucion Query")

                        'Si surge un error estandar
                    Catch ex As Exception
                        MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")
                    End Try
                End Using

                'Sirve para ver si se ha impactado en la base de datos
            Case TipoProceso.NonQuery
                'Bloque using para liberar de memoria los objetos creados al final
                Using conexionSql

                    'Objeto del tipo transaccion, para ejecutar la consulta contra la base de datos. Las transacciones son un conjunto de instrucciones SQL que tienen la cualidad de ejecutarse como una unidad, es decir, o se ejecutan todas o no se ejecuta ninguna.
                    Dim miTransaccion As MySqlTransaction
                    miTransaccion = Nothing

                    Try
                        'Abro la conexion
                        conexionSql.Open()
                        'Comienzo la transaccion hacia la base de datos. Desde aca si falla alguna instruccion no se guarda ningun cambio que se haya realizado en la base de datos
                        miTransaccion = conexionSql.BeginTransaction

                        'Le asigno las propiedades al comando
                        With Comando
                            'Los datos para la conexion a MySQL
                            .Connection = conexionSql
                            'La transaccion que se esta realizando
                            .Transaction = miTransaccion
                        End With

                        'Le asigno la query al comando si es que ya no tiene una
                        If Comando.CommandText = "" Then
                            Comando.CommandText = QuerySQL
                        End If

                        'Ejecuto la consulta y guardo las filas afectadas
                        _FilasAfectadas = Comando.ExecuteNonQuery

                        'Confirmo la transaccion para que se finalice
                        miTransaccion.Commit()

                    Catch er As MySqlException
                        MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Ejecucion Query")
                        'Si surge un error, vuelvo atras la transaccion
                        miTransaccion.Rollback()

                    Catch ex As Exception
                        MsgBox("Error: " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")
                        'Si surge un error, vuelvo atras la transaccion
                        miTransaccion.Rollback()

                    Finally
                        'Cierro la conexion
                        conexionSql.Close()
                    End Try
                End Using

            'Tipo de proceso que sirve para obtener el valor de la primer fila y primer columna del registro creado
            Case TipoProceso.Scalar
                'Bloque using para liberar de memoria los objetos creados al final
                Using conexionSql

                    Dim miTransaccion As MySqlTransaction
                    miTransaccion = Nothing

                    Try
                        conexionSql.Open()

                        miTransaccion = conexionSql.BeginTransaction

                        With Comando
                            .Connection = conexionSql
                            .Transaction = miTransaccion
                        End With

                        If Comando.CommandText = "" Then
                            Comando.CommandText = QuerySQL
                        End If

                        Comando.ExecuteScalar()

                        miTransaccion.Commit()

                        Comando.CommandText = "SELECT MAX(IdProducto) FROM productos;"
                        _IdNuevoRegistro = Comando.ExecuteScalar()

                    Catch er As MySqlException
                        MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Ejecucion Query")
                        'Si surge un error, vuelvo atras la transaccion
                        miTransaccion.Rollback()

                    Catch ex As Exception
                        MsgBox("Error: " & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")
                        'Si surge un error, vuelvo atras la transaccion
                        miTransaccion.Rollback()

                    Finally
                        'Cierro la conexion
                        conexionSql.Close()
                    End Try
                End Using
        End Select
    End Sub
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Funcion que permite ejecutar la query desde un comando SQL
    ''' </summary>
    ''' <param name="Comando">Objeto comando del tipo MySqlCommand con la query a ejecutar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Actualizar(ByVal Comando As MySqlCommand) As Int16
        'Creo un objeto de la clase conectorSql que me permitira llamar al conector y asignarle el string correspondiente a la direccion de la conexion a realizar
        Dim conexion As New clsConectorSql
        Dim registros As New Int16

        'Al objeto pasado como parametro le asigno el string de conexion correspondiente que se encuentra en la clase clsConectorSql
        Comando.Connection = conexion.conector

        Comando.Connection.Open()

        Try
            'Ejecuto la consulta con el ExecuteNonQuery y me devolvera la cantidad de filas afectadas que las guardo para mostrarlas luego
            registros = Comando.ExecuteNonQuery()

            'Si surge un error del tipo SQL
        Catch eq As MySqlException
            MsgBox("Error: " & eq.Message, MsgBoxStyle.Critical, "Ejecucion Query")

            'Si surge un error estandar
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Ejecucion Query")
        End Try

        'Cierro la conexion
        Comando.Connection.Close()

        'Devuelvo la cantidad de registros afectados
        Return registros
    End Function
#End Region
End Class