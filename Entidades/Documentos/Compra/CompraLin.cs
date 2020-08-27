using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class CompraLin : Linea
    {
        private decimal _Costo = 0;
        private List<decimal> _Descuentos;

        

        public CompraLin(Articulo xobjArticulo, string xDescripcion, decimal xCantidad, decimal xDescuento, int xNumLinea,decimal xCosto) : base(xobjArticulo, xDescripcion, xCantidad, xDescuento, xNumLinea)
        {
            _Costo = xCosto;
            _Descuentos = new List<decimal>();
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

        public List<decimal> Descuentos
        {
            get
            {
                return _Descuentos;
            }

            set
            {
                _Descuentos = value;
            }
        }

        /// <summary>
        /// El costo total de la linea (Costo * Cantidad) con descuento sin iva
        /// </summary>
        public override decimal SubTotal()
        {
            decimal Importe = 0;
            Importe = _Costo * Cantidad;
            foreach (decimal Descuento in _Descuentos)
            {
                Importe = (Importe * ((100 - Descuento) / 100));

            }

            return Importe;
        }
        
        

        /// <summary>
        /// Devuelve el valor total de la linea
        /// </summary>
        public override decimal TotalconIva() //Total con iva
        {
            return SubTotal() * (1 + (Articulo.Iva.Valor / 100));
        }


        /// <summary>
        /// Devuelve el valor incluyendo el descuento asignado
        /// </summary>
        //public override decimal TotalConDescuento() //Total Con descuento
        //{
        //    if (Descuento < 0)
        //    {
        //        return (TotalconIva() * (1+(- Descuento / 100)));
        //    }
        //    else
        //    {
        //        return (TotalconIva() * ((100 - Descuento) / 100));
        //    }

        //}

        /// <summary>
        /// Devuelve el valor total de la linea
        /// </summary>
        public override decimal ImporteDescuentoTotal()
        {
            return (TotalconIva() - SubTotal());
        }

        

        public string stringDescuentos()
        {
            string xDescuento ="";
            foreach (decimal Index in _Descuentos)
            {
                if (Index > 0)
                {
                    xDescuento = xDescuento + " " + decimal.Round(Index, 2).ToString() + "%";
                }
                    
            }
            return xDescuento;
        }

    }
}
