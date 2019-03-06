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
        private decimal _cargo;

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

        public decimal Cargo
        {
            get
            {
                return _cargo;
            }

            set
            {
                _cargo = value;
            }
        }

        public Tarifa(int xCodigo, string xNombre,decimal xCargo)
        {
            _codigo = xCodigo;
            _nombre = xNombre;
            _cargo = xCargo;
        }



        public override string ToString()
        {
            return _codigo + " - " + _nombre;
        }
    }
}
