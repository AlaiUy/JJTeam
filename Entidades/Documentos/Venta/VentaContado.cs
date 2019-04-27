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

        public VentaContado(int xDocumento,ClienteContado xCliente,DateTime xFecha) : base(xFecha)
        {
            _Cliente = xCliente;
        }

        public VentaContado(int xDocumento,ClienteContado xCliente, DateTime xFecha,int  xNumero, string xSerie, string xCodCaja, int xCodMoneda, int xZ, int xCodVendedor) : base(xNumero, xSerie, xCodCaja, xFecha, xCodMoneda, xZ,xCodVendedor)
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
