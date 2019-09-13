using JJ.Entidades;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JJ.Mappers
{
    public class MapperPersonas : DataAccess, IMapperPersonas
    {

        public bool Add(object xObject)
        {
            

            if (xObject is Proveedor)
                addProveedor(xObject);

            if (xObject is Persona)
                addPersona(xObject);

            return true;
        }

        private void addPersona(object xPersona)
        {
            Persona P = (Persona)xPersona;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO PERSONAS(CEDULA,RUT,NOMBRE,APELLIDO,DIRECCION,DIRNUMERO,NUMEROAPTO,TELEFONO,CELULAR,PAIS,CIUDAD,CODCATEGORIA,EMAIL,ACTIVA) VALUES (@CEDULA,@RUT,@NOMBRE,@APELLIDO,@DIRECCION,@DIRNUMERO,@NUMEROAPTO,@TELEFONO,@CELULAR,@PAIS,@CIUDAD,@CODCATEGORIA,@EMAIL,@ACTIVA)", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CEDULA", P.Cedula));
                    Com.Parameters.Add(new SqlParameter("@RUT", P.Rut));
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", P.Nombre));
                    Com.Parameters.Add(new SqlParameter("@DIRECCION", P.Direccion));
                    Com.Parameters.Add(new SqlParameter("@DIRNUMERO", P.DireccionNumero));
                    Com.Parameters.Add(new SqlParameter("@NUMEROAPTO", P.DireccionApto));
                    Com.Parameters.Add(new SqlParameter("@TELEFONO", P.Telefono));
                    Com.Parameters.Add(new SqlParameter("@CELULAR", P.Celular));
                    Com.Parameters.Add(new SqlParameter("@PAIS", P.Pais));
                    Com.Parameters.Add(new SqlParameter("@CIUDAD", P.Ciudad));
                    Com.Parameters.Add(new SqlParameter("@CODCATEGORIA", P.ObjCategoria.Codigo));
                    Com.Parameters.Add(new SqlParameter("@EMAIL", P.Email));
                    Com.Parameters.Add(new SqlParameter("@ACTIVA", 1));
                    ExecuteNonQuery(Com);
                }

            }
        }

        private void addProveedor(object xProveedor)
        {
            Proveedor Pv = (Proveedor)xProveedor;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO PROVEEDORES(NOMBRE,RZ,RUT,DIRECCION,DIRNUMERO,TELEFONO,CELULAR,CODCATEGORIA,EMAIL) VALUES (@NOMBRE,@RZ,@RUT,@DIRECCION,@DIRNUMERO,@TELEFONO,@CELULAR,@CODCATEGORIA,@EMAIL)", Con))
                {
                    List<IDataParameter> P = new List<IDataParameter>();
                    P.Add(new SqlParameter("@NOMBRE", Pv.Nombre));
                    P.Add(new SqlParameter("@RZ", Pv.Rz));
                    P.Add(new SqlParameter("@RUT", Pv.Rut));
                    P.Add(new SqlParameter("@DIRECCION", Pv.Direccion));
                    P.Add(new SqlParameter("@DIRNUMERO", Pv.Dirnumero));
                    P.Add(new SqlParameter("@TELEFONO", Pv.Telefono));
                    P.Add(new SqlParameter("@CELULAR", Pv.Celular));
                    P.Add(new SqlParameter("@CODCATEGORIA", Pv.Categoria));
                    P.Add(new SqlParameter("@EMAIL", Pv.Email));
                    ExecuteNonQuery(Com, P);
                }

            }
        }

        public IList<object> getCategoriasProveedor()
        {
            IList<object> CatsProveedor = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CAT.CODIGO,CAT.NOMBRE AS DESCRIPCION FROM CATEGORIASPROVEEDORES CAT", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            ;
                            CatsProveedor.Add(getCategoriaFromReader(Reader,"P"));
                        }
                    }
                }
            }
            return CatsProveedor;
        }

        public IList<object> getCategoriasPersona()
        {
            IList<object> CatCliente = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CAT.CODIGO,CAT.DESCRIPCION FROM CATEGORIASCLIENTE CAT", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            CatCliente.Add(getCategoriaFromReader(Reader,"C"));
                        }
                    }
                }
            }
            return CatCliente;
        }

        public object getCategoriasProveedorByID(int xCodigo)
        {
            object ObjCat = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 CAT.CODIGO,CAT.NOMBRE AS DESCRIPCION FROM CATEGORIASPROVEEDORES CAT WHERE CAT.CODIGO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {

                            ObjCat = getCategoriaFromReader(Reader, "P");
                        }
                    }
                }
            }
            return ObjCat; 
        }

        public IList<object> getMonedas()
        {
            return MapperGeneral.getInstance().getMonedas();
        }

        public IList<object> getProveedores()
        {
            IList<object> Proveedores = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT P.CODIGO,P.NOMBRE,P.RZ,P.RUT,P.DIRECCION,P.DIRNUMERO,P.TELEFONO,P.CELULAR,P.CODCATEGORIA,P.EMAIL FROM PROVEEDORES P", Con))
                {

                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            object P = getProveedorFromReader(Reader);
                            Proveedores.Add(P);
                        }
                    }
                }
            }
            return Proveedores;
        }

        private Proveedor getProveedorFromReader(IDataReader Reader)
        {
            Proveedor Entity = null;
            int Codigo = (int)Reader["CODIGO"];
            string Nombre = (string)Reader["NOMBRE"];
            Entity = new Proveedor(Codigo);
            Entity.Direccion = (string)Reader["DIRECCION"];
            Entity.Dirnumero = (string)Reader["DIRNUMERO"];
            Entity.Email = (string)Reader["EMAIL"];
            Entity.Nombre = Nombre;
            Entity.Rut = (string)Reader["RUT"];
            Entity.Rz = (string)Reader["RZ"];
            Entity.Telefono = (string)Reader["TELEFONO"];
            Entity.Celular = (string)Reader["CELULAR"];
            Entity.Categoria = (int)Reader["CODCATEGORIA"];
            return Entity;
        }

        public object getPersona(string xCodPersona)
        {
            Persona objP=null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM PERSONAS WHERE CODIGO=@CODIGO OR CEDULA=@CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodPersona));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                   
                        if(Reader.Read())
                        {
                            int xCodigo = (int)Reader["CODIGO"];
                            string xCedula = (string)Reader["CEDULA"];
                            string xNombre = (string)Reader["NOMBRE"];
                            string xApellido = (string)Reader["APELLIDO"];
                            string xDireccion = (string)(Reader["DIRECCION"] is DBNull ? string.Empty : Reader["DIRECCION"]);
                            string xDirNumero = (string)Reader["DIRNUMERO"];
                            string xNumeroApto = (string)(Reader["NUMEROAPTO"] is DBNull ? string.Empty : Reader["NUMEROAPTO"]);
                            string xTelefono = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);
                            string xCelular = (string)(Reader["CELULAR"] is DBNull ? string.Empty : Reader["CELULAR"]);
                            string xPais = (string)Reader["PAIS"];
                            string xCiudad = (string)(Reader["CIUDAD"] is DBNull ? string.Empty : Reader["CIUDAD"]);
                            Categoria Cat = (CatCliente)getCategoriaPersonaByID((int)Reader["CODCATEGORIA"]);
                            string xEmail = (string)(Reader["EMAIL"] is DBNull ? string.Empty : Reader["EMAIL"]);
                            int xActiva = (int)Reader["ACTIVA"];
                            objP = new Persona(xCodigo, xCedula, xNombre, xApellido, xDireccion, xDirNumero,xNumeroApto,xTelefono,xCelular,xPais,xCiudad,Cat,xEmail,xActiva);
                            objP.AddCuentas(getCuentasByCliente(xCodigo));
                        }
                    }
                }
            }

            return objP;
        }

        public object getCategoriaPersonaByID(int xCodigo)
        {
            object objCategoria = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT C.CODIGO,C.DESCRIPCION FROM CATEGORIASCLIENTE AS C WHERE C.CODIGO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            objCategoria = getCategoriaFromReader(Reader,"C");
                        }
                    }
                }
            }
            return objCategoria;
        }

        public Cuenta getCuenta(int xCodPersona, int xCuenta)
        {
            Cuenta objCuenta=null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM CUENTAS WHERE CODIGO=@CODIGO AND CODPERSONA=@CODPERSONA", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCuenta));
                    Com.Parameters.Add(new SqlParameter("@CODPERSONA", xCodPersona));
                
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        if (Reader.Read())
                        {
                            objCuenta = new Cuenta((int)Reader["CODIGO"], (int)Reader["CODTIPO"], (string)Reader["RAZONSOCIAL"], (string)Reader["DIRECCION"], (string)Reader["NUMDIRECCION"], (string)Reader["RUT"], (string)Reader["TELEFONO"], (string)Reader["CELULAR"], (string)Reader["EMAILPRINCIPAL"], (byte)Reader["ACTIVA"]);
                          
                        }
                    }
                }
            }

            return objCuenta;
        }

        private List<Cuenta> getCuentasByCliente(int xIdCliente)
        {
            List<Cuenta> Cuentas = new List<Cuenta>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CODIGO,CODTIPO,RAZONSOCIAL,DIRECCION,NUMDIRECCION,RUT,TELEFONO,CELULAR,EMAILPRINCIPAL,ACTIVA FROM CUENTAS WHERE  CODPERSONA=@CODPERSONA", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODPERSONA", xIdCliente));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        Cuenta objCuenta;
                        while (Reader.Read())
                        {
                            int xCodigo = (int)Reader["CODIGO"];
                            int xCodTipo = (int)Reader["CODTIPO"];
                            string xRz = (string)Reader["RAZONSOCIAL"];

                            string xDireccion = (string)(Reader["DIRECCION"] is DBNull ? string.Empty : Reader["DIRECCION"]);
                            string xNumDir = (string)(Reader["NUMDIRECCION"] is DBNull ? string.Empty : Reader["NUMDIRECCION"]);
                            string xRut = (string)(Reader["RUT"] is DBNull ? string.Empty : Reader["RUT"]);
                            string xTelefono = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);
                            string xCelular = (string)(Reader["CELULAR"] is DBNull ? string.Empty : Reader["CELULAR"]);
                            string xEmail = (string)(Reader["EMAILPRINCIPAL"] is DBNull ? string.Empty : Reader["EMAILPRINCIPAL"]);
                            byte xActiva = Convert.ToByte((Reader["ACTIVA"] is DBNull ? 0 : Reader["ACTIVA"]));

                            objCuenta = new Cuenta(xCodigo,xCodTipo,xRz,xDireccion,xNumDir,xRut,xTelefono,xCelular,xEmail,xActiva);
                            Cuentas.Add(objCuenta);
                        }
                    }
                }
            }
            return Cuentas;
        }


        public bool Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object xObject)
        {
            if (xObject is Proveedor)
            {
                UpdateProveedor((Proveedor)xObject);
                return true;
            }
            return true;
        }

        private void UpdateProveedor(Proveedor xObject)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("UPDATE PROVEEDORES SET NOMBRE=@NOMBRE,RZ=@RZ,RUT=@RUT,DIRECCION=@DIRECCION,DIRNUMERO=@NUMERO,TELEFONO=@TELEFONO,CELULAR=@CELULAR,CODCATEGORIA=@CODCATEGORIA,EMAIL=@EMAIL where CODIGO = @CODIGO",Con))
                {
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", xObject.Nombre));
                    Com.Parameters.Add(new SqlParameter("@RZ", xObject.Rz));
                    Com.Parameters.Add(new SqlParameter("@RUT", xObject.Rut));
                    Com.Parameters.Add(new SqlParameter("@DIRECCION", xObject.Direccion));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xObject.Dirnumero));
                    Com.Parameters.Add(new SqlParameter("@TELEFONO", xObject.Telefono));
                    Com.Parameters.Add(new SqlParameter("@CELULAR", xObject.Celular));
                    Com.Parameters.Add(new SqlParameter("@CODCATEGORIA", xObject.Categoria));
                    Com.Parameters.Add(new SqlParameter("@EMAIL", xObject.Email));
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xObject.Codigo));
                    ExecuteNonQuery(Com);
                }
            }
        }

        private Categoria getCategoriaFromReader(IDataReader Reader,string xType)
        {
            Categoria Cat = null;
            int Codigo = (int)Reader["CODIGO"];
            string Nombre = (string)Reader["DESCRIPCION"];
            if (xType == "C")
                Cat = new CatCliente(Codigo, Nombre);
            if (xType == "P")
                Cat = new CatProveedor(Codigo, Nombre);
            return Cat;
            
        }

        public object getClienteContadobyID(string xCodCliente)
        {
            ClienteContado objc = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM CLIENTESCONTADO WHERE DOCUMENTO=@CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodCliente));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        if (Reader.Read())
                        {
                            int xCodigo = (int)Reader["CODIGO"];
                            string xDocumento = (string)(Reader["DOCUMENTO"] is DBNull ? string.Empty : Reader["DOCUMENTO"]);
                            string xNombre = (string)Reader["NOMBRE"];
                            string xDireccion = (string)(Reader["DIRECCION"] is DBNull ? string.Empty : Reader["DIRECCION"]);
                            string xTelefono = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);

                            objc = new ClienteContado(xCodigo,xDocumento,xNombre,xDireccion,xTelefono);
           
                        }
                    }
                }
            }

            return objc;
        }

        public object getClienteContadobyDoc(string xDoc)
        {
            ClienteContado objc = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM CLIENTESCONTADO WHERE DOCUMENTO=@DOC", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@DOC", xDoc));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        if (Reader.Read())
                        {
                            int xCodigo = (int)Reader["CODIGO"];
                            string xDocumento = (string)(Reader["DOCUMENTO"] is DBNull ? string.Empty : Reader["DOCUMENTO"]);

                            string xNombre = (string)Reader["NOMBRE"];
                            string xDireccion = (string)(Reader["DIRECCION"] is DBNull ? string.Empty : Reader["DIRECCION"]);
                            string xTelefono = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);

                            objc = new ClienteContado(xCodigo, xDocumento, xNombre, xDireccion, xTelefono);

                        }
                    }
                }
            }

            return objc;
        }

        public object getAllClientes(bool xTodos)
        {
            DataTable DT;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(CONVERT(VARCHAR(8),CODIGO),'') CODIGO, ISNULL(DOCUMENTO,'') AS DOCUMENTO,ISNULL(NOMBRE,'') NOMBRE,ISNULL(DIRECCION,'') AS DIRECCION,ISNULL(CONVERT(VARCHAR(8),TELEFONO),'') AS TELEFONO FROM  CLIENTESCONTADO", (SqlConnection)Con))
                {
                    DT = new DataTable();
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public int addclienteContado(object xCC)
        {
            ClienteContado CC = (ClienteContado)xCC;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO CLIENTESCONTADO(CODIGO,DOCUMENTO,NOMBRE,DIRECCION,TELEFONO) VALUES (@CODIGO,@DOCUMENTO,@NOMBRE,@DIRECCION,@TELEFONO)", Con))
                {
                    int codigo = getMaxCodigoCC();
                    codigo += 1;
                    Com.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    Com.Parameters.Add(new SqlParameter("@DOCUMENTO", CC.Documento));
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", CC.Nombre));
                    Com.Parameters.Add(new SqlParameter("@DIRECCION", CC.Direccion.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@TELEFONO", CC.Telefono));
                    ExecuteNonQuery(Com);
                    return codigo;
                }

            }
        }

        private int getMaxCodigoCC()
        {
            int Numero = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT MAX(CODIGO) NUMERO FROM CLIENTESCONTADO", (SqlConnection)Con))
                {
                    Numero = (int)ExecuteScalar(Com);
                }
            }
            return Numero;
        }

        public void addCatProveedor(object xCategoriaProveedor)
        {
            int Codigo = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO CATEGORIASPROVEEDORES(NOMBRE) OUTPUT INSERTED.CODIGO VALUES (@NOMBRE)", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", ((CatProveedor)xCategoriaProveedor).Nombre.ToUpper()));
                    var Result = ExecuteScalar(Com);
                    int.TryParse(Result.ToString(), out Codigo);
                }

            }
        }

        public object getVistaProveedores()
        {
            DataTable DT = new DataTable();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM dbo.JL_ProveedoresView", (SqlConnection)Con))
                {
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public Proveedor getProveedorByID(string xCod)
        {
            Proveedor P = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 P.CODIGO,P.NOMBRE,P.RZ,P.RUT,P.DIRECCION,P.DIRNUMERO,P.TELEFONO,P.CELULAR,P.CODCATEGORIA,P.EMAIL FROM PROVEEDORES P WHERE CODIGO = @CODIGO OR RUT = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCod));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            P = getProveedorFromReader(Reader);
                        }
                    }
                }
            }
            return P;
        }

        public Proveedor getProveedorByRut(string xRut)
        {
            Proveedor P = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 P.CODIGO,P.NOMBRE,P.RZ,P.RUT,P.DIRECCION,P.DIRNUMERO,P.TELEFONO,P.CELULAR,P.CODCATEGORIA,P.EMAIL FROM PROVEEDORES P WHERE RUT = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xRut));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            P = getProveedorFromReader(Reader);
                        }
                    }
                }
            }
            return P;
        }
    }
}
