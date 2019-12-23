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
            throw new Exception("No implementado");
        }

        public void CrearCaja(Caja xCaja)
        {
            Caja C = xCaja;
            SqlTransaction T;
            try
            {
                using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
                {
                    Con.Open();
                    T = Con.BeginTransaction();
                    using (SqlCommand Com = new SqlCommand("INSERT INTO CAJAS(CODIGO,NOMBRE) VALUES (@CODIGO,@NOMBRE)", Con))
                    {
                        Com.Transaction = T;
                        Com.Parameters.Add(new SqlParameter("@CODIGO", C.Codigo));
                        Com.Parameters.Add(new SqlParameter("@NOMBRE", C.Nombre));
                        ExecuteNonQuery(Com);
                    }
                    foreach (Seriedoc S in C.Series)
                    {
                        using (SqlCommand Com = new SqlCommand("INSERT INTO SERIESCAJA(CODDOCUMENTO,CODCAJA,SERIE) VALUES (@DOCUMENTO,@CAJA,@SERIE)", Con))
                        {
                            Com.Transaction = T;
                            Com.Parameters.Add(new SqlParameter("@DOCUMENTO", S.Documento));
                            Com.Parameters.Add(new SqlParameter("@CAJA", C.Codigo));
                            Com.Parameters.Add(new SqlParameter("@SERIE", S.Serie));
                            ExecuteNonQuery(Com);
                        }
                    }
                    T.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
        public void AgregarPago(int xMoneda,decimal xImporte,decimal xCotizacion,string xComentario,string xCaja, int xZ)
        {
            xZ = 0;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO PAGOS(CAJA,NUMERO,FECHA,HORA,CODMONEDA,IMPORTE,COTIZACION,COMENTARIO,ZCAJA) VALUES (@CAJA,(SELECT ISNULL(MAX(NUMERO),0) FROM PAGOS) + 1,@FECHA,@HORA,@CODMONEDA,@IMPORTE,@COTIZACION,@COMENTARIO,@ZCAJA)", Con))
                {
                    DateTime xFecha = DateTime.Now;
                    Com.Parameters.Add(new SqlParameter("@CAJA",xCaja));
                    Com.Parameters.Add(new SqlParameter("@FECHA",Convert.ToDateTime(xFecha.ToShortDateString())));
                    Com.Parameters.Add(new SqlParameter("@HORA", Convert.ToDateTime(xFecha.ToShortTimeString())));
                    Com.Parameters.Add(new SqlParameter("@CODMONEDA", xMoneda));
                    Com.Parameters.Add(new SqlParameter("@IMPORTE", xImporte));
                    Com.Parameters.Add(new SqlParameter("@COTIZACION", xCotizacion));
                    Com.Parameters.Add(new SqlParameter("@COMENTARIO", xComentario));
                    Com.Parameters.Add(new SqlParameter("@ZCAJA", xZ));
                    ExecuteNonQuery(Com);
                }

            }

        }

        public void GuardarSaldoInicial(decimal xSaldoInicialPesos, decimal xSaldoInicialDolares, string xCaja, int xZ)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO DECLARADOZ(TIPO, CAJA, NUMEROCIERRE, CODMONEDA, IMPORTE) VALUES (0,@CAJA,@NUMEROCIERRE,1,@SALDOINICIALPESOS)", Con))
                {
                    DateTime xFecha = DateTime.Now;
                    Com.Parameters.Add(new SqlParameter("@SALDOINICIALPESOS", xSaldoInicialPesos));
                    Com.Parameters.Add(new SqlParameter("@SALDOINICIALDOLARES", xSaldoInicialDolares));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xZ));
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));

                    ExecuteNonQuery(Com);

                    Com.CommandText = "INSERT INTO DECLARADOZ(TIPO, CAJA, NUMEROCIERRE, CODMONEDA, IMPORTE) VALUES (0,@CAJA,@NUMEROCIERRE,2,@SALDOINICIALDOLARES)";

                    ExecuteNonQuery(Com);

                }

            }

        }


        public void CierreCaja(decimal xCierrePesos, decimal xCierreDolares,decimal xsaldoinicialP, decimal xsaldoInicialD, string xCaja, int xZ, int xCodVendedor)

        {

            decimal Total = 0;
            decimal totaldeclarado = 0;
            decimal pagopesos = getPagosPesos(xCaja, 0);
            decimal pagodolares = getPagosDolares(xCaja, 0);

            decimal cotizacion = MapperGeneral.getInstance().getMonedaByID(2).Cotizacion;
            decimal Descuadre = 0;

            Total = getVentasContadoPesos(xCaja, xZ) + (getVentasContadoDolares(xCaja, xZ) * cotizacion) - pagopesos - (pagodolares*cotizacion) ;
            totaldeclarado = xCierrePesos + (xCierreDolares * cotizacion) - pagopesos - (pagodolares * cotizacion);
            Descuadre =totaldeclarado - Total;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction()) { 
                using (SqlCommand Com = new SqlCommand("INSERT INTO DECLARADOZ(TIPO, CAJA, NUMEROCIERRE, CODMONEDA, IMPORTE) VALUES (1,@CAJA,@NUMEROCIERRE,1,@CIERREPESOS)", Con))
                {
                    DateTime xFecha = DateTime.Now;
                    Com.Parameters.Add(new SqlParameter("@CIERREPESOS", xCierrePesos));
                    Com.Parameters.Add(new SqlParameter("@CIERREDOLARES", xCierreDolares));

                        Com.Parameters.Add(new SqlParameter("@SALDOINICIALPESOS", xsaldoinicialP));
                        Com.Parameters.Add(new SqlParameter("@SALDOINICIALDOLARES", xsaldoInicialD));

                        Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xZ));
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@CODVENDEDOR", xCodVendedor));
                    Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Now.ToString("dd/MM/yyyy")));
                    Com.Parameters.Add(new SqlParameter("@HORA", DateTime.Now.ToString("HH:mm:ss")));
                        Com.Parameters.Add(new SqlParameter("@TOTAL", Total));
                        Com.Parameters.Add(new SqlParameter("@DESCUADRE", Descuadre));


                        Com.Transaction = (SqlTransaction)Tran;
                    ExecuteNonQuery(Com);

                    Com.CommandText = "INSERT INTO DECLARADOZ(TIPO, CAJA, NUMEROCIERRE, CODMONEDA, IMPORTE) VALUES (1,@CAJA,@NUMEROCIERRE,2,@CIERREDOLARES)";

                    ExecuteNonQuery(Com);

                        Com.CommandText = "INSERT INTO DECLARADOZ(TIPO, CAJA, NUMEROCIERRE, CODMONEDA, IMPORTE) VALUES (2,@CAJA,@NUMEROCIERRE,1,@SALDOINICIALPESOS)";

                        ExecuteNonQuery(Com);

                        Com.CommandText = "INSERT INTO DECLARADOZ(TIPO, CAJA, NUMEROCIERRE, CODMONEDA, IMPORTE) VALUES (2,@CAJA,@NUMEROCIERRE,2,@SALDOINICIALDOLARES)";

                        ExecuteNonQuery(Com);

                        Com.CommandText = "INSERT INTO ARQUEOS(CODCAJA, NUMEROZ, CODVENDEDOR, FECHA, HORA,TOTAL, DESCUADRE) VALUES (@CAJA, @NUMEROCIERRE, @CODVENDEDOR,@FECHA,@HORA,@TOTAL, @DESCUADRE)";

                    ExecuteNonQuery(Com);

                        Com.CommandText = "UPDATE PAGOS SET ZCAJA=@NUMEROCIERRE WHERE CAJA=@CAJA AND ZCAJA=0";

                        ExecuteNonQuery(Com);



                    }
                    Tran.Commit();
                }


            }
    } 



        #region Funciones Cierre

        public int getPagosPesos(string xCaja, int xnumerocierre)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(SUM(P.IMPORTE),0) AS TOTAL FROM PAGOS AS P WHERE CAJA=@CAJA AND NUMERO=@NUMEROCIERRE AND CODMONEDA=1", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xnumerocierre));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }

        public int getPagosDolares(string xCaja, int xnumerocierre)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(SUM(P.IMPORTE),0) AS TOTAL  FROM PAGOS AS P WHERE CAJA=@CAJA AND NUMERO=@NUMEROCIERRE AND CODMONEDA=2", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xnumerocierre));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }

        public int getVentasContadoPesos(string xCaja, int xnumerocierre)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT  ISNULL(SUM(V.SUBTOTAL+V.IVA),0) AS TOTAL FROM VENTAS AS V INNER JOIN VENTASCONTADO AS VC ON (V.NUMERO=VC.NUMERO AND V.CODSERIE=VC.SERIE) WHERE V.Z=@NUMEROCIERRE AND V.CODCAJA=@CAJA AND CODMONEDA=1", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xnumerocierre));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }

        public int getVentasContadoDolares(string xCaja, int xnumerocierre)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT  ISNULL(SUM(V.SUBTOTAL+V.IVA),0) AS TOTAL FROM VENTAS AS V INNER JOIN VENTASCONTADO AS VC ON (V.NUMERO=VC.NUMERO AND V.CODSERIE=VC.SERIE) WHERE V.Z=@NUMEROCIERRE AND V.CODCAJA=@CAJA AND CODMONEDA=2", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xnumerocierre));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }

        public int getDevolucionesContadoPesos(string xCaja, int xnumerocierre)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(SUM(P.IMPORTE),0) AS TOTAL FROM PAGOS AS P WHERE CAJA=@CAJA AND NUMERO=@NUMEROCIERRE and CODMONEDA=2", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xnumerocierre));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }

        public int getDevolucionesContadoDolares(string xCaja, int xnumerocierre)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(SUM(P.IMPORTE),0) AS TOTAL FROM PAGOS AS P WHERE CAJA=@CAJA AND NUMERO=@NUMEROCIERRE and CODMONEDA=2", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@NUMEROCIERRE", xnumerocierre));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }

      

        public int getSaldoDeclarados(string xCaja, int xCodMoneda, int xtipo)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 ISNULL(importe,0) AS IMPORTE from DeclaradoZ where codmoneda=@MONEDA and caja= @CAJA AND TIPO=@TIPO ORDER BY NUMEROCIERRE DESC", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@MONEDA", xCodMoneda));
                    Com.Parameters.Add(new SqlParameter("@TIPO", xtipo));

                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }




        #endregion

        public void Eliminarpago(int xNumeroPago)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("DELETE FROM PAGOS WHERE NUMERO = @NUMERO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xNumeroPago));
                    ExecuteNonQuery(Com);
                }
            }
        }

        public int getZByPago(int xNumeroPago)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(ZCAJA,-1) FROM PAGOS WHERE NUMERO = @NUMERO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xNumeroPago));
                    return Convert.ToInt32(ExecuteScalar(Com));
                }
            }
        }


        public object getCaja()
        {
            Caja C = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CODIGO FROM CAJAS AS C  INNER JOIN EGRUPOS AS G ON C.CODIGO = G.CAJA INNER JOIN EQUIPOS E ON E.IDGRUPO = G.IDGRUPO WHERE E.NOMBRE = @EQUIPO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@EQUIPO", Environment.MachineName));
                    string xSerieCaja = Convert.ToString(ExecuteScalar(Com));
                    C = (Caja)getCajaById(xSerieCaja);
                }
            }
            return C;
        }

        public object getPagoByFecha(DateTime xFecha, string xCaja)
        {
            DataTable DT = new DataTable();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT P.NUMERO,P.FECHA,convert(DATeTIME,P.HORA,108) AS HORA,P.CODMONEDA,M.NOMBRE, P.IMPORTE,P.COMENTARIO,P.ZCAJA FROM PAGOS AS P INNER JOIN MONEDAS AS M ON P.CODMONEDA= M.CODIGO WHERE P.CAJA=@CAJA AND P.FECHA = @FECHA ORDER BY P.NUMERO ASC", (SqlConnection)Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@FECHA", xFecha));
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public object getPagoDetalle(DateTime xFecha, int xZ)
        {
            DataTable DT = new DataTable();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT P.COMENTARIO,(P.IMPORTE*P.COTIZACION)AS IMPORTE FROM PAGOS AS P INNER JOIN MONEDAS AS M ON P.CODMONEDA= M.CODIGO WHERE P.ZCAJA=@Z AND P.FECHA = @FECHA ORDER BY P.NUMERO ASC", (SqlConnection)Con))
                {
                    Com.Parameters.Add(new SqlParameter("@Z", xZ));
                    Com.Parameters.Add(new SqlParameter("@FECHA", xFecha));
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public object getPagoCabecera(DateTime xFecha, int XZ)
        {
            DataTable DT = new DataTable();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT V.NOMBRE AS CAJERO, P.CODCAJA AS CAJA, P.FECHA AS FECHA, P.NUMEROZ AS NUMEROZ FROM ARQUEOS AS P INNER JOIN VENDEDORES AS V ON (V.CODIGO=P.CODVENDEDOR) WHERE P.FECHA=@FECHA AND P.NUMEROZ=@XZ ", (SqlConnection)Con))
                {
                    Com.Parameters.Add(new SqlParameter("@xz", XZ));
                    Com.Parameters.Add(new SqlParameter("@FECHA", xFecha));
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public object getCajaById(string xCodigo)
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

        public List<Caja> getCajas()
        {
            List<Caja> Cajas = new List<Caja>() ;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT C.CODIGO,C.NOMBRE FROM CAJAS C ", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while(Reader.Read())
                        {
                            Cajas.Add(getCajaFromReader(Reader));
                        }
                    }
                }
            }
            return Cajas;
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
            C.Z = new MapperDocumentos().getNumeroZ(C.Codigo);
            return C;
        }



        private decimal getDatosCierre(IDataReader Reader)
        {
            
            return Convert.ToDecimal(Reader["TOTAL"]);
        }




  

        public decimal getVentasContado(string xCaja, int xZ, int xcodmoneda)
        {
            decimal total = 0;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT isnull(SUM(ISNULL(V.SUBTOTAL+V.IVA,0)),0) AS TOTAL  FROM VENTAS AS V INNER JOIN VENTASCONTADO AS VC ON V.NUMERO=VC.NUMERO AND V.CODSERIE=VC.SERIE WHERE CODCAJA=@CODCAJA AND Z=@Z AND CODMONEDA=@CODMONEDA ", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODCAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@Z", xZ));
                    Com.Parameters.Add(new SqlParameter("@CODMONEDA", xcodmoneda));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            total = getDatosCierre(Reader);
                        }
                    }
                }
            }
            return total;
        }

        public decimal getDevolucionesContado(string xCaja, int xZ, int xcodmoneda)
        {
            decimal total = 0;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT isnull(SUM(ISNULL(V.SUBTOTAL+V.IVA,0)),0) AS TOTAL  FROM VENTAS AS V INNER JOIN DEVCONTADO AS VC ON V.NUMERO=VC.NUMERO AND V.CODSERIE=VC.SERIE WHERE CODCAJA=@CODCAJA AND Z=@Z AND CODMONEDA=@CODMONEDA ", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODCAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@Z", xZ));
                    Com.Parameters.Add(new SqlParameter("@CODMONEDA", xcodmoneda));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            total = getDatosCierre(Reader);
                        }
                    }
                }
            }
            return total;
        }

        public decimal getPagos(string xCaja, int xZ, int xcodmoneda)
        {
            decimal total = 0;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT isnull(SUM(ISNULL(IMPORTE,0)),0) AS TOTAL  FROM PAGOS WHERE CAJA=@CODCAJA AND ZCAJA=@Z AND CODMONEDA=@CODMONEDA ", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODCAJA", xCaja));
                    Com.Parameters.Add(new SqlParameter("@Z", xZ));
                    Com.Parameters.Add(new SqlParameter("@CODMONEDA", xcodmoneda));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            total = getDatosCierre(Reader);
                        }
                    }
                }
            }
            return total;
        }

    

    }
}
