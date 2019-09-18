using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{
    public class GesCajas
    {
        private static GesCajas _Instance = null;
        private static IMapperCajas _DBCajas;
        private static readonly object _padlock = new object();
        private Grupo _Grupo;

        public Caja Caja
        {
            get
            {
                return _Grupo.Caja;
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
            _Grupo = GesEmpresa.getInstance().getGrupo();
        }

        public void AgregarPago(int xMoneda, decimal xImporte, decimal xCotizacion, string xComentario)
        {
            if (xCotizacion < 1)
                throw new Exception("La cotizacion ingresada es incorrecta. [Must be >= 1]");

            if(xComentario.Length < 1 || xComentario.Length > 50)
                throw new Exception("El comentario ingresado no es valido. [Length 4-50]");

            _DBCajas.AgregarPago(xMoneda, xImporte, xCotizacion, xComentario, Caja.Codigo, Caja.Z);
        }

        public void EliminarPago(int xNumeroPago)
        {
            if (xNumeroPago == -1)
                return;

            int zPago = _DBCajas.getZByPago(xNumeroPago);

            if (zPago == -1 || zPago != Caja.Z)
                return;

            _DBCajas.Eliminarpago(xNumeroPago);
        }

        public DataTable getPagos(DateTime xFecha, string xCaja)
        {
            if (xFecha == null & xCaja == null)
                return (DataTable)_DBCajas.getPagoByFecha(DateTime.Now, Caja.Codigo);

            if(xCaja == null)
                return (DataTable)_DBCajas.getPagoByFecha(xFecha, Caja.Codigo);

            if (xFecha == null)
                return (DataTable)_DBCajas.getPagoByFecha(DateTime.Now,xCaja);

            return (DataTable)_DBCajas.getPagoByFecha(xFecha, xCaja);
        }

        public int GetSaldoDeclarado( int xCodMoneda, int xtipo)
        {
            return _DBCajas.getSaldoDeclarados(Caja.Codigo,xCodMoneda, xtipo);

        }

        public void CierreCaja(decimal xPesos, decimal xDolares,int xcodVendedor )
        {

            _DBCajas.CierreCaja(xPesos, xDolares, Caja.Codigo, Caja.Z, xcodVendedor);

        }

        public Caja getCajaByID(string xCajaID)
        {
            return (Caja)_DBCajas.getCajaById(xCajaID);
        }

      

    }
}
