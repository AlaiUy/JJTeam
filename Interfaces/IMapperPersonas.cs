using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperPersonas : IMapper
    {
        
        IList<object> getCategoriasProveedor();
        object getCategoriasProveedorByID(int xCodigo);
        IList<object> getProveedores();

        IList<object> getCategoriasPersona();

        void addEmpresa(object xEmpresa);
        object getempresa();

        object getPersona(string xId);
    }
}
