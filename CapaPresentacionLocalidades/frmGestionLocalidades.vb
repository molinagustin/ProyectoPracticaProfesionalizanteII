Imports entLocalidad
Imports entProvincia
Public Class frmGestionLocalidades
#Region "Campos"
    Public Enum TipoFormu
        Nueva
        Modificar
    End Enum

    Private _TipoFormulario As TipoFormu
    Private _Localidad As New eLocalidad
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

    Public Property Localidad As eLocalidad
        Get
            Return _Localidad
        End Get
        Set(value As eLocalidad)
            _Localidad = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmGestionLocalidades_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Creo un objeto para asignarle las provincias al CBO
            Dim Prov As New eProvincia

            With cboProvincia
                .DataSource = Prov.ObtenerProvincias
                .ValueMember = "IdProvincia"
                .DisplayMember = "NombreProvincia"
                .SelectedValue = 12
            End With

            If TipoFormulario = TipoFormu.Nueva Then
                'Cambio el titulo segun el formulario
                lblLocalidad.Text = "ALTA DE LOCALIDAD"

            ElseIf TipoFormulario = TipoFormu.Modificar Then
                'Cambio el titulo segun el formulario
                lblLocalidad.Text = "MODIFICAR LOCALIDAD"

                'Si la localidad pasada por parametro no es nula, asigno sus propiedades a los controles del formulario
                If Localidad IsNot Nothing Then
                    With Localidad
                        txtNombreLocalidad.Text = .NombreLocalidad
                        txtCodigoPostal.Text = .CP
                        cboProvincia.SelectedValue = .Provincia
                    End With
                Else
                    Throw New Exception("Los datos de la localidad no se pudieron cargar")
                End If
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
            'Si el formulario era de nueva localidad
            If TipoFormulario = TipoFormu.Nueva Then

                'Guardo las propiedades en el objeto
                With Localidad
                    .NombreLocalidad = txtNombreLocalidad.Text
                    .CP = txtCodigoPostal.Text
                    .Provincia = (cboProvincia.SelectedItem).IdProvincia
                End With

                'Uso la funcion para insertar nueva localidad
                Dim registro As Short = Localidad.InsertarLocalidad()

                'Compruebo que se haya dado de alta correctamente
                If registro = 1 Then
                    MsgBox("Alta realizada con exito", MsgBoxStyle.Information, Text)
                Else
                    Throw New Exception("El registro no pudo ser dado de alta")
                End If

                'Si el formulario era de modificacion localidad
            ElseIf TipoFormulario = TipoFormu.Modificar Then
                'Creo un nuevo objeto al que le asigno los datos modificados y no modificados
                Dim locanueva As New eLocalidad

                With locanueva
                    .IdLocalidad = Localidad.IdLocalidad
                    .NombreLocalidad = txtNombreLocalidad.Text
                    .CP = txtCodigoPostal.Text
                    .Provincia = (cboProvincia.SelectedItem).IdProvincia
                End With

                'Uso la funcion para actualizar localidades
                Dim registro As Short = Localidad.ActualizarLocalidad(locanueva)

                'Compruebo que se haya modificado correctamente
                If registro = 1 Then
                    MsgBox("El registro fue actualizado correctamente", MsgBoxStyle.Information, Text)
                Else
                    Throw New Exception("El registro no pudo ser actualizado")
                End If
            End If

            'Confirmo el formulario
            DialogResult = DialogResult.OK

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    'Evento al pulsar una tecla en el txt
    Private Sub txtCodigoPostal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPostal.KeyPress
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

    'Evento al pulsar una tecla en el cbo
    Private Sub cboProvincia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProvincia.KeyPress
        'Este evento se ejecuta cada vez que se presiona una tecla en el control.
        'Pregunto si es numerico el valor de la tecla presionada de ser asi no muestro el valor en el control.
        'Caso contrario  dejo que el valor tecleado se muestre
        If IsNumeric(e.KeyChar) Then
            'El handled me indica que tomara lo que tecleamos y si es false lo dejara pasar, pero si es True lo toma y no me lo muestra
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region
End Class