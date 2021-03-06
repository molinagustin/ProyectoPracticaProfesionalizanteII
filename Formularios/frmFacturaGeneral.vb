﻿Imports ParaPuppeteer
Imports entProducto
Imports Facturas
Imports entUnidadMedida
Imports entUsuarioAFIP
Imports entTipoDocumento
Imports entCondicionIVA
Imports entCliente
Imports entTarjeta
Imports entStock
Imports CapaPresentacionClientes
Imports System.Management

Public Class frmFacturaGeneral
#Region "Campos"
    'Clase para poder utilizar el puppeteer y sus correspondientes propiedades
    Private facturador As New clsFacturador

    Private _Encabezado As New eEncabezadoComprobante
    'Listas para añadir los datos al cuerpo del comprobante y traer la lista de productos
    Private _ListaItems As New List(Of eCuerpoComprobante)
    Private _ListaProductos As New List(Of eProducto)

    Private _FechaFac As Date = Today.Date
    Private _NroDoc As String
    Private _IdProdSelec As Integer = -1
    Private _IdClien As Integer = -1
    Private _Cliente As New eCliente

    'Creo una bandera para utilizar en el cbo de productos
    Dim flag As Integer = 0
#End Region

#Region "Propiedades"

    Public Property ListaItems As List(Of eCuerpoComprobante)
        Get
            Return _ListaItems
        End Get
        Set(value As List(Of eCuerpoComprobante))
            _ListaItems = value
        End Set
    End Property

    Public Property ListaProductos As List(Of eProducto)
        Get
            Return _ListaProductos
        End Get
        Set(value As List(Of eProducto))
            _ListaProductos = value
        End Set
    End Property

    Public Property FechaFac As String
        Get
            Return _FechaFac
        End Get
        Set(value As String)
            _FechaFac = value
        End Set
    End Property

    Public Property NroDoc As String
        Get
            Return _NroDoc
        End Get
        Set(value As String)
            _NroDoc = value
        End Set
    End Property

    Public Property IdProdSelec As Integer
        Get
            Return _IdProdSelec
        End Get
        Set(value As Integer)
            _IdProdSelec = value
        End Set
    End Property

    Public Property IdClien As Integer
        Get
            Return _IdClien
        End Get
        Set(value As Integer)
            _IdClien = value
        End Set
    End Property

    Public Property Encabezado As eEncabezadoComprobante
        Get
            Return _Encabezado
        End Get
        Set(value As eEncabezadoComprobante)
            _Encabezado = value
        End Set
    End Property

    Public Property Cliente As eCliente
        Get
            Return _Cliente
        End Get
        Set(value As eCliente)
            _Cliente = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Async Sub frmFacturaGeneral_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            IsRunning("chrome")
            'Creo un objeto para los productos
            Dim producto As New eProducto
            'Guardo en la propiedad el listaod de todos los productos
            ListaProductos = producto.ObtenerProductos()

            'Le asigno las propiedades al cbo
            With cboProductoServicio
                .Text = ""
                .DataSource = producto.ObtenerProductos
                .ValueMember = "Idproducto"
                .DisplayMember = "NombreProducto"
                .SelectedValue = 0
            End With

            'Con un objeto de tipo documento
            Dim tipo As New eTipoDocumento

            'Le asigno sus propiedades
            With cboTipoDoc
                .DataSource = tipo.ObtenerTiposDocumentos
                .ValueMember = "IdTipoDoc"
                .DisplayMember = "TipoDoc"
                .SelectedValue = 6
            End With

            'Creo un objeto para las condiciones IVA
            Dim condicion As New eCondicionIVA

            'Le asigno las propiedades al cbo
            With cboCondicionIva
                .DataSource = condicion.ObtenerCondicionesIVA
                .ValueMember = "IdCondicion"
                .DisplayMember = "Descripcion"
                .SelectedValue = 3
            End With

            'Se define la fecha maxima y la minima para el control de la fecha
            dtpFechaFactura.MaxDate = Today
            dtpFechaFactura.MinDate = Today.AddDays(-5)

            'Muestro la cantidad de productos a incluir inicialmente
            txtCantidad.Text = 1
            'Muestro la bonificacion nula
            txtBonificacion.Text = 0

            'Marco el radiobutton contado
            rbtContado.Checked = True

            'Creo un objeto para obtener los usuarios y una lista de estos
            Dim Usuario As New eUsuarioAfip
            Dim listaUsuario As New List(Of eUsuarioAfip)
            'Uso el metodo y lleno la lista
            listaUsuario = Usuario.ObtenerUsuarios

            'Verifico que al menos haya 1 usuario cargado
            If listaUsuario.Count > 0 Then
                If listaUsuario.Count = 1 Then
                    'Selecciono el primer usuario
                    Usuario = listaUsuario.Item(0)

                    'Le asigno las propiedades al objeto del Puppeteer
                    With facturador
                        .CUIL = Usuario.NombreUsuario
                        .Password = Usuario.ClaveFiscal
                    End With
                Else
                    Throw New Exception("Hay mas de un usuario cargado en la base de datos, contacte al Administrador")
                End If
            Else
                Throw New Exception("Para utilizar el modulo de comprobantes en linea debe ingresar un usuario en la pestaña de Preferencias")
                Me.Close()
            End If

            'Deshabilito los controles apropiados
            habilitarControles(True, False)

            'Coloco en 0 los campos de bonificacion y total
            txtBonificacionTotal.Text = 0
            txtTotal.Text = 0

            'Habilito la bandera
            flag = 1

            'Funciones asincronas (Descargar Navegador, Abrirlo, Ingresar con los datos pasados e ir a los comprobantes en linea)

            Await Task.Run(Function() facturador.DescargarNavegador)
            Await Task.Run(Function() facturador.AbrirNavegador)
            Await Task.Run(Function() facturador.IrPagAfip)
            aumentarBarra(20)
            Await Task.Run(Function() facturador.IngresoCUIT())
            aumentarBarra(20)
            Await Task.Run(Function() facturador.IngresoPass())
            aumentarBarra(20)
            Await Task.Run(Function() facturador.IrAComprobantesEnLinea())
            aumentarBarra(20)
            Await Task.Run(Function() facturador.IngresarEmpresa())
            aumentarBarra(20)


        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
            Me.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Cierro el formulario
        Close()
    End Sub

    'AGREGAR PRODUCTO
    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Try
            If cboProductoServicio.SelectedValue = 0 Then
                Throw New Exception("Debe seleccionar un producto")
            End If

            'Sumo a los valores ya cargados, el proveniente de los textbox
            Dim valorBonTot As Double = Convert.ToDouble(txtBonificacionTotal.Text)
            Dim valorTot As Double = Convert.ToDouble(txtTotal.Text)

            'Creo un objeto para guardar los productos del DGV
            Dim item As New eCuerpoComprobante
            'Creo un objeto para guardar el producto seleccionado en el CBO
            Dim producto As eProducto = cboProductoServicio.SelectedItem

            'Compruebo que si hay un (.) en la cantidad o en la bonificacion lo cambie por una (,)
            If txtCantidad.Text.Contains(".") Then
                txtCantidad.Text = txtCantidad.Text.Replace(".", ",")
            End If

            If txtBonificacion.Text.Contains(".") Then
                txtBonificacion.Text = txtBonificacion.Text.Replace(".", ",")
            End If

            'Le asigno los valores al objeto
            With item
                'A la cantidad de elementos en la lista, le sumo 1 para el ID
                .IdCuerpo = ListaItems.Count + 1
                .NumeroComprobante = 0
                .ProductoServicio = producto.IdProducto
                .Cantidad = Convert.ToDouble(txtCantidad.Text)
                'SOLO A FINES DE MOSTRAR LA UNIDAD DE MEDIDA (el valor ya se encuentra en el producto cargado)
                .UnidadMedida = producto.UnidadMedida
                .PrecioUnitario = producto.PrecioFinal

                'Compruebo la bonificacion
                If Convert.ToDouble(txtBonificacion.Text) > 100 Then
                    .Bonificacion = 100
                Else
                    .Bonificacion = Convert.ToDouble(txtBonificacion.Text)
                End If

                'Calculo la bonificacion total
                .BonificacionTotal = .Cantidad * .Bonificacion * .PrecioUnitario / 100

                'Calculo el subtotal
                .SubTotal = .PrecioUnitario * .Cantidad - .BonificacionTotal

                'Sumo la bonificacion total y el total general
                valorBonTot += .BonificacionTotal
                valorTot += .SubTotal

                'Guardo el total
                .Total = valorTot
            End With

            'Muestro en los txt los valores
            txtBonificacionTotal.Text = valorBonTot.ToString("F2")
            txtTotal.Text = valorTot.ToString("F2")

            'Reestablezo la cantidad y la bonificacion
            txtCantidad.Text = 1
            txtBonificacion.Text = 0

            'Agrego un nuevo objeto a la lista
            ListaItems.Add(item)

            'Actualizo el DGV
            ActualizarDGV()

        Catch ex As Exception
            MsgBox("Error :" & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    'ELIMINAR PRODUCTO
    Private Sub btnEliminarProducto_Click(sender As Object, e As EventArgs) Handles btnEliminarProducto.Click
        Try
            'Verifico que se haya seleccionado un producto
            If IdProdSelec > 0 Then
                'Si la lista cuenta con al menos 1 producto ya agregado
                If ListaItems.Count > 0 Then
                    'Creo un objeto para encontrar el producto
                    Dim prod As eCuerpoComprobante = ListaItems.Find(Function(arg) arg.IdCuerpo = IdProdSelec)
                    'Verifico que se haya encontrado algun producto dentro de la lista
                    If prod IsNot Nothing Then
                        'Recalculo los campos
                        Dim valorBonTot As Double = Convert.ToDouble(txtBonificacionTotal.Text)
                        Dim valorTot As Double = Convert.ToDouble(txtTotal.Text)

                        With prod
                            valorBonTot -= .BonificacionTotal
                            valorTot -= .SubTotal
                        End With

                        'Muestro en los txt los valores
                        txtBonificacionTotal.Text = valorBonTot.ToString("F2")
                        txtTotal.Text = valorTot.ToString("F2")

                        'Lo elimino de la lista
                        ListaItems.Remove(prod)

                        'Reestablezo el id de la seleccion
                        IdProdSelec = -1

                        'Actualizo el DGV
                        ActualizarDGV()
                    End If
                End If
            Else
                Throw New Exception("Debe seleccionar un producto")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Text)
        End Try
    End Sub

    'GENERAR FACTURA
    Private Async Sub btnGenerarFactura_Click(sender As Object, e As EventArgs) Handles btnGenerarFactura.Click
        Try
            If ListaItems.Count = 0 Then
                Throw New Exception("NO HA INGRESADO NINGUN PRODUCTO")

            Else
                'Guardo el encabezado
                With Encabezado
                    .TipoComprobante = 3
                    .ConceptoInc = "Productos"
                    .Fecha = dtpFechaFactura.Value
                    .PuntoVta = 1
                End With

                If rbtContado.Checked Then
                    Encabezado.FormaPago = 1
                ElseIf rbtTarjetaCredito.Checked Then
                    Encabezado.FormaPago = 3
                    If txtTarjetaCredito.Text.Count = 0 Then
                        Throw New Exception("DEBE INGRESAR EL NRO DE LA TARJETA DE CREDITO")
                    Else
                        Encabezado.NumeroTarjCredito = txtTarjetaCredito.Text
                        Encabezado.Tarjeta = cboTarjetaCredito.SelectedValue
                    End If
                ElseIf rbtTarjetaDebito.Checked Then
                    Encabezado.FormaPago = 2
                    If txtTarjetaDebito.Text.Count = 0 Then
                        Throw New Exception("DEBE INGRESAR EL NRO DE LA TARJETA DE DEBITO")
                    Else
                        Encabezado.NumeroTarjDebito = txtTarjetaDebito.Text
                        Encabezado.Tarjeta = cboTarjetaDebito.SelectedValue
                    End If
                End If

                'Habria que guardar el valor del total que tienen el txtTotal
                Dim ValorTotal As Double = Convert.ToDouble(txtTotal.Text)
                If ValorTotal >= 0 And txtNumDoc.Text = "" Then
                    Throw New Exception("DEBE SELECCIONAR UN CLIENTE")
                Else

                    If Cliente.IdCliente > 0 Then
                        With Encabezado
                            .CondicionIva = Cliente.CondicionIva
                            .Cliente = Cliente.IdCliente
                        End With
                    Else
                        With Encabezado
                            .CondicionIva = Cliente.CondicionIva
                        End With
                    End If

                    facturador.Encabezado = Encabezado
                    facturador.Items = ListaItems
                    facturador.ListaProductos = ListaProductos
                    'Creo un nuevo objeto y le asigno el resultado del MessageBox creado
                    Dim resultado As DialogResult = MessageBox.Show("CONFIRME LA EMISION DEL COMPROBANTE", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    'Si se confirma la accion, se procede a la emision de la factura
                    If resultado = DialogResult.Yes Then

                        'Deshabilito el boton y muestra la barra de progreso de la factura
                        barraGeneracionFactura()

                        Dim NumeroTarjeta As String = ""
                        If Encabezado.FormaPago = 2 Then
                            NumeroTarjeta = Encabezado.NumeroTarjDebito
                        ElseIf Encabezado.FormaPago = 3 Then
                            NumeroTarjeta = Encabezado.NumeroTarjCredito
                        End If
                        'Comienzo la emision del comprobante
                        Await Task.Run(Function() facturador.IngresarEncabezado())
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarPuntoVenta())
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarTipoComp())
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarFecha())
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarConcepIncluir())
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarCondIVA())
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarTipoDoc(Cliente.TipoDocumento))
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarNroDoc(Cliente.NumeroDocumento))
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarFormaPago(Convert.ToString(Encabezado.FormaPago), Encabezado.Tarjeta, NumeroTarjeta))
                        aumentarBarra(5)
                        Await Task.Run(Function() facturador.IngresarItems())
                        aumentarBarra(5)
                        If Await Task.Run(Function() facturador.Terminar()) Then
                            aumentarBarra(5)
                            'Vuelvo al menu principal para obtener el nro de comprobante y cae
                            Await Task.Run(Function() facturador.Volver())
                            aumentarBarra(5)
                            Await Task.Run(Function() facturador.ObtenerComprobante())
                            aumentarBarra(5)
                            Dim nroComp As String = Await Task.Run(Function() facturador.ObtenerNroComp())
                            aumentarBarra(10)
                            Dim nroCAE As String = Await Task.Run(Function() facturador.ObtenerCae())
                            aumentarBarra(5)
                            Await Task.Run(Function() facturador.Volver())
                            aumentarBarra(10)

                            'Al finalizar se carga el encabezado del comprobante generado
                            cargarEncabComprobante(nroComp, nroCAE)
                            aumentarBarra(5)

                            'Limpio la lista de items y actualizo el DGV
                            ListaItems.Clear()
                            ActualizarDGV()
                            aumentarBarra(5)

                            'Limpio los datos del cliente
                            Dim clientenuevo As New eCliente
                            Cliente = clientenuevo
                            btnBorrarDatos.PerformClick()
                            rbtContado.Checked = True

                            cboProductoServicio.SelectedValue = 0

                            'Muestro mensaje de que fue generado correctamente el comprobante
                            MsgBox("Comprobante Generado con Exito!")
                        End If

                    Else
                        MsgBox("SE CANCELO LA EMISION DEL COMPROBANTE", MsgBoxStyle.Information, Text)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
            Me.Close()
        End Try
    End Sub

    'Cada vez que cambie el radiobutton seleccionado, cambiaran los controles habilitados
    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles rbtContado.CheckedChanged, rbtTarjetaCredito.CheckedChanged, rbtTarjetaDebito.CheckedChanged
        If rbtContado.Checked = True Then
            'Guardo el valor en la condicion venta

            cboTarjetaDebito.Enabled = False
            cboTarjetaCredito.Enabled = False
            txtTarjetaDebito.Enabled = False
            txtTarjetaCredito.Enabled = False
            cboTarjetaDebito.SelectedValue = 0
            cboTarjetaCredito.SelectedValue = 0
            txtTarjetaDebito.Text = ""
            txtTarjetaCredito.Text = ""

        ElseIf rbtTarjetaDebito.Checked = True Then

            'Creo un objeto para las tarjetas
            Dim tarjetas As New eTarjeta
            'Le asigno los tipos de tarjetas al cbo
            With cboTarjetaDebito
                .DataSource = tarjetas.ObtenerTarjetasDebito()
                .ValueMember = "IdTarjeta"
                .DisplayMember = "NombreTarj"
            End With

            cboTarjetaDebito.Enabled = True
            cboTarjetaCredito.Enabled = False
            txtTarjetaDebito.Enabled = True
            txtTarjetaCredito.Enabled = False
            cboTarjetaCredito.SelectedValue = 0
            txtTarjetaCredito.Text = ""

        ElseIf rbtTarjetaCredito.Checked = True Then

            'Creo un objeto para las tarjetas
            Dim tarjetas As New eTarjeta
            'Le asigno los tipos de tarjetas al cbo
            With cboTarjetaCredito
                .DataSource = tarjetas.ObtenerTarjetasCredito()
                .ValueMember = "IdTarjeta"
                .DisplayMember = "NombreTarj"
            End With

            cboTarjetaDebito.Enabled = False
            cboTarjetaCredito.Enabled = True
            txtTarjetaDebito.Enabled = False
            txtTarjetaCredito.Enabled = True
            cboTarjetaDebito.SelectedValue = 0
            txtTarjetaDebito.Text = ""
        End If
    End Sub

    Private Sub txtTarjetaDebito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjetaDebito.KeyPress
        CaracterNumerico(e)
    End Sub

    Private Sub txtTarjetaCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjetaCredito.KeyPress
        CaracterNumerico(e)
    End Sub

    Private Sub txtBonificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBonificacion.KeyPress
        CaracterNumericoPuntoComa(txtBonificacion, e)
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        CaracterNumericoPuntoComa(txtCantidad, e)
    End Sub

    Private Sub dtpFechaFactura_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFactura.ValueChanged
        FechaFac = dtpFechaFactura.Text
    End Sub

    'BUSQUEDA DE CLIENTE
    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        'Creo un objeto para buscar en el formulario
        Dim busqueda As New frmDialogoClilentes

        'Lo muestro
        With busqueda
            .ShowDialog()
            'Si se confirma el formulario
            If .DialogResult = DialogResult.OK Then
                'Guardo el ID del cliente seleccionado
                IdClien = .IdCli

                'Autoasigno los datos encontrados al objeto que llamo al metodo
                Cliente = Cliente.ObtenerCliente(IdClien)

                'Le asigno los datos encontrados a los controles
                With Cliente
                    cboTipoDoc.SelectedValue = .TipoDocumento
                    txtNumDoc.Text = .NumeroDocumento
                    txtNombreCliente.Text = .NombreCliente
                    txtDomicilio.Text = .Domicilio
                    cboCondicionIva.SelectedValue = .CondicionIva
                End With
            End If
        End With
    End Sub

    'BORRAR DATOS DEL CLIENTE SELECCIONADO
    Private Sub btnBorrarDatos_Click(sender As Object, e As EventArgs) Handles btnBorrarDatos.Click
        'Reestablezco los datos en los controles
        cboTipoDoc.SelectedValue = 6
        cboCondicionIva.SelectedValue = 3
        txtNumDoc.Text = ""
        txtNombreCliente.Text = ""
        txtDomicilio.Text = ""
    End Sub

    'Evento que ocurre al darle un formato al DGV
    Private Sub dgvContenidoFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvContenidoFactura.CellFormatting
        'Cuando se encuentre la columna de ProductosServicio
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("ProductoServicio") Then
            'Recorro todos los productos traidos en la lista
            For Each prod In ListaProductos
                'Cuando los valores coincidan (el id del producto y el que aparece en la columna del DGV)
                If prod.IdProducto = CInt(e.Value) Then
                    'Cambio el valor del DGV por el nombre del producto
                    e.Value = prod.NombreProducto
                    Exit For
                End If
            Next
        End If

        'Objeto y lista para comparar las unidades de medida
        Dim unidad As New eUnidadMedida
        Dim listaunidad As New List(Of eUnidadMedida)

        'Entro cuando encuentre la columna Unidad Medida
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("UnidadMedida") Then
            'Obtengo la lista de unidades medida
            listaunidad = unidad.ObtenerUnidadesMedidas
            'Las recorro
            For Each list In listaunidad
                If list.IdUnidadMedida = CInt(e.Value) Then
                    'Cuando coincidan los ID, cambio su valor en el DGV por el nombre
                    e.Value = list.TipoUnidad
                    Exit For
                End If
            Next
        End If

        'Cuando sea Cantidad
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("Cantidad") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Float
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("F2")
        End If

        'Entro cuando encuentre la columna Precio Unitario
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("PrecioUnitario") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Currency
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("C2")
        End If

        'Cuando sea Bonificacion
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("Bonificacion") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Fixed
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("F2")
        End If

        'Cuando sea Bonificacion Total
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("BonificacionTotal") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Currency
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("C2")
        End If

        'Entro cuando encuentre la columna Subtotal
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("SubTotal") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Currency
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("C2")
        End If

        'Entro cuando encuentre la columna Total
        If dgvContenidoFactura.Columns(e.ColumnIndex).Name.Equals("Total") Then
            'Guardo su valor en un objeto Double y le cambio el formato al tipo Currency
            Dim valor As New Double
            valor = e.Value
            e.Value = valor.ToString("C2")
        End If
    End Sub

    'Evento al realizar un cambio de seleccion en el CBO
    Private Sub cboProductoServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboProductoServicio.SelectedValueChanged
        'Verifico que haya un producto seleccionado
        If cboProductoServicio.SelectedValue IsNot Nothing Then
            'En un nuevo objeto guardo los datos del producto seleccionado
            Dim prod As eProducto = cboProductoServicio.SelectedItem
            'Muestro el precio del producto en el TXT, realizando un formateo al tipo FLOAT
            txtPrecioUnitario.Text = prod.PrecioFinal.ToString("F2")

            If flag = 1 Then
                'Creo un objeto para mostrar el stock
                Dim stock As New eStock
                stock = stock.ObtenerStockProducto(cboProductoServicio.SelectedValue)
                txtStockAlmacen.Text = stock.StockExistencia.ToString("F2")
            End If

        Else
            txtPrecioUnitario.Text = "0"
            txtStockAlmacen.Text = ""
        End If
    End Sub

    'Evento al realizar click sobre una celda del DGV
    Private Sub dgvContenidoFactura_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvContenidoFactura.CellMouseClick
        'Guardo el ID del producto de dicha celda
        IdProdSelec = dgvContenidoFactura.Rows(e.RowIndex).Cells(0).Value
    End Sub

    'Evento cuando se terminan de enlazar los datos
    Private Sub dgvContenidoFactura_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvContenidoFactura.DataBindingComplete
        'Limpio la seleccion
        dgvContenidoFactura.ClearSelection()
    End Sub

    'Evento al perder el foco del objeto
    Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus
        If txtCantidad.Text.Trim = "" Or Not IsNumeric(txtCantidad.Text) Then
            txtCantidad.Text = 1
        End If

        If Not Convert.ToDouble(txtCantidad.Text) > 0 Then
            txtCantidad.Text = 1
        End If
    End Sub

    'Evento al perder el foco del objeto
    Private Sub txtBonificacion_LostFocus(sender As Object, e As EventArgs) Handles txtBonificacion.LostFocus
        If txtBonificacion.Text.Trim = "" Or Not IsNumeric(txtCantidad.Text) Then
            txtBonificacion.Text = 0
        End If

        If Not Convert.ToDouble(txtBonificacion.Text) > 0 Then
            txtBonificacion.Text = 0
        End If
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Este metodo se ejecuta cada vez que se presiona una tecla en el control
    ''' </summary>
    ''' <param name="e"></param>
    Public Sub CaracterNumerico(e As KeyPressEventArgs)
        'Pregunto si es numerico el valor de la tecla presionada o si corresponde al Codigo ASCII 8 "retroceso", de ser asi muestro el valor en el control.
        'Caso contrario no dejo que el valor tecleado se muestre
        If IsNumeric(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'El handled me indica que tomara lo que tecleamos y si es false lo dejara pasar, pero si es True lo toma y no me lo muestra
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Este metodo se ejecuta cada vez que se presiona una tecla en el control
    ''' </summary>
    ''' <param name="e"></param>
    Public Sub CaracterNumericoPuntoComa(CajaTexto As TextBox, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf (e.KeyChar = "." Or e.KeyChar = ",") And (Not CajaTexto.Text.IndexOf(".") Or Not CajaTexto.Text.IndexOf(",")) Then
            e.Handled = True
        ElseIf e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Metodo para actualizar el DGV con datos de la base de datos
    ''' </summary>
    Private Sub ActualizarDGV()
        'Creo una lista vacia, para poder actualizar el DGV
        Dim lista As New List(Of eCuerpoComprobante)

        dgvContenidoFactura.DataSource = lista
        dgvContenidoFactura.DataSource = ListaItems
        dgvContenidoFactura.Update()
        'Limpio la seleccion
        dgvContenidoFactura.ClearSelection()
    End Sub

    ''' <summary>
    ''' Metodo que permite habilitar o deshabilitar los controles del formulario
    ''' </summary>
    ''' <param name="accion1">Booleano que determina si los controles apropiados seran de solo lectura</param>
    ''' <param name="accion2">Booleano que determina si los controles apropiados estaran habilitados o no</param>
    Public Sub habilitarControles(accion1 As Boolean, accion2 As Boolean)
        cboTipoDoc.Enabled = accion2
        cboCondicionIva.Enabled = accion2

        txtNumDoc.ReadOnly = accion1
        txtNombreCliente.ReadOnly = accion1
        txtDomicilio.ReadOnly = accion1
    End Sub

    ''' <summary>
    ''' Metodo para aumentar el valor de la barra de progreso
    ''' </summary>
    ''' <param name="valor">Valor a incrementar</param>
    Public Sub aumentarBarra(valor As Int16)

        'Si el valor es menor a 100%, lo aumento y muestro en el label
        If barHabilitarFactura.Value < 100 Then
            barHabilitarFactura.Value += valor
            lblProgresoBarra.Text = barHabilitarFactura.Value & "%"

            'Si por alguna razon se pasara de 100% lo vuelvo a colocar en 100%
            If barHabilitarFactura.Value > 100 Then
                barHabilitarFactura.Value = 100
                lblProgresoBarra.Text = barHabilitarFactura.Value & "%"

            End If
        End If

        'Al llegar a 100% muestro el boton para generar la factura
        If barHabilitarFactura.Value = 100 Then
            lblProgresoBarra.Visible = False
            barHabilitarFactura.Visible = False

            btnGenerarFactura.Enabled = True
            btnGenerarFactura.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Metodo que reestablece la barra y el boton para genera facturas
    ''' </summary>
    Public Sub barraGeneracionFactura()
        barHabilitarFactura.Value = 0
        lblProgresoBarra.Text = "0%"
        barHabilitarFactura.Visible = True
        lblProgresoBarra.Visible = True

        btnGenerarFactura.Enabled = False
        btnGenerarFactura.Visible = False
    End Sub

    ''' <summary>
    ''' Metodo para cargar y obtener el Id del encabezado del comprobante
    ''' </summary>
    Public Sub cargarEncabComprobante(numComp As String, cae As String)
        Try
            'Guardo los valores de AFIP
            With Encabezado
                .ComprobanteCompleto = numComp
                .CAE = cae
            End With

            'Guardo el Id de la insersion del encabezado
            Dim idEncab As Integer = Encabezado.InsertarComprobante

            'Si es mayor a cero, indica que fue cargado exitosamente, por lo que procede a cargar los cuerpos
            If idEncab > 0 Then
                cargarCuerposComprobante(idEncab)
            Else
                Throw New Exception("No se hizo la carga correcta del encabezado del comprobante")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    ''' <summary>
    ''' Metodo para cargar los registros de cuerpo de comprobante de un encabezado
    ''' </summary>
    ''' <param name="id">Numero de Id del encabezado referenciando a los distintos registros de cuerpo</param>
    Public Sub cargarCuerposComprobante(id As Integer)
        Try
            'Hago un bucle y recorro cada item de la lista de items a cargar
            For Each itemCuerpo In ListaItems
                'Dejo el Id del cuerpo vacio (porque es auto incremental) y le asigno a cada registro del cuerpo el nº de Id que representa el encabezado de comprobante
                itemCuerpo.IdCuerpo = Nothing
                itemCuerpo.NumeroComprobante = id

                'Si es menor o igual a cero indica un error en la carga del registro
                If Not itemCuerpo.InsertarCuerpo() > 0 Then
                    Throw New Exception("No se hizo la carga correcta del cuerpo del comprobante")
                End If

                'Actualizo el stock segun producto y cantidad vendida
                actualizarStock(itemCuerpo.ProductoServicio, itemCuerpo.Cantidad)
            Next

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    ''' <summary>
    ''' Metodo que actualiza el stock del producto segun la cantidad vendida
    ''' </summary>
    ''' <param name="idProd">Id del producto a actualizar</param>
    ''' <param name="cantVendida">Cantidad del producto vendida</param>
    Public Sub actualizarStock(idProd As Integer, cantVendida As Double)
        Try
            'Creo un objeto para solicitar el stock actual del producto
            Dim stockAlmacen As New eStock
            stockAlmacen = stockAlmacen.ObtenerStockProducto(idProd)

            'Creo un objeto para usarlo en la actualizacion
            Dim stockActualAlmacen As New eStock
            With stockActualAlmacen
                .IdStock = stockAlmacen.IdStock
                .IdProdStock = stockAlmacen.IdProdStock

                Dim stock As Double = stockAlmacen.StockExistencia - cantVendida
                'Si el stock diera negativo, lo dejo nulo
                If stock < 0 Then
                    stock = 0
                End If
                .StockExistencia = stock
            End With

            'Si los stock son distintos, los actualizo (sino quiere decir que continua con el mismo stock, siendo 0 seguramente)
            If stockAlmacen.StockExistencia <> stockActualAlmacen.StockExistencia Then
                'Actualizo el stock. Si no devuelve un valor mayor a 0 entonces no se modifico el registro
                If Not stockAlmacen.ActualizarStock(stockActualAlmacen) > 0 Then
                    Throw New Exception("Fallo al realizar la actualizacion de stock")
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub
#End Region

#Region "Funciones"
    Public Function IsRunning(ByVal processName As String) As Integer
        Try
            Dim retVal() As Process = Process.GetProcessesByName(processName)

            If retVal.Length > 0 Then
                For Each proceso In retVal
                    If ObtenerEjecutable(proceso) = "D:\Chromium\Win64-686378\chrome-win\chrome.exe" Then
                        proceso.Kill()
                    End If
                Next
            End If
            Return retVal.Count
        Catch ex As Exception
            'handle the exception your way
            MessageBox.Show(ex.Message)
            Return -1
        End Try
    End Function
    Private Function ObtenerEjecutable(proceso As Process) As String
        Try
            Return proceso.MainModule.FileName
        Catch ex As Exception
            Dim query As String = "SELECT ExecutablePath, ProcessID FROM Win32_Process"
            Dim buscador As New ManagementObjectSearcher(query)
            For Each item In buscador.Get
                Dim id As Object = item("ProcessID")
                Dim path As Object = item("ExecutablePath")
                If Not path Is Nothing And id.ToString = proceso.Id.ToString Then
                    Return path.ToString
                End If
            Next
            Return Nothing
        End Try
    End Function
#End Region
End Class