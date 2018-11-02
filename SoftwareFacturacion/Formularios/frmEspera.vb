Imports JJ.Gestoras
Imports JJ.Entidades
Public Class frmEspera

    Private mListaDocumentos As List(Of Object)

    Private Sub frmEspera_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmEspera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mListaDocumentos = GesDocumentos.getInstance.getListaEspera()
        Me.dgridCabecera.DataSource = MostrarEncabezado()
    End Sub

    Public Function MostrarEncabezado() As DataTable
        Dim tTable As New DataTable
        Dim ColA As DataColumn = tTable.Columns.Add("NUMERO", Type.GetType("System.Int32"))
        Dim ColV As DataColumn = tTable.Columns.Add("VENDEDOR", Type.GetType("System.String"))


        Dim COLC As DataColumn = tTable.Columns.Add("CLIENTE", Type.GetType("System.String"))
        Dim COLTV As DataColumn = tTable.Columns.Add("TIPOVENTA", Type.GetType("System.String"))

        For Each objE As Espera In mListaDocumentos
            Dim objf As DataRow = tTable.NewRow()
            objf.Item("NUMERO") = objE.Numero
            objf.Item("VENDEDOR") = objE.ObjVendedor.Nombre
            objf.Item("CLIENTE") = objE.ObjCliente.Nombre & " " & objE.ObjCliente.Apellido
            objf.Item("TIPOVENTA") = objE.Tipo


            tTable.Rows.Add(objf)
        Next

        Return tTable
    End Function

    Public Function ObtenerEsperabyIdEspera(xcodigo As Integer) As Espera
        For Each E As Espera In mListaDocumentos
            If E.Numero = xcodigo Then
                Return E
            End If
        Next
        Return Nothing
    End Function

    Public Function MostrarLineas(xobjE As Espera) As DataTable
        Dim tTable As New DataTable

        Dim ColRef As DataColumn = tTable.Columns.Add("REFERENCIA", Type.GetType("System.String"))
        Dim ColDes As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))
        Dim ColCan As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.Decimal"))

        If Not (xobjE.Lineas Is Nothing) Then


            For Each xobjL As Esperalin In xobjE.Lineas

                'If MyBase.Moneda.Id = objl.Articulo.MONEDA.Id Then
                Dim objf As DataRow = tTable.NewRow()
                objf.Item("REFERENCIA") = xobjL.CodArticulo
                objf.Item("DESCRIPCION") = xobjL.Descripcion
                objf.Item("CANTIDAD") = xobjL.Cantidad

                tTable.Rows.Add(objf)


            Next
        End If
        Return tTable

    End Function

    Private Sub dgridCabecera_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgridCabecera.CellContentClick

    End Sub

    Private Sub dgridCabecera_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgridCabecera.CellEnter
        Dim objE As Espera = ObtenerEsperabyIdEspera(dgridCabecera.Item("NUMERO", e.RowIndex).Value)
        Me.dgridLineas.DataSource = MostrarLineas(objE)
        txtAdenda.Text = objE.Adenda
        txtImporteTotal.Text = objE.PrecioFinal

    End Sub
End Class