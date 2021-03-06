﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Espera
    {
        //metodos sin set
        private int _numero;
        private DateTime _fecha;
        private int _CodDocumento;


        //Metodos con set
        private int _codvendedor;
        private int _codcliente;
        private List<Esperalin> lineas;
        private int _codmoneda;
        private int _codcuenta;
        private string _Adenda;
        private string _Nombreopc = "";
        private string _DirOpc = "";
        private string _RutOpc = "";
        private int _estado;
        private int _tipo;

        

        

        public string Nombreopc
        {
            get
            {
                return _Nombreopc;
            }

            set
            {
                _Nombreopc = value;
            }
        }

        public string DirOpc
        {
            get
            {
                return _DirOpc;
            }

            set
            {
                _DirOpc = value;
            }
        }

        public string RutOpc
        {
            get
            {
                return _RutOpc;
            }

            set
            {
                _RutOpc = value;
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

        public int CodDocumento
        {
            get
            {
                return _CodDocumento;
            }
        }

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

        public int Codcliente
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

        public List<Esperalin> Lineas
        {
            get
            {
                return lineas;
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

        public Espera(int xNumero,DateTime xFecha) {
            lineas = new List<Esperalin>();
            _numero = xNumero;
            _fecha = xFecha;
            
        }

        public Espera() {
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

        public decimal PrecioBruto()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += L.Cantidad * L.Precio;

            }
            return Importe;
        }

        public decimal PrecioFinal()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += (L.Precio * (1 + (L.Iva / 100)) * L.Cantidad);

            }
            return Importe;
        }

        public decimal PrecioIva()
        {
            decimal Importe = 0;

            foreach (Esperalin L in lineas)
            {
                Importe += (((L.Precio * (1 + (L.Iva / 100)))-L.Precio)*L.Cantidad);

            }
            return Importe;
        }




    }
}
