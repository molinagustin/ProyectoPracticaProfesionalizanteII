Imports CapaDatos
Public Class eProvincia
#Region "Campos"
    Private _IdProvincia As Integer
    Private _NombreProvincia As String
#End Region

#Region "Propiedades"
    Public Property IdProvincia As Integer
        Get
            Return _IdProvincia
        End Get
        Set(value As Integer)
            _IdProvincia = value
        End Set
    End Property

    Public Property NombreProvincia As String
        Get
            Return _NombreProvincia
        End Get
        Set(value As String)
            _NombreProvincia = value
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eProvincia y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerProvincias() As List(Of eProvincia)
        Dim listado As New List(Of eProvincia)
        'Uso el constructor para obtener directamente el listado de provincias
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM provincias;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una provincia y la devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID de la provincia</param>
    ''' <returns></returns>
    Public Function ObtenerProvincia(Id As Integer) As eProvincia
        Dim provincia As New eProvincia
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(provincia, "SELECT * FROM provincias WHERE IdProvincia = " & Id)

        Return provincia
    End Function
#End Region
End Class
