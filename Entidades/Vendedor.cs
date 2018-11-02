using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Vendedor
    {
        private int _codigo;
        private string _nombre;

        public Vendedor(int xcodigo, string xnombre) {
            Codigo = xcodigo;
            Nombre = xnombre;
        }

        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
    }
}
