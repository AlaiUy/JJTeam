using JJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class VentaContado : Documento
    {
        private ClienteContado _Cliente;

        


        public VentaContado(ClienteContado xCliente, DateTime xFecha, string xSerie, string xCodCaja, int xCodMoneda, int xZ, int xCodVendedor, decimal xCotizacion, bool xpresupuesto) : base(xFecha,xSerie, xCodCaja, xCodMoneda, xZ,xCodVendedor,xCotizacion)
        {
            _Cliente = xCliente;
            base.Presupuesto = xpresupuesto;
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
