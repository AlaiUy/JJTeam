using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Linea
    {
        private Articulo _objArticulo;
        private string _Descripcion;
        private decimal _Cantidad;
        private decimal _Descuento;
        private int _NumLinea;
        private int _CodMoneda;

        public Articulo Articulo
        {
            get
            {
                return _objArticulo;
            }

            set
            {
                _objArticulo = value;
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

        public decimal Descuento
        {
            get
            {
                return _Descuento;
            }

            set
            {
                _Descuento = value;
            }
        }

        public int NumLinea
        {
            get
            {
                return _NumLinea;
            }

            set
            {
                _NumLinea = value;
            }
        }

        public int CodMoneda
        {
            get
            {
                return _CodMoneda;
            }

            set
            {
                _CodMoneda = value;
            }
        }

        public Linea(Articulo xobjArticulo, string xDescripcion, decimal xCantidad, decimal xDescuento, int xNumLinea)
        {
            _objArticulo = xobjArticulo;
            _Descripcion = xDescripcion;
            _Cantidad = xCantidad;
            _Descuento = xDescuento;
            _NumLinea = xNumLinea;
        }

        public decimal SubTotal()
        {
            return _objArticulo.Precio() * _Cantidad;
        }

        public decimal Precio() //Con iva
        {
            return (_objArticulo.Precio() * (1 + (_objArticulo.Iva / 100)));
        }

        public decimal Total() //Total con iva
        {
            return (this._objArticulo.Precio() * (1 + (_objArticulo.Iva / 100))) * _Cantidad;
        }

        public decimal TotalDescuento() //Total Con descuento
        {
            return ((this._objArticulo.Precio() * (1 + (this._objArticulo.Iva / 100))) * ((100 - _Descuento) / 100)) * _Cantidad;
        }

        public decimal ImporteDescuento()
        {
            return (Total() - TotalDescuento()) * _Cantidad;
        }
    }
}
