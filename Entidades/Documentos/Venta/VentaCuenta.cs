using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public  class VentaCuenta:Factura
    {
        private int _CodCLiente;
        private Cuenta _Cuenta;

        public Cuenta Cuenta
        {
            get
            {
                return _Cuenta;
            }
            set{
                _Cuenta = value;
            }
        }

        public int CodCLiente
        {
            get
            {
                return _CodCLiente;
            }
        }

        public VentaCuenta(int xCodDocumento,int xCodCLiente,Cuenta xCuenta) :base(xCodDocumento)
        {
            _CodCLiente = xCodCLiente;
            _Cuenta = xCuenta;
        }

        public VentaCuenta(int xNumero, string xSerie, DateTime xFecha, int xDocumento, int xCodCLiente, Cuenta xCuenta) : base(xNumero, xSerie, xFecha, xDocumento)
        {
            _CodCLiente = xCodCLiente;
            _Cuenta = xCuenta;
        }

        public VentaCuenta(DateTime xFecha, int xDocumento, int xCodCLiente, Cuenta xCuenta) : base(xFecha, xDocumento)
        {
            _CodCLiente = xCodCLiente;
            _Cuenta = xCuenta;
        }

        
    }
}
