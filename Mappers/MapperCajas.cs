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
    public class MapperCajas: DataAccess,IMapperCajas
    {
        public bool Add(object xObject)
        {
            Caja C = (Caja)xObject;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO CAJAS(CODIGO,NOMBRE) VALUES (@CODIGO,@NOMBRE)", Con))
                {
                    //List<IDataParameter> P = new List<IDataParameter>();
                    //P.Add(new SqlParameter("@NOMBRE", Pv.Nombre));
                    //P.Add(new SqlParameter("@RZ", Pv.Rz));
                    //P.Add(new SqlParameter("@RUT", Pv.Rut));
                    //P.Add(new SqlParameter("@DIRECCION", Pv.Direccion));
                    //P.Add(new SqlParameter("@DIRNUMERO", Pv.Dirnumero));
                    //P.Add(new SqlParameter("@TELEFONO", Pv.Telefono));
                    //P.Add(new SqlParameter("@CELULAR", Pv.Celular));
                    //P.Add(new SqlParameter("@CODCATEGORIA", Pv.Categoria));
                    //P.Add(new SqlParameter("@EMAIL", Pv.Email));
                    //ExecuteNonQuery(Com, P);
                }

            }
            return true;
        }
        
        public void AgregarPago(int xMoneda,decimal xImporte,decimal xCotizacion,string xComentario,string xCaja, int xZ)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO PAGOS(CAJA,NUMERO,FECHA,HORA,CODMONEDA,IMPORTE,COTIZACION,COMENTARIO,ZCAJA) VALUES (@CAJA,(SELECT ISNULL(MAX(NUMERO),0) FROM PAGOS) + 1,@FECHA,@HORA,@CODMONEDA,@IMPORTE,@COTIZACION,@COMENTARIO,@ZCAJA)", Con))
                {
                    DateTime xFecha = DateTime.Now;
                    Com.Parameters.Add(new SqlParameter("@CAJA",xCaja));
                    Com.Parameters.Add(new SqlParameter("@FECHA", xFecha.ToShortDateString()));
                    Com.Parameters.Add(new SqlParameter("@HORA", xFecha.ToShortTimeString()));
                    Com.Parameters.Add(new SqlParameter("@CODMONEDA", xMoneda));
                    Com.Parameters.Add(new SqlParameter("@IMPORTE", xImporte));
                    Com.Parameters.Add(new SqlParameter("@COTIZACION", xCotizacion));
                    Com.Parameters.Add(new SqlParameter("@COMENTARIO", xComentario));
                    Com.Parameters.Add(new SqlParameter("@ZCAJA", xZ));
                    ExecuteNonQuery(Com);
                }

            }

        }


        public object getCaja()
        {
            Caja C = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT E.VALOR FROM EPARAMETROS AS E  INNER JOIN PARAMETROS AS P ON E.IDPAR = P.IDPAR AND P.NOMBRE = 'CAJA' INNER JOIN EQUIPOS AS EQ ON EQ.IDEQUIPO = E.IDEQUIPO WHERE EQ.NOMBRE = @EQUIPO ", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@EQUIPO", Environment.MachineName));
                    string xSerieCaja = Convert.ToString(ExecuteScalar(Com));
                    C = getCajaById(xSerieCaja);
                    
                }
            }
            return C;
        }

        private Caja getCajaById(string xCodigo)
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
            string Codigo = (string )Reader["CODIGO"];
            string Nombre = (string)Reader["NOMBRE"];
            List<Seriedoc> L = new MapperDocumentos().getDocumentosByCaja(Codigo);
            Caja C = new Caja(Codigo, Nombre, L);
            return C;
        }
    }
}
