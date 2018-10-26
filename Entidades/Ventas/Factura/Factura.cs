using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Factura
    {
        private int _numero;
        private string _serie;
        private DateTime _fecha;
        private int _codvendedor;
        private IList<Facturalin> _Lineas;
        private Caja _caja;
        private int _codmoneda;
        private int _coddocumento;

        public int Numero
        {
            get
            {
                return _numero;
            }
        }

        public string Serie
        {
            get
            {
                return _serie;
            }

            set
            {
                _serie = value;
            }
        }

        public int Codvendedor
        {
            get
            {
                return _codvendedor;
            }

            set
            {
                _codvendedor = value;
            }
        }
    }
}
