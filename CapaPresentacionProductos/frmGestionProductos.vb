Imports entProducto, entRubro, entUnidadMedida, entProveedor, entStock
Imports CapaPresentacionProveedores
Public Class frmGestionProductos
#Region "Campos"
    Public Enum TipoFormu
        Nuevo
        Consulta
    End Enum

    Private _TipoFormulario As TipoFormu
    Private _IdPro As Integer
    Private _productoOriginal As New eProducto

    Private stockOriginal As New eStock
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

    Public Property ProductoOriginal As eProducto
        Get
            Return _productoOriginal
        End Get
        Set(value As eProducto)
            _productoOriginal = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmGestionProductos_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Busco una lista de los rubros y se lo asigno al cbo
        Dim rubro As New eRubro
        With cboRubro
            .DataSource = rubro.ObtenerRubros
            .ValueMember = "IdRubro"
            .DisplayMember = "NombreRubro"
            .SelectedValue = 1
        End With

        'Busco una lista de las unidades medida y se la asigno al cbo
        Dim unidadmedida As New eUnidadMedida
        With cboUnidad
            .DataSource = unidadmedida.ObtenerUnidadesMedidas
            .ValueMember = "IdUnidadMedida"
            .DisplayMember = "TipoUnidad"
        End With

        'Si es un nuevo producto
        If TipoFormulario = TipoFormu.Nuevo Then
            'Cambio el titulo segun el formulario
            lblGestioProductos.Text = "ALTA DE PRODUCTO"

            'Deshabilitos los botones
            btnModificar.Visible = False
            btnBaja.Visible = False

            'Cambio el nombre del boton y su imagen
            btnCancelar.Text = "CANCELAR"
            btnCancelar.Image = My.Resources.stop_error

            'Si es consulta
        ElseIf TipoFormulario = TipoFormu.Consulta Then
            'Cambio el titulo segun el formulario
            lblGestioProductos.Text = "CONSULTA DE PRODUCTO"

            'Obtengo los datos del producto con su ID
            ProductoOriginal = ProductoOriginal.ObtenerProducto(IdPro)

            'Objeto para obtener los datos del proveedor
            Dim prove As New eProveedor

            'Objeto para obtener el stock
            Dim stock As New eStock

            'Le asigno los datos a los controles
            With ProductoOriginal
                txtNombreProducto.Text = .NombreProducto
                cboRubro.SelectedValue = .Rubro
                txtPrecioCosto.Text = .PrecioCosto.ToString("F2")
                txtPorcentaje.Text = (((.PrecioFinal / .PrecioCosto) * 100) - 100).ToString("F2")
                txtPrecioFinal.Text = .PrecioFinal.ToString("F2")
                txtProv.Text = prove.ObtenerProveedor(.Proveedor).NombreProveedor
                cboUnidad.SelectedValue = .UnidadMedida
                txtStock.Text = stock.ObtenerStockProducto(IdPro).StockExistencia
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
            'Creo un objeto para guardar el proveedor
            Dim prov As New eProveedor

            'Creo un objeto para guardar el stock
            Dim stock As New eStock

            'Si era un nuevo producto
            If TipoFormulario = TipoFormu.Nuevo Then
                'Guardo los datos de los controles en el objeto
                With ProductoOriginal
                    .NombreProducto = txtNombreProducto.Text
                    .Rubro = cboRubro.SelectedValue
                    .PrecioCosto = txtPrecioCosto.Text
                    .PrecioFinal = txtPrecioFinal.Text
                    'Con el nombre del proveedor, uso su metodo y obtengo el ID del mismo
                    .Proveedor = prov.obtenerProveedorNombre(txtProv.Text).IdProveedor
                    .UnidadMedida = cboUnidad.SelectedValue
                    .Activo = 1
                End With

                'Guardo el valor del stock para asegurarme de que se ha introducido
                If txtStock.Text.Trim = 0 Then
                    stock.StockExistencia = 0
                End If

                'Llamo a la funcion para crear el registro del producto y guardar su id
                Dim idProdNuevo As New Integer
                idProdNuevo = ProductoOriginal.InsertarProducto()

                'Guardo el valor del Id del producto generado
                stock.IdProdStock = idProdNuevo

                'Llamo a la funcion para crear el registro del stock
                Dim registroStock As New Integer
                registroStock = stock.InsertarStock()

                'Verifico que se haya insertado correctamente
                If idProdNuevo > 0 And registroStock > 0 Then
                    MsgBox("Alta realizada con exito", MsgBoxStyle.Information, Text)
                Else
                    Throw New Exception("El registro no pudo ser dado de alta")
                End If

                'Si el formulario es de consulta-modificacion
            ElseIf TipoFormulario = TipoFormu.Consulta Then
                'Obtengo los datos del producto original segun el ID pasado por propiedad
                ProductoOriginal = ProductoOriginal.ObtenerProducto(IdPro)

                'Obtengo los datos del stock original
                stockOriginal = stockOriginal.ObtenerStockProducto(IdPro)

                'En un objeto nuevo guardo la unidad de medida seleccionada
                Dim unidad As eUnidadMedida = cboUnidad.SelectedItem

                'Creo un objeto nuevo donde guardo los datos actualizados del producto
                Dim productoNuevo As New eProducto

                'Le asigno los valores al objeto nuevo
                With productoNuevo
                    .IdProducto = IdPro
                    .NombreProducto = txtNombreProducto.Text
                    .Rubro = cboRubro.SelectedValue
                    .PrecioCosto = txtPrecioCosto.Text
                    .PrecioFinal = txtPrecioFinal.Text
                    'Con el nombre del proveedor, uso su metodo y obtengo el ID del mismo
                    .Proveedor = prov.obtenerProveedorNombre(txtProv.Text).IdProveedor
                    .UnidadMedida = unidad.IdUnidadMedida
                    .Activo = 1
                End With

                'Creo un objeto para guardar los datos actuales del stock
                Dim stockNuevo As New eStock

                With stockNuevo
                    .IdStock = stockOriginal.IdStock
                    .IdProdStock = IdPro
                    .StockExistencia = txtStock.Text
                End With

                'Llamo a la funcion para actualizar desde el producto original y le paso el objeto con los datos del producto modificado
                Dim actualizacion1 As Short = ProductoOriginal.ActualizarProducto(productoNuevo)

                Dim actualizacion2 As New Short

                'Si los stock son diferentes
                If Not stockNuevo.StockExistencia = stockOriginal.StockExistencia Then
                    actualizacion2 = stockOriginal.ActualizarStock(stockNuevo)
                End If

                'Compruebo que se haya modificado correctamente el producto y stock o solo el producto
                If actualizacion1 = 1 Or actualizacion2 = 1 Then
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

        Text = "MODIFICACION DE PRODUCTO"
        lblGestioProductos.Text = "MODIFICAR PRODUCTO"
    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        'Compruebo que se haya seleccionado un registro
        Try
            'Creo un nuevo objeto y le asigno el resultado del MessageBox creado
            Dim resultado As DialogResult = MessageBox.Show("¿Seguro desea dar de baja el registro seleccionado?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            'Si se confirma la accion, se da de baja el registro
            If resultado = DialogResult.Yes Then
                'Creo un nuevo objeto para guardar los datos y cambiar su estado
                Dim prodMod As eProducto = ProductoOriginal.ObtenerProducto(IdPro)
                prodMod.Activo = 0

                'Llamo a la funcion que me permite actualizar registros y guardo el resultado si fue actualizado con exito
                If ProductoOriginal.ActualizarProducto(prodMod) = 1 Then
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

    Private Sub btnBuscarProv_Click(sender As Object, e As EventArgs) Handles btnBuscarProv.Click
        'Creo un objeto para obtener los datos del proveedor encontrado
        Dim pro As New eProveedor

        'Creo un nuevo objeto para ver los proveedores
        Dim proveedo As New frmDialogoProveedores

        'Lo muestro como dialogo
        With proveedo
            .TipoFormulario = frmDialogoProveedores.TipoFormu.Seleccion
            .ShowDialog()
            If .DialogResult = DialogResult.OK Then
                'Si la seleccion fue correcta, guardo y muestro su nombre
                txtProv.Text = pro.ObtenerProveedor(.IdPro).NombreProveedor
            End If
        End With
    End Sub

    'Cuando se pulsa una tecla sobre el txt PrecioCosto
    Private Sub txtPrecioCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioCosto.KeyPress
        'Llamo al metodo apropiado
        CaracterNumericoPuntoComa(txtPrecioCosto, e)
    End Sub

    'Cuando se pulsa una tecla sobre el txt PrecioFinal
    Private Sub txtPrecioFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioFinal.KeyPress
        'Llamo al metodo apropiado
        CaracterNumericoPuntoComa(txtPrecioFinal, e)
    End Sub

    'Cuando se pulsa una tecla sobre el txt Procentaje
    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        'Llamo al metodo apropiado
        CaracterNumericoPuntoComa(txtPorcentaje, e)
    End Sub

    'Cuando se pulsa una tecla sobre el txt stock
    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        'Llamo al metodo apropiado
        CaracterNumericoPuntoComa(txtStock, e)
    End Sub

    'Cuando se salga de foco del precioCosto o el Procentaje
    Private Sub txtPrecioCosto_LostFocus(sender As Object, e As EventArgs) Handles txtPrecioCosto.LostFocus, txtPorcentaje.LostFocus
        'Cambio cualquier punto en los controles por una coma
        If txtPrecioCosto.Text.Trim.Contains(".") Then
            txtPrecioCosto.Text = txtPrecioCosto.Text.Replace(".", ",")
        ElseIf txtPorcentaje.Text.Trim.Contains(".") Then
            txtPorcentaje.Text = txtPorcentaje.Text.Replace(".", ",")
        End If

        'Creo 3 objetos para guardar los valores
        Dim preciocosto, preciofinal, porcentaje As Double

        preciofinal = 0

        If Not txtPrecioCosto.Text.Trim = "" Then
            preciocosto = Convert.ToDouble(txtPrecioCosto.Text.Trim())
        Else
            preciocosto = 0
        End If

        If Not txtPorcentaje.Text.Trim = "" Then
            porcentaje = Convert.ToDouble(txtPorcentaje.Text.Trim())
        Else
            porcentaje = 0
        End If


        'Verifico que no se haya escrito ningun valor en el porcentaje
        If txtPorcentaje.Text.Trim() = "" Or porcentaje = 0 Then
            'Los valores van a ser iguales de Costo y Final
            txtPrecioCosto.Text = preciocosto.ToString("F2")
            txtPrecioFinal.Text = preciocosto.ToString("F2")
            'El porcentaje lo asigno para formatearlo ya que va a ser nulo
            txtPorcentaje.Text = porcentaje.ToString("F2")
        Else
            'Guardo los valores de los TXT
            preciocosto = Convert.ToDouble(txtPrecioCosto.Text.Trim)
            porcentaje = Convert.ToDouble(txtPorcentaje.Text.Trim)
            'Calculo el precio final
            preciofinal = (preciocosto * porcentaje / 100) + preciocosto

            'Se lo asigno a los txt
            txtPrecioCosto.Text = preciocosto.ToString("F2")
            txtPorcentaje.Text = porcentaje.ToString("F2")
            txtPrecioFinal.Text = preciofinal.ToString("F2")
        End If
    End Sub

    'Cuando se salga de foco del PrecioFinal
    Private Sub txtPrecioFinal_LostFocus(sender As Object, e As EventArgs) Handles txtPrecioFinal.LostFocus
        'Reemplazo los puntos por coma
        If txtPrecioFinal.Text.Trim.Contains(".") Then
            txtPrecioFinal.Text = txtPrecioFinal.Text.Replace(".", ",")
        End If

        'Creo 3 objetos para guardar los valores
        Dim preciocosto, preciofinal, porcentaje As Double

        If Not txtPrecioFinal.Text.Trim = "" Then
            preciofinal = Convert.ToDouble(txtPrecioFinal.Text.Trim())
        Else
            preciofinal = 0
        End If

        If Not txtPrecioCosto.Text.Trim = "" Then
            preciocosto = Convert.ToDouble(txtPrecioCosto.Text.Trim())
        Else
            preciocosto = 0
        End If

        porcentaje = 0


        If preciofinal < preciocosto Then
            preciofinal = preciocosto
        End If


        If preciocosto > 0 Then
            'Calculo el porcentaje
            porcentaje = ((preciofinal / preciocosto) * 100) - 100
        Else
            porcentaje = 0
        End If


        If porcentaje > 0 Then
            'Lo muestro en el txt
            txtPorcentaje.Text = porcentaje.ToString("F2")
        Else
            txtPorcentaje.Text = "0,00"
        End If

        txtPrecioCosto.Text = preciocosto.ToString("F2")
        txtPrecioFinal.Text = preciofinal.ToString("F2")
    End Sub

    Private Sub txtStock_LostFocus(sender As Object, e As EventArgs) Handles txtStock.LostFocus
        If txtStock.Text.Trim = "" Or Not IsNumeric(txtStock.Text) Then
            txtStock.Text = 0
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
        btnBuscarProv.Enabled = accion2
        cboRubro.Enabled = accion2
        cboUnidad.Enabled = accion2

        txtNombreProducto.ReadOnly = accion1
        txtPrecioCosto.ReadOnly = accion1
        txtPorcentaje.ReadOnly = accion1
        txtPrecioFinal.ReadOnly = accion1
        txtStock.ReadOnly = accion1
    End Sub

    ''' <summary>
    ''' Este metodo se ejecuta cada vez que se presiona una tecla en el control
    ''' </summary>
    ''' <param name="e"></param>
    Public Sub CaracterNumericoPuntoComa(CajaTexto As TextBox, e As KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf (e.KeyChar = "." Or e.KeyChar = ",") And (Not CajaTexto.Text.IndexOf(".") Or Not CajaTexto.Text.IndexOf(",")) Then
            e.Handled = True
        ElseIf e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region
End Class