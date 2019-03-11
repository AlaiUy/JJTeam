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
        private int _codvendedor;
        private int _codclientecontado;
        private List<Esperalin> lineas;
        private int _codmoneda;
        private string _Adenda;
        private string _DirEnvio = "";
        private int _estado;
        private int _tipo;

        public int Codvendedor
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

        public int Codclientecontado
        {
            get
            {
                return _codclientecontado;
            }

            set
            {
                _codclientecontado = value;
            }
        }

        public List<Esperalin> Lineas
        {
            get
            {
                return lineas;
            }

            set
            {
                lineas = value;
            }
        }

        public int Codmoneda
        {
            get
            {
                return _codmoneda;
            }

            set
            {
                _codmoneda = value;
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

        public string DirEnvio
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

            set
            {
                _estado = value;
            }
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

        public EsperaContado(int xNumero, DateTime xFecha)
        {
            Lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
        }



        public EsperaContado(int xNumero, DateTime xFecha, int xCodVendedor, int xCodClienteContado, int xCodMoneda, String xAdenda, String xDirEnvio, int xEstado, int xTipo)
        {
            Lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
            Codvendedor = xCodVendedor;
          Codclientecontado = xCodClienteContado;
            Codmoneda = xCodMoneda;
            Adenda = xAdenda;
            DirEnvio = xDirEnvio;
            Estado = xEstado;
            Tipo = xTipo;

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

            foreach (Esperalin L in Lineas)
            {
                Importe += (((L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);

            }
            return Decimal.Round(Importe, 2);
        }

        public decimal ImporteTotalSinIva()
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                Importe += L.ObjArticulo.Precio() * L.Cantidad;

            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteTotalSinDescuentos()
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
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

            foreach (Esperalin L in Lineas)
            {
                Importe += (L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100)) - (L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad;

            }
            return Decimal.Round(Importe, 2);

        }








    }
}
