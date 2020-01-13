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
                Facturar(xObject, 1, new MapperPrecios().getCotizacion(2));
            if (xObject is EsperaContado)
                GuardarEsperaContado(xObject);
            if (xObject is AlbaranCompra)
                FacturarCompra(xObject);
            if (xObject is DevolucionContado)
                Facturar(xObject, 3, new MapperPrecios().getCotizacion(2));
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
                    Numero = AddCabeceraCompra(C, Con, Tran);
                    //Ingreso las lineas
                    AddLineasCompra(C, Numero, Con, Tran);
                    //Actualizo el precio en la tabla articulos
                    UpdatePreciosArticulos(C, Con, Tran);
                    // Agrego el historial del articulo.
                    Tran.Commit();
                }
            }
        }

        private void UpdatePreciosArticulos(AlbaranCompra xCompra, SqlConnection xCon, SqlTransaction xTran)
        {
            foreach (CompraLin L in xCompra.Lineas)
            {
                if (L.Articulo.Recalcula)
                {
                    using (SqlCommand Com = new SqlCommand("UPDATE ARTICULOS SET COSTO = @COSTO,STOCK = STOCK + @CANTIDAD,MONEDACOMPRA = @MONEDA WHERE CODIGO = @ARTICULO", (SqlConnection)xCon))
                    {
                        Com.Parameters.Add(new SqlParameter("@COSTO", L.Costo));
                        Com.Parameters.Add(new SqlParameter("@ARTICULO", L.Articulo.CodArticulo));
                        Com.Parameters.Add(new SqlParameter("@CANTIDAD", L.Cantidad));
                        Com.Parameters.Add(new SqlParameter("@MONEDA", xCompra.CodMoneda));
                        Com.Transaction = xTran;
                        ExecuteNonQuery(Com);
                    }
                }
            }
        }

        private void AddLineasCompra(AlbaranCompra xC, int xNumero, SqlConnection xCon, SqlTransaction xTran)
        {
            foreach (CompraLin L in xC.Lineas)
            {
                using (SqlCommand Com = new SqlCommand("INSERT INTO COMPRASLIN(IDCOMPRA,SERIECOMPRA,NUMLIN,CODARTICULO,DESCRIPCION,CANTIDAD,PRECIOBRUTO,IVA,TOTALIVA) VALUES(@IDCOMPRA,@SERIECOMPRA,@NUMLIN,@CODARTICULO,@DESCRIPCION,@CANTIDAD,@PRECIOBRUTO,@IVA,@TOTALIVA)", (SqlConnection)xCon))
                {
                    Com.Parameters.Add(new SqlParameter("@IDCOMPRA", xNumero));
                    Com.Parameters.Add(new SqlParameter("@SERIECOMPRA", xC.Serie));
                    Com.Parameters.Add(new SqlParameter("@NUMLIN", L.NumLinea));
                    Com.Parameters.Add(new SqlParameter("@CODARTICULO", L.Articulo.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION", L.Descripcion));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", L.Cantidad));
                    Com.Parameters.Add(new SqlParameter("@PRECIOBRUTO", L.SubTotal()));
                    Com.Parameters.Add(new SqlParameter("@IVA", L.Articulo.Iva.Id));
                    Com.Parameters.Add(new SqlParameter("@TOTALIVA", L.TotalconIva() - L.SubTotal()));
                    Com.Transaction = xTran;
                    ExecuteNonQuery(Com);
                    AddHisotriaPrecios(xC, xCon, xTran, L, xNumero);
                }
            }
        }

        private void AddHisotriaPrecios(AlbaranCompra xC, SqlConnection xCon, SqlTransaction xTran, CompraLin xL, int xNumero)
        {
            using (SqlCommand Com = new SqlCommand("INSERT INTO PRECIOS(CODARTICULO,IDCOMPRA,SERIECOMPRA,PRECIOBRUTO,FECHA,CODMONEDA,IVA) VALUES(@CODARTICULO,@IDCOMPRA,@SERIECOMPRA,@PRECIOBRUTO,@FECHA,@CODMONEDA,@IVA)", (SqlConnection)xCon))
            {
                //CODARTICULO,IDCOMPRA,SERIECOMPRA,PRECIOBRUTO,FECHA,CODMONEDA,IVA
                Com.Parameters.Add(new SqlParameter("@CODARTICULO", xL.Articulo.CodArticulo));
                Com.Parameters.Add(new SqlParameter("@IDCOMPRA", xNumero));
                Com.Parameters.Add(new SqlParameter("@SERIECOMPRA", xC.Serie));
                Com.Parameters.Add(new SqlParameter("@PRECIOBRUTO", xL.Costo));
                Com.Parameters.Add(new SqlParameter("@FECHA", xC.Fecha));
                Com.Parameters.Add(new SqlParameter("@CODMONEDA", xC.CodMoneda));
                Com.Parameters.Add(new SqlParameter("@IVA", xL.Articulo.Iva.Id));
                Com.Transaction = xTran;
                ExecuteNonQuery(Com);
            }
        }

        private int AddCabeceraCompra(AlbaranCompra xC, SqlConnection xCon, SqlTransaction xTran)
        {
            int Numero = -1;
            using (SqlCommand Com = new SqlCommand("INSERT INTO COMPRAS(SERIECOMPRA,FECHA,CODPROVEEDOR, CODMONEDA, NUMPROVEEDOR, SERIEPROVEEDOR, FECHAPROVEEDOR,COTIZACION) OUTPUT INSERTED.IDCOMPRA VALUES (@SERIECOMPRA,@FECHA,@CODPROVEEDOR,@CODMONEDA,@NUMPROVEEDOR,@SERIEPROVEEDOR,@FECHAPROVEEDOR,@COTIZACION)", (SqlConnection)xCon))
            {
                Com.Parameters.Add(new SqlParameter("@SERIECOMPRA", xC.Serie));
                Com.Parameters.Add(new SqlParameter("@FECHA", xC.Fecha));
                Com.Parameters.Add(new SqlParameter("@CODPROVEEDOR", xC.CodProveedor));
                Com.Parameters.Add(new SqlParameter("@CODMONEDA", xC.CodMoneda));
                Com.Parameters.Add(new SqlParameter("@NUMPROVEEDOR", xC.NumFacturaProveedor));
                Com.Parameters.Add(new SqlParameter("@SERIEPROVEEDOR", xC.SerieFacturaProveedor));
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


                    using (SqlCommand Com = new SqlCommand("INSERT INTO ESPERACONTADO(FECHA,CODVENDEDOR,CLIENTECONTADO, ESTADO, DIRECCIONENVIO, ADENDA) OUTPUT INSERTED.CODIGO VALUES (@FECHA,@CODVENDEDOR, @CLIENTECONTADO, @ESTADO, @DIRECCIONENVIO, @ADENDA)", (SqlConnection)Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@FECHA", DateTime.Today));
                        Com.Parameters.Add(new SqlParameter("@CODVENDEDOR", E.Codvendedor));
                        Com.Parameters.Add(new SqlParameter("@CLIENTECONTADO", E.Codclientecontado));
                        Com.Parameters.Add(new SqlParameter("@ESTADO", E.Estado));

                        Com.Parameters.Add(new SqlParameter("@DIRECCIONENVIO", E.DirEnvio.ToUpper()));
                        Com.Parameters.Add(new SqlParameter("@ADENDA", E.Adenda));
                        Com.Transaction = (SqlTransaction)Tran;
                        var Result = ExecuteScalar(Com, P);
                        int.TryParse(Result.ToString(), out xCodEspera);
                    }
                    AddLineasEspera(E.Lineas, Con, Tran, xCodEspera, TipoLineas.Contado);
                    Tran.Commit();
                }
            }
        }

        private void AddLineasEspera(List<Esperalin> lineas, SqlConnection xCon, SqlTransaction xTran, int xCodEsperaContado, TipoLineas xTipo)
        {
            string Query = "";

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
                using (SqlCommand Com = new SqlCommand("SELECT E.CODIGO,E.FECHA,E.CODVENDEDOR,E.CLIENTECONTADO,E.ESTADO,E.DIRECCIONENVIO,E.ADENDA, CC.NOMBRE, E.PRESUPUESTO FROM ESPERACONTADO E  inner join clientescontado as CC on (cc.CODIGO= E.Clientecontado) where estado=0 AND fecha=@fecha order by codigo asc", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@fecha", DateTime.Today.ToString("dd/MM/yyyy")));
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

                            //char xPresupuesto = (char)Reader["PRESUPUESTO"];
                            int xEstado = (int)Reader["ESTADO"];
                            String xNombreCliente = (string)Reader["NOMBRE"];
                            EsperaContado E = new EsperaContado(Codigo, Fecha, xCodVendedor, xCliente, xAdenda, xEnvio, xEstado, xNombreCliente, 'F');

                            E.AgregarLineas(getLineasEsperaContado(Codigo));
                            LtsEspera.Add(E);
                        }
                    }
                }
            }
            return LtsEspera;
        }

        public List<object> getVentasEsperaContado(int xEstado)
        {
            List<object> LtsEspera = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT E.CODIGO,E.FECHA,E.CODVENDEDOR,E.CLIENTECONTADO,E.ESTADO,E.DIRECCIONENVIO,E.ADENDA, CC.NOMBRE, E.PRESUPUESTO FROM ESPERACONTADO E  inner join clientescontado as CC on (cc.CODIGO= E.Clientecontado) where estado=@ESTADO AND fecha=@fecha order by codigo asc", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@fecha", DateTime.Today.ToString("dd/MM/yyyy")));
                    Com.Parameters.Add(new SqlParameter("@ESTADO", xEstado));
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
                            String xNombreCliente = (string)Reader["NOMBRE"];
                            EsperaContado E = new EsperaContado(Codigo, Fecha, xCodVendedor, xCliente, xAdenda, xEnvio, xEstado, xNombreCliente, 'F');

                            E.AgregarLineas(getLineasEsperaContado(Codigo));
                            LtsEspera.Add(E);
                        }
                    }
                }
            }
            return LtsEspera;
        }

        public List<object> getVentasEsperaCredito()
        {
            List<object> LtsEspera = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT E.CODIGO,E.FECHA,E.CODVENDEDOR,E.CODPERSONA, E.CODCUENTA, E.ESTADO,E.DIRECCIONENVIO,E.ADENDA, E.PRESUPUESTO, CC.NOMBRE, E.PRESUPUESTO, P.CODIGO, P.CEDULA, P.NOMBRE, P.APELLIDO, P.DIRECCION, P.DIRNUMERO, P.TELEFONO,P.CELULAR, P.PAIS,P.CIUDAD,P.SUBCATEGORIA, P.EMAIL,P.ACTIVA   FROM ESPERA E  inner join PERSONAS as P on (E.CODIGO= P.CODIGO) where estado=0 order by codigo asc", Con))
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
                            char xPresupuesto = (char)Reader["PRESPUESTO"];
                            int xEstado = (int)Reader["ESTADO"];
                            String xNombreCliente = (string)Reader["NOMBRE"];
                            EsperaContado E = new EsperaContado(Codigo, Fecha, xCodVendedor, xCliente, xAdenda, xEnvio, xEstado, xNombreCliente, xPresupuesto);
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

                            Esperalin L = new Esperalin(A, Descripcion, Cantidad, Descuento, NumLin);





                            Lineas.Add(L);
                        }
                    }
                }
            }
            return Lineas;
        }


        public List<object> getVentasContado(DateTime xfechaini, DateTime xfechafin)
        {
            List<object> ltsVentasC = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CC.*,V.FECHA, V.CODSERIE,V.NUMERO, V.CODCAJA,V.CODMONEDA,V.Z, v.CODVENDEDOR,V.COTIZACION,V.DETALLE FROM VENTAS AS V INNER JOIN VENTASCONTADO VC ON (V.CODSERIE=VC.SERIE AND V.NUMERO=VC.NUMERO) inner join CLIENTESCONTADO AS CC ON (CC.CODIGO=VC.CLIENTECONTADO)  WHERE V.FECHA BETWEEN @Fechaini AND @Fechafin ", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@Fechaini", xfechaini));
                    Com.Parameters.Add(new SqlParameter("@Fechafin", xfechafin));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {


                        while (Reader.Read())
                        {

                            DateTime Fecha = (DateTime)Reader["FECHA"];
                            int xCodVendedor = (int)Reader["CODVENDEDOR"];

                            int xCliente = (int)Reader["CODIGO"];
                            string xdocumento = (string)Reader["DOCUMENTO"];
                            string XNOMBREC = (string)(Reader["NOMBRE"] is DBNull ? string.Empty : Reader["NOMBRE"]);
                            string XDIRECCIONC = (string)(Reader["DIRECCION"] is DBNull ? string.Empty : Reader["DIRECCION"]);
                            string xtelefonocc = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);

                            string xdetalle = (string)(Reader["DETALLE"] is DBNull ? string.Empty : Reader["DETALLE"]);

                            string xserie = (string)(Reader["CODSERIE"]);
                            int xnumero = (int)Reader["NUMERO"];
                            string xcodcaja = (string)(Reader["CODCAJA"]);


                            int XCODMONEDA = (int)Reader["CODMONEDA"];
                            int XZ = (int)Reader["Z"];
                            int xcodvendedor = (int)Reader["CODVENDEDOR"];
                            decimal xcotizacion = (decimal)Reader["COTIZACION"];

                            VentaContado V = new VentaContado(new ClienteContado(xCliente, xdocumento, XNOMBREC, XDIRECCIONC, xtelefonocc), Fecha, xserie, xcodcaja, XCODMONEDA, XZ, xcodvendedor, xcotizacion, false, 0);
                            V.Numero = xnumero;
                            V.Detalle = xdetalle;

                            V.AgregarLineas(getLineasVentasC(V.Serie, V.Numero));
                            ltsVentasC.Add(V);
                        }
                    }
                }
            }
            return ltsVentasC;

        }

        private List<Linea> getLineasVentasC(string xSerie, int xNumero)
        {
            List<Linea> Lineas = new List<Linea>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("select CODSERIE, NUMERO, LINEA, CODARTICULO, REFERENCIA, DESCRIPCION, CANTIDAD, PRECIO,DTO, IVA FROM VENTASLIN WHERE CODSERIE=@CODSERIE AND NUMERO=@NUMERO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODSERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xNumero));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            string xserie = (string)Reader["CODSERIE"];
                            int xnumero = (int)Reader["NUMERO"];

                            int NumLin = (int)Reader["LINEA"];
                            decimal Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
                            decimal xpreciof = Convert.ToDecimal(Reader["PRECIO"]);
                            Articulo A = (Articulo)(new MapperArticulos().getArticuloById((Reader["CODARTICULO"]).ToString()));
                            string Descripcion = (string)Reader["DESCRIPCION"];
                            decimal Descuento = Convert.ToDecimal(Reader["DTO"]);

                            VentaLin L = new VentaLin(xserie, xnumero, NumLin, A, Descripcion, Cantidad, Descuento);
                            L.Preciofacturado = xpreciof;


                            Lineas.Add(L);
                        }
                    }
                }
            }
            return Lineas;
        }




        public void Facturar(object xObjFactura, int xCodDocumento, decimal xcotizacion)

        {
            Documento F = (Documento)xObjFactura;
            int NumeroFactura = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    int xZ = getNumeroZ(F.Caja);
                    NumeroFactura = ObtenerNumeroFactura(Con, Tran, F.Serie);
                    F.Numero = NumeroFactura;
                    using (SqlCommand Com = new SqlCommand("INSERT INTO VENTAS(NUMERO, CODSERIE, CODCAJA, FECHA, CODMONEDA, Z, CODVENDEDOR, CODDOCUMENTO,DETALLE, COTIZACION, SUBTOTAL, IVA,CODSERIEANULA,CODNUMEROANULA) VALUES (@NUMERO, @CODSERIE, @CODCAJA, @FECHA, @CODMONEDA, @Z, @CODVENDEDOR, @CODDOCUMENTO,@DETALLE,@COTIZACION,@SUBTOTAL,@IVA,@CODSERIEANULA,@CODNUMEROANULA)", (SqlConnection)Con))
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

                      
                        if (F is DevolucionContado)
                        {
                            Com.Parameters.Add(new SqlParameter("@SUBTOTAL", F.SubtotalDevolucion(1)));
                            Com.Parameters.Add(new SqlParameter("@IVA", F.IvaTotalDevolucion(1)));
                            Com.Parameters.Add(new SqlParameter("@CODSERIEANULA", F.SerieFacturaAnula));
                            Com.Parameters.Add(new SqlParameter("@CODNUMEROANULA", F.NumeroFacturaAnula));

                        }
                        else {
                            Com.Parameters.Add(new SqlParameter("@SUBTOTAL", F.Subtotal(1, xcotizacion)));
                            Com.Parameters.Add(new SqlParameter("@IVA", F.IvaTotal(1, xcotizacion)));
                            Com.Parameters.Add(new SqlParameter("@CODSERIEANULA", null));
                            Com.Parameters.Add(new SqlParameter("@CODNUMEROANULA", null));
                        }

                        Com.Transaction = (SqlTransaction)Tran;
                        ExecuteNonQuery(Com);
                        if (F is VentaContado)
                        {
                            Com.CommandText = "INSERT INTO VENTASCONTADO(NUMERO, SERIE, CLIENTECONTADO) VALUES (@NUMERO,@CODSERIE,@CLIENTE)";

                            Com.Parameters.Add(new SqlParameter("@CLIENTE", ((VentaContado)F).Cliente.Codigo));
                            ExecuteNonQuery(Com);

                            Com.CommandText = "INSERT INTO ENTREGA(CODSERIE, NUMERO, FECHA, ENVIO_NOMBRE, ENVIO_DIRECCION, ENVIO_TELEFONO, ENVIO_OBSERVACIONES) VALUES (@CODSERIE, @NUMERO, @FECHA, @ENVIO_NOMBRE,@ENVIO_DIRECCION,@ENVIO_TELEFONO,@ENVIO_OBSERVACIONES)";

                            Com.Parameters.Add(new SqlParameter("@ENVIO_NOMBRE", ((VentaContado)F).Env_Nombre));
                            Com.Parameters.Add(new SqlParameter("@ENVIO_DIRECCION", ((VentaContado)F).Env_Direccion));
                            Com.Parameters.Add(new SqlParameter("@ENVIO_TELEFONO", ((VentaContado)F).Env_telefono));
                            Com.Parameters.Add(new SqlParameter("@ENVIO_OBSERVACIONES", ((VentaContado)F).Env_observaciones));
                            ExecuteNonQuery(Com);

                            //SqlParameter LINEA = new SqlParameter("@LINEA",0);
                            //SqlParameter CANTIDAD = new SqlParameter("@CANTIDAD", 0);

                            //Com.Parameters.Add(LINEA);
                            //Com.Parameters.Add(CANTIDAD);

                            //foreach (VentaLin L in F.Lineas)
                            //{
                            //    LINEA.Value = L.NumLinea;
                            //    CANTIDAD.Value = L.Cantidad;                             

                            //    Com.CommandText = "INSERT INTO ENTREGALIN(CODSERIE, NUMERO, LINEA, CANTIDAD, ENTREGADO, DEVUELTO, RECIBIDO, NOTAC) VALUES (@CODSERIE, @NUMERO, @LINEA, @CANTIDAD, 0,0, 0, 0)";
                            //    ExecuteNonQuery(Com);

                            //}
                            UpdateEspera(((VentaContado)F).Espera, Con, Tran);
                        }
                        else if (F is VentaCuenta)
                        {
                            Com.CommandText = "INSERT INTO VENTASCREDITO(NUMERO, SERIE, CODPERSONA,CODCUENTA,CODTARIFA) VALUES (@NUMERO,@SERIE,@PERSONA,@CUENTA,@TARIFA)";

                            Com.Parameters.Add(new SqlParameter("@PERSONA", ((VentaCuenta)F).Persona.CodCliente));
                            Com.Parameters.Add(new SqlParameter("@CUENTA", ((VentaCuenta)F).Cuenta));
                            Com.Parameters.Add(new SqlParameter("@TARIFA", ((VentaCuenta)F).CodTarifa));
                            ExecuteNonQuery(Com);


                            Com.CommandText = "INSERT INTO ENTREGA(CODSERIE, NUMERO, FECHA, ENVIO_NOMBRE, ENVIO_DIRECCION, ENVIO_TELEFONO, ENVIO_OBSERVACIONES) VALUES (@CODSERIE, @NUMERO, @FECHA, @ENVIO_NOMBRE,@ENVIO_DIRECCION,@ENVIO_TELEFONO,@ENVIO_OBSERVACIONES)";

                            Com.Parameters.Add(new SqlParameter("@ENVIO_NOMBRE", ((VentaContado)F).Env_Nombre));
                            Com.Parameters.Add(new SqlParameter("@ENVIO_DIRECCION", ((VentaContado)F).Env_Direccion));
                            Com.Parameters.Add(new SqlParameter("@ENVIO_TELEFONO", ((VentaContado)F).Env_telefono));
                            Com.Parameters.Add(new SqlParameter("@ENVIO_OBSERVACIONES", ((VentaContado)F).Env_observaciones));
                            ExecuteNonQuery(Com);

                            SqlParameter LINEA = new SqlParameter("@LINEA,", 0);
                            SqlParameter CANTIDAD = new SqlParameter("@CANTIDAD,", 0);

                            Com.Parameters.Add(LINEA);
                            Com.Parameters.Add(CANTIDAD);

                            foreach (VentaLin L in F.Lineas)
                            {
                                LINEA.Value = L.NumLinea;
                                CANTIDAD.Value = L.Cantidad;

                                Com.CommandText = "INSERT INTO ENTREGALIN(CODSERIE, NUMERO, LINEA, CANTIDAD, ENTREGADO, DEVUELTO, RECIBIDO, NOTAC) VALUES (@CODSERIE, @NUMERO, @LINEA, @CANTIDAD, 0,0, 0, 0)";
                                ExecuteNonQuery(Com);

                            }


                        }

                        else if (F is DevolucionContado)
                        {
                            Com.CommandText = "INSERT INTO DEVCONTADO(SERIE, NUMERO, FECHA,SERIEANULA,NUMEROANULA) VALUES (@SERIE,@NUMERO,@FECHAd,@SERIEANULA,@NUMEROANULA)";

                            Com.Parameters.Add(new SqlParameter("@SERIE", ((DevolucionContado)F).Serie));

                            //Com.Parameters.Add(new SqlParameter("@NUMERO", NumeroFactura);
                            Com.Parameters.Add(new SqlParameter("@FECHAd", ((DevolucionContado)F).Fecha)); 

                            Com.Parameters.Add(new SqlParameter("@SERIEANULA", ((DevolucionContado)F).SerieReferencia));//CHEQUEAR SI VIENE EL NUMERO DE LA FACTURA A LA QUE ANULA
                            Com.Parameters.Add(new SqlParameter("@NUMEROANULA", ((DevolucionContado)F).NumeroReferencia));//CHEQUEAR SI VIENE EL NUMERO DE LA FACTURA A LA QUE ANULA
                            ExecuteNonQuery(Com);








                        }
                        else if (F is VentaCuenta)
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
                    AddLineasFactura(F, Con, Tran, NumeroFactura, F.Serie, xcotizacion);
                    if (F is DevolucionCuenta || F is VentaContado){
                        AddLineasEntrega(F.Lineas, Con, Tran, NumeroFactura, F.Serie);
                        DescontarStock(F.Lineas, Con, Tran);
                    }
                    else
                    {
                        AgregarStock(F.Lineas, Con, Tran);
                        //aca tengo que llamar la de actualizar entregalin
                    }
                  
                   


                    Tran.Commit();
                }
            }
        }

        private void UpdateEspera(int xEspera, IDbConnection con, IDbTransaction xTra)
        {

            using (SqlCommand Com = new SqlCommand("UPDATE ESPERACONTADO SET ESTADO=1 WHERE CODIGO = @CODIGO", (SqlConnection)con))
            {
                Com.Transaction = (SqlTransaction)xTra;
                Com.Parameters.Add(new SqlParameter("@CODIGO", xEspera));
                ExecuteNonQuery(Com);
            }


        }

        public int getNumeroZ(string xCaja)
        {
            int Numero = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT ISNULL(CONVERT(INT,MAX(NUMEROZ+1)),1) AS NUMERO FROM ARQUEOS WHERE CODCAJA =@CAJA", (SqlConnection)Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CAJA", xCaja));

                    Numero = (int)ExecuteScalar(Com);
                }
            }
            return Numero;
        }

        //public object getFacturaByID(string xSerie, int xNumero, TipoLineas xTipo)
        //{
        //    Documento F = null;

        //    string Query = "SELECT * FROM VENTAS V ";
        //    switch (xTipo)
        //    {
        //        case TipoLineas.Contado:
        //            Query += "INNER JOIN VENTASCONTADO VC ON V.NUMERO = VC.NUMERO AND V.CODSERIE = VC.SERIE and INNER JOIN CLIENTESCONTADO AS CC ON (CC.CODIGO=CV.CLIENTECONTADO)";
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

        private Documento getFacturaFromReader(IDataReader Reader, TipoLineas xTipo)
        {
            Documento F = null;

            //  Persona P = null;
            //CLIENTE CONTADO
            int CODCCCLIENTE = (int)Reader["CODIGO"];
            string CCDOCUMENTO = (string)(Reader["DOCUMENTO"] is DBNull ? string.Empty : Reader["DOCUMENTO"]);
            string CCNOMBRE = (string)Reader["NOMBRE"];
            string CCDIRECCION = (string)(Reader["DIRECCION"] is DBNull ? string.Empty : Reader["DIRECCION"]);
            string CCTELEFONO = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);

            //VENTASCONTADO
            int VCNUMERO = (int)Reader["NUMERO"];
            string CVSERIE = (string)Reader["SERIE"];
            int CVCLIENTECONTADO = (int)Reader["CLIENTECONTADO"];

            //VENTA


            int VNumero = (int)Reader["NUMERO"];
            string VSerie = (string)Reader["SERIE"];
            string VCaja = (string)Reader["CODCAJA"];
            DateTime VFecha = Convert.ToDateTime(Reader["FECHA"]);
            int VMoneda = (int)Reader["CODMONEDA"];
            int VZ = (int)Reader["Z"];
            int VVendedor = (int)Reader["CODVENDEDOR"];
            int VDocumento = (int)Reader["CODDOCUMENTO"];
            string VDetalle = (string)Reader["DETALLE"];
            decimal VCotizacion = (decimal)Reader["COTIZACION"];
            double VSubtotal = (double)Reader["SUBTOTAL"];
            double VIva = (double)Reader["IVA"];


            switch (xTipo)
            {
                case TipoLineas.Contado:


                    F = new VentaContado(new ClienteContado(CODCCCLIENTE, CCDOCUMENTO, CCNOMBRE, CCDIRECCION, CCTELEFONO), VFecha, VSerie, VCaja, VMoneda, VZ, VVendedor, VCotizacion, false, -1);
                    F.Numero = VCNUMERO;

                    break;
                case TipoLineas.Credito:
                //int CodPersona = (int)Reader["CODPERSONA"];
                //int CodCuenta = (int)Reader["CODCUENTA"];
                //int Tarifa = (int)Reader["CODTARIFA"];
                //P = getPersonaById(CodPersona.ToString());
                //F = new VentaCuenta(Documento, P, CodCuenta, Fecha, Numero, Serie, Caja, Moneda, Z, Vendedor, Tarifa);
                //break;
                default:
                    break;

            }

            List<Linea> L = getLineasByFactura(F.Numero, F.Serie);
            F.AgregarLineas(L);
            return F;
        }



        private List<Linea> getLineasByFactura(int xNumero, string xSerie)
        {
            List<Linea> Lineas = new List<Linea>();
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
            A.setCostoenBaseAPrecioFinal(Precio);


            VentaLin L = new VentaLin(Linea, A, Des, Cantidad, dto);
            return L;
        }

        private Persona getPersonaById(string codPersona)
        {
            return (Persona)new MapperPersonas().getPersona(codPersona);
        }

        private ClienteContado getClienteContadoByID(string ClC)
        {
            return (ClienteContado)new MapperPersonas().getClienteContadobyID(ClC);
        }

        private void AddLineasFactura(object xFactura, SqlConnection xCon, SqlTransaction xTran, int xFacturaID, string xSerie, decimal xcotizacion)
        {
            string Query = "";

            if (xFactura is VentaContado)
            {
                Query = "INSERT INTO VENTASLIN (CODSERIE, NUMERO, LINEA, CODARTICULO, REFERENCIA, DESCRIPCION, CANTIDAD, PRECIO, DTO, IVA) VALUES(@CODSERIE, @NUMERO, @LINEA, @CODARTICULO, @REFERENCIA, @DESCRIPCION, @CANTIDAD, @PRECIO, @DTO, @IVA)";
            }

            if (xFactura is DevolucionContado)
            {
                Query = "INSERT INTO DEVCONTADOLIN (CODSERIE, NUMERO, LINEA, CODARTICULO, REFERENCIA, DESCRIPCION, CANTIDAD, PRECIO, DTO, IVA) VALUES(@CODSERIE, @NUMERO, @LINEA, @CODARTICULO, @REFERENCIA, @DESCRIPCION, @CANTIDAD, @PRECIO, @DTO, @IVA)";
            }

            foreach (object L in ((Documento)xFactura).Lineas)
            {
                Linea VL = (Linea)L;
                using (SqlCommand Com = new SqlCommand(Query, (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    Com.Parameters.Add(new SqlParameter("@CODSERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xFacturaID));
                    Com.Parameters.Add(new SqlParameter("@LINEA", VL.NumLinea));
                    Com.Parameters.Add(new SqlParameter("@CODARTICULO", VL.Articulo.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@REFERENCIA", VL.Articulo.Referencia));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION", VL.Descripcion.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", VL.Cantidad));
                    Com.Parameters.Add(new SqlParameter("@PRECIO", VL.Precio(1, xcotizacion)));
                    Com.Parameters.Add(new SqlParameter("@DTO", VL.Descuento));
                    Com.Parameters.Add(new SqlParameter("@IVA", VL.Articulo.Iva.Valor));
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }


        private void AddLineasEntrega(List<Linea> lineas, SqlConnection xCon, SqlTransaction xTran, int xFacturaID, string xSerie)
        {
            foreach (object L in lineas)
            {
                VentaLin VL = (VentaLin)L;
                using (SqlCommand Com = new SqlCommand("INSERT INTO ENTREGALIN(CODSERIE, NUMERO, LINEA, CANTIDAD, ENTREGADO, DEVUELTO, RECIBIDO, NOTAC) VALUES (@CODSERIE, @NUMERO, @LINEA, @CANTIDAD, @CANTIDAD,0, 0, 0)", (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    Com.Parameters.Add(new SqlParameter("@CODSERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xFacturaID));
                    Com.Parameters.Add(new SqlParameter("@LINEA", VL.NumLinea));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", VL.Cantidad));
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }

        // HAY QUE HACER EL UPDATE EN ENTREGASLIN CUANDO HAGO LA DEVOLUCION - COMO ENTREGALIN ES INDEPENDIENTE, NO SE SI LLAMAR LA FUNCION NUEVAMENTE O NO
        //private void UpdateLineasEntregas(List<Linea> lineas, SqlConnection xCon, SqlTransaction xTran, int xFacturaID, string xSerie, List<EntregaLin> lineasEntrega)
        //{
        //    foreach (object L in lineas)
        //    {
        //        VentaLin VL = (VentaLin)L;
        //        using (SqlCommand Com = new SqlCommand("UPDATE ENTREGALIN SET ENTREGADO=, DEVUELTO=, RECIBIDO=,NOTAC WHERE CODSERIE=@CODSERIE AND NUMERO=@NUMERO AND LINEA=@LINEA", (SqlConnection)xCon))
        //        {
        //            FALTA EN VENTALIN PONER ATRIBUTOS
        //            Com.Parameters.Add(new SqlParameter("@CODSERIE", xSerie));
        //            Com.Parameters.Add(new SqlParameter("@NUMERO", xFacturaID));
        //            Com.Parameters.Add(new SqlParameter("@LINEA", VL.NumLinea));

        //            Com.Parameters.Add(new SqlParameter("@ENTREGADO", ));
        //            Com.Parameters.Add(new SqlParameter("@DEVUELTO", ));
        //            Com.Parameters.Add(new SqlParameter("@RECIBIDO", ));
        //            Com.Parameters.Add(new SqlParameter("@NOTAC", E));


        //            Com.Transaction = (SqlTransaction)xTran;
        //            ExecuteNonQuery(Com);
        //        }
        //    }
        //}


        private void DescontarStock(List<Linea> lineas, SqlConnection xCon, SqlTransaction xTran)
        {
            foreach (object L in lineas)
            {
                VentaLin VL = (VentaLin)L;
                using (SqlCommand Com = new SqlCommand("UPDATE  ARTICULOS set STOCK=(STOCK - @CANTIDAD)  WHERE CODIGO=@CODIGO", (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    Com.Parameters.Add(new SqlParameter("@CODIGO", VL.Articulo.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", VL.Cantidad));
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }

        private void AgregarStock(List<Linea> lineas, SqlConnection xCon, SqlTransaction xTran)
        {
            foreach (object L in lineas)
            {
                VentaLin VL = (VentaLin)L;
                using (SqlCommand Com = new SqlCommand("UPDATE  ARTICULOS set STOCK=(STOCK + @CANTIDAD)  WHERE CODIGO=@CODIGO", (SqlConnection)xCon))
                {
                    //FALTA EN VENTALIN PONER ATRIBUTOS
                    Com.Parameters.Add(new SqlParameter("@CODIGO", VL.Articulo.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@CANTIDAD", VL.Cantidad));
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com);
                }
            }
        }


        private int ObtenerNumeroFactura(SqlConnection xCon, SqlTransaction xTran,  string serie)
        {
            int numero = 0;
            using (SqlCommand Com = new SqlCommand("SELECT ISNULL(MAX(NUMERO),0) AS NUMERO FROM VENTAS where codserie=@serienum", (SqlConnection)xCon))
            {
                Com.Parameters.Add(new SqlParameter("@serienum", serie));
                Com.Transaction = xTran;
                numero = Convert.ToInt32(ExecuteScalar(Com));
                using (IDataReader Reader = ExecuteReader(Com))
                {

                    if (Reader.Read())
                    {
                        numero = (int)Reader["NUMERO"] + 1;
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

        Documento IMapperDocumentos.getFacturaByID(string xSerie, int Numero, TipoLineas xTipo)
        {
            Documento F = null;

            string Query = "SELECT * FROM VENTAS V ";
            switch (xTipo)
            {
                case TipoLineas.Contado:
                    Query += "INNER JOIN VENTASCONTADO VC ON V.NUMERO = VC.NUMERO AND V.CODSERIE = VC.SERIE INNER JOIN CLIENTESCONTADO AS CC ON (V.CODDOCUMENTO=CC.CODIGO) ";
                    break;
                case TipoLineas.Credito:
                    Query += "INNER JOIN VENTASCREDITO VC ON V.NUMERO = VC.NUMERO AND V.CODSERIE = VC.CODSERIE";
                    break;
            }
            Query += " WHERE V.CODSERIE = @SERIE AND V.NUMERO = @NUMERO";
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand(Query, Con))
                {
                    Com.Parameters.Add(new SqlParameter("@SERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", Numero));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if (Reader.Read())
                        {
                            F = getFacturaFromReader(Reader, xTipo);
                        }
                    }
                }
            }
            return F;
        }

        public object getVentas(DateTime xFechaI, DateTime xFechaF)
        {

            DataTable DT = new DataTable();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT FECHA, NUMERO,CAST(SUM(SUBTOTAL) AS DECIMAL(18,2)) AS SUBTOTAL, CAST(SUM(IVA) AS DECIMAL(18,2)) AS IVA, CAST(SUM(SUBTOTAL + IVA) AS DECIMAL(18,2)) AS TOTAL FROM VENTAS WHERE FECHA BETWEEN @INICIO AND @FINAL GROUP BY FECHA,NUMERO", (SqlConnection)Con))
                {
                    Com.Parameters.Add(new SqlParameter("@INICIO", xFechaI));
                    Com.Parameters.Add(new SqlParameter("@FINAL", xFechaF));
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public object getEntrega(int xNumero, string xSerie)
        {
            Entrega E = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 FECHA,ENVIO_NOMBRE,ENVIO_DIRECCION,ENVIO_TELEFONO FROM ENTREGA WHERE CODSERIE = @SERIE AND NUMERO = @NUMERO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@SERIE", xSerie));
                    Com.Parameters.Add(new SqlParameter("@NUMERO", xNumero));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            DateTime Fec = (DateTime)Reader["FECHA"];
                            string Nom = (string)(Reader["ENVIO_NOMBRE"] is DBNull ? string.Empty : Reader["ENVIO_NOMBRE"]);
                            string Dir = (string)(Reader["ENVIO_DIRECCION"] is DBNull ? string.Empty : Reader["ENVIO_DIRECCION"]);
                            string Tel = (string)(Reader["ENVIO_TELEFONO"] is DBNull ? string.Empty : Reader["ENVIO_TELEFONO"]);
                            E = getEntraLineas(xNumero,xSerie,Fec, Nom, Dir, Tel, Con);
                        }
                    }
                }
            }
            return E;
        }

        private Entrega getEntraLineas(int xNumero,string xSerie,DateTime fec, string nom, string dir, string tel, SqlConnection xCon)
        {
            List<EntregaLin> Lineas = new List<EntregaLin>();
            EntregaLin EL = null;

            using (SqlCommand Com = new SqlCommand("SELECT L.LINEA,L.CANTIDAD,L.ENTREGADO,L.DEVUELTO,L.NOTAC,L.RECIBIDO FROM ENTREGALIN L WHERE L.CODSERIE = @SERIE AND L.NUMERO = @CODIGO", xCon))
            {
                Com.Parameters.Add(new SqlParameter("@CODIGO", xNumero));
                Com.Parameters.Add(new SqlParameter("@SERIE", xSerie));
                using (IDataReader Reader = ExecuteReader(Com))
                {
                    while (Reader.Read())
                    {
                        int Linea = (int)Reader["LINEA"];
                        decimal Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
                        decimal Entregado = Convert.ToDecimal(Reader["ENTREGADO"]);
                        decimal Dev = Convert.ToDecimal(Reader["DEVUELTO"]);
                        decimal NotC = Convert.ToDecimal(Reader["NOTAC"]);
                        decimal Rec = Convert.ToDecimal(Reader["RECIBIDO"]);
                        EL = new EntregaLin(Linea, Cantidad, Entregado, Dev, NotC);
                        Lineas.Add(EL);
                    }
                }
            }
            return new Entrega(xNumero, xSerie, Lineas);
        }
    }
}
    


        