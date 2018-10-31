Imports JJ.Entidades
Imports JJ.Gestoras
Imports JJ.Interfaces.Observer

Public Class frmDepartamentoNuevo
    Implements IObservable
    Private _Obs As IList(Of IObserver)
    Private _Depto As Departamento = Nothing

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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If String.IsNullOrEmpty(txtDepto.Text) Then
            Return
        End If
        Dim xDepto As New Departamento()
        xDepto.Nombre = txtDepto.Text.Trim().ToUpper()
        Try
            _Depto = GesArticulos.getInstance().AddDepto(xDepto)
            If Not IsNothing(_Depto) Then
                notifyObservers()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmDepartamentoNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        If Not IsNothing(_Depto) Then
            For Each Obs As IObserver In _Obs
                Obs.Update(_Depto)
            Next
        End If
    End Sub
End Class