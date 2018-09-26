<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecuperarVenta
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgridEsperaLin = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgridEspera = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRecuperar = New System.Windows.Forms.Button()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgridEsperaLin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgridEspera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(932, 601)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgridEsperaLin)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(327, 108)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(605, 493)
        Me.Panel4.TabIndex = 2
        '
        'dgridEsperaLin
        '
        Me.dgridEsperaLin.AllowUserToAddRows = False
        Me.dgridEsperaLin.AllowUserToDeleteRows = False
        Me.dgridEsperaLin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgridEsperaLin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgridEsperaLin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgridEsperaLin.Location = New System.Drawing.Point(0, 0)
        Me.dgridEsperaLin.MultiSelect = False
        Me.dgridEsperaLin.Name = "dgridEsperaLin"
        Me.dgridEsperaLin.ReadOnly = True
        Me.dgridEsperaLin.RowHeadersVisible = False
        Me.dgridEsperaLin.RowTemplate.Height = 28
        Me.dgridEsperaLin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgridEsperaLin.Size = New System.Drawing.Size(605, 493)
        Me.dgridEsperaLin.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgridEspera)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 108)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(327, 493)
        Me.Panel3.TabIndex = 1
        '
        'dgridEspera
        '
        Me.dgridEspera.AllowUserToAddRows = False
        Me.dgridEspera.AllowUserToDeleteRows = False
        Me.dgridEspera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgridEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgridEspera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgridEspera.Location = New System.Drawing.Point(0, 0)
        Me.dgridEspera.MultiSelect = False
        Me.dgridEspera.Name = "dgridEspera"
        Me.dgridEspera.ReadOnly = True
        Me.dgridEspera.RowHeadersVisible = False
        Me.dgridEspera.RowTemplate.Height = 28
        Me.dgridEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgridEspera.Size = New System.Drawing.Size(327, 493)
        Me.dgridEspera.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRecuperar)
        Me.Panel2.Controls.Add(Me.txtDireccion)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.txtDocumento)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(932, 108)
        Me.Panel2.TabIndex = 0
        '
        'btnRecuperar
        '
        Me.btnRecuperar.Location = New System.Drawing.Point(774, 3)
        Me.btnRecuperar.Name = "btnRecuperar"
        Me.btnRecuperar.Size = New System.Drawing.Size(159, 46)
        Me.btnRecuperar.TabIndex = 6
        Me.btnRecuperar.Text = "Recuperar Venta"
        Me.btnRecuperar.UseVisualStyleBackColor = True
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(118, 72)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(361, 26)
        Me.txtDireccion.TabIndex = 5
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(118, 40)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(361, 26)
        Me.txtNombre.TabIndex = 4
        '
        'txtDocumento
        '
        Me.txtDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(118, 8)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(149, 26)
        Me.txtDocumento.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Direccion:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Documento:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(637, 622)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Importe Total:"
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteTotal.Location = New System.Drawing.Point(750, 619)
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(194, 26)
        Me.txtImporteTotal.TabIndex = 2
        '
        'frmRecuperarVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 656)
        Me.Controls.Add(Me.txtImporteTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRecuperarVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recuperar Venta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgridEsperaLin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgridEspera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgridEspera As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgridEsperaLin As DataGridView
    Friend WithEvents btnRecuperar As Button
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtDocumento As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtImporteTotal As TextBox
End Class
