Imports JJ.Gestoras
Imports JJ.Entidades
Public Class frmEspera

    Private mListaDocumentos As List(Of Object)
    Private mLisVendedores As List(Of Object)
    Public objEspera As EsperaContado

    Private Sub frmEspera_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmEspera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mLisVendedores = GesVendedores.getInstance.getListaVendedores()
        mListaDocumentos = GesDocumentos.getInstance.getListaEspera()
        Me.dgridCabecera.DataSource = MostrarEncabezado()
        dgridCabecera.Columns("CLIENTECOD").Visible = False
        Me.dgridCabecera.Focus()
    End Sub



    Public Function MostrarEncabezado() As DataTable
        Dim tTable As New DataTable
        Dim ColA As DataColumn = tTable.Columns.Add("NUMERO", Type.GetType("System.Int32"))
        Dim ColV As DataColumn = tTable.Columns.Add("VENDEDOR", Type.GetType("System.String"))


        Dim COLC As DataColumn = tTable.Columns.Add("CLIENTECOD", Type.GetType("System.String"))
        Dim COLCN As DataColumn = tTable.Columns.Add("CLIENTE", Type.GetType("System.String"))


        For Each objE As EsperaContado In mListaDocumentos
            Dim objf As DataRow = tTable.NewRow()
            objf.Item("NUMERO") = objE.Numero
            For Each objV As Vendedor In mLisVendedores
                If objV.Codigo = objE.Codvendedor Then
                    objf.Item("VENDEDOR") = objV.Nombre
                End If
            Next

            objf.Item("CLIENTECOD") = objE.Codclientecontado
            objf.Item("CLIENTE") = objE.NombreCLiente



            tTable.Rows.Add(objf)
        Next

        Return tTable
    End Function

    Public Function ObtenerEsperabyIdEspera(xcodigo As Integer) As EsperaContado
        For Each E As EsperaContado In mListaDocumentos
            If E.Numero = xcodigo Then
                Return E
            End If
        Next
        Return Nothing
    End Function

    Public Function MostrarLineas(xobjE As EsperaContado) As DataTable
        Dim tTable As New DataTable

        Dim ColRef As DataColumn = tTable.Columns.Add("REFERENCIA", Type.GetType("System.String"))
        Dim ColDes As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))
        Dim ColCan As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.Decimal"))

        If Not (xobjE.Lineas Is Nothing) Then


            For Each xobjL As Esperalin In xobjE.Lineas

                'If MyBase.Moneda.Id = objl.Articulo.MONEDA.Id Then
                Dim objf As DataRow = tTable.NewRow()
                objf.Item("REFERENCIA") = xobjL.Articulo.Referencia
                objf.Item("DESCRIPCION") = xobjL.Descripcion
                objf.Item("CANTIDAD") = xobjL.Cantidad

                tTable.Rows.Add(objf)


            Next
        End If
        Return tTable

    End Function



    Private Sub dgridCabecera_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgridCabecera.CellEnter
        Dim objE As EsperaContado = ObtenerEsperabyIdEspera(dgridCabecera.Item("NUMERO", e.RowIndex).Value)
        Me.dgridLineas.DataSource = MostrarLineas(objE)
        txtAdenda.Text = objE.Adenda
        txtImporteTotal.Text = objE.ImporteTotal()
        Dim objCC As ClienteContado
        objCC = GesPersonas.getInstance.getClienteContadoByID(dgridCabecera.Item("ClienteCod", e.RowIndex).Value)
        txtNombre.Text = objCC.Nombre
        txtDireccion.Text = objCC.Direccion
        txtDocumento.Text = objCC.Documento


    End Sub

    Private Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        If Me.mListaDocumentos.Count > 0 Then
            If dgridCabecera.Rows.Count > 1 Then
                objEspera = ObtenerEsperabyIdEspera(dgridCabecera.Item("NUMERO", dgridCabecera.CurrentRow.Index).Value)
            Else
                objEspera = ObtenerEsperabyIdEspera(dgridCabecera.Item("NUMERO", 0).Value)
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If




    End Sub

    Private Sub dgridCabecera_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgridCabecera.CellContentClick

    End Sub

    Private Sub dgridCabecera_KeyDown(sender As Object, e As KeyEventArgs) Handles dgridCabecera.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgridCabecera.Rows.Count > 1 Then
                objEspera = ObtenerEsperabyIdEspera(dgridCabecera.Item("NUMERO", dgridCabecera.CurrentRow.Index).Value)
            Else
                objEspera = ObtenerEsperabyIdEspera(dgridCabecera.Item("NUMERO", 0).Value)
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class