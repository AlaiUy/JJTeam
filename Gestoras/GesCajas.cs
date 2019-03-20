using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{
    public class GesCajas
    {
        private static GesCajas _Instance = null;
        private static IMapperCajas _DBCajas;
        private static readonly object _padlock = new object();
        private Caja _Caja;

        public Caja Caja
        {
            get
            {
                return _Caja;
            }
        }

        public static GesCajas getInstance()
        {
            if (_Instance == null)
            {
                lock (_padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesCajas();
                }
            }

            return _Instance;
        }

        public GesCajas()
        {
            _DBCajas = (IMapperCajas)Factory.getMapper(this.GetType());
            _Caja = (Caja)_DBCajas.getCaja();
        }

        public void AgregarPago(int xMoneda, decimal xImporte, decimal xCotizacion, string xComentario)
        {
            if (xCotizacion < 1)
                throw new Exception("La cotizacion ingresada es incorrecta. [Must be >= 1]");

            if(xComentario.Length < 1 || xComentario.Length > 50)
                throw new Exception("El comentario ingresado no es valido. [Length 4-50]");

            _DBCajas.AgregarPago(xMoneda, xImporte, xCotizacion, xComentario, _Caja.Codigo, _Caja.Z);
        }
    }
}
