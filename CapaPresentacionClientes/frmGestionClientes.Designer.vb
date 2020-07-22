<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionClientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblGestionCliente = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblTipoDoc = New System.Windows.Forms.Label()
        Me.lblNumDoc = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblCondIVA = New System.Windows.Forms.Label()
        Me.lblLocalidad = New System.Windows.Forms.Label()
        Me.txtNombCliente = New System.Windows.Forms.TextBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.txtLocalidad = New System.Windows.Forms.TextBox()
        Me.cboCondIVA = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnBaja = New System.Windows.Forms.Button()
        Me.btnBuscarLocalidad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblGestionCliente
        '
        Me.lblGestionCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGestionCliente.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGestionCliente.Location = New System.Drawing.Point(12, 9)
        Me.lblGestionCliente.Name = "lblGestionCliente"
        Me.lblGestionCliente.Size = New System.Drawing.Size(687, 33)
        Me.lblGestionCliente.TabIndex = 2
        Me.lblGestionCliente.Text = "CLIENTE"
        Me.lblGestionCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(141, 128)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(127, 19)
        Me.lblNombreCliente.TabIndex = 3
        Me.lblNombreCliente.Text = "NOMBRE CLIENTE"
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.Location = New System.Drawing.Point(141, 201)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(134, 19)
        Me.lblTipoDoc.TabIndex = 4
        Me.lblTipoDoc.Text = "TIPO DOCUMENTO"
        '
        'lblNumDoc
        '
        Me.lblNumDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNumDoc.AutoSize = True
        Me.lblNumDoc.Location = New System.Drawing.Point(141, 274)
        Me.lblNumDoc.Name = "lblNumDoc"
        Me.lblNumDoc.Size = New System.Drawing.Size(164, 19)
        Me.lblNumDoc.TabIndex = 5
        Me.lblNumDoc.Text = "NUMERO DOCUMENTO"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDomicilio.AutoSize = True
        Me.lblDomicilio.Location = New System.Drawing.Point(141, 347)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(82, 19)
        Me.lblDomicilio.TabIndex = 6
        Me.lblDomicilio.Text = "DOMICILIO"
        '
        'lblCondIVA
        '
        Me.lblCondIVA.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCondIVA.AutoSize = True
        Me.lblCondIVA.Location = New System.Drawing.Point(141, 420)
        Me.lblCondIVA.Name = "lblCondIVA"
        Me.lblCondIVA.Size = New System.Drawing.Size(179, 19)
        Me.lblCondIVA.TabIndex = 7
        Me.lblCondIVA.Text = "CONDICION FRENTE A IVA"
        '
        'lblLocalidad
        '
        Me.lblLocalidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.Location = New System.Drawing.Point(141, 493)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(85, 19)
        Me.lblLocalidad.TabIndex = 8
        Me.lblLocalidad.Text = "LOCALIDAD"
        '
        'txtNombCliente
        '
        Me.txtNombCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombCliente.Location = New System.Drawing.Point(353, 125)
        Me.txtNombCliente.MaxLength = 40
        Me.txtNombCliente.Name = "txtNombCliente"
        Me.txtNombCliente.Size = New System.Drawing.Size(222, 27)
        Me.txtNombCliente.TabIndex = 1
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNumDoc.Location = New System.Drawing.Point(353, 271)
        Me.txtNumDoc.MaxLength = 11
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(191, 27)
        Me.txtNumDoc.TabIndex = 3
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDomicilio.Location = New System.Drawing.Point(353, 344)
        Me.txtDomicilio.MaxLength = 35
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(222, 27)
        Me.txtDomicilio.TabIndex = 4
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Location = New System.Drawing.Point(353, 198)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(110, 27)
        Me.cboTipoDoc.TabIndex = 2
        '
        'txtLocalidad
        '
        Me.txtLocalidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtLocalidad.Location = New System.Drawing.Point(353, 490)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.ReadOnly = True
        Me.txtLocalidad.Size = New System.Drawing.Size(183, 27)
        Me.txtLocalidad.TabIndex = 13
        '
        'cboCondIVA
        '
        Me.cboCondIVA.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboCondIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCondIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCondIVA.FormattingEnabled = True
        Me.cboCondIVA.Location = New System.Drawing.Point(353, 417)
        Me.cboCondIVA.Name = "cboCondIVA"
        Me.cboCondIVA.Size = New System.Drawing.Size(191, 27)
        Me.cboCondIVA.TabIndex = 5
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Image = Global.CapaPresentacionClientes.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(184, 625)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 47)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.CapaPresentacionClientes.My.Resources.Resources.back
        Me.btnCancelar.Location = New System.Drawing.Point(403, 625)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 47)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "   SALIR"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = Global.CapaPresentacionClientes.My.Resources.Resources.edit
        Me.btnModificar.Location = New System.Drawing.Point(560, 625)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(139, 47)
        Me.btnModificar.TabIndex = 15
        Me.btnModificar.Text = "MODIFICAR REGISTRO"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnBaja
        '
        Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBaja.Image = Global.CapaPresentacionClientes.My.Resources.Resources.user_remove
        Me.btnBaja.Location = New System.Drawing.Point(560, 572)
        Me.btnBaja.Name = "btnBaja"
        Me.btnBaja.Size = New System.Drawing.Size(139, 47)
        Me.btnBaja.TabIndex = 14
        Me.btnBaja.Text = "BAJA REGISTRO"
        Me.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBaja.UseVisualStyleBackColor = True
        '
        'btnBuscarLocalidad
        '
        Me.btnBuscarLocalidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBuscarLocalidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarLocalidad.Image = Global.CapaPresentacionClientes.My.Resources.Resources.search
        Me.btnBuscarLocalidad.Location = New System.Drawing.Point(542, 484)
        Me.btnBuscarLocalidad.Name = "btnBuscarLocalidad"
        Me.btnBuscarLocalidad.Size = New System.Drawing.Size(40, 37)
        Me.btnBuscarLocalidad.TabIndex = 6
        Me.btnBuscarLocalidad.UseVisualStyleBackColor = True
        '
        'frmGestionClientes
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(721, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnBaja)
        Me.Controls.Add(Me.btnBuscarLocalidad)
        Me.Controls.Add(Me.cboCondIVA)
        Me.Controls.Add(Me.txtLocalidad)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.txtNombCliente)
        Me.Controls.Add(Me.lblLocalidad)
        Me.Controls.Add(Me.lblCondIVA)
        Me.Controls.Add(Me.lblDomicilio)
        Me.Controls.Add(Me.lblNumDoc)
        Me.Controls.Add(Me.lblTipoDoc)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.lblGestionCliente)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(737, 759)
        Me.MinimumSize = New System.Drawing.Size(737, 759)
        Me.Name = "frmGestionClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALTA-MODIFICACION CLIENTE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblGestionCliente As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblTipoDoc As Label
    Friend WithEvents lblNumDoc As Label
    Friend WithEvents lblDomicilio As Label
    Friend WithEvents lblCondIVA As Label
    Friend WithEvents lblLocalidad As Label
    Friend WithEvents txtNombCliente As TextBox
    Friend WithEvents txtNumDoc As TextBox
    Friend WithEvents txtDomicilio As TextBox
    Friend WithEvents cboTipoDoc As ComboBox
    Friend WithEvents txtLocalidad As TextBox
    Friend WithEvents cboCondIVA As ComboBox
    Friend WithEvents btnBuscarLocalidad As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnBaja As Button
End Class
