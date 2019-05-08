using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class CompraLin : Linea
    {
        private decimal _Costo = 0;

        

        public CompraLin(Articulo xobjArticulo, string xDescripcion, decimal xCantidad, decimal xDescuento, int xNumLinea,decimal xCosto) : base(xobjArticulo, xDescripcion, xCantidad, xDescuento, xNumLinea)
        {
            _Costo = xCosto;
        }

        public decimal Costo
        {
            get
            {
                return _Costo;
            }

            set
            {
                _Costo = value;
            }
        }

        public override decimal SubTotal()
        {
            return _Costo * Cantidad;
        }

        public override decimal Precio() //Con iva
        {
            return (_Costo * (1 + (Articulo.Iva / 100)));
        }

        public override decimal Total() //Total con iva
        {
            return (_Costo * (1 + (Articulo.Iva / 100))) * Cantidad;
        }

        public override decimal TotalDescuento() //Total Con descuento
        {
            return ((this.Costo* (1 + (this.Articulo.Iva / 100))) * ((100 - Descuento) / 100)) * Cantidad;
        }

        public override decimal ImporteDescuento()
        {
            return (this.Total() - this.TotalDescuento()) * Cantidad;
        }

    }
}
