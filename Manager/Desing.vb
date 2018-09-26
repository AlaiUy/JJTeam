Module Desing
    Public Sub Redondear(ByRef xObj)
        Dim Region As New Drawing2D.GraphicsPath()
        Region.StartFigure()
        Region.AddArc(New Rectangle(0, 0, 10, 10), 180, 90)
        Region.AddLine(10, 0, xObj.Width - 10, 0)
        Region.AddArc(New Rectangle(xObj.Width - 10, 0, 10, 10), -90, 90)
        Region.AddLine(xObj.Width, 10, xObj.Width, xObj.Height - 10)
        Region.AddArc(New Rectangle(xObj.Width - 10, xObj.Height - 10, 10, 10), 0, 90)
        Region.AddLine(xObj.Width - 10, xObj.Height, 10, xObj.Height)
        Region.AddArc(New Rectangle(0, xObj.Height - 10, 10, 10), 90, 90)
        Region.CloseFigure()
        xObj.Region = New Region(Region)
    End Sub
End Module
