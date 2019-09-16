using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class Documento
    {
        private DateTime _Fecha;
        private string _Serie;
        private string _Caja;
        private int _Moneda;
        private int _Z;
        private int _Vendedor;
        private List<Linea> _Lineas;
        private decimal _Cotizacion;
        private string _Detalle;
        private int _numero;
        private string _env_Nombre;
        private string _env_Direccion;
        private string _env_telefono;
        private string _env_observaciones;
        private bool _presupuesto;


        public Documento(DateTime xFecha, string xSerie, string xCaja, int xMoneda, int xZ, int xVendedor, decimal xCotizacion)
        {
            _Fecha = xFecha;
            _Serie = xSerie;
            _Caja = xCaja;
            _Moneda = xMoneda;
            _Z = xZ;
            _Vendedor = xVendedor;
            _Cotizacion = xCotizacion;
            _Lineas = new List<Linea>();
            _Detalle = "";
         
        }

        public Documento(DateTime xFecha, string xSerie, string xCaja, int xMoneda, int xZ, int xVendedor, decimal xCotizacion, int xnumero)
        {
            _Fecha = xFecha;
            _Serie = xSerie;
            _Caja = xCaja;
            _Moneda = xMoneda;
            _Z = xZ;
            _Vendedor = xVendedor;
            _Cotizacion = xCotizacion;
            _Lineas = new List<Linea>();
            _Detalle = "";
            _numero = xnumero;

        }

        public void AgregarLineas(List<Linea> xLineas)
        {
            foreach (Linea Linea in xLineas)
            {
                AgregarLinea(Linea);
            }
        }

        public void AgregarLinea(Linea Linea)
        {
            Lineas.Add(Linea);
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public string Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
            }
        }

        public string Caja
        {
            get
            {
                return _Caja;
            }

            set
            {
                _Caja = value;
            }
        }

        public int Moneda
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

        public int Vendedor
        {
            get
            {
                return _Vendedor;
            }

            set
            {
                _Vendedor = value;
            }
        }

        public List<Linea> Lineas
        {
            get
            {
                return _Lineas;
            }

            set
            {
                _Lineas = value;
            }
        }

        public decimal Cotizacion
        {
            get
            {
                return _Cotizacion;
            }

            set
            {
                _Cotizacion = value;
            }
        }

        public string Detalle
        {
            get
            {
                return _Detalle;
            }

            set
            {
                _Detalle = value;
            }
        }

        public string Env_Nombre
        {
            get
            {
                if (_env_Nombre == null)
                {
                    return string.Empty;
                }
                return _env_Nombre;
            }

            set
            {
                _env_Nombre = value;
            }
        }

        public string Env_Direccion
        {
            get
            {
                if (_env_Direccion == null)
                {
                    return string.Empty;
                }
                return _env_Direccion;
            }

            set
            {
                _env_Direccion = value;
            }
        }

        public string Env_telefono
        {
            get
            {
                if (_env_telefono == null)
                {
                    return string.Empty;
                }
                return _env_telefono;
            }

            set
            {
                _env_telefono = value;
            }
        }

        public string Env_observaciones
        {
            get
            {
                if (_env_observaciones == null)
                {
                    return string.Empty;
                }
                return _env_observaciones;
            }

            set
            {
                _env_observaciones = value;
            }
        }

        public bool Presupuesto
        {
            get
            {
                return _presupuesto;
            }

            set
            {
                _presupuesto = value;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

      
        public decimal Subtotal()
        {
            decimal zSuma = 0;
            foreach (Linea L in _Lineas)
                zSuma += L.SubTotal();
            return zSuma;
        }

        public decimal IvaTotal() {
            decimal ivaTot = 0;
            foreach (Linea L in _Lineas)
               
                    ivaTot += L.IvaTotal();
             
               
            return ivaTot;
        }

        public decimal IvaTotal(int xcodmoneda, decimal xCotizacion)
        {
            decimal ivaTot = 0;
            foreach (Linea L in _Lineas)
                if (L.Articulo.CodMoneda == xcodmoneda)
                {
                    ivaTot += L.IvaTotal();
                }
            else
                {
                    ivaTot += L.IvaTotal()*xCotizacion;

                }
              


            return ivaTot;
        }

        public decimal Subtotal(int xcodmoneda, decimal xCotizacion)
        {
            decimal zSuma = 0;
            foreach (Linea L in _Lineas)
                if (L.Articulo.CodMoneda == xcodmoneda)
                {
                    zSuma += L.SubTotal();
                }
                else
                {
                    zSuma += L.SubTotal()* xCotizacion;

                }
            return zSuma;
        }

    }


}
