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
            throw new NotImplementedException();
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
                using (SqlCommand Com = new SqlCommand("SELECT V.CODIGO,V.NOMBRE FROM VENDEDORES AS V WHERE CODIGO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            //   byte Activa = (byte)Reader["ACTIVA"];
                            objVendedor = new Vendedor(Codigo, Nombre);
                        }
                    }
                }
            }
            return objVendedor;
        }

        public IList<object> getVendedores()
        {

            IList<object> Vendedores = new List<object>();
            Vendedor Entity = null;

            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CODIGO, NOMBRE FROM VENDEDORES WHERE ACTIVO=1", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];

                            Entity = new Vendedor(Codigo, Nombre);
                            Vendedores.Add(Entity);
                        }
                    }
                }
            }
            return Vendedores;

        }
    }
}
