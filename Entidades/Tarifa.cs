using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Tarifa
    {
        private int _codigo;
        private string _nombre;
        private bool _activa;

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

        public bool Activa
        {
            get
            {
                return _activa;
            }

            set
            {
                _activa = value;
            }
        }

        public Tarifa(int xCodigo, string xNombre)
        {
            _codigo = xCodigo;
            _nombre = xNombre;
        }

        public Tarifa()
        {

        }

        public override string ToString()
        {
            return _codigo + " - " + _nombre;
        }
    }
}
