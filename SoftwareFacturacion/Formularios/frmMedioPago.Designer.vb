﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedioPago
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
        Me.btnTarjeta = New System.Windows.Forms.Button()
        Me.btnEfectivo = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.btnVolver)
        Me.Panel1.Controls.Add(Me.btnTarjeta)
        Me.Panel1.Controls.Add(Me.btnEfectivo)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 160)
        Me.Panel1.TabIndex = 0
        '
        'btnTarjeta
        '
        Me.btnTarjeta.Location = New System.Drawing.Point(132, 13)
        Me.btnTarjeta.Name = "btnTarjeta"
        Me.btnTarjeta.Size = New System.Drawing.Size(97, 65)
        Me.btnTarjeta.TabIndex = 1
        Me.btnTarjeta.Text = "Tarjeta"
        Me.btnTarjeta.UseVisualStyleBackColor = True
        '
        'btnEfectivo
        '
        Me.btnEfectivo.Location = New System.Drawing.Point(13, 13)
        Me.btnEfectivo.Name = "btnEfectivo"
        Me.btnEfectivo.Size = New System.Drawing.Size(97, 65)
        Me.btnEfectivo.TabIndex = 0
        Me.btnEfectivo.Text = "Efectivo"
        Me.btnEfectivo.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(154, 117)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 34)
        Me.btnVolver.TabIndex = 2
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'frmMedioPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(264, 184)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmMedioPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Medio de Pago"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnEfectivo As Button
    Friend WithEvents btnTarjeta As Button
    Friend WithEvents btnVolver As Button
End Class
