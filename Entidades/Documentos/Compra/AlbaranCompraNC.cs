using System;

namespace JJ.Entidades
{
    public class AlbaranCompraNC : AlbaranCompra
    {
        public AlbaranCompraNC(string xSerie, DateTime xFecha, int xCodproveedor, Moneda xMoneda) : base(xSerie, xFecha, xCodproveedor, xMoneda)
        {

        }

        public override int Tipodoc()
        {
            return 21;
        }

        public override char Estado()
        {
            return 'P';
        }

        public override decimal ImporteTesoreria()
        {
            return base.ImporteTesoreria()*-1;
        }
    }
}
