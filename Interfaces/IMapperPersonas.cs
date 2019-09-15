using System;
using System.Collections.Generic;
using System.Data;
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

       
        

        object getPersona(string xId);
        object getAllClientes(bool xTodos);

        object getClienteContadobyID(string xCodCliente);
        object getClienteContadobyDoc(string xCodCliente);
        
        int addclienteContado(object xCC);
        void addCatProveedor(object xCategoriaProveedor);
        object getVistaProveedores();
        Proveedor getProveedorByID(string xCod);

        Proveedor getProveedorByRut(string xRut);
    }
}
