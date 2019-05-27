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
        private int _CodProveedor;
        private int _CodMoneda;
        private int _NumFacturaProveedor;
        private string _SerieFacturaProveedor;
        private DateTime _FechaProveedor;
        private List<CompraLin> _Lineas;
        private decimal _Cotizacion;

        public AlbaranCompra()
        {

        }

        public AlbaranCompra(string xSerie, DateTime xFecha, int xCodproveedor, int xCodmoneda)
        {
            _Serie = xSerie;
            _Fecha = xFecha;
            _CodProveedor = xCodproveedor;
            _CodMoneda = xCodmoneda; 
        }

        /// <summary>
        /// Agrega una linea a la compra.
        /// Necesita se invocado en un try and catch, puede generar una excepcion.
        /// </summary>
        public void AgregarLineas(List<CompraLin> xLineas)
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
        public void AgregarLinea(CompraLin Linea)
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

        public int CodMoneda
        {
            get
            {
                return _CodMoneda;
            }

            set
            {
                _CodMoneda = value;
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
    }
}
