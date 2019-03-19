using JJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class DevolucionCuenta : Factura
    {
        private int _CodCLiente;
        private Cuenta _Cuenta;
        private int _CodTarifa;
        private String _SerieReferencia;
        private int _NumeroReferencia;

        public string SerieReferencia
        {
            get
            {
                return _SerieReferencia;
            }

            set
            {
                _SerieReferencia = value;
            }
        }

        public int NumeroReferencia
        {
            get
            {
                return _NumeroReferencia;
            }

            set
            {
                _NumeroReferencia = value;
            }
        }

        public int CodCLiente
        {
            get
            {
                return _CodCLiente;
            }

            set
            {
                _CodCLiente = value;
            }
        }

        public Cuenta Cuenta
        {
            get
            {
                return _Cuenta;
            }

            set
            {
                _Cuenta = value;
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

        public DevolucionCuenta(int xNumero, string xSerie, string xCodCaja, DateTime xFecha, int xCodMoneda, int xZ, int xcodvendedor, int xcoddocumento, Cuenta xCuenta, int xCodCliente, int xCodTarifa, string xSerieReferencia, int xNumeroReferencia) : base(xNumero, xSerie, xCodCaja, xFecha, xCodMoneda, xZ, xcodvendedor, xcoddocumento)
        {
            _CodCLiente = xCodCliente;
            _Cuenta = xCuenta;
            _CodTarifa = xCodTarifa;
            _SerieReferencia = xSerieReferencia;
            _NumeroReferencia = xNumeroReferencia;
        }


    }
}

