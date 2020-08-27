using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Proveedor
    {
        private int _codigo;
        private string _nombre;
        private string _rz;
        private string _rut;
        private string _direccion;
        private string _dirnumero;
        private string _telefono;
        private string _celular;
        private int _categoria;
        private string _email;
        private string _Comentarios;
        private int _codMoneda;

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

        public string Rz
        {
            get
            {
                return _rz;
            }

            set
            {
                _rz = value;
            }
        }

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Dirnumero
        {
            get
            {
                return _dirnumero;
            }

            set
            {
                _dirnumero = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Celular
        {
            get
            {
                return _celular;
            }

            set
            {
                _celular = value;
            }
        }

        public int Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Comentarios
        {
            get
            {
                return _Comentarios;
            }

            set
            {
                _Comentarios = value;
            }
        }

        public int CodMoneda
        {
            get
            {
                return _codMoneda;
            }
        }

        public Proveedor(int xCodmoneda) {
            _codMoneda = xCodmoneda;
        }

        public Proveedor(int xCodProveedor,int xCodmoneda)
        {
            _codigo = xCodProveedor;
            _codMoneda = xCodmoneda;
        }

        public override string ToString()
        {
            return _codigo + " - " + _nombre;
        }
    }
}
