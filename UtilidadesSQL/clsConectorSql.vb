Imports MySql.Data.MySqlClient
Imports System.Configuration 'Esta libreria contiene clases variadas necesarias en muchos casos
Public Class clsConectorSql
    'Con esta clase solo armaremos un sql conection y lo devolvera
#Region "Campos"
    Private _conector As New MySqlConnection
#End Region

#Region "Propiedad"
    Public ReadOnly Property conector As MySqlConnection
        Get
            Return _conector
        End Get
    End Property
#End Region

#Region "Constructor"
    'Este metodo es para objetos nuevos. Preguntara si el conector tiene un string asignado, sino se lo asigna
    Public Sub New()
        If _conector.ConnectionString = Nothing Then
            asignarCadenaConexion()
        End If
    End Sub
#End Region

#Region "Metodo"
    Private Sub asignarCadenaConexion()
        Try
            'A la configuracion de la cadenaConexion creada, le asignamos en su configuracion que el string de conexion sera el "MySQL"
            Dim cadenaConexion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("MySQL")

            'Le asignamos la cadena de conexion al conector previamente creado
            If Not cadenaConexion Is Nothing Then
                _conector.ConnectionString = cadenaConexion.ConnectionString
            End If

        Catch er As MySqlException
            MsgBox("Error: " & er.Message, MsgBoxStyle.Critical, "Conector MySQL")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Conector MySQL")
        End Try
    End Sub
#End Region
End Class
