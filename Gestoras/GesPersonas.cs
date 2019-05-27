using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
        private IList<object> _CategoriasPersona;

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
            _CategoriasPersona = _DBPersonas.getCategoriasPersona();
        }

        public void AddEmpresa(Empresa xEmpresa)
        {

            if (xEmpresa == null)
                return;

            if (xEmpresa.CodEmpresa != -1)
                return;

            if (xEmpresa.Nombre.Length < 4 || xEmpresa.Nombre.Length > 100)
                throw new Exception("El nombre de la empresa no es valido. [Length 4-100]");

            if (xEmpresa.Razonsocial.Length < 3 || xEmpresa.Razonsocial.Length > 100)
                throw new Exception("La razon social de la empresa no es valida. [Length 3-100]");

            if (!Tools.Numeros.ValidaRut(xEmpresa.Rut.Trim()))
                throw new Exception("El rut no se puede validar, o ya esta ingresada la empresa");

            if (xEmpresa.Direccion.Length < 5 || xEmpresa.Direccion.Length > 100)
                throw new Exception("No se puede guardar esa direccion.[Length 5-100]");

            if (xEmpresa.Ciudad.Length < 2 || xEmpresa.Ciudad.Length > 50)
                throw new Exception("No se puede ingresar esa ciudad. [Length 2-50]");

            if (xEmpresa.Pais.Length < 4 || xEmpresa.Ciudad.Length > 50)
                throw new Exception("No se puede ingresar ese Pais. [Length 4-50]");

            if (xEmpresa.Telefono.Length < 9)
                if (!Tools.Numeros.isNumeric(xEmpresa.Telefono))
                    throw new Exception("No se puede ingresar ese telefono. [Only number.]");
                else
                    throw new Exception("No se puede ingresar ese telefono. [Max 8.]");

            if (xEmpresa.Email.Length < 100)
                if (!xEmpresa.Email.Contains("@"))
                    throw new Exception("El email no se puede validar. [Must contain: @]");
                else
                    throw new Exception("El direccion de correo electronico no valida en este sistema. [Max 100.]");

            _DBPersonas.addEmpresa(xEmpresa);
        }

        public Proveedor getProveedorById(string xCod)
        {
            Proveedor P = null;

            if (xCod.Length < 10) {
                P = _getProveedorById(xCod);
                
            }else{
                P = _getProveedorByRut(xCod);
                if (P == null)
                    P = _DBPersonas.getProveedorByRut(xCod);
            }
            if (P == null)
                throw new Exception("No se puede encontrar el proveedor buscado");
            else
                return P;
        }

        private Proveedor _getProveedorById(string xCod)
        {
            foreach (object P in _Proveedores)
            {
                if (((Proveedor)P).Codigo.Equals( Convert.ToInt32(xCod)))
                    return (Proveedor)P;
            }
            return null;
        }

        private Proveedor _getProveedorByRut(string xCod)
        {
            foreach (object P in _Proveedores)
            {
                if (((Proveedor)P).Rut.Equals(xCod))
                    return (Proveedor)P;
            }
            return null;
        }

        public ClienteContado addClienteContado(ClienteContado xCC)
        {
            if (xCC.Codigo == 1)
                return null;

            ClienteContado CC = getClienteContadoByDoc(xCC.Documento);

            if (CC != null)
                return CC;

            if (xCC.Documento.Length > 12)
            {
                throw new Exception("El rut ingresado no es valido. [Length 5-12]");
            }
            if (xCC.Documento.Length < 11)
                if (!Tools.Numeros.VerificaDocumento(Convert.ToInt32(xCC.Documento)))
                    throw new Exception("La cedula ingresada no se puede verificar");

            if (xCC.Telefono.Length > 9 || !Tools.Numeros.isNumeric(xCC.Telefono))
                throw new Exception("El Telefono/Celular ingresado no es correcto. [Length 9]");

            if (xCC.Nombre.Length > 50)
                xCC.Nombre = xCC.Nombre.Substring(0, 49);
            if (xCC.Direccion.Length > 200)
                xCC.Direccion = xCC.Direccion.Substring(0, 49);

            int xCodigo = _DBPersonas.addclienteContado(xCC);

            return new ClienteContado(xCodigo, xCC.Documento, xCC.Nombre, xCC.Direccion, xCC.Telefono);

        }

        public void AddProveedor(Proveedor xProveedor)
        {
            if (xProveedor == null)
                return;
            if (xProveedor.Nombre.Length < 5 || xProveedor.Nombre.Length > 50)
                throw new Exception("El nombre del proveedor no es valido. [Length 5-50]");
            if (xProveedor.Rz.Length < 4 || xProveedor.Rz.Length > 50)
                throw new Exception("La razon social del proveedor no es valido. [Length 4-50]");
            if (xProveedor.Direccion.Length > 50)
                throw new Exception("La direccion del proveedor no es valida. [Length 4-50]");
            if (xProveedor.Dirnumero.Length < 11)
            {
                if (!Tools.Numeros.isNumeric(xProveedor.Dirnumero))
                    throw new Exception("El numero de calle no es correcto. [Must be only numbers]");
            }
            else
                throw new Exception("El numero de calle es demasiado largo. [Max 10]");


            if (!Tools.Numeros.ValidaTelefono(xProveedor.Telefono))
                throw new Exception("El telefono ingresado no es valido");


            if (!Tools.Numeros.ValidaCelular(xProveedor.Celular))
                throw new Exception("El celular ingresado no es valido");


            if (xProveedor.Email.Length < 100)
            {
                if (!xProveedor.Email.Contains("@"))
                    throw new Exception("El email no se puede validar. [Must contain: @]");
            } else
                    throw new Exception("El direccion de correo electronico no valida en este sistema. [Max 100.]");

            if (xProveedor.Categoria < 1 || !_ExisteCategoria(xProveedor.Categoria, _CategoriasProveedores))
                throw new Exception("La categoria del proveedor no es correcta");

            if (!Tools.Numeros.ValidaRut(xProveedor.Rut) || _ExisteProveedorByRut(xProveedor.Rut))
                throw new Exception("Ya existe un proveedor con el rut que intenta registrar");

            _DBPersonas.Add(xProveedor);
        }

        public Empresa getEmpresa()
        {
            return (Empresa)_DBPersonas.getempresa();
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

            if (Cat.Codigo == xCodigo)
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


        public object getPersonaById(string xId)
        {
            return (Persona)_DBPersonas.getPersona(xId);
        }

        public IList<object> getCategoriasCliente()
        {
            return _CategoriasPersona;
        }

        public object TablaClientesContado()
        {
            return _DBPersonas.getAllClientes(true);
        }

        public ClienteContado getClienteContadoByID(int xCodCLienteContado)
        {
            return (ClienteContado)_DBPersonas.getClienteContadobyID(xCodCLienteContado);
        }

        public ClienteContado getClienteContadoByDoc(string xDoc)
        {
            return (ClienteContado)_DBPersonas.getClienteContadobyDoc(xDoc);
        }

        public void addCatProveedor(CatProveedor xCategoriaProveedor)
        {
            _DBPersonas.addCatProveedor(xCategoriaProveedor);
            _CategoriasProveedores = _DBPersonas.getCategoriasProveedor();
        }

        public DataTable getVistaProveedores()
        {
            return (DataTable)_DBPersonas.getVistaProveedores();
        }



    }
}
