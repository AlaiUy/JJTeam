using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Facturalin
    {
        private int _Numero;
        private string _Serie;
        private int _codArticulo;
        private string _Descripcion;
        private decimal _Precio;
        private decimal _Iva;
        private decimal _Cantidad;
        private decimal _Descuento;
        private int _NumLinea;

        public int CodArticulo
        {
            get
            {
                return _codArticulo;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
        }

        public decimal Precio
        {
            get
            {
                return _Precio;
            }
        }

        public decimal Iva
        {
            get
            {
                return _Iva;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }
        }

        public decimal Descuento
        {
            get
            {
                return _Descuento;
            }
        }

        public int NumLinea
        {
            get
            {
                return _NumLinea;
            }
        }

        public Facturalin(int xNumero,string xSerie,int xNumeroLinea, int xCodArticulo, string xDescripcion, decimal xPrecio, decimal xIva, decimal xCantidad,decimal xDescuento)
        {
            _Numero = xNumero;
            _Serie = xSerie;
            _NumLinea = xNumeroLinea;
            _Cantidad = xCantidad;
            _Descuento = xDescuento;
            _codArticulo = xCodArticulo;
            _Descripcion = xDescripcion;
            _Precio = xPrecio;
            _Iva = xIva;
        }

        public Facturalin(int xNumeroLinea, int xCodArticulo, string xDescripcion, decimal xPrecio, decimal xIva, decimal xCantidad, decimal xDescuento)
        {
            _Numero = -1;
            _NumLinea = xNumeroLinea;
            _Cantidad = xCantidad;
            _Descuento = xDescuento;
            _codArticulo = xCodArticulo;
            _Descripcion = xDescripcion;
            _Precio = xPrecio;
            _Iva = xIva;
        }




    }
}
