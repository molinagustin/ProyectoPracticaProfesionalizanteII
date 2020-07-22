<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionUsuario
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
        Me.lblUsuarioAfip = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblClaveF = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClaveF = New System.Windows.Forms.TextBox()
        Me.cbxMostrar = New System.Windows.Forms.CheckBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblUsuarioAfip
        '
        Me.lblUsuarioAfip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUsuarioAfip.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioAfip.Location = New System.Drawing.Point(12, 9)
        Me.lblUsuarioAfip.Name = "lblUsuarioAfip"
        Me.lblUsuarioAfip.Size = New System.Drawing.Size(608, 33)
        Me.lblUsuarioAfip.TabIndex = 0
        Me.lblUsuarioAfip.Text = "USUARIO AFIP"
        Me.lblUsuarioAfip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUsuario
        '
        Me.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblUsuario.Location = New System.Drawing.Point(151, 156)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(69, 19)
        Me.lblUsuario.TabIndex = 1
        Me.lblUsuario.Text = "USUARIO"
        '
        'lblClaveF
        '
        Me.lblClaveF.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblClaveF.AutoSize = True
        Me.lblClaveF.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblClaveF.Location = New System.Drawing.Point(151, 234)
        Me.lblClaveF.Name = "lblClaveF"
        Me.lblClaveF.Size = New System.Drawing.Size(97, 19)
        Me.lblClaveF.TabIndex = 2
        Me.lblClaveF.Text = "CLAVE FISCAL"
        '
        'txtUsuario
        '
        Me.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUsuario.Location = New System.Drawing.Point(300, 153)
        Me.txtUsuario.MaxLength = 11
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(152, 27)
        Me.txtUsuario.TabIndex = 1
        '
        'txtClaveF
        '
        Me.txtClaveF.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtClaveF.Location = New System.Drawing.Point(300, 231)
        Me.txtClaveF.Name = "txtClaveF"
        Me.txtClaveF.Size = New System.Drawing.Size(152, 27)
        Me.txtClaveF.TabIndex = 2
        Me.txtClaveF.UseSystemPasswordChar = True
        '
        'cbxMostrar
        '
        Me.cbxMostrar.AutoSize = True
        Me.cbxMostrar.Location = New System.Drawing.Point(300, 264)
        Me.cbxMostrar.Name = "cbxMostrar"
        Me.cbxMostrar.Size = New System.Drawing.Size(188, 23)
        Me.cbxMostrar.TabIndex = 5
        Me.cbxMostrar.Text = "MOSTRAR CONTRASEÑA"
        Me.cbxMostrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.CapaPresentacionUsuarioAFIP.My.Resources.Resources.ok
        Me.btnGuardar.Location = New System.Drawing.Point(142, 362)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(121, 50)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.CapaPresentacionUsuarioAFIP.My.Resources.Resources.stop_error
        Me.btnCancelar.Location = New System.Drawing.Point(345, 362)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 50)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmGestionUsuario
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(632, 458)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxMostrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtClaveF)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblClaveF)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblUsuarioAfip)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(648, 497)
        Me.MinimumSize = New System.Drawing.Size(648, 497)
        Me.Name = "frmGestionUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USUARIO AFIP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblUsuarioAfip As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblClaveF As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtClaveF As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents cbxMostrar As CheckBox
End Class
