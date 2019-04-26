using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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
            if(!string.IsNullOrEmpty(xArticulo.Descripcion))
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


            if (xArticulo.Ganancia < 1)
                throw new Exception(String.Format("la ganancia del articulo es negativa en tarifa: {0}", xArticulo.Ganancia));

            if (xArticulo.Precio() < 1)
                throw new Exception("El precio no es correcto");

            if (GesPrecios.getInstance().getMonedaByID(xArticulo.CodMoneda) == null)
                throw new Exception("La moneda ingresada no es valida.");

            DBArticulos.Add(xArticulo);


            return true;
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

        public IList<object> getArticulos()
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

        public Articulo getArticuloById(string xCodigo)
        {
            Articulo A = (Articulo)DBArticulos.getArticuloById(xCodigo);
            if (A != null)
                return A;
            throw new Exception("No se encontro el articulo");
        }
    }
}
