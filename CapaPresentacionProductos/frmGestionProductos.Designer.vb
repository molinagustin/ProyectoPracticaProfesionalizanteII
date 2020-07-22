<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGestionProductos
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
        Me.lblGestioProductos = New System.Windows.Forms.Label()
        Me.lblNombreProd = New System.Windows.Forms.Label()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.lblPrecioCosto = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblUnidadMed = New System.Windows.Forms.Label()
        Me.txtNombreProducto = New System.Windows.Forms.TextBox()
        Me.cboRubro = New System.Windows.Forms.ComboBox()
        Me.txtPrecioCosto = New System.Windows.Forms.TextBox()
        Me.lblPrecioFinal = New System.Windows.Forms.Label()
        Me.txtPrecioFinal = New System.Windows.Forms.TextBox()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.cboUnidad = New System.Windows.Forms.ComboBox()
        Me.txtProv = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscarProv = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnBaja = New System.Windows.Forms.Button()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblGestioProductos
        '
        Me.lblGestioProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGestioProductos.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGestioProductos.Location = New System.Drawing.Point(12, 9)
        Me.lblGestioProductos.Name = "lblGestioProductos"
        Me.lblGestioProductos.Size = New System.Drawing.Size(647, 33)
        Me.lblGestioProductos.TabIndex = 2
        Me.lblGestioProductos.Text = "PRODUCTO"
        Me.lblGestioProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreProd
        '
        Me.lblNombreProd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombreProd.AutoSize = True
        Me.lblNombreProd.Location = New System.Drawing.Point(105, 138)
        Me.lblNombreProd.Name = "lblNombreProd"
        Me.lblNombreProd.Size = New System.Drawing.Size(149, 19)
        Me.lblNombreProd.TabIndex = 3
        Me.lblNombreProd.Text = "NOMBRE PRODUCTO"
        '
        'lblRubro
        '
        Me.lblRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Location = New System.Drawing.Point(105, 199)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(57, 19)
        Me.lblRubro.TabIndex = 4
        Me.lblRubro.Text = "RUBRO"
        '
        'lblPrecioCosto
        '
        Me.lblPrecioCosto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrecioCosto.AutoSize = True
        Me.lblPrecioCosto.Location = New System.Drawing.Point(105, 260)
        Me.lblPrecioCosto.Name = "lblPrecioCosto"
        Me.lblPrecioCosto.Size = New System.Drawing.Size(130, 19)
        Me.lblPrecioCosto.TabIndex = 5
        Me.lblPrecioCosto.Text = "PRECIO COSTO ($)"
        '
        'lblProveedor
        '
        Me.lblProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(105, 382)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(92, 19)
        Me.lblProveedor.TabIndex = 6
        Me.lblProveedor.Text = "PROVEEDOR"
        '
        'lblUnidadMed
        '
        Me.lblUnidadMed.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUnidadMed.AutoSize = True
        Me.lblUnidadMed.Location = New System.Drawing.Point(105, 504)
        Me.lblUnidadMed.Name = "lblUnidadMed"
        Me.lblUnidadMed.Size = New System.Drawing.Size(142, 19)
        Me.lblUnidadMed.TabIndex = 7
        Me.lblUnidadMed.Text = "UNIDAD DE MEDIDA"
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreProducto.Location = New System.Drawing.Point(338, 135)
        Me.txtNombreProducto.MaxLength = 35
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(181, 27)
        Me.txtNombreProducto.TabIndex = 1
        '
        'cboRubro
        '
        Me.cboRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRubro.FormattingEnabled = True
        Me.cboRubro.Location = New System.Drawing.Point(338, 196)
        Me.cboRubro.Name = "cboRubro"
        Me.cboRubro.Size = New System.Drawing.Size(181, 27)
        Me.cboRubro.TabIndex = 2
        '
        'txtPrecioCosto
        '
        Me.txtPrecioCosto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPrecioCosto.Location = New System.Drawing.Point(338, 257)
        Me.txtPrecioCosto.MaxLength = 100
        Me.txtPrecioCosto.Name = "txtPrecioCosto"
        Me.txtPrecioCosto.Size = New System.Drawing.Size(97, 27)
        Me.txtPrecioCosto.TabIndex = 3
        Me.txtPrecioCosto.Text = "0,00"
        Me.txtPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioFinal
        '
        Me.lblPrecioFinal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrecioFinal.AutoSize = True
        Me.lblPrecioFinal.Location = New System.Drawing.Point(105, 321)
        Me.lblPrecioFinal.Name = "lblPrecioFinal"
        Me.lblPrecioFinal.Size = New System.Drawing.Size(121, 19)
        Me.lblPrecioFinal.TabIndex = 8
        Me.lblPrecioFinal.Text = "PRECIO FINAL ($)"
        '
        'txtPrecioFinal
        '
        Me.txtPrecioFinal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPrecioFinal.Location = New System.Drawing.Point(338, 318)
        Me.txtPrecioFinal.Name = "txtPrecioFinal"
        Me.txtPrecioFinal.Size = New System.Drawing.Size(97, 27)
        Me.txtPrecioFinal.TabIndex = 5
        Me.txtPrecioFinal.Text = "0,00"
        Me.txtPrecioFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Location = New System.Drawing.Point(468, 260)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(20, 19)
        Me.lblPorcentaje.TabIndex = 10
        Me.lblPorcentaje.Text = "%"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPorcentaje.Location = New System.Drawing.Point(494, 257)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(71, 27)
        Me.txtPorcentaje.TabIndex = 4
        Me.txtPorcentaje.Text = "0,00"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboUnidad
        '
        Me.cboUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboUnidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboUnidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Location = New System.Drawing.Point(338, 501)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(181, 27)
        Me.cboUnidad.TabIndex = 8
        '
        'txtProv
        '
        Me.txtProv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtProv.Location = New System.Drawing.Point(338, 379)
        Me.txtProv.Name = "txtProv"
        Me.txtProv.ReadOnly = True
        Me.txtProv.Size = New System.Drawing.Size(181, 27)
        Me.txtProv.TabIndex = 21
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Image = Global.CapaPresentacionProductos.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(168, 622)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 47)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.CapaPresentacionProductos.My.Resources.Resources.back
        Me.btnCancelar.Location = New System.Drawing.Point(414, 622)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 47)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "   SALIR"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnBuscarProv
        '
        Me.btnBuscarProv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBuscarProv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarProv.Image = Global.CapaPresentacionProductos.My.Resources.Resources.search
        Me.btnBuscarProv.Location = New System.Drawing.Point(525, 373)
        Me.btnBuscarProv.Name = "btnBuscarProv"
        Me.btnBuscarProv.Size = New System.Drawing.Size(40, 37)
        Me.btnBuscarProv.TabIndex = 6
        Me.btnBuscarProv.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = Global.CapaPresentacionProductos.My.Resources.Resources.edit
        Me.btnModificar.Location = New System.Drawing.Point(560, 622)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(139, 47)
        Me.btnModificar.TabIndex = 11
        Me.btnModificar.Text = "MODIFICAR REGISTRO"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnBaja
        '
        Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBaja.Image = Global.CapaPresentacionProductos.My.Resources.Resources.user_remove
        Me.btnBaja.Location = New System.Drawing.Point(560, 569)
        Me.btnBaja.Name = "btnBaja"
        Me.btnBaja.Size = New System.Drawing.Size(139, 47)
        Me.btnBaja.TabIndex = 12
        Me.btnBaja.Text = "BAJA REGISTRO"
        Me.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBaja.UseVisualStyleBackColor = True
        '
        'txtStock
        '
        Me.txtStock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtStock.Location = New System.Drawing.Point(338, 440)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(97, 27)
        Me.txtStock.TabIndex = 7
        Me.txtStock.Text = "0"
        '
        'lblStock
        '
        Me.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblStock.AutoSize = True
        Me.lblStock.Location = New System.Drawing.Point(105, 443)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(121, 19)
        Me.lblStock.TabIndex = 23
        Me.lblStock.Text = "STOCK ALMACEN"
        '
        'frmGestionProductos
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(721, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.btnBuscarProv)
        Me.Controls.Add(Me.txtProv)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnBaja)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cboUnidad)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.lblPorcentaje)
        Me.Controls.Add(Me.txtPrecioFinal)
        Me.Controls.Add(Me.lblPrecioFinal)
        Me.Controls.Add(Me.txtPrecioCosto)
        Me.Controls.Add(Me.cboRubro)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.lblUnidadMed)
        Me.Controls.Add(Me.lblProveedor)
        Me.Controls.Add(Me.lblPrecioCosto)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.lblNombreProd)
        Me.Controls.Add(Me.lblGestioProductos)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(737, 759)
        Me.MinimumSize = New System.Drawing.Size(737, 759)
        Me.Name = "frmGestionProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALTA-MODIFICACION PRODUCTOS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGestioProductos As Label
    Friend WithEvents lblNombreProd As Label
    Friend WithEvents lblRubro As Label
    Friend WithEvents lblPrecioCosto As Label
    Friend WithEvents lblProveedor As Label
    Friend WithEvents lblUnidadMed As Label
    Friend WithEvents txtNombreProducto As TextBox
    Friend WithEvents cboRubro As ComboBox
    Friend WithEvents txtPrecioCosto As TextBox
    Friend WithEvents lblPrecioFinal As Label
    Friend WithEvents txtPrecioFinal As TextBox
    Friend WithEvents lblPorcentaje As Label
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents cboUnidad As ComboBox
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnBaja As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnBuscarProv As Button
    Friend WithEvents txtProv As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents lblStock As Label
End Class
