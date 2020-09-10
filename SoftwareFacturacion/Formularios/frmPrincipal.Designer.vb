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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.dgridLineas = New System.Windows.Forms.DataGridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtImporteTotalConIva = New System.Windows.Forms.TextBox()
        Me.txtImporteDescuento = New System.Windows.Forms.TextBox()
        Me.txtImporteIva = New System.Windows.Forms.TextBox()
        Me.txtTotalSinIva = New System.Windows.Forms.TextBox()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnConsultaCaja = New System.Windows.Forms.Button()
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
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtAdenda = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cboxMoneda = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblCajero = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCotrizacion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtTipoVta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblVendedor = New System.Windows.Forms.Label()
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
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1186, 396)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel9)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 111)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1186, 285)
        Me.Panel3.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.dgridLineas)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1186, 88)
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
        Me.dgridLineas.MultiSelect = False
        Me.dgridLineas.Name = "dgridLineas"
        Me.dgridLineas.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgridLineas.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgridLineas.RowHeadersVisible = False
        Me.dgridLineas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgridLineas.RowTemplate.Height = 28
        Me.dgridLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgridLineas.Size = New System.Drawing.Size(1186, 88)
        Me.dgridLineas.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel11)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 88)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1186, 197)
        Me.Panel8.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Panel13)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 58)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1186, 139)
        Me.Panel11.TabIndex = 1
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Label7)
        Me.Panel13.Controls.Add(Me.txtEfectivo)
        Me.Panel13.Controls.Add(Me.Label18)
        Me.Panel13.Controls.Add(Me.Label17)
        Me.Panel13.Controls.Add(Me.Label16)
        Me.Panel13.Controls.Add(Me.Label15)
        Me.Panel13.Controls.Add(Me.txtImporteTotalConIva)
        Me.Panel13.Controls.Add(Me.txtImporteDescuento)
        Me.Panel13.Controls.Add(Me.txtImporteIva)
        Me.Panel13.Controls.Add(Me.txtTotalSinIva)
        Me.Panel13.Controls.Add(Me.btnConsulta)
        Me.Panel13.Controls.Add(Me.btnConsultaCaja)
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
        Me.Panel13.Size = New System.Drawing.Size(1186, 139)
        Me.Panel13.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(912, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Total EFECTIVO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Visible = False
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(1027, 109)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.ReadOnly = True
        Me.txtEfectivo.Size = New System.Drawing.Size(154, 23)
        Me.txtEfectivo.TabIndex = 20
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEfectivo.Visible = False
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(928, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 15)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Importe Total"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(945, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 15)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Descuento"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(993, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 15)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "IVA"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(932, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 15)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Total Sin IVA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporteTotalConIva
        '
        Me.txtImporteTotalConIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteTotalConIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteTotalConIva.Location = New System.Drawing.Point(1027, 83)
        Me.txtImporteTotalConIva.Name = "txtImporteTotalConIva"
        Me.txtImporteTotalConIva.ReadOnly = True
        Me.txtImporteTotalConIva.Size = New System.Drawing.Size(154, 23)
        Me.txtImporteTotalConIva.TabIndex = 15
        Me.txtImporteTotalConIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteDescuento
        '
        Me.txtImporteDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteDescuento.Location = New System.Drawing.Point(1027, 57)
        Me.txtImporteDescuento.Name = "txtImporteDescuento"
        Me.txtImporteDescuento.ReadOnly = True
        Me.txtImporteDescuento.Size = New System.Drawing.Size(154, 23)
        Me.txtImporteDescuento.TabIndex = 14
        Me.txtImporteDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteIva
        '
        Me.txtImporteIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteIva.Location = New System.Drawing.Point(1027, 31)
        Me.txtImporteIva.Name = "txtImporteIva"
        Me.txtImporteIva.ReadOnly = True
        Me.txtImporteIva.Size = New System.Drawing.Size(154, 23)
        Me.txtImporteIva.TabIndex = 13
        Me.txtImporteIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalSinIva
        '
        Me.txtTotalSinIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalSinIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSinIva.Location = New System.Drawing.Point(1027, 5)
        Me.txtTotalSinIva.Name = "txtTotalSinIva"
        Me.txtTotalSinIva.ReadOnly = True
        Me.txtTotalSinIva.Size = New System.Drawing.Size(154, 23)
        Me.txtTotalSinIva.TabIndex = 12
        Me.txtTotalSinIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(743, 65)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(142, 55)
        Me.btnConsulta.TabIndex = 11
        Me.btnConsulta.Text = "Consultar Facturas"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnConsultaCaja
        '
        Me.btnConsultaCaja.Location = New System.Drawing.Point(743, 6)
        Me.btnConsultaCaja.Name = "btnConsultaCaja"
        Me.btnConsultaCaja.Size = New System.Drawing.Size(142, 55)
        Me.btnConsultaCaja.TabIndex = 10
        Me.btnConsultaCaja.Text = "Consulta Caja"
        Me.btnConsultaCaja.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(595, 65)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(142, 55)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnDescuentoTotal
        '
        Me.btnDescuentoTotal.Location = New System.Drawing.Point(447, 65)
        Me.btnDescuentoTotal.Name = "btnDescuentoTotal"
        Me.btnDescuentoTotal.Size = New System.Drawing.Size(142, 55)
        Me.btnDescuentoTotal.TabIndex = 8
        Me.btnDescuentoTotal.Text = "Dto. Total"
        Me.btnDescuentoTotal.UseVisualStyleBackColor = True
        '
        'btnDescuentoLinea
        '
        Me.btnDescuentoLinea.Location = New System.Drawing.Point(299, 65)
        Me.btnDescuentoLinea.Name = "btnDescuentoLinea"
        Me.btnDescuentoLinea.Size = New System.Drawing.Size(142, 55)
        Me.btnDescuentoLinea.TabIndex = 7
        Me.btnDescuentoLinea.Text = "Dto. Linea"
        Me.btnDescuentoLinea.UseVisualStyleBackColor = True
        '
        'btnCierre
        '
        Me.btnCierre.Location = New System.Drawing.Point(151, 65)
        Me.btnCierre.Name = "btnCierre"
        Me.btnCierre.Size = New System.Drawing.Size(142, 55)
        Me.btnCierre.TabIndex = 6
        Me.btnCierre.Text = "Cierre"
        Me.btnCierre.UseVisualStyleBackColor = True
        '
        'btnPagos
        '
        Me.btnPagos.Location = New System.Drawing.Point(3, 65)
        Me.btnPagos.Name = "btnPagos"
        Me.btnPagos.Size = New System.Drawing.Size(142, 55)
        Me.btnPagos.TabIndex = 5
        Me.btnPagos.Text = "Pagos"
        Me.btnPagos.UseVisualStyleBackColor = True
        '
        'btnBorrarLinea
        '
        Me.btnBorrarLinea.Location = New System.Drawing.Point(447, 6)
        Me.btnBorrarLinea.Name = "btnBorrarLinea"
        Me.btnBorrarLinea.Size = New System.Drawing.Size(142, 55)
        Me.btnBorrarLinea.TabIndex = 4
        Me.btnBorrarLinea.Text = "Borrar Linea"
        Me.btnBorrarLinea.UseVisualStyleBackColor = True
        '
        'btnDevolucion
        '
        Me.btnDevolucion.Location = New System.Drawing.Point(595, 6)
        Me.btnDevolucion.Name = "btnDevolucion"
        Me.btnDevolucion.Size = New System.Drawing.Size(142, 55)
        Me.btnDevolucion.TabIndex = 3
        Me.btnDevolucion.Text = "Devolucion"
        Me.btnDevolucion.UseVisualStyleBackColor = True
        '
        'btnEspera
        '
        Me.btnEspera.Location = New System.Drawing.Point(299, 6)
        Me.btnEspera.Name = "btnEspera"
        Me.btnEspera.Size = New System.Drawing.Size(142, 55)
        Me.btnEspera.TabIndex = 2
        Me.btnEspera.Text = "En Espera"
        Me.btnEspera.UseVisualStyleBackColor = True
        '
        'btnRecuperar
        '
        Me.btnRecuperar.Location = New System.Drawing.Point(151, 6)
        Me.btnRecuperar.Name = "btnRecuperar"
        Me.btnRecuperar.Size = New System.Drawing.Size(142, 55)
        Me.btnRecuperar.TabIndex = 1
        Me.btnRecuperar.Text = "Recuperar"
        Me.btnRecuperar.UseVisualStyleBackColor = True
        '
        'btnFacturar
        '
        Me.btnFacturar.Location = New System.Drawing.Point(3, 6)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(142, 55)
        Me.btnFacturar.TabIndex = 0
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.txtAdenda)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1186, 58)
        Me.Panel10.TabIndex = 0
        '
        'txtAdenda
        '
        Me.txtAdenda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdenda.Location = New System.Drawing.Point(0, 0)
        Me.txtAdenda.Multiline = True
        Me.txtAdenda.Name = "txtAdenda"
        Me.txtAdenda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdenda.Size = New System.Drawing.Size(1186, 58)
        Me.txtAdenda.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1186, 111)
        Me.Panel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cboxMoneda)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(362, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(824, 111)
        Me.Panel5.TabIndex = 10
        '
        'cboxMoneda
        '
        Me.cboxMoneda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxMoneda.Enabled = False
        Me.cboxMoneda.FormattingEnabled = True
        Me.cboxMoneda.Location = New System.Drawing.Point(207, 42)
        Me.cboxMoneda.Name = "cboxMoneda"
        Me.cboxMoneda.Size = New System.Drawing.Size(168, 21)
        Me.cboxMoneda.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(204, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "MONEDA"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblCajero)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.lblCotrizacion)
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(525, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(299, 111)
        Me.Panel7.TabIndex = 4
        '
        'lblCajero
        '
        Me.lblCajero.AutoSize = True
        Me.lblCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajero.Location = New System.Drawing.Point(105, 86)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(59, 17)
        Me.lblCajero.TabIndex = 6
        Me.lblCajero.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 17)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Cajero:"
        '
        'lblCotrizacion
        '
        Me.lblCotrizacion.AutoSize = True
        Me.lblCotrizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotrizacion.Location = New System.Drawing.Point(216, 26)
        Me.lblCotrizacion.Name = "lblCotrizacion"
        Me.lblCotrizacion.Size = New System.Drawing.Size(51, 17)
        Me.lblCotrizacion.TabIndex = 4
        Me.lblCotrizacion.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Cotizacion del Día:"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.txtTipoVta)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.lblVendedor)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(189, 111)
        Me.Panel6.TabIndex = 2
        '
        'txtTipoVta
        '
        Me.txtTipoVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoVta.Location = New System.Drawing.Point(18, 69)
        Me.txtTipoVta.Name = "txtTipoVta"
        Me.txtTipoVta.ReadOnly = True
        Me.txtTipoVta.Size = New System.Drawing.Size(159, 20)
        Me.txtTipoVta.TabIndex = 3
        Me.txtTipoVta.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(46, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "TIPO DE VENTA"
        Me.Label14.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "VENDEDOR"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.Location = New System.Drawing.Point(60, 48)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(0, 17)
        Me.lblVendedor.TabIndex = 1
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
        Me.Panel4.Size = New System.Drawing.Size(362, 111)
        Me.Panel4.TabIndex = 9
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(237, 24)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(112, 20)
        Me.txtTelefono.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(137, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Persona"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Direccion"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(78, 82)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(271, 20)
        Me.txtDireccion.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Telefono"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(78, 50)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(271, 20)
        Me.txtNombre.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Documento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(78, 24)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(97, 20)
        Me.txtDocumento.TabIndex = 4
        '
        'frmPrincipal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(1189, 398)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "frmPrincipal"
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.dgridLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
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
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblCajero As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblCotrizacion As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents lblVendedor As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents dgridLineas As DataGridView
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtTipoVta As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtAdenda As TextBox
    Friend WithEvents btnConsultaCaja As Button
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
    Friend WithEvents btnConsulta As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtImporteTotalConIva As TextBox
    Friend WithEvents txtImporteDescuento As TextBox
    Friend WithEvents txtImporteIva As TextBox
    Friend WithEvents txtTotalSinIva As TextBox
End Class
