using JJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades.Documentos.Venta
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

        public VentaContado(int xNumero, string xSerie, DateTime xFecha, int xDocumento,ClienteContado xCliente) : base(xNumero, xSerie, xFecha, xDocumento)
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
