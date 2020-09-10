using System;
using System.Collections.Generic;

namespace JJ.Entidades
{
    public abstract class Recibo
    {
        private DateTime _Fecha;
        private string _Serie;
        private int _Numero = -1;
        private int _Codmoneda;
        protected List<Movimiento> _Movimientos;

        public Recibo(DateTime xFecha,string xSerie)
        {
            _Fecha = xFecha;
            _Serie = xSerie;
        }

        public Recibo(DateTime xFecha, string xSerie,int xCodmoneda,int xNumero)
        {
            _Fecha = xFecha;
            _Serie = xSerie;
            _Numero = xNumero;
            _Codmoneda = xCodmoneda;
        }

       

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
        }

        

        public string Serie
        {
            get
            {
                return _Serie;
            }
        }

        public int Codmoneda
        {
            get
            {
                return _Codmoneda;
            }
        }


        

        public abstract void AddMovimiento(Movimiento xMovimiento);
        //{
        //    if (xMovimiento == null)
        //        return;

        //    if (xMovimiento.Estado == 'S')
        //        return;

        //    if (xMovimiento.Saldar == 0)
        //        return;

        //    if ((_Movimientos.Find(Obj => Obj.Linea == xMovimiento.Linea && Obj.SerieInterna == xMovimiento.SerieInterna && Obj.NumeroInterno == xMovimiento.NumeroInterno) != null))
        //        return;

        //    _Movimientos.Add(xMovimiento);
        //}

        public abstract decimal Total(int xCodMoneda);

        public abstract decimal Total();
        //{
        //    decimal zSuma = 0;
        //    foreach (Movimiento M in _Movimientos.FindAll(Obj => Obj.Moneda == xCodMoneda))
        //    {
        //        zSuma += M.Saldar;
        //    }
        //    return zSuma;
        //}





        public abstract void upImporte(decimal xImporte, string xSerie, int xNumero, int xLinea);
        
    }
}
