using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades.Ventas
{
    public class Ventalin
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
        }

        public int Referencia
        {
            get
            {
                return _Referencia;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
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
                return _iva;
            }
        }

        public decimal Dto
        {
            get
            {
                return _dto;
            }
        }
    }
}
