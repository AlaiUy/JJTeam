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
    public class MapperCobros : DataAccess, IMapperCobros
    {
        public bool Add(object xObject)
        {
            if (xObject is Recibo)
                GenerarRecibo(xObject);

            return true;
        }

        private List<Recibo> GenerarRecibo(object xRecibo)
        {
            PreRecibo R = (PreRecibo)xRecibo;
            List<Recibo> _Recibos = new List<Recibo>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    try
                    {
                        int NumeroPesos = GuardarRecibo(R.Movimientos.FindAll(Obj => Obj.Moneda == 1), Tran, Con, R.Fecha, R.Serie);
                        int NumeroDolares = GuardarRecibo(R.Movimientos.FindAll(Obj => Obj.Moneda == 2), Tran, Con, R.Fecha, R.Serie);
                        Tran.Commit();
                        return _Recibos;
                    }

                    catch (Exception E)
                    {
                        Tran.Rollback();
                        throw E;
                    }
                }
            }
        }

        private int GuardarRecibo(List<Movimiento> xList, IDbTransaction xTran, IDbConnection xCon, DateTime xFecha, string xRecibo)
        {
            int xNumero = -1;
            using (SqlCommand Com = new SqlCommand("SELECT ISNULL(MAX(NUMEROPAGO),1) AS NUMERO FROM TESORERIAP WHERE SERIEPAGO = @SERIE", (SqlConnection)xCon))
            {
                Com.Transaction = (SqlTransaction)xTran;
                Com.Parameters.Add(new SqlParameter("@SERIE", xRecibo));
                xNumero = (int)ExecuteScalar(Com);
                xNumero += 1;
                foreach (Movimiento M in xList)
                {
                    decimal xSaldo = M.Importe - M.Saldar;
                    Com.CommandText = "UPDATE TESORERIAP SET IMPORTE = @IMPORTE,FECHAPAGO = @FECHAPAGO,SERIEPAGO = @SERIEPAGO,NUMEROPAGO = @NUMEROPAGO,ESTADO = 'S' WHERE SERIE = @SERIE AND NUMERO = @NUMERO AND LIN = @LINEA";
                    List<IDataParameter> P = new List<IDataParameter>();
                    P.Add(new SqlParameter("@IMPORTE", M.Saldar));
                    P.Add(new SqlParameter("@FECHAPAGO", xFecha));
                    P.Add(new SqlParameter("@SERIE", M.SerieInterna));
                    P.Add(new SqlParameter("@NUMERO", M.NumeroInterno));
                    P.Add(new SqlParameter("@LINEA", M.Linea));
                    P.Add(new SqlParameter("@SERIEPAGO", xRecibo));
                    P.Add(new SqlParameter("@NUMEROPAGO", xNumero));
                    ExecuteNonQuery(Com, P);
                    if (xSaldo > 0)
                    {
                        Com.CommandText = "SELECT MAX(LIN) AS NUMERO FROM TESORERIAP WHERE SERIE = @SERIE AND NUMERO = @NUMERO";
                        int Result = (int)ExecuteScalar(Com);
                        Com.CommandText = "INSERT INTO TESORERIAP(SERIE,NUMERO,LIN,FECHA,ESTADO,CODMONEDA,COTIZACION,IMPORTE,CODPROVEEDOR) VALUES (@SERIE,@NUMERO,@LIN,@FECHA,@ESTADO,@CODMONEDA,@COTIZACION,@IMPORTE,@CODPROVEEDOR)";
                        P = new List<IDataParameter>();
                        P.Add(new SqlParameter("@SERIE", M.SerieInterna));
                        P.Add(new SqlParameter("@NUMERO", M.NumeroInterno));
                        P.Add(new SqlParameter("@LIN", Result + 1));
                        P.Add(new SqlParameter("@FECHA", M.Fecha));
                        P.Add(new SqlParameter("@ESTADO", 'P'));
                        P.Add(new SqlParameter("@CODMONEDA", M.Moneda));
                        P.Add(new SqlParameter("@COTIZACION", M.Cotizacion));
                        P.Add(new SqlParameter("@IMPORTE", xSaldo));
                        P.Add(new SqlParameter("@CODPROVEEDOR", M.Codproveedor));
                        ExecuteNonQuery(Com, P);
                    }
                }
            }
            return xNumero + 1;
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


    }
}
