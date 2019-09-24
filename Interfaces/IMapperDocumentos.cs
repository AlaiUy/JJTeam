using JJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperDocumentos:IMapper 
    {
        List<object> getVentasEsperaContado();

        List<object> getVentasContado(DateTime xfechaini, DateTime xfechafin);

        Documento getFacturaByID(string xSerie, int Numero, TipoLineas xTipo);
        object getVentas(DateTime xFechaI, DateTime xFechaF);

        //object getFacturaByID(string xSerie, int xNumero, TipoLineas xTipo);
    }
}
