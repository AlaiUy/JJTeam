using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperCajas:IMapper
    {
        void AgregarPago(int xMoneda, decimal xImporte, decimal xCotizacion, string xComentario, string xCaja, int xZ);

        object getCaja();
    }
}
