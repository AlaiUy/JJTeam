Imports JJ.Entidades
Imports JJ.Gestoras
Imports JJ.Interfaces.Observer

Public Class frmMain
    Implements IObserver
    Public xClaveAdmin As Boolean = True

    Dim Tab As TabControl = Nothing

    Private Sub btnNuevoArticulo_Click(sender As Object, e As EventArgs)
        Dim frm As Form = New frmNuevoArticulo()
        frm.Show()
    End Sub


    Private Sub btnMenuSalir_Click(sender As Object, e As EventArgs) Handles btnMenuSalir.Click
        If MsgBox("¿Desea salir de la aplicacion?", vbOKCancel, "Realmente...") = MsgBoxResult.Ok Then
            Close()
        End If
    End Sub

    Private Sub AgregarArticuloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarArticuloToolStripMenuItem.Click
        Dim frm As Form = New frmNuevoArticulo()
        TryCast(frm, frmNuevoArticulo).Register(Me)
        CargarFormulario(frm)

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopularForm()
    End Sub

    Private Sub CargarFormulario(ByVal xFormulario As Form)
        If IsNothing(Tab) Then
            PanelBienvenida.Dispose()
            Tab = New TabControl()
            PnContenedor.Controls.Add(Tab)
            Tab.Dock = DockStyle.Fill
        End If
        Dim TP As TabPage = New TabPage("Articulos")
        Dim Panel As Panel = New Panel()
        With xFormulario
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
        End With
        With Panel
            .Controls.Add(xFormulario)
            .Dock = DockStyle.Fill
        End With

        With TP
            .Controls.Add(Panel)
            .BackColor = Color.White
        End With
        With Tab
            Tab.TabPages.Add(TP)
            Tab.Appearance = TabAppearance.FlatButtons
        End With

        xFormulario.Show()
    End Sub

    Public Overloads Sub Update(Obj As Object) Implements IObserver.Update
        If (TypeOf Obj Is Form) Then
            If Not IsNothing(Tab) Then
                If Tab.TabCount = 1 Then
                    If TryCast(Obj, Form).DialogResult = DialogResult.Abort Then
                        PanelBienvenida.Show()
                        Tab.Dispose()
                        Tab = Nothing
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub PopularForm()
        If xClaveAdmin = True Then
            ToolsConfig.Visible = True
            ToolsConfig.Enabled = True
        Else
            ToolsConfig.Visible = False
            ToolsConfig.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosToolStripMenuItem.Click
        Dim Form As Form = New frmEmpresaData()
        Form.ShowDialog()
    End Sub
End Class