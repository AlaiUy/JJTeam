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
        private string _Adenda;
        private string _DirEnvio = "";
        private int _estado;
        private string _NombreCLiente;
        private bool _presupuesto;


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

        public string NombreCLiente
        {
            get
            {
                return _NombreCLiente;
            }

            set
            {
                _NombreCLiente = value;
            }
        }

        public char Presupuesto
        {
            get
            {
                if(_presupuesto==true)
                {
                    return 'T';
                  
                }
                return 'F';
            }
            set
            {

                if (value.Equals('T'))
                {
                    _presupuesto = true;

                }else
                {
                    _presupuesto = false;
                }
               

            }
        }


        public EsperaContado(DateTime xFecha)
        {
            Lineas = new List<Esperalin>();
            _fecha = xFecha;
        }



        public EsperaContado(int xNumero, DateTime xFecha, int xCodVendedor, int xCodClienteContado, String xAdenda, String xDirEnvio, int xEstado,string xNombreCliente, char xpresupuesto)
        {
            Lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
            _codvendedor = xCodVendedor;
            _codclientecontado = xCodClienteContado;
            _Adenda = xAdenda;
            _DirEnvio = xDirEnvio;
            _estado = xEstado;
            Presupuesto = xpresupuesto;
            _NombreCLiente = xNombreCliente;
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
                if (L.Descuento < 0)
                {
                    Importe += (((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) * (1 + (-L.Descuento / 100))) * L.Cantidad);

                }
                else
                {
                    Importe += (((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);

                }
                   
             

            }
            return Decimal.Round(Importe, 2);
        }

        public decimal ImporteTotal(int xcodmoneda, decimal xcotizacion)
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                if (L.Articulo.CodMoneda == xcodmoneda)
                {
                    if (L.Descuento < 0)
                    {
                        Importe += (((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) * (1 + (-L.Descuento / 100))) * L.Cantidad);
                    }
                    else { 
                    Importe += (((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);
                    }
                     }

                
                else
                {
                    if (L.Descuento < 0)
                    {
                        Importe += ((((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100))) * (1 + (-L.Descuento / 100))) * L.Cantidad);
                    }
                    else {
                        Importe += ((((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);
                    }
                    

                }


            }
            return Decimal.Round(Importe, 2);
        }

        //public decimal ImporteTotalMoneda(int xcodMoneda, decimal xcotizacion)
        //{
        //    decimal Importe = 0;

        //    foreach (Esperalin L in Lineas)
        //    {
        //        if (L.Articulo.CodMoneda == xcodMoneda)
        //        {


        //        Importe += (((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);
        //        }else
        //        {
        //            Importe += (((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad);

        //        }

        //    }
        //    return Decimal.Round(Importe, 2);
        //}


        public decimal ImporteTotalSinIva()
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
              
                Importe += L.Articulo.Precio() * L.Cantidad;

            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteTotalSinIva(int xcodmoneda, decimal xcotizacion)
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                if (L.Articulo.CodMoneda == xcodmoneda)
                {
                if (L.Descuento < 0)
                    {
                        Importe += (L.Articulo.Precio()*(1+(-L.Descuento)/100)) * L.Cantidad;
                    }else
                    {
                        Importe += (L.Articulo.Precio()/ (1 + (L.Descuento) / 100)) * L.Cantidad;

                    }
                  
                }
                else
                {
                    if (L.Descuento < 0)
                    {
                        Importe += ((L.Articulo.Precio()*(1+(-L.Descuento/100))) * xcotizacion) * L.Cantidad;

                    }
                    else
                    {
                        Importe += ((L.Articulo.Precio() / (1 + (L.Descuento / 100))) * xcotizacion) * L.Cantidad;

                    }
                       
                }
            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteTotalSinDescuentos()
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                Importe += ((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) * L.Cantidad);

            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteTotalSinDescuentos(int xcodmoneda, decimal xcotizacion)
        {
            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                if (L.Articulo.CodMoneda == xcodmoneda)
                {
                    Importe += ((L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) * L.Cantidad);

                }
                else
                {
                    Importe += (((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100))) * L.Cantidad);

                }


            }
            return Decimal.Round(Importe, 2);

        }


        public decimal ImporteIva()
        {

            return Decimal.Round(ImporteTotalSinDescuentos() - ImporteTotalSinIva(), 2);

        }

        public decimal ImporteIva(int xcodmoneda, decimal xcotizacion)
        {
            return Decimal.Round(ImporteTotal(xcodmoneda, xcotizacion) - ImporteTotalSinIva(xcodmoneda, xcotizacion), 2);
         //   return Decimal.Round(ImporteTotalSinDescuentos(xcodmoneda, xcotizacion) - ImporteTotalSinIva(xcodmoneda, xcotizacion), 2);

        }

        public decimal ImporteDescuento()
        {

            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                if (L.Descuento < 0)
                {
                    Importe += (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100)) - (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) * (1 + (-L.Descuento / 100))) * L.Cantidad;

                }
                else
                {
                    Importe += (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100)) - (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad;

                }
                   

            }
            return Decimal.Round(Importe, 2);

        }

        public decimal ImporteDescuento(int xcodmoneda, decimal xcotizacion)
        {

            decimal Importe = 0;

            foreach (Esperalin L in Lineas)
            {
                if (L.Articulo.CodMoneda == xcodmoneda)
                {
                    if (L.Descuento < 0)
                    {
                        Importe += (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100)) - (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) * (1 + (-L.Descuento / 100))) * L.Cantidad;
                    }
                    else
                    {

                        Importe += (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100)) - (L.Articulo.Precio() * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad;
                    }
                      
                }
                else
                {
                    if (L.Descuento < 0)
                    {
                        Importe += ((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100)) - ((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100))) * (1 + (-L.Descuento / 100))) * L.Cantidad;

                    }
                    else {
                        Importe += ((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100)) - ((L.Articulo.Precio() * xcotizacion) * (1 + (L.Articulo.Iva.Valor / 100))) / (1 + (L.Descuento / 100))) * L.Cantidad;
                    }
                        
                }
            }
            return Decimal.Round(Importe, 2);

        }

        public  void EliminarLinea(int xNLinea )
        {
                      lineas.RemoveAt(xNLinea);
            Byte Index = 1;
            foreach (Esperalin L in Lineas)
            {
                L.NumLinea = Index;
            Index += 1;

            }


            }


        




    }
}
