using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Compra : Documento
    {
        public Compra(DateTime xFecha, string xSerie, string xCaja, int xMoneda, int xZ, int xVendedor) : base(xFecha, xSerie, xCaja, xMoneda, xZ, xVendedor)
        {

        }
    }
}
