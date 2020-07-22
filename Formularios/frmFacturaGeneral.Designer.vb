<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFacturaGeneral
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblTipoDoc = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblCondicionIva = New System.Windows.Forms.Label()
        Me.cboCondicionIva = New System.Windows.Forms.ComboBox()
        Me.gbxFormasPago = New System.Windows.Forms.GroupBox()
        Me.rbtTarjetaCredito = New System.Windows.Forms.RadioButton()
        Me.rbtTarjetaDebito = New System.Windows.Forms.RadioButton()
        Me.rbtContado = New System.Windows.Forms.RadioButton()
        Me.cboTarjetaDebito = New System.Windows.Forms.ComboBox()
        Me.cboTarjetaCredito = New System.Windows.Forms.ComboBox()
        Me.txtTarjetaDebito = New System.Windows.Forms.TextBox()
        Me.txtTarjetaCredito = New System.Windows.Forms.TextBox()
        Me.cboProductoServicio = New System.Windows.Forms.ComboBox()
        Me.lblProductoServicio = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.lblPrecioUnitario = New System.Windows.Forms.Label()
        Me.txtBonificacion = New System.Windows.Forms.TextBox()
        Me.lblBonificacion = New System.Windows.Forms.Label()
        Me.txtBonificacionTotal = New System.Windows.Forms.TextBox()
        Me.lblBonificacionTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblNumDoc = New System.Windows.Forms.Label()
        Me.dtpFechaFactura = New System.Windows.Forms.DateTimePicker()
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.lblBarraSeparacion = New System.Windows.Forms.Label()
        Me.dgvContenidoFactura = New System.Windows.Forms.DataGridView()
        Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCuerpo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductoServicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BonificacionTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblBuscarCl = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBorrarDatos = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.btnGenerarFactura = New System.Windows.Forms.Button()
        Me.btnEliminarProducto = New System.Windows.Forms.Button()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.txtStockAlmacen = New System.Windows.Forms.TextBox()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.gbxFormasPago.SuspendLayout()
        CType(Me.dgvContenidoFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNumDoc.Location = New System.Drawing.Point(438, 80)
        Me.txtNumDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumDoc.MaxLength = 11
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(146, 27)
        Me.txtNumDoc.TabIndex = 3
        '
        'lblFecha
        '
        Me.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(10, 35)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(52, 19)
        Me.lblFecha.TabIndex = 3
        Me.lblFecha.Text = "FECHA"
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.Location = New System.Drawing.Point(10, 83)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(134, 19)
        Me.lblTipoDoc.TabIndex = 4
        Me.lblTipoDoc.Text = "TIPO DOCUMENTO"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(10, 124)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(163, 38)
        Me.lblNombreCliente.TabIndex = 5
        Me.lblNombreCliente.Text = "APELLIDO Y NOMBRE / " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RAZON SOCIAL"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDomicilio.AutoSize = True
        Me.lblDomicilio.Location = New System.Drawing.Point(10, 183)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(82, 19)
        Me.lblDomicilio.TabIndex = 7
        Me.lblDomicilio.Text = "DOMICILIO"
        '
        'lblCondicionIva
        '
        Me.lblCondicionIva.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCondicionIva.AutoSize = True
        Me.lblCondicionIva.Location = New System.Drawing.Point(10, 234)
        Me.lblCondicionIva.Name = "lblCondicionIva"
        Me.lblCondicionIva.Size = New System.Drawing.Size(112, 19)
        Me.lblCondicionIva.TabIndex = 9
        Me.lblCondicionIva.Text = "CONDICION IVA"
        '
        'cboCondicionIva
        '
        Me.cboCondicionIva.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboCondicionIva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCondicionIva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCondicionIva.FormattingEnabled = True
        Me.cboCondicionIva.Location = New System.Drawing.Point(179, 231)
        Me.cboCondicionIva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboCondicionIva.Name = "cboCondicionIva"
        Me.cboCondicionIva.Size = New System.Drawing.Size(198, 27)
        Me.cboCondicionIva.TabIndex = 6
        '
        'gbxFormasPago
        '
        Me.gbxFormasPago.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxFormasPago.Controls.Add(Me.rbtTarjetaCredito)
        Me.gbxFormasPago.Controls.Add(Me.rbtTarjetaDebito)
        Me.gbxFormasPago.Controls.Add(Me.rbtContado)
        Me.gbxFormasPago.Location = New System.Drawing.Point(592, 29)
        Me.gbxFormasPago.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbxFormasPago.Name = "gbxFormasPago"
        Me.gbxFormasPago.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbxFormasPago.Size = New System.Drawing.Size(175, 172)
        Me.gbxFormasPago.TabIndex = 11
        Me.gbxFormasPago.TabStop = False
        Me.gbxFormasPago.Text = "FORMA DE PAGO"
        '
        'rbtTarjetaCredito
        '
        Me.rbtTarjetaCredito.AutoSize = True
        Me.rbtTarjetaCredito.Location = New System.Drawing.Point(7, 113)
        Me.rbtTarjetaCredito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtTarjetaCredito.Name = "rbtTarjetaCredito"
        Me.rbtTarjetaCredito.Size = New System.Drawing.Size(124, 23)
        Me.rbtTarjetaCredito.TabIndex = 2
        Me.rbtTarjetaCredito.TabStop = True
        Me.rbtTarjetaCredito.Text = "TARJ. CREDITO"
        Me.rbtTarjetaCredito.UseVisualStyleBackColor = True
        '
        'rbtTarjetaDebito
        '
        Me.rbtTarjetaDebito.AutoSize = True
        Me.rbtTarjetaDebito.Location = New System.Drawing.Point(7, 79)
        Me.rbtTarjetaDebito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtTarjetaDebito.Name = "rbtTarjetaDebito"
        Me.rbtTarjetaDebito.Size = New System.Drawing.Size(115, 23)
        Me.rbtTarjetaDebito.TabIndex = 1
        Me.rbtTarjetaDebito.TabStop = True
        Me.rbtTarjetaDebito.Text = "TARJ. DEBITO"
        Me.rbtTarjetaDebito.UseVisualStyleBackColor = True
        '
        'rbtContado
        '
        Me.rbtContado.AutoSize = True
        Me.rbtContado.Location = New System.Drawing.Point(7, 44)
        Me.rbtContado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtContado.Name = "rbtContado"
        Me.rbtContado.Size = New System.Drawing.Size(94, 23)
        Me.rbtContado.TabIndex = 0
        Me.rbtContado.TabStop = True
        Me.rbtContado.Text = "CONTADO"
        Me.rbtContado.UseVisualStyleBackColor = True
        '
        'cboTarjetaDebito
        '
        Me.cboTarjetaDebito.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboTarjetaDebito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboTarjetaDebito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTarjetaDebito.Enabled = False
        Me.cboTarjetaDebito.FormattingEnabled = True
        Me.cboTarjetaDebito.Location = New System.Drawing.Point(774, 105)
        Me.cboTarjetaDebito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTarjetaDebito.Name = "cboTarjetaDebito"
        Me.cboTarjetaDebito.Size = New System.Drawing.Size(135, 27)
        Me.cboTarjetaDebito.TabIndex = 7
        '
        'cboTarjetaCredito
        '
        Me.cboTarjetaCredito.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboTarjetaCredito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboTarjetaCredito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTarjetaCredito.Enabled = False
        Me.cboTarjetaCredito.FormattingEnabled = True
        Me.cboTarjetaCredito.Location = New System.Drawing.Point(774, 142)
        Me.cboTarjetaCredito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTarjetaCredito.Name = "cboTarjetaCredito"
        Me.cboTarjetaCredito.Size = New System.Drawing.Size(135, 27)
        Me.cboTarjetaCredito.TabIndex = 9
        '
        'txtTarjetaDebito
        '
        Me.txtTarjetaDebito.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTarjetaDebito.Enabled = False
        Me.txtTarjetaDebito.Location = New System.Drawing.Point(917, 105)
        Me.txtTarjetaDebito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTarjetaDebito.Name = "txtTarjetaDebito"
        Me.txtTarjetaDebito.Size = New System.Drawing.Size(205, 27)
        Me.txtTarjetaDebito.TabIndex = 8
        '
        'txtTarjetaCredito
        '
        Me.txtTarjetaCredito.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTarjetaCredito.Enabled = False
        Me.txtTarjetaCredito.Location = New System.Drawing.Point(917, 142)
        Me.txtTarjetaCredito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTarjetaCredito.Name = "txtTarjetaCredito"
        Me.txtTarjetaCredito.Size = New System.Drawing.Size(205, 27)
        Me.txtTarjetaCredito.TabIndex = 10
        '
        'cboProductoServicio
        '
        Me.cboProductoServicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboProductoServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProductoServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProductoServicio.FormattingEnabled = True
        Me.cboProductoServicio.Location = New System.Drawing.Point(248, 322)
        Me.cboProductoServicio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboProductoServicio.Name = "cboProductoServicio"
        Me.cboProductoServicio.Size = New System.Drawing.Size(211, 27)
        Me.cboProductoServicio.TabIndex = 11
        '
        'lblProductoServicio
        '
        Me.lblProductoServicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblProductoServicio.AutoSize = True
        Me.lblProductoServicio.Location = New System.Drawing.Point(143, 322)
        Me.lblProductoServicio.Name = "lblProductoServicio"
        Me.lblProductoServicio.Size = New System.Drawing.Size(99, 38)
        Me.lblProductoServicio.TabIndex = 15
        Me.lblProductoServicio.Text = "PRODUCTO / " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SERVICIO"
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(143, 380)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(78, 19)
        Me.lblCantidad.TabIndex = 17
        Me.lblCantidad.Text = "CANTIDAD"
        '
        'txtCantidad
        '
        Me.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCantidad.Location = New System.Drawing.Point(248, 376)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(96, 27)
        Me.txtCantidad.TabIndex = 12
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(610, 322)
        Me.txtPrecioUnitario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.ReadOnly = True
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(79, 27)
        Me.txtPrecioUnitario.TabIndex = 13
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioUnitario
        '
        Me.lblPrecioUnitario.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrecioUnitario.AutoSize = True
        Me.lblPrecioUnitario.Location = New System.Drawing.Point(478, 325)
        Me.lblPrecioUnitario.Name = "lblPrecioUnitario"
        Me.lblPrecioUnitario.Size = New System.Drawing.Size(126, 19)
        Me.lblPrecioUnitario.TabIndex = 21
        Me.lblPrecioUnitario.Text = "PRECIO UNITARIO"
        '
        'txtBonificacion
        '
        Me.txtBonificacion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBonificacion.Location = New System.Drawing.Point(248, 425)
        Me.txtBonificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBonificacion.Name = "txtBonificacion"
        Me.txtBonificacion.Size = New System.Drawing.Size(96, 27)
        Me.txtBonificacion.TabIndex = 14
        Me.txtBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBonificacion
        '
        Me.lblBonificacion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblBonificacion.AutoSize = True
        Me.lblBonificacion.Location = New System.Drawing.Point(121, 428)
        Me.lblBonificacion.Name = "lblBonificacion"
        Me.lblBonificacion.Size = New System.Drawing.Size(121, 19)
        Me.lblBonificacion.TabIndex = 23
        Me.lblBonificacion.Text = "% BONIFICACION"
        '
        'txtBonificacionTotal
        '
        Me.txtBonificacionTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBonificacionTotal.Location = New System.Drawing.Point(848, 693)
        Me.txtBonificacionTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBonificacionTotal.Name = "txtBonificacionTotal"
        Me.txtBonificacionTotal.ReadOnly = True
        Me.txtBonificacionTotal.Size = New System.Drawing.Size(98, 27)
        Me.txtBonificacionTotal.TabIndex = 26
        Me.txtBonificacionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBonificacionTotal
        '
        Me.lblBonificacionTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBonificacionTotal.AutoSize = True
        Me.lblBonificacionTotal.Location = New System.Drawing.Point(668, 696)
        Me.lblBonificacionTotal.Name = "lblBonificacionTotal"
        Me.lblBonificacionTotal.Size = New System.Drawing.Size(174, 19)
        Me.lblBonificacionTotal.TabIndex = 25
        Me.lblBonificacionTotal.Text = "BONIFICACION TOTAL ($)"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Location = New System.Drawing.Point(1029, 693)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(98, 27)
        Me.txtTotal.TabIndex = 28
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(950, 696)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(73, 19)
        Me.lblTotal.TabIndex = 27
        Me.lblTotal.Text = "TOTAL ($)"
        '
        'lblNumDoc
        '
        Me.lblNumDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNumDoc.AutoSize = True
        Me.lblNumDoc.Location = New System.Drawing.Point(314, 75)
        Me.lblNumDoc.Name = "lblNumDoc"
        Me.lblNumDoc.Size = New System.Drawing.Size(118, 38)
        Me.lblNumDoc.TabIndex = 31
        Me.lblNumDoc.Text = "N° DOCUMENTO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " / CUIT"
        '
        'dtpFechaFactura
        '
        Me.dtpFechaFactura.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtpFechaFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFactura.Location = New System.Drawing.Point(179, 29)
        Me.dtpFechaFactura.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaFactura.Name = "dtpFechaFactura"
        Me.dtpFechaFactura.Size = New System.Drawing.Size(113, 27)
        Me.dtpFechaFactura.TabIndex = 1
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Location = New System.Drawing.Point(179, 80)
        Me.cboTipoDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(113, 27)
        Me.cboTipoDoc.TabIndex = 2
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreCliente.Location = New System.Drawing.Point(179, 129)
        Me.txtNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(274, 27)
        Me.txtNombreCliente.TabIndex = 4
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDomicilio.Location = New System.Drawing.Point(179, 180)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(198, 27)
        Me.txtDomicilio.TabIndex = 5
        '
        'lblBarraSeparacion
        '
        Me.lblBarraSeparacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBarraSeparacion.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblBarraSeparacion.Font = New System.Drawing.Font("Calibri", 1.0!)
        Me.lblBarraSeparacion.Location = New System.Drawing.Point(1, 284)
        Me.lblBarraSeparacion.Name = "lblBarraSeparacion"
        Me.lblBarraSeparacion.Size = New System.Drawing.Size(1137, 5)
        Me.lblBarraSeparacion.TabIndex = 33
        '
        'dgvContenidoFactura
        '
        Me.dgvContenidoFactura.AllowUserToAddRows = False
        Me.dgvContenidoFactura.AllowUserToDeleteRows = False
        Me.dgvContenidoFactura.AllowUserToResizeColumns = False
        Me.dgvContenidoFactura.AllowUserToResizeRows = False
        Me.dgvContenidoFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvContenidoFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvContenidoFactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContenidoFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvContenidoFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContenidoFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroComprobante, Me.IdCuerpo, Me.ProductoServicio, Me.PrecioUnitario, Me.Cantidad, Me.UnidadMedida, Me.Bonificacion, Me.BonificacionTotal, Me.Total, Me.SubTotal})
        Me.dgvContenidoFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvContenidoFactura.Location = New System.Drawing.Point(12, 468)
        Me.dgvContenidoFactura.MultiSelect = False
        Me.dgvContenidoFactura.Name = "dgvContenidoFactura"
        Me.dgvContenidoFactura.ReadOnly = True
        Me.dgvContenidoFactura.RowHeadersVisible = False
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 15.0!)
        Me.dgvContenidoFactura.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvContenidoFactura.RowTemplate.Height = 24
        Me.dgvContenidoFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContenidoFactura.Size = New System.Drawing.Size(1115, 218)
        Me.dgvContenidoFactura.TabIndex = 35
        '
        'NumeroComprobante
        '
        Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
        Me.NumeroComprobante.HeaderText = "COMPROBANTE"
        Me.NumeroComprobante.Name = "NumeroComprobante"
        Me.NumeroComprobante.ReadOnly = True
        Me.NumeroComprobante.Visible = False
        '
        'IdCuerpo
        '
        Me.IdCuerpo.DataPropertyName = "IdCuerpo"
        Me.IdCuerpo.HeaderText = "ID"
        Me.IdCuerpo.Name = "IdCuerpo"
        Me.IdCuerpo.ReadOnly = True
        Me.IdCuerpo.Visible = False
        Me.IdCuerpo.Width = 50
        '
        'ProductoServicio
        '
        Me.ProductoServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ProductoServicio.DataPropertyName = "ProductoServicio"
        Me.ProductoServicio.HeaderText = "DESCRIPCION"
        Me.ProductoServicio.Name = "ProductoServicio"
        Me.ProductoServicio.ReadOnly = True
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.DataPropertyName = "PrecioUnitario"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrecioUnitario.HeaderText = "PRECIO"
        Me.PrecioUnitario.MinimumWidth = 110
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        Me.PrecioUnitario.Width = 110
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cantidad.HeaderText = "CANTIDAD"
        Me.Cantidad.MinimumWidth = 120
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 120
        '
        'UnidadMedida
        '
        Me.UnidadMedida.DataPropertyName = "UnidadMedida"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnidadMedida.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnidadMedida.HeaderText = "UNIDAD MEDIDA"
        Me.UnidadMedida.MinimumWidth = 120
        Me.UnidadMedida.Name = "UnidadMedida"
        Me.UnidadMedida.ReadOnly = True
        Me.UnidadMedida.Width = 120
        '
        'Bonificacion
        '
        Me.Bonificacion.DataPropertyName = "Bonificacion"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Bonificacion.DefaultCellStyle = DataGridViewCellStyle5
        Me.Bonificacion.HeaderText = "% BONIFICACION"
        Me.Bonificacion.MinimumWidth = 105
        Me.Bonificacion.Name = "Bonificacion"
        Me.Bonificacion.ReadOnly = True
        Me.Bonificacion.Width = 105
        '
        'BonificacionTotal
        '
        Me.BonificacionTotal.DataPropertyName = "BonificacionTotal"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.BonificacionTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.BonificacionTotal.HeaderText = "BONIFICACION"
        Me.BonificacionTotal.MinimumWidth = 130
        Me.BonificacionTotal.Name = "BonificacionTotal"
        Me.BonificacionTotal.ReadOnly = True
        Me.BonificacionTotal.Width = 130
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle7
        Me.Total.HeaderText = "TOTAL"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Visible = False
        '
        'SubTotal
        '
        Me.SubTotal.DataPropertyName = "SubTotal"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle8
        Me.SubTotal.HeaderText = "SUBTOTAL"
        Me.SubTotal.MinimumWidth = 130
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        Me.SubTotal.Width = 130
        '
        'lblBuscarCl
        '
        Me.lblBuscarCl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblBuscarCl.AutoSize = True
        Me.lblBuscarCl.Location = New System.Drawing.Point(314, 35)
        Me.lblBuscarCl.Name = "lblBuscarCl"
        Me.lblBuscarCl.Size = New System.Drawing.Size(120, 19)
        Me.lblBuscarCl.TabIndex = 36
        Me.lblBuscarCl.Text = "BUSCAR CLIENTE"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = Global.CapaPresentacionComprobantes.My.Resources.Resources.back
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(1011, 748)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 39)
        Me.btnSalir.TabIndex = 32
        Me.btnSalir.Text = "     SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBorrarDatos
        '
        Me.btnBorrarDatos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBorrarDatos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBorrarDatos.Image = Global.CapaPresentacionComprobantes.My.Resources.Resources.user_remove
        Me.btnBorrarDatos.Location = New System.Drawing.Point(504, 26)
        Me.btnBorrarDatos.Name = "btnBorrarDatos"
        Me.btnBorrarDatos.Size = New System.Drawing.Size(40, 37)
        Me.btnBorrarDatos.TabIndex = 38
        Me.btnBorrarDatos.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarCliente.Image = Global.CapaPresentacionComprobantes.My.Resources.Resources.search
        Me.btnBuscarCliente.Location = New System.Drawing.Point(440, 26)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(40, 37)
        Me.btnBuscarCliente.TabIndex = 37
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnGenerarFactura
        '
        Me.btnGenerarFactura.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGenerarFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarFactura.Image = Global.CapaPresentacionComprobantes.My.Resources.Resources.creditcard
        Me.btnGenerarFactura.Location = New System.Drawing.Point(519, 693)
        Me.btnGenerarFactura.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerarFactura.Name = "btnGenerarFactura"
        Me.btnGenerarFactura.Size = New System.Drawing.Size(117, 63)
        Me.btnGenerarFactura.TabIndex = 30
        Me.btnGenerarFactura.Text = "GENERAR FACTURA"
        Me.btnGenerarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerarFactura.UseVisualStyleBackColor = True
        '
        'btnEliminarProducto
        '
        Me.btnEliminarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEliminarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarProducto.Image = Global.CapaPresentacionComprobantes.My.Resources.Resources.remove
        Me.btnEliminarProducto.Location = New System.Drawing.Point(848, 325)
        Me.btnEliminarProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEliminarProducto.Name = "btnEliminarProducto"
        Me.btnEliminarProducto.Size = New System.Drawing.Size(128, 74)
        Me.btnEliminarProducto.TabIndex = 29
        Me.btnEliminarProducto.Text = "ELIMINAR PRODUCTO"
        Me.btnEliminarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarProducto.UseVisualStyleBackColor = True
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarProducto.Image = Global.CapaPresentacionComprobantes.My.Resources.Resources.insert
        Me.btnAgregarProducto.Location = New System.Drawing.Point(714, 325)
        Me.btnAgregarProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(128, 74)
        Me.btnAgregarProducto.TabIndex = 16
        Me.btnAgregarProducto.Text = "AGREGAR PRODUCTO"
        Me.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'txtStockAlmacen
        '
        Me.txtStockAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtStockAlmacen.Location = New System.Drawing.Point(610, 376)
        Me.txtStockAlmacen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtStockAlmacen.Name = "txtStockAlmacen"
        Me.txtStockAlmacen.ReadOnly = True
        Me.txtStockAlmacen.Size = New System.Drawing.Size(79, 27)
        Me.txtStockAlmacen.TabIndex = 39
        Me.txtStockAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStock
        '
        Me.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblStock.AutoSize = True
        Me.lblStock.Location = New System.Drawing.Point(478, 380)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(121, 19)
        Me.lblStock.TabIndex = 40
        Me.lblStock.Text = "STOCK ALMACEN"
        '
        'frmFacturaGeneral
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1139, 800)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtStockAlmacen)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.btnBorrarDatos)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.lblBuscarCl)
        Me.Controls.Add(Me.dgvContenidoFactura)
        Me.Controls.Add(Me.lblBarraSeparacion)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblNumDoc)
        Me.Controls.Add(Me.btnGenerarFactura)
        Me.Controls.Add(Me.btnEliminarProducto)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.txtBonificacionTotal)
        Me.Controls.Add(Me.lblBonificacionTotal)
        Me.Controls.Add(Me.txtBonificacion)
        Me.Controls.Add(Me.lblBonificacion)
        Me.Controls.Add(Me.txtPrecioUnitario)
        Me.Controls.Add(Me.lblPrecioUnitario)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.lblProductoServicio)
        Me.Controls.Add(Me.cboProductoServicio)
        Me.Controls.Add(Me.txtTarjetaCredito)
        Me.Controls.Add(Me.txtTarjetaDebito)
        Me.Controls.Add(Me.gbxFormasPago)
        Me.Controls.Add(Me.cboTarjetaCredito)
        Me.Controls.Add(Me.cboCondicionIva)
        Me.Controls.Add(Me.cboTarjetaDebito)
        Me.Controls.Add(Me.lblCondicionIva)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.lblDomicilio)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.lblTipoDoc)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.dtpFechaFactura)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(1155, 816)
        Me.Name = "frmFacturaGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FACTURA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbxFormasPago.ResumeLayout(False)
        Me.gbxFormasPago.PerformLayout()
        CType(Me.dgvContenidoFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumDoc As TextBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblTipoDoc As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblDomicilio As Label
    Friend WithEvents lblCondicionIva As Label
    Friend WithEvents cboCondicionIva As ComboBox
    Friend WithEvents gbxFormasPago As GroupBox
    Friend WithEvents txtTarjetaCredito As TextBox
    Friend WithEvents txtTarjetaDebito As TextBox
    Friend WithEvents cboTarjetaCredito As ComboBox
    Friend WithEvents cboTarjetaDebito As ComboBox
    Friend WithEvents rbtTarjetaCredito As RadioButton
    Friend WithEvents rbtTarjetaDebito As RadioButton
    Friend WithEvents rbtContado As RadioButton
    Friend WithEvents cboProductoServicio As ComboBox
    Friend WithEvents lblProductoServicio As Label
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents lblCantidad As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtPrecioUnitario As TextBox
    Friend WithEvents lblPrecioUnitario As Label
    Friend WithEvents txtBonificacion As TextBox
    Friend WithEvents lblBonificacion As Label
    Friend WithEvents txtBonificacionTotal As TextBox
    Friend WithEvents lblBonificacionTotal As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnEliminarProducto As Button
    Friend WithEvents btnGenerarFactura As Button
    Friend WithEvents lblNumDoc As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents dtpFechaFactura As DateTimePicker
    Friend WithEvents cboTipoDoc As ComboBox
    Friend WithEvents txtNombreCliente As TextBox
    Friend WithEvents txtDomicilio As TextBox
    Friend WithEvents lblBarraSeparacion As Label
    Friend WithEvents dgvContenidoFactura As DataGridView
    Friend WithEvents lblBuscarCl As Label
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents NumeroComprobante As DataGridViewTextBoxColumn
    Friend WithEvents IdCuerpo As DataGridViewTextBoxColumn
    Friend WithEvents ProductoServicio As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents UnidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents Bonificacion As DataGridViewTextBoxColumn
    Friend WithEvents BonificacionTotal As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As DataGridViewTextBoxColumn
    Friend WithEvents btnBorrarDatos As Button
    Friend WithEvents txtStockAlmacen As TextBox
    Friend WithEvents lblStock As Label
End Class
