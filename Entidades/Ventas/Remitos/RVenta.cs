using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades.Ventas.Remitos
{
    public class RVenta
    {
        private int _numero;
        private string _serie;
        private DateTime _fecha;
        private int _codvendedor;
        private IList<RVentaLin> _Lineas;
        private string _codcaja;
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

        public IList<RVentaLin> Lineas
        {
            get
            {
                return _Lineas;
            }

            set
            {
                _Lineas = value;
            }
        }

        public string Codcaja
        {
            get
            {
                return _codcaja;
            }

            set
            {
                _codcaja = value;
            }
        }

        public int Codmoneda
        {
            get
            {
                return _codmoneda;
            }

            set
            {
                _codmoneda = value;
            }
        }

        public int Coddocumento
        {
            get
            {
                return _coddocumento;
            }

            set
            {
                _coddocumento = value;
            }
        }

        public RVenta() { }

        public bool addLinea(RVentaLin xLinea)
        {
            if(xLinea == null)
                return false;
            if (xLinea.Cantidad < 0)
                return false;
            if (xLinea.Dto < 0)
                return false; ;
            if (xLinea.Iva < 0)
                return false; ;
            if (xLinea.Precio < 0)
                return false; ;

            _Lineas.Add(xLinea);
            return true;
        }

        public bool AgregarLineas(IList<RVentaLin> xLineas)
        {
            foreach (RVentaLin L in xLineas)
            {
                if (!addLinea(L))
                {
                    _Lineas = null;
                    return false;
                }
                    
            }
            return true;
        }
    }
}
