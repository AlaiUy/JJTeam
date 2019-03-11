using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class EsperaContado
    {
        //metodos sin set
        private int _numero;
        private DateTime _fecha;



        //Metodos con set
        private Vendedor _objVendedor;
        private ClienteContado _objClienteContado;
        private List<Esperalin> lineas;
        private Moneda _objMoneda;
        private string _Adenda;
        private string _DirEnvio = "";
        private int _estado;
        private int _tipo;
                
        public string DireccionEnvio
        {
            get
            {
                return _DirEnvio;
            }

            set
            {
                _DirEnvio = value;
            }
        }

       
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

       

     

        public ClienteContado ObjClienteContado
        {
            get
            {
                return _objClienteContado;
            }

            set
            {
                _objClienteContado = value;
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

        public EsperaContado(int xNumero, DateTime xFecha, Vendedor xObjVendedor, ClienteContado xObjClienteContado, Moneda xObjMoneda, String xAdenda, String xDirEnvio, int xEstado, int xTipo)
        {
            lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
            _objVendedor = xObjVendedor;
            _objClienteContado = xObjClienteContado;
            _objMoneda = xObjMoneda;
            _Adenda = xAdenda;
            _DirEnvio = xDirEnvio;
            _estado = xEstado;
            _tipo = xTipo;

        }

     
        public void AgregarLineas(List<Esperalin> xLineas)
        {
            foreach (Esperalin Linea in xLineas)
            {
                AgregarLinea(Linea);
            }
        }

        public void AgregarLinea(Esperalin Linea)
        {
            Lineas.Add(Linea);
        }



        public decimal ImporteTotal()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += (((L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);

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

            return Decimal.Round(ImporteTotalSinDescuentos() - ImporteTotalSinIva(), 2);

        }

        public decimal ImporteDescuento()
        {

            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += (L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100)) - (L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad;

            }
            return Decimal.Round(Importe, 2);

        }








    }
}
