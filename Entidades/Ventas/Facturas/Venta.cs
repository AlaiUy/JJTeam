using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades.Ventas
{
    public abstract class Venta
    {
        private int _numero;
        private string _serie;
        private DateTime _fecha;
        private int _codvendedor;
        private IList<Ventalin> _Lineas;
        private Caja _caja;
        private int _codmoneda;
        private int _coddocumento;

        public string Serie
        {
            get
            {
                return _serie;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            
        }

        public int Codvendedor
        {
            get
            {
                return _codvendedor;
            }

           
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            
        }

        public IList<Ventalin> Lineas
        {
            get
            {
                return _Lineas;
            }
        }

        public Caja Caja
        {
            get
            {
                return _caja;
            }
        }
    }
}
