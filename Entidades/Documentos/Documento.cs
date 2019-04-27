using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Documento
    {
        private DateTime _Fecha;
        private string _Serie;
        private string _Caja;
        private int _Moneda;
        private int _Z;
        private int _Vendedor;
        private List<Linea> _Lineas;

        public Documento(DateTime xFecha,string xSerie,string xCaja,int xMoneda,int xZ,int xVendedor)
        {
            _Fecha = xFecha;
            _Serie = xSerie;
            _Caja = xCaja;
            _Moneda = xMoneda;
            _Z = xZ;
            _Vendedor = xVendedor;
        }

        public void AgregarLineas(List<Linea> xLineas)
        {
            foreach (Linea Linea in xLineas)
            {
                AgregarLinea(Linea);
            }
        }

        public void AgregarLinea(Linea  Linea)
        {
            Lineas.Add(Linea);
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public string Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
            }
        }

        public string Caja
        {
            get
            {
                return _Caja;
            }

            set
            {
                _Caja = value;
            }
        }

        public int Moneda
        {
            get
            {
                return _Moneda;
            }

            set
            {
                _Moneda = value;
            }
        }

        public int Z
        {
            get
            {
                return _Z;
            }

            set
            {
                _Z = value;
            }
        }

        public int Vendedor
        {
            get
            {
                return _Vendedor;
            }

            set
            {
                _Vendedor = value;
            }
        }

        public List<Linea> Lineas
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

        public decimal Subtotal()
        {
            decimal zSuma = 0;
            foreach (Linea L in _Lineas)
                zSuma += L.SubTotal();
            return zSuma;
        }

        public decimal Total()
        {
            decimal zSuma = 0;
            foreach (Linea L in _Lineas)
                zSuma += L.TotalDescuento();
            return zSuma;
        }

        
    }


}
