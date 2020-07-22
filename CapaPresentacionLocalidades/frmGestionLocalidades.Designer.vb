<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGestionLocalidades
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
        Me.lblLocalidad = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.cboProvincia = New System.Windows.Forms.ComboBox()
        Me.lblNombreLocalidad = New System.Windows.Forms.Label()
        Me.txtNombreLocalidad = New System.Windows.Forms.TextBox()
        Me.lblCodigoPostal = New System.Windows.Forms.Label()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblLocalidad
        '
        Me.lblLocalidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocalidad.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalidad.Location = New System.Drawing.Point(12, 9)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(598, 33)
        Me.lblLocalidad.TabIndex = 0
        Me.lblLocalidad.Text = "LOCALIDAD"
        Me.lblLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProvincia
        '
        Me.lblProvincia.AutoSize = True
        Me.lblProvincia.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblProvincia.Location = New System.Drawing.Point(160, 120)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(82, 19)
        Me.lblProvincia.TabIndex = 1
        Me.lblProvincia.Text = "PROVINCIA"
        '
        'cboProvincia
        '
        Me.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProvincia.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(353, 117)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(160, 27)
        Me.cboProvincia.TabIndex = 1
        '
        'lblNombreLocalidad
        '
        Me.lblNombreLocalidad.AutoSize = True
        Me.lblNombreLocalidad.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblNombreLocalidad.Location = New System.Drawing.Point(160, 196)
        Me.lblNombreLocalidad.Name = "lblNombreLocalidad"
        Me.lblNombreLocalidad.Size = New System.Drawing.Size(171, 19)
        Me.lblNombreLocalidad.TabIndex = 3
        Me.lblNombreLocalidad.Text = "NOMBRE DE LOCALIDAD"
        '
        'txtNombreLocalidad
        '
        Me.txtNombreLocalidad.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.txtNombreLocalidad.Location = New System.Drawing.Point(353, 193)
        Me.txtNombreLocalidad.Name = "txtNombreLocalidad"
        Me.txtNombreLocalidad.Size = New System.Drawing.Size(160, 27)
        Me.txtNombreLocalidad.TabIndex = 2
        '
        'lblCodigoPostal
        '
        Me.lblCodigoPostal.AutoSize = True
        Me.lblCodigoPostal.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblCodigoPostal.Location = New System.Drawing.Point(160, 272)
        Me.lblCodigoPostal.Name = "lblCodigoPostal"
        Me.lblCodigoPostal.Size = New System.Drawing.Size(117, 19)
        Me.lblCodigoPostal.TabIndex = 5
        Me.lblCodigoPostal.Text = "CODIGO POSTAL"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.txtCodigoPostal.Location = New System.Drawing.Point(353, 269)
        Me.txtCodigoPostal.MaxLength = 5
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(100, 27)
        Me.txtCodigoPostal.TabIndex = 3
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.btnAceptar.Image = Global.CapaPresentacionLocalidades.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(156, 366)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 50)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.btnCancelar.Image = Global.CapaPresentacionLocalidades.My.Resources.Resources.stop_error
        Me.btnCancelar.Location = New System.Drawing.Point(365, 366)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 50)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmGestionLocalidades
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(632, 458)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtCodigoPostal)
        Me.Controls.Add(Me.lblCodigoPostal)
        Me.Controls.Add(Me.txtNombreLocalidad)
        Me.Controls.Add(Me.lblNombreLocalidad)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.lblLocalidad)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(648, 497)
        Me.MinimumSize = New System.Drawing.Size(648, 497)
        Me.Name = "frmGestionLocalidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOCALIDAD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLocalidad As Label
    Friend WithEvents lblProvincia As Label
    Friend WithEvents cboProvincia As ComboBox
    Friend WithEvents lblNombreLocalidad As Label
    Friend WithEvents txtNombreLocalidad As TextBox
    Friend WithEvents lblCodigoPostal As Label
    Friend WithEvents txtCodigoPostal As TextBox
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
End Class
