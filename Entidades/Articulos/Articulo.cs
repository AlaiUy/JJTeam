using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Articulo
    {
        private int _codArticulo;
        private string _descripcion;
        private string _referencia;
        private IList<PreciosVenta> _Precios;
        private string _nombre;
        private bool _activo;
        private string _codbarras;
        private string _codbarras1;
        private int _codmarca;
        private string _modelo;
        private int _coddepto;
        private int _codseccion;

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

        public IList<PreciosVenta> Precios
        {
            get
            {
                return _Precios;
            }

            protected set
            {
                _Precios = value;
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

        public Articulo(int xCodigo, string xDescripcion, string xReferencia,IList<PreciosVenta> xPrecios)
        {
            _codArticulo = xCodigo;
            _descripcion = xDescripcion;
            _referencia = xReferencia;
            _Precios = xPrecios;
        }

        public Articulo(int xCodArticulo) {
            _codArticulo = xCodArticulo;
            _Precios = new List<PreciosVenta>();
            
        }
        public Articulo()
        {
            _Precios = new List<PreciosVenta>();

        }


        public void AddPreciosVenta(List<object> xPreciosVenta)
        {
            if (xPreciosVenta == null)
                return;


            foreach (PreciosVenta P in xPreciosVenta)
            {
               
                if(!_Precios.Contains(P))
                    AddPrecioVenta(P);
            }

          
        }

        public void AddPrecioVenta(object xPrecioVenta)
        {

            if (xPrecioVenta == null)
                return;

            PreciosVenta P = (PreciosVenta)xPrecioVenta;
            if (!_Precios.Contains(P))
                _Precios.Add(P);
        }


    }
}
