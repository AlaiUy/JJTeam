Imports JJ.Entidades
Imports JJ.Gestoras

Public Class frmCompras
    Private Articulos As List(Of Object)
    Private _ImpBruto As Decimal = 0
    Private _ImpIva As Decimal = 0
    Private _ImpDescuento As Decimal = 0
    Private _ImpTotal As Decimal = 0
    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Articulos = GesArticulos.getInstance().getArticulos()
            Popular()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Popular()
        PopularGrilla()


    End Sub

    Private Sub AgregarArticulo(ByVal xArticulo As Articulo, ByVal xCantidad As Decimal)
        If IsNothing(xArticulo) Then
            MsgBox("Ese articulo no existe")
            Return
        End If
        If (xCantidad < 0) Then
            MsgBox("La cantidad no puede ser negativa")
            Return
        End If
        Try
            dgCompras.Rows.Add(xArticulo.CodArticulo, xArticulo.Referencia, xArticulo.Nombre + " - " + xArticulo.Descripcion, xCantidad, 1, 22, 1, 0, 1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopularGrilla()
        Dim SumaAnchos As Decimal = 1
        For Each C As DataGridViewColumn In dgCompras.Columns
            If C.Visible Then
                SumaAnchos += C.Width
            End If
        Next
        dgCompras.Columns("NOMBRE").Width += dgCompras.Width - (SumaAnchos)
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If e.KeyChar = Chr(13) And Not String.IsNullOrEmpty(DirectCast(sender, TextBox).Text) Then
            Dim Cantidad As Decimal = Convert.ToDecimal(txtCantidad.Text)
            Dim A As Articulo = Articulos.Find(Function(Ar As Articulo) Ar.Referencia = TryCast(sender, TextBox).Text)
            If Not IsNothing(A) Then
                AgregarArticulo(A, Cantidad)
                Totalizar()
            End If
        End If

        If e.KeyChar = "+" Then
            e.Handled = True
            If IsNumeric(txtReferencia.Text) Then
                If ValidarImportes(e.KeyChar, TryCast(sender, TextBox).Text, TryCast(sender, TextBox).SelectionLength, TryCast(sender, TextBox).SelectionStart, 6) Then
                    txtCantidad.Text = txtReferencia.Text
                End If
                txtReferencia.Text = String.Empty
            End If

        End If

    End Sub

    Private Sub dgCompras_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCompras.CellEndEdit
        If IsDBNull(TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("CANTIDAD").Value) Or TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("CANTIDAD").Value < 0 Then
            TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("CANTIDAD").Value = 1
            MsgBox("La cantidad no puede ser negativa, verifique")

            Return
        End If
        If IsDBNull(TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("PRECIO").Value) Or TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("PRECIO").Value < 0 Then
            TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("PRECIO").Value = 1
            MsgBox("El precio ingresado no puede ser negativo, verifique")
            Return
        End If
        If TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("DESCUENTO").Value >= 100 Then
            TryCast(sender, DataGridView).Rows(e.RowIndex).Cells("DESCUENTO").Value = 0
            MsgBox("El Descuento realizado no es correcto")
            Return
        End If
        Totalizar()
    End Sub

    Private Sub Totalizar()
        _ImpBruto = 0
        _ImpDescuento = 0
        _ImpIva = 0
        _ImpTotal = 0
        For Each R As DataGridViewRow In dgCompras.Rows
            Dim Cantidad As Decimal = 0
            Dim Precio As Decimal = 0
            Dim Iva As Decimal = 0
            Dim Descuento As Decimal = 0
            Dim PBruto As Decimal = 0
            Dim PNeto As Decimal = 0
            Dim PFinal As Decimal = 0
            Dim PIva As Decimal = 0

            Cantidad = R.Cells("CANTIDAD").Value
            Precio = R.Cells("PRECIO").Value
            Iva = R.Cells("IVA").Value
            Descuento = R.Cells("DESCUENTO").Value
            PBruto = Precio * Cantidad
            R.Cells("SUBTOTAL").Value = PBruto
            PNeto = PBruto * (1 + (Iva / 100))
            PFinal = (((100 - Descuento) * PNeto) / 100)
            R.Cells("FINAL").Value = PFinal
            _ImpBruto += PBruto
            _ImpDescuento += PFinal - PNeto
            _ImpIva = PNeto - PBruto
            _ImpTotal = PFinal
            txtSubTotal.Text = FormatearImporte(_ImpBruto)
            txtIva.Text = FormatearImporte(_ImpIva)
            txtDescuento.Text = FormatearImporte(Math.Abs(_ImpDescuento))
            txtFinal.Text = FormatearImporte(_ImpTotal)
        Next
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub txtReferencia_TextChanged(sender As Object, e As EventArgs) Handles txtReferencia.TextChanged

    End Sub

    Private Sub btnBorrarLinea_Click(sender As Object, e As EventArgs) Handles btnBorrarLinea.Click
        If Not IsNothing(dgCompras.CurrentRow) Then
            dgCompras.Rows.Remove(dgCompras.CurrentRow)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GesDocumentos.getInstance().addEspera(New Espera())
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class