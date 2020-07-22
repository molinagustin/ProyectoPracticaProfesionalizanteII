Imports CapaDatos
Imports CapaNegocio
Imports MySql.Data
Public Class eTipoDocumento
#Region "Campos"
    Private _IdTipoDoc As Integer
    Private _TipoDoc As String
#End Region

#Region "Propiedades"
    Public Property IdTipoDoc As Integer
        Get
            Return _IdTipoDoc
        End Get
        Set(value As Integer)
            _IdTipoDoc = value
        End Set
    End Property

    Public Property TipoDoc As String
        Get
            Return _TipoDoc
        End Get
        Set(value As String)
            _TipoDoc = value
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Obtiene una lista de eTipoDocumento y la devuelve
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerTiposDocumentos() As List(Of eTipoDocumento)
        Dim listado As New List(Of eTipoDocumento)

        'Uso el constructor para obtener directamente el listado de tipo documento
        Dim lista As New clsEjecucionQuery(Me.GetType, listado, "SELECT * FROM tipos_documento;")

        Return listado
    End Function

    ''' <summary>
    ''' Obtiene un Tipo de Documento
    ''' </summary>
    ''' <param name="Id">Numero de ID del tipo de documento</param>
    ''' <returns></returns>
    Public Function ObtenerTipoDocumento(Id As Integer) As eTipoDocumento
        Dim documento As New eTipoDocumento
        Dim registro As New clsEjecucionQuery()

        registro.obtenerRegistro(documento, "SELECT * FROM tipos_documento WHERE IdTipoDoc = " & Id)

        Return documento
    End Function
#End Region
End Class
