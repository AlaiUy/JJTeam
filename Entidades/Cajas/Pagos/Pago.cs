using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Pago
    {
        
        private int _Codmoneda;
        private decimal _Importe;
        private decimal _Cotizacion;
        private string _Comentario;
       

        

        public int Codmoneda
        {
            get
            {
                return _Codmoneda;
            }

            set
            {
                _Codmoneda = value;
            }
        }

        public decimal Importe
        {
            get
            {
                return _Importe;
            }

            set
            {
                _Importe = value;
            }
        }

        public decimal Cotizacion
        {
            get
            {
                return _Cotizacion;
            }

            set
            {
                _Cotizacion = value;
            }
        }

        public string Comentario
        {
            get
            {
                return _Comentario;
            }

            set
            {
                _Comentario = value;
            }
        }

        
    }
}
