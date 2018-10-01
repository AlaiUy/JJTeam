Imports JJ.Entidades
Imports JJ.Gestoras

Public Class frmMain
    Private Sub btnNuevoArticulo_Click(sender As Object, e As EventArgs) Handles btnNuevoArticulo.Click
        Dim frm As Form = New frmNuevoArticulo()
        frm.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TarifaContado As Tarifa = New Tarifa()
        TarifaContado.Nombre = "CONTADO"

        Dim TarifaCredito As Tarifa = New Tarifa()
        TarifaCredito.Nombre = "CREDITO"

        Try
            GesPrecios.getInstance().addTarifa(TarifaContado)
            GesPrecios.getInstance().addTarifa(TarifaCredito)
            MsgBox("Tarifas Agregadas exitosamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class