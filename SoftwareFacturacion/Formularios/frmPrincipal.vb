
Imports JJ.Gestoras
Imports JJ.Entidades

Public Class frmPrincipal

    Private objE As Espera

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("Desea salir?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub cboxTarifa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.cboxTarifa.DataSource = GesPrecios.getInstance().getTarifas()
            Me.cboxMoneda.DataSource = GesPrecios.getInstance().getMonedas()
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

        If Not (objE Is Nothing) Then
            Me.txtAdenda.Text = objE.Adenda
            Me.txtDireccion.Text = objE.ObjCliente.Direccion & " " & objE.ObjCliente.DireccionNumero
            Me.txtDocumento.Text = objE.ObjCliente.Cedula
            Me.txtTelefono.Text = objE.ObjCliente.Telefono
            If objE.Tipo = 1 Then
                Me.txtTipoVta.Text = "CONTADO"
            Else
                Me.txtTipoVta.Text = "CREDITO"
            End If

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

                objf.Item("CODARTICULO") = objL.CodArticulo
                objf.Item("DESCRIPCION") = objL.Descripcion
                objf.Item("CANTIDAD") = objL.Cantidad
                objf.Item("P/UNITARIO C/IVA") = objL.PrecioUnitarioConIva
                objf.Item("DESCUENTO") = objL.Descuento
                objf.Item("IMPORTE DESCUENTO TOTAL") = objL.ImporteDescuento
                objf.Item("PRECIO TOTAL") = objL.PrecioTotalConDescuento

                tTable.Rows.Add(objf)
            Next

        End If

        Me.dgridLineas.DataSource = tTable

    End Sub

End Class