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
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAgregarPersona = New System.Windows.Forms.Button()
        Me.btnNuevoArticulo = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlContenedor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.Controls.Add(Me.Button1)
        Me.pnlContenedor.Controls.Add(Me.Panel1)
        Me.pnlContenedor.Controls.Add(Me.btnNuevoArticulo)
        Me.pnlContenedor.Location = New System.Drawing.Point(220, 103)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(580, 348)
        Me.pnlContenedor.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAgregarPersona)
        Me.Panel1.Location = New System.Drawing.Point(28, 121)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(82, 100)
        Me.Panel1.TabIndex = 2
        '
        'btnAgregarPersona
        '
        Me.btnAgregarPersona.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAgregarPersona.FlatAppearance.BorderSize = 0
        Me.btnAgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPersona.Image = Global.Manager.My.Resources.JJRecursos.man
        Me.btnAgregarPersona.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregarPersona.Location = New System.Drawing.Point(12, 9)
        Me.btnAgregarPersona.Name = "btnAgregarPersona"
        Me.btnAgregarPersona.Size = New System.Drawing.Size(59, 39)
        Me.btnAgregarPersona.TabIndex = 0
        Me.btnAgregarPersona.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregarPersona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAgregarPersona.UseVisualStyleBackColor = False
        '
        'btnNuevoArticulo
        '
        Me.btnNuevoArticulo.FlatAppearance.BorderSize = 0
        Me.btnNuevoArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoArticulo.Image = Global.Manager.My.Resources.JJRecursos.Tools
        Me.btnNuevoArticulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevoArticulo.Location = New System.Drawing.Point(216, 158)
        Me.btnNuevoArticulo.Name = "btnNuevoArticulo"
        Me.btnNuevoArticulo.Size = New System.Drawing.Size(89, 63)
        Me.btnNuevoArticulo.TabIndex = 1
        Me.btnNuevoArticulo.Text = "Agregar Articulos"
        Me.btnNuevoArticulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevoArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNuevoArticulo.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(395, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 55)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 543)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.pnlContenedor.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents btnAgregarPersona As Button
    Friend WithEvents btnNuevoArticulo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
End Class
