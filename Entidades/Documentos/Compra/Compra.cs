using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Compra : Documento
    {
        private int _CodProveedor;
        private int _NumFacturaProveedor;
        private string _SerieFacturaProveedor;

        public Compra(DateTime xFecha, string xSerie, string xCaja, int xMoneda, int xZ, int xVendedor, decimal xCotizacion) : base(xFecha, xSerie, xCaja, xMoneda, xZ, xVendedor, xCotizacion)
        {

        }

        public int CodProveedor
        {
            get
            {
                return _CodProveedor;
            }
        }

        public int NumFacturaProveedor
        {
            get
            {
                return _NumFacturaProveedor;
            }
        }

        public string SerieFacturaProveedor
        {
            get
            {
                return _SerieFacturaProveedor;
            }
        }
    }
}
