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
        private int _CodTarifa;
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

        public VentaCuenta(int xCodDocumento,int xCodCLiente,Cuenta xCuenta) :base(xCodDocumento)
        {
            _CodCLiente = xCodCLiente;
            _Cuenta = xCuenta;
        }

        public VentaCuenta(int xNumero, string xSerie, string xCodCaja, DateTime xFecha, int xCodMoneda, int xZ, int xcodvendedor, int xcoddocumento, Cuenta xCuenta,int xCodCliente, int xCodTarifa) : base(xNumero, xSerie, xCodCaja, xFecha, xCodMoneda , xZ, xcodvendedor , xcoddocumento)
        {
            _CodCLiente = xCodCliente;
            _Cuenta = xCuenta;
            _CodTarifa = xCodTarifa;
        }

        public VentaCuenta(DateTime xFecha, int xDocumento, int xCodCLiente, Cuenta xCuenta) : base(xFecha, xDocumento)
        {
            _CodCLiente = xCodCLiente;
            _Cuenta = xCuenta;
        }

        
    }
}
