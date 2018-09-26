using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Marca
    {
        private int _Codigo;
        private string _Nombre;

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

        public Marca()
        {

        }

        public Marca(int xCodigo, string xNombre)
        {
            _Codigo = xCodigo;
            _Nombre = xNombre;
        }

        public override string ToString()
        {
            return _Codigo + " - " + _Nombre;
        }
    }
}
