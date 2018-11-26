<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.dgridLineas = New System.Windows.Forms.DataGridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnDescuentoTotal = New System.Windows.Forms.Button()
        Me.btnDescuentoLinea = New System.Windows.Forms.Button()
        Me.btnCierre = New System.Windows.Forms.Button()
        Me.btnPagos = New System.Windows.Forms.Button()
        Me.btnBorrarLinea = New System.Windows.Forms.Button()
        Me.btnDevolucion = New System.Windows.Forms.Button()
        Me.btnEspera = New System.Windows.Forms.Button()
        Me.btnRecuperar = New System.Windows.Forms.Button()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtImporteTotalConIva = New System.Windows.Forms.TextBox()
        Me.txtImporteDescuento = New System.Windows.Forms.TextBox()
        Me.txtImporteIva = New System.Windows.Forms.TextBox()
        Me.txtTotalSinIva = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtAdenda = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cboxMoneda = New System.Windows.Forms.ComboBox()
        Me.cboxTarifa = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtTipoVta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.dgridLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1153, 639)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel9)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 167)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1153, 472)
        Me.Panel3.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.dgridLineas)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1153, 253)
        Me.Panel9.TabIndex = 1
        '
        'dgridLineas
        '
        Me.dgridLineas.AllowUserToAddRows = False
        Me.dgridLineas.AllowUserToDeleteRows = False
        Me.dgridLineas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgridLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgridLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgridLineas.Location = New System.Drawing.Point(0, 0)
        Me.dgridLineas.Name = "dgridLineas"
        Me.dgridLineas.RowHeadersVisible = False
        Me.dgridLineas.RowTemplate.Height = 28
        Me.dgridLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgridLineas.Size = New System.Drawing.Size(1153, 253)
        Me.dgridLineas.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel11)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 253)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1153, 219)
        Me.Panel8.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Panel13)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 58)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1153, 161)
        Me.Panel11.TabIndex = 1
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.btnReimprimir)
        Me.Panel13.Controls.Add(Me.btnSalir)
        Me.Panel13.Controls.Add(Me.btnDescuentoTotal)
        Me.Panel13.Controls.Add(Me.btnDescuentoLinea)
        Me.Panel13.Controls.Add(Me.btnCierre)
        Me.Panel13.Controls.Add(Me.btnPagos)
        Me.Panel13.Controls.Add(Me.btnBorrarLinea)
        Me.Panel13.Controls.Add(Me.btnDevolucion)
        Me.Panel13.Controls.Add(Me.btnEspera)
        Me.Panel13.Controls.Add(Me.btnRecuperar)
        Me.Panel13.Controls.Add(Me.btnFacturar)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(842, 161)
        Me.Panel13.TabIndex = 1
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Location = New System.Drawing.Point(854, 16)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(142, 55)
        Me.btnReimprimir.TabIndex = 10
        Me.btnReimprimir.Text = "Reimpresion"
        Me.btnReimprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(604, 82)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(142, 55)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnDescuentoTotal
        '
        Me.btnDescuentoTotal.Location = New System.Drawing.Point(456, 82)
        Me.btnDescuentoTotal.Name = "btnDescuentoTotal"
        Me.btnDescuentoTotal.Size = New System.Drawing.Size(142, 55)
        Me.btnDescuentoTotal.TabIndex = 8
        Me.btnDescuentoTotal.Text = "Dto. Total"
        Me.btnDescuentoTotal.UseVisualStyleBackColor = True
        '
        'btnDescuentoLinea
        '
        Me.btnDescuentoLinea.Location = New System.Drawing.Point(308, 82)
        Me.btnDescuentoLinea.Name = "btnDescuentoLinea"
        Me.btnDescuentoLinea.Size = New System.Drawing.Size(142, 55)
        Me.btnDescuentoLinea.TabIndex = 7
        Me.btnDescuentoLinea.Text = "Dto. Linea"
        Me.btnDescuentoLinea.UseVisualStyleBackColor = True
        '
        'btnCierre
        '
        Me.btnCierre.Location = New System.Drawing.Point(160, 82)
        Me.btnCierre.Name = "btnCierre"
        Me.btnCierre.Size = New System.Drawing.Size(142, 55)
        Me.btnCierre.TabIndex = 6
        Me.btnCierre.Text = "Cierre"
        Me.btnCierre.UseVisualStyleBackColor = True
        '
        'btnPagos
        '
        Me.btnPagos.Location = New System.Drawing.Point(12, 82)
        Me.btnPagos.Name = "btnPagos"
        Me.btnPagos.Size = New System.Drawing.Size(142, 55)
        Me.btnPagos.TabIndex = 5
        Me.btnPagos.Text = "Pagos"
        Me.btnPagos.UseVisualStyleBackColor = True
        '
        'btnBorrarLinea
        '
        Me.btnBorrarLinea.Location = New System.Drawing.Point(456, 16)
        Me.btnBorrarLinea.Name = "btnBorrarLinea"
        Me.btnBorrarLinea.Size = New System.Drawing.Size(142, 55)
        Me.btnBorrarLinea.TabIndex = 4
        Me.btnBorrarLinea.Text = "Borrar Linea"
        Me.btnBorrarLinea.UseVisualStyleBackColor = True
        '
        'btnDevolucion
        '
        Me.btnDevolucion.Location = New System.Drawing.Point(604, 16)
        Me.btnDevolucion.Name = "btnDevolucion"
        Me.btnDevolucion.Size = New System.Drawing.Size(142, 55)
        Me.btnDevolucion.TabIndex = 3
        Me.btnDevolucion.Text = "Devolucion"
        Me.btnDevolucion.UseVisualStyleBackColor = True
        '
        'btnEspera
        '
        Me.btnEspera.Location = New System.Drawing.Point(308, 15)
        Me.btnEspera.Name = "btnEspera"
        Me.btnEspera.Size = New System.Drawing.Size(142, 55)
        Me.btnEspera.TabIndex = 2
        Me.btnEspera.Text = "En Espera"
        Me.btnEspera.UseVisualStyleBackColor = True
        '
        'btnRecuperar
        '
        Me.btnRecuperar.Location = New System.Drawing.Point(160, 16)
        Me.btnRecuperar.Name = "btnRecuperar"
        Me.btnRecuperar.Size = New System.Drawing.Size(142, 55)
        Me.btnRecuperar.TabIndex = 1
        Me.btnRecuperar.Text = "Recuperar"
        Me.btnRecuperar.UseVisualStyleBackColor = True
        '
        'btnFacturar
        '
        Me.btnFacturar.Location = New System.Drawing.Point(12, 16)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(142, 55)
        Me.btnFacturar.TabIndex = 0
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.Label18)
        Me.Panel12.Controls.Add(Me.Label17)
        Me.Panel12.Controls.Add(Me.Label16)
        Me.Panel12.Controls.Add(Me.Label15)
        Me.Panel12.Controls.Add(Me.txtImporteTotalConIva)
        Me.Panel12.Controls.Add(Me.txtImporteDescuento)
        Me.Panel12.Controls.Add(Me.txtImporteIva)
        Me.Panel12.Controls.Add(Me.txtTotalSinIva)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(842, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(311, 161)
        Me.Panel12.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 123)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 22)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Importe Total"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(35, 82)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 22)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Descuento"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(99, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 22)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "IVA"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 22)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Total Sin IVA"
        '
        'txtImporteTotalConIva
        '
        Me.txtImporteTotalConIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteTotalConIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteTotalConIva.Location = New System.Drawing.Point(149, 118)
        Me.txtImporteTotalConIva.Name = "txtImporteTotalConIva"
        Me.txtImporteTotalConIva.ReadOnly = True
        Me.txtImporteTotalConIva.Size = New System.Drawing.Size(154, 30)
        Me.txtImporteTotalConIva.TabIndex = 3
        Me.txtImporteTotalConIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteDescuento
        '
        Me.txtImporteDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteDescuento.Location = New System.Drawing.Point(149, 80)
        Me.txtImporteDescuento.Name = "txtImporteDescuento"
        Me.txtImporteDescuento.ReadOnly = True
        Me.txtImporteDescuento.Size = New System.Drawing.Size(154, 30)
        Me.txtImporteDescuento.TabIndex = 2
        Me.txtImporteDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteIva
        '
        Me.txtImporteIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteIva.Location = New System.Drawing.Point(149, 44)
        Me.txtImporteIva.Name = "txtImporteIva"
        Me.txtImporteIva.ReadOnly = True
        Me.txtImporteIva.Size = New System.Drawing.Size(154, 30)
        Me.txtImporteIva.TabIndex = 1
        Me.txtImporteIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalSinIva
        '
        Me.txtTotalSinIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalSinIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSinIva.Location = New System.Drawing.Point(149, 10)
        Me.txtTotalSinIva.Name = "txtTotalSinIva"
        Me.txtTotalSinIva.ReadOnly = True
        Me.txtTotalSinIva.Size = New System.Drawing.Size(154, 30)
        Me.txtTotalSinIva.TabIndex = 0
        Me.txtTotalSinIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.txtAdenda)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1153, 58)
        Me.Panel10.TabIndex = 0
        '
        'txtAdenda
        '
        Me.txtAdenda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdenda.Location = New System.Drawing.Point(0, 0)
        Me.txtAdenda.Multiline = True
        Me.txtAdenda.Name = "txtAdenda"
        Me.txtAdenda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdenda.Size = New System.Drawing.Size(1153, 58)
        Me.txtAdenda.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1153, 167)
        Me.Panel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cboxMoneda)
        Me.Panel5.Controls.Add(Me.cboxTarifa)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(407, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(746, 167)
        Me.Panel5.TabIndex = 10
        '
        'cboxMoneda
        '
        Me.cboxMoneda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxMoneda.FormattingEnabled = True
        Me.cboxMoneda.Location = New System.Drawing.Point(249, 111)
        Me.cboxMoneda.Name = "cboxMoneda"
        Me.cboxMoneda.Size = New System.Drawing.Size(167, 28)
        Me.cboxMoneda.TabIndex = 8
        '
        'cboxTarifa
        '
        Me.cboxTarifa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxTarifa.FormattingEnabled = True
        Me.cboxTarifa.Location = New System.Drawing.Point(249, 43)
        Me.cboxTarifa.Name = "cboxTarifa"
        Me.cboxTarifa.Size = New System.Drawing.Size(167, 28)
        Me.cboxTarifa.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(287, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 20)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "MONEDA"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(289, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "TARIFA"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label11)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(447, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(299, 167)
        Me.Panel7.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(105, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 25)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 25)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Cajero:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(216, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 25)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(194, 25)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Cotizacion del Día:"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.txtTipoVta)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(228, 167)
        Me.Panel6.TabIndex = 2
        '
        'txtTipoVta
        '
        Me.txtTipoVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoVta.Location = New System.Drawing.Point(12, 118)
        Me.txtTipoVta.Name = "txtTipoVta"
        Me.txtTipoVta.ReadOnly = True
        Me.txtTipoVta.Size = New System.Drawing.Size(203, 26)
        Me.txtTipoVta.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(45, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(129, 20)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "TIPO DE VENTA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "VENDEDOR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(60, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 25)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Jose Curti"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txtTelefono)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtDireccion)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtNombre)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.txtDocumento)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(407, 167)
        Me.Panel4.TabIndex = 9
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(106, 130)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(180, 26)
        Me.txtTelefono.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(137, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Personas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Direccion"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(106, 98)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(271, 26)
        Me.txtDireccion.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Telefono"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(106, 66)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(271, 26)
        Me.txtNombre.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Documento"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(106, 34)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(180, 26)
        Me.txtDocumento.TabIndex = 4
        '
        'frmPrincipal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1177, 663)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmPrincipal"
        Me.Text = "Facturacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.dgridLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtDocumento As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cboxMoneda As ComboBox
    Friend WithEvents cboxTarifa As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents dgridLineas As DataGridView
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtTipoVta As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtImporteTotalConIva As TextBox
    Friend WithEvents txtImporteDescuento As TextBox
    Friend WithEvents txtImporteIva As TextBox
    Friend WithEvents txtTotalSinIva As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtAdenda As TextBox
    Friend WithEvents btnReimprimir As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnDescuentoTotal As Button
    Friend WithEvents btnDescuentoLinea As Button
    Friend WithEvents btnCierre As Button
    Friend WithEvents btnPagos As Button
    Friend WithEvents btnBorrarLinea As Button
    Friend WithEvents btnDevolucion As Button
    Friend WithEvents btnEspera As Button
    Friend WithEvents btnRecuperar As Button
    Friend WithEvents btnFacturar As Button
End Class
