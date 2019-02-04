using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperPersonas : IMapper
    {
        void addProveedor(object xProveedor);
        IList<object> getCategoriasProveedor();
        object getCategoriasProveedorByID(int xCodigo);
        IList<object> getProveedores();

        void addEmpresa(object xEmpresa);
    }
}
