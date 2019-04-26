using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Entidades;

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
        object getAllClientes(bool xTodos);

        object getClienteContadobyID(int xCodCliente);

        object getClienteContadobyDoc(string xDoc);
        int addclienteContado(object xCC);
    }
}
