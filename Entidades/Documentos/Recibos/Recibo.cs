using System;
using System.Collections.Generic;

namespace JJ.Entidades
{
    public abstract class Recibo
    {
        private List<Movimiento> _Movimientos;
        private DateTime _Fecha;

        public Recibo(DateTime xFecha)
        {
            _Fecha = xFecha;
            _Movimientos = new List<Movimiento>();
        }

        public List<Movimiento> Movimientos
        {
            get
            {
                return _Movimientos;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
        }

       

        public void AddMovimiento(Movimiento xMovimiento)
        {
            if (xMovimiento == null)
                return;

            if (xMovimiento.Estado == 'S')
                return;

            if (xMovimiento.Saldar == 0)
                return;

            if ((_Movimientos.Find(Obj => Obj.Linea == xMovimiento.Linea && Obj.SerieInterna == xMovimiento.SerieInterna && Obj.NumeroInterno == xMovimiento.NumeroInterno) != null))
                return;
            
            _Movimientos.Add(xMovimiento);
        }

        public virtual decimal Total(int xCodMoneda)
        {
            decimal zSuma = 0;
            foreach (Movimiento M in _Movimientos.FindAll(Obj => Obj.Moneda == xCodMoneda))
            {
                zSuma += M.Saldar;
            }
            return zSuma;
        }



       

        public void upImporte(decimal xImporte, string xSerie, int xNumero, int xLinea)
        {
            Movimiento M = _Movimientos.Find(Obj => Obj.Linea == xLinea && Obj.SerieInterna == xSerie && Obj.NumeroInterno == xNumero);
            if(M != null)
            {
                if (Math.Abs(M.Importe) < Math.Abs(xImporte))
                    M.Saldar = M.Importe;
                else
                    M.Saldar = xImporte;
            }
        }
    }
}
