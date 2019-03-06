using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Cuenta
    {
        private int _Codigo;
        private int _CodTipo;
        private string _RazonSocial;
        private string _Direccion;
        private string _NumDireccion;
        private string _Rut;
        private string _Telefono;
        private string _Celular;
        private string _EmailPrincipal;
        private byte _Activa;
       

        public Cuenta(int xCodigo, int xCodTipo, string xRazonSocial, string xDireccion, string xNumDireccion, string xRut, string xTelefono, string xCelular, string xEmailPrincipal, byte xActiva)
        {
            Codigo = xCodigo;
            CodTipo = xCodTipo;
            RazonSocial = xRazonSocial;
            Direccion = xDireccion;
            NumDireccion = xNumDireccion;
            Rut = xRut;
            Telefono = xTelefono;
            Celular = xCelular;
            EmailPrincipal = xEmailPrincipal;
            Activa = xActiva;
            
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

        public int CodTipo
        {
            get
            {
                return _CodTipo;
            }

            set
            {
                _CodTipo = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return _RazonSocial;
            }

            set
            {
                _RazonSocial = value;
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

        public string EmailPrincipal
        {
            get
            {
                return _EmailPrincipal;
            }

            set
            {
                _EmailPrincipal = value;
            }
        }

        public byte Activa
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

        public string NumDireccion
        {
            get
            {
                return _NumDireccion;
            }

            set
            {
                _NumDireccion = value;
            }
        }
    }
}
