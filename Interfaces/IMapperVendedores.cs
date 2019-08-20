using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
   

    public interface IMapperVendedores : IMapper
    {
         List<object> getVendedores();

         object getVendedorByID(int xCodigo);


    }
}
