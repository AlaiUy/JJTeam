using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperArticulos : IMapper
    {
        void AddMarca(object xMarca);
        void AddDepartamento(object xDepto);
        IList<object> getDepartamentos();
        IList<object> getMarcas();
        IList<object> getArticulos();
    }
}
