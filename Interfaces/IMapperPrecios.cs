using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Entidades;

namespace JJ.Interfaces
{
    public interface IMapperPrecios:IMapper 
    {
        void AddTarifa(object xTarifa);
        IList<object> getTarifas();
        void AgregarMoneda(object xMoneda);
        Moneda getMonedaByID(int xCodMoneda);

        decimal getCotizacion();
    }
}
