Imports JJ.Gestoras
Imports JJ.Entidades
Public Class frmPagos

    Dim Sep As Char
    Dim coma As Boolean = False
    Private Sub frmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Me.dtFecha.Value = Date.Now.ToShortDateString
        Me.cboxMoneda.DataSource = GesPrecios.getInstance().getMonedas()
        CargarDatos()
        Me.txtdescripcion.Focus()
    End Sub

    Private Sub CargarDatos()

        dgridPagos.DataSource = GesCajas.getInstance.getPagos(Me.dtFecha.Value.ToString("dd/MM/yyyy"), GesCajas.getInstance.Caja.Codigo)
        dgridPagos.Columns("NUMERO").Visible = False
        dgridPagos.Columns("CODMONEDA").Visible = False
        dgridPagos.Columns("ZCAJA").Visible = False
        dgridPagos.Columns(2).DefaultCellStyle.Format = "t"
    End Sub

    Public Sub Vaciar()
        Me.txtdescripcion.Text = ""
        Me.txtImporte.Text = ""
        Me.txtdescripcion.Focus()
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged

        CargarDatos()

        If Not Me.dtFecha.Value.ToShortDateString = Date.Now.ToShortDateString Then
            Me.btnBorrar.Enabled = False
            Me.btnAgregar.Enabled = False
        Else
            Me.btnBorrar.Enabled = True
            Me.btnAgregar.Enabled = True
        End If

    End Sub

    Private Sub frmPagos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtdescripcion.Text <> "" And txtImporte.Text <> "" Then
            Dim monedaP As Moneda = DirectCast(cboxMoneda.SelectedItem, Moneda)

            GesCajas.getInstance.AgregarPago(monedaP.Codigo, txtImporte.Text, monedaP.Coeficiente, txtdescripcion.Text)
            CargarDatos()

            Vaciar()
            coma = False

        Else
            MsgBox("Complete los datos para agregar pagos", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtImporte_TextChanged(sender As Object, e As EventArgs) Handles txtImporte.TextChanged
        If Me.txtImporte.Text.Contains(".") Then
            coma = True
        Else
            coma = False
        End If
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress

        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If

        If (e.KeyChar = "." And coma) Then
            e.Handled = True
        End If
        If txtImporte.Text.Length = 0 And e.KeyChar = "-" Then
            e.Handled = False
        End If
        If e.KeyChar = Convert.ToChar(13) Then
            If txtImporte.Text <> "" And txtdescripcion.Text <> "" Then
                Dim monedaP As Moneda = DirectCast(cboxMoneda.SelectedItem, Moneda)

                GesCajas.getInstance.AgregarPago(monedaP.Codigo, txtImporte.Text, monedaP.Coeficiente, txtdescripcion.Text)
                CargarDatos()

                Vaciar()
                coma = False

            Else
                MsgBox("Hay que completar datos", MsgBoxStyle.Critical)

            End If
        End If

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If dgridPagos.Rows.Count > 0 Then


            If dgridPagos.Rows.Count > 1 Then

                If (dgridPagos.Item("ZCAJA", dgridPagos.CurrentRow.Index).Value) <> 0 Then
                    MsgBox("No se puede eliminar un pago ya asociado a un Cierre de Caja", MsgBoxStyle.Information)

                Else

                    GesCajas.getInstance.EliminarPago(dgridPagos.Item("NUMERO", dgridPagos.CurrentRow.Index).Value)
                    CargarDatos()

                    Vaciar()
                    coma = False
                End If
            Else

                GesCajas.getInstance.EliminarPago(dgridPagos.Item("NUMERO", 0).Value)
                CargarDatos()

                Vaciar()
                coma = False

            End If

        End If
    End Sub
End Class