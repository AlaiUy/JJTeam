using JJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class DevolucionContado : Factura
    {
        private ClienteContado _Cliente;
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

        public ClienteContado Cliente
        {
            get
            {
                return _Cliente;
            }

            set
            {
                _Cliente = value;
            }
        }

        public DevolucionContado(int xNumero, string xSerie, string xCodCaja, DateTime xFecha, int xCodMoneda, int xZ, int xcodvendedor, int xcoddocumento, string xSerieReferencia, int xNumeroReferencia, ClienteContado xCliente) : base(xNumero, xSerie, xCodCaja, xFecha, xCodMoneda, xZ, xcodvendedor, xcoddocumento)
        {
            _Cliente = xCliente;
            _SerieReferencia = xSerieReferencia;
            _NumeroReferencia = xNumeroReferencia;
        }

       
    }
}


