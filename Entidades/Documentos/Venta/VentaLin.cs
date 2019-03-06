using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class VentaLin : Facturalin
    {
        public VentaLin(string xSerie,int xNumero,int xNumeroLinea, int xCodArticulo, string xDescripcion, decimal xPrecio, decimal xIva, decimal xCantidad, decimal xDescuento) : base(xNumero,xSerie,xNumeroLinea,xCodArticulo,xDescripcion,xPrecio,xIva, xCantidad, xDescuento)
        {

        }
        public VentaLin(int xNumeroLinea, int xCodArticulo, string xDescripcion, decimal xPrecio, decimal xIva, decimal xCantidad,decimal xDescuento) : base(xNumeroLinea,xCodArticulo,xDescripcion,xPrecio,xIva,xCantidad,xDescuento)
        {

        }
    }
}
