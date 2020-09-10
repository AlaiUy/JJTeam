using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

namespace JJ.Gestoras
{
    public class GesArticulos
    {
        private static GesArticulos _Instance = null;
        private static IMapperArticulos DBArticulos;
        private static readonly object padlock = new object();

        public static GesArticulos getInstance()
        {
            if (_Instance == null)
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesArticulos();
                }
            }

            return _Instance;
        }

        public GesArticulos()
        {
            DBArticulos = (IMapperArticulos)Factory.getMapper(this.GetType());
        }

        public bool AddArticulo(Articulo xArticulo)
        {


            if (xArticulo == null)
                throw new Exception("El articulo es incorrecto");
            if (xArticulo.CodArticulo > 0)
                throw new Exception("El Articulo ya existe");
            if (!string.IsNullOrEmpty(xArticulo.Descripcion))
                if (xArticulo.Descripcion.Length > 100)
                    throw new Exception("La descripcion no cumple con la longuitud necesaria");
            if (string.IsNullOrEmpty(xArticulo.Referencia) || xArticulo.Referencia.Length > 11)
                throw new Exception("La referencia ingresada no es aceptada");
            if (xArticulo.Nombre.Length > 50)
                throw new Exception("El nombre del articulo ingresada no correcto");
            if (xArticulo.Coddepto < 1)
                throw new Exception("El departamento ingresado no es valido o no existe");
            if (xArticulo.Codmarca < 1)
                throw new Exception("La marca ingresada no es valida o no existe");
            if (xArticulo.Codseccion < 1)
                throw new Exception("La seccion ingresada no es valida");


            if (xArticulo.Ganancia < 0)
                throw new Exception(String.Format("la ganancia del articulo es negativa", xArticulo.Ganancia));

            if (xArticulo.Precio() < 0)
                throw new Exception("El precio no es correcto");

            if (GesPrecios.getInstance().getMonedaByID(xArticulo.CodMoneda) == null)
                throw new Exception("La moneda ingresada no es valida.");

            xArticulo.Activo = true;

            DBArticulos.Add(xArticulo);


            return true;
        }

        

        public DataTable getVistaArticulos()
        {
            return (DataTable)DBArticulos.getVistaArticulos();
        }

        public DataTable getVistaArticulosOff()
        {
            return (DataTable)DBArticulos.getVistaArticulosDescatalogados();
        }

        public DataTable getListadoArticulos()
        {
            return (DataTable)DBArticulos.getListadoArticulos();
        }

        public void Descatalogar(int xCodArticulo)
        {

        }

        public Marca AddMarca(Marca xMarca)
        {
            if (xMarca == null)
                throw new Exception("La marca no puede ser nula");
            if (string.IsNullOrEmpty(xMarca.Nombre) || xMarca.Nombre.Length > 20)
                throw new Exception("La longuitud del nombre de la marca es incorrecta");

            return (Marca)DBArticulos.AddMarca(xMarca);
        }

        public Departamento AddDepto(Departamento xDpto)
        {
            if (xDpto == null)
                throw new Exception("La marca no puede ser nula");
            if (string.IsNullOrEmpty(xDpto.Nombre) || xDpto.Nombre.Length > 20)
                throw new Exception("La longuitud del nombre de la marca es incorrecta");
            if (xDpto.Codigo > 0)
                throw new Exception("El departamento ya se encuentra ingresado");

            return (Departamento)DBArticulos.AddDepartamento(xDpto);
        }

        public IList<object> getDepartamentos()
        {
            return DBArticulos.getDepartamentos();
        }

        public IList<object> getMarcas()
        {
            return DBArticulos.getMarcas();
        }


        /// <summary>
        /// Devuelve una lista de JJ.entidades.Articulos
        /// </summary>
        public List<Articulo> getArticulos()
        {
            List<Articulo> L = new List<Articulo>();
            foreach (object o in _getArticlos())
                L.Add((Articulo)o);
            return L;
        }
        private IList<object> _getArticlos()
        {
            return DBArticulos.getArticulos();
        }

        

        public Seccion addSeccion(Seccion xSeccion, Departamento xDepartamento)
        {
            if (xDepartamento == null || xSeccion == null)
                throw new Exception("No es posible registrar una seccion con valores nulos");


            if (string.IsNullOrEmpty(xSeccion.Nombre) || xSeccion.Nombre.Length > 20)
                throw new Exception("La longuitud del nombre de la seccion es incorrecta");

            if (xDepartamento.Codigo < 1)
                throw new Exception("No se puede agregar una seccion en un departamento inexistente");


            return (Seccion)DBArticulos.AddSeccion(xSeccion, xDepartamento);
        }

        public Articulo getArticuloByRef(string xCodigo)
        {
            Articulo A = (Articulo)DBArticulos.getArticuloByRef(xCodigo);
            if (A != null)
                return A;
            if( A == null)
                throw new Exception("No se encontro el articulo");
            if(!A.Activo)
                throw new Exception("El articulo esta descatalogado");
            return null;
        }

        public Articulo getArticuloById(string xCodigo)
        {
            Articulo A = (Articulo)DBArticulos.getArticuloById(xCodigo);
            if (A != null)
                return A;
            if (A == null)
                throw new Exception("No se encontro el articulo");
            if (!A.Activo)
                throw new Exception("El articulo esta descatalogado");
            return null;
        }

        public void ActualizarArticulo(Articulo xArticulo, decimal xCosto, decimal xGanancia)
        {
            if (xArticulo == null)
                throw new Exception("El articulo es incorrecto");
            
            if (!string.IsNullOrEmpty(xArticulo.Descripcion))
                if (xArticulo.Descripcion.Length > 100)
                    throw new Exception("La descripcion no cumple con la longuitud necesaria");
            if (string.IsNullOrEmpty(xArticulo.Referencia) || xArticulo.Referencia.Length > 11)
                throw new Exception("La referencia ingresada no es aceptada");
            if (xArticulo.Nombre.Length > 50)
                throw new Exception("El nombre del articulo ingresada no correcto");
            if (xArticulo.Coddepto < 1)
                throw new Exception("El departamento ingresado no es valido o no existe");
            if (xArticulo.Codmarca < 1)
                throw new Exception("La marca ingresada no es valida o no existe");
            if (xArticulo.Codseccion < 1)
                throw new Exception("La seccion ingresada no es valida");


            if (xGanancia <= 0)
                throw new Exception(String.Format("La ganancia del articulo es negativa", xGanancia));

            if(xCosto <= 0)
                throw new Exception(String.Format("El costo no puede ser menor a 0", xCosto));

            DBArticulos.Actualizar(xArticulo, xGanancia, xCosto);

        }

        public void UpdateStock(Articulo xArticulo, decimal xCantidad)
        {
            if (xArticulo == null)
                throw new Exception("No se puede validar ese articulo");
            if (xCantidad <= 0)
                throw new Exception("La cantidad a asignar debe ser mayor que 0");

            DBArticulos.UpdateStock(xArticulo, xCantidad);
        }
    }
}
