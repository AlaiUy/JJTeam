using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Factura
    {
        
        //metodos sin set
        private int _numero;      
        private DateTime _fecha;
        private int _CodDocumento;


        //Metodos con set
        private int _codvendedor;
        protected List<object> _Lineas;
        private int _Moneda;
        private string _serie;
        private int _codcuenta;
        private string _Adenda;

        public Factura(int xCodDocumento)
        {
            _CodDocumento = xCodDocumento;
            _Lineas = new List<object>();
        }

        public Factura(int xNumero,string xSerie,DateTime xFecha,int xDocumento)
        {
            _numero = xNumero;
            _fecha = xFecha;
            _CodDocumento = xDocumento;
            _Lineas = new List<object>();
            _serie = xSerie;
        }


        public Factura(DateTime xFecha, int xDocumento)
        {
            _fecha = xFecha;
            _CodDocumento = xDocumento;
            _Lineas = new List<object>();
        }

        public string Serie
        {
            get
            {
                return _serie;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
        }

        public int Vendedor
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

    

        public List<object> Lineas
        {
            get
            {
                return _Lineas;
            }
            
        }

        public int Documento
        {
            get
            {
                return _CodDocumento;
            }
        }

        public int Codmoneda
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

        public int Codcuenta
        {
            get
            {
                return _codcuenta;
            }

            set
            {
                _codcuenta = value;
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

        public virtual  void AgregarLineas(List<object> xLineas) {
            foreach (object Linea in xLineas)
            {
                Lineas.Add((VentaLin)Linea);
            }
        }
        public virtual void AgregarLinea(object Linea) {
            Lineas.Add((VentaLin)Linea);
        }




    }
}
