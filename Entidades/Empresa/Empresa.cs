using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Empresa
    {
        private int _CodEmpresa;
        private string _Nombre;
        private string _Razonsocial;
        private string _Rut;
        private string _Direccion;
        private string _Ciudad;
        private string _Pais;
        private string _Email;
        private string _Telefono;
        private Byte[] _Imagen;
        private List<Grupo> _Grupos;
        private List<Parametro> _Parametros;
        private List<Caja> _Cajas;
        private List<Seriedoc> _Series;
        private List<Equipo> _Equipos;
        private List<Iva> _Ivas;


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

        public int CodEmpresa
        {
            get
            {
                return _CodEmpresa;
            }
        }

        public List<Grupo> Grupos
        {
            get
            {
                return _Grupos;
            }

            set
            {
                _Grupos = value;
            }
        }

        public List<Parametro> Parametros
        {
            get
            {
                return _Parametros;
            }

            set
            {
                _Parametros = value;
            }
        }

        public List<Seriedoc> Series
        {
            get
            {
                return _Series;
            }

            set
            {
                _Series = value;
            }
        }

        public List<Caja> Cajas
        {
            get
            {
                return _Cajas;
            }

            set
            {
                _Cajas = value;
            }
        }

        public List<Equipo> Equipos
        {
            get
            {
                return _Equipos;
            }

            set
            {
                _Equipos = value;
            }
        }

        public List<Iva> Ivas
        {
            get
            {
                return _Ivas;
            }

            set
            {
                _Ivas = value;
            }
        }

        public Empresa(int xcodEmpresa,string xRazonSocial, string xRut)
        {
            _CodEmpresa = xcodEmpresa;
            _Rut = xRut;
            _Razonsocial = xRazonSocial;
        }
        public Empresa(string xRazonSocial, string xRut) {
            _CodEmpresa = -1;
            _Rut = xRut;
            _Razonsocial = xRazonSocial;
        }
    }
}
