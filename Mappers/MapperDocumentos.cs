﻿using JJ.Entidades;
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
            if (xObject is VentaCuenta)

            if(xObject is VentaContado)

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
                        AgregarLineasEsperaContado(E.Lineas, Con, Tran, xCodEspera);
                        Tran.Commit();
                }
            }
        }

        private void AgregarLineasEsperaContado(List<Esperalin> lineas, SqlConnection xCon, SqlTransaction xTran, int xCodEsperaContado)
        {
            foreach (object L in lineas)
            {
                Esperalin EL = (Esperalin)L;
                List<IDataParameter> Lin = new List<IDataParameter>();
                Lin.Add(new SqlParameter("@CODESPERACONTADO", xCodEsperaContado));
                Lin.Add(new SqlParameter("@LINEA", EL.NumLinea));
                Lin.Add(new SqlParameter("@CODARTICULO", EL.ObjArticulo.CodArticulo));
                Lin.Add(new SqlParameter("@DESCRIPCION", EL.ObjArticulo.Descripcion));
                Lin.Add(new SqlParameter("@CANTIDAD", EL.Cantidad));
                Lin.Add(new SqlParameter("@DESCUENTO", EL.Descuento));
     
                using (SqlCommand Com = new SqlCommand("INSERT INTO ESPERALINCONTADO (CODESPERACONTADO, LINEA, CODARTICULO, DESCRIPCION, CANTIDAD, DESCUENTO) VALUES (@CODESPERACONTADO, @LINEA, @CODARTICULO, @DESCRIPCION, @CANTIDAD, @DESCUENTO)", (SqlConnection)xCon))
                {
                    Com.Transaction = (SqlTransaction)xTran;
                    ExecuteNonQuery(Com, Lin);
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
                            EsperaContado E = new EsperaContado(Codigo, Fecha);
                            E.Codmoneda = (int)Reader["MONEDA"];
                            E.Codvendedor = (int)Reader["CODVENDEDOR"];
                            E.Codclientecontado = (int) Reader["CLIENTECONTADO"];
                            E.Estado = (int)Reader["ESTADO"];
                            E.Tipo = (int)Reader["TIPO"];
                            E.DirEnvio = (string)(Reader["DIRECCIONENVIO"] is DBNull ? string.Empty : Reader["DIRECCIONENVIO"]);
                            E.Adenda = (string)(Reader["ADENDA"] is DBNull ? string.Empty : Reader["ADENDA"]);
   
                          
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
                            int codEspera = (int)Reader["CODESPERA"];
                            int NumLin = (int)Reader["LINEA"];

                            Esperalin L = new Esperalin();
         
                            L.Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
                         L.ObjArticulo =(Articulo) (new MapperArticulos().getArticuloById(((string)Reader["CODARTICULO"])));
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



            return false;

        }

        List<object> IMapperDocumentos.getVentasEspera()
        {
            throw new NotImplementedException();
        }

        bool IMapper.Add(object xObject)
        {
            throw new NotImplementedException();
        }

        bool IMapper.Update(object xObject)
        {
            throw new NotImplementedException();
        }

        bool IMapper.Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        IList<object> IMapper.getMonedas()
        {
            throw new NotImplementedException();
        }
    }
}


        