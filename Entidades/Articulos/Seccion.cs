using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Seccion
    {
        private int _Codigo;
        private string _Nombre;

        public Seccion() { }

        public Seccion(int xCodigo, string xNombre) {
            _Codigo = xCodigo;
            _Nombre = xNombre;
        }

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

        public override bool Equals(object obj)
        {
            if((obj == null)|| !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }else
            {
                return _Codigo == ((Seccion)obj)._Codigo;
            }
        }

        public override string ToString()
        {
            return _Codigo + " - " + _Nombre;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
