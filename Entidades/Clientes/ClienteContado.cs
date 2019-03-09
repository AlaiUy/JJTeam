using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class ClienteContado
    {

        private int _Codigo;
        private String _Cedula;
        private String _Rut;
        private String _Nombre;
        private String _Direccion;
        private String _Telefono;

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

        public string Cedula
        {
            get
            {
                return _Cedula;
            }

            set
            {
                _Cedula = value;
            }
        }

        public string Rut
        {
            get
            {
                return _Rut;
            }

            set
            {
                _Rut = value;
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

        public ClienteContado(int xCodigo, String xCedula, String xRut, String xNombre, String xDireccion, String xTelefono)
        {
            _Codigo = xCodigo;
            _Cedula = xCedula;
            _Rut = xRut;
            _Nombre = xNombre;
            _Direccion = xDireccion;
            _Telefono = xTelefono;
            
        }

    }
}
