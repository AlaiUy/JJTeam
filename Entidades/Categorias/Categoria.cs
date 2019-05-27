using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Categoria
    {
        private int _codigo;
        private string _nombre;

        public int Codigo
        {
            get
            {
                return _codigo;
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

        protected  Categoria() {
            _codigo = -1;
        }

        protected Categoria(int xCodigo, string xDescripcion)
        {
            _codigo = xCodigo;
            _nombre = xDescripcion;

        }

        public override string ToString()
        {
           return  _codigo + " - " + _nombre;
        }
    }
}
