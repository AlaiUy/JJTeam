using JJ.Entidades;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JJ.Mappers
{
    public class MapperCajas: DataAccess,IMapper
    {
        public bool Add(object xObject)
        {
            Caja C = (Caja)xObject;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO CAJAS(CODIGO,NOMBRE) VALUES (@CODIGO,@NOMBRE)", Con))
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

        

        public Caja getCajaById(int xCodigo)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT C.CODIGO,C.NOMBRE FROM CAJAS C WHERE C.CODIGO = @CODIGO ", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            return getCajaFromReader(Reader);
                        }
                    }
                }
            }
            return null;
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

        private Caja getCajaFromReader(IDataReader Reader)
        {
            int Codigo = (int)Reader["CODIGO"];
            string Nombre = (string)Reader["NOMBRE"];
            List<Seriedoc> L = new MapperDocumentos().getDocumentosByCaja(Codigo);
            Caja C = new Caja(Codigo, Nombre, L);
            return C;
        }
    }
}
