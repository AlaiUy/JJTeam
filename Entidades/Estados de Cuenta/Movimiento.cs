using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Movimiento
    {
        private DateTime _Fecha;
        private int _NumeroInterno;
        private string _SerieInterna;
        private int _Moneda;
        private DateTime _FechaPago;
        private decimal _Importe;
        private char _estado;
        private int _linea;
        private decimal _saldar;

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
        }

        public int NumeroInterno
        {
            get
            {
                return _NumeroInterno;
            }
        }

        public string SerieInterna
        {
            get
            {
                return _SerieInterna;
            }
        }

        public int Moneda
        {
            get
            {
                return _Moneda;
            }
        }

        public DateTime FechaPago
        {
            get
            {
                return _FechaPago;
            }
        }

        

        public decimal Importe
        {
            get
            {
                return _Importe;
            }
        }

        public int Linea
        {
            get
            {
                return _linea;
            }
        }

        public decimal Saldar
        {
            get
            {
                return _saldar;
            }
            set
            {
                if (_Importe < value)
                    value = _Importe;
                _saldar = value;
            }
            
        }

        public char Estado
        {
            get
            {
                return _estado;
            }
        }

          
        

        public Movimiento(DateTime xFecha, int xNumeroInterno, string xSerieInterna, int xCodMoneda,decimal xImporte)
        {
            _Fecha = xFecha;
            _NumeroInterno = xNumeroInterno;
            _SerieInterna = xSerieInterna;
            _Moneda = xCodMoneda;
            _Importe = xImporte;
        }

        public Movimiento(DateTime xFecha, int xNumeroInterno, string xSerieInterna, int xCodMoneda, decimal xImporte,char xEstado,int xLinea)
        {
            _Fecha = xFecha;
            _NumeroInterno = xNumeroInterno;
            _SerieInterna = xSerieInterna;
            _Moneda = xCodMoneda;
            _Importe = xImporte;
            _estado = xEstado;
            _linea = xLinea;
        }


    }
}
