Imports entProducto
Imports entRubro
Imports entProveedor
Imports entUnidadMedida
Imports entStock
Public Class frmVistaProductos
#Region "Campos"
    Public Enum TipoBusq
        NOMBRE
        PROVEEDOR
        RUBRO
    End Enum

    'Para la busqueda en el CBO
    Private _TipoBusqueda As TipoBusq

    Private _IdPd As Integer = -1

    'Lista para todos los productos
    Dim lista As New List(Of eProducto)

    'Objeto para obtener los proveedores
    Dim pro As New eProveedor

    'Objeto para obtener los rubros
    Dim rub As New eRubro
#End Region

#Region "Propiedades"
    Public Property TipoBusqueda As TipoBusq
        Get
            Return _TipoBusqueda
        End Get
        Set(value As TipoBusq)
            _TipoBusqueda = value
        End Set
    End Property

    Public Property IdPd As Integer
        Get
            Return _IdPd
        End Get
        Set(value As Integer)
            _IdPd = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmVistaProductos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Asigno los valores al CBO
            With cboTipoBusqueda
                .DataSource = [Enum].GetValues(GetType(TipoBusq))
            End With

            'Cambio el tamaño de la fuente del encabezado de las columnas
            dgvListadoProductos.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 15, FontStyle.Bold)

            'Actualizo el DGV
            ActualizarDGV()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Cierro el formulario
        Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'Creo un objeto nuevo
        Dim nuevoPd As New frmGestionProductos

        'Le asigno las propiedades y lo muestro como objeto de dialogo
        With nuevoPd
            .Text = "ALTA DE PRODUCTO"
            .TipoFormulario = frmGestionProductos.TipoFormu.Nuevo
            .ShowDialog()
            If .DialogResult = DialogResult.OK Then
                'Actualizo el DGV
                ActualizarDGV()
            End If
        End With
    End Sub

    'Evento que se lanza al realizar un cambio en las celdas del DGV (darle otro formato por ejemplo)
    Private Sub dgvListadoProductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListadoProductos.CellFormatting
        'Para la columna rubros
        If dgvListadoProductos.Columns(e.ColumnIndex).Name.Equals("Rubro") Then
            'Obtengo una lista de todos los rubros
            Dim rub As New eRubro
            Dim listaR As List(Of eRubro) = rub.ObtenerRubros()

            'Recorro la lista y la comparo con el contenido de la celda del DGV
            For Each list In listaR
                'Si son iguales, cambio el valor numerico (ID) por el nombre
                If list.IdRubro = CInt(e.Value) Then
                    e.Value = list.NombreRubro
                    Exit For
                End If
            Next
        End If

        'Para la columna proveedores
        If dgvListadoProductos.Columns(e.ColumnIndex).Name.Equals("Proveedor") Then
            'Obtengo una lista de todos los proveedores
            Dim prov As New eProveedor
            Dim listaP As List(Of eProveedor) = prov.ObtenerProveedores()

            'Recorro la lista y la comparo con el contenido de la celda del DGV
            For Each list In listaP
                'Si son iguales, cambio el valor numerico (ID) por el nombre
                If list.IdProveedor = CInt(e.Value) Then
                    e.Value = list.NombreProveedor
                    Exit For
                End If
            Next
        End If

        'Para la columna unidades medida
        If dgvListadoProductos.Columns(e.ColumnIndex).Name.Equals("UnidadMedida") Then
            'Obtengo una lista de todos las unidades de medida
            Dim uni As New eUnidadMedida
            Dim listaU As List(Of eUnidadMedida) = uni.ObtenerUnidadesMedidas()

            'Recorro la lista y la comparo con el contenido de la celda del DGV
            For Each list In listaU
                'Si son iguales, cambio el valor numerico (ID) por el nombre
                If list.IdUnidadMedida = CInt(e.Value) Then
                    e.Value = list.TipoUnidad
                    Exit For
                End If
            Next
        End If

        'Entro cuando encuentre la columna Precio Costo
        If dgvListadoProductos.Columns(e.ColumnIndex).Name.Equals("PrecioCosto") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Currency
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("C2")
        End If

        'Entro cuando encuentre la columna Precio Final
        If dgvListadoProductos.Columns(e.ColumnIndex).Name.Equals("PrecioFinal") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Currency
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("C2")
        End If

        'Para la columna stock
        If dgvListadoProductos.Columns(e.ColumnIndex).Name.Equals("StockExistencia") Then
            'Obtengo una lista del stock
            Dim st As New eStock
            Dim listaSt As List(Of eStock) = st.ObtenerTodosStocks()

            'Recorro la lista y comparo que el valor de la clave foranea en el Stock sea igual al Id del producto
            For Each list In listaSt
                'Si son iguales, cambio el valor numerico (ID) por el valor de stock
                If list.IdProdStock = dgvListadoProductos.Rows(e.RowIndex).Cells(1).Value Then
                    e.Value = list.StockExistencia
                    Exit For
                End If
            Next
        End If
    End Sub

    'Evento al hacer doble click sobre una celda del DGV
    Private Sub dgvListadoProductos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListadoProductos.CellMouseDoubleClick
        'Compruebo que haya al menos 1 fila
        If e.RowIndex > -1 Then
            'Guardo el valor del Id de la fila seleccionada
            IdPd = dgvListadoProductos.Rows(e.RowIndex).Cells(1).Value

            'Creo un objeto nuevo
            Dim nuevoPd As New frmGestionProductos

            'Le asigno las propiedades y lo muestro como dialogo
            With nuevoPd
                .IdPro = IdPd
                .Text = "CONSULTA DE PRODUCTO"
                .TipoFormulario = frmGestionProductos.TipoFormu.Consulta
                .ShowDialog()
                If .DialogResult = DialogResult.OK Then
                    'Actualizo el DGV
                    ActualizarDGV()
                End If
            End With
        End If
    End Sub

    'Evento al terminar de enlazar los datos con el DGV
    Private Sub dgvListadoProductos_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvListadoProductos.DataBindingComplete
        'Se borra la seleccion actual
        dgvListadoProductos.ClearSelection()
    End Sub

    'Evento cuando se cambia el contenido del TXT
    Private Sub txtBuscador_TextChanged() Handles txtBuscador.TextChanged
        'Verifico que tenga contenido para buscar en el TXT
        If txtBuscador.Text.Trim() IsNot "" Then
            If cboTipoBusqueda.SelectedItem = TipoBusq.NOMBRE Then
                'Busco en el listado de eProductos, aquellos que contengas letras o palabras escritas en el txtBuscador
                dgvListadoProductos.DataSource = lista.FindAll(Function(x) x.NombreProducto.ToLower.Contains(txtBuscador.Text.ToLower.Trim()))

                'Busqueda por proveedor
            ElseIf cboTipoBusqueda.SelectedItem = TipoBusq.PROVEEDOR Then
                'Llamo al metodo correspondiente
                buscarPorProveedor()

                'Busqueda por rubro
            ElseIf cboTipoBusqueda.SelectedItem = TipoBusq.RUBRO Then
                'Llamo al metodo correspondiente
                buscarPorRubro()
            End If
        Else
                'Sino le asigo el listado sin filtrar nuevamente al DGV
                dgvListadoProductos.DataSource = lista.OrderBy(Function(x) x.NombreProducto).ToList
        End If
    End Sub

    'Evento al presionar una tecla sobre el cbo
    Private Sub cboTipoBusqueda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoBusqueda.KeyPress
        'No dejo escribir en el cbo
        e.Handled = True
    End Sub

    'Evento al cambiar la seleccion del cbo
    Private Sub cboTipoBusqueda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoBusqueda.SelectedValueChanged
        'Llamo al evento para que busque
        txtBuscador_TextChanged()
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Metodo que sirve para consultar la base de datos y llenar el DGV con los registros encontrados
    ''' </summary>
    Public Sub ActualizarDGV()
        'Creo nuevo objeto para llenar de datos
        Dim producto As New eProducto

        'Lleno la lista instanciada al principio
        lista = producto.ObtenerProductos()

        'Creo una funcion lambda donde asigno como parametro un objeto del tipo eProducto ("x") y que obtena el nombre del producto
        'Se la asigno al DGV
        dgvListadoProductos.DataSource = lista.OrderBy(Function(x) x.NombreProducto).ToList

        'Limpio la primer fila seleccionada
        dgvListadoProductos.ClearSelection()
    End Sub

    ''' <summary>
    ''' Metodo para realizar la busqueda por proveedor
    ''' </summary>
    Public Sub buscarPorProveedor()
        'Lista para los proveedores
        Dim listaProv As List(Of eProveedor) = pro.ObtenerProveedores()

        'Encuentro todos los proveedores que coincidan con lo escrito en el buscador
        listaProv = listaProv.FindAll(Function(p) p.NombreProveedor.ToLower.Contains(txtBuscador.Text.ToLower.Trim))

        'Creo una lista para guardar los objetos que coincidan con las comparaciones
        Dim listaFinal As New List(Of eProducto)

        'Recorro la lista de productos
        For Each listProducto In lista
            'Recorro la lista de proveedores filtrados
            For Each listProve In listaProv
                'Cuando el ID del proveedor en el producto coincida con el ID del proveedor en su lista entra 
                If listProducto.Proveedor = listProve.IdProveedor Then
                    'En la lista de productos finales agrago el producto que coincidio con el proveedor
                    listaFinal.Add(listProducto)
                    Exit For
                End If
            Next
        Next

        'Le asigno la lista al dgv
        dgvListadoProductos.DataSource = listaFinal.OrderBy(Function(x) x.NombreProducto).ToList
    End Sub

    ''' <summary>
    ''' Metodo para realizar la busqueda por rubro
    ''' </summary>
    Public Sub buscarPorRubro()
        'Lista para los rubros
        Dim listaRub As List(Of eRubro) = rub.ObtenerRubros()

        'Encuentro todos los rubros que coincidan con lo escrito en el buscador
        listaRub = listaRub.FindAll(Function(r) r.NombreRubro.ToLower.Contains(txtBuscador.Text.ToLower.Trim))

        'Creo una lista para guardar los objetos que coincidan con las comparaciones
        Dim listaFinal As New List(Of eProducto)

        'Recorro la lista de productos
        For Each listProducto In lista
            'Recorro la lista de rubros filtrados
            For Each listRub In listaRub
                'Cuando el ID del rubro en el producto coincida con el ID del rubro en su lista entra 
                If listProducto.Rubro = listRub.IdRubro Then
                    'En la lista de productos finales agrago el producto que coincidio con el rubro
                    listaFinal.Add(listProducto)
                    Exit For
                End If
            Next
        Next

        'Le asigno la lista al dgv
        dgvListadoProductos.DataSource = listaFinal.OrderBy(Function(x) x.NombreProducto).ToList
    End Sub
#End Region
End Class
