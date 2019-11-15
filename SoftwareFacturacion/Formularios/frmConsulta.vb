Imports JJ.Entidades
Imports JJ.Gestoras

Public Class frmConsulta

    Private sep As Char
    Public unidad As Decimal = 0

    Private coma As Boolean
    Private val As Integer = 0

    Private Sub txtSaldoInicial_TextChanged(sender As Object, e As EventArgs) Handles txtSaldoInicial.TextChanged
        If txtSaldoInicial.Text.Contains(sep) Then
            coma = False
        Else
            coma = True
        End If
    End Sub

    Private Sub frmConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    End Sub

    Private Sub txtSaldoInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSaldoInicial.KeyPress
        If Not (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Not (Char.IsNumber(e.KeyChar) Or (e.KeyChar.Equals(sep) And coma And txtSaldoInicial.TextLength > 0) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Else
            If IsNumeric(txtSaldoInicial.Text) Then
                unidad = txtSaldoInicial.Text
                DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If

        If txtSaldoInicial.Text.Length = 0 And e.KeyChar = "-" Then
            e.Handled = False
        End If
    End Sub

    Private Sub frmConsulta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If txtSaldoInicial.Text <> "" Then
            Dim saldoini As Decimal = Convert.ToDecimal(txtSaldoInicial.Text)
            Dim c As Caja
            c = GesCajas.getInstance().Caja

            Dim vc As Decimal = GesCajas.getInstance().GetTotalVentaContado(c.Codigo, c.Z, 1)
            Dim dc As Decimal = GesCajas.getInstance().getDevolucionesContado(c.Codigo, c.Z, 1)
            Dim pagos As Decimal = GesCajas.getInstance().getTotalPagos(c.Codigo, 0, 1)


            Dim totcalculado As Decimal = saldoini + vc - dc - pagos

            txtSaldoCalculado.Text = Decimal.Round(totcalculado, 2)
        Else
            MsgBox("Complete saldo inicial", MsgBoxStyle.Information)
        End If
    End Sub
End Class