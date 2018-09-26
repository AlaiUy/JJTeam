using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class PreciosVenta
    {
        //Precio bruto = precio con iva pero sin ganancia
        private int _CodTarifa;
        private decimal _PrecioBruto;
        private decimal _Ganancia;
        private int _CodMoneda;

        public int CodTarifa
        {
            get
            {
                return _CodTarifa;
            }
        }

        public decimal Ganancia
        {
            get
            {
                return _Ganancia;
            }
        }

        public int CodMoneda
        {
            get
            {
                return _CodMoneda;
            }
            
        }

        public decimal PrecioBruto
        {
            get
            {
                return _PrecioBruto;
            }
        }

        public PreciosVenta(int xCodTarifa, decimal xPrecio, decimal xGanancia, int xCodMoneda)
        {
            _CodTarifa = xCodTarifa;
            _PrecioBruto = xPrecio;
            _Ganancia = xGanancia;
            _CodMoneda = xCodMoneda;
            
        }


        public decimal Precio()
        {
            return _PrecioBruto * (1 + (_Ganancia / 100)); 
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return _CodTarifa == ((PreciosVenta)obj).CodTarifa;
            }
        }

        
    }
}
