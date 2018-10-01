Imports JJ.Entidades
Imports JJ.Gestoras
Imports JJ.Interfaces.Observer

Public Class frmNuevaMarca
    Implements IObservable
    Private _Obs As IList(Of IObserver)
    Private _Marca As Marca = Nothing

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal xObserver As IObserver)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Register(xObserver)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmNuevaMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim xMarca As New Marca()
        xMarca.Nombre = txtMarca.Text.Trim().ToUpper()
        Try
            _Marca = GesArticulos.getInstance().AddMarca(xMarca)
            If Not IsNothing(_Marca) Then
                notifyObservers()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Register(xObserver As IObserver) Implements IObservable.Register
        If IsNothing(xObserver) Then
            Return
        End If
        If IsNothing(_Obs) Then
            _Obs = New List(Of IObserver)
        End If
        _Obs.Add(xObserver)
    End Sub

    Public Sub UnRegister(xObserver As IObserver) Implements IObservable.UnRegister
        If IsNothing(xObserver) Then Return
        If IsNothing(_Obs) Then Return
        _Obs.Remove(xObserver)
    End Sub

    Public Sub notifyObservers() Implements IObservable.notifyObservers
        If Not IsNothing(_Marca) Then
            For Each Obs As IObserver In _Obs
                Obs.Update(_Marca)
            Next
        End If
    End Sub
End Class