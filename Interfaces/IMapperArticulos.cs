using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Entidades;

namespace JJ.Interfaces
{
    public interface IMapperArticulos : IMapper
    {
        object AddMarca(object xMarca);
        object AddDepartamento(object xDepto);
        IList<object> getDepartamentos();
        IList<object> getMarcas();
        IList<object> getArticulos();
        object AddSeccion(object xSeccion,object xDepto);
        object getArticuloById(string xArticulo);
        object getVistaArticulos();

        object getVistaArticulosDescatalogados();
        

        void Actualizar(Articulo xArticulo, decimal xGanancia, decimal xCosto);
        void UpdateStock(object xArticulo, decimal xCantidad);
        object getArticuloByRef(string xCodigo);
    }
}
