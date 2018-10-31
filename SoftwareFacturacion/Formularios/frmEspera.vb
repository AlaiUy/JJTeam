Public Class frmEspera
    Private Sub frmEspera_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmEspera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class