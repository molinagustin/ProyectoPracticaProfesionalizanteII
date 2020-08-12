<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInformes
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.chrInformesClientes = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cboTipoBusqueda = New System.Windows.Forms.ComboBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblInfoSobre = New System.Windows.Forms.Label()
        Me.lblInformes = New System.Windows.Forms.Label()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.chrInformesVentas = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.chrInformesClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chrInformesVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chrInformesClientes
        '
        Me.chrInformesClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Area3DStyle.Inclination = 5
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.Rotation = 5
        ChartArea1.Area3DStyle.WallWidth = 0
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.BackColor = System.Drawing.Color.White
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.Name = "ChartArea1"
        Me.chrInformesClientes.ChartAreas.Add(ChartArea1)
        Legend1.Enabled = False
        Legend1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.chrInformesClientes.Legends.Add(Legend1)
        Me.chrInformesClientes.Location = New System.Drawing.Point(306, 96)
        Me.chrInformesClientes.MinimumSize = New System.Drawing.Size(826, 575)
        Me.chrInformesClientes.Name = "chrInformesClientes"
        Series1.ChartArea = "ChartArea1"
        Series1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.YValuesPerPoint = 3
        Me.chrInformesClientes.Series.Add(Series1)
        Me.chrInformesClientes.Size = New System.Drawing.Size(826, 610)
        Me.chrInformesClientes.TabIndex = 2
        Title1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Title1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.Name = "titulo"
        Title1.Text = "CLIENTES CARGADOS"
        Me.chrInformesClientes.Titles.Add(Title1)
        '
        'cboTipoBusqueda
        '
        Me.cboTipoBusqueda.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.cboTipoBusqueda.FormattingEnabled = True
        Me.cboTipoBusqueda.Location = New System.Drawing.Point(157, 148)
        Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
        Me.cboTipoBusqueda.Size = New System.Drawing.Size(143, 29)
        Me.cboTipoBusqueda.TabIndex = 1
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.CalendarFont = New System.Drawing.Font("Calibri", 13.0!)
        Me.dtpFechaDesde.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(157, 222)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(124, 29)
        Me.dtpFechaDesde.TabIndex = 2
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.CalendarFont = New System.Drawing.Font("Calibri", 13.0!)
        Me.dtpFechaHasta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(157, 283)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(124, 29)
        Me.dtpFechaHasta.TabIndex = 3
        '
        'lblInfoSobre
        '
        Me.lblInfoSobre.AutoSize = True
        Me.lblInfoSobre.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.lblInfoSobre.Location = New System.Drawing.Point(12, 151)
        Me.lblInfoSobre.Name = "lblInfoSobre"
        Me.lblInfoSobre.Size = New System.Drawing.Size(139, 22)
        Me.lblInfoSobre.TabIndex = 6
        Me.lblInfoSobre.Text = "INFORME SOBRE:"
        '
        'lblInformes
        '
        Me.lblInformes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInformes.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInformes.Location = New System.Drawing.Point(12, 9)
        Me.lblInformes.Name = "lblInformes"
        Me.lblInformes.Size = New System.Drawing.Size(1120, 35)
        Me.lblInformes.TabIndex = 7
        Me.lblInformes.Text = "INFORMES"
        Me.lblInformes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.lblDesde.Location = New System.Drawing.Point(93, 228)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(58, 22)
        Me.lblDesde.TabIndex = 8
        Me.lblDesde.Text = "DESDE"
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Font = New System.Drawing.Font("Calibri", 13.0!)
        Me.lblHasta.Location = New System.Drawing.Point(94, 289)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(57, 22)
        Me.lblHasta.TabIndex = 9
        Me.lblHasta.Text = "HASTA"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = Global.CapaPresentacionInformes.My.Resources.Resources.back
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(1016, 749)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 39)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "     SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.Image = Global.CapaPresentacionInformes.My.Resources.Resources.table
        Me.btnGenerar.Location = New System.Drawing.Point(524, 713)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(128, 74)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "GENERAR INFORME"
        Me.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'chrInformesVentas
        '
        Me.chrInformesVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Area3DStyle.Enable3D = True
        ChartArea2.Area3DStyle.Inclination = 5
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.Rotation = 5
        ChartArea2.Area3DStyle.WallWidth = 0
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.BackColor = System.Drawing.Color.White
        ChartArea2.BackSecondaryColor = System.Drawing.Color.White
        ChartArea2.Name = "ChartArea1"
        Me.chrInformesVentas.ChartAreas.Add(ChartArea2)
        Legend2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Legend1"
        Me.chrInformesVentas.Legends.Add(Legend2)
        Me.chrInformesVentas.Location = New System.Drawing.Point(306, 96)
        Me.chrInformesVentas.MinimumSize = New System.Drawing.Size(826, 550)
        Me.chrInformesVentas.Name = "chrInformesVentas"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series2.IsValueShownAsLabel = True
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Series2.YValuesPerPoint = 3
        Me.chrInformesVentas.Series.Add(Series2)
        Me.chrInformesVentas.Size = New System.Drawing.Size(826, 610)
        Me.chrInformesVentas.TabIndex = 12
        Title2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Title2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.Name = "titulo"
        Title2.Text = "VENTAS REALIZADAS EN LA FECHA"
        Me.chrInformesVentas.Titles.Add(Title2)
        '
        'frmInformes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1144, 800)
        Me.ControlBox = False
        Me.Controls.Add(Me.chrInformesVentas)
        Me.Controls.Add(Me.lblHasta)
        Me.Controls.Add(Me.lblDesde)
        Me.Controls.Add(Me.lblInformes)
        Me.Controls.Add(Me.lblInfoSobre)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.cboTipoBusqueda)
        Me.Controls.Add(Me.chrInformesClientes)
        Me.Controls.Add(Me.btnSalir)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1160, 839)
        Me.Name = "frmInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORMES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.chrInformesClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chrInformesVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents chrInformesClientes As DataVisualization.Charting.Chart
    Friend WithEvents cboTipoBusqueda As ComboBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents btnGenerar As Button
    Friend WithEvents lblInfoSobre As Label
    Friend WithEvents lblInformes As Label
    Friend WithEvents lblDesde As Label
    Friend WithEvents lblHasta As Label
    Friend WithEvents chrInformesVentas As DataVisualization.Charting.Chart
End Class
