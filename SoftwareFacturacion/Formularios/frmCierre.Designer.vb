<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierre
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDolaresInicial = New System.Windows.Forms.TextBox()
        Me.txtFinalDolares = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPesosInicial = New System.Windows.Forms.TextBox()
        Me.txtPesosFinal = New System.Windows.Forms.TextBox()
        Me.btnCierre = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(635, 288)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.btnCierre)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(635, 288)
        Me.Panel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.txtDolaresInicial)
        Me.Panel4.Controls.Add(Me.txtFinalDolares)
        Me.Panel4.Location = New System.Drawing.Point(423, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(182, 233)
        Me.Panel4.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "DOLARES"
        '
        'txtDolaresInicial
        '
        Me.txtDolaresInicial.Enabled = False
        Me.txtDolaresInicial.Location = New System.Drawing.Point(29, 60)
        Me.txtDolaresInicial.Name = "txtDolaresInicial"
        Me.txtDolaresInicial.Size = New System.Drawing.Size(136, 26)
        Me.txtDolaresInicial.TabIndex = 2
        Me.txtDolaresInicial.Text = "0"
        Me.txtDolaresInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFinalDolares
        '
        Me.txtFinalDolares.Enabled = False
        Me.txtFinalDolares.Location = New System.Drawing.Point(29, 168)
        Me.txtFinalDolares.Name = "txtFinalDolares"
        Me.txtFinalDolares.Size = New System.Drawing.Size(136, 26)
        Me.txtFinalDolares.TabIndex = 7
        Me.txtFinalDolares.Text = "0"
        Me.txtFinalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtPesosInicial)
        Me.Panel3.Controls.Add(Me.txtPesosFinal)
        Me.Panel3.Location = New System.Drawing.Point(28, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(171, 233)
        Me.Panel3.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PESOS"
        '
        'txtPesosInicial
        '
        Me.txtPesosInicial.Location = New System.Drawing.Point(19, 60)
        Me.txtPesosInicial.Name = "txtPesosInicial"
        Me.txtPesosInicial.Size = New System.Drawing.Size(136, 26)
        Me.txtPesosInicial.TabIndex = 1
        Me.txtPesosInicial.Text = "0"
        Me.txtPesosInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPesosFinal
        '
        Me.txtPesosFinal.Location = New System.Drawing.Point(19, 168)
        Me.txtPesosFinal.Name = "txtPesosFinal"
        Me.txtPesosFinal.Size = New System.Drawing.Size(136, 26)
        Me.txtPesosFinal.TabIndex = 6
        Me.txtPesosFinal.Text = "0"
        Me.txtPesosFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCierre
        '
        Me.btnCierre.Location = New System.Drawing.Point(247, 214)
        Me.btnCierre.Name = "btnCierre"
        Me.btnCierre.Size = New System.Drawing.Size(143, 43)
        Me.btnCierre.TabIndex = 0
        Me.btnCierre.Text = "Realizar Cierre"
        Me.btnCierre.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(260, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Saldo Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Saldo Inicial"
        '
        'frmCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 312)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmCierre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cierre Caja"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCierre As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDolaresInicial As TextBox
    Friend WithEvents txtPesosInicial As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtFinalDolares As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtPesosFinal As TextBox
    Friend WithEvents Label2 As Label
End Class
