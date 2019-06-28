using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{

    /* Se controlaran el ingreso de tarifas, los precios de los articulos y los costos de compras */

    public class GesPrecios
    {
        private static GesPrecios _Instance = null;
        private static IMapperPrecios DBPrecios;
        private static readonly object padlock = new object();

        public static GesPrecios getInstance()
        {
            if (_Instance == null)
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesPrecios();
                }
            }

            return _Instance;
        }

        public GesPrecios()
        {
            DBPrecios = (IMapperPrecios)Factory.getMapper(this.GetType());
        }

        public void addTarifa(Tarifa xTarifa)
        {
            if (xTarifa == null)
                throw new Exception("La tarifa no puede ser nula");
            if (string.IsNullOrEmpty(xTarifa.Nombre) || xTarifa.Nombre.Length > 20)
                throw new Exception("El nombre de la tarifa no cumple con los requerimientos");
            DBPrecios.AddTarifa(xTarifa);
        }

        public IList<object> getTarifas()
        {
            return DBPrecios.getTarifas();
        }

        public IList<object> getMonedas()
        {
            return DBPrecios.getMonedas();
        }

        public Moneda getMonedaByID(int xCodMoneda)
        {
            return (Moneda)DBPrecios.getMonedaByID(xCodMoneda);
        }

        public decimal getCotizacion()
        {
            return DBPrecios.getCotizacion();
        }



    }
}
