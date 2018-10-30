using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Factura
    {
        private int _Codigo;
        private string _serie;
        private int _numero;      
        private DateTime _fecha;
        private int _codvendedor;
        private int _codcliente;
        private IList<Facturalin> _Lineas;
        private Caja _caja;

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
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

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
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

        public int Codcliente
        {
            get
            {
                return _codcliente;
            }

            set
            {
                _codcliente = value;
            }
        }

        public IList<Facturalin> Lineas
        {
            get
            {
                return Lineas1;
            }

            set
            {
                Lineas1 = value;
            }
        }

        public Caja Caja
        {
            get
            {
                return _caja;
            }

            set
            {
                _caja = value;
            }
        }

        public IList<Facturalin> Lineas1
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
    }
}
