Imports JJ.Gestoras
Imports JJ.Entidades

Public Class frmCierre
    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmCierre_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class