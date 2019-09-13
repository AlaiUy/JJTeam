Imports JJ.Entidades
Imports JJ.Gestoras
Public Class frmAnulacion
    Private objF As VentaContado

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        objF = GesDocumentos.getInstance().getVentaDocumento(txtNumero.Text, txtSerie.Text, 1)
        MsgBox(objF.Fecha)
    End Sub

    Private Sub frmAnulacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmAnulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class