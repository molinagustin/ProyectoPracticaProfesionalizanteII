<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDialogoProveedores
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblListadoProv = New System.Windows.Forms.Label()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.dgvListadoProv = New System.Windows.Forms.DataGridView()
        Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DomicilioProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorreoElectronico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.dgvListadoProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblListadoProv
        '
        Me.lblListadoProv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblListadoProv.BackColor = System.Drawing.Color.Transparent
        Me.lblListadoProv.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListadoProv.ForeColor = System.Drawing.Color.Black
        Me.lblListadoProv.Location = New System.Drawing.Point(12, 9)
        Me.lblListadoProv.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblListadoProv.Name = "lblListadoProv"
        Me.lblListadoProv.Size = New System.Drawing.Size(1110, 36)
        Me.lblListadoProv.TabIndex = 16
        Me.lblListadoProv.Text = "LISTADO DE PROVEEDORES"
        Me.lblListadoProv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBuscador
        '
        Me.txtBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBuscador.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.txtBuscador.Location = New System.Drawing.Point(926, 99)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(201, 29)
        Me.txtBuscador.TabIndex = 18
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Font = New System.Drawing.Font("Calibri", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblBuscar.Location = New System.Drawing.Point(843, 102)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(77, 22)
        Me.lblBuscar.TabIndex = 19
        Me.lblBuscar.Text = "BUSCAR:"
        '
        'dgvListadoProv
        '
        Me.dgvListadoProv.AllowUserToAddRows = False
        Me.dgvListadoProv.AllowUserToDeleteRows = False
        Me.dgvListadoProv.AllowUserToResizeColumns = False
        Me.dgvListadoProv.AllowUserToResizeRows = False
        Me.dgvListadoProv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoProv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvListadoProv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListadoProv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListadoProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoProv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProveedor, Me.NombreProveedor, Me.DomicilioProveedor, Me.Telefono, Me.CorreoElectronico, Me.Activo})
        Me.dgvListadoProv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvListadoProv.Location = New System.Drawing.Point(12, 138)
        Me.dgvListadoProv.MaximumSize = New System.Drawing.Size(1120, 319)
        Me.dgvListadoProv.MinimumSize = New System.Drawing.Size(1120, 319)
        Me.dgvListadoProv.MultiSelect = False
        Me.dgvListadoProv.Name = "dgvListadoProv"
        Me.dgvListadoProv.ReadOnly = True
        Me.dgvListadoProv.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 15.0!)
        Me.dgvListadoProv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListadoProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListadoProv.Size = New System.Drawing.Size(1120, 319)
        Me.dgvListadoProv.TabIndex = 20
        '
        'IdProveedor
        '
        Me.IdProveedor.DataPropertyName = "IdProveedor"
        Me.IdProveedor.HeaderText = "IdProveedor"
        Me.IdProveedor.Name = "IdProveedor"
        Me.IdProveedor.ReadOnly = True
        Me.IdProveedor.Visible = False
        '
        'NombreProveedor
        '
        Me.NombreProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreProveedor.DataPropertyName = "NombreProveedor"
        Me.NombreProveedor.HeaderText = "NOMBRE PROVEEDOR"
        Me.NombreProveedor.Name = "NombreProveedor"
        Me.NombreProveedor.ReadOnly = True
        '
        'DomicilioProveedor
        '
        Me.DomicilioProveedor.DataPropertyName = "DomicilioProveedor"
        Me.DomicilioProveedor.HeaderText = "DOMICILIO"
        Me.DomicilioProveedor.MinimumWidth = 350
        Me.DomicilioProveedor.Name = "DomicilioProveedor"
        Me.DomicilioProveedor.ReadOnly = True
        Me.DomicilioProveedor.Width = 350
        '
        'Telefono
        '
        Me.Telefono.DataPropertyName = "Telefono"
        Me.Telefono.HeaderText = "TELEFONO"
        Me.Telefono.MinimumWidth = 150
        Me.Telefono.Name = "Telefono"
        Me.Telefono.ReadOnly = True
        Me.Telefono.Width = 150
        '
        'CorreoElectronico
        '
        Me.CorreoElectronico.DataPropertyName = "CorreoElectronico"
        Me.CorreoElectronico.HeaderText = "CORREO ELECTRONICO"
        Me.CorreoElectronico.MinimumWidth = 230
        Me.CorreoElectronico.Name = "CorreoElectronico"
        Me.CorreoElectronico.ReadOnly = True
        Me.CorreoElectronico.Width = 230
        '
        'Activo
        '
        Me.Activo.DataPropertyName = "Activo"
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        Me.Activo.ReadOnly = True
        Me.Activo.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.btnAceptar.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(416, 474)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAceptar.MaximumSize = New System.Drawing.Size(121, 47)
        Me.btnAceptar.MinimumSize = New System.Drawing.Size(121, 47)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 47)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.btnSalir.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.back
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(668, 474)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.MaximumSize = New System.Drawing.Size(121, 47)
        Me.btnSalir.MinimumSize = New System.Drawing.Size(121, 47)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(121, 47)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "     SALIR"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.insert
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(1006, 474)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(121, 47)
        Me.btnAgregar.TabIndex = 21
        Me.btnAgregar.Text = "  AGREGAR NUEVO"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmDialogoProveedores
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1143, 533)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvListadoProv)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.lblListadoProv)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(1159, 572)
        Me.MinimumSize = New System.Drawing.Size(1159, 572)
        Me.Name = "frmDialogoProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PROVEEDORES"
        CType(Me.dgvListadoProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblListadoProv As Label
    Friend WithEvents txtBuscador As TextBox
    Friend WithEvents lblBuscar As Label
    Friend WithEvents dgvListadoProv As DataGridView
    Friend WithEvents btnAgregar As Button
    Friend WithEvents IdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents NombreProveedor As DataGridViewTextBoxColumn
    Friend WithEvents DomicilioProveedor As DataGridViewTextBoxColumn
    Friend WithEvents Telefono As DataGridViewTextBoxColumn
    Friend WithEvents CorreoElectronico As DataGridViewTextBoxColumn
    Friend WithEvents Activo As DataGridViewTextBoxColumn
End Class
