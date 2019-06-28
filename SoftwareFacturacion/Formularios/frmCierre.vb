Imports JJ.Gestoras
Imports JJ.Entidades

Public Class frmCierre

    Private mCodVendedor As Integer

    Public Sub New(xCodvendedor)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        mCodVendedor = xCodvendedor
    End Sub

    Private Sub frmCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPesosInicial.Text = GesCajas.getInstance.GetSaldoDeclarado(1, 1)
        txtPesosInicial.Text = GesCajas.getInstance.GetSaldoDeclarado(2, 1)
    End Sub

    Private Sub frmCierre_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCierre_Click(sender As Object, e As EventArgs) Handles btnCierre.Click
        Try
            If txtPesosFinal.Text <> "" And txtFinalDolares.Text <> "" And txtPesosInicial.Text <> "" And txtDolaresInicial.Text <> "" Then
                GesCajas.getInstance.CierreCaja(txtPesosFinal.Text, txtFinalDolares.Text, mCodVendedor)
                MsgBox("Cierre Realizado")
            Else
                MsgBox("Declare saldos Finales e Iniciales")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class