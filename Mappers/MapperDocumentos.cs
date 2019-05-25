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

//NUMERO DOCUMENTO 1 = CONTADO
//NUMERO DOCUMENTO 2 = CREDITO
//NUMERO DOCUMENTO 20 = COMPRAS
//NUMERO DOCUMENTO 3 = DEV.CONTADO
//NUMERO DOCUMENTO 4 = NOTA CREDITO

        public bool Add(object xObject)
        {
            if (xObject is VentaCuenta)
                return true;
            if (xObject is VentaContado)
                Facturar(xObject,33,1);
            if(xObject is EsperaContado )
                GuardarEsperaContado(xObject);
            if (xObject is AlbaranCompra)
                FacturarCompra(xObject);


            return true;
        }

        private void FacturarCompra(object xObject)
        {
            AlbaranCompra C = (AlbaranCompra)xObject;
            int Numero = -1;

            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    //Ingreso Cabecera
                    Numero = AddCabeceraCompra(C,Con,Tran);
                    //Ingreso las lineas
                    AddLineasCompra(C, Numero,Con,Tran);
                    //Actualizo el precio en la tabla articulos
                    UpdatePreciosArticulos(C.Lineas,Con,Tran);
                    Tran.Commit();
                }
            }
        }

        private void UpdatePreciosArticulos(List<CompraLin> xLineas, SqlConnection xCon, SqlTransaction xTran)
        {
            foreach (CompraLin L in xLineas)
            {
                using (SqlCommand Com = new SqlCommand("UPDATE ARTICULOS SET COSTO = @COSTO,IVA = @IVA WHERE CODARTICULO = @ARTICULO", (SqlConnection)xCon))
                {
                    Com.Parameters.Add(new SqlParameter("@COSTO", L.Articulo.Costo));
                    Com.Parameters.Add(new SqlParameter("@IVA", L.Articulo.Iva));
                    Com.Parameters.Add(new SqlParameter("@ARTICULO", L.Articulo.CodArticulo));
                    Com.Transaction = xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }

        private void AddLineasCompra(AlbaranCompra xC, int xNumero, SqlConnection xCon, SqlTransaction xTran)
        {
            foreach (CompraLin L in xC.Lineas)
            {
                using (SqlCommand Com = new SqlCommand("INSERT INTO COMPRASLIN(IDCOMPRA,SERIECOMPRA,NUMLIN,CODATICULO,DESCRIPCION,CANTIDAD,PRECIOBRUTO,IVA,TOTALIVA) VALUES(@IDCOMPRA,@SERIECOMPRA,@NUMLIN,@CODATICULO,@DESCRIPCION,@CANTIDAD,@PRECIOBRUTO,@IVA,@TOTALIVA)", (SqlConnection)xCon))
                {
                    Com.Parameters.Add(new SqlParameter("@IDCOMPRA", xNumero));
                    Com.Parameters.Add(new SqlParameter("@SERIECOMPRA", xC.Serie));
                    Com.Parameters.Add(new SqlParameter("@NUMLIN", L.NumLinea));
                    Com.Parameters.Add(new SqlParameter("@CODATICULO", L.Articulo.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION", L.Descripcion));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", L.Cantidad));
                    Com.Parameters.Add(new SqlParameter("@PRECIOBRUTO", L.SubTotal()));
                    Com.Parameters.Add(new SqlParameter("@IVA", L.Articulo.Iva));
                    Com.Parameters.Add(new SqlParameter("@TOTALIVA", L.TotalconIva() - L.SubTotal()));
                    Com.Transaction = xTran;
                    ExecuteNonQuery(Com);
                    AddHisotriaPrecios(xC,xCon,xTran,L,xNumero);
                }
            }
        }

        private void AddHisotriaPrecios(AlbaranCompra xC, SqlConnection xCon, SqlTransaction xTran, CompraLin xL,int xNumero)
        {
            using (SqlCommand Com = new SqlCommand("INSERT INTO PRECIOS(CODARTICULO,IDCOMPRA,SERIECOMPRA,PRECIOBRUTO,FECHA,CODMONEDA,IVA) VALUES(@CODARTICULO,@IDCOMPRA,@SERIECOMPRA,@PRECIOBRUTO,@FECHA,@CODMONEDA,@IVA)", (SqlConnection)xCon))
            {
                //CODARTICULO,IDCOMPRA,SERIECOMPRA,PRECIOBRUTO,FECHA,CODMONEDA,IVA
                Com.Parameters.Add(new SqlParameter("@CODARTICULO", xL.Articulo.CodArticulo));
                Com.Parameters.Add(new SqlParameter("@IDCOMPRA", xNumero));
                Com.Parameters.Add(new SqlParameter("@SERIECOMPRA",xC.Serie));
                Com.Parameters.Add(new SqlParameter("@PRECIOBRUTO",xL.Costo));
                Com.Parameters.Add(new SqlParameter("@FECHA", xC.Fecha));
                Com.Parameters.Add(new SqlParameter("@CODMONEDA", xC.CodMoneda));
                Com.Parameters.Add(new SqlParameter("@IVA", xL.Articulo.Iva));
                Com.Transaction = xTran;
                ExecuteNonQuery(Com);
            }
        }

        private int AddCabeceraCompra(AlbaranCompra xC, SqlConnection xCon, SqlTransaction xTran)
        {
            int Numero = -1;
            using (SqlCommand Com = new SqlCommand("INSERT INTO COMPRAS(SERIECOMPRA,FECHA,CODPROVEEDOR, CODMONEDA, NUMPROVEEDOR, SERIEPROVEEDO, FECHAPROVEEDOR,COTIZACION) OUTPUT INSERTED.IDCOMPRA VALUES (@SERIECOMPRA,@FECHA,@CODPROVEEDOR,@CODMONEDA,@NUMPROVEEDOR,@SERIEPROVEEDO,@FECHAPROVEEDOR,@COTIZACION)", (SqlConnection)xCon))
            {
                Com.Parameters.Add(new SqlParameter("@SERIECOMPRA", xC.Serie));
                Com.Parameters.Add(new SqlParameter("@FECHA", xC.Fecha.ToShortDateString()));
                Com.Parameters.Add(new SqlParameter("@CODPROVEEDOR", xC.CodProveedor));
                Com.Parameters.Add(new SqlParameter("@CODMONEDA", xC.CodMoneda));
                Com.Parameters.Add(new SqlParameter("@NUMPROVEEDOR", xC.CodProveedor));
                Com.Parameters.Add(new SqlParameter("@SERIEPROVEEDO", xC.SerieFacturaProveedor));
                Com.Parameters.Add(new SqlParameter("@FECHAPROVEEDOR", xC.FechaProveedor));
                Com.Parameters.Add(new SqlParameter("@COTIZACION", xC.Cotizacion));
                Com.Transaction = xTran;
                var Result = ExecuteScalar(Com);
                int.TryParse(Result.ToString(), out Numero);
            }
            return Numero;
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
                        using (SqlCommand Com = new SqlCommand("INSERT INTO ESPERACONTADO(FECHA,CODVENDEDOR,CLIENTECONTADO, ESTADO, TIPO, DIRECCIONENVIO, ADENDA) OUTPUT INSERTED.CODIGO VALUES (@FECHA,@CODVENDEDOR, @CLIENTECONTADO, @ESTADO, @TIPO, @DIRECCIONENVIO, @ADENDA)", (SqlConnection)Con))
                        {
                            Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Today));
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
                    Com.Parameters.Add(new SqlParameter("@CODARTICULO", EL.Articulo.CodArticulo));
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
                using (SqlCommand Com = new SqlCommand("SELECT E.CODIGO,E.FECHA,E.CODVENDEDOR,E.CLIENTECONTADO,E.ESTADO,E.TIPO,E.DIRECCIONENVIO,E.ADENDA, CC.NOMBRE FROM ESPERACONTADO E  inner join clientescontado as CC on (cc.CODIGO= E.Clientecontado)where estado=0 order by codigo asc", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            DateTime Fecha = (DateTime)Reader["FECHA"];
                            int xCodVendedor = (int)Reader["CODVENDEDOR"];
                            int xCliente = (int)Reader["CLIENTECONTADO"];
                            string xAdenda = (string)(Reader["ADENDA"] is DBNull ? string.Empty : Reader["ADENDA"]);
                            string xEnvio = (string)(Reader["DIRECCIONENVIO"] is DBNull ? string.Empty : Reader["DIRECCIONENVIO"]);
                            int xTipo = (int)Reader["TIPO"];
                            int xEstado = (int)Reader["ESTADO"];
                            String xNombreCliente = (string)Reader["NOMBRE"];
                            EsperaContado E = new EsperaContado(Codigo,Fecha,xCodVendedor,xCliente,xAdenda,xEnvio,xEstado,xTipo,xNombreCliente);
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
                            decimal Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
                            Articulo A = (Articulo)(new MapperArticulos().getArticuloById((Reader["CODARTICULO"]).ToString()));
                            string Descripcion = (string)Reader["DESCRIPCION"];
                            decimal Descuento = Convert.ToDecimal(Reader["DESCUENTO"]);

                            Esperalin L = new Esperalin(A,Descripcion,Cantidad,Descuento,NumLin);
         
                            
                            Lineas.Add(L);
                        }
                    }
                }
            }
            return Lineas;
        }




        public void Facturar(object xObjFactura, int xZ, int xCodDocumento)
        {
            Documento F = (Documento)xObjFactura;
            int NumeroFactura = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    NumeroFactura = ObtenerNumeroFactura(Con, Tran);
                    using (SqlCommand Com = new SqlCommand("INSERT INTO VENTAS(NUMERO, CODSERIE, CODCAJA, FECHA, CODMONEDA, Z, CODVENDEDOR, CODDOCUMENTO,DETALLE, COTIZACION, SUBTOTAL, IVA) VALUES (@NUMERO, @CODSERIE, @CODCAJA, @FECHA, @CODMONEDA, @Z, @CODVENDEDOR, @CODDOCUMENTO,@DETALLE,@COTIZACION,@SUBTOTAL,@IVA)", (SqlConnection)Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@NUMERO", NumeroFactura));
                        Com.Parameters.Add(new SqlParameter("@CODSERIE", F.Serie));
                        Com.Parameters.Add(new SqlParameter("@CODCAJA", F.Caja));
                        Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Today));
                        Com.Parameters.Add(new SqlParameter("@CODMONEDA", F.Moneda));
                        Com.Parameters.Add(new SqlParameter("@Z", xZ));
                        Com.Parameters.Add(new SqlParameter("@CODVENDEDOR", F.Vendedor));
                        Com.Parameters.Add(new SqlParameter("@CODDOCUMENTO", xCodDocumento));
                        Com.Parameters.Add(new SqlParameter("@DETALLE", F.Detalle));
                        Com.Parameters.Add(new SqlParameter("@COTIZACION", F.Cotizacion));
                        Com.Parameters.Add(new SqlParameter("@SUBTOTAL", F.Subtotal()));
                        Com.Parameters.Add(new SqlParameter("@IVA", F.IvaTotal()));
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

                            Com.Parameters.Add(new SqlParameter("@PERSONA", ((VentaCuenta)F).Persona.CodCliente));
                            Com.Parameters.Add(new SqlParameter("@CUENTA", ((VentaCuenta)F).Cuenta));
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
                    AddLineasFactura(F.Lineas, Con, Tran, NumeroFactura, F.Serie);
                    Tran.Commit();
                }
            }
        }

        //public object getFacturaByID(string xSerie, int xNumero, TipoLineas xTipo)
        //{
        //    Factura F = null;

        //    string Query = "SELECT * FROM VENTAS V ";
        //    switch (xTipo)
        //    {
        //        case TipoLineas.Contado:
        //            Query += "INNER JOIN VENTASCONTADO VC ON V.NUMERO = VC.NUMERO AND V.CODSERIE = VC.SERIE";
        //            break;
        //        case TipoLineas.Credito:
        //            Query += "INNER JOIN VENTASCREDITO VC ON V.NUMERO = VC.NUMERO AND V.CODSERIE = VC.CODSERIE";
        //            break;
        //    }
        //    Query += " WHERE V.CODSERIE = @SERIE AND V.NUMERO = @NUMERO";
        //    using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
        //    {
        //        Con.Open();
        //        using (SqlCommand Com = new SqlCommand(Query, Con))
        //        {
        //            Com.Parameters.Add(new SqlParameter("@SERIE", xSerie));
        //            Com.Parameters.Add(new SqlParameter("@NUMERO", xNumero));
        //            using (IDataReader Reader = ExecuteReader(Com))
        //            {
        //                if (Reader.Read())
        //                {
        //                    F = getFacturaFromReader(Reader, xTipo);
        //                }
        //            }
        //        }
        //    }
        //    return F;
        //}

        //private Factura getFacturaFromReader(IDataReader Reader, TipoLineas xTipo)
        //{
        //    Factura F = null;
        //    ClienteContado CC = null;
        //    Persona P = null;
        //    int Numero = (int)Reader["NUMERO"];
        //    string Serie = (string)Reader["SERIE"];
        //    string Caja = (string)Reader["CODCAJA"];
        //    DateTime Fecha = Convert.ToDateTime(Reader["FECHA"]);
        //    int Moneda = (int)Reader["CODMONEDA"];
        //    int Z = (int)Reader["Z"];
        //    int Vendedor = (int)Reader["CODVENDEDOR"];
        //    int Documento = (int)Reader["CODDOCUMENTO"];
        //    switch (xTipo)
        //    {
        //        case TipoLineas.Contado:
        //            int ClC = (int)Reader["CLIENTECONTADO"];
        //            CC = getClienteContadoByID(ClC);
        //            F = new VentaContado(Documento, CC, Fecha, Numero, Serie, Caja, Moneda, Z, Vendedor);
        //            break;
        //        case TipoLineas.Credito:
        //            int CodPersona = (int)Reader["CODPERSONA"];
        //            int CodCuenta = (int)Reader["CODCUENTA"];
        //            int Tarifa = (int)Reader["CODTARIFA"];
        //            P = getPersonaById(CodPersona.ToString());
        //            F = new VentaCuenta(Documento, P, CodCuenta, Fecha, Numero, Serie, Caja, Moneda, Z, Vendedor, Tarifa);
        //            break;
        //        default:
        //            break;

        //    }

        //    List<object> L = getLineasByFactura(F.Numero, F.Serie);
        //    F.AgregarLineas(L);
        //    return F;
        //}

        private List<object> getLineasByFactura(int xNumero, string xSerie)
        {
            List<object> Lineas = new List<object>();
            VentaLin VL = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT L.CODSERIE,L.NUMERO,L.LINEA,L.CODARTICULO,L.REFERENCIA,L.DESCRIPCION,L.CANTIDAD,L.PRECIO,L.DTO,L.IVA FROM VENTASLIN L WHERE L.CODSERIE = @SERIE AND L.NUMERO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xNumero));
                    Com.Parameters.Add(new SqlParameter("@SERIE", xSerie));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {

                            VL = getVentaLinFromReader(Reader);
                            Lineas.Add(VL);
                        }
                    }
                }
            }
            return Lineas;
        }

        private VentaLin getVentaLinFromReader(IDataReader Reader)
        {
            //L.CODSERIE,L.NUMERO,L.LINEA,L.CODARTICULO,L.REFERENCIA,L.DESCRIPCION,L.CANTIDAD,L.PRECIO,L.DTO,L.IVA
            string Serie = (string)Reader["CODSERIE"];
            int Numero = (int)Reader["NUMERO"];
            int Linea = (int)Reader["LINEA"];
            int CodArt = (int)Reader["CODARTICULO"];
            string Ref = (string)Reader["REFERENCIA"];
            string Des = (string)Reader["DESCRIPCION"];
            decimal Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
            decimal Precio = Convert.ToDecimal(Reader["PRECIO"]);
            decimal dto = Convert.ToDecimal(Reader["DTO"]);
            decimal Iva = Convert.ToDecimal(Reader["IVA"]);
            Articulo A = (Articulo)(new MapperArticulos().getArticuloById(CodArt.ToString()));
            VentaLin L = new VentaLin(Linea, A, Des,  Cantidad, dto);
            return L;
        }

        private Persona getPersonaById(string codPersona)
        {
            return (Persona)new MapperPersonas().getPersona(codPersona);
        }

        private ClienteContado getClienteContadoByID(int ClC)
        {
            return (ClienteContado)new MapperPersonas().getClienteContadobyID(ClC);
        }

        private void AddLineasFactura(List<Linea> lineas, SqlConnection xCon, SqlTransaction xTran, int xFacturaID, string xSerie)
        {
            foreach (object L in lineas)
            {
                VentaLin VL = (VentaLin)L;
                using (SqlCommand Com = new SqlCommand("INSERT INTO VENTASLIN (CODSERIE, NUMERO, LINEA, CODARTICULO, REFERENCIA, DESCRIPCION, CANTIDAD, PRECIO, DTO, IVA) VALUES(@CODSERIE, @NUMERO, @LINEA, @CODARTICULO,@REFERENCIA, @DESCRIPCION, @CANTIDAD, @PRECIO, @DTO,@IVA)", (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    Com.Parameters.Add(new SqlParameter("@CODSERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xFacturaID));
                    Com.Parameters.Add(new SqlParameter("@LINEA",VL.NumLinea ));
                    Com.Parameters.Add(new SqlParameter("@CODARTICULO",VL.Articulo.CodArticulo ));
                    Com.Parameters.Add(new SqlParameter("@REFERENCIA", VL.Articulo.Referencia));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION",VL.Descripcion.ToUpper() ));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD",VL.Cantidad ));
                    Com.Parameters.Add(new SqlParameter("@PRECIO",VL.Precio()));
                    Com.Parameters.Add(new SqlParameter("@DTO", VL.Descuento));
                    Com.Parameters.Add(new SqlParameter("@IVA",VL.Articulo.Iva));
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


        