﻿using System;
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

        public virtual decimal SubTotal()
        {
            return _objArticulo.Precio() * _Cantidad;
        }

        public virtual decimal Precio() //Con iva
        {
            return _objArticulo.PrecioIva();
        }

        public virtual decimal TotalconIva() //Total con iva
        {
            return (this._objArticulo.Precio() * (1 + (_objArticulo.Iva.Valor / 100))) * _Cantidad;
        }

        public virtual decimal TotalConDescuento() //Total Con descuento
        {
            return (TotalconIva() * ((100 - _Descuento) / 100));

                //((this._objArticulo.Precio() * (1 + (this._objArticulo.Iva / 100))) * ((100 - _Descuento) / 100)) * _Cantidad;
        }

        public virtual decimal IvaTotal()
        {
            return (TotalConDescuento() - (TotalConDescuento() / (1+(_objArticulo.Iva.Valor/100))));
        }

        public virtual decimal ImporteDescuentoTotal()
        {
            return (TotalconIva() - TotalConDescuento());
        }
    }
}
