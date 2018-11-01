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
        private int _codcliente;
        protected List<object> _Lineas;
        private Moneda _Moneda;
        private string _serie;
        private int _codcuenta;
        private string _Adenda;

        public Factura()
        {
            _Lineas = new List<object>();
        }

        public Factura(int xNumero,DateTime xFecha,int xDocumento)
        {
            _numero = xNumero;
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

        public int Cliente
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

        public virtual  void AgregarLineas(List<object> xLineas) { }
        public virtual void AgregarLinea(object Linea) { }




    }
}
