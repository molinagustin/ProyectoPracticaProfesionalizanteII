Imports System.Reflection 'Esta libreria me otorga clases para poder consultar objetos y sus propiedades
Imports MySql.Data.MySqlClient 'Libreria que me permite obtener clases para acceder a la base de datos de MySQL
Public Class clsArmadoQuery
#Region "Campos"
    Dim _flag As Boolean = False
#End Region

#Region "Propiedades"
    Public Property Flag As Boolean
        Get
            Return _flag
        End Get
        Set(value As Boolean)
            _flag = value
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Funcion para insertar un nuevo registro en la base de datos
    ''' </summary>
    ''' <param name="objetoConDatos">El objeto que contiene las propiedades y valores a insertar</param>
    ''' <param name="tabla">El nombre de la tabla donde se insertara el registro</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function insertarNuevoRegistro(ByRef objetoConDatos As Object, tabla As String) As MySqlCommand
        Dim comando As New MySqlCommand
        Dim query1 As String = "INSERT INTO " & tabla & "("
        Dim query2 As String = " VALUES ("

        Dim tipoObjetos As Type = objetoConDatos.GetType

        Dim propiedadesObjeto() As PropertyInfo = tipoObjetos.GetProperties

        For i = 1 To propiedadesObjeto.Length - 1
            'Se instancian el valor, el nombre de la propiedad y el tipo para tener una mayor legibilidad
            Dim Valor, NombreProp, TipoProp As Object
            Valor = propiedadesObjeto(i).GetValue(objetoConDatos)
            NombreProp = propiedadesObjeto(i).Name
            TipoProp = propiedadesObjeto(i).PropertyType

            'Si la query esta por terminar se coloca un parentesis y si continua se coloca una coma

            If i = propiedadesObjeto.Length - 1 Then
                query1 += NombreProp & ")"
                query2 += "@" & NombreProp & ")"
            Else
                query1 += NombreProp & ", "
                query2 += "@" & NombreProp & ", "
            End If

            'Se agregan los parametros de la query con sus respectivos valores y sus tipos
            Select Case (TipoProp)
                Case GetType(String)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.VarChar)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Int32), GetType(Integer)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.Int32)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Int16), GetType(Short)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.Int16)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Int64), GetType(Long)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.Int64)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Date)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.Date)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(DateTime)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.DateTime)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Boolean)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.Bit)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Char)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.VarChar)
                    comando.Parameters("@" & NombreProp).Value = Valor
                Case GetType(Double)
                    comando.Parameters.Add("@" & NombreProp, MySqlDbType.Double)
                    comando.Parameters("@" & NombreProp).Value = Valor
            End Select
        Next

        'Se agrega la query al comando
        comando.CommandText = query1 + query2

        Return comando
    End Function

    ''' <summary>
    ''' Funcion para actualizar un objeto de la base de datos en base a la comparacion de sus propiedades
    ''' </summary>
    ''' <param name="objetoOriginal">El objeto que contiene los datos originales</param>
    ''' <param name="ObjetoNuevo">El objeto con datos actualizados</param>
    ''' <param name="Tabla">El nombre de la tabla donde se actualizara el registro</param>
    ''' <param name="ID">El nombre de la columna de la clave principal</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function actualizarRegistro(ByRef ObjetoOriginal As Object, ByRef ObjetoNuevo As Object, Tabla As String, ID As String) As MySqlCommand
        Dim Query As String = "UPDATE " & Tabla & " SET "
        Dim Comando As New MySqlCommand

        Dim flag As Boolean = False

        Dim tipoObjOriginal As Type = ObjetoOriginal.GetType
        Dim tipoObjNuevo As Type = ObjetoNuevo.GetType

        'Comparo que los objetos sean iguales
        If tipoObjOriginal = tipoObjNuevo Then
            Dim propObjOriginal() As PropertyInfo = tipoObjOriginal.GetProperties
            Dim propObjNuevo() As PropertyInfo = tipoObjNuevo.GetProperties
            Dim ValorId As Integer

            'Busco dentro de las propiedades del objeto original
            For Each prop In propObjOriginal
                'Al encontrar la propiedad ID, comparo que en ambos objetos sea el mismo valor
                If prop.Name = ID Then
                    'Recorriendo las propiedades del objeto nuevo, encuentro la propiedad que se llame como el Id
                    For Each propN In propObjNuevo
                        If propN.Name = ID Then
                            If prop.GetValue(ObjetoOriginal) = propN.GetValue(ObjetoNuevo) Then
                                'Guardo el valor del ID
                                ValorId = prop.GetValue(ObjetoOriginal)
                                'Salgo del For
                                Exit For
                            Else
                                Throw New Exception("Los objetos a comparar no poseen el mismo ID")
                            End If
                        End If
                    Next
                    'Salgo del bucle
                    Exit For
                End If
            Next

            'Recorro las propiedades comparando los valores en ambos objetos
            For i = 0 To propObjOriginal.Length - 1
                'Objetos para los valores
                Dim DatoOrig, DatoNuevo As Object

                DatoOrig = propObjOriginal(i).GetValue(ObjetoOriginal)
                DatoNuevo = propObjNuevo(i).GetValue(ObjetoNuevo)

                Dim nomPropOrig As String = propObjOriginal(i).Name

                'Si encuentro la propiedad ID no la tomo en cuenta y recorro un nuevo bucle
                If nomPropOrig = ID Then
                    Continue For
                End If

                'Comparo los valores en la propiedad de ambos objetos, si son distintos entro
                If Not DatoOrig = DatoNuevo Then
                    Me.Flag = True

                    Query += nomPropOrig & " = " & "@" & nomPropOrig & ","

                    'Guardo el tipo de propiedad
                    Dim TipoProp As Object
                    TipoProp = propObjOriginal(i).PropertyType

                    'Comparo de que tipo es el valor encontrado para formatearlo
                    Select Case (TipoProp)
                        Case GetType(String)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.VarChar)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Int32), GetType(Integer)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.Int32)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Int16), GetType(Short)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.Int16)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Int64), GetType(Long)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.Int64)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Date)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.Date)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(DateTime)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.DateTime)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Boolean)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.Bit)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Char)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.VarChar)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                        Case GetType(Double)
                            Comando.Parameters.Add("@" & nomPropOrig, MySqlDbType.Double)
                            Comando.Parameters("@" & nomPropOrig).Value = DatoNuevo
                    End Select
                End If
            Next

            'Recorto el string creado porque le queda 1 coma al final
            Query = Query.Substring(0, Query.Length - 1)
            'Agrego el filtro WHERE con el ID guardado
            Query += " WHERE " & ID & " = " & ValorId & ";"

            'Se la asigno al comando
            Comando.CommandText = Query
        Else
            Throw New Exception("Los objetos pasados no son del mismo tipo")
        End If

        'Devuelvo el comando creado
        Return Comando
    End Function

    ''' <summary>
    ''' Funcion que permite consultar un registro de una tabla
    ''' </summary>
    ''' <param name="tabla">El nombre de la tabla a consultar</param>
    ''' <param name="campoId">El nombre del campo de la clave principal o ID de la tabla</param>
    ''' <param name="numeroId">El numero de ID del registro a consultar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultaRegistro(tabla As String, campoId As String, numeroId As Integer) As String
        'Creo un objeto string para armar la query y devolverla
        Dim query As String = "SELECT * FROM " & tabla & " WHERE " & campoId & " = " & numeroId & ";"
        Return query
    End Function

    ''' <summary>
    ''' Funcion que permite consultar todos los registros de una tabla
    ''' </summary>
    ''' <param name="tabla">El nombre de la tabla a consultar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultarRegistros(tabla As String) As String
        'Armo la query generica con la tabla pasada
        Dim query As String = "SELECT * FROM " & tabla
        Return query
    End Function

    ''' <summary>
    ''' Funcion que trae todos los registros activos de una tabla de la base de datos
    ''' </summary>
    ''' <param name="tabla">Nombre de la tabla a consultar</param>
    ''' <returns></returns>
    Public Function consultarRegistrosActivos(tabla As String) As String
        'Armo la query generica con la tabla pasada y que solo se muestren los registros activos
        Dim query As String = "SELECT * FROM " & tabla & " WHERE Activo = 1;"
        Return query
    End Function

    ''' <summary>
    ''' Funcion me trae todos los registros asociados a un ID foraneo de la misma tabla
    ''' </summary>
    ''' <param name="tabla">El nombre de la tabla principal</param>
    ''' <param name="tablaForanea">El nombre de la columna con el ID foraneo en la tabla principal</param>
    ''' <param name="numeroIdForaneo">El numero de ID del registro asociado a la tabla principal</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultarRegistrosCompleto(tabla As String, tablaForanea As String, numeroIdForaneo As Integer) As String
        'Armo la query y la devuelvo
        Dim query As String = "SELECT * FROM " & tabla & " WHERE " & tablaForanea & " = " & numeroIdForaneo & ";"
        Return query
    End Function
#End Region
End Class
