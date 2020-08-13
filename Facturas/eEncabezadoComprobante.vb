Imports CapaDatos, CapaNegocio
Public Class eEncabezadoComprobante
#Region "Campos"
    'Declaracion de los campos a utilizar
    Private _NumComprobante As Integer
    Private _ComprobanteCompleto As String
    Private _CAE As String
    Private _TipoComprobante As Integer
    Private _Fecha As Date
    Private _Cliente As Integer
    Private _CondicionIva As Integer
    Private _ConceptoInc As String
    Private _PuntoVta As Integer
    Private _FormaPago As Integer
    Private _Operacion As Integer
    Private _Tarjeta As Integer
    Private _NumeroTarjDebito As String
    Private _NumeroTarjCredito As String

    'Campo para comprobar fecha de comprobante
    Private _FechaVieja As Date = DateAdd(DateInterval.Day, -5, Today.Date)
#End Region

#Region "Propiedades"
    'Declaracion de la propiedad vinculada al campo correspondiente
    Public Property NumComprobante As Integer
        Get
            Return _NumComprobante
        End Get
        Set(value As Integer)
            _NumComprobante = value
        End Set
    End Property

    Public Property ComprobanteCompleto As String
        Get
            Return _ComprobanteCompleto
        End Get
        Set(value As String)
            _ComprobanteCompleto = value
        End Set
    End Property

    Public Property CAE As String
        Get
            Return _CAE
        End Get
        Set(value As String)
            _CAE = value
        End Set
    End Property

    Public Property TipoComprobante As Integer
        Get
            Return _TipoComprobante
        End Get
        Set(value As Integer)
            _TipoComprobante = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            'Si la fecha supera los 5 dias de diferencia, lanza el error (AFIP no permite facturar con mas de 5 dias de diferencia)
            If value < _FechaVieja Then
                Throw New Exception("La diferencia de fecha con la actual no puede ser mayor a 5")
            Else
                _Fecha = value
            End If
        End Set
    End Property

    Public Property Cliente As Integer
        Get
            Return _Cliente
        End Get
        Set(value As Integer)
            _Cliente = value
        End Set
    End Property

    Public Property CondicionIva As Integer
        Get
            Return _CondicionIva
        End Get
        Set(value As Integer)
            _CondicionIva = value
        End Set
    End Property

    Public Property ConceptoInc As String
        Get
            Return _ConceptoInc
        End Get
        Set(value As String)
            _ConceptoInc = value.Trim()
        End Set
    End Property

    Public Property PuntoVta As Integer
        Get
            Return _PuntoVta
        End Get
        Set(value As Integer)
            _PuntoVta = value
        End Set
    End Property

    Public Property FormaPago As Integer
        Get
            Return _FormaPago
        End Get
        Set(value As Integer)
            _FormaPago = value
        End Set
    End Property

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
        End Set
    End Property

    Public Property Tarjeta As Integer
        Get
            Return _Tarjeta
        End Get
        Set(value As Integer)
            _Tarjeta = value
        End Set
    End Property

    Public Property NumeroTarjDebito As String
        Get
            Return _NumeroTarjDebito
        End Get
        Set(value As String)
            'El valor tendra que ser hasta 16 caracteres de longitud y numerico
            If (value.Trim().Length <= 19 And value.Trim().Length >= 13 And IsNumeric(value.Trim())) Or value.Trim() = "" Then
                _NumeroTarjDebito = value.Trim()
            Else
                Throw New Exception("Largo y/o contenido de Numero de Tarjeta Debito incorrecto")
            End If
        End Set
    End Property

    Public Property NumeroTarjCredito As String
        Get
            Return _NumeroTarjCredito
        End Get
        Set(value As String)
            'El valor tendra que ser hasta 16 caracteres de longitud y numerico
            If (value.Trim().Length <= 19 And value.Trim().Length >= 13 And IsNumeric(value.Trim())) Or value.Trim() = "" Then
                _NumeroTarjCredito = value.Trim()
            Else
                Throw New Exception("Largo y/o contenido de Numero de Tarjeta Credito incorrecto")
            End If
        End Set
    End Property
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Inserta los datos de un comprobante en la base de datos
    ''' </summary>
    ''' <returns></returns>
    Public Function InsertarComprobante() As Integer
        Dim query As New clsArmadoQuery
        Dim comprobante As New clsEjecucionQuery
        Dim registro As Short

        'Le asigno las propiedades al objeto
        With comprobante
            .ModoProceso = clsEjecucionQuery.TipoProceso.Comprobante
            .Comando = query.insertarNuevoRegistro(Me, "encabezado_comprobantes")
            registro = .IdNuevoRegistro
        End With

        'Devuelvo el id del registro
        Return registro
    End Function
#End Region
End Class
