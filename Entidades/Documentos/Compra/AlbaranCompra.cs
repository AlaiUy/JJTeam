using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    //SERIECOMPRA,FECHA,CODPROVEEDOR, CODMONEDA, NUMPROVEEDOR, SERIEPROVEEDO, FECHAPROVEEDOR
    public class AlbaranCompra
    {
        private string _Serie;
        private DateTime _Fecha;
        private int _Numero;
        private int _CodProveedor;
        private Moneda _Moneda;
        private int _NumFacturaProveedor;
        private string _SerieFacturaProveedor;
        private DateTime _FechaProveedor;
        private List<CompraLin> _Lineas;
        private string _Adenda;

        

        public AlbaranCompra(string xSerie, DateTime xFecha, int xCodproveedor, Moneda xMoneda)
        {
            _Serie = xSerie;
            _Fecha = xFecha;
            _CodProveedor = xCodproveedor;
            _Moneda = xMoneda;
            _Adenda = "";
        }

        /// <summary>
        /// Agrega una linea a la compra.
        /// Necesita se invocado en un try and catch, puede generar una excepcion.
        /// </summary>
        public virtual void AgregarLineas(List<CompraLin> xLineas)
        {
            foreach (CompraLin Linea in xLineas)
            {
                AgregarLinea(Linea);
            }
        }

        /// <summary>
        /// Agrega una linea a la compra.
        /// Necesita se invocado en un try and catch, puede generar una excepcion.
        /// </summary>
        public virtual void AgregarLinea(CompraLin Linea)
        {
            if (Linea.Cantidad <= 0)
                throw new Exception("No puede haber articulos con cantidad negativa");
            if(Linea.Costo < 0)
                throw new Exception("No puede haber articulos con costo 0");
            if (Linea.Descuento  < 0 || Linea.Descuento > 99)
                throw new Exception("El descuento de la linea es incorrecto");
            if(Linea.ImporteDescuentoTotal() < 0)
                throw new Exception("El precio de la linea es incorrecto");

            if (_Lineas == null)
                _Lineas = new List<CompraLin>();
            Lineas.Add(Linea);
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

        public int CodProveedor
        {
            get
            {
                return _CodProveedor;
            }

            set
            {
                _CodProveedor = value;
            }
        }

        

        public int NumFacturaProveedor
        {
            get
            {
                return _NumFacturaProveedor;
            }

            set
            {
                _NumFacturaProveedor = value;
            }
        }

        public string SerieFacturaProveedor
        {
            get
            {
                return _SerieFacturaProveedor;
            }

            set
            {
                _SerieFacturaProveedor = value;
            }
        }

        public DateTime FechaProveedor
        {
            get
            {
                return _FechaProveedor;
            }

            set
            {
                _FechaProveedor = value;
            }
        }

        public List<CompraLin> Lineas
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

        public string Adenda
        {
            get
            {
                return _Adenda;
            }

            set
            {
                _Adenda = value;
            }
        }

        public Moneda Moneda
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

        public int Numero
        {
            get
            {
                return _Numero;
            }

            set
            {
                _Numero = value;
            }
        }

        public virtual char Estado()
        {
            return 'P';
        }

        public virtual decimal Total()
        {
            decimal zImporte = 0;
            foreach (CompraLin L in _Lineas)
            {
                zImporte += L.TotalconIva();
            }
            return zImporte;
        }

        public virtual int Tipodoc()
        {
            return 20;
        }

        public virtual decimal ImporteTesoreria()
        {
            return Total();
        }
    }
}
