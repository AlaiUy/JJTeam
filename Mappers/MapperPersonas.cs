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
            throw new NotImplementedException();
        }

        public void addProveedor(object xProveedor)
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
                using (SqlCommand Com = new SqlCommand("SELECT CAT.CODIGO,CAT.NOMBRE FROM CATEGORIASPROVEEDORES CAT", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            CatsProveedor.Add(new CatProveedor(Codigo, Nombre));
                        }
                    }
                }
            }
            return CatsProveedor;
        }

        public object getCategoriasProveedorByID(int xCodigo)
        {
            object ObjCat = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 CAT.CODIGO,CAT.NOMBRE FROM CATEGORIASPROVEEDORES CAT WHERE CAT.CODIGO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            ObjCat = new CatProveedor(Codigo, Nombre);
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
                        Proveedor Entity;
                        while (Reader.Read())
                        {
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
                            Proveedores.Add(Entity);
                        }
                    }
                }
            }
            return Proveedores;
        }

        public bool Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object xObject)
        {
            throw new NotImplementedException();
        }
    }
}
