<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagos
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
        Me.dgridPagos = New System.Windows.Forms.DataGridView()
        Me.txtDescripcion = New System.Windows.Forms.Panel()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cboxMoneda = New System.Windows.Forms.ComboBox()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.txtDescripcion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1155, 573)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgridPagos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 139)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1155, 434)
        Me.Panel3.TabIndex = 1
        '
        'dgridPagos
        '
        Me.dgridPagos.AllowUserToAddRows = False
        Me.dgridPagos.AllowUserToDeleteRows = False
        Me.dgridPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgridPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgridPagos.Location = New System.Drawing.Point(0, 0)
        Me.dgridPagos.MultiSelect = False
        Me.dgridPagos.Name = "dgridPagos"
        Me.dgridPagos.RowHeadersVisible = False
        Me.dgridPagos.RowTemplate.Height = 28
        Me.dgridPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgridPagos.Size = New System.Drawing.Size(1155, 434)
        Me.dgridPagos.TabIndex = 0
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Controls.Add(Me.btnBorrar)
        Me.txtDescripcion.Controls.Add(Me.btnAgregar)
        Me.txtDescripcion.Controls.Add(Me.cboxMoneda)
        Me.txtDescripcion.Controls.Add(Me.txtImporte)
        Me.txtDescripcion.Controls.Add(Me.TextBox1)
        Me.txtDescripcion.Controls.Add(Me.Label3)
        Me.txtDescripcion.Controls.Add(Me.Label2)
        Me.txtDescripcion.Controls.Add(Me.Label1)
        Me.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDescripcion.Location = New System.Drawing.Point(0, 0)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(1155, 139)
        Me.txtDescripcion.TabIndex = 0
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(512, 72)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(95, 39)
        Me.btnBorrar.TabIndex = 7
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(512, 13)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(95, 38)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cboxMoneda
        '
        Me.cboxMoneda.FormattingEnabled = True
        Me.cboxMoneda.Location = New System.Drawing.Point(137, 83)
        Me.cboxMoneda.Name = "cboxMoneda"
        Me.cboxMoneda.Size = New System.Drawing.Size(251, 28)
        Me.cboxMoneda.TabIndex = 5
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(137, 51)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(172, 26)
        Me.txtImporte.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(137, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(328, 26)
        Me.TextBox1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Moneda"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Importe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripcion"
        '
        'frmPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 597)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmPagos"
        Me.Text = "Pagos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.txtDescripcion.ResumeLayout(False)
        Me.txtDescripcion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtDescripcion As Panel
    Friend WithEvents dgridPagos As DataGridView
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents cboxMoneda As ComboBox
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
