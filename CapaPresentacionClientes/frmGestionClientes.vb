Imports CapaPresentacionLocalidades
Imports entCliente, entTipoDocumento, entCondicionIVA, entLocalidad
Public Class frmGestionClientes
#Region "Campos"
    Public Enum TipoFormu
        Nuevo
        Consulta
    End Enum

    Private _TipoFormulario As TipoFormu
    Private _Cliente As New eCliente
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

    Public Property Cliente As eCliente
        Get
            Return _Cliente
        End Get
        Set(value As eCliente)
            _Cliente = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmGestionClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Busco una lista de los tipos de documentos y se los asigno al CBO
        Dim tipo As New eTipoDocumento
        With cboTipoDoc
            .DataSource = tipo.ObtenerTiposDocumentos
            .ValueMember = "IdTipoDoc"
            .DisplayMember = "TipoDoc"
            .SelectedValue = 1
        End With

        'Busco una lista de condiciones IVA y se la asigno al CBO
        Dim condicion As New eCondicionIVA
        With cboCondIVA
            .DataSource = condicion.ObtenerCondicionesIVA
            .ValueMember = "IdCondicion"
            .DisplayMember = "Descripcion"
            .SelectedValue = 1
        End With

        'Si es un nuevo cliente
        If TipoFormulario = TipoFormu.Nuevo Then
            'Cambio el titulo segun el formulario
            lblGestionCliente.Text = "ALTA DE CLIENTE"

            'Deshabilitos los botones
            btnModificar.Visible = False
            btnBaja.Visible = False

            'Cambio el nombre del boton y su imagen
            btnCancelar.Text = "CANCELAR"
            btnCancelar.Image = My.Resources.stop_error

            'Si es consulta
        ElseIf TipoFormulario = TipoFormu.Consulta Then
            'Cambio el titulo segun el formulario
            lblGestionCliente.Text = "CONSULTA DE CLIENTE"

            'Obtengo los datos segun el ID pasado por parametro
            Cliente = Cliente.ObtenerCliente(Cliente.IdCliente)

            'Creo un objeto para la localidad
            Dim localidad As New eLocalidad

            'Se lo asigno a los controles
            With Cliente
                txtNombCliente.Text = .NombreCliente
                cboTipoDoc.SelectedValue = .TipoDocumento
                txtNumDoc.Text = .NumeroDocumento
                txtDomicilio.Text = .Domicilio
                cboCondIVA.SelectedValue = .CondicionIva
                txtLocalidad.Text = localidad.ObtenerLocalidad(Cliente.Localidad).NombreLocalidad
            End With

            'Dejo de solo lectura los controles que voy a mostrar
            habilitarControles(True, False)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Cierro el formulario
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            'Llamo al metodo para verificar que sea correcto el numero de documento segun el tipo de documento
            verificarDocumento()
            'Llamo al metodo para verificar que el tipo de documento y la condicion de IVA sean consistentes
            verificarCondicionIVA()

            'Creo un objeto para guardar la localidad
            Dim localidad As New eLocalidad

            'Si el formulario es de Alta Cliente
            If TipoFormulario = TipoFormu.Nuevo Then
                'Guardo los datos de los controles en el objeto
                With Cliente
                    .NombreCliente = txtNombCliente.Text
                    .TipoDocumento = cboTipoDoc.SelectedValue
                    .NumeroDocumento = txtNumDoc.Text
                    .Domicilio = txtDomicilio.Text
                    .CondicionIva = cboCondIVA.SelectedValue
                    'Con el nombre de la localidad, uso su metodo y obtengo el ID de la misma
                    .Localidad = localidad.ObtenerLocalidadNombre(txtLocalidad.Text).IdLocalidad
                    .Activo = 1
                End With

                'Llamo a la funcion que inserta un cliente
                Dim registro As Short = Cliente.InsertarCliente()

                If registro = 1 Then
                    MsgBox("Alta realizada con exito", MsgBoxStyle.Information, Text)
                Else
                    Throw New Exception("El registro no pudo ser dado de alta")
                End If

                'Si el formulario fue de consulta-modificacion
            ElseIf TipoFormulario = TipoFormu.Consulta Then
                'Creo un nuevo objeto para guardar los datos modificados
                Dim clientemod As New eCliente

                With clientemod
                    .IdCliente = Cliente.IdCliente
                    .NombreCliente = txtNombCliente.Text
                    .TipoDocumento = cboTipoDoc.SelectedValue
                    .NumeroDocumento = txtNumDoc.Text
                    .Domicilio = txtDomicilio.Text
                    .CondicionIva = cboCondIVA.SelectedValue
                    .Localidad = localidad.ObtenerLocalidadNombre(txtLocalidad.Text).IdLocalidad
                    .Activo = 1
                End With

                'Llamo a la funcion para actualizar desde el cliente original y le paso el objeto con los datos del cliente modificado
                Dim registro As Short = Cliente.ActualizarCliente(clientemod)

                If registro = 1 Then
                    MsgBox("El registro fue actualizado correctamente", MsgBoxStyle.Information, Text)
                Else
                    Throw New Exception("El registro no pudo ser actualizado")
                End If
            End If

            'Confirmo lo realizado en el formulario
            DialogResult = DialogResult.OK

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        'Habilito los controles apropiados
        habilitarControles(False, True)

        'Deshabilito el boton de baja y modificacion
        btnModificar.Enabled = False
        btnBaja.Enabled = False

        'Cambio el nombre del boton y su imagen
        btnCancelar.Text = "CANCELAR"
        btnCancelar.Image = My.Resources.stop_error

        Text = "MODIFICACION DE CLIENTE"
        lblGestionCliente.Text = "MODIFICAR CLIENTE"
    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        Try
            'Creo un nuevo objeto y le asigno el resultado del MessageBox creado
            Dim resultado As DialogResult = MessageBox.Show("¿Seguro desea dar de baja el registro actual?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            'Si se confirma la accion, se da de baja el registro
            If resultado = DialogResult.Yes Then
                'Creo un nuevo objeto para guardar los datos y cambiar su estado
                Dim clientemod As eCliente = Cliente.ObtenerCliente(Cliente.IdCliente)
                clientemod.Activo = 0

                'Llamo a la funcion que me permite actualizar registros y guardo el resultado si fue actualizado con exito
                Dim registro As Short = Cliente.ActualizarCliente(clientemod)

                If registro = 1 Then
                    'Muestro un mensaje
                    MsgBox("BAJA REALIZADA CON EXITO", MsgBoxStyle.Information, Text)
                    'Confirmo el formulario
                    DialogResult = DialogResult.OK
                Else
                    Throw New Exception("No se pudo realizar la baja")
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnBuscarLocalidad_Click(sender As Object, e As EventArgs) Handles btnBuscarLocalidad.Click
        'Creo un nuevo objeto
        Dim local As New frmDialogoLocalidades

        'Lo muestro como dialogo
        With local
            .ShowDialog()
            If .DialogResult = DialogResult.OK Then
                'Si la seleccion fue correcta, guardo y muestro su nombre
                txtLocalidad.Text = .NombreLoc
            End If
        End With
    End Sub

    'Cuando se pulsa una tecla en el TXT NumDoc
    Private Sub txtNumDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumDoc.KeyPress
        'Este evento se ejecuta cada vez que se presiona una tecla en el control.
        'Pregunto si es numerico el valor de la tecla presionada o si corresponde al Codigo ASCII 8 "retroceso", de ser asi muestro el valor en el control.
        'Caso contrario no dejo que el valor tecleado se muestre
        If IsNumeric(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'El handled me indica que tomara lo que tecleamos y si es false lo dejara pasar, pero si es True lo toma y no me lo muestra
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Cuando se pulsa una tecla en el TXT NombCliente
    Private Sub txtNombCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombCliente.KeyPress
        'Pregunto si es numerico el valor de la tecla presionada , de ser asi muestro no muestro el valor
        'El handled me indica que tomara lo que tecleamos y si es false lo dejara pasar, pero si es True lo toma y no me lo muestra
        If IsNumeric(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    'Cuando se busque por medio del CBO CondIVA
    Private Sub cboCondIVA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCondIVA.KeyPress
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
    ''' Metodo que permite habilitar o deshabilitar los controles del formulario
    ''' </summary>
    ''' <param name="accion1">Booleano que determina si los controles apropiados seran de solo lectura</param>
    ''' <param name="accion2">Booleano que determina si los controles apropiados estaran habilitados o no</param>
    Public Sub habilitarControles(accion1 As Boolean, accion2 As Boolean)
        btnAceptar.Enabled = accion2
        btnBuscarLocalidad.Enabled = accion2
        cboTipoDoc.Enabled = accion2
        cboCondIVA.Enabled = accion2

        txtNombCliente.ReadOnly = accion1
        txtNumDoc.ReadOnly = accion1
        txtDomicilio.ReadOnly = accion1
    End Sub

    ''' <summary>
    ''' Metodo que verifica que coincida el tipo de documento con la longitud del numero de documento
    ''' </summary>
    Private Sub verificarDocumento()
        'Si el tipo de documento es CUIT - CUIL, la longitud de caracteres debera ser 11
        If cboTipoDoc.SelectedValue = 1 Then
            If txtNumDoc.TextLength = 11 Then
                'Lo dejo pasar
            Else
                Throw New Exception("Largo de Numero Documento incorrecto")
            End If
        End If

        'Si el tipo de documento es DNI, la longitud de caracteres debera ser 7 u 8
        If cboTipoDoc.SelectedValue = 2 Or cboTipoDoc.SelectedValue = 3 Or cboTipoDoc.SelectedValue = 4 Or cboTipoDoc.SelectedValue = 5 Or cboTipoDoc.SelectedValue = 6 Then
            If txtNumDoc.TextLength > 6 And txtNumDoc.TextLength < 9 Then
                'Lo dejo pasar
            Else
                Throw New Exception("Largo de Numero Documento incorrecto")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Metodo que verifica que coincida el tipo de documento con la condicion de IVA del cliente
    ''' </summary>
    Private Sub verificarCondicionIVA()
        'No se verifica el CUIT porque es aceptado por todas las condiciones IVA

        'Si el tipo de documento es CDI, LE, LC, DNI, CI Policia o Certificado de Migracion
        If cboTipoDoc.SelectedValue = 2 Or cboTipoDoc.SelectedValue = 3 Or cboTipoDoc.SelectedValue = 4 Or cboTipoDoc.SelectedValue = 6 Or cboTipoDoc.SelectedValue = 8 Or cboTipoDoc.SelectedValue = 9 Then
            If cboCondIVA.SelectedValue = 3 Then
                'Dejo pasar
            Else
                Throw New Exception("El Tipo de Documento no es admitido por la Condicion Frente a IVA seleccionada")
            End If
        End If

        'Si el tipo de documento es CI Extranjera o Pasaporte
        If cboTipoDoc.SelectedValue = 5 Or cboTipoDoc.SelectedValue = 7 Then
            If cboCondIVA.SelectedValue = 3 Or cboCondIVA.SelectedValue = 5 Or cboCondIVA.SelectedValue = 6 Then
                'Dejo pasar
            Else
                Throw New Exception("El Tipo de Documento no es admitido por la Condicion Frente a IVA seleccionada")
            End If
        End If
    End Sub
#End Region
End Class