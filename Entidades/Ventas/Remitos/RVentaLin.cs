using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades.Ventas.Remitos
{
    public class RVentaLin
    {
        
        private int _Linea;
        private int _CodArticulo;
        private int _Referencia;
        private string _Descripcion;
        private decimal _Cantidad;
        private decimal _Precio;
        private decimal _iva;
        private decimal _dto;

        public int Linea
        {
            get
            {
                return _Linea;
            }
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

        public int Referencia
        {
            get
            {
                return _Referencia;
            }

            set
            {
                _Referencia = value;
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
                return _iva;
            }

            set
            {
                _iva = value;
            }
        }

        public decimal Dto
        {
            get
            {
                return _dto;
            }

            set
            {
                _dto = value;
            }
        }
    }
}
