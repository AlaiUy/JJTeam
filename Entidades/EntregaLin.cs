using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    
    public class EntregaLin
    {
        private int _Linea;
        private decimal _Cantidad;
        private decimal _Entregado;
        private decimal _Devuelto;
        private decimal _Notac;

        public int Linea
        {
            get
            {
                return _Linea;
            }
        }

        public decimal Devuelto
        {
            get
            {
                return _Devuelto;
            }
        }

        public decimal NotaC
        {
            get
            {
                return _Notac;
            }
        }

        public EntregaLin(int xLinea, decimal xCantidad, decimal xEntregado, decimal xDevuelto, decimal xNotac)
        {
            _Linea = xLinea;
            _Cantidad = xCantidad;
            _Entregado = xEntregado;
            _Devuelto = xDevuelto;
            _Notac = xNotac;
        }

        public decimal Disponible()
        {
            return _Entregado - (_Notac - _Devuelto);
        }
    }
}
