<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoProveedor
    Inherits Form

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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.lblCelular = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.txtRut = New System.Windows.Forms.TextBox()
        Me.lblRut = New System.Windows.Forms.Label()
        Me.txtRz = New System.Windows.Forms.TextBox()
        Me.lblRz = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 390)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 349)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(675, 41)
        Me.Panel4.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(586, 9)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cbCategoria)
        Me.Panel3.Controls.Add(Me.lblCategoria)
        Me.Panel3.Controls.Add(Me.txtEmail)
        Me.Panel3.Controls.Add(Me.lblEmail)
        Me.Panel3.Controls.Add(Me.txtCelular)
        Me.Panel3.Controls.Add(Me.lblCelular)
        Me.Panel3.Controls.Add(Me.txtTelefono)
        Me.Panel3.Controls.Add(Me.lblTelefono)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.txtRut)
        Me.Panel3.Controls.Add(Me.lblRut)
        Me.Panel3.Controls.Add(Me.txtRz)
        Me.Panel3.Controls.Add(Me.lblRz)
        Me.Panel3.Controls.Add(Me.txtNombre)
        Me.Panel3.Controls.Add(Me.lblNombre)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(675, 358)
        Me.Panel3.TabIndex = 1
        '
        'cbCategoria
        '
        Me.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(121, 246)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(185, 23)
        Me.cbCategoria.TabIndex = 6
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(20, 246)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(85, 30)
        Me.lblCategoria.TabIndex = 17
        Me.lblCategoria.Text = "CATEGORIA:"
        Me.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCategoria.UseCompatibleTextRendering = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(121, 207)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(185, 21)
        Me.txtEmail.TabIndex = 5
        '
        'lblEmail
        '
        Me.lblEmail.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(20, 202)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(85, 30)
        Me.lblEmail.TabIndex = 15
        Me.lblEmail.Text = "EMAIL:"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblEmail.UseCompatibleTextRendering = True
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(121, 168)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(185, 21)
        Me.txtCelular.TabIndex = 4
        '
        'lblCelular
        '
        Me.lblCelular.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelular.Location = New System.Drawing.Point(20, 163)
        Me.lblCelular.Name = "lblCelular"
        Me.lblCelular.Size = New System.Drawing.Size(85, 30)
        Me.lblCelular.TabIndex = 13
        Me.lblCelular.Text = "CELULAR:"
        Me.lblCelular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCelular.UseCompatibleTextRendering = True
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(121, 130)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(185, 21)
        Me.txtTelefono.TabIndex = 3
        '
        'lblTelefono
        '
        Me.lblTelefono.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(20, 125)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(85, 30)
        Me.lblTelefono.TabIndex = 11
        Me.lblTelefono.Text = "TELEFONO:"
        Me.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTelefono.UseCompatibleTextRendering = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Controls.Add(Me.lblCalle)
        Me.GroupBox1.Location = New System.Drawing.Point(346, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 120)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Direccion"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(92, 75)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(185, 21)
        Me.txtNumero.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 30)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "NUMERO:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.UseCompatibleTextRendering = True
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(92, 35)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(185, 21)
        Me.txtCalle.TabIndex = 7
        '
        'lblCalle
        '
        Me.lblCalle.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalle.Location = New System.Drawing.Point(23, 30)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(63, 30)
        Me.lblCalle.TabIndex = 10
        Me.lblCalle.Text = "CALLE:"
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCalle.UseCompatibleTextRendering = True
        '
        'txtRut
        '
        Me.txtRut.Location = New System.Drawing.Point(121, 94)
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(185, 21)
        Me.txtRut.TabIndex = 2
        '
        'lblRut
        '
        Me.lblRut.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRut.Location = New System.Drawing.Point(20, 89)
        Me.lblRut.Name = "lblRut"
        Me.lblRut.Size = New System.Drawing.Size(85, 30)
        Me.lblRut.TabIndex = 6
        Me.lblRut.Text = "RUT:"
        Me.lblRut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRut.UseCompatibleTextRendering = True
        '
        'txtRz
        '
        Me.txtRz.Location = New System.Drawing.Point(121, 54)
        Me.txtRz.Name = "txtRz"
        Me.txtRz.Size = New System.Drawing.Size(185, 21)
        Me.txtRz.TabIndex = 1
        '
        'lblRz
        '
        Me.lblRz.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRz.Location = New System.Drawing.Point(20, 49)
        Me.lblRz.Name = "lblRz"
        Me.lblRz.Size = New System.Drawing.Size(85, 30)
        Me.lblRz.TabIndex = 4
        Me.lblRz.Text = "RAZON SOLCIAL:"
        Me.lblRz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRz.UseCompatibleTextRendering = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(121, 16)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(185, 21)
        Me.txtNombre.TabIndex = 0
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(20, 19)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(85, 15)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "NOMBRE:"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 32)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGISTRO DE UN NUEVO PROVEEDOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmNuevoProveedor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(679, 395)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmNuevoProveedor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNuevoProveedor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents lblCategoria As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents lblCelular As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lblTelefono As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCalle As TextBox
    Friend WithEvents lblCalle As Label
    Friend WithEvents txtRut As TextBox
    Friend WithEvents lblRut As Label
    Friend WithEvents txtRz As TextBox
    Friend WithEvents lblRz As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
End Class
