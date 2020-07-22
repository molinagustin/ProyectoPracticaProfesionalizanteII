Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eUnidadMedida
#Region "Campos"
    Private _IdUnidadMedida As Integer
    Private _TipoUnidad As String
#End Region

#Region "Propiedades"
    Public Property IdUnidadMedida As Integer
        Get
            Return _IdUnidadMedida
        End Get
        Set(value As Integer)
            _IdUnidadMedida = value
        End Set
    End Property

    Public Property TipoUnidad As String
        Get
            Return _TipoUnidad
        End Get
        Set(value As String)
            _TipoUnidad = value
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eUnidadMedida y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerUnidadesMedidas() As List(Of eUnidadMedida)
        Dim listado As New List(Of eUnidadMedida)

        'Uso el constructor para obtener directamente el listado de unidades medida
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM unidades_medida ORDER BY IdUnidadMedida;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene una unidad de medida y la devuelve
    ''' </summary>
    ''' <param name="Id">Numero de ID de la unidad de medida</param>
    ''' <returns></returns>
    Public Function ObtenerUnidadMedida(Id As Integer) As eUnidadMedida
        Dim unidadMedida As New eUnidadMedida
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(unidadMedida, "SELECT * FROM unidades_medida WHERE IdUnidadMedida = " & Id)

        Return unidadMedida
    End Function
#End Region
End Class
