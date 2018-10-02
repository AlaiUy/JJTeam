Imports JJ.Entidades
Imports JJ.Gestoras
Imports JJ.Interfaces.Observer

Public Class frmNuevoArticulo
    Implements IObserver
    Private _Tarifas As List(Of Object)
    Private _Monedas As List(Of Object)
    Private _Departamentos As List(Of Object)
    Private _PreciosVenta As IList(Of Object)
    Private _Marcas As IList(Of Object)

    Private Sub btnAgregarPrecio_Click(sender As Object, e As EventArgs) Handles btnAgregarPrecio.Click
        Dim PV As PreciosVenta

        PV = New PreciosVenta(TryCast(cbTarifa.SelectedItem, Tarifa).Codigo, Convert.ToDecimal(txtPrecio.Text), Convert.ToDecimal(txtGanancia.Text), TryCast(cbMoneda.SelectedItem, Moneda).Codigo)
        If (IsNothing(_PreciosVenta)) Then
            _PreciosVenta = New List(Of Object)
        End If
        _PreciosVenta.Add(PV)
        DGPreciosVenta.DataSource = Mostrar()
    End Sub

    Private Sub frmNuevoArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _Tarifas = GesPrecios.getInstance().getTarifas()
            _Monedas = GesPrecios.getInstance().getMonedas()
            _Departamentos = GesArticulos.getInstance().getDepartamentos()
            _Marcas = GesArticulos.getInstance().getMarcas()
            Popular()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartamento.SelectedIndexChanged
        Popular()
    End Sub

    Private Sub Popular()
        Try
            cbTarifa.DataSource = _Tarifas
            cbMoneda.DataSource = _Monedas
            cbDepartamento.DataSource = _Departamentos
            If Not IsNothing(cbDepartamento.SelectedItem) Then
                cbSeccion.DataSource = TryCast(cbDepartamento.SelectedItem, Departamento).Secciones()
            End If
            cbMarca.DataSource = _Marcas
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        e.Handled = ValidarImportes(e.KeyChar, TryCast(sender, TextBox).Text, TryCast(sender, TextBox).SelectionLength, TryCast(sender, TextBox).SelectionStart, 2)
    End Sub

    Private Sub txtGanancia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGanancia.KeyPress
        e.Handled = ValidarImportes(e.KeyChar, TryCast(sender, TextBox).Text, TryCast(sender, TextBox).SelectionLength, TryCast(sender, TextBox).SelectionStart, 2)
    End Sub

    Public Function Mostrar() As DataTable
        If IsNothing(_PreciosVenta) Then
            Return Nothing
        End If

        If _PreciosVenta.Count < 1 Then
            Return Nothing
        End If

        Dim T As New DataTable("PreciosVenta")
        Dim ColCodTarifa As DataColumn = New DataColumn("CODTARIFA", Type.GetType("System.Int32"))
        Dim ColTarifa As DataColumn = New DataColumn("TARIFA", Type.GetType("System.String"))

        Dim ColCodMoneda As DataColumn = New DataColumn("CODMONEDA", Type.GetType("System.Int32"))
        Dim ColMoneda As DataColumn = New DataColumn("MONEDA", Type.GetType("System.String"))

        Dim ColPrecio As DataColumn = New DataColumn("PRECIO SIN GANANCIA", Type.GetType("System.Single"))
        Dim ColGanancia As DataColumn = New DataColumn("GANANCIA", Type.GetType("System.Single"))
        Dim ColPrecioFinal As DataColumn = New DataColumn("PRECIO FINAL", Type.GetType("System.Single"))

        T.Columns.Add(ColCodTarifa)
        T.Columns.Add(ColTarifa)
        T.Columns.Add(ColCodMoneda)
        T.Columns.Add(ColMoneda)
        T.Columns.Add(ColPrecio)
        T.Columns.Add(ColGanancia)
        T.Columns.Add(ColPrecioFinal)

        For Each PV As PreciosVenta In _PreciosVenta
            Dim Row As DataRow = T.NewRow()
            Row.Item("CODTARIFA") = PV.CodTarifa
            Row.Item("TARIFA") = _Tarifas.Find(Function(Tar As Tarifa) Tar.Codigo = PV.CodTarifa).Nombre
            Row.Item("CODMONEDA") = PV.CodMoneda
            Row.Item("MONEDA") = _Monedas.Find(Function(Mon As Moneda) Mon.Codigo = PV.CodMoneda).Nombre
            Row.Item("PRECIO SIN GANANCIA") = PV.PrecioBruto
            Row.Item("GANANCIA") = PV.Ganancia
            Row.Item("PRECIO FINAL") = PV.Precio()
            T.Rows.Add(Row)
        Next
        Return T
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim A = New Articulo()
        A.Activo = 1
        A.Codbarras = txtCodBarras.Text
        A.Codbarras1 = txtCodBarras1.Text
        A.Descripcion = txtDescripcion.Text
        A.Nombre = txtNombre.Text
        A.Referencia = txtReferencia.Text
        A.Coddepto = TryCast(cbDepartamento.SelectedItem, Departamento).Codigo
        A.Codmarca = TryCast(cbMarca.SelectedItem, Marca).Codigo
        A.Codseccion = TryCast(cbSeccion.SelectedItem, Seccion).Codigo
        A.Modelo = txtModelo.Text
        Try
            A.AddPreciosVenta(_PreciosVenta)
            GesArticulos.getInstance().AddArticulo(A)
            MsgBox("Agregado con exito")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAddMarca_Click(sender As Object, e As EventArgs) Handles btnAddMarca.Click
        Dim F As Form = New frmNuevaMarca(Me)
        F.Show()
    End Sub

    Public Overloads Sub Update(Obj As Object) Implements IObserver.Update
        If TypeOf Obj Is Marca Then
            _Marcas = GesArticulos.getInstance().getMarcas()
            Popular()
        End If
        If TypeOf Obj Is Departamento Then
            _Departamentos = GesArticulos.getInstance().getDepartamentos()
            Popular()
        End If
    End Sub

    Private Sub frmNuevoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnAddDepto_Click(sender As Object, e As EventArgs) Handles btnAddDepto.Click
        Dim F As Form = New frmDepartamentoNuevo(Me)
        F.Show()
    End Sub

    Private Sub btnAddSeccion_Click(sender As Object, e As EventArgs) Handles btnAddSeccion.Click

    End Sub
End Class