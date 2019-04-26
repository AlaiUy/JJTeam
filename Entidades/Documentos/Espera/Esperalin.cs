using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Esperalin
    {
        private Articulo _objArticulo;
        private string _Descripcion;
        private decimal _Cantidad;
        private decimal _Descuento;
        private int _NumLinea;
        private int _CodMoneda;

        public Articulo ObjArticulo
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
        }

        public Esperalin()
        {


        }
        public Esperalin(Articulo xobjArticulo, String xDescripcion, Decimal xCantidad, Decimal xDescuento, int xNumLinea)
        {
            _objArticulo = xobjArticulo;
            _Descripcion = xDescripcion;
            _Cantidad = xCantidad;
            _Descuento = xDescuento;
            _NumLinea = xNumLinea;
        }

      

        public decimal PrecioUnitarioConIva()
        {
            
            return (_objArticulo.Precio()  * (1+(_objArticulo.Iva / 100)));
        }

        public decimal PrecioTotalConIva()
        {
            return (this._objArticulo.Precio() * (1 + (_objArticulo.Iva/ 100)))*this.Cantidad;
        }

        public decimal PrecioTotalConDescuento()
        {
            return (((this._objArticulo.Precio() * (1 + (this._objArticulo.Iva / 100)))*this.Descuento)/100) * this.Cantidad;
        }

        public decimal ImporteDescuento()
        {
            return (PrecioTotalConIva()-(((this._objArticulo.Precio() * (1 + (this._objArticulo.Iva / 100))) * this.Descuento) / 100)) * this.Cantidad;
        }


    }

}
