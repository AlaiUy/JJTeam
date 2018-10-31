using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public  class Facturas
    {
        private int _numero;
        private string _serie;
        private DateTime _fecha;
        private int _codvendedor;
        private IList<Facturaslin> _Lineas;
        private Caja _caja;
        private int _codmoneda;
        private int _coddocumento;

        public Facturas (int xNumero, String xSerie, DateTime xFecha, int xcodvendedor, IList<Facturaslin> xLineas, Caja xCaja, int xCodMoneda, int xCoddocumento)
        {
            _numero = xNumero;
            _serie = xSerie;
            _fecha = xFecha;
            _codvendedor = xcodvendedor;
            _Lineas = xLineas;
            _caja = xCaja;
            _codmoneda = xCodMoneda;
            _coddocumento = xCoddocumento;
             
            }

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
    }
}
