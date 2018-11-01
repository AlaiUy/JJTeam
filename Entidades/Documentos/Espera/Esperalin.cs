using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Esperalin
    {
        private int _CodArticulo;
        private string _Descripcion;
        private decimal _Precio;
        private decimal _Iva;
        private decimal _Cantidad;
        private decimal _Descuento;
        private int _NumLinea;

        public Esperalin(int xNumeroLinea)
        {
            _NumLinea = xNumeroLinea;
        }

        public int CodArticulo
        {
            get
            {
                return _CodArticulo;
            }

            set
            {
                _CodArticulo = value;
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

        public decimal Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        public decimal Iva
        {
            get
            {
                return _Iva;
            }

            set
            {
                _Iva = value;
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
        }

        

    }
}
