Imports entCliente
Imports entCondicionIVA
Public Class frmDialogoClilentes
#Region "Campos"
    Private _IdCli As Integer = -1
    Dim lista As New List(Of eCliente)
#End Region

#Region "Propiedades"
    Public Property IdCli As Integer
        Get
            Return _IdCli
        End Get
        Set(value As Integer)
            _IdCli = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmDialogoClilentes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Cambio el tamaño de la fuente del encabezado de las columnas
            dgvListadoClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 15, FontStyle.Bold)

            'Muestro los registros actuales en el DGV
            ActualizarDGV()

            'Coloco el boton en la posicion deseada
            btnAgregar.Location = New Point(693, 364)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Cierro el formulario
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If IdCli > -1 Then
                'Confirmo la accion
                DialogResult = DialogResult.OK
            Else
                Throw New Exception("Debe seleccionar un registro")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Text)
        End Try
    End Sub

    'Evento click de agregar
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'Creo un objeto nuevo
        Dim nuevoCl As New frmGestionClientes

        'Le asigno las propiedades y lo muestro como objeto de dialogo
        With nuevoCl
            .Text = "ALTA DE CLIENTE"
            .TipoFormulario = frmGestionClientes.TipoFormu.Nuevo
            .ShowDialog()
            If .DialogResult = DialogResult.OK Then
                'Actualizo el DGV
                ActualizarDGV()
            End If
        End With
    End Sub

    'Evento que se lanza al hacer click en una celda
    Private Sub dgvListadoClientes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListadoClientes.CellMouseClick
        'Si el DGV tiene mas de una fila entra al comparador
        If e.RowIndex > -1 Then
            'Asigno el Id del Cliente seleccionado (el cual se encuentra en la primer columna)
            IdCli = dgvListadoClientes.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    'Evento que se lanza al hacer doble click en una celda
    Private Sub dgvListadoClientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListadoClientes.CellMouseDoubleClick
        'Si el DGV tiene mas de una celda entra al comparador
        If e.RowIndex > -1 Then
            'Guardo el numero correspondiente al ID
            IdCli = dgvListadoClientes.Rows(e.RowIndex).Cells(0).Value

            'Creo un objeto nuevo
            Dim nuevoCl As New frmGestionClientes

            'Le asigno las propiedades y lo muestro como dialogo
            With nuevoCl
                'Le asigno al objeto el ID de la seleccion
                .Cliente.IdCliente = IdCli
                .Text = "CONSULTA DE CLIENTE"
                .TipoFormulario = frmGestionClientes.TipoFormu.Consulta
                .ShowDialog()
                If .DialogResult = DialogResult.OK Then
                    'Actualizo el DGV
                    ActualizarDGV()
                    IdCli = -1
                End If
            End With
        End If
    End Sub

    'Evento que se lanza al terminar de enlazarse los datos
    Private Sub dgvListadoClientes_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvListadoClientes.DataBindingComplete
        'Limpio la seleccion actual
        dgvListadoClientes.ClearSelection()
    End Sub

    'Para realizar un formateo de las celdas
    Private Sub dgvListadoClientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListadoClientes.CellFormatting
        'Para la columna CondicionIVA
        If dgvListadoClientes.Columns(e.ColumnIndex).Name.Equals("CondicionIva") Then
            Dim condi As New eCondicionIVA
            Dim listatipo As New List(Of eCondicionIVA)
            listatipo = condi.ObtenerCondicionesIVA

            For Each list In listatipo
                If list.IdCondicion = CInt(e.Value) Then
                    e.Value = list.Descripcion
                    Exit For
                End If
            Next
        End If
    End Sub

    'Evento cuando se cambia el contenido del TXT
    Private Sub txtBuscador_TextChanged(sender As Object, e As EventArgs) Handles txtBuscador.TextChanged
        'Verifico que tenga contenido para buscar en el TXT
        If txtBuscador.Text.Trim() IsNot "" Then
            'Busco en el listado de eClientes, aquellos que contengas letras o palabras escritas en el txtBuscador
            dgvListadoClientes.DataSource = lista.FindAll(Function(x) x.NombreCliente.ToLower.Contains(txtBuscador.Text.ToLower))
        Else
            'Sino le asigo el listado sin filtrar nuevamente al DGV
            dgvListadoClientes.DataSource = lista.OrderBy(Function(x) x.NombreCliente).ToList
        End If
    End Sub

    'Evento al pulsar una tecla
    Private Sub txtBuscador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscador.KeyPress
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
        'Creo nuevo objeto para llenar de datos
        Dim cliente As New eCliente

        'Lleno la lista creada anteriormente
        lista = cliente.ObtenerClientes

        'Creo una funcion lambda donde asigno como parametro un objeto del tipo eCliente ("x") y que obtena el nombre del cliente
        'Se la asigno al DGV
        dgvListadoClientes.DataSource = lista.OrderBy(Function(x) x.NombreCliente).ToList

        'Limpio la primer fila seleccionada
        dgvListadoClientes.ClearSelection()
    End Sub
#End Region
End Class