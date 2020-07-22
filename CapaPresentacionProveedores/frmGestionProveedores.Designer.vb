<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionProveedores
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
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.lblGestionProv = New System.Windows.Forms.Label()
        Me.lblNombreProv = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblTel = New System.Windows.Forms.Label()
        Me.lblCorreoE = New System.Windows.Forms.Label()
        Me.txtNombProv = New System.Windows.Forms.TextBox()
        Me.txtDom = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBaja = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.edit
        Me.btnModificar.Location = New System.Drawing.Point(545, 511)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(139, 47)
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "MODIFICAR REGISTRO"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'lblGestionProv
        '
        Me.lblGestionProv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGestionProv.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGestionProv.Location = New System.Drawing.Point(12, 9)
        Me.lblGestionProv.MaximumSize = New System.Drawing.Size(672, 33)
        Me.lblGestionProv.MinimumSize = New System.Drawing.Size(672, 33)
        Me.lblGestionProv.Name = "lblGestionProv"
        Me.lblGestionProv.Size = New System.Drawing.Size(672, 33)
        Me.lblGestionProv.TabIndex = 20
        Me.lblGestionProv.Text = "PROVEEDOR"
        Me.lblGestionProv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreProv
        '
        Me.lblNombreProv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombreProv.AutoSize = True
        Me.lblNombreProv.Location = New System.Drawing.Point(148, 136)
        Me.lblNombreProv.Name = "lblNombreProv"
        Me.lblNombreProv.Size = New System.Drawing.Size(156, 19)
        Me.lblNombreProv.TabIndex = 21
        Me.lblNombreProv.Text = "NOMBRE PROVEEDOR"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDomicilio.AutoSize = True
        Me.lblDomicilio.Location = New System.Drawing.Point(148, 219)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(82, 19)
        Me.lblDomicilio.TabIndex = 22
        Me.lblDomicilio.Text = "DOMICILIO"
        '
        'lblTel
        '
        Me.lblTel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTel.AutoSize = True
        Me.lblTel.Location = New System.Drawing.Point(148, 302)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(79, 19)
        Me.lblTel.TabIndex = 23
        Me.lblTel.Text = "TELEFONO"
        '
        'lblCorreoE
        '
        Me.lblCorreoE.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCorreoE.AutoSize = True
        Me.lblCorreoE.Location = New System.Drawing.Point(148, 385)
        Me.lblCorreoE.Name = "lblCorreoE"
        Me.lblCorreoE.Size = New System.Drawing.Size(164, 19)
        Me.lblCorreoE.TabIndex = 24
        Me.lblCorreoE.Text = "CORREO ELECTRONICO"
        '
        'txtNombProv
        '
        Me.txtNombProv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombProv.Location = New System.Drawing.Point(328, 133)
        Me.txtNombProv.MaxLength = 40
        Me.txtNombProv.Name = "txtNombProv"
        Me.txtNombProv.Size = New System.Drawing.Size(256, 27)
        Me.txtNombProv.TabIndex = 1
        '
        'txtDom
        '
        Me.txtDom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDom.Location = New System.Drawing.Point(328, 216)
        Me.txtDom.MaxLength = 40
        Me.txtDom.Name = "txtDom"
        Me.txtDom.Size = New System.Drawing.Size(256, 27)
        Me.txtDom.TabIndex = 2
        '
        'txtTel
        '
        Me.txtTel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTel.Location = New System.Drawing.Point(328, 299)
        Me.txtTel.MaxLength = 40
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(134, 27)
        Me.txtTel.TabIndex = 3
        '
        'txtCorreo
        '
        Me.txtCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCorreo.Location = New System.Drawing.Point(328, 383)
        Me.txtCorreo.MaxLength = 100
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(190, 27)
        Me.txtCorreo.TabIndex = 4
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(191, 511)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 47)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.back
        Me.btnCancelar.Location = New System.Drawing.Point(397, 511)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 47)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "   SALIR"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnBaja
        '
        Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBaja.Image = Global.CapaPresentacionProveedores.My.Resources.Resources.user_remove
        Me.btnBaja.Location = New System.Drawing.Point(545, 458)
        Me.btnBaja.Name = "btnBaja"
        Me.btnBaja.Size = New System.Drawing.Size(139, 47)
        Me.btnBaja.TabIndex = 18
        Me.btnBaja.Text = "BAJA REGISTRO"
        Me.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBaja.UseVisualStyleBackColor = True
        '
        'frmGestionProveedores
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(696, 581)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.txtDom)
        Me.Controls.Add(Me.txtNombProv)
        Me.Controls.Add(Me.lblCorreoE)
        Me.Controls.Add(Me.lblTel)
        Me.Controls.Add(Me.lblDomicilio)
        Me.Controls.Add(Me.lblNombreProv)
        Me.Controls.Add(Me.lblGestionProv)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnBaja)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmGestionProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALTA-MODIFICACION PROVEEDORES"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnModificar As Button
    Friend WithEvents btnBaja As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblGestionProv As Label
    Friend WithEvents lblNombreProv As Label
    Friend WithEvents lblDomicilio As Label
    Friend WithEvents lblTel As Label
    Friend WithEvents lblCorreoE As Label
    Friend WithEvents txtNombProv As TextBox
    Friend WithEvents txtDom As TextBox
    Friend WithEvents txtTel As TextBox
    Friend WithEvents txtCorreo As TextBox
End Class
