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
    public class MapperVendedores : DataAccess, IMapperVendedores
    {
        public bool Add(object xObject)
        {
            Vendedor V = (Vendedor)xObject;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO VENDEDORES(NOMBRE,ACTIVO) VALUES (@NOMBRE,@ACTIVO)", Con))
                {
                    List<IDataParameter> P = new List<IDataParameter>();
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", V.Nombre.ToUpper().Trim()));
                    Com.Parameters.Add(new SqlParameter("@ACTIVO", 1));
                    ExecuteNonQuery(Com);
                }
            }
            return true;
        }

        public IList<object> getMonedas()
        {
            throw new NotImplementedException();
        }

        public bool Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object xObject)
        {
            throw new NotImplementedException();
        }

        public object getVendedorByID(int xCodigo)
        {
            object objVendedor = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT V.CODIGO,V.NOMBRE,V.ACTIVO FROM VENDEDORES AS V WHERE CODIGO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            objVendedor = getVendedorFromReader(Reader);
                        }
                    }
                }
            }
            return objVendedor;
        }

        private Vendedor getVendedorFromReader(IDataReader Reader)
        {
            Vendedor V;
            int Codigo = (int)Reader["CODIGO"];
            string Nombre = (string)Reader["NOMBRE"];
            bool Activo = Convert.ToBoolean(Reader["ACTIVO"]);
            //   byte Activa = (byte)Reader["ACTIVA"];
            V = new Vendedor(Codigo, Nombre, Activo);
            return V;
        }

        public List<object> getVendedores()
        {

            List<object> Vendedores = new List<object>();
            Vendedor Entity = null;

            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CODIGO, NOMBRE,ACTIVO FROM VENDEDORES", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            Entity = (Vendedor)getVendedorFromReader(Reader);
                            Vendedores.Add(Entity);
                        }
                    }
                }
            }
            return Vendedores;

        }
    }
}
