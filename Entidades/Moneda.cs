using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Moneda
    {
        private int _Codigo;
        private string _Nombre;
        private string _SubFijo;
        private decimal _Coeficiente;
        private decimal _Cotizacion;

        public int Codigo
        {
            get
            {
                return _Codigo;
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

        public string SubFijo
        {
            get
            {
                return _SubFijo;
            }

            set
            {
                _SubFijo = value;
            }
        }

        public decimal Coeficiente
        {
            get
            {
                return _Coeficiente;
            }

            set
            {
                _Coeficiente = value;
            }
        }

        public decimal Cotizacion
        {
            get
            {
                return _Cotizacion;
            }

            set
            {
                _Cotizacion = value;
            }
        }

        public Moneda() { }

        public Moneda(int xCodigo) {
            _Codigo = xCodigo;
        }

        public Moneda(int xCodigo, string xNombre, string xSubFijo, decimal xCoeficiente,decimal xCotizacion)
        {
            _Codigo = xCodigo;
            _Nombre = xNombre;
            _SubFijo = xSubFijo;
            _Coeficiente = xCoeficiente;
            _Cotizacion = xCotizacion;
        }

        public override string ToString()
        {
            return _Codigo + " - " + _Nombre;
        }
    }
}
