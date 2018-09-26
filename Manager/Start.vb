Public Class Start
    <STAThread()>
    Shared Sub Main()
        Try
            Application.SetCompatibleTextRenderingDefault(False)
            Application.EnableVisualStyles()
            Dim main As Form = New frmMain()
            main.ShowDialog()
            'If (Login.DialogResult = DialogResult.OK) Then
            '    Dim MainForm As Form = New Main()
            '    Application.Run(MainForm)
            'Else
            '    Return
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
