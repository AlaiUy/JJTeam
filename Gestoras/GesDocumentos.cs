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
            EsperaContado E = new EsperaContado(DateTime.Now);
            E.Adenda = "Buenas";
            E.Codclientecontado = 2;
            E.Codmoneda = 1;
            E.Codvendedor = 1;
            E.DirEnvio = "Barbieri 1080";
            E.Estado = 0;
            List<Esperalin> Lineas = new List<Esperalin>();
            Esperalin E1 = new Esperalin();
            E1.Cantidad = 1;
            E1.Descripcion = "PORTLAND";
            E1.Descuento = 0;
            E1.NumLinea = 1;
            E1.ObjArticulo = GesArticulos.getInstance().getArticuloById("2");
            Lineas.Add(E1);
            Esperalin E2 = new Esperalin();
            E2.Cantidad = 2;
            E2.Descripcion = "PORTLAND 1";
            E2.Descuento = 0;
            E2.NumLinea = 2;
            E2.ObjArticulo = GesArticulos.getInstance().getArticuloById("2");
            Lineas.Add(E2);
            E.AgregarLineas(Lineas);
            _DBDocumentos.Add(E);
        }
    }

}
