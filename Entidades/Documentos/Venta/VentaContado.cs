using JJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class VentaContado : Factura
    {
        private ClienteContado _Cliente;

        public VentaContado(int xCodDocumento, ClienteContado xCliente) : base(xCodDocumento)
        {
            _Cliente = xCliente;
        }

        public VentaContado(DateTime xFecha, int xDocumento,ClienteContado xCliente) : base(xFecha, xDocumento)
        {
            _Cliente = xCliente;
        }

        public VentaContado(int xNumero, string xSerie, string xCodCaja, DateTime xFecha, int xCodMoneda, int xZ, int xcodvendedor, int xcoddocumento, ClienteContado xCliente) : base(xNumero, xSerie, xCodCaja, xFecha, xCodMoneda, xZ,xcodvendedor, xcoddocumento)
        {
            _Cliente = xCliente;
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
    }
}
