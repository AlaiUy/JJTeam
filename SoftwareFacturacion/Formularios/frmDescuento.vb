Public Class frmDescuento
    Public xdescuento As Decimal = 0
    Private Sub frmDescuento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()

        End If
    End Sub



    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        xdescuento = txtDescuento.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmDescuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtDescuento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuento.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAceptar.PerformClick()
        End If
    End Sub
End Class