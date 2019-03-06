using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public  class Venta:Factura
    {

        public Venta(int xCodDocumento) :base(xCodDocumento)
        {

        }

        public Venta(int xNumero, string xSerie, DateTime xFecha, int xDocumento) : base(xNumero, xSerie, xFecha, xDocumento)
        {

        }

        public Venta(DateTime xFecha, int xDocumento) : base(xFecha, xDocumento)
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
