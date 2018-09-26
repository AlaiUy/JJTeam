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
            if(xArticulo.CodArticulo > 0)
                throw new Exception("El Articulo ya existe");
            if(xArticulo.Descripcion.Length > 100)
                throw new Exception("La descripcion no cumple con la longuitud necesaria");
            if (string.IsNullOrEmpty(xArticulo.Referencia) || xArticulo.Referencia.Length > 11)
                throw new Exception("La referencia ingresada no es aceptada");
            if(xArticulo.Nombre.Length > 50)
                throw new Exception("La referencia ingresada no correcto");
            if(xArticulo.Precios.Count < 1)
                throw new Exception("Este articulo no tiene precios para la venta");

            foreach (PreciosVenta P in xArticulo.Precios)
            {
                if (P.Ganancia < 1)
                    throw new Exception(String.Format("la ganancia del articulo es negativa en tarifa: {0}", P.CodTarifa));
              
                if (P.Precio() < 1)
                    throw new Exception("El precio no es correcto");
            }

            DBArticulos.Add(xArticulo);
                
                
            return true;
        }

        public void Descatalogar(int xCodArticulo)
        {

        }

        public void AddMarca(Marca xMarca)
        {
            if (xMarca == null)
                throw new Exception("La marca no puede ser nula");
            if(xMarca.Nombre.Length < 1 || xMarca.Nombre.Length > 20)
                throw new Exception("La longuitud del nombre de la marca es incorrecta");

            DBArticulos.AddMarca(xMarca);
        }

        public void AddDepto(Departamento xDpto)
        {
            if (xDpto == null)
                throw new Exception("La marca no puede ser nula");
            if (xDpto.Nombre.Length < 1 || xDpto.Nombre.Length > 20)
                throw new Exception("La longuitud del nombre de la marca es incorrecta");
            if(xDpto.Codigo > 0)
                throw new Exception("El departamento ya se encuentra ingresado");

            DBArticulos.AddDepartamento(xDpto);
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
    }
}
