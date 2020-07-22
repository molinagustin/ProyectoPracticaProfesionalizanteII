Imports CapaPresentacionProveedores
Imports entProveedor
Public Class frmDialogoProveedores
#Region "Campos"
    Public Enum TipoFormu
        Consulta
        Seleccion
    End Enum

    Private _TipoFormulario As TipoFormu
    Private _IdPro As Integer = -1
    'Lista para llenar el DGV
    Dim lista As New List(Of eProveedor)
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

    Public Property IdPro As Integer
        Get
            Return _IdPro
        End Get
        Set(value As Integer)
            _IdPro = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmDialogoProveedores_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Cambio el tamaño de la fuente del encabezado de las columnas
            dgvListadoProv.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 15, FontStyle.Bold)

            'Si es para consulta, no muestro el boton Aceptar
            If TipoFormulario = TipoFormu.Consulta Then
                With btnAceptar
                    .Enabled = False
                    .Visible = False
                End With

            ElseIf TipoFormulario = TipoFormu.Seleccion Then
                'Cambio el nombre del boton y su imagen
                btnSalir.Text = "CANCELAR"
                btnSalir.Image = My.Resources.stop_error
            End If

            'Muestro los registros actuales en el DGV
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
            If IdPro > -1 Then
                'Confirmo la accion
                DialogResult = DialogResult.OK
            Else
                Throw New Exception("Debe seleccionar un registro")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            'Creo un objeto nuevo
            Dim nuevoProv As New frmGestionProveedores

            'Le asigno las propiedades y lo muestro como objeto de dialogo
            With nuevoProv
                .Text = "ALTA DE PROVEEDOR"
                .TipoFormulario = frmGestionProveedores.TipoFormu.Nuevo
                .ShowDialog()
                If .DialogResult = DialogResult.OK Then
                    'Actualizo el DGV
                    ActualizarDGV()
                End If
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    'Evento que se lanza al hacer click en una celda
    Private Sub dgvListadoProv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListadoProv.CellMouseClick
        'Si el DGV tiene mas de una fila entra al comparador
        If e.RowIndex > -1 Then
            'Asigno el Id del Proveedor seleccionado (el cual se encuentra en la primer columna)
            IdPro = dgvListadoProv.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    'Evento que se lanza al hacer doble click en una celda
    Private Sub dgvListadoProv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListadoProv.CellMouseDoubleClick
        'Si el DGV tiene mas de una celda entra al comparador
        If e.RowIndex > -1 Then
            'Obtiene la Id del Proveedor en la fila a la que se le hizo click
            IdPro = dgvListadoProv.Rows(e.RowIndex).Cells(0).Value

            'Creo un objeto nuevo
            Dim nuevoProve As New frmGestionProveedores
            'Guardo en una lista los proveedores que contiene el DGV
            Dim lista As List(Of eProveedor) = dgvListadoProv.DataSource

            'Le asigno las propiedades y lo muestro como dialogo
            With nuevoProve
                .Text = "CONSULTA DE PROVEEDOR"
                .TipoFormulario = frmGestionProveedores.TipoFormu.Consulta
                .Prove = lista.Find(Function(arg) arg.IdProveedor = IdPro)
                .ShowDialog()
                If .DialogResult = DialogResult.OK Then
                    'Actualizo el DGV
                    ActualizarDGV()
                End If
            End With
        End If
    End Sub

    'Evento que se lanza al terminar de enlazarse los datos
    Private Sub dgvListadoProv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvListadoProv.DataBindingComplete
        'Limpio la seleccion actual
        dgvListadoProv.ClearSelection()
    End Sub

    'Evento cuando se cambia el contenido del TXT
    Private Sub txtBuscador_TextChanged(sender As Object, e As EventArgs) Handles txtBuscador.TextChanged
        'Verifico que tenga contenido para buscar en el TXT
        If txtBuscador.Text.Trim() IsNot "" Then
            'Busco en el listado de eProveedores, aquellos que contengas letras o palabras escritas en el txtBuscador
            dgvListadoProv.DataSource = lista.FindAll(Function(x) x.NombreProveedor.ToLower.Contains(txtBuscador.Text.ToLower))
        Else
            'Sino le asigo el listado sin filtrar nuevamente al DGV
            dgvListadoProv.DataSource = lista.OrderBy(Function(x) x.NombreProveedor).ToList
        End If
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Metodo que sirve para consultar la base de datos y llenar el DGV con los registros encontrados
    ''' </summary>
    Public Sub ActualizarDGV()
        'Creo nuevo objeto para llenar de datos
        Dim pro As New eProveedor

        'Lleno la lista creada anteriormente
        lista = pro.ObtenerProveedores()

        'Creo una funcion lambda donde asigno como parametro un objeto del tipo eProveedor ("x") y que obtena el nombre del proveedor para ordenarlo
        'Se la asigno al DGV
        dgvListadoProv.DataSource = lista.OrderBy(Function(x) x.NombreProveedor).ToList

        'Limpio la primer fila seleccionada
        dgvListadoProv.ClearSelection()
    End Sub
#End Region
End Class
