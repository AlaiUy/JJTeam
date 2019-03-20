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
                            Com.Parameters.Add(new SqlParameter("@DIRECCIONENVIO", E.DirEnvio.ToUpper()));
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

        public void Facturar(object xObjFactura,int xZ)
        {
            Factura F = (Factura)xObjFactura;
            int NumeroFactura = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    NumeroFactura = ObtenerNumeroFactura(Con, Tran);
                    using (SqlCommand Com = new SqlCommand("INSERT INTO VENTAS(NUMERO, CODSERIE, CODCAJA, FECHA, CODMONEDA, Z, CODVENDEDOR, CODDOCUMENTO) VALUES (@NUMERO, @CODSERIE, @CODCAJA, @FECHA, @CODMONEDA, @Z, @CODVENDEDOR, @CODDOCUMENTO)", (SqlConnection)Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@NUMERO", NumeroFactura));
                        Com.Parameters.Add(new SqlParameter("@CODSERIE", F.Serie));
                        Com.Parameters.Add(new SqlParameter("@CODCAJA", F.CodCaja));
                        Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Today));
                        Com.Parameters.Add(new SqlParameter("@CODMONEDA", F.Codmoneda));
                        Com.Parameters.Add(new SqlParameter("@Z", xZ));
                        Com.Parameters.Add(new SqlParameter("@CODVENDEDOR", F.Vendedor));
                        Com.Parameters.Add(new SqlParameter("@CODDOCUMENTO", F.Documento));
                        Com.Transaction = (SqlTransaction)Tran;
                        ExecuteNonQuery(Com);
                        if (F is VentaContado)
                        {
                            Com.CommandText = "INSERT INTO VENTASCONTADO(NUMERO, SERIE, CLIENTECONTADO) VALUES (@NUMERO,@CODSERIE,@CLIENTE)";
                        
                            Com.Parameters.Add(new SqlParameter("@CLIENTE", ((VentaContado)F).Cliente.Codigo));
                            ExecuteNonQuery(Com);
                        }
                        else if (F is VentaCuenta)
                        {
                            Com.CommandText = "INSERT INTO VENTASCREDITO(NUMERO, SERIE, CODPERSONA,CODCUENTA,CODTARIFA) VALUES (@NUMERO,@SERIE,@PERSONA,@CUENTA,@TARIFA)";
                            
                            Com.Parameters.Add(new SqlParameter("@PERSONA", ((VentaCuenta)F).CodCLiente));
                            Com.Parameters.Add(new SqlParameter("@CUENTA", ((VentaCuenta)F).Cuenta.Codigo));
                            Com.Parameters.Add(new SqlParameter("@TARIFA", ((VentaCuenta)F).CodTarifa));
                            ExecuteNonQuery(Com);
                        }

                        else if (F is DevolucionContado)
                        {
                            Com.CommandText = "INSERT INTO VENTASCONTADO(NUMERO, SERIE, CLIENTECONTADO) VALUES (@NUMERO,@CODSERIE,@CLIENTE)";

                            Com.Parameters.Add(new SqlParameter("@CLIENTE", ((DevolucionContado)F).Cliente.Codigo));
                            ExecuteNonQuery(Com);

                            Com.CommandText = "UPDATE VENTAS SET CODSERIEANULA=@CODSERIEANULA, CODNUMEROANULA=@CODNUMEROANULA WHERE NUMERO=@NUMERO AND CODSERIE=@SERIE";
                            Com.Parameters.Add(new SqlParameter("@CODSERIEANULA", ((DevolucionContado)F).SerieReferencia));
                            Com.Parameters.Add(new SqlParameter("@CODNUMEROANULA", ((DevolucionContado)F).NumeroReferencia));
                            ExecuteNonQuery(Com);

                        }
                        else if (F is DevolucionCuenta)
                        {
                            Com.CommandText = "INSERT INTO VENTASCREDITO(NUMERO, SERIE, CODPERSONA,CODCUENTA,CODTARIFA) VALUES (@NUMERO,@SERIE,@PERSONA,@CUENTA,@TARIFA)";

                            Com.Parameters.Add(new SqlParameter("@PERSONA", ((DevolucionCuenta)F).CodCLiente));
                            Com.Parameters.Add(new SqlParameter("@CUENTA", ((DevolucionCuenta)F).Cuenta.Codigo));
                            Com.Parameters.Add(new SqlParameter("@TARIFA", ((DevolucionCuenta)F).CodTarifa));
                            ExecuteNonQuery(Com);

                            Com.CommandText = "UPDATE VENTAS SET CODSERIEANULA=@CODSERIEANULA, CODNUMEROANULA=@CODNUMEROANULA WHERE NUMERO=@NUMERO AND CODSERIE=@SERIE";
                            Com.Parameters.Add(new SqlParameter("@CODSERIEANULA", ((DevolucionCuenta)F).SerieReferencia));
                            Com.Parameters.Add(new SqlParameter("@CODNUMEROANULA", ((DevolucionCuenta)F).NumeroReferencia));
                            ExecuteNonQuery(Com);
                        }



                    }
                    AddLineasFactura(F.Lineas, Con, Tran, NumeroFactura,F.Serie);
                    Tran.Commit();
                }
            }
        }

        private void AddLineasFactura(List<object> lineas, SqlConnection xCon, SqlTransaction xTran, int xFacturaID, string xSerie)
        {
            foreach (object L in lineas)
            {
                VentaLin VL = (VentaLin)L;
                using (SqlCommand Com = new SqlCommand("INSERT INTO VENTASLIN (CODSERIE, NUMERO, LINEA, CODARTICULO, DESCRIPCION, CANTIDAD, PRECIO, DTO, IVA) VALUES(@CODSERIE, @NUMERO, @LINEA, @CODARTICULO, @DESCRIPCION, @CANTIDAD, @PRECIO, @DTO,@IVA)", (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    Com.Parameters.Add(new SqlParameter("@CODSERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xFacturaID));
                    Com.Parameters.Add(new SqlParameter("@LINEA",VL.NumLinea ));
                    Com.Parameters.Add(new SqlParameter("@CODARTICULO",VL.CodArticulo ));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION",VL.Descripcion.ToUpper() ));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD",VL.Cantidad ));
                    Com.Parameters.Add(new SqlParameter("@PRECIO",VL.Precio ));
                    Com.Parameters.Add(new SqlParameter("@DTO", VL.Descuento));
                    Com.Parameters.Add(new SqlParameter("@IVA",VL.Iva));
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }

        private int ObtenerNumeroFactura(SqlConnection xCon, SqlTransaction xTran)
        {
            int numero = 0;
            using (SqlCommand Com = new SqlCommand("SELECT ISNULL(MAX(NUMERO),0) AS NUMERO FROM VENTAS", (SqlConnection)xCon))
            {
                Com.Transaction = xTran;
                numero = Convert.ToInt32(ExecuteScalar(Com));
                using (IDataReader Reader = ExecuteReader(Com))
                {

                    if (Reader.Read())
                    {
                        numero = (int)Reader["NUMERO"] + 1 ;
                    
                    }
                }
            }
            return numero;
        }


        public List<Seriedoc> getDocumentosByCaja(string xCodCaja)
        {
            List<Seriedoc> ListDoc = new List<Seriedoc>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT D.NOMBRE,SC.SERIE,d.CODIGO FROM CAJAS C INNER JOIN SERIESCAJA SC ON C.CODIGO = SC.CODCAJA LEFT JOIN DOCUMENTOS D ON SC.CODDOCUMENTO = D.CODIGO  WHERE C.CODIGO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodCaja));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string xNombre = (string)(Reader["NOMBRE"] is DBNull ? string.Empty : Reader["NOMBRE"]);
                            string xSerie = (string)(Reader["SERIE"] is DBNull ? string.Empty : Reader["SERIE"]);
                            Seriedoc SD = new Seriedoc(Codigo, xNombre, xSerie);
                            ListDoc.Add(SD);
                        }
                    }
                }
            }
            return ListDoc;
        }
        
    }
}


        