Imports CapaPresentacionComprobantes
Imports CapaPresentacionClientes
Imports CapaPresentacionProductos
Imports CapaPresentacionUsuarioAFIP
Imports CapaPresentacionLocalidades
Imports CapaPresentacionConfiguracion
Imports CapaPresentacionProveedores
Imports CapaPresentacionInformes
Public Class frmVistaPrincipal
#Region "Eventos"
    Private Sub frmVistaPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Desactivo de la vista a los Rubros
        RUBROSToolStripMenuItem.Visible = False
    End Sub

    Private Sub EXITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITToolStripMenuItem.Click
        'Cierro el programa y todos sus subprocesos
        End
    End Sub

    'FACTURAS
    Private Sub FACTURASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FACTURASToolStripMenuItem.Click
        'Si el formulario no esta abierto ingresa al IF
        If Not AbrirFormularioHijo("FACTURACION") Then
            'Creo un nuevo objeto para usarlo
            Dim nuevoHijo As New frmFacturaGeneral
            'Creo el nuevo formulario
            CrearFormularioHijo(nuevoHijo, "FACTURACION")
        End If
    End Sub

    'CLIENTES
    Private Sub CONSULTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONSULTAToolStripMenuItem.Click
        'Si el formulario no esta abierto ingresa al IF
        If Not AbrirFormularioHijo("CONSULTA DE CLIENTES") Then
            'Creo un nuevo objeto para usarlo
            Dim nuevoHijo As New frmVistaClientes
            'Creo el nuevo formulario
            CrearFormularioHijo(nuevoHijo, "CONSULTA DE CLIENTES")
        End If
    End Sub

    'PRODUCTOS
    Private Sub CONSULTAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONSULTAToolStripMenuItem1.Click
        'Si el formulario no esta abierto ingresa al IF
        If Not AbrirFormularioHijo("CONSULTA DE PRODUCTOS") Then
            'Creo un nuevo objeto para usarlo
            Dim nuevoHijo As New frmVistaProductos
            'Creo el nuevo formulario
            CrearFormularioHijo(nuevoHijo, "CONSULTA DE PRODUCTOS")
        End If
    End Sub

    'PROVEEDORES
    Private Sub CONSULTAToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CONSULTAToolStripMenuItem3.Click
        'Creo un nuevo objeto de reactivacion
        Dim dialogo As New frmDialogoProveedores
        dialogo.TipoFormulario = frmDialogoProveedores.TipoFormu.Consulta
        'Lo muestro
        Reactivacion(dialogo)
    End Sub

    'LOCALIDADES
    Private Sub CONSULTAToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CONSULTAToolStripMenuItem2.Click
        'Creo un nuevo objeto de reactivacion
        Dim dialogo As New frmDialogoLocalidades
        dialogo.TipoFormulario = frmDialogoLocalidades.TipoFormu.Consulta
        'Lo muestro
        Reactivacion(dialogo)
    End Sub

    'CONFIGURACIONES
    Private Sub CONFIGURACIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONFIGURACIONToolStripMenuItem.Click
        'Si el formulario no esta abierto ingresa al IF
        If Not AbrirFormularioHijo("CONFIGURACIONES") Then
            'Creo un nuevo objeto para usarlo
            Dim nuevoHijo As New frmConfiguracion
            'Creo el nuevo formulario
            CrearFormularioHijo(nuevoHijo, "CONFIGURACIONES")
        End If
    End Sub

    'INFORMES
    Private Sub INFORMESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INFORMESToolStripMenuItem.Click
        'Si el formulario no esta abierto ingresa al IF
        If Not AbrirFormularioHijo("INFORMES") Then
            'Creo un nuevo objeto para usarlo
            Dim nuevoHijo As New frmInformes
            'Creo el nuevo formulario
            CrearFormularioHijo(nuevoHijo, "INFORMES")
        End If
    End Sub

    'USUARIO AFIP
    Private Sub USUARIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USUARIOToolStripMenuItem.Click
        'Creo un nuevo objeto de reactivacion
        Dim dialogo As New frmGestionUsuario
        'Lo muestro
        Reactivacion(dialogo)
    End Sub

    'Evento para redimensionar la imagen del formulario segun varie el tamaño del mismo
    Private Sub frmVistaPrincipal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Al control que contiene la imagen, le cambio el tamaño segun cambie el tamaño del formulario
        pbxImagenDietetica.Height = Size.Height
        pbxImagenDietetica.Width = Size.Width - 15 'Le aplico un pequeño factor de correccion
    End Sub

    'Cuando se activa un hijo de este formulario
    Private Sub frmVistaPrincipal_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
        'Oculto la imagen
        pbxImagenDietetica.Visible = False
    End Sub

    'Cuando el foco vuelve al formulario
    Private Sub frmVistaPrincipal_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        'Vuelvo a mostrar la imagen
        pbxImagenDietetica.Visible = True
    End Sub

    'Evento que deshabilita la posibilidad de cerrar el programa desde el menu del formulario asi no quedan subprocesos en ejecucion
    Private Sub frmVistaPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Si la razon por la que se esta cerrando el formulario es porque el usuario hizo click en el menu del formulario o con ALT+F4 o desde la barra de tareas, cancela dicha interaccion
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Funcion que permite detectar si un formulario hijo esta abierto dentro de uno padre
    ''' </summary>
    ''' <param name="NombreFormu">Nombre del formulario hijo</param>
    ''' <returns></returns>
    Function AbrirFormularioHijo(NombreFormu As String) As Boolean
        'Variable que indicara si se encontro algun formulario que cumpla con las condiciones dadas
        Dim bandera As Boolean
        'Objeto que contendra el formulario hijo que se estara analizando
        Dim formu As New Form

        'Preguntamos si existe algun formulario hijo en la coleccion de formularios hijos del frmPrincipal
        If Me.MdiChildren.Count > 0 Then
            'Recorremos todos los formularios hijos del frmPrincipal
            For Each formu In Me.MdiChildren
                'Consultamos si el formulario hijo que se esta analizando cumple con la condicion de igualdad de la propiedad text pasado por parametro
                If formu.Text = NombreFormu Then
                    'Si el formulario hijo cumple con la condicion anterior colocamos en verdadero la variable bandera y salimos del bucle For Each...Next
                    bandera = True
                    Exit For
                End If
            Next
        End If

        'Preguntamos si bandera esta en verdadero (el formulario ya esta abierto)
        If bandera Then
            'Si el formulario ya esta abierto hacemos foco en el.
            formu.Focus()
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Metodo que permite crear un nuevo formulario hijo y asignarselo a un formulario padre
    ''' </summary>
    ''' <param name="frmHijo">Formulario a crear</param>
    ''' <param name="NombreFormu">Nombre del formulario hijo</param>
    Sub CrearFormularioHijo(ByRef frmHijo As Form, NombreFormu As String)
        'Si el formulario no se encuentra abierto, Instanciamos un objeto del tipo del formulario que queremos abrir, configuramos sus propiedades y lo abrimos
        With frmHijo
            .MdiParent = Me 'Le decimos que heredara propiedades del padre frmPrincipal
            .Text = NombreFormu
            .Show() 'Con este evento se muestra el formulario
        End With
    End Sub

    ''' <summary>
    ''' Metodo que abre un dialogo con los formularios de reactivacion creados
    ''' </summary>
    ''' <param name="formulario">Tipo de formulario a crear</param>
    Public Sub Reactivacion(ByRef formulario As Form)
        'Muestro el formulario apropiado
        With formulario
            .ShowDialog()
        End With
    End Sub
#End Region
End Class
