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

        /// <summary>
        /// El costo total de la linea (Costo * Cantidad)
        /// </summary>
        public override decimal SubTotal()
        {
            return _Costo * Cantidad;
        }
        /// <summary>
        /// Devuelve el costo + iva
        /// </summary>
        public override decimal Precio() //Con iva
        {
            return (_Costo * (1 + (Articulo.Iva.Valor / 100)));
        }


        /// <summary>
        /// Devuelve el valor total de la linea
        /// </summary>
        public override decimal TotalconIva() //Total con iva
        {
     
            return (_Costo * (1 + (Articulo.Iva.Valor / 100))) * Cantidad;
        }


        /// <summary>
        /// Devuelve el valor incluyendo el descuento asignado
        /// </summary>
        public override decimal TotalConDescuento() //Total Con descuento
        {
            if (Descuento < 0)
            {
                return (TotalconIva() * (1+(- Descuento / 100)));
            }
            else
            {
                return (TotalconIva() * ((100 - Descuento) / 100));
            }
            
        }

        /// <summary>
        /// Devuelve el valor total de la linea
        /// </summary>
        public override decimal ImporteDescuentoTotal()
        {
            return (TotalconIva() - TotalConDescuento());
        }

    }
}
