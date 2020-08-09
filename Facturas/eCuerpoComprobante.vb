Imports CapaDatos
Public Class eCuerpoComprobante
#Region "Campos"
    'Declaracion de los campos a utilizar
    'Agregar producto a la lista del dgv
    Private _IdCuerpo As Integer
    Private _NumeroComprobante As Integer
    Private _ProductoServicio As Integer
    Private _Cantidad As Double

    'Campo solo para mostrar en el DGV la unidad de medida
    Private _UnidadMedida As Integer

    Private _PrecioUnitario As Double
    Private _Bonificacion As Double
    Private _BonificacionTotal As Double
    Private _Total As Double

    'Solo para calculos internos
    Private _SubTotal As Double
#End Region

#Region "Propiedades"
    'Declaracion de la propiedad vinculada al campo correspondiente
    Public Property IdCuerpo As Integer
        Get
            Return _IdCuerpo
        End Get
        Set(value As Integer)
            _IdCuerpo = value
        End Set
    End Property
    Public Property NumeroComprobante As Integer
        Get
            Return _NumeroComprobante
        End Get
        Set(value As Integer)
            _NumeroComprobante = value
        End Set
    End Property

    Public Property ProductoServicio As Integer
        Get
            Return _ProductoServicio
        End Get
        Set(value As Integer)
            _ProductoServicio = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Return _Cantidad
        End Get
        Set(value As Double)
            If value > 0 Then
                _Cantidad = value
            Else
                Throw New Exception("La cantidad no puede ser nula o negativa")
            End If
        End Set
    End Property

    'Propiedad para acceder al campo y mostrar su valor en el DGV solamente
    Public Property UnidadMedida As Integer
        Get
            Return _UnidadMedida
        End Get
        Set(value As Integer)
            _UnidadMedida = value
        End Set
    End Property

    Public Property PrecioUnitario As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(value As Double)
            If value > 0 Then
                _PrecioUnitario = value
            Else
                Throw New Exception("El precio no puede ser nulo o negativo")
            End If
        End Set
    End Property

    Public Property Bonificacion As Double
        Get
            Return _Bonificacion
        End Get
        Set(value As Double)
            If value >= 0 Then
                _Bonificacion = value
            Else
                Throw New Exception("La bonificacion no puede ser negativa")
            End If
        End Set
    End Property

    Public Property BonificacionTotal As Double
        Get
            Return _BonificacionTotal
        End Get
        Set(value As Double)
            _BonificacionTotal = value
        End Set
    End Property

    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(value As Double)
            _Total = value
        End Set
    End Property

    Public Property SubTotal As Double
        Get
            Return _SubTotal
        End Get
        Set(value As Double)
            _SubTotal = value
        End Set
    End Property
#End Region

#Region "Funciones"

#End Region
End Class
