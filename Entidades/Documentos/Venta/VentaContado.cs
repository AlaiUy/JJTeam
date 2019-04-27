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

        


        public VentaContado(ClienteContado xCliente, DateTime xFecha, string xSerie, string xCodCaja, int xCodMoneda, int xZ, int xCodVendedor) : base(xFecha,xSerie, xCodCaja, xCodMoneda, xZ,xCodVendedor)
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
