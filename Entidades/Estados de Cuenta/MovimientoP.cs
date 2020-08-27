using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class MovimientoP : Movimiento
    {
        

        public MovimientoP(DateTime xFecha, int xNumeroInterno, string xSerieInterna, int xCodMoneda, decimal xImporte) : base(xFecha, xNumeroInterno, xSerieInterna, xCodMoneda, xImporte)
        {

        }

        public MovimientoP(DateTime xFecha, int xNumeroInterno, string xSerieInterna, int xCodMoneda, decimal xImporte,int xLinea,char xEstado) : base(xFecha, xNumeroInterno, xSerieInterna, xCodMoneda, xImporte,xEstado,xLinea)
        {

        }






    }
}
