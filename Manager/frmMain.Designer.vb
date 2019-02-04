<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnMenuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PnContenedor = New System.Windows.Forms.Panel()
        Me.PanelBienvenida = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnAgregarPersona = New System.Windows.Forms.Button()
        Me.btnNuevoArticulo = New System.Windows.Forms.Button()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AgregarPersonaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarArticuloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolsConfig = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FicherosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.PnContenedor.SuspendLayout()
        Me.PanelBienvenida.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator1, Me.ToolStripDropDownButton2, Me.ToolStripSeparator2, Me.ToolStripDropDownButton3, Me.ToolStripSeparator3, Me.ToolStripDropDownButton4, Me.ToolsConfig})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMenuSalir})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        Me.ToolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'btnMenuSalir
        '
        Me.btnMenuSalir.Name = "btnMenuSalir"
        Me.btnMenuSalir.Size = New System.Drawing.Size(95, 22)
        Me.btnMenuSalir.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'PnContenedor
        '
        Me.PnContenedor.Controls.Add(Me.PanelBienvenida)
        Me.PnContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnContenedor.Location = New System.Drawing.Point(0, 25)
        Me.PnContenedor.Name = "PnContenedor"
        Me.PnContenedor.Size = New System.Drawing.Size(1008, 390)
        Me.PnContenedor.TabIndex = 2
        '
        'PanelBienvenida
        '
        Me.PanelBienvenida.Controls.Add(Me.Label1)
        Me.PanelBienvenida.Controls.Add(Me.PictureBox1)
        Me.PanelBienvenida.Controls.Add(Me.btnAgregarPersona)
        Me.PanelBienvenida.Controls.Add(Me.btnNuevoArticulo)
        Me.PanelBienvenida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBienvenida.Location = New System.Drawing.Point(0, 0)
        Me.PanelBienvenida.Name = "PanelBienvenida"
        Me.PanelBienvenida.Size = New System.Drawing.Size(1008, 390)
        Me.PanelBienvenida.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(124, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(407, 29)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "JJTeam Soluciones Informaticas."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Manager.My.Resources.JJRecursos.placeholder__1_
        Me.PictureBox1.Location = New System.Drawing.Point(46, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 75)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'btnAgregarPersona
        '
        Me.btnAgregarPersona.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregarPersona.FlatAppearance.BorderSize = 0
        Me.btnAgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPersona.Image = Global.Manager.My.Resources.JJRecursos.man
        Me.btnAgregarPersona.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregarPersona.Location = New System.Drawing.Point(129, 203)
        Me.btnAgregarPersona.Name = "btnAgregarPersona"
        Me.btnAgregarPersona.Size = New System.Drawing.Size(186, 37)
        Me.btnAgregarPersona.TabIndex = 4
        Me.btnAgregarPersona.Text = "Agregar Persona"
        Me.btnAgregarPersona.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarPersona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarPersona.UseVisualStyleBackColor = False
        '
        'btnNuevoArticulo
        '
        Me.btnNuevoArticulo.FlatAppearance.BorderSize = 0
        Me.btnNuevoArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoArticulo.Image = Global.Manager.My.Resources.JJRecursos.Tools
        Me.btnNuevoArticulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevoArticulo.Location = New System.Drawing.Point(129, 135)
        Me.btnNuevoArticulo.Name = "btnNuevoArticulo"
        Me.btnNuevoArticulo.Size = New System.Drawing.Size(186, 37)
        Me.btnNuevoArticulo.TabIndex = 1
        Me.btnNuevoArticulo.Text = "Agregar Articulos"
        Me.btnNuevoArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNuevoArticulo.UseVisualStyleBackColor = False
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarPersonaToolStripMenuItem, Me.AgregarArticuloToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripDropDownButton2.Text = "Tareas"
        '
        'AgregarPersonaToolStripMenuItem
        '
        Me.AgregarPersonaToolStripMenuItem.Name = "AgregarPersonaToolStripMenuItem"
        Me.AgregarPersonaToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AgregarPersonaToolStripMenuItem.Text = "Agregar persona"
        '
        'AgregarArticuloToolStripMenuItem
        '
        Me.AgregarArticuloToolStripMenuItem.Name = "AgregarArticuloToolStripMenuItem"
        Me.AgregarArticuloToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AgregarArticuloToolStripMenuItem.Text = "Agregar articulo"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripDropDownButton3.Text = "Tools"
        '
        'ToolStripDropDownButton4
        '
        Me.ToolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton4.Image = CType(resources.GetObject("ToolStripDropDownButton4.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton4.Name = "ToolStripDropDownButton4"
        Me.ToolStripDropDownButton4.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripDropDownButton4.Text = "Help"
        '
        'ToolsConfig
        '
        Me.ToolsConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolsConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguracionToolStripMenuItem})
        Me.ToolsConfig.Image = CType(resources.GetObject("ToolsConfig.Image"), System.Drawing.Image)
        Me.ToolsConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolsConfig.Name = "ToolsConfig"
        Me.ToolsConfig.Size = New System.Drawing.Size(56, 22)
        Me.ToolsConfig.Text = "Config"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosToolStripMenuItem, Me.FicherosToolStripMenuItem})
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConfiguracionToolStripMenuItem.Text = "Empresa"
        '
        'DatosToolStripMenuItem
        '
        Me.DatosToolStripMenuItem.Name = "DatosToolStripMenuItem"
        Me.DatosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DatosToolStripMenuItem.Text = "Datos"
        '
        'FicherosToolStripMenuItem
        '
        Me.FicherosToolStripMenuItem.Name = "FicherosToolStripMenuItem"
        Me.FicherosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FicherosToolStripMenuItem.Text = "Ficheros"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 415)
        Me.Controls.Add(Me.PnContenedor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PnContenedor.ResumeLayout(False)
        Me.PanelBienvenida.ResumeLayout(False)
        Me.PanelBienvenida.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents btnMenuSalir As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton4 As ToolStripDropDownButton
    Friend WithEvents AgregarPersonaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarArticuloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PnContenedor As Panel
    Friend WithEvents PanelBienvenida As Panel
    Friend WithEvents btnAgregarPersona As Button
    Friend WithEvents btnNuevoArticulo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolsConfig As ToolStripDropDownButton
    Friend WithEvents ConfiguracionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FicherosToolStripMenuItem As ToolStripMenuItem
End Class
