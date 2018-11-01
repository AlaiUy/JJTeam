using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public  class Venta:Factura
    {
        

        public Venta (int xNumero, String xSerie, DateTime xFecha, int xcodvendedor, Caja xCaja, int xCodMoneda, int xCoddocumento)
        {
            
        }

        

        public override void AgregarLineas(List<object> xLineas)
        {
            foreach (object Linea in xLineas)
            {
                Lineas.Add((VentaLin)Linea);
            }
        }

        public override void AgregarLinea(object Linea)
        {
            Lineas.Add((VentaLin)Linea);
        }
    }
}
