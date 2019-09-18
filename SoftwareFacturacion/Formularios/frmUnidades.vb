Public Class frmUnidades
    Private sep As Char
    Public unidad As Decimal = 0

    Private coma As Boolean
    Private val As Integer = 0

    Private Sub frmUnidades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            DialogResult = DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Public Sub nombre(txt As String)
        lbl.Text = txt
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        unidad = txtUnidades.Text
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    End Sub

    Private Sub txtUnidades_TextChanged(sender As Object, e As EventArgs) Handles txtUnidades.TextChanged
        If txtUnidades.Text.Contains(Sep) Then
            coma = False
        Else
            coma = True
        End If
    End Sub

    Private Sub txtUnidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnidades.KeyPress
        If Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Not (Char.IsNumber(e.KeyChar) Or (e.KeyChar.Equals(Sep) And coma And txtUnidades.TextLength > 0) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Else
            If IsNumeric(txtUnidades.Text) Then
                unidad = txtUnidades.Text
                DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If

        If txtUnidades.Text.Length = 0 And e.KeyChar = "-" Then
            e.Handled = False
        End If
    End Sub
End Class