using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Moneda
    {
        private int _Codigo;
        private string _Nombre;
        private string _SubFijo;
        private decimal _Coeficiente;

        public int Codigo
        {
            get
            {
                return _Codigo;
            }
            
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string SubFijo
        {
            get
            {
                return _SubFijo;
            }

            set
            {
                _SubFijo = value;
            }
        }

        public Moneda() { }

        public Moneda(int xCodigo) {
            _Codigo = xCodigo;
        }

        public Moneda(int xCodigo, string xNombre, string xSubFijo)
        {
            _Codigo = xCodigo;
            _Nombre = xNombre;
            _SubFijo = xSubFijo;
        }

        public override string ToString()
        {
            return _Codigo + " - " + _Nombre;
        }
    }
}
