Imports JJ.Gestoras
Imports JJ.Entidades
Imports JJ.Mappers
Imports JJ.Reportes

Public Class frmCierre

    Private mCodVendedor As Integer

    Public Sub New(xCodvendedor)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        mCodVendedor = xCodvendedor
    End Sub

    Private Sub frmCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPesosInicial.Text = GesCajas.getInstance.GetSaldoDeclarado(1, 1)
        txtPesosInicial.Text = GesCajas.getInstance.GetSaldoDeclarado(2, 1)
    End Sub

    Private Sub frmCierre_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCierre_Click(sender As Object, e As EventArgs) Handles btnCierre.Click
        Try
            If txtPesosFinal.Text <> "" And txtFinalDolares.Text <> "" And txtPesosInicial.Text <> "" And txtDolaresInicial.Text <> "" Then
                GesCajas.getInstance.CierreCaja(txtPesosFinal.Text, txtFinalDolares.Text, txtPesosInicial.Text, txtDolaresInicial.Text, mCodVendedor)
                MsgBox("Cierre Realizado")
                Dim c As Caja
                c = GesCajas.getInstance().Caja
                c.Z = New MapperDocumentos().getNumeroZ(c.Codigo)
                Imprimir(c)
                Me.Close()
            Else
                MsgBox("Declare saldos Finales e Iniciales")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Imprimir(xc As Caja)

        Dim dtCierre As New DataTable

        With dtCierre

            .Columns.Add("CAJA")
            .Columns.Add("ARQUEO")
            .Columns.Add("CAJERO")
            .Columns.Add("FECHA")
            .Columns.Add("SALDOINI")
            .Columns.Add("VENTASCONTADO")
            .Columns.Add("DEVOLUCIONESCONTADO")
            .Columns.Add("PAGOS")
            .Columns.Add("TOTALCALCULADO")
            .Columns.Add("TOTALDECLARADO")
            .Columns.Add("DIFERENCIA")

        End With
        Dim sini As Decimal = GesCajas.getInstance().GetSaldoDeclarado(1, 2)
        Dim vc As Decimal = GesCajas.getInstance().GetTotalVentaContado(xc.Codigo, xc.Z - 1, 1)
        Dim dc As Decimal = GesCajas.getInstance().getDevolucionesContado(xc.Codigo, xc.Z - 1, 1)
        Dim pagos As Decimal = GesCajas.getInstance().getTotalPagos(xc.Codigo, xc.Z - 1, 1)
        Dim sdeclarado As Decimal = GesCajas.getInstance().GetSaldoDeclarado(1, 1)

        Dim totcalculado As Decimal = sini + vc - dc - pagos

        Dim LINEA As DataRow

        LINEA = dtCierre.NewRow()
        LINEA("CAJA") = xc.Codigo
        LINEA("ARQUEO") = xc.Z - 1
        LINEA("CAJERO") = GesVendedores.getInstance().getVendedorByID(mCodVendedor).Nombre
        LINEA("FECHA") = Date.Today
        LINEA("SALDOINI") = sini
        LINEA("VENTASCONTADO") = vc
        LINEA("DEVOLUCIONESCONTADO") = dc
        LINEA("PAGOS") = pagos
        LINEA("TOTALCALCULADO") = totcalculado
        LINEA("TOTALDECLARADO") = sdeclarado
        LINEA("DIFERENCIA") = sdeclarado - totcalculado

        dtCierre.Rows.Add(LINEA)

        GestionReporte.ImprimirCierre(dtCierre)

    End Sub
End Class