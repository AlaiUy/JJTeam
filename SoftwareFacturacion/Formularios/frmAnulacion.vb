Imports JJ.Entidades
Imports JJ.Gestoras
Public Class frmAnulacion
    Private objF As VentaContado

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtSerie.Text <> "" And txtNumero.Text <> "" Then
            objF = GesDocumentos.getInstance().getVentaDocumento(txtNumero.Text, txtSerie.Text, 1)
            ''MsgBox(objF.Fecha)
            MostrarEnTabla()
            Me.txtNombre.Text = objF.Cliente.Nombre
            Me.txtTotal.Text = objF.Subtotal + objF.IvaTotal
        Else
            MsgBox("Ingrese los valores", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub frmAnulacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmAnulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtSerie.Text = "NH1C"
    End Sub

    Public Sub MostrarEnTabla()

        Dim tTable As New DataTable

        Dim colLin As DataColumn = tTable.Columns.Add("LINEA", Type.GetType("System.Int32"))


        Dim ColA As DataColumn = tTable.Columns.Add("CODARTICULO", Type.GetType("System.Int32"))

        Dim ColD As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

        Dim COLC As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.String"))

        Dim COLPv As DataColumn = tTable.Columns.Add("P/UNITARIO C/IVA", Type.GetType("System.String"))

        Dim COLDesc As DataColumn = tTable.Columns.Add("DESCUENTO", Type.GetType("System.String"))

        Dim COLImporte As DataColumn = tTable.Columns.Add("IMPORTE DESCUENTO TOTAL", Type.GetType("System.String"))

        Dim COLTot As DataColumn = tTable.Columns.Add("PRECIO TOTAL", Type.GetType("System.String"))

        Dim ColCant As DataColumn = tTable.Columns.Add("CANTIDAD A ANULAR", Type.GetType("System.Decimal"))

        If Not (objF Is Nothing) Then

            For Each objL As Linea In Me.objF.Lineas
                Dim objf As DataRow = tTable.NewRow()

                objf.Item("LINEA") = objL.NumLinea
                    objf.Item("CODARTICULO") = objL.Articulo.Referencia
                    objf.Item("DESCRIPCION") = objL.Descripcion
                    objf.Item("CANTIDAD") = objL.Cantidad
                    objf.Item("P/UNITARIO C/IVA") = Redondear(objL.Articulo.PrecioIva())
                    objf.Item("DESCUENTO") = objL.Descuento
                    objf.Item("IMPORTE DESCUENTO TOTAL") = Redondear(objL.ImporteDescuentoTotal())
                    objf.Item("PRECIO TOTAL") = Redondear(objL.TotalConDescuento())
                objf.Item("CANTIDAD A ANULAR") = 0



                tTable.Rows.Add(objf)
            Next

        End If

        Me.dgridfactura.DataSource = tTable
        If dgridfactura.RowCount > 0 Then
            dgridfactura.Columns("LINEA").Visible = False
            dgridfactura.Columns("CODARTICULO").ReadOnly = True
            dgridfactura.Columns("DESCRIPCION").ReadOnly = True
            dgridfactura.Columns("CANTIDAD").ReadOnly = True
            dgridfactura.Columns("P/UNITARIO C/IVA").ReadOnly = True
            dgridfactura.Columns("DESCUENTO").ReadOnly = True
            dgridfactura.Columns("IMPORTE DESCUENTO TOTAL").ReadOnly = True
            dgridfactura.Columns("PRECIO TOTAL").ReadOnly = True
            dgridfactura.Columns("CANTIDAD A ANULAR").ReadOnly = False
        End If

    End Sub

    Public Function Redondear(xvalor As Decimal) As Decimal
        Return Decimal.Round(xvalor, 2)
    End Function

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Dim objc As Caja = GesCajas.getInstance().Caja
        Dim objfd As New DevolucionContado(0, 0, objF.Caja, Date.Today, objF.Moneda, objc.Z, objF.Vendedor, objF.Cotizacion, 0, objF.Serie, objF.Numero, objF.Cliente)
        'Dim objF As New VentaContado(objCC, Date.Today(), objC.getSerieByID(1).Serie, objC.Codigo, CType(Me.cboxMoneda.SelectedItem, Moneda).Codigo, objC.Z, objE.Codvendedor, CType(Me.cboxMoneda.SelectedItem, Moneda).Cotizacion, False, objE.Numero)

        GesDocumentos.getInstance.GesFacturar(objfd, objfd.Z)

    End Sub

    Private Sub dgridfactura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgridfactura.CellContentClick

    End Sub

    Private Sub dgridfactura_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgridfactura.DataError
        MsgBox("Ingrese un dato correcto, tiene que ser numerico", MsgBoxStyle.Information, "-Informacion-")
        dgridfactura.Item((dgridfactura.Columns.Count - 1), e.RowIndex).Value = 0

    End Sub

    Private Sub dgridfactura_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgridfactura.CellValueChanged
        If dgridfactura.CurrentRow.Cells("CANTIDAD A ANULAR").Value > (dgridfactura.CurrentRow.Cells("CANTIDAD").Value) Or dgridfactura.CurrentRow.Cells("CANTIDAD A ANULAR").Value < 0 Then
            dgridfactura.CurrentRow.Cells("CANTIDAD A ANULAR").Value = dgridfactura.CurrentRow.Cells("CANTIDAD").Value
        End If
    End Sub
End Class