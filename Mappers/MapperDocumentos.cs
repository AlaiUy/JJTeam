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

        enum TipoLineas
        {
            Contado,
            Credito,
        }

        public bool Add(object xObject)
        {
            if (xObject is VentaCuenta)
                return true;
            if (xObject is VentaContado)
                return true;
            if(xObject is EsperaContado )
                GuardarEsperaContado(xObject);

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
        

        private void GuardarEsperaContado(object xEspera)
        {
            EsperaContado E = (EsperaContado)xEspera;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                        int xCodEspera = -1;
                        List<IDataParameter> P = new List<IDataParameter>();
                        using (SqlCommand Com = new SqlCommand("INSERT INTO ESPERACONTADO(FECHA,MONEDA,CODVENDEDOR,CLIENTECONTADO, ESTADO, TIPO, DIRECCIONENVIO, ADENDA) OUTPUT INSERTED.CODIGO VALUES (@FECHA,@MONEDA,@CODVENDEDOR, @CLIENTECONTADO, @ESTADO, @TIPO, @DIRECCIONENVIO, @ADENDA)", (SqlConnection)Con))
                        {
                            Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Today));
                            Com.Parameters.Add(new SqlParameter("@MONEDA", E.Codmoneda));
                            Com.Parameters.Add(new SqlParameter("@CODVENDEDOR", E.Codvendedor));
                            Com.Parameters.Add(new SqlParameter("@CLIENTECONTADO", E.Codclientecontado));
                            Com.Parameters.Add(new SqlParameter("@ESTADO", E.Estado));
                            Com.Parameters.Add(new SqlParameter("@TIPO", E.Tipo));
                            Com.Parameters.Add(new SqlParameter("@DIRECCIONENVIO", E.DirEnvio));
                            Com.Parameters.Add(new SqlParameter("@ADENDA", E.Adenda));
                            Com.Transaction = (SqlTransaction)Tran;
                            var Result = ExecuteScalar(Com, P);
                            int.TryParse(Result.ToString(), out xCodEspera);
                        }
                        AddLineasEspera(E.Lineas, Con, Tran, xCodEspera,TipoLineas.Contado);
                        Tran.Commit();
                }
            }
        }

        private void AddLineasEspera(List<Esperalin> lineas, SqlConnection xCon, SqlTransaction xTran, int xCodEsperaContado,TipoLineas xTipo)
        {
            string Query="";

            if (xTipo == TipoLineas.Contado)
                Query = "INSERT INTO ESPERALINCONTADO (CODESPERACONTADO, LINEA, CODARTICULO, DESCRIPCION, CANTIDAD, DESCUENTO) VALUES(@CODESPERACONTADO, @LINEA, @CODARTICULO, @DESCRIPCION, @CANTIDAD, @DESCUENTO)";
           if (xTipo == TipoLineas.Credito)
                Query = "";//INSERT INTO ESPERALINCONTADO (CODESPERACONTADO, LINEA, CODARTICULO, DESCRIPCION, CANTIDAD, DESCUENTO) VALUES(@CODESPERACONTADO, @LINEA, @CODARTICULO, @DESCRIPCION, @CANTIDAD, @DESCUENTO)

            foreach (object L in lineas)
            {
                Esperalin EL = (Esperalin)L;
                using (SqlCommand Com = new SqlCommand(Query, (SqlConnection)xCon))
                {
                    Com.Parameters.Add(new SqlParameter("@CODESPERACONTADO", xCodEsperaContado));
                    Com.Parameters.Add(new SqlParameter("@LINEA", EL.NumLinea));
                    Com.Parameters.Add(new SqlParameter("@CODARTICULO", EL.ObjArticulo.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION", EL.Descripcion));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", EL.Cantidad));
                    Com.Parameters.Add(new SqlParameter("@DESCUENTO", EL.Descuento));
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }

        public List<object> getVentasEsperaContado()
        {
            List<object> LtsEspera = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT E.CODIGO,E.FECHA,E.MONEDA,E.CODVENDEDOR,E.CLIENTECONTADO,E.ESTADO,E.TIPO,E.DIRECCIONENVIO,E.ADENDA FROM ESPERACONTADO E where estado=1 order by codigo asc", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            DateTime Fecha = (DateTime)Reader["FECHA"];
                            int xCodMoneda = (int)Reader["MONEDA"];
                            int xCodVendedor = (int)Reader["CODVENDEDOR"];
                            int xCliente = (int)Reader["CLIENTECONTADO"];
                            string xAdenda = (string)(Reader["ADENDA"] is DBNull ? string.Empty : Reader["ADENDA"]);
                            string xEnvio = (string)(Reader["DIRECCIONENVIO"] is DBNull ? string.Empty : Reader["DIRECCIONENVIO"]);
                            int xTipo = (int)Reader["TIPO"];
                            int xEstado = (int)Reader["ESTADO"];
                            EsperaContado E = new EsperaContado(Codigo,Fecha,xCodVendedor,xCliente,xCodMoneda,xAdenda,xEnvio,xEstado,xTipo);
                            E.AgregarLineas(getLineasEsperaContado(Codigo));
                            LtsEspera.Add(E);
                        }
                    }
                }
            }
            return LtsEspera;
        }

        private List<Esperalin> getLineasEsperaContado(int xIDEspera)
        {
            List<Esperalin> Lineas = new List<Esperalin>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT L.CODESPERACONTADO,L.LINEA, L.CODARTICULO,L.DESCRIPCION,L.CANTIDAD,L.DESCUENTO FROM ESPERALINCONTADO L WHERE CODESPERACONTADO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xIDEspera));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int codEspera = (int)Reader["CODESPERACONTADO"];
                            int NumLin = (int)Reader["LINEA"];

                            Esperalin L = new Esperalin();
         
                            L.Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
                         L.ObjArticulo =(Articulo) (new MapperArticulos().getArticuloById((Reader["CODARTICULO"]).ToString()));
                            L.Descripcion = (string)Reader["DESCRIPCION"];
                            L.Descuento = Convert.ToDecimal(Reader["DESCUENTO"]);
                     
                            Lineas.Add(L);
                        }
                    }
                }
            }
            return Lineas;
        }

        public Boolean Facturar(Factura xObjFactura)
        {
          
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    int xCodEspera = -1;
                    List<IDataParameter> P = new List<IDataParameter>();
                    using (SqlCommand Com = new SqlCommand("INSERT INTO VENTAS(CODSERIE, CODCAJA, FECHA, CODMONEDA, Z, CODVENDEDOR, CODDOCUMENTO) OUTPUT INSERTED.CODIGO VALUES (@CODSERIE, @CODCAJA, @FECHA, @CODMONEDA, @Z, @CODVENDEDOR, @CODDOCUMENTO)", (SqlConnection)Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@CODSERIE", xObjFactura.Serie));
                        Com.Parameters.Add(new SqlParameter("@CODCAJA", "cajaa"));
                        Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Today));
                        Com.Parameters.Add(new SqlParameter("@CODMONEDA", xObjFactura.Moneda.Codigo));
                        Com.Parameters.Add(new SqlParameter("@Z", "z"));
                        Com.Parameters.Add(new SqlParameter("@CODVENDEDOR", xObjFactura.Vendedor));
                        Com.Parameters.Add(new SqlParameter("@CODDOCUMENTO", xObjFactura.Documento));
             
                        Com.Transaction = (SqlTransaction)Tran;
                        var Result = ExecuteScalar(Com, P);
                        int.TryParse(Result.ToString(), out xCodEspera);
                    }
                    AddLineasEspera(E.Lineas, Con, Tran, xCodEspera, TipoLineas.Contado);
                    Tran.Commit();
                }
            }


            return false;

        }

        private void AddLineasFactura(List<Facturalin> lineas, SqlConnection xCon, SqlTransaction xTran, int xFacturaID)
        {
            string Query = "";

                Query = "INSERT INTO VENTASLIN (CODSERIE, NUMERO, LINEA, CODARTICULO, REFERENCIA, DESCRIPCION, CANTIDAD, PRECIO, DTO, IVA) VALUES(@CODSERIE, @NUMERO, @LINEA, @CODARTICULO, @REFERENCIA, @DESCRIPCION, @CANTIDAD, @PRECIO, @DTO,@IVA)";
         
            foreach (object L in lineas)
            {
                VentaLin EL = (VentaLin)L;
                using (SqlCommand Com = new SqlCommand(Query, (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    //Com.Parameters.Add(new SqlParameter("@CODSERIE", "SERIE"));
                    //Com.Parameters.Add(new SqlParameter("@NUMERO", xFacturaID));
                    //Com.Parameters.Add(new SqlParameter("@LINEA", EL.));
                    //Com.Parameters.Add(new SqlParameter("@CODARTICULO", ));
                    //Com.Parameters.Add(new SqlParameter("@REFERENCIA", ));
                    //Com.Parameters.Add(new SqlParameter("@DESCRIPCION", ));
                    //Com.Parameters.Add(new SqlParameter("@CANTIDAD", ));
                    //Com.Parameters.Add(new SqlParameter("@PRECIO", ));
                    //Com.Parameters.Add(new SqlParameter("@DTO", ));
                    //Com.Parameters.Add(new SqlParameter("@IVA", ));
                    //Com.Transaction = (SqlTransaction)xTran;
                    //ExecuteNonQuery(Com);
                }
            }
        }





    }
}


        