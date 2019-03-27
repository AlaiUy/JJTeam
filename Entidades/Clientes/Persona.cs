using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Persona
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
        private List<Cuenta> _Cuentas;
        private int _Tipo;
        private decimal _limite;

        public Persona(int xCodigo, string xCedula, string xNombre, string xApellido, string xDireccion, string xDirNumero, string xNumeroApto, string xtelefono, string xcelular, string xPais, string xciudad, Categoria xobjCategoria, string xemail, int xActiva)
        {
            _CodCliente = xCodigo;
            Cedula = xCedula;
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

        public Persona(string xCedula, string xNombre, string xApellido, string xDireccion, string xDirNumero, string xNumeroApto, string xtelefono, string xcelular, string xPais, string xciudad, Categoria xobjCategoria, string xemail, int xActiva)
        {
            Cedula = xCedula;
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

        public List<Cuenta> Cuentas
        {
            get
            {
                return _Cuentas;
            }
        }

        public decimal Limite
        {
            get
            {
                return _limite;
            }

            set
            {
                _limite = value;
            }
        }

        public void AddCuenta(Cuenta xCuenta)
        {
            if (_Cuentas == null)
                _Cuentas = new List<Cuenta>();
            _Cuentas.Add(xCuenta);
        }

        public void AddCuentas(List<Cuenta> Cuentas)
        {
            foreach (Cuenta C in Cuentas)
                AddCuenta(C);
        }

        public Cuenta getCuenta(int xIdCuenta)
        {
            if (_Cuentas == null)
                return null;

            foreach (Cuenta C in _Cuentas)
                if (C.Codigo == xIdCuenta)
                    return C;
            return null;
        }
            
    }
}
