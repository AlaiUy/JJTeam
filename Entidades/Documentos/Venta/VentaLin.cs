using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class VentaLin : Linea
    {
        //base(xNumero,xSerie,xNumeroLinea,xCodArticulo,xDescripcion,xPrecio,xIva, xCantidad, xDescuento)
        public VentaLin(string xSerie,int xNumero,int xNumeroLinea, Articulo xArticulo, string xDescripcion, decimal xCantidad, decimal xDescuento) : base(xArticulo,xDescripcion,xCantidad,xDescuento,xNumeroLinea)
        {

        }

        //base(xNumeroLinea,xCodArticulo,xDescripcion,xPrecio,xIva,xCantidad,xDescuento)
        public VentaLin(int xNumeroLinea, Articulo xArticulo, string xDescripcion, decimal xCantidad,decimal xDescuento) : base(xArticulo,xDescripcion,xCantidad,xDescuento,xNumeroLinea)
        {}
    }
}
