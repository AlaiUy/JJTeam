<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain_Material
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.PanelBody_Top = New System.Windows.Forms.Panel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnDescuentoAll = New FontAwesome.Sharp.IconButton()
        Me.btnDescuentoLinea = New FontAwesome.Sharp.IconButton()
        Me.btnCierre = New FontAwesome.Sharp.IconButton()
        Me.btnPagos = New FontAwesome.Sharp.IconButton()
        Me.btnConsultacaja = New FontAwesome.Sharp.IconButton()
        Me.btnDevolucion = New FontAwesome.Sharp.IconButton()
        Me.btnBorrarLinea = New FontAwesome.Sharp.IconButton()
        Me.btnEspera = New FontAwesome.Sharp.IconButton()
        Me.btnRecuperar = New FontAwesome.Sharp.IconButton()
        Me.btnFacturar = New FontAwesome.Sharp.IconButton()
        Me.btnConsultaFacturas = New FontAwesome.Sharp.IconButton()
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
        Me.PanelBody.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHeader
        '
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(1195, 30)
        Me.PanelHeader.TabIndex = 0
        '
        'PanelBody
        '
        Me.PanelBody.Controls.Add(Me.PanelBody_Top)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 30)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1195, 733)
        Me.PanelBody.TabIndex = 1
        '
        'PanelBody_Top
        '
        Me.PanelBody_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBody_Top.Location = New System.Drawing.Point(0, 0)
        Me.PanelBody_Top.Name = "PanelBody_Top"
        Me.PanelBody_Top.Size = New System.Drawing.Size(1195, 44)
        Me.PanelBody_Top.TabIndex = 1
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.Label7)
        Me.PanelBottom.Controls.Add(Me.txtEfectivo)
        Me.PanelBottom.Controls.Add(Me.Label18)
        Me.PanelBottom.Controls.Add(Me.Label17)
        Me.PanelBottom.Controls.Add(Me.Label16)
        Me.PanelBottom.Controls.Add(Me.Label15)
        Me.PanelBottom.Controls.Add(Me.txtImporteTotalConIva)
        Me.PanelBottom.Controls.Add(Me.txtImporteDescuento)
        Me.PanelBottom.Controls.Add(Me.txtImporteIva)
        Me.PanelBottom.Controls.Add(Me.txtTotalSinIva)
        Me.PanelBottom.Controls.Add(Me.btnConsultaFacturas)
        Me.PanelBottom.Controls.Add(Me.btnDescuentoAll)
        Me.PanelBottom.Controls.Add(Me.btnDescuentoLinea)
        Me.PanelBottom.Controls.Add(Me.btnCierre)
        Me.PanelBottom.Controls.Add(Me.btnPagos)
        Me.PanelBottom.Controls.Add(Me.btnConsultacaja)
        Me.PanelBottom.Controls.Add(Me.btnDevolucion)
        Me.PanelBottom.Controls.Add(Me.btnBorrarLinea)
        Me.PanelBottom.Controls.Add(Me.btnEspera)
        Me.PanelBottom.Controls.Add(Me.btnRecuperar)
        Me.PanelBottom.Controls.Add(Me.btnFacturar)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 622)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1195, 141)
        Me.PanelBottom.TabIndex = 1
        '
        'btnDescuentoAll
        '
        Me.btnDescuentoAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDescuentoAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescuentoAll.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnDescuentoAll.IconChar = FontAwesome.Sharp.IconChar.Percentage
        Me.btnDescuentoAll.IconColor = System.Drawing.Color.Black
        Me.btnDescuentoAll.IconSize = 48
        Me.btnDescuentoAll.Location = New System.Drawing.Point(375, 81)
        Me.btnDescuentoAll.Name = "btnDescuentoAll"
        Me.btnDescuentoAll.Rotation = 0R
        Me.btnDescuentoAll.Size = New System.Drawing.Size(118, 55)
        Me.btnDescuentoAll.TabIndex = 34
        Me.btnDescuentoAll.Text = "DTO total"
        Me.btnDescuentoAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescuentoAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoAll.UseVisualStyleBackColor = True
        '
        'btnDescuentoLinea
        '
        Me.btnDescuentoLinea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDescuentoLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescuentoLinea.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnDescuentoLinea.IconChar = FontAwesome.Sharp.IconChar.Percentage
        Me.btnDescuentoLinea.IconColor = System.Drawing.Color.Black
        Me.btnDescuentoLinea.IconSize = 48
        Me.btnDescuentoLinea.Location = New System.Drawing.Point(254, 81)
        Me.btnDescuentoLinea.Name = "btnDescuentoLinea"
        Me.btnDescuentoLinea.Rotation = 0R
        Me.btnDescuentoLinea.Size = New System.Drawing.Size(118, 55)
        Me.btnDescuentoLinea.TabIndex = 33
        Me.btnDescuentoLinea.Text = "DTO Linea"
        Me.btnDescuentoLinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescuentoLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoLinea.UseVisualStyleBackColor = True
        '
        'btnCierre
        '
        Me.btnCierre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCierre.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnCierre.IconChar = FontAwesome.Sharp.IconChar.Key
        Me.btnCierre.IconColor = System.Drawing.Color.Black
        Me.btnCierre.IconSize = 48
        Me.btnCierre.Location = New System.Drawing.Point(128, 81)
        Me.btnCierre.Name = "btnCierre"
        Me.btnCierre.Rotation = 0R
        Me.btnCierre.Size = New System.Drawing.Size(123, 55)
        Me.btnCierre.TabIndex = 32
        Me.btnCierre.Text = "Cierre"
        Me.btnCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCierre.UseVisualStyleBackColor = True
        '
        'btnPagos
        '
        Me.btnPagos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagos.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnPagos.IconChar = FontAwesome.Sharp.IconChar.CashRegister
        Me.btnPagos.IconColor = System.Drawing.Color.Black
        Me.btnPagos.IconSize = 48
        Me.btnPagos.Location = New System.Drawing.Point(6, 81)
        Me.btnPagos.Name = "btnPagos"
        Me.btnPagos.Rotation = 0R
        Me.btnPagos.Size = New System.Drawing.Size(118, 55)
        Me.btnPagos.TabIndex = 31
        Me.btnPagos.Text = "Pagos"
        Me.btnPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPagos.UseVisualStyleBackColor = True
        '
        'btnConsultacaja
        '
        Me.btnConsultacaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultacaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultacaja.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnConsultacaja.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.btnConsultacaja.IconColor = System.Drawing.Color.Black
        Me.btnConsultacaja.IconSize = 48
        Me.btnConsultacaja.Location = New System.Drawing.Point(631, 6)
        Me.btnConsultacaja.Name = "btnConsultacaja"
        Me.btnConsultacaja.Rotation = 0R
        Me.btnConsultacaja.Size = New System.Drawing.Size(131, 55)
        Me.btnConsultacaja.TabIndex = 30
        Me.btnConsultacaja.Text = "Consultar caja"
        Me.btnConsultacaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultacaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultacaja.UseVisualStyleBackColor = True
        '
        'btnDevolucion
        '
        Me.btnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDevolucion.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnDevolucion.IconChar = FontAwesome.Sharp.IconChar.Undo
        Me.btnDevolucion.IconColor = System.Drawing.Color.Black
        Me.btnDevolucion.IconSize = 48
        Me.btnDevolucion.Location = New System.Drawing.Point(496, 6)
        Me.btnDevolucion.Name = "btnDevolucion"
        Me.btnDevolucion.Rotation = 0R
        Me.btnDevolucion.Size = New System.Drawing.Size(131, 55)
        Me.btnDevolucion.TabIndex = 29
        Me.btnDevolucion.Text = "Devolucion"
        Me.btnDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDevolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDevolucion.UseVisualStyleBackColor = True
        '
        'btnBorrarLinea
        '
        Me.btnBorrarLinea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBorrarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarLinea.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnBorrarLinea.IconChar = FontAwesome.Sharp.IconChar.MinusCircle
        Me.btnBorrarLinea.IconColor = System.Drawing.Color.Black
        Me.btnBorrarLinea.IconSize = 48
        Me.btnBorrarLinea.Location = New System.Drawing.Point(375, 6)
        Me.btnBorrarLinea.Name = "btnBorrarLinea"
        Me.btnBorrarLinea.Rotation = 0R
        Me.btnBorrarLinea.Size = New System.Drawing.Size(118, 55)
        Me.btnBorrarLinea.TabIndex = 28
        Me.btnBorrarLinea.Text = "Borrar linea"
        Me.btnBorrarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrarLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBorrarLinea.UseVisualStyleBackColor = True
        '
        'btnEspera
        '
        Me.btnEspera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEspera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEspera.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnEspera.IconChar = FontAwesome.Sharp.IconChar.PauseCircle
        Me.btnEspera.IconColor = System.Drawing.Color.Black
        Me.btnEspera.IconSize = 48
        Me.btnEspera.Location = New System.Drawing.Point(254, 6)
        Me.btnEspera.Name = "btnEspera"
        Me.btnEspera.Rotation = 0R
        Me.btnEspera.Size = New System.Drawing.Size(118, 55)
        Me.btnEspera.TabIndex = 27
        Me.btnEspera.Text = "Espera"
        Me.btnEspera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEspera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEspera.UseVisualStyleBackColor = True
        '
        'btnRecuperar
        '
        Me.btnRecuperar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecuperar.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnRecuperar.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.btnRecuperar.IconColor = System.Drawing.Color.Black
        Me.btnRecuperar.IconSize = 48
        Me.btnRecuperar.Location = New System.Drawing.Point(128, 6)
        Me.btnRecuperar.Name = "btnRecuperar"
        Me.btnRecuperar.Rotation = 0R
        Me.btnRecuperar.Size = New System.Drawing.Size(123, 55)
        Me.btnRecuperar.TabIndex = 26
        Me.btnRecuperar.Text = "Recuperar"
        Me.btnRecuperar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecuperar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRecuperar.UseVisualStyleBackColor = True
        '
        'btnFacturar
        '
        Me.btnFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturar.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnFacturar.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar
        Me.btnFacturar.IconColor = System.Drawing.Color.Black
        Me.btnFacturar.IconSize = 48
        Me.btnFacturar.Location = New System.Drawing.Point(6, 6)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Rotation = 0R
        Me.btnFacturar.Size = New System.Drawing.Size(118, 55)
        Me.btnFacturar.TabIndex = 25
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFacturar.UseVisualStyleBackColor = True
        '
        'btnConsultaFacturas
        '
        Me.btnConsultaFacturas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultaFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaFacturas.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnConsultaFacturas.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.btnConsultaFacturas.IconColor = System.Drawing.Color.Black
        Me.btnConsultaFacturas.IconSize = 48
        Me.btnConsultaFacturas.Location = New System.Drawing.Point(496, 81)
        Me.btnConsultaFacturas.Name = "btnConsultaFacturas"
        Me.btnConsultaFacturas.Rotation = 0R
        Me.btnConsultaFacturas.Size = New System.Drawing.Size(131, 55)
        Me.btnConsultaFacturas.TabIndex = 35
        Me.btnConsultaFacturas.Text = "Consultar Facturas"
        Me.btnConsultaFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultaFacturas.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(1022, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 15)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Efectivo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Visible = False
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(1090, 113)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.ReadOnly = True
        Me.txtEfectivo.Size = New System.Drawing.Size(99, 23)
        Me.txtEfectivo.TabIndex = 44
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEfectivo.Visible = False
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(1041, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 15)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "Total:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1044, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "DTO:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1052, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 15)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "IVA:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1015, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Sub total:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporteTotalConIva
        '
        Me.txtImporteTotalConIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteTotalConIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteTotalConIva.Location = New System.Drawing.Point(1090, 59)
        Me.txtImporteTotalConIva.Name = "txtImporteTotalConIva"
        Me.txtImporteTotalConIva.ReadOnly = True
        Me.txtImporteTotalConIva.Size = New System.Drawing.Size(99, 23)
        Me.txtImporteTotalConIva.TabIndex = 39
        Me.txtImporteTotalConIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteDescuento
        '
        Me.txtImporteDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteDescuento.Location = New System.Drawing.Point(1090, 85)
        Me.txtImporteDescuento.Name = "txtImporteDescuento"
        Me.txtImporteDescuento.ReadOnly = True
        Me.txtImporteDescuento.Size = New System.Drawing.Size(99, 23)
        Me.txtImporteDescuento.TabIndex = 38
        Me.txtImporteDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteIva
        '
        Me.txtImporteIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteIva.Location = New System.Drawing.Point(1090, 32)
        Me.txtImporteIva.Name = "txtImporteIva"
        Me.txtImporteIva.ReadOnly = True
        Me.txtImporteIva.Size = New System.Drawing.Size(99, 23)
        Me.txtImporteIva.TabIndex = 37
        Me.txtImporteIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalSinIva
        '
        Me.txtTotalSinIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalSinIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSinIva.Location = New System.Drawing.Point(1089, 5)
        Me.txtTotalSinIva.Name = "txtTotalSinIva"
        Me.txtTotalSinIva.ReadOnly = True
        Me.txtTotalSinIva.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalSinIva.TabIndex = 36
        Me.txtTotalSinIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmMain_Material
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1195, 763)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelHeader)
        Me.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain_Material"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain_Material"
        Me.PanelBody.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents PanelBody As Panel
    Friend WithEvents PanelBody_Top As Panel
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents btnFacturar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnRecuperar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEspera As FontAwesome.Sharp.IconButton
    Friend WithEvents btnBorrarLinea As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDevolucion As FontAwesome.Sharp.IconButton
    Friend WithEvents btnConsultacaja As FontAwesome.Sharp.IconButton
    Friend WithEvents btnPagos As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCierre As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDescuentoAll As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDescuentoLinea As FontAwesome.Sharp.IconButton
    Friend WithEvents btnConsultaFacturas As FontAwesome.Sharp.IconButton
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
