Imports entLocalidad
Imports entProvincia
Public Class frmDialogoLocalidades
#Region "Campos"
    Public Enum TipoFormu
        Seleccion
        Consulta
    End Enum

    Private _TipoFormulario As TipoFormu
    Private _IdLocal As Integer = -1
    Private _NombreLoc As String

    Private _Prov As New eProvincia
    Private _Localidades As New eLocalidad
#End Region

#Region "Propiedades"
    Public Property TipoFormulario As TipoFormu
        Get
            Return _TipoFormulario
        End Get
        Set(value As TipoFormu)
            _TipoFormulario = value
        End Set
    End Property

    Public Property IdLocal As Integer
        Get
            Return _IdLocal
        End Get
        Set(value As Integer)
            _IdLocal = value
        End Set
    End Property

    Public Property NombreLoc As String
        Get
            Return _NombreLoc
        End Get
        Set(value As String)
            _NombreLoc = value
        End Set
    End Property

    Public Property Prov As eProvincia
        Get
            Return _Prov
        End Get
        Set(value As eProvincia)
            _Prov = value
        End Set
    End Property

    Public Property Localidades As eLocalidad
        Get
            Return _Localidades
        End Get
        Set(value As eLocalidad)
            _Localidades = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmDialogoLocalidades_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Cambio el tamaño de la fuente del encabezado de las columnas
            dgvLocalidades.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 15, FontStyle.Bold)

            'Le asigno el contenido al CBO y lo pongo por defecto en Mendoza
            With cboProvincias
                .DataSource = Prov.ObtenerProvincias
                .ValueMember = "IdProvincia"
                .DisplayMember = "NombreProvincia"
                .SelectedValue = 12
            End With

            'Si es para consulta, no muestro el boton Aceptar
            If TipoFormulario = TipoFormu.Consulta Then
                With btnAceptar
                    .Enabled = False
                    .Visible = False
                End With
            End If

            'Actualizo el DGV
            ActualizarDGV()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Cierro el formulario
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            'Confirmo la accion
            If IdLocal > -1 Then
                NombreLoc = Localidades.ObtenerLocalidad(IdLocal).NombreLocalidad
                DialogResult = DialogResult.OK
            Else
                Throw New Exception("Debe seleccionar un registro")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Text)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'Creo un objeto nuevo
        Dim nuevaLoc As New frmGestionLocalidades

        'Le asigno las propiedades y lo muestro como objeto de dialogo
        With nuevaLoc
            .Text = "ALTA DE LOCALIDAD"
            .TipoFormulario = frmGestionLocalidades.TipoFormu.Nueva
            .ShowDialog()
            If .DialogResult = DialogResult.OK Then
                'Actualizo el DGV
                ActualizarDGV()
            End If
        End With
    End Sub

    'Evento al cambiar el valor del CBO
    Private Sub cboProvincias_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboProvincias.SelectedValueChanged
        'Guardo la provincia seleccionada
        Prov = cboProvincias.SelectedItem
        'Reestablezco el Id de la localidad
        IdLocal = -1
        'Actualizo el DGV
        ActualizarDGV()
    End Sub

    'Evento al hacer click sobre una celda del DGV
    Private Sub dgvLocalidades_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLocalidades.CellMouseClick
        'Verifico que al menos haya 1 fila cargada
        If e.RowIndex > -1 Then
            'Obtiene la Id de la localidad en la fila a la que se le hizo click
            IdLocal = dgvLocalidades.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    'Evento al hacer doble click sobre una celda del DGV
    Private Sub dgvLocalidades_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLocalidades.CellMouseDoubleClick
        'Si el DGV tiene mas de una celda entra al comparador
        If e.RowIndex > -1 Then
            'Obtiene la Id de la localidad en la fila a la que se le hizo click
            IdLocal = dgvLocalidades.Rows(e.RowIndex).Cells(0).Value

            'Creo un objeto nuevo
            Dim nuevaLoc As New frmGestionLocalidades
            'Guardo en una lista las localidades que contiene el DGV
            Dim lista As List(Of eLocalidad) = dgvLocalidades.DataSource

            'Le asigno las propiedades y lo muestro como dialogo
            With nuevaLoc
                .Text = "MODIFICACION DE LOCALIDAD"
                .TipoFormulario = frmGestionLocalidades.TipoFormu.Modificar
                .Localidad = lista.Find(Function(arg) arg.IdLocalidad = IdLocal)
                .ShowDialog()
                If .DialogResult = DialogResult.OK Then
                    'Actualizo el DGV
                    ActualizarDGV()
                End If
            End With
        End If
    End Sub

    'Evento al terminar de enlazar los datos con el DGV
    Private Sub dgvLocalidades_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvLocalidades.DataBindingComplete
        'Se borra la seleccion actual
        dgvLocalidades.ClearSelection()
    End Sub

    'Evento al presionar una tecla en el CBO
    Private Sub cboProvincias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProvincias.KeyPress
        'Pregunto si es numerico el valor de la tecla presionada , de ser asi muestro no muestro el valor
        'El handled me indica que tomara lo que tecleamos y si es false lo dejara pasar, pero si es True lo toma y no me lo muestra
        If IsNumeric(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Metodo que sirve para consultar la base de datos y llenar el DGV con los registros encontrados
    ''' </summary>
    Public Sub ActualizarDGV()
        'Creo una lista vacia para asignarsela al DGV y asi actualizarlo
        Dim lista As New List(Of eLocalidad)

        dgvLocalidades.DataSource = lista
        'Busco una lista de las localidades segun la provincia seleccionada y antes de agregarsela al DGV la ordeno por Nombre
        dgvLocalidades.DataSource = Localidades.ObtenerLocalidades(Prov.IdProvincia).OrderBy(Function(x) x.NombreLocalidad).ToList

        'Limpio la primer fila seleccionada
        dgvLocalidades.ClearSelection()
    End Sub
#End Region
End Class
