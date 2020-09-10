using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class PreRecibo : Recibo
    {

        public PreRecibo(DateTime xFecha, string xRecibo) : base(xFecha, xRecibo)
        {
            base._Movimientos = new List<Movimiento>();
        }



        public override void AddMovimiento(Movimiento xMovimiento)
        {
            {
                if (xMovimiento == null)
                    return;

                if (xMovimiento.Estado == 'S')
                    return;

                if (xMovimiento.Saldar == 0)
                    return;

                if ((Movimientos.Find(Obj => Obj.Linea == xMovimiento.Linea && Obj.SerieInterna == xMovimiento.SerieInterna && Obj.NumeroInterno == xMovimiento.NumeroInterno) != null))
                    return;

                Movimientos.Add(xMovimiento);
            }
        }

        public  List<Movimiento> Movimientos
        {
            get
            {
                return base._Movimientos;
            }

            set
            {
                base._Movimientos = value;
            }
        }

        public override decimal Total(int xCodMoneda)
        {
            decimal zSuma = 0;
            foreach (Movimiento M in Movimientos.FindAll(Obj => Obj.Moneda == xCodMoneda))
            {
                zSuma += M.Saldar;
            }
            return zSuma;
        }

        public override decimal Total()
        {
            return 0;
        }

        public override void upImporte(decimal xImporte, string xSerie, int xNumero, int xLinea)
        {
            Movimiento M = Movimientos.Find(Obj => Obj.Linea == xLinea && Obj.SerieInterna == xSerie && Obj.NumeroInterno == xNumero);
            if (M != null)
            {
                if (Math.Abs(M.Importe) < Math.Abs(xImporte))
                    M.Saldar = M.Importe;
                else
                    M.Saldar = xImporte;
            }
        }
    }
}
