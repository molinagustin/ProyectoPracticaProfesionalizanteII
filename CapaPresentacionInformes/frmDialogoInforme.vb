Imports entInformes
Public Class frmDialogoInforme
#Region "Campos"
    Public Enum tipoInfo
        CLIENTES
        VENTAS
    End Enum

    'Campos para el tipo de informe y las fechas necesarias
    Private _TipoInforme As tipoInfo
    Private _fechaD, _fechaH As New Date

    'Tablas para llenar con los datos hacia los archivos XML y el objeto para realizar las consultas
    Dim ds As New DataSet
    Dim tabla1, tabla2, tabla3 As New DataTable
    Dim obtener As New eInforme
#End Region

#Region "Propiedades"
    Public Property TipoInforme As tipoInfo
        Get
            Return _TipoInforme
        End Get
        Set(value As tipoInfo)
            _TipoInforme = value
        End Set
    End Property

    Public Property FechaD As Date
        Get
            Return _fechaD
        End Get
        Set(value As Date)
            _fechaD = value
        End Set
    End Property

    Public Property FechaH As Date
        Get
            Return _fechaH
        End Get
        Set(value As Date)
            _fechaH = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmDialogoInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TipoInforme = tipoInfo.CLIENTES Then
            informeClientes()

            'Creo un objeto del tipo de reporte para clientes
            Dim rep As New ReporteClient

            'Se lo asigno como fuente de visualizacion al CRP
            crpInformes.ReportSource = rep

        ElseIf TipoInforme = tipoInfo.VENTAS Then
            informeVentas()

            'Creo un objeto del tipo de reporte para ventas
            Dim rep As New ReporteVentas


            'Se lo asigno como fuente de visualizacion al CRP
            crpInformes.ReportSource = rep
        End If

        'Actualizo el Crystal Report Viewer
        crpInformes.RefreshReport()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Cierro el formulario
        Close()
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Realiza y muestra un informe de los clientes
    ''' </summary>
    Public Sub informeClientes()
        'Obtengo en cada tabla los datos necesarios para guardar en los archivos XML
        With obtener
            .obtenerClientesActivos(tabla1)
            .obtenerCondicionesIVA(tabla2)
            .obtenerTiposDoc(tabla3)
        End With

        'Guardo las tablas en el DataSet y escribo un nuevo archivo XML con cada una de ellas
        With ds
            .Tables.Add(tabla1)
            .WriteXml("D:\\Documentos\\Visual Studio 2015\\Projects\\ProyectoPracticaProfesionalizanteII\\Archivos XML\\clientes.xml", XmlWriteMode.WriteSchema)
            .Tables.Remove(tabla1)

            .Tables.Add(tabla2)
            .WriteXml("D:\\Documentos\\Visual Studio 2015\\Projects\\ProyectoPracticaProfesionalizanteII\\Archivos XML\\condiciones_iva.xml", XmlWriteMode.WriteSchema)
            .Tables.Remove(tabla2)

            .Tables.Add(tabla3)
            .WriteXml("D:\\Documentos\\Visual Studio 2015\\Projects\\ProyectoPracticaProfesionalizanteII\\Archivos XML\\tipos_documento.xml", XmlWriteMode.WriteSchema)
        End With
    End Sub

    ''' <summary>
    ''' Realiza y muestra un informe de las ventas realizadas entre 2 fechas
    ''' </summary>
    Public Sub informeVentas()
        'Obtengo en la tabla los datos necesarios para guardar en el archivo XML
        obtener.obtenerVentasFecha(tabla1, FechaD, FechaH)

        'Guardo la tabla en el DataSet y escribo un nuevo archivo XML
        With ds
            .Tables.Add(tabla1)
            .WriteXml("D:\\Documentos\\Visual Studio 2015\\Projects\\ProyectoPracticaProfesionalizanteII\\Archivos XML\\ventasPorFecha.xml", XmlWriteMode.WriteSchema)
        End With
    End Sub
#End Region
End Class