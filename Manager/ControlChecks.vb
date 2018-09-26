Imports System.Globalization

Module ControlChecks
    Public Function BackTextBox(ByVal xCorrecto) As Color
        If xCorrecto Then
            Return Color.LightGreen
        End If
        Return Color.IndianRed
    End Function

    Public Function FormatearImporte(ByVal xImporte As Decimal) As String
        If xImporte < 10 Then
            Return String.Format(CultureInfo.InvariantCulture, "{0:0.00}", xImporte)
        Else
            Return String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", xImporte)
        End If

    End Function

    Public Function ValidarImportes(ByRef xIngreso As Char, ByVal xTextoIngresado As String, ByVal xLenSelecionado As Integer, ByVal xLenStart As Integer, ByVal xPrecision As Byte)
        Dim Separador As Char = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)
        Dim PosicionSeparador As Integer = 0

        If ((xIngreso = "."c) OrElse (xIngreso = ","c)) Then
            If xTextoIngresado.Length = 0 Or xLenSelecionado = xTextoIngresado.Length Or xLenStart = 0 Then
                Return True
            End If
            ' Obtenemos el carácter separador decimal existente
            ' actualmente en la configuración regional de Windows.
            xIngreso = Separador
        End If

        Dim Punto As Boolean = False

        If xTextoIngresado.Contains(Separador) = True Then
            Punto = True
            PosicionSeparador = InStr(1, xTextoIngresado, Separador, CompareMethod.Text)
        Else
            Punto = False
        End If

        If (Char.IsDigit(xIngreso) Or xIngreso = Separador) Then
            'validar si el usuario esta ingresando el caracter (punto)
            If (xIngreso = Separador) Then
                ' limitar el numero de puntos en el textbox
                If (Punto = False) Then
                    'si no existe ningun punto en el textbox, permitir el caracter
                    Return False
                    Punto = True
                End If
            End If
        End If

        If PosicionSeparador > 0 And Not (Char.IsControl(xIngreso)) Then
            If xTextoIngresado.Length > PosicionSeparador + (xPrecision - 1) Then '(xPrecision-1) lugares decimales
                Return True
            End If
        End If
        If (Char.IsNumber(xIngreso)) Then ' Al  pulsar un Numero
            Return False '; //Se acepta (todo OK)
        ElseIf (Char.IsControl(xIngreso)) Then  ' Al  pulsar teclas como Borrar y eso.
            Return False '; //Se acepta (todo OK)
        Else '//Para todo lo demas
            Return True '; //No se acepta (si pulsas cualquier otra cosa pues no se envia)
        End If
    End Function
End Module
