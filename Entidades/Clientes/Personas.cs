using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Personas
    {
        private int _CodCliente;
        private string _Cedula;
        private string _Rut;
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _DireccionNumero;
        private string _DireccionApto;
        private string _Telefono;
        private string _Celular;
        private string _Pais;
        private string _Ciudad;
        private Categoria _objCategoria;
        private string _Email;
        private int _Activa;      
        private IList<Cuenta> Cuentas;
        private int _Tipo;

        public Personas(int xCodigo, string xCedula, string xRut, string xNombre, string xApellido, string xDireccion, string xDirNumero, string xNumeroApto, string xtelefono, string xcelular, string xPais, string xciudad, Categoria xobjCategoria, string xemail, int xActiva)
        {
            CodCliente= xCodigo;
            Cedula = xCedula;
            Rut = xRut;
            Nombre = xNombre;
            Apellido = xApellido;
            Direccion = xDireccion;
            DireccionNumero = xDirNumero;
            DireccionApto = xNumeroApto;
            Telefono = xtelefono;
            Celular = xcelular;
            Pais = xPais;
            Ciudad = xciudad;
            ObjCategoria = xobjCategoria;
            Email = xemail;
            Activa = xActiva;


        }


        public int CodCliente
        {
            get
            {
                return _CodCliente;
            }

            set
            {
                _CodCliente = value;
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

        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
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

        public string DireccionNumero
        {
            get
            {
                return _DireccionNumero;
            }

            set
            {
                _DireccionNumero = value;
            }
        }

        public string DireccionApto
        {
            get
            {
                return _DireccionApto;
            }

            set
            {
                _DireccionApto = value;
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

        public string Celular
        {
            get
            {
                return _Celular;
            }

            set
            {
                _Celular = value;
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

        public Categoria ObjCategoria
        {
            get
            {
                return _objCategoria;
            }

            set
            {
                _objCategoria = value;
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

        public int Activa
        {
            get
            {
                return _Activa;
            }

            set
            {
                _Activa = value;
            }
        }

        public IList<Cuenta> Cuentas1
        {
            get
            {
                return Cuentas;
            }

            set
            {
                Cuentas = value;
            }
        }

            
    }
}
