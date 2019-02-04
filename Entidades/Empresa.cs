using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Empresa
    {
        private string _Nombre;
        private string _Razonsocial;
        private string _Rut;
        private string _Direccion;
        private string _Ciudad;
        private string _Pais;
        private string _Email;
        private string _Telefono;
        private Byte[] _Imagen;

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

        public string Razonsocial
        {
            get
            {
                return _Razonsocial;
            }
        }

        public string Rut
        {
            get
            {
                return _Rut;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return _Ciudad;
            }

            set
            {
                _Ciudad = value;
            }
        }

        public string Pais
        {
            get
            {
                return _Pais;
            }

            set
            {
                _Pais = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public byte[] Imagen
        {
            get
            {
                return _Imagen;
            }

            set
            {
                _Imagen = value;
            }
        }

        public Empresa(string xRazonSocial, string xRut) {
            _Rut = xRut;
            _Razonsocial = xRazonSocial;
        }
    }
}
