using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class PresupuestoLin
    {
        private Articulo _Articulo;
        private decimal _SubTotal;
        private decimal _Iva;
        private decimal _Cantidad;
        private string _Descripcion;
        private decimal _descuento;
        



        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public Articulo Articulo
        {
            get
            {
                return _Articulo;
            }
        }

        public decimal SubTotal
        {
            get
            {
                return _SubTotal;
            }

            set
            {
                _SubTotal = value;
            }
        }

        public decimal Iva
        {
            get
            {
                return _Iva;
            }
        }



        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public decimal Descuento
        {
            get
            {
                return _descuento;
            }

            set
            {
                _descuento = value;
            }
        }

        public PresupuestoLin(Articulo xobjArticulo, string xDescripcion, decimal xCantidad,decimal xSubTotal,decimal xIva,decimal xDescuento)
        {
            _Articulo = xobjArticulo;
            _Descripcion = xDescripcion;
            _Cantidad = xCantidad;
            _SubTotal = xSubTotal;
            _Iva = xIva;
            _descuento = xDescuento;
        }

        public decimal Total()
        {
            if(_descuento < 0)
                return (_SubTotal * (1+ (-_descuento) / 100)) * (1 + (_Iva / 100)) * _Cantidad;
            else
                return (_SubTotal / (1 + (_descuento) / 100)) * (1 + (_Iva / 100)) * _Cantidad;
        }
    }
}
