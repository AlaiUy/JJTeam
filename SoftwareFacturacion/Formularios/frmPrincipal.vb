
Imports JJ.Gestoras
Imports JJ.Entidades
Imports JJ.Reportes

Public Class frmPrincipal

    Private objE As EsperaContado
    Private objCC As ClienteContado
    Private mCajero As Vendedor
    Private objC As Caja

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("Desea salir?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub cboxTarifa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objC = GesCajas.getInstance().Caja
        Try

            Me.cboxMoneda.DataSource = GesPrecios.getInstance().getMonedas()
            mCajero = GesVendedores.getInstance().getVendedorByID(1)
            lblCotrizacion.Text = GesPrecios.getInstance().getCotizacion(2)
            MostrarEnTabla()
            CargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        Dim frmE As New frmEspera
        frmE.ShowDialog()
        If frmE.DialogResult = DialogResult.OK Then
            Me.objE = frmE.objEspera
            CargarDatos()
            MostrarEnTabla()
            With dgridLineas
                For Each ObjCol As DataGridViewColumn In .Columns
                    ObjCol.SortMode = DataGridViewColumnSortMode.Programmatic
                Next
            End With


        End If
    End Sub

    Public Sub CargarDatos()
        lblCajero.Text = mCajero.Nombre
        If Not (objE Is Nothing) Then
            Me.txtAdenda.Text = objE.Adenda
            ' Me.txtDireccion.Text = objE.ObjCliente.Direccion & " " & objE.ObjCliente.DireccionNumero

            '  Me.txtTelefono.Text = objE.ObjCliente.Telefono
            If TypeOf objE Is EsperaContado Then
                Me.txtTipoVta.Text = "CONTADO"
                objCC = GesPersonas.getInstance.getClienteContadoByID(objE.Codclientecontado)
                txtNombre.Text = objCC.Nombre
                txtDocumento.Text = objCC.Documento
                txtDireccion.Text = objCC.Direccion
                txtTelefono.Text = objCC.Telefono
                lblVendedor.Text = GesVendedores.getInstance.getVendedorByID(objE.Codvendedor).Nombre
                'ElseIf (TypeOf objE Is EsperaCredito) Then
                '    Me.txtTipoVta.Text = "CREDITO"
            End If

            Me.txtNombre.Text = objE.NombreCLiente
            Dim cot As Decimal = GesPrecios.getInstance.getCotizacion(2)
            Me.txtTotalSinIva.Text = objE.ImporteTotalSinIva(1, cot)
            Me.txtImporteIva.Text = objE.ImporteIva(1, cot)
            Me.txtImporteDescuento.Text = objE.ImporteDescuento(1, cot)
            Me.txtImporteTotalConIva.Text = objE.ImporteTotal(1, cot)
        Else
            Me.txtAdenda.Text = ""
            Me.txtDireccion.Text = ""
            Me.txtDocumento.Text = ""
            Me.txtTelefono.Text = ""

            Me.txtTipoVta.Text = ""
            objCC = Nothing

            Me.txtTotalSinIva.Text = 0
            Me.txtImporteIva.Text = 0
            Me.txtImporteDescuento.Text = 0
            Me.txtImporteTotalConIva.Text = 0

        End If


    End Sub

    Public Sub MostrarEnTabla()

        Dim tTable As New DataTable

        Dim colLin As DataColumn = tTable.Columns.Add("LINEA", Type.GetType("System.Int32"))


        Dim ColA As DataColumn = tTable.Columns.Add("CODARTICULO", Type.GetType("System.Int32"))

        Dim ColRef As DataColumn = tTable.Columns.Add("REFERENCIA", Type.GetType("System.String"))

        Dim ColD As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

        Dim COLC As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.String"))

        Dim COLPv As DataColumn = tTable.Columns.Add("P/UNITARIO C/IVA", Type.GetType("System.String"))


        Dim COLDesc As DataColumn = tTable.Columns.Add("DESCUENTO", Type.GetType("System.String"))

        Dim COLImporte As DataColumn = tTable.Columns.Add("IMPORTE DESCUENTO TOTAL", Type.GetType("System.String"))

        Dim COLTot As DataColumn = tTable.Columns.Add("PRECIO TOTAL", Type.GetType("System.String"))

        If Not (objE Is Nothing) Then

            For Each objL As Esperalin In Me.objE.Lineas
                Dim objf As DataRow = tTable.NewRow()
                objf.Item("LINEA") = objL.NumLinea
                objf.Item("CODARTICULO") = objL.Articulo.CodArticulo
                objf.Item("REFERENCIA") = objL.Articulo.Referencia

                objf.Item("DESCRIPCION") = objL.Descripcion
                objf.Item("CANTIDAD") = objL.Cantidad
                objf.Item("DESCUENTO") = objL.Descuento
                If objL.Articulo.CodMoneda = 1 Then
                    objf.Item("P/UNITARIO C/IVA") = Redondear(objL.Articulo.PrecioIva())
                    objf.Item("IMPORTE DESCUENTO TOTAL") = Redondear(objL.ImporteDescuentoTotal())
                    objf.Item("PRECIO TOTAL") = Redondear(objL.TotalConDescuento())
                Else
                    objf.Item("P/UNITARIO C/IVA") = Redondear(objL.Articulo.PrecioIva() * GesPrecios.getInstance.getCotizacion(2))
                    objf.Item("IMPORTE DESCUENTO TOTAL") = Redondear(objL.ImporteDescuentoTotal()) * GesPrecios.getInstance.getCotizacion(2)
                    objf.Item("PRECIO TOTAL") = Redondear(objL.TotalConDescuento()) * GesPrecios.getInstance.getCotizacion(2)
                End If


                tTable.Rows.Add(objf)
            Next

        End If

        Me.dgridLineas.DataSource = tTable
        dgridLineas.Columns("CODARTICULO").Visible = False
        If dgridLineas.RowCount > 0 Then
            dgridLineas.Columns("LINEA").Visible = False
        End If

    End Sub

    Public Sub Devolver(xobj As VentaContado)
        xobj.Detalle = xobj.Detalle.Replace(vbCrLf, "\n")
        xobj.Env_Direccion = xobj.Env_Direccion.Replace(vbCrLf, "\n")
        xobj.Env_Nombre = xobj.Env_Nombre.Replace(vbCrLf, "\n")
        xobj.Env_observaciones = xobj.Env_observaciones.Replace(vbCrLf, "\n")

    End Sub

    Public Sub Restaurar(xobj As VentaContado)
        xobj.Detalle = xobj.Detalle.Replace("\n", vbCrLf)
        xobj.Env_Direccion = xobj.Env_Direccion.Replace("\n", vbCrLf)
        xobj.Env_Nombre = xobj.Env_Nombre.Replace("\n", vbCrLf)
        xobj.Env_observaciones = xobj.Env_observaciones.Replace("\n", vbCrLf)

    End Sub



    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        If dgridLineas.RowCount > 0 Then


            Dim objF As New VentaContado(objCC, Date.Today(), objC.getSerieByID(1).Serie, objC.Codigo, CType(Me.cboxMoneda.SelectedItem, Moneda).Codigo, objC.Z, objE.Codvendedor, CType(Me.cboxMoneda.SelectedItem, Moneda).Cotizacion, False, objE.Numero)
            objF.Detalle = txtAdenda.Text
            objF.Env_Direccion = objE.DirEnvio
            Devolver(objF)


            For Each objL As Esperalin In objE.Lineas

                objF.Lineas.Add(New VentaLin(objL.NumLinea, objL.Articulo, objL.Descripcion, objL.Cantidad, objL.Descuento))
                'objF.Lineas.Add(New VentaLin(objL.NumLinea, objL.ObjArticulo.CodArticulo, objL.ObjArticulo.Descripcion, objL.ObjArticulo.Precio(), objL.ObjArticulo.Iva, objL.Cantidad, objL.Descuento))

            Next



            Try
                GesDocumentos.getInstance.GesFacturar(objF, objF.Z)
                Restaurar(objF)
                GestionReporte.FacturaContado(objF, GesPrecios.getInstance.getCotizacion(2))
                objE = Nothing
                MostrarEnTabla()
                CargarDatos()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No Hay Lineas para facturar", MsgBoxStyle.Information)
        End If



    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Dim frmP As New frmPagos
        frmP.ShowDialog()

    End Sub

    Private Sub txtTotalSinIva_TextChanged(sender As Object, e As EventArgs) Handles txtTotalSinIva.TextChanged

    End Sub

    Private Sub btnCierre_Click(sender As Object, e As EventArgs) Handles btnCierre.Click
        Dim frmCierre As New frmCierre(mCajero.Codigo)
        frmCierre.ShowDialog()
    End Sub

    Public Function Redondear(xvalor As Decimal) As Decimal
        Return Decimal.Round(xvalor, 2)
    End Function

    Private Sub cboxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxMoneda.SelectedIndexChanged

    End Sub

    Private Sub btnDescuentoLinea_Click(sender As Object, e As EventArgs) Handles btnDescuentoLinea.Click
        If dgridLineas.RowCount > 0 Then


            Dim lin As Integer = dgridLineas.CurrentRow.Index + 1

            Dim frmd As New frmDescuento
            frmd.ShowDialog()
            If frmd.DialogResult = DialogResult.OK Then
                For Each line As Linea In objE.Lineas
                    If line.NumLinea = lin Then
                        line.Descuento = frmd.xdescuento
                    End If
                Next
                CargarDatos()
                MostrarEnTabla()
            End If
        Else
            MsgBox("No hay lineas", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub btnDescuentoTotal_Click(sender As Object, e As EventArgs) Handles btnDescuentoTotal.Click
        If dgridLineas.RowCount > 0 Then


            Dim frmD As New frmDescuento
            frmD.ShowDialog()
            If frmD.DialogResult = DialogResult.OK Then
                AplicarDescuentoTotal(frmD.xdescuento)
                MostrarEnTabla()
                CargarDatos()
            End If
        Else
            MsgBox("No Hay Lineas", MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub AplicarDescuentoTotal(xdescuento)
        For Each obja As Esperalin In Me.objE.Lineas
            obja.Descuento = xdescuento
        Next
    End Sub

    Private Sub btnDevolucion_Click(sender As Object, e As EventArgs) Handles btnDevolucion.Click
        Dim frmD As New frmAnulacion
        frmD.ShowDialog()

    End Sub

    Private Sub btnBorrarLinea_Click(sender As Object, e As EventArgs) Handles btnBorrarLinea.Click
        If Me.dgridLineas.Rows.Count > 0 Then


            If dgridLineas.Rows.Count > 1 And Not (dgridLineas.CurrentRow Is Nothing) Then
                objE.EliminarLinea(dgridLineas.Item("LINEA", dgridLineas.CurrentRow.Index).Value - 1)
            Else
                objE.EliminarLinea(0)
            End If
            MostrarEnTabla()
            CargarDatos()

        End If
    End Sub

    Private Sub txtImporteTotalConIva_TextChanged(sender As Object, e As EventArgs) Handles txtImporteTotalConIva.TextChanged

    End Sub


    Private Sub txtImporteDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtImporteDescuento.TextChanged

    End Sub

    Private Sub dgridLineas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgridLineas.CellContentClick

    End Sub

    Private Sub dgridLineas_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgridLineas.ColumnHeaderMouseClick
        If dgridLineas.Columns(e.ColumnIndex).Name = "CANTIDAD" And Me.dgridLineas.Rows.Count > 0 Then
            Dim frmU As New frmUnidades()
            frmU.nombre("Unidades")
            frmU.ShowDialog()

            objE.Lineas(dgridLineas.Item("LINEA", dgridLineas.CurrentRow.Index).Value - 1).Cantidad = frmU.unidad

            CargarDatos()
            MostrarEnTabla()
        ElseIf dgridLineas.Columns(e.ColumnIndex).Name = "PRECIO TOTAL" And Me.dgridLineas.Rows.Count > 0 Then
            Dim frmU As New frmUnidades()
            frmU.nombre("PRECIO TOTAL")
            frmU.Text = "PRECIO TOTAL"
            frmU.ShowDialog()
            If frmU.unidad > 0 Then


                objE.Lineas(dgridLineas.Item("LINEA", dgridLineas.CurrentRow.Index).Value - 1).CalcularDescuentoPrecioFinal(frmU.unidad, GesPrecios.getInstance.getCotizacion(2))

                CargarDatos()
                MostrarEnTabla()
            End If

        End If



    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        Dim frmC As New frmVerFacturas
        frmC.ShowDialog()

    End Sub

    Private Sub frmPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("Desea cerrar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnConsultaCaja_Click(sender As Object, e As EventArgs) Handles btnConsultaCaja.Click
        Dim frmc As New frmConsulta
        frmc.ShowDialog()
    End Sub
End Class