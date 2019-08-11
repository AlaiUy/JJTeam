using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperCajas:IMapper
    {
        void AgregarPago(int xMoneda, decimal xImporte, decimal xCotizacion, string xComentario, string xCaja, int xZ);

        void Eliminarpago(int xNumeroPago);

        int getZByPago(int xNumeroPago);

        object getPagoByFecha(DateTime xFecha, string xCaja); //Devuelve un datatable

        object getCaja();

        void CierreCaja(decimal xCierrePesos, decimal xCierreDolares, string xCaja, int xZ, int xCodVendedor);
        
       int getSaldoDeclarados(string xCaja, int xCodMoneda, int xtipo);

        object getCajaById(string xCodigo);
    }
}
