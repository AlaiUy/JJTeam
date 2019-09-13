
Imports JJ.Gestoras
Imports JJ.Entidades

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
            lblCotrizacion.Text = GesPrecios.getInstance().getCotizacion()
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

                'ElseIf (TypeOf objE Is EsperaCredito) Then
                '    Me.txtTipoVta.Text = "CREDITO"


            End If

            Me.txtNombre.Text = objE.NombreCLiente

            Me.txtTotalSinIva.Text = objE.ImporteTotalSinIva
            Me.txtImporteIva.Text = objE.ImporteIva
            Me.txtImporteDescuento.Text = objE.ImporteDescuento
            Me.txtImporteTotalConIva.Text = objE.ImporteTotal
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

        Dim ColA As DataColumn = tTable.Columns.Add("CODARTICULO", Type.GetType("System.Int32"))

        Dim ColD As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))

        Dim COLC As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.String"))

        Dim COLPv As DataColumn = tTable.Columns.Add("P/UNITARIO C/IVA", Type.GetType("System.String"))

        Dim COLDesc As DataColumn = tTable.Columns.Add("DESCUENTO", Type.GetType("System.String"))

        Dim COLImporte As DataColumn = tTable.Columns.Add("IMPORTE DESCUENTO TOTAL", Type.GetType("System.String"))

        Dim COLTot As DataColumn = tTable.Columns.Add("PRECIO TOTAL", Type.GetType("System.String"))

        If Not (objE Is Nothing) Then

            For Each objL As Esperalin In Me.objE.Lineas
                Dim objf As DataRow = tTable.NewRow()

                objf.Item("CODARTICULO") = objL.Articulo.Referencia
                objf.Item("DESCRIPCION") = objL.Descripcion
                objf.Item("CANTIDAD") = objL.Cantidad
                objf.Item("P/UNITARIO C/IVA") = Redondear(objL.Precio)
                objf.Item("DESCUENTO") = objL.Descuento
                objf.Item("IMPORTE DESCUENTO TOTAL") = Redondear(objL.ImporteDescuentoTotal)
                objf.Item("PRECIO TOTAL") = Redondear(objL.TotalConDescuento)

                tTable.Rows.Add(objf)
            Next

        End If

        Me.dgridLineas.DataSource = tTable

    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click

        Dim objF As New VentaContado(objCC, Date.Today(), objC.getSerieByID(1).Serie, objC.Codigo, CType(Me.cboxMoneda.SelectedItem, Moneda).Codigo, objC.Z, objE.Codvendedor, CType(Me.cboxMoneda.SelectedItem, Moneda).Cotizacion, False)


        For Each objL As Esperalin In objE.Lineas

            objF.Lineas.Add(New VentaLin(objL.NumLinea, objL.Articulo, objL.Descripcion, objL.Cantidad, objL.Descuento))
            'objF.Lineas.Add(New VentaLin(objL.NumLinea, objL.ObjArticulo.CodArticulo, objL.ObjArticulo.Descripcion, objL.ObjArticulo.Precio(), objL.ObjArticulo.Iva, objL.Cantidad, objL.Descuento))

        Next


        Try
            GesDocumentos.getInstance.GesFacturar(objF, objF.Z)
            objE = Nothing
            MostrarEnTabla()
            MsgBox("Facturado", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


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

    End Sub

    Private Sub btnDescuentoTotal_Click(sender As Object, e As EventArgs) Handles btnDescuentoTotal.Click

    End Sub

    Private Sub btnDevolucion_Click(sender As Object, e As EventArgs) Handles btnDevolucion.Click
        Dim frmD As New frmAnulacion
        frmD.ShowDialog()

    End Sub
End Class