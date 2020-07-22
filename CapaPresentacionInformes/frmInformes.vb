Imports entInformes
Public Class frmInformes
#Region "Campos"
    Public Enum TipoInfo
        CLIENTES = 1
        VENTAS = 2
    End Enum

    Private _TipoInforme As TipoInfo

    'Objeto para obtener el informe apropiado
    Dim obtener As New eInforme
#End Region

#Region "Propiedades"
    Public Property TipoInforme As TipoInfo
        Get
            Return _TipoInforme
        End Get
        Set(value As TipoInfo)
            _TipoInforme = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmInformes_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Le asigno el enum al CBO
        With cboTipoBusqueda
            .DataSource = [Enum].GetValues(GetType(TipoInfo))
        End With

        'Cambio su texto
        cboTipoBusqueda.Text = "Seleccionar"

        'Oculto los controles apropiados
        mostrarControles(False)
        mostrarChrCliente(False)
        mostrarChrVentas(False)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Cierro el formulario
        Close()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            'Objeto para mostrar el informe
            Dim dialogo As New frmDialogoInforme

            'Segun el tipo de informe seleccionado lo muestro como dialogo y le asigno sus propiedades
            If cboTipoBusqueda.Text = "CLIENTES" Then

                With dialogo
                    .TipoInforme = frmDialogoInforme.tipoInfo.CLIENTES
                    .ShowDialog()
                End With

            ElseIf cboTipoBusqueda.Text = "VENTAS" Then
                'Compruebo que la fecha HASTA no sea menor que la fecha DESDE
                If dtpFechaHasta.Value.Date >= dtpFechaDesde.Value.Date Then

                    With dialogo
                        .TipoInforme = frmDialogoInforme.tipoInfo.VENTAS
                        .FechaD = dtpFechaDesde.Value.Date
                        .FechaH = dtpFechaHasta.Value.Date
                        .ShowDialog()
                    End With

                Else
                    Throw New Exception("La fecha HASTA no puede ser menor a la fecha DESDE")
                End If

            Else
                Throw New Exception("Debe seleccionar el tipo de informe que desea conocer")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Text)
        End Try
    End Sub

    'Evento al presionar una tecla sobre el cbo
    Private Sub cboTipoBusqueda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoBusqueda.KeyPress
        'No dejo escribir en el cbo
        e.Handled = True
    End Sub

    'Evento al cambiar la seleccion del cbo
    Private Sub cboTipoBusqueda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoBusqueda.SelectedValueChanged
        'Llamo al evento apropiado
        If cboTipoBusqueda.Text = "CLIENTES" Then
            mostrarChrVentas(False)
            mostrarControles(False)
            mostrarChrCliente(True)
            estadisticaClientes()

        ElseIf cboTipoBusqueda.Text = "VENTAS" Then
            mostrarChrCliente(False)
            mostrarChrVentas(True)
            mostrarControles(True)
            estadisticaVentas()

        End If
    End Sub

    'Evento al realizar un cambio en la fecha de los DTP
    Private Sub DateTimePickers_ValueChanged() Handles dtpFechaDesde.ValueChanged, dtpFechaHasta.ValueChanged
        Try
            'Compruebo que la fecha HASTA no sea menor que la fecha DESDE
            If dtpFechaHasta.Value.Date >= dtpFechaDesde.Value.Date Then
                'Llamo al metodo apropiado
                estadisticaVentas()

            Else
                Throw New Exception("La fecha HASTA no puede ser menor a la fecha DESDE")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Text)
        End Try
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Muestra en un grafico de columnas una estadistica de clientes hasta la fecha
    ''' </summary>
    Public Sub estadisticaClientes()
        Try
            'Guardo en una tabla los clientes activos
            Dim tabla As New DataTable
            obtener.obtenerClientesIVA(tabla)

            'Le asigno las propiedades al grafico
            With chrInformesClientes
                .DataSource = tabla
                .Series(0).XValueMember = "Descripcion"
                .Series(0).YValueMembers = "IdCliente"
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    ''' <summary>
    ''' Muestra en un grafico de torta una estadistica de las ventas realizadas entre 2 fechas
    ''' </summary>
    Public Sub estadisticaVentas()
        Try
            'Guardo en una tabla las ventas realizadas
            Dim tabla As New DataTable
            obtener.obtenerEstadisticaVentas(tabla, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date
                                             )
            'Le asigno las propiedades al grafico
            With chrInformesVentas
                .DataSource = tabla
                .Series(0).XValueMember = "Producto"
                .Series(0).YValueMembers = "Cantidad"
                'Hago que vuelva a calcular los valores a mostrar en el grafico
                .ResetAutoValues()
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    ''' <summary>
    ''' Muestra u oculta los controles de fechas
    ''' </summary>
    ''' <param name="cond"></param>
    Public Sub mostrarControles(cond As Boolean)
        lblDesde.Visible = cond
        lblHasta.Visible = cond
        dtpFechaDesde.Visible = cond
        dtpFechaHasta.Visible = cond
    End Sub

    ''' <summary>
    ''' Muestra u oculta el grafico de estadisticas de clientes
    ''' </summary>
    ''' <param name="cond"></param>
    Public Sub mostrarChrCliente(cond As Boolean)
        chrInformesClientes.Visible = cond
        chrInformesClientes.Enabled = cond
    End Sub

    ''' <summary>
    ''' Muestra u oculta el grafico de estadisticas de ventas
    ''' </summary>
    ''' <param name="cond"></param>
    Public Sub mostrarChrVentas(cond As Boolean)
        chrInformesVentas.Visible = cond
        chrInformesVentas.Enabled = cond
    End Sub
#End Region
End Class
