<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaPrincipal))
        Me.menuVistaPrincipal = New System.Windows.Forms.MenuStrip()
        Me.COMPROBANTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FACTURASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NOTADEBITOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NOTACREDITOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLIENTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSULTAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCTOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSULTAToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PROVEEDORESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSULTAToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RUBROSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LOCALIDADESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSULTAToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PREFERENCIASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONFIGURACIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INFORMESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.USUARIOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTANASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXITToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbxImagenDietetica = New System.Windows.Forms.PictureBox()
        Me.menuVistaPrincipal.SuspendLayout()
        CType(Me.pbxImagenDietetica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuVistaPrincipal
        '
        Me.menuVistaPrincipal.Font = New System.Drawing.Font("Calibri", 16.0!)
        Me.menuVistaPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.COMPROBANTESToolStripMenuItem, Me.CLIENTESToolStripMenuItem, Me.PRODUCTOSToolStripMenuItem, Me.PROVEEDORESToolStripMenuItem, Me.RUBROSToolStripMenuItem, Me.LOCALIDADESToolStripMenuItem, Me.PREFERENCIASToolStripMenuItem, Me.VENTANASToolStripMenuItem, Me.EXITToolStripMenuItem})
        Me.menuVistaPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.menuVistaPrincipal.MdiWindowListItem = Me.VENTANASToolStripMenuItem
        Me.menuVistaPrincipal.Name = "menuVistaPrincipal"
        Me.menuVistaPrincipal.Padding = New System.Windows.Forms.Padding(0)
        Me.menuVistaPrincipal.Size = New System.Drawing.Size(1321, 31)
        Me.menuVistaPrincipal.TabIndex = 1
        '
        'COMPROBANTESToolStripMenuItem
        '
        Me.COMPROBANTESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FACTURASToolStripMenuItem, Me.NOTADEBITOToolStripMenuItem, Me.NOTACREDITOToolStripMenuItem})
        Me.COMPROBANTESToolStripMenuItem.Image = CType(resources.GetObject("COMPROBANTESToolStripMenuItem.Image"), System.Drawing.Image)
        Me.COMPROBANTESToolStripMenuItem.Name = "COMPROBANTESToolStripMenuItem"
        Me.COMPROBANTESToolStripMenuItem.Size = New System.Drawing.Size(195, 31)
        Me.COMPROBANTESToolStripMenuItem.Text = "COMPROBANTES"
        '
        'FACTURASToolStripMenuItem
        '
        Me.FACTURASToolStripMenuItem.Name = "FACTURASToolStripMenuItem"
        Me.FACTURASToolStripMenuItem.Size = New System.Drawing.Size(219, 32)
        Me.FACTURASToolStripMenuItem.Text = "FACTURAS"
        '
        'NOTADEBITOToolStripMenuItem
        '
        Me.NOTADEBITOToolStripMenuItem.Enabled = False
        Me.NOTADEBITOToolStripMenuItem.Name = "NOTADEBITOToolStripMenuItem"
        Me.NOTADEBITOToolStripMenuItem.Size = New System.Drawing.Size(219, 32)
        Me.NOTADEBITOToolStripMenuItem.Text = "NOTA DEBITO"
        '
        'NOTACREDITOToolStripMenuItem
        '
        Me.NOTACREDITOToolStripMenuItem.Enabled = False
        Me.NOTACREDITOToolStripMenuItem.Name = "NOTACREDITOToolStripMenuItem"
        Me.NOTACREDITOToolStripMenuItem.Size = New System.Drawing.Size(219, 32)
        Me.NOTACREDITOToolStripMenuItem.Text = "NOTA CREDITO"
        '
        'CLIENTESToolStripMenuItem
        '
        Me.CLIENTESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONSULTAToolStripMenuItem})
        Me.CLIENTESToolStripMenuItem.Image = CType(resources.GetObject("CLIENTESToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CLIENTESToolStripMenuItem.Name = "CLIENTESToolStripMenuItem"
        Me.CLIENTESToolStripMenuItem.Size = New System.Drawing.Size(124, 31)
        Me.CLIENTESToolStripMenuItem.Text = "CLIENTES"
        '
        'CONSULTAToolStripMenuItem
        '
        Me.CONSULTAToolStripMenuItem.Name = "CONSULTAToolStripMenuItem"
        Me.CONSULTAToolStripMenuItem.Size = New System.Drawing.Size(178, 32)
        Me.CONSULTAToolStripMenuItem.Text = "CONSULTA"
        '
        'PRODUCTOSToolStripMenuItem
        '
        Me.PRODUCTOSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONSULTAToolStripMenuItem1})
        Me.PRODUCTOSToolStripMenuItem.Image = CType(resources.GetObject("PRODUCTOSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PRODUCTOSToolStripMenuItem.Name = "PRODUCTOSToolStripMenuItem"
        Me.PRODUCTOSToolStripMenuItem.Size = New System.Drawing.Size(153, 31)
        Me.PRODUCTOSToolStripMenuItem.Text = "PRODUCTOS"
        '
        'CONSULTAToolStripMenuItem1
        '
        Me.CONSULTAToolStripMenuItem1.Name = "CONSULTAToolStripMenuItem1"
        Me.CONSULTAToolStripMenuItem1.Size = New System.Drawing.Size(178, 32)
        Me.CONSULTAToolStripMenuItem1.Text = "CONSULTA"
        '
        'PROVEEDORESToolStripMenuItem
        '
        Me.PROVEEDORESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONSULTAToolStripMenuItem3})
        Me.PROVEEDORESToolStripMenuItem.Image = CType(resources.GetObject("PROVEEDORESToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PROVEEDORESToolStripMenuItem.Name = "PROVEEDORESToolStripMenuItem"
        Me.PROVEEDORESToolStripMenuItem.Size = New System.Drawing.Size(174, 31)
        Me.PROVEEDORESToolStripMenuItem.Text = "PROVEEDORES"
        '
        'CONSULTAToolStripMenuItem3
        '
        Me.CONSULTAToolStripMenuItem3.Name = "CONSULTAToolStripMenuItem3"
        Me.CONSULTAToolStripMenuItem3.Size = New System.Drawing.Size(178, 32)
        Me.CONSULTAToolStripMenuItem3.Text = "CONSULTA"
        '
        'RUBROSToolStripMenuItem
        '
        Me.RUBROSToolStripMenuItem.Enabled = False
        Me.RUBROSToolStripMenuItem.Image = CType(resources.GetObject("RUBROSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RUBROSToolStripMenuItem.Name = "RUBROSToolStripMenuItem"
        Me.RUBROSToolStripMenuItem.Size = New System.Drawing.Size(115, 31)
        Me.RUBROSToolStripMenuItem.Text = "RUBROS"
        '
        'LOCALIDADESToolStripMenuItem
        '
        Me.LOCALIDADESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONSULTAToolStripMenuItem2})
        Me.LOCALIDADESToolStripMenuItem.Image = CType(resources.GetObject("LOCALIDADESToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LOCALIDADESToolStripMenuItem.Name = "LOCALIDADESToolStripMenuItem"
        Me.LOCALIDADESToolStripMenuItem.Size = New System.Drawing.Size(166, 31)
        Me.LOCALIDADESToolStripMenuItem.Text = "LOCALIDADES"
        '
        'CONSULTAToolStripMenuItem2
        '
        Me.CONSULTAToolStripMenuItem2.Name = "CONSULTAToolStripMenuItem2"
        Me.CONSULTAToolStripMenuItem2.Size = New System.Drawing.Size(178, 32)
        Me.CONSULTAToolStripMenuItem2.Text = "CONSULTA"
        '
        'PREFERENCIASToolStripMenuItem
        '
        Me.PREFERENCIASToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONFIGURACIONToolStripMenuItem, Me.INFORMESToolStripMenuItem, Me.USUARIOToolStripMenuItem})
        Me.PREFERENCIASToolStripMenuItem.Image = CType(resources.GetObject("PREFERENCIASToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PREFERENCIASToolStripMenuItem.Name = "PREFERENCIASToolStripMenuItem"
        Me.PREFERENCIASToolStripMenuItem.Size = New System.Drawing.Size(173, 31)
        Me.PREFERENCIASToolStripMenuItem.Text = "PREFERENCIAS"
        '
        'CONFIGURACIONToolStripMenuItem
        '
        Me.CONFIGURACIONToolStripMenuItem.Enabled = False
        Me.CONFIGURACIONToolStripMenuItem.Name = "CONFIGURACIONToolStripMenuItem"
        Me.CONFIGURACIONToolStripMenuItem.Size = New System.Drawing.Size(241, 32)
        Me.CONFIGURACIONToolStripMenuItem.Text = "CONFIGURACION"
        '
        'INFORMESToolStripMenuItem
        '
        Me.INFORMESToolStripMenuItem.Name = "INFORMESToolStripMenuItem"
        Me.INFORMESToolStripMenuItem.Size = New System.Drawing.Size(241, 32)
        Me.INFORMESToolStripMenuItem.Text = "INFORMES"
        '
        'USUARIOToolStripMenuItem
        '
        Me.USUARIOToolStripMenuItem.Name = "USUARIOToolStripMenuItem"
        Me.USUARIOToolStripMenuItem.Size = New System.Drawing.Size(241, 32)
        Me.USUARIOToolStripMenuItem.Text = "USUARIO AFIP"
        '
        'VENTANASToolStripMenuItem
        '
        Me.VENTANASToolStripMenuItem.Image = CType(resources.GetObject("VENTANASToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VENTANASToolStripMenuItem.Name = "VENTANASToolStripMenuItem"
        Me.VENTANASToolStripMenuItem.Size = New System.Drawing.Size(136, 31)
        Me.VENTANASToolStripMenuItem.Text = "VENTANAS"
        '
        'EXITToolStripMenuItem
        '
        Me.EXITToolStripMenuItem.Image = CType(resources.GetObject("EXITToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EXITToolStripMenuItem.Name = "EXITToolStripMenuItem"
        Me.EXITToolStripMenuItem.Size = New System.Drawing.Size(79, 31)
        Me.EXITToolStripMenuItem.Text = "EXIT"
        '
        'pbxImagenDietetica
        '
        Me.pbxImagenDietetica.BackColor = System.Drawing.Color.LemonChiffon
        Me.pbxImagenDietetica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbxImagenDietetica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxImagenDietetica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxImagenDietetica.Image = CType(resources.GetObject("pbxImagenDietetica.Image"), System.Drawing.Image)
        Me.pbxImagenDietetica.Location = New System.Drawing.Point(0, 31)
        Me.pbxImagenDietetica.Margin = New System.Windows.Forms.Padding(0)
        Me.pbxImagenDietetica.Name = "pbxImagenDietetica"
        Me.pbxImagenDietetica.Size = New System.Drawing.Size(1321, 809)
        Me.pbxImagenDietetica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxImagenDietetica.TabIndex = 3
        Me.pbxImagenDietetica.TabStop = False
        '
        'frmVistaPrincipal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1321, 840)
        Me.Controls.Add(Me.pbxImagenDietetica)
        Me.Controls.Add(Me.menuVistaPrincipal)
        Me.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menuVistaPrincipal
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1337, 879)
        Me.Name = "frmVistaPrincipal"
        Me.Text = "SISTEMA DE COMPROBANTES EN LINEA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.menuVistaPrincipal.ResumeLayout(False)
        Me.menuVistaPrincipal.PerformLayout()
        CType(Me.pbxImagenDietetica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents menuVistaPrincipal As MenuStrip
    Friend WithEvents COMPROBANTESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FACTURASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NOTADEBITOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NOTACREDITOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CLIENTESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PRODUCTOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PROVEEDORESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RUBROSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONSULTAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONSULTAToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VENTANASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXITToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PREFERENCIASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents USUARIOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOCALIDADESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONSULTAToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents pbxImagenDietetica As PictureBox
    Friend WithEvents CONFIGURACIONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONSULTAToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents INFORMESToolStripMenuItem As ToolStripMenuItem
End Class
