Imports JJ.Gestoras
Imports JJ.Entidades
Imports JJ.Reportes

Public Class frmVerFacturas

    Private mListaDocumentos As List(Of Object)
    Private mLisVendedores As List(Of Object)
    Private xobjFacturaSeleccionada As VentaContado
    Private Sub frmVerFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub

    Private Sub frmVerFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mLisVendedores = GesVendedores.getInstance.getListaVendedores()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        mListaDocumentos = GesDocumentos.getInstance.getListaVentaContado(dtpIni.Value.ToString("dd/MM/yyyy"), dtpFin.Value.ToString("dd/MM/yyyy"))
        dgridEncabezado.DataSource = MostrarEncabezado()
    End Sub

    Public Function MostrarEncabezado() As DataTable
        Dim tTable As New DataTable
        Dim ColA As DataColumn = tTable.Columns.Add("SERIE", Type.GetType("System.String"))
        Dim ColN As DataColumn = tTable.Columns.Add("NUMERO", Type.GetType("System.String"))
        Dim ColV As DataColumn = tTable.Columns.Add("VENDEDOR", Type.GetType("System.String"))



        For Each objV As VentaContado In mListaDocumentos
            Dim objf As DataRow = tTable.NewRow()
            objf.Item("SERIE") = objV.Serie
            objf.Item("Numero") = objV.Numero
            For Each objVendedor As Vendedor In mLisVendedores
                If objVendedor.Codigo = objV.Vendedor Then
                    objf.Item("VENDEDOR") = objVendedor.Nombre
                End If
            Next

            tTable.Rows.Add(objf)
        Next

        Return tTable
    End Function

    Public Function MostrarLineas(xobjE As VentaContado) As DataTable
        Dim tTable As New DataTable

        Dim ColRef As DataColumn = tTable.Columns.Add("REFERENCIA", Type.GetType("System.String"))
        Dim ColDes As DataColumn = tTable.Columns.Add("DESCRIPCION", Type.GetType("System.String"))
        Dim ColCan As DataColumn = tTable.Columns.Add("CANTIDAD", Type.GetType("System.Decimal"))
        Dim COLDTO As DataColumn = tTable.Columns.Add("DTO", Type.GetType("System.Decimal"))
        Dim colpreciofin As DataColumn = tTable.Columns.Add("PRECIO FINAL", Type.GetType("System.Decimal"))

        If Not (xobjE.Lineas Is Nothing) Then


            For Each xobjL As VentaLin In xobjE.Lineas


                Dim objf As DataRow = tTable.NewRow()
                objf.Item("REFERENCIA") = xobjL.Articulo.Referencia
                objf.Item("DESCRIPCION") = xobjL.Descripcion
                objf.Item("CANTIDAD") = xobjL.Cantidad
                objf.Item("DTO") = xobjL.Descuento
                objf.Item("PRECIO FINAL") = xobjL.Preciofacturado

                tTable.Rows.Add(objf)


            Next
        End If
        Return tTable

    End Function



    Private Sub dgridEncabezado_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgridEncabezado.CellEnter
        Dim XSERIE As String = dgridEncabezado.Item("SERIE", e.RowIndex).Value
        Dim xnumero As String = dgridEncabezado.Item("NUMERO", e.RowIndex).Value
        For Each objV As VentaContado In mListaDocumentos
            If objV.Serie = XSERIE And objV.Numero = xnumero Then
                Restaurar(objV)
                xobjFacturaSeleccionada = objV
                Me.dgridlineas.DataSource = MostrarLineas(objV)
                txtDetalle.Text = objV.Detalle
                txtNombre.Text = objV.Cliente.Nombre
                txtDireccion.Text = objV.Cliente.Direccion
            End If
        Next

    End Sub

    Private Sub btnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click
        If dgridEncabezado.RowCount > 0 Then

            Try


                GestionReporte.FacturaContado(xobjFacturaSeleccionada, xobjFacturaSeleccionada.Cotizacion)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Public Sub Restaurar(xobj As VentaContado)
        xobj.Detalle = xobj.Detalle.Replace("\n", vbCrLf)
        xobj.Env_Direccion = xobj.Env_Direccion.Replace("\n", vbCrLf)
        xobj.Env_Nombre = xobj.Env_Nombre.Replace("\n", vbCrLf)
        xobj.Env_observaciones = xobj.Env_observaciones.Replace("\n", vbCrLf)

    End Sub

End Class