
Imports JJ.Gestoras

Public Class frmPrincipal
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("Desea salir?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub cboxTarifa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.cboxTarifa.DataSource = GesPrecios.getInstance().getTarifas()
            Me.cboxMoneda.DataSource = GesPrecios.getInstance().getMonedas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        Dim frmE As New frmEspera
        frmE.ShowDialog()
    End Sub
End Class