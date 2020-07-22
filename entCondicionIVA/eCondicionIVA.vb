Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eCondicionIVA

#Region "Campos"
    Private _IdCondicion As Integer
    Private _Descripcion As String
#End Region

#Region "Propiedades"
    Public Property IdCondicion As Integer
        Get
            Return _IdCondicion
        End Get
        Set(value As Integer)
            _IdCondicion = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eCondicionIVA y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerCondicionesIVA() As List(Of eCondicionIVA)
        Dim listado As New List(Of eCondicionIVA)

        'Uso el constructor para obtener directamente el listado de condiciones IVA
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM condiciones_iva;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una condicion de IVA y la devuelve
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Function ObtenerCondicion(Id As Integer) As eCondicionIVA
        Dim condicion As New eCondicionIVA

        'Creo un nuevo objeto con el constructor vacio
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(condicion, "SELECT * FROM condiciones_iva WHERE IdCondicion = " & Id)

        Return condicion
    End Function
#End Region
End Class
