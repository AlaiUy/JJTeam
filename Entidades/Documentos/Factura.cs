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
        private string _CodCaja;


        //Metodos con set
        private int _codvendedor;
        protected List<object> _Lineas;
        private int _Moneda;
        private string _serie;
        private int _codcuenta;
        private string _Adenda;
        private int _Z;

        public Factura(int xCodDocumento)
        {
            _CodDocumento = xCodDocumento;
            _Lineas = new List<object>();
        }

        public Factura(int xNumero,string xSerie,string xCodCaja, DateTime xFecha, int xCodMoneda, int xZ, int xcodvendedor)
        {
            _Lineas = new List<object>();
            _numero = xNumero;
            _fecha = xFecha;
            _CodCaja = xCodCaja;
            _serie = xSerie;
            _Moneda = xCodMoneda;
            _Z = xZ;
            _codvendedor = xcodvendedor;
        }


        public Factura(DateTime xFecha)
        {
            _fecha = xFecha;
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

        public string CodCaja
        {
            get
            {
                return _CodCaja;
            }

            set
            {
                _CodCaja = value;
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

        public int CodDocumento
        {
            get
            {
                return _CodDocumento;
            }

            set
            {
                _CodDocumento = value;
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
