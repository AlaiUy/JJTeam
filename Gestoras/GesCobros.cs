using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{
    public class GesCobros
    {

        private static GesCobros _Instance = null;
        private static IMapperCobros _DBCobros;
        private static readonly object padlock = new object();

        public static GesCobros getInstance()
        {
            if (_Instance == null)
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesCobros();
                }
            }

            return _Instance;
        }

        public GesCobros()
        {
            _DBCobros = (IMapperCobros)Factory.getMapper(this.GetType());
        }
    }
}
