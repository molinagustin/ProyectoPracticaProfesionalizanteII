Imports entUsuarioAFIP
Public Class frmGestionUsuario
#Region "Campos"
    Private _Usuario As New eUsuarioAfip
#End Region

#Region "Propiedades"
    Public Property Usuario As eUsuarioAfip
        Get
            Return _Usuario
        End Get
        Set(value As eUsuarioAfip)
            _Usuario = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmGestionUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Creo una lista para guardar los usuarios cargados
        Dim listaUsuario As New List(Of eUsuarioAfip)
        'Los obtengo
        listaUsuario = Usuario.ObtenerUsuarios

        'Si hay al menos 1 usuario entro
        If listaUsuario.Count > 0 Then
            If listaUsuario.Count = 1 Then
                'Guardo los datos del primer usuario
                Usuario = listaUsuario.Item(0)

                'Los muestro en los controles
                With Usuario
                    txtUsuario.Text = .NombreUsuario
                    txtClaveF.Text = .ClaveFiscal
                End With
            End If

            'Sino le doy un Id falso 0 para luego poder cargarlo
        Else
            Usuario.IdUsuarioAfip = 0
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Cierro el formulario
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            'Compruebo que los controles tengan datos
            If txtUsuario.Text.Trim.Length > 0 And txtClaveF.Text.Trim.Length > 0 Then
                'Compruebo si es de la carga de un nuevo usuario
                If Usuario.IdUsuarioAfip = 0 Then
                    'Guardo los datos en el objeto
                    Usuario.NombreUsuario = txtUsuario.Text
                    Usuario.ClaveFiscal = txtClaveF.Text

                    'Uso la funcion para insertar un usuario y lo verifico
                    Dim registro As Short = Usuario.InsertarUsuario()

                    If registro = 1 Then
                        MsgBox("Carga realizada con exito", MsgBoxStyle.Information, Text)
                        Close()
                    Else
                        Throw New Exception("El registro no se pudo cargar")
                    End If

                    'Sino modifico el usuario ya cargado
                Else

                    'Guardo los datos en un nuevo objeto para modificacion
                    Dim usuarionuevo As New eUsuarioAfip

                    'Le asigno los valores de los controles
                    With usuarionuevo
                        .IdUsuarioAfip = Usuario.IdUsuarioAfip
                        .NombreUsuario = txtUsuario.Text
                        .ClaveFiscal = txtClaveF.Text
                    End With

                    'Llamo a la funcion para actualizar desde el usuario original
                    Dim registro As Short = Usuario.ActualizarUsuario(usuarionuevo)

                    'Compruebo que se haya modificado correctamente
                    If registro = 1 Then
                        MsgBox("Modificacion realizada con exito", MsgBoxStyle.Information, Text)
                        Close()
                    Else
                        Throw New Exception("El registro no se pudo modificar")
                    End If
                End If
            Else
                Throw New Exception("Campos Incompletos")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Text)
        End Try
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
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

    'Evento que se lanza al marcar o desmarcar el checkbox
    Private Sub cbxMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMostrar.CheckedChanged
        'Si se marca, muestro la contraseña
        If cbxMostrar.Checked Then
            txtClaveF.UseSystemPasswordChar = False

            'Sino la oculto
        Else
            txtClaveF.UseSystemPasswordChar = True
        End If
    End Sub
#End Region

#Region "Metodos"

#End Region
End Class
