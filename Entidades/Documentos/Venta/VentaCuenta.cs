using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public  class VentaCuenta:Factura
    {
        private Persona _Persona;
        private int _Cuenta;
        private int _CodTarifa;
        

        public int CodTarifa
        {
            get
            {
                return _CodTarifa;
            }

            set
            {
                _CodTarifa = value;
            }
        }

        public Persona Persona
        {
            get
            {
                return _Persona;
            }
        }

        public int Cuenta
        {
            get
            {
                return _Cuenta;
            }
        }

        public VentaCuenta(int xCodDocumento,Persona xPersona,int xCodCuenta) :base(xCodDocumento)
        {
            _Persona  = xPersona;
            _Cuenta = xCodCuenta;
        }

        public VentaCuenta(int xCodDocumento, Persona xPersona, int xCodCuenta, DateTime xFecha, int xNumero, string xSerie, string xCodCaja, int xCodMoneda, int xZ, int xcodvendedor, int xCodTarifa) : base(xNumero, xSerie, xCodCaja, xFecha, xCodMoneda , xZ,xcodvendedor)
        {
            _Persona = xPersona;
            _Cuenta = xCodCuenta;
            _CodTarifa = xCodTarifa;
        }

        public VentaCuenta(int xCodDocumento, Persona xPersona, int xCodCuenta,DateTime xFecha) : base(xFecha)
        {
            _Persona = xPersona;
            _Cuenta = xCodCuenta;
        }

        
    }
}
