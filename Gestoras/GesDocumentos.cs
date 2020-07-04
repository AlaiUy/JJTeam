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
    public class GesDocumentos
    {
        private static GesDocumentos _Instance = null;
        private static IMapperDocumentos _DBDocumentos;
        private static readonly object padlock = new object();


        public void GesFacturar(object xObjFactura, int xZ)
        {
            if(xObjFactura == null)
                throw new Exception("Documento no valido");

            if (xObjFactura is VentaContado)
            {
                VentaContado F = (VentaContado)xObjFactura;


                if (F.Caja.Length != 3)
                    throw new Exception("La caja ingresada no es valida");

                if (F.Vendedor < 1)
                    throw new Exception("El vendedor ingresado no es valido");
            }

            if (xObjFactura is DevolucionContado)
            {
                DevolucionContado D = (DevolucionContado)xObjFactura;
                if (D.Caja.Length != 3)
                    throw new Exception("La caja ingresada no es valida");

                if (D.Vendedor < 1)
                    throw new Exception("El vendedor ingresado no es valido");
            }

            _DBDocumentos.Add(xObjFactura);
        }


        public Entrega getEntrega(int xNumero, string xSerie)
        {
            return (Entrega)_DBDocumentos.getEntrega(xNumero, xSerie);
        }

        public static GesDocumentos getInstance()
        {
            if (_Instance == null)
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesDocumentos();
                }
            }

            return _Instance;
        }

        public GesDocumentos()
        {
            _DBDocumentos = (IMapperDocumentos)Factory.getMapper(GetType());
        }
        
       
        
        public List<object> getListaEspera()
        {
            return _DBDocumentos.getVentasEsperaContado();
        }

        public List<object> getListaEspera(int xEstado)
        {
            return _DBDocumentos.getVentasEsperaContado(xEstado);
        }

        public List<object> getListaVentaContado(DateTime xfechaini, DateTime xfechafin)
        {
            return _DBDocumentos.getVentasContado(xfechaini, xfechafin);
        }

        public void AddEspera(object xEspera)
        {
            EsperaContado E = (EsperaContado)xEspera;
            _DBDocumentos.Add(E);
        }

        public void IngresarCompra(AlbaranCompra xCompra)
        {
            xCompra.Serie = GesCajas.getInstance().Caja.getSerieByID(20).Serie;
            xCompra.FechaProveedor = DateTime.Now;
            xCompra.Fecha = DateTime.Now;
            _DBDocumentos.Add(xCompra);
        }

        public VentaContado getVentaDocumento(int xNumero, string xSerie, TipoLineas xtipo)
        {
           return (VentaContado)_DBDocumentos.getFacturaByID(xSerie, xNumero, xtipo);
        }

        public DataTable ListadoVentas(DateTime xFechaI, DateTime xFechaF)
        {
            return (DataTable)_DBDocumentos.getVentas(xFechaI, xFechaF);
        }

        public DataTable ListadoDevoluciones(DateTime xFechaI, DateTime xFechaF)
        {
            return (DataTable)_DBDocumentos.getDevoluciones(xFechaI, xFechaF);
        }

    }

}
