using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{
    public class GesDocumentos
    {
        private static GesDocumentos _Instance = null;
        private static IMapperDocumentos DBDocumentos;
        private static readonly object padlock = new object();

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
            DBDocumentos = (IMapperDocumentos)Factory.getMapper(GetType());
        }
        
        /*
        public void addEspera(Espera xEspera)
        {
            if (xEspera.Codcliente < 1)
                xEspera.Codcliente = 1;

            if (xEspera.Codcuenta < 1)
                xEspera.Codcuenta = 1;

            if(xEspera.Lineas.Count < 1)
                throw new Exception("La venta no tiene ninguna linea");

            Espera E = new Espera();
            E.Adenda = "hola";
            E.Codcliente = 1;
            E.Codcuenta = 1;
            E.DirOpc = "hola1";
            E.Codmoneda = 1;
            Esperalin EL = new Esperalin(1,1);
            EL.Cantidad = 1;
            EL.CodArticulo = 1;
            EL.Descripcion = "Anca";
            EL.Descuento = 0;
            EL.Iva = 22;
            EL.Precio = 100;
            E.AgregarLinea(EL);
            DBDocumentos.addEspera(E);
        }
        */
        public List<object> getListaEspera()
        {
            return DBDocumentos.getVentasEsperaContado();
        }
    }

}
