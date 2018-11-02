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
    public class MapperDocumentos : DataAccess, IMapperDocumentos
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
        public void addEspera(object xEspera)
        {
            
            GuardarEspera(xEspera);
                    
        }

        private void GuardarEspera(object xEspera)
        {
            Espera E = (Espera)xEspera;
            int Codigo = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    try
                    {
                        int CodEspera = -1;
                        List<IDataParameter> P = new List<IDataParameter>();
                        P.Add(new SqlParameter("@FECHA", DateTime.Today));
                        P.Add(new SqlParameter("@MONEDA", E.Codmoneda));
                        P.Add(new SqlParameter("@CODPERSONA", E.ObjCliente.Cedula));
                        P.Add(new SqlParameter("@CODCUENTA", E.ObjCuenta));
                        P.Add(new SqlParameter("@ESTADO", E.Estado));
                        P.Add(new SqlParameter("@TIPO", E.Tipo));
                        P.Add(new SqlParameter("@NOMBREOPC", E.Nombreopc));
                        P.Add(new SqlParameter("@DIROPC", E.DirOpc));
                        P.Add(new SqlParameter("@RUTOPC", E.RutOpc));
                        P.Add(new SqlParameter("@ADENDA", E.Adenda));
                        using (SqlCommand Com = new SqlCommand("INSERT INTO ESPERA(FECHA,MONEDA,CODPERSONA,CODCUENTA,ESTADO,TIPO,NOMBREOPC,DIROPC,RUTOPC,ADENDA) OUTPUT INSERTED.CODIGO VALUES (@FECHA,@MONEDA,@CODPERSONA,@CODCUENTA,@ESTADO,@TIPO,@NOMBREOPC,@DIROPC,@RUTOPC,@ADENDA)", (SqlConnection)Con))
                        {
                            Com.Transaction = (SqlTransaction)Tran;
                            var Result = ExecuteScalar(Com, P);
                            int.TryParse(Result.ToString(), out CodEspera);
                        }
                        AgregarLineasEspera(E.Lineas, Con, Tran, CodEspera);
                        Tran.Commit();
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
            }
        }

        private void AgregarLineasEspera(List<Esperalin> lineas, SqlConnection xCon, SqlTransaction xTran, int xEspera)
        {
            foreach (object L in lineas)
            {
                Esperalin EL = (Esperalin)L;
                List<IDataParameter> Lin = new List<IDataParameter>();
                Lin.Add(new SqlParameter("@CODESPERA", xEspera));
                Lin.Add(new SqlParameter("@CODARTICULO", EL.CodArticulo));
                Lin.Add(new SqlParameter("@CANTIDAD", EL.Cantidad));
                Lin.Add(new SqlParameter("@PRECIO", EL.Precio));
                Lin.Add(new SqlParameter("@DESCUENTO", EL.Descuento));
                Lin.Add(new SqlParameter("@IVA", EL.Iva));
                Lin.Add(new SqlParameter("@CODIGO", EL.NumLinea));
                using (SqlCommand Com = new SqlCommand("INSERT INTO ESPERALIN (CODESPERA,CODARTICULO,CANTIDAD,PRECIO,DESCUENTO,IVA,CODIGO) VALUES (@CODESPERA,@CODARTICULO,@CANTIDAD,@PRECIO,@DESCUENTO,@IVA,@CODIGO)", (SqlConnection)xCon))
                {
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com, Lin);
                }
            }
        }

        public List<object> getVentasEspera()
        {
            List<object> LtsEspera = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT E.CODIGO,E.FECHA,E.MONEDA,E.CODVENDEDOR,E.CODPERSONA,E.CODCUENTA,E.ESTADO,E.TIPO,E.NOMBREOPC,E.DIROPC,E.RUTOPC,E.ADENDA FROM ESPERA E where estado=1 order by codigo asc", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            DateTime Fecha = (DateTime)Reader["FECHA"];
                            Espera E = new Espera(Codigo, Fecha);
                            E.Estado = (int)Reader["ESTADO"];
                            E.Codmoneda = (int)Reader["MONEDA"];
                            E.Adenda = (string)(Reader["ADENDA"] is DBNull ? string.Empty : Reader["ADENDA"]);
                            E.ObjCliente =  new MapperPersonas().getPersona((int)Reader["CODPERSONA"]);
                            E.ObjCuenta = new MapperPersonas().getCuenta((int)Reader["CODPERSONA"],(int)Reader["CODCUENTA"]);
                            E.ObjVendedor =(Vendedor) new MapperVendedores().getVendedorByID((int)Reader["CODVENDEDOR"]);
                            E.Tipo = (int)Reader["TIPO"];
                            E.Nombreopc = (string)(Reader["NOMBREOPC"] is DBNull ? string.Empty : Reader["NOMBREOPC"]);
                            E.DirOpc = (string)(Reader["DIROPC"] is DBNull ? string.Empty : Reader["DIROPC"]);
                            E.RutOpc = (string)(Reader["RUTOPC"] is DBNull ? string.Empty : Reader["RUTOPC"]);
                            E.AgregarLineas(getLineasEspera(Codigo));
                            LtsEspera.Add(E);
                        }
                    }
                }
            }
            return LtsEspera;
        }

        private List<Esperalin> getLineasEspera(int xIDEspera)
        {
            List<Esperalin> Lineas = new List<Esperalin>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT L.CODESPERA,L.LINEA, L.CODARTICULO,L.CANTIDAD,L.PRECIO,L.DESCUENTO,L.IVA,L.DESCRIPCION FROM ESPERALIN L WHERE CODESPERA = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xIDEspera));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int codEspera = (int)Reader["CODESPERA"];
                            int NumLin = (int)Reader["LINEA"];
                            Esperalin L = new Esperalin(codEspera,NumLin);
         
                            L.Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
                            L.CodArticulo = (int)Reader["CODARTICULO"];
                            L.Descripcion = (string)Reader["DESCRIPCION"];
                            L.Descuento = Convert.ToDecimal(Reader["DESCUENTO"]);
                            L.Iva = Convert.ToDecimal(Reader["IVA"]);
                            L.Precio = Convert.ToDecimal(Reader["PRECIO"]);
                            Lineas.Add(L);
                        }
                    }
                }
            }
            return Lineas;
        }
    }
}


        