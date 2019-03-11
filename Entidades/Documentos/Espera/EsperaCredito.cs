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
        private int _codvendedor;
        private int _codPersona;
        private List<Esperalin> _lineas;
        private int _codMoneda;
        private int _codCuenta;
        private string _Adenda;
        private string _DireccionEnvio;
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

        public int CodPersona
        {
            get
            {
                return _codPersona;
            }

            set
            {
                _codPersona = value;
            }
        }

        public List<Esperalin> Lineas
        {
            get
            {
                return _lineas;
            }

            set
            {
                _lineas = value;
            }
        }

        public int CodMoneda
        {
            get
            {
                return _codMoneda;
            }

            set
            {
                _codMoneda = value;
            }
        }

        public int CodCuenta
        {
            get
            {
                return _codCuenta;
            }

            set
            {
                _codCuenta = value;
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

        public string DireccionEnvio
        {
            get
            {
                return _DireccionEnvio;
            }

            set
            {
                _DireccionEnvio = value;
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

        public EsperaCredito(int xNumero,DateTime xFecha, int xcodVendedor, int xcodpersona, int xCodMoneda, int xCodCuenta,  String xAdenda, String xDireccionEnvio, int xestado, int xtipo) {
            _lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
            _codvendedor = xcodVendedor;
            _codPersona = xcodpersona;
            _codMoneda = xCodMoneda;
            _codCuenta = xCodCuenta;
            _Adenda = xAdenda;
            _DireccionEnvio = xDireccionEnvio;
            _estado = xestado;
            _tipo = xtipo;
                        
        }

        public EsperaCredito() {
            Lineas = new List<Esperalin>();
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

            foreach (Esperalin L in Lineas)
            {
                Importe += (((L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100)))/(1+(L.Descuento/100))) * L.Cantidad);

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
                        
            return Decimal.Round(ImporteTotalSinDescuentos() - ImporteTotalSinIva(),2);

        }

        public decimal ImporteDescuento() {

            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                Importe += (L.ObjArticulo.Precio() * (1 + (L.ObjArticulo.Iva / 100)) - (L.ObjArticulo.Precio()  * (1 + (L.ObjArticulo.Iva / 100)) )/ (1+(L.Descuento/100))) * L.Cantidad;

            }
            return Decimal.Round(Importe,2);

        }

      






    }
}
