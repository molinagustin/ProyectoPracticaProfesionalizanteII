<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDialogoLocalidades
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
        Me.lblListadoLocalidades = New System.Windows.Forms.Label()
        Me.cboProvincias = New System.Windows.Forms.ComboBox()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.dgvLocalidades = New System.Windows.Forms.DataGridView()
        Me.IdLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Provincia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.dgvLocalidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblListadoLocalidades
        '
        Me.lblListadoLocalidades.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblListadoLocalidades.BackColor = System.Drawing.Color.Transparent
        Me.lblListadoLocalidades.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListadoLocalidades.ForeColor = System.Drawing.Color.Black
        Me.lblListadoLocalidades.Location = New System.Drawing.Point(11, 9)
        Me.lblListadoLocalidades.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblListadoLocalidades.Name = "lblListadoLocalidades"
        Me.lblListadoLocalidades.Size = New System.Drawing.Size(785, 36)
        Me.lblListadoLocalidades.TabIndex = 0
        Me.lblListadoLocalidades.Text = "LISTADO DE LOCALIDADES"
        Me.lblListadoLocalidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboProvincias
        '
        Me.cboProvincias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProvincias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProvincias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProvincias.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.cboProvincias.FormattingEnabled = True
        Me.cboProvincias.Location = New System.Drawing.Point(586, 112)
        Me.cboProvincias.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cboProvincias.Name = "cboProvincias"
        Me.cboProvincias.Size = New System.Drawing.Size(210, 27)
        Me.cboProvincias.TabIndex = 1
        '
        'lblProvincia
        '
        Me.lblProvincia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProvincia.AutoSize = True
        Me.lblProvincia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(498, 115)
        Me.lblProvincia.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(84, 19)
        Me.lblProvincia.TabIndex = 2
        Me.lblProvincia.Text = "PROVINCIA"
        '
        'dgvLocalidades
        '
        Me.dgvLocalidades.AllowUserToAddRows = False
        Me.dgvLocalidades.AllowUserToDeleteRows = False
        Me.dgvLocalidades.AllowUserToResizeColumns = False
        Me.dgvLocalidades.AllowUserToResizeRows = False
        Me.dgvLocalidades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLocalidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvLocalidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLocalidades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLocalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLocalidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdLocalidad, Me.NombreLocalidad, Me.CP, Me.Provincia})
        Me.dgvLocalidades.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvLocalidades.Location = New System.Drawing.Point(11, 145)
        Me.dgvLocalidades.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvLocalidades.MaximumSize = New System.Drawing.Size(794, 303)
        Me.dgvLocalidades.MinimumSize = New System.Drawing.Size(794, 303)
        Me.dgvLocalidades.MultiSelect = False
        Me.dgvLocalidades.Name = "dgvLocalidades"
        Me.dgvLocalidades.ReadOnly = True
        Me.dgvLocalidades.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 15.0!)
        Me.dgvLocalidades.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLocalidades.RowTemplate.Height = 24
        Me.dgvLocalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLocalidades.Size = New System.Drawing.Size(794, 303)
        Me.dgvLocalidades.TabIndex = 3
        '
        'IdLocalidad
        '
        Me.IdLocalidad.DataPropertyName = "IdLocalidad"
        Me.IdLocalidad.HeaderText = "IdLocalidad"
        Me.IdLocalidad.Name = "IdLocalidad"
        Me.IdLocalidad.ReadOnly = True
        Me.IdLocalidad.Visible = False
        '
        'NombreLocalidad
        '
        Me.NombreLocalidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreLocalidad.DataPropertyName = "NombreLocalidad"
        Me.NombreLocalidad.HeaderText = "NOMBRE DE LA LOCALIDAD"
        Me.NombreLocalidad.Name = "NombreLocalidad"
        Me.NombreLocalidad.ReadOnly = True
        '
        'CP
        '
        Me.CP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CP.DataPropertyName = "CP"
        Me.CP.HeaderText = "CODIGO POSTAL"
        Me.CP.Name = "CP"
        Me.CP.ReadOnly = True
        Me.CP.Width = 150
        '
        'Provincia
        '
        Me.Provincia.DataPropertyName = "Provincia"
        Me.Provincia.HeaderText = "PROVINCIA"
        Me.Provincia.Name = "Provincia"
        Me.Provincia.ReadOnly = True
        Me.Provincia.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Image = Global.CapaPresentacionLocalidades.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(221, 471)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 47)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = Global.CapaPresentacionLocalidades.My.Resources.Resources.back
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(445, 474)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(121, 47)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "     SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = Global.CapaPresentacionLocalidades.My.Resources.Resources.insert
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(680, 471)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(121, 47)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "  AGREGAR NUEVA"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmDialogoLocalidades
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(817, 533)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.dgvLocalidades)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.cboProvincias)
        Me.Controls.Add(Me.lblListadoLocalidades)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximumSize = New System.Drawing.Size(833, 572)
        Me.MinimumSize = New System.Drawing.Size(833, 572)
        Me.Name = "frmDialogoLocalidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOCALIDADES"
        CType(Me.dgvLocalidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblListadoLocalidades As Label
    Friend WithEvents cboProvincias As ComboBox
    Friend WithEvents lblProvincia As Label
    Friend WithEvents dgvLocalidades As DataGridView
    Friend WithEvents IdLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents NombreLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents CP As DataGridViewTextBoxColumn
    Friend WithEvents Provincia As DataGridViewTextBoxColumn
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAceptar As Button
End Class
