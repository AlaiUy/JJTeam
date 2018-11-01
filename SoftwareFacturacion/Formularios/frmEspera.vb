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
        Dim ColA As DataColumn = tTable.Columns.Add("IDESPERA", Type.GetType("System.Int32"))
        Dim ColV As DataColumn = tTable.Columns.Add("VENDEDOR", Type.GetType("System.String"))
        'Dim ColS As DataColumn = tTable.Columns.Add("SERIE", Type.GetType("System.String"))
        'Dim COLF As DataColumn = tTable.Columns.Add("FECHA", Type.GetType("System.String"))

        Dim COLC As DataColumn = tTable.Columns.Add("CLIENTE", Type.GetType("System.String"))
        Dim COLTV As DataColumn = tTable.Columns.Add("TIPOVENTA", Type.GetType("System.String"))

        For Each objE As Espera In mListaDocumentos
            Dim objf As DataRow = tTable.NewRow()
            objf.Item("IDESPERA") = objE.Numero
            'objf.Item("SERIE") = _FacturasPendientes(id).Serie
            '   objf.Item("VENDEDOR") = objE.ObjVendedor.Nombre
            ' objf.Item("FECHA") = Format(objl.Fecha, "dd/MM/yyyy")

            objf.Item("CLIENTE") = objE.ObjCliente.Nombre




            objf.Item("TIPOVENTA") = objE.Tipo


            tTable.Rows.Add(objf)
        Next

        Return tTable
    End Function

End Class