using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{
    public class GesPersonas
    {
        private static GesPersonas _Instance = null;
        private static IMapperPersonas _DBPersonas;
        private static readonly object _padlock = new object();
        private IList<object> _CategoriasProveedores;
        private IList<object> _Proveedores;

        public static GesPersonas getInstance()
        {
            if (_Instance == null)
            {
                lock (_padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesPersonas();
                }
            }

            return _Instance;
        }

        public GesPersonas()
        {
            _DBPersonas = (IMapperPersonas)Factory.getMapper(this.GetType());
            _CategoriasProveedores = _DBPersonas.getCategoriasProveedor();
            _Proveedores = _DBPersonas.getProveedores();
        }

        public void AddProveedor(Proveedor xProveedor)
        {

            if (xProveedor == null)
                return;
            if (xProveedor.Nombre.Length < 1 || xProveedor.Nombre.Length > 20)
                throw new Exception("El nombre del proveedor no es valido");
            if (xProveedor.Rz.Length < 1 || xProveedor.Rz.Length > 50)
                throw new Exception("La razon social del proveedor no es valido");
            if (xProveedor.Direccion.Length > 50)
                throw new Exception("La direccion del proveedor no es valida");
            if (xProveedor.Dirnumero.Length > 10)
                throw new Exception("El numero de calle no es correcto ");
            if (xProveedor.Telefono.Length > 1)
                if (!Tools.Numeros.ValidaTelefono(xProveedor.Telefono))
                    throw new Exception("El telefono ingresado no es valido");
            if (xProveedor.Celular.Length > 1)
                if (!Tools.Numeros.ValidaCelular(xProveedor.Celular))
                    throw new Exception("El celular ingresado no es valido");
            if (xProveedor.Email.Length > 50)
                throw new Exception("La direccion del proveedor no es valida");
            if(xProveedor.Categoria < 1 || !_ExisteCategoria(xProveedor.Categoria,_CategoriasProveedores))
                throw new Exception("La categoria del proveedor no es correcta");
            if(!Tools.Numeros.ValidaRut(xProveedor.Rut) || _ExisteProveedorByRut(xProveedor.Rut))
                throw new Exception("Ya existe un proveedor con el rut que intenta registrar");

            _DBPersonas.addProveedor(xProveedor);
        }

        public IList<object> getCategoriasProveedor()
        {
            return _CategoriasProveedores;
        }

        public IList<object> getProveedores()
        {
            return _Proveedores;
        }

        private bool _ExisteCategoria(int xCodigo, IList<object> ListaCategoria)
        {
            Categoria Cat = null;
            foreach (object O in ListaCategoria)
            {
                Cat = (Categoria)O;
                if (Cat.Codigo == xCodigo)
                    return true;
            }

            if (Cat is CatProveedor)
                Cat = (Categoria)_DBPersonas.getCategoriasProveedorByID(xCodigo);
            
            if(Cat.Codigo == xCodigo)
                return true;
            return false;
        }

        private bool _ExisteProveedorByRut(string xRut)
        {
            foreach (object O in _Proveedores)
            {
                Proveedor P = (Proveedor)O;
                if (P.Rut == xRut)
                    return true;
            }
            return false;
        }




    }
}
