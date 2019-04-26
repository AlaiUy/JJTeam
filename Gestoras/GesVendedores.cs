using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace JJ.Gestoras
{
    public class GesVendedores
    {

        private static GesVendedores _Instance = null;
        private static IMapperVendedores DBVendedores;
        private static readonly object padlock = new object();

        public static GesVendedores getInstance()
        {
            if (_Instance == null)
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesVendedores();
                }
            }

            return _Instance;
        }

        public GesVendedores()
        {
            DBVendedores = (IMapperVendedores)Factory.getMapper(this.GetType());
        }

        public IList<object> getListaVendedores()
        {
            return DBVendedores.getVendedores();
        }

        public Vendedor getVendedorByID(int xId)
        {
            return (Vendedor)DBVendedores.getVendedorByID(xId);
        }

    }
}
