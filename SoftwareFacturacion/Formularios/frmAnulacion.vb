Imports JJ.Entidades
Imports JJ.Gestoras
Imports JJ.Reportes

Public Class frmAnulacion
    Private objF As VentaContado
    Private objEntrega As Entrega

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtSerie.Text <> "" And txtNumero.Text <> "" Then
            objF = GesDocumentos.getInstance().getVentaDocumento(txtNumero.Text, txtSerie.Text, 1)

            If objF Is Nothing Then
                MsgBox("No se encontro factura", MsgBoxStyle.Information)
            Else
                ''MsgBox(objF.Fecha)
                objEntrega = GesDocumentos.getInstance().getEntrega(txtNumero.Text, txtSerie.Text)

                MostrarEnTabla()
                Me.txtNombre.Text = objF.Cliente.Nombre
                Me.txtTotal.Text = Decimal.Round(objF.Subtotal + objF.IvaTotal)
                ControlDevolucion()
            End If

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
        Me.txtTotal.Text = 0
        Me.txtTotalAnulacion.Text = 0
    End Sub



    Public Sub ControlDevolucion()
        txtTotalAnulacion.Text = "0"
        Dim A As Decimal = "0"
        Dim B As Decimal
        For i As Integer = 0 To dgridfactura.Rows.Count - 1
            If IsDBNull(dgridfactura.Rows(i).Cells("CANTIDAD A ANULAR").Value) Then
                A = 0
            Else
                A = dgridfactura.Rows(i).Cells("CANTIDAD A ANULAR").Value
            End If

            B = objF.Lineas(i).TotalConDescuentoDevolucion(A)
            'B = Convert.ToString(DataGridView1.Rows(i).Cells("PRECIO UNITARIO CON IVA").Value * (1 + (DataGridView1.Rows(i).Cells("DTO").Value / 100))).Split(" ")
            'MsgBox(DataGridView1.Rows(i).Cells("PRECIO UNITARIO CON IVA").Value)
            txtTotalAnulacion.Text = Convert.ToDecimal(txtTotalAnulacion.Text) + B

        Next
        txtTotalAnulacion.Text = Decimal.Round(Convert.ToDecimal(txtTotalAnulacion.Text), 2)
    End Sub

    Public Sub MostrarEnTabla()

        Dim tTable As New DataTable

        Dim colLin As DataColumn = tTable.Columns.Add("LINEA", Type.GetType("System.Int32"))


        Dim ColA As DataColumn = tTable.Columns.Add("CODARTICULO", Type.GetType("System.String"))

        Dim ColD As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

        Dim COLC As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.String"))

        Dim COLCANANULADA As DataColumn = tTable.Columns.Add("CANTIDAD_ANULADA", Type.GetType("System.String"))

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
                objf.Item("CANTIDAD_ANULADA") = objEntrega.getLinea(objL.NumLinea).NotaC
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

    Public Function controllineas() As List(Of Linea)
        Dim control As Integer = 0
        Dim XLIST As New List(Of Linea)
        For Each a As Linea In objF.Lineas
            If a.CantANular > 0 Then
                a.NumLinea = control
                a.Cantidad = a.CantANular
                XLIST.Add(a)
                control += 1
            End If

        Next
        Return XLIST
    End Function

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Dim objc As Caja = GesCajas.getInstance().Caja

        Dim objfd As New DevolucionContado(0, objc.getSerieByID(3).Serie, objF.Caja, Date.Today, objF.Moneda, objc.Z, objF.Vendedor, objF.Cotizacion, 0, objF.Serie, objF.Numero, objF.Cliente)
        ControlCant()
        objfd.Lineas = controllineas()
        objfd.NumeroFacturaAnula = objF.Numero
        objfd.SerieFacturaAnula = objF.Serie

        'Dim objF As New VentaContado(objCC, Date.Today(), objC.getSerieByID(1).Serie, objC.Codigo, CType(Me.cboxMoneda.SelectedItem, Moneda).Codigo, objC.Z, objE.Codvendedor, CType(Me.cboxMoneda.SelectedItem, Moneda).Cotizacion, False, objE.Numero)
        Try
            GesDocumentos.getInstance.GesFacturar(objfd, objfd.Z)
            GestionReporte.DevolucionContado(objfd)
            objF = Nothing
            MostrarEnTabla()
            Me.txtNumero.Text = ""
            Me.txtTotal.Text = 0
            Me.txtTotalAnulacion.Text = 0
            Me.txtNombre.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Sub ControlCant()
        If dgridfactura.Rows.Count > 0 Then
            For Each Fila As DataGridViewRow In dgridfactura.Rows
                objF.Lineas(Fila.Index).CantANular = Fila.Cells("CANTIDAD A ANULAR").Value
            Next
        End If
    End Sub

    Private Sub dgridfactura_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgridfactura.DataError
        MsgBox("Ingrese un dato correcto, tiene que ser numerico", MsgBoxStyle.Information, "-Informacion-")
        dgridfactura.Item((dgridfactura.Columns.Count - 1), e.RowIndex).Value = 0
        ControlDevolucion()

    End Sub

    Private Sub dgridfactura_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgridfactura.CellValueChanged
        If dgridfactura.CurrentRow.Cells("CANTIDAD A ANULAR").Value > (dgridfactura.CurrentRow.Cells("CANTIDAD").Value) Or dgridfactura.CurrentRow.Cells("CANTIDAD A ANULAR").Value < 0 Then
            dgridfactura.CurrentRow.Cells("CANTIDAD A ANULAR").Value = dgridfactura.CurrentRow.Cells("CANTIDAD").Value
            Try
                objEntrega.Devolver(dgridfactura.CurrentRow.Index, dgridfactura.CurrentRow.Cells("CANTIDAD").Value)
            Catch ex As Exception

            End Try

        End If
        ControlDevolucion()
    End Sub


    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class