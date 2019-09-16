using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Articulo
    {
        private int _codArticulo;
        private string _descripcion;
        private string _referencia;
        private string _nombre;
        private bool _activo;
        private string _codbarras;
        private string _codbarras1;
        private int _codmarca;
        private string _modelo;
        private int _coddepto;
        private int _codseccion;
        private decimal _Costo;
        private decimal _Ganancia;
        private Iva _Iva;
        private int _CodMoneda;
        private bool _recalcula;
        private decimal _stock;

        public int CodArticulo
        {
            get
            {
                return _codArticulo;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        public string Referencia
        {
            get
            {
                return _referencia;
            }

            set
            {
                _referencia = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public bool Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                _activo = value;
            }
        }

        public string Codbarras
        {
            get
            {
                return _codbarras;
            }

            set
            {
                _codbarras = value;
            }
        }

        public string Codbarras1
        {
            get
            {
                return _codbarras1;
            }

            set
            {
                _codbarras1 = value;
            }
        }



        public int Codmarca
        {
            get
            {
                return _codmarca;
            }

            set
            {
                _codmarca = value;
            }
        }

       

        public string Modelo
        {
            get
            {
                return _modelo;
            }

            set
            {
                _modelo = value;
            }
        }

        public int Coddepto
        {
            get
            {
                return _coddepto;
            }

            set
            {
                _coddepto = value;
            }
        }

        public int Codseccion
        {
            get
            {
                return _codseccion;
            }

            set
            {
                _codseccion = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return _Costo;
            }
            set
            {
                _Costo = value;
            }
        }

        public decimal Ganancia
        {
            get
            {
                return _Ganancia;
            }
        }

        public Iva Iva
        {
            get
            {
                return _Iva;
            }
            set
            {
                _Iva = value;
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

        public bool Recalcula
        {
            get
            {
                return _recalcula;
            }

            set
            {
                _recalcula = value;
            }
        }

        public decimal Stock
        {
            get
            {
                return _stock;
            }
        }

        public Articulo(int xCodigo, string xDescripcion, string xReferencia,decimal xPrecioCosto,Iva xIva,decimal xGanancia, int xCodMoneda,bool xRecalcula,decimal xStock)
        {
            _codArticulo = xCodigo;
            _descripcion = xDescripcion;
            _referencia = xReferencia;
            _Costo = xPrecioCosto;
            _Iva = xIva;
            _Ganancia = xGanancia;
            _CodMoneda = xCodMoneda;
            _recalcula = xRecalcula;
            _stock = xStock;
        }

        public Articulo(string xDescripcion, string xReferencia, decimal xPrecioCosto, Iva xIva, decimal xGanancia, int xCodMoneda,bool xRecalcula)
        {
            _codArticulo = -1;
            _descripcion = xDescripcion;
            _referencia = xReferencia;
            _Costo = xPrecioCosto;
            _Iva = xIva;
            _Ganancia = xGanancia;
            _CodMoneda = xCodMoneda;
            _recalcula = xRecalcula;
            _activo = true;
        }

        public void setCosto(decimal xCosto)
        {
            if (xCosto <= 0)
                return;
            _Costo = xCosto;
        }

        public void setCostoenBaseAPrecioFinal(decimal xPrecio)
        {
            _Costo = ((xPrecio/ ValorPorcentaje(_Iva.Valor)) / ValorPorcentaje(_Ganancia));

        }

        public void setGanancia(decimal xGanancia)
        {
            if (xGanancia <= 0)
                return;
            _Ganancia = xGanancia;
        }

        public decimal PrecioIva()
        {

            return ((_Costo*ValorPorcentaje(_Iva.Valor))* ValorPorcentaje(_Ganancia));
            
        }

       
        public decimal Precio()
        {
          
            return (PrecioIva() / ValorPorcentaje(_Iva.Valor));
          
        }

        static decimal ValorPorcentaje(decimal Porcentaje)
        {
            return (1+(Porcentaje/100));
        }

        public static decimal ObtenerGanancia(decimal xCosto, Iva xIva, decimal xFinal)
        {
            decimal Importe = 0;

            Importe = (xFinal / (xCosto * ValorPorcentaje(xIva.Valor)));
             //me devuelve el valor de la ganancia pero no en % sino como 1,x..

            return decimal.Round(((Importe - 1)*100),2);
        }

   

    }
}
