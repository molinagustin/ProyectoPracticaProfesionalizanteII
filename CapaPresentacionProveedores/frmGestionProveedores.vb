Imports entProveedor
Public Class frmGestionProveedores
#Region "Campos"
    Public Enum TipoFormu
        Nuevo
        Consulta
    End Enum

    Private _TipoFormulario As TipoFormu
    Private _Prove As New eProveedor
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

    Public Property Prove As eProveedor
        Get
            Return _Prove
        End Get
        Set(value As eProveedor)
            _Prove = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmGestionProveedores_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Verifico el tipo de formulario
            If TipoFormulario = TipoFormu.Nuevo Then
                'Cambio el titulo segun el formulario
                lblGestionProv.Text = "ALTA DE PROVEEDOR"

                'Deshabilitos los botones
                btnModificar.Visible = False
                btnBaja.Visible = False

                'Cambio el nombre del boton y su imagen
                btnCancelar.Text = "CANCELAR"
                btnCancelar.Image = My.Resources.stop_error

                'Si es consulta
            ElseIf TipoFormulario = TipoFormu.Consulta Then
                'Cambio el titulo segun el formulario
                lblGestionProv.Text = "CONSULTA DE PROVEEDOR"

                'Verifico que se haya pasado un proveedor por propiedad
                If Prove IsNot Nothing Then
                    'Asigno los valores a los controles
                    With Prove
                        txtNombProv.Text = .NombreProveedor
                        txtDom.Text = .DomicilioProveedor
                        txtTel.Text = .Telefono
                        txtCorreo.Text = .CorreoElectronico
                    End With
                Else
                    Throw New Exception("Los datos de proveedor no se pudieron cargar")
                End If

                'Dejo de solo lectura los controles que voy a mostrar
                habilitarControles(True, False)
            End If

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
            'Compruebo el tipo de formulario
            If TipoFormulario = TipoFormu.Nuevo Then

                'Guardo los datos cargados
                With Prove
                    .NombreProveedor = txtNombProv.Text
                    .DomicilioProveedor = txtDom.Text
                    .Telefono = txtTel.Text
                    .CorreoElectronico = txtCorreo.Text
                    .Activo = 1
                End With

                'Llamo a la funcion para insertar un proveedor
                Dim registro As Short = Prove.InsertarProveedor()

                'Verifico que se haya realizado correctamente
                If registro = 1 Then
                    MsgBox("Alta realizada con exito", MsgBoxStyle.Information, Text)
                Else
                    Throw New Exception("El registro no pudo ser dado de alta")
                End If

                'Si fue de consulta-modificacion
            ElseIf TipoFormulario = TipoFormu.Consulta Then
                'Creo un nuevo objeto para los datos modificados
                Dim nuevoProv As New eProveedor

                'Guardo los datos
                With nuevoProv
                    .IdProveedor = Prove.IdProveedor
                    .NombreProveedor = txtNombProv.Text
                    .DomicilioProveedor = txtDom.Text
                    .Telefono = txtTel.Text
                    .CorreoElectronico = txtCorreo.Text
                    .Activo = 1
                End With

                'Llamo a la funcion para actualizar desde el objeto original
                Dim registro As Short = Prove.ActualizarProveedor(nuevoProv)

                'Verifico que se haya realizado correctamente
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
        Try
            'Habilito los controles apropiados
            habilitarControles(False, True)

            'Deshabilito el boton de baja y modificacion
            btnModificar.Enabled = False
            btnBaja.Enabled = False

            'Cambio el nombre del boton y su imagen
            btnCancelar.Text = "CANCELAR"
            btnCancelar.Image = My.Resources.stop_error

            Text = "MODIFICACION DE PROVEEDOR"
            lblGestionProv.Text = "MODIFICAR PROVEEDOR"

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        Try
            'Creo un nuevo objeto y le asigno el resultado del MessageBox creado
            Dim resultado As DialogResult = MessageBox.Show("¿Seguro desea dar de baja el registro actual?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            'Si se confirma la accion, se da de baja el registro
            If resultado = DialogResult.Yes Then
                'Creo un nuevo objeto para guardar los datos y cambiar su estado
                Dim proveBaja As eProveedor = Prove.ObtenerProveedor(Prove.IdProveedor)
                'Cambio su estado activo
                proveBaja.Activo = 0

                'Llamo a la funcion que me permite actualizar registros y guardo el resultado si fue actualizado con exito
                Dim registro As Short = Prove.ActualizarProveedor(proveBaja)

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

    'Cuando se pulsa una tecla sobre el txt telefono
    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        'Solo dejo pasar caracteres numericos
        CaracterNumerico(e)
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

        txtNombProv.ReadOnly = accion1
        txtDom.ReadOnly = accion1
        txtTel.ReadOnly = accion1
        txtCorreo.ReadOnly = accion1
    End Sub

    ''' <summary>
    ''' Este metodo se ejecuta cada vez que se presiona una tecla en el control
    ''' </summary>
    ''' <param name="e"></param>
    Public Sub CaracterNumerico(e As KeyPressEventArgs)
        'Pregunto si es numerico el valor de la tecla presionada o si corresponde al Codigo ASCII 8 "retroceso", de ser asi muestro el valor en el control.
        'Caso contrario no dejo que el valor tecleado se muestre
        If IsNumeric(e.KeyChar) Or e.KeyChar = Chr(8) Then
            'El handled me indica que tomara lo que tecleamos y si es false lo dejara pasar, pero si es True lo toma y no me lo muestra
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region
End Class