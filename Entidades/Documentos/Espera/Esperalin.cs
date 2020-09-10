using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Esperalin:Linea
    {
        private decimal _Precio = 0;
        public Esperalin(Articulo xobjArticulo, String xDescripcion, Decimal xCantidad, Decimal xDescuento, int xNumLinea):base(xobjArticulo,xDescripcion,xCantidad,xDescuento,xNumLinea)
        {

            
        }

        public decimal ImporteLinea
        {
            get
            {
                if(_Precio == 0)
                    return base.Precio();
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }
    }

}
