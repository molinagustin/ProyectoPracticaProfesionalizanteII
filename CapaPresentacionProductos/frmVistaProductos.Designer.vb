<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVistaProductos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblConsultaProduc = New System.Windows.Forms.Label()
        Me.dgvListadoProductos = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.cboTipoBusqueda = New System.Windows.Forms.ComboBox()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockExistencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvListadoProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblConsultaProduc
        '
        Me.lblConsultaProduc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConsultaProduc.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultaProduc.Location = New System.Drawing.Point(12, 9)
        Me.lblConsultaProduc.Name = "lblConsultaProduc"
        Me.lblConsultaProduc.Size = New System.Drawing.Size(1120, 35)
        Me.lblConsultaProduc.TabIndex = 5
        Me.lblConsultaProduc.Text = "CONSULTA DE PRODUCTOS"
        Me.lblConsultaProduc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvListadoProductos
        '
        Me.dgvListadoProductos.AllowUserToAddRows = False
        Me.dgvListadoProductos.AllowUserToDeleteRows = False
        Me.dgvListadoProductos.AllowUserToResizeColumns = False
        Me.dgvListadoProductos.AllowUserToResizeRows = False
        Me.dgvListadoProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvListadoProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListadoProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListadoProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.NombreProducto, Me.Rubro, Me.PrecioCosto, Me.PrecioFinal, Me.Proveedor, Me.StockExistencia, Me.UnidadMedida, Me.Activo})
        Me.dgvListadoProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvListadoProductos.Location = New System.Drawing.Point(18, 190)
        Me.dgvListadoProductos.MinimumSize = New System.Drawing.Size(1114, 509)
        Me.dgvListadoProductos.MultiSelect = False
        Me.dgvListadoProductos.Name = "dgvListadoProductos"
        Me.dgvListadoProductos.ReadOnly = True
        Me.dgvListadoProductos.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 15.0!)
        Me.dgvListadoProductos.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvListadoProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListadoProductos.Size = New System.Drawing.Size(1114, 509)
        Me.dgvListadoProductos.TabIndex = 6
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = Global.CapaPresentacionProductos.My.Resources.Resources.insert
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(834, 705)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(135, 50)
        Me.btnAgregar.TabIndex = 8
        Me.btnAgregar.Text = "  AGREGAR NUEVO"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = Global.CapaPresentacionProductos.My.Resources.Resources.back
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(1016, 711)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 39)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "     SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtBuscador
        '
        Me.txtBuscador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscador.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.txtBuscador.Location = New System.Drawing.Point(931, 155)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(201, 29)
        Me.txtBuscador.TabIndex = 1
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Font = New System.Drawing.Font("Calibri", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblBuscar.Location = New System.Drawing.Point(701, 158)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(77, 22)
        Me.lblBuscar.TabIndex = 11
        Me.lblBuscar.Text = "BUSCAR:"
        '
        'cboTipoBusqueda
        '
        Me.cboTipoBusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTipoBusqueda.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.cboTipoBusqueda.FormattingEnabled = True
        Me.cboTipoBusqueda.Location = New System.Drawing.Point(784, 155)
        Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
        Me.cboTipoBusqueda.Size = New System.Drawing.Size(141, 29)
        Me.cboTipoBusqueda.TabIndex = 12
        '
        'IdProducto
        '
        Me.IdProducto.DataPropertyName = "IdProducto"
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        Me.IdProducto.Visible = False
        '
        'NombreProducto
        '
        Me.NombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "NOMBRE PRODUCTO"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.ReadOnly = True
        '
        'Rubro
        '
        Me.Rubro.DataPropertyName = "Rubro"
        Me.Rubro.HeaderText = "RUBRO"
        Me.Rubro.MinimumWidth = 230
        Me.Rubro.Name = "Rubro"
        Me.Rubro.ReadOnly = True
        Me.Rubro.Width = 230
        '
        'PrecioCosto
        '
        Me.PrecioCosto.DataPropertyName = "PrecioCosto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PrecioCosto.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrecioCosto.HeaderText = "PRECIO COSTO"
        Me.PrecioCosto.MinimumWidth = 120
        Me.PrecioCosto.Name = "PrecioCosto"
        Me.PrecioCosto.ReadOnly = True
        Me.PrecioCosto.Width = 120
        '
        'PrecioFinal
        '
        Me.PrecioFinal.DataPropertyName = "PrecioFinal"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PrecioFinal.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioFinal.HeaderText = "PRECIO FINAL"
        Me.PrecioFinal.MinimumWidth = 120
        Me.PrecioFinal.Name = "PrecioFinal"
        Me.PrecioFinal.ReadOnly = True
        Me.PrecioFinal.Width = 120
        '
        'Proveedor
        '
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "PROVEEDOR"
        Me.Proveedor.MinimumWidth = 200
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Width = 200
        '
        'StockExistencia
        '
        Me.StockExistencia.DataPropertyName = "StockExistencia"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.StockExistencia.DefaultCellStyle = DataGridViewCellStyle4
        Me.StockExistencia.HeaderText = "STOCK"
        Me.StockExistencia.Name = "StockExistencia"
        Me.StockExistencia.ReadOnly = True
        '
        'UnidadMedida
        '
        Me.UnidadMedida.DataPropertyName = "UnidadMedida"
        Me.UnidadMedida.HeaderText = "UNIDAD DE MEDIDA"
        Me.UnidadMedida.MinimumWidth = 160
        Me.UnidadMedida.Name = "UnidadMedida"
        Me.UnidadMedida.ReadOnly = True
        Me.UnidadMedida.Width = 160
        '
        'Activo
        '
        Me.Activo.DataPropertyName = "Activo"
        Me.Activo.HeaderText = "ACTIVO"
        Me.Activo.Name = "Activo"
        Me.Activo.ReadOnly = True
        Me.Activo.Visible = False
        '
        'frmVistaProductos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1144, 762)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboTipoBusqueda)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.dgvListadoProductos)
        Me.Controls.Add(Me.lblConsultaProduc)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1160, 778)
        Me.Name = "frmVistaProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTA DE PRODUCTOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvListadoProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblConsultaProduc As Label
    Friend WithEvents dgvListadoProductos As DataGridView
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents txtBuscador As TextBox
    Friend WithEvents lblBuscar As Label
    Friend WithEvents cboTipoBusqueda As ComboBox
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents NombreProducto As DataGridViewTextBoxColumn
    Friend WithEvents Rubro As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCosto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioFinal As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents StockExistencia As DataGridViewTextBoxColumn
    Friend WithEvents UnidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents Activo As DataGridViewTextBoxColumn
End Class
