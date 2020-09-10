using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class ReciboCompra : Recibo
    {

        public ReciboCompra(DateTime xFecha, string xRecibo, int xCodMoneda, int xNumero, List<Movimiento> xMovimientos) : base(xFecha, xRecibo, xCodMoneda, xNumero)
        {
            base._Movimientos = xMovimientos;
        }


        public  List<Movimiento> Movimientos
        {
            get
            {
                return _Movimientos;
            }
        }





        public override void AddMovimiento(Movimiento xMovimiento)
        {
            if (xMovimiento == null)
                return;

            if (xMovimiento.Estado == 'S')
                return;



            if ((_Movimientos.Find(Obj => Obj.Linea == xMovimiento.Linea && Obj.SerieInterna == xMovimiento.SerieInterna && Obj.NumeroInterno == xMovimiento.NumeroInterno) != null))
                return;

            _Movimientos.Add(xMovimiento);
        }

        public void AddMovimientos(List<Movimiento> xMovimientos)
        {
            foreach (Movimiento M in xMovimientos)
                AddMovimiento(M);

        }

        public override decimal Total()
        {
            decimal zSuma = 0;
            foreach (Movimiento M in _Movimientos)
            {
                zSuma += M.Importe;
            }
            return zSuma;
        }

        public override decimal Total(int xCodMoneda)
        {
                decimal zSuma = 0;
                foreach (Movimiento M in _Movimientos.FindAll(Obj => Obj.Moneda == xCodMoneda))
                {
                    zSuma += M.Importe;
                }
                return zSuma;
            
        }

        public override void upImporte(decimal xImporte, string xSerie, int xNumero, int xLinea)
        {
            return;
        }
    }
}
