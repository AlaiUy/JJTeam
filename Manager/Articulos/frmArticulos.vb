Public Class frmArticulos
    Private Sub frmArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If

    End Sub

    Private Sub frmArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class