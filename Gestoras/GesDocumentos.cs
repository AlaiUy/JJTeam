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
        private static IMapperDocumentos _DBDocumentos;
        private static readonly object padlock = new object();


        public void GesFacturar(object xObjFactura, int xZ)
        {

            _DBDocumentos.Add(xObjFactura);
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

        public void AddEspera(object xEspera)
        {
            EsperaContado E = (EsperaContado)xEspera;
            _DBDocumentos.Add(E);
        }

        public void IngresarCompra(AlbaranCompra xCompra)
        {

            _DBDocumentos.Add(xCompra);
        }


    }

}
