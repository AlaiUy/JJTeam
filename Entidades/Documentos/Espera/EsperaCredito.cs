using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class EsperaCredito
    {
        //metodos sin set
        private int _numero;
        private DateTime _fecha;



        //Metodos con set
        private Vendedor _objVendedor;
        private Persona _objPersona;
        private List<Esperalin> lineas;
        private Moneda _objMoneda;
        private Cuenta _objCuenta;
        private string _Adenda;
        private string _DireccionEnvio;
        private int _estado;
        private int _tipo;

     
        public int Estado
        {
            get
            {
                return _estado;
            }
            set { _estado = value; }
        }

        public int Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
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

       

        public List<Esperalin> Lineas
        {
            get
            {
                return lineas;
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

        public Vendedor ObjVendedor
        {
            get
            {
                return _objVendedor;
            }

            set
            {
                _objVendedor = value;
            }
        }

       

        public Cuenta ObjCuenta
        {
            get
            {
                return _objCuenta;
            }

            set
            {
                _objCuenta = value;
            }
        }

        public Moneda ObjMoneda
        {
            get
            {
                return _objMoneda;
            }

            set
            {
                _objMoneda = value;
            }
        }

        public Persona ObjPersona
        {
            get
            {
                return _objPersona;
            }

            set
            {
                _objPersona = value;
            }
        }

        public EsperaCredito(int xNumero,DateTime xFecha, Vendedor xobjVendedor, Persona xobjPersona, Moneda xobjMoneda, Cuenta xobjCuenta,  String xAdenda, String xDireccionEnvio, int xestado, int xtipo) {
            lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
            _objVendedor = xobjVendedor;
            ObjPersona = xobjPersona;
            _objMoneda = xobjMoneda;
            _objCuenta = xobjCuenta;
            _Adenda = xAdenda;
            _DireccionEnvio = xDireccionEnvio;
            _estado = xestado;
            _tipo = xtipo;
                        
        }

        public EsperaCredito() {
            lineas = new List<Esperalin>();
        }



        public  void AgregarLineas(List<Esperalin> xLineas)
        {
            foreach (Esperalin Linea in xLineas)
            {
                AgregarLinea(Linea);
            }
        }

        public  void AgregarLinea(Esperalin Linea)
        {
            Lineas.Add(Linea);
        }

       

        public decimal ImporteTotal()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += (((L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100)))/(1+(L.Descuento/100))) * L.Cantidad);

            }
            return Decimal.Round(Importe, 2);
        }

        public decimal ImporteTotalSinIva()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += L.ObjArticulo.Precio() * L.Cantidad;

            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteTotalSinDescuentos()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += ((L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100))) * L.Cantidad);

            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteIva()
        {
                        
            return Decimal.Round(ImporteTotalSinDescuentos() - ImporteTotalSinIva(),2);

        }

        public decimal ImporteDescuento() {

            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += (L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100)) - (L.ObjArticulo.Precio()  * (1 + (L.ObjArticulo.Iva / 100)) )/ (1+(L.Descuento/100))) * L.Cantidad;

            }
            return Decimal.Round(Importe,2);

        }

      






    }
}
