Imports CapaDatos
Public Class eInforme
#Region "Metodos"
    ''' <summary>
    ''' Metodo que devuelve la cantidad de clientes cargados agrupados por condicion IVA
    ''' </summary>
    ''' <param name="tabla">Tabla a llenar de datos</param>
    Public Sub obtenerClientesIVA(ByRef tabla As DataTable)
        Dim ejecucion As New clsEjecucionQuery
        Dim query As String = "SELECT COUNT( clientes.IdCliente) AS IdCliente, condiciones_iva.Descripcion FROM clientes, condiciones_iva WHERE clientes.Activo = 1 AND clientes.CondicionIva = condiciones_iva.IdCondicion GROUP BY Descripcion;"

        ejecucion.obtenerRegistros(tabla, query)
    End Sub

    ''' <summary>
    ''' Metodo que devuelve las ventas realizadas en un rango de fechas
    ''' </summary>
    ''' <param name="tabla">Tabla a llenar de datos</param>
    ''' <param name="fechaD">Fecha desde donde se quiere consultar</param>
    ''' <param name="fechaH">Fecha hasta cuando se quiere consultar</param>
    Public Sub obtenerVentasFecha(ByRef tabla As DataTable, fechaD As Date, fechaH As Date)
        Dim ejecucion As New clsEjecucionQuery
        Dim query As String = "SELECT cuerpo_comprobantes.IdCuerpo, encabezado_comprobantes.Fecha, encabezado_comprobantes.ComprobanteCompleto, productos.NombreProducto, cuerpo_comprobantes.Cantidad, cuerpo_comprobantes.BonificacionTotal, cuerpo_comprobantes.Total FROM encabezado_comprobantes, productos, cuerpo_comprobantes WHERE encabezado_comprobantes.NumComprobante = cuerpo_comprobantes.NumeroComprobante AND cuerpo_comprobantes.ProductoServicio = productos.IdProducto AND encabezado_comprobantes.Fecha BETWEEN '" & fechaD.ToString("yyyy/MM/dd") & "' AND '" & fechaH.ToString("yyyy/MM/dd") & "' ORDER BY encabezado_comprobantes.Fecha;"

        ejecucion.obtenerRegistros(tabla, query)
    End Sub

    ''' <summary>
    ''' Metodo que permite obtener la cantidad de productos vendidos en un rango de fechas
    ''' </summary>
    ''' <param name="tabla">Tabla para obtener los datos</param>
    ''' <param name="fechaD">Fecha desde donde se quiere consultar</param>
    ''' <param name="fechaH">Fecha hasta cuando se quiere consultar</param>
    Public Sub obtenerEstadisticaVentas(ByRef tabla As DataTable, fechaD As Date, fechaH As Date)
        Dim ejecucion As New clsEjecucionQuery
        Dim query As String = "SELECT productos.NombreProducto as Producto, ROUND(sum(cuerpo_comprobantes.Cantidad), 2) as Cantidad FROM encabezado_comprobantes, productos, cuerpo_comprobantes WHERE encabezado_comprobantes.NumComprobante = cuerpo_comprobantes.NumeroComprobante AND cuerpo_comprobantes.ProductoServicio = productos.IdProducto  AND encabezado_comprobantes.Fecha BETWEEN '" & fechaD.ToString("yyyy/MM/dd") & "' AND '" & fechaH.ToString("yyyy/MM/dd") & "' GROUP BY productos.NombreProducto ORDER BY productos.NombreProducto;"

        ejecucion.obtenerRegistros(tabla, query)
    End Sub

    ''' <summary>
    ''' Metodo que devuelve todos los clientes activos
    ''' </summary>
    ''' <param name="tabla">Tabla a llenar de datos</param>
    Public Sub obtenerClientesActivos(ByRef tabla As DataTable)
        Dim ejecucion As New clsEjecucionQuery
        ejecucion.obtenerRegistros(tabla, "SELECT * FROM clientes WHERE Activo = 1")
    End Sub

    ''' <summary>
    ''' Metodo que devuelve todas las condiciones de IVA cargadas
    ''' </summary>
    ''' <param name="tabla">Tabla a llenar de datos</param>
    Public Sub obtenerCondicionesIVA(ByRef tabla As DataTable)
        Dim ejecucion As New clsEjecucionQuery
        ejecucion.obtenerRegistros(tabla, "SELECT * FROM condiciones_iva")
    End Sub

    ''' <summary>
    ''' Metodo que devuelve todos los tipos de documentos cargados
    ''' </summary>
    ''' <param name="tabla">Tabla a llenar de datos</param>
    Public Sub obtenerTiposDoc(ByRef tabla As DataTable)
        Dim ejecucion As New clsEjecucionQuery
        ejecucion.obtenerRegistros(tabla, "SELECT * FROM tipos_documento")
    End Sub
#End Region
End Class
