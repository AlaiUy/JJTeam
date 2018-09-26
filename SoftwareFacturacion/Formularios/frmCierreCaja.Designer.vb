<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreCaja
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSaldoInicialP = New System.Windows.Forms.TextBox()
        Me.txtSaldoFinalP = New System.Windows.Forms.TextBox()
        Me.txtSaldoFinalD = New System.Windows.Forms.TextBox()
        Me.txtSaldoIncialD = New System.Windows.Forms.TextBox()
        Me.btnCerrarCaja = New System.Windows.Forms.Button()
        Me.btnReimprimirCaja = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnReimprimirCaja)
        Me.Panel1.Controls.Add(Me.btnCerrarCaja)
        Me.Panel1.Controls.Add(Me.txtSaldoIncialD)
        Me.Panel1.Controls.Add(Me.txtSaldoFinalD)
        Me.Panel1.Controls.Add(Me.txtSaldoFinalP)
        Me.Panel1.Controls.Add(Me.txtSaldoInicialP)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 182)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Saldo Inicial $"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Saldo Inicial U$S"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Saldo Final $"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(279, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Saldo Final U$S"
        '
        'txtSaldoInicialP
        '
        Me.txtSaldoInicialP.Location = New System.Drawing.Point(125, 27)
        Me.txtSaldoInicialP.Name = "txtSaldoInicialP"
        Me.txtSaldoInicialP.Size = New System.Drawing.Size(127, 26)
        Me.txtSaldoInicialP.TabIndex = 4
        '
        'txtSaldoFinalP
        '
        Me.txtSaldoFinalP.Location = New System.Drawing.Point(125, 78)
        Me.txtSaldoFinalP.Name = "txtSaldoFinalP"
        Me.txtSaldoFinalP.Size = New System.Drawing.Size(127, 26)
        Me.txtSaldoFinalP.TabIndex = 5
        '
        'txtSaldoFinalD
        '
        Me.txtSaldoFinalD.Location = New System.Drawing.Point(409, 78)
        Me.txtSaldoFinalD.Name = "txtSaldoFinalD"
        Me.txtSaldoFinalD.Size = New System.Drawing.Size(141, 26)
        Me.txtSaldoFinalD.TabIndex = 6
        '
        'txtSaldoIncialD
        '
        Me.txtSaldoIncialD.Location = New System.Drawing.Point(409, 27)
        Me.txtSaldoIncialD.Name = "txtSaldoIncialD"
        Me.txtSaldoIncialD.Size = New System.Drawing.Size(141, 26)
        Me.txtSaldoIncialD.TabIndex = 7
        '
        'btnCerrarCaja
        '
        Me.btnCerrarCaja.Location = New System.Drawing.Point(101, 125)
        Me.btnCerrarCaja.Name = "btnCerrarCaja"
        Me.btnCerrarCaja.Size = New System.Drawing.Size(139, 38)
        Me.btnCerrarCaja.TabIndex = 8
        Me.btnCerrarCaja.Text = "Cerrar Caja"
        Me.btnCerrarCaja.UseVisualStyleBackColor = True
        '
        'btnReimprimirCaja
        '
        Me.btnReimprimirCaja.Location = New System.Drawing.Point(338, 125)
        Me.btnReimprimirCaja.Name = "btnReimprimirCaja"
        Me.btnReimprimirCaja.Size = New System.Drawing.Size(139, 38)
        Me.btnReimprimirCaja.TabIndex = 9
        Me.btnReimprimirCaja.Text = "Reimprimir Caja"
        Me.btnReimprimirCaja.UseVisualStyleBackColor = True
        '
        'frmCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 206)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCierreCaja"
        Me.Text = "Cierre de Caja"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnReimprimirCaja As Button
    Friend WithEvents btnCerrarCaja As Button
    Friend WithEvents txtSaldoIncialD As TextBox
    Friend WithEvents txtSaldoFinalD As TextBox
    Friend WithEvents txtSaldoFinalP As TextBox
    Friend WithEvents txtSaldoInicialP As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
