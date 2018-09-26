using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class TipoCliente
    {
        private int _codigo;
        private string _nombre;

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

        public int Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public TipoCliente(int xCodigo, string xNombre)
        {
            _codigo = xCodigo;
            _nombre = xNombre;
        }

        public TipoCliente() { }
    }
}
