using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Vendedor
    {
        private int _Codigo;
        private string _Nombre;
        private bool _Activo;

        public Vendedor(int xcodigo, string xnombre,bool xActivo) {
            _Codigo = xcodigo;
            _Nombre = xnombre;
            _Activo = xActivo;
        }

        public Vendedor(string xnombre)
        {
            _Codigo = -1;
            _Nombre = xnombre;
            _Activo = true;
        }

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
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

        public bool Activo
        {
            get
            {
                return _Activo;
            }

            set
            {
                _Activo = value;
            }
        }

        public override string ToString()
        {
            return _Codigo + " - " + _Nombre;
        }
    }
}
