using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JJ.Mappers
{
    public abstract class DataAccess
    {
        private static string globalConnectionString;



        public static string GlobalConnectionString
        {
            get
            {
                try
                {
                    if (globalConnectionString == null)
                        globalConnectionString = ConfigurationManager.ConnectionStrings["Servidor"].ConnectionString;



                    return DataAccess.globalConnectionString;

                }

                catch (Exception e)
                {
                    throw e;
                }


            }
            set { DataAccess.globalConnectionString = value; }
        }




        public int ExecuteNonQuery(DbCommand cmd)
        {
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(e.Message);
            }
        }


        public int ExecuteNonQuery(DbCommand cmd, List<IDataParameter> Lts)
        {
            
            foreach (IDataParameter P in Lts)
            {
                if(cmd.Parameters.Contains(P.ParameterName))
                    cmd.Parameters.RemoveAt(P.ParameterName);
                cmd.Parameters.Add(P);
            }

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {

                CerrarConexion(cmd.Connection);
                throw new Exception(E.Message);
            }

        }



        public IDataReader ExecuteReader(DbCommand cmd)
        {
            try
            {
                return cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch (Exception e)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(e.Message);
            }
        }

        public IDataReader ExecuteReader(DbCommand cmd, List<IDataParameter> Lts)
        {
            foreach (IDataParameter P in Lts)
            {
                cmd.Parameters.Add(P);
            }
            try
            {
                return cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch (Exception e)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(e.Message);
            }
        }


        public object ExecuteScalar(DbCommand cmd, List<IDataParameter> Lts)
        {
            foreach (IDataParameter P in Lts)
            {
                cmd.Parameters.Add(P);
            }
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(e.Message);
            }
        }


        public object ExecuteScalar(DbCommand cmd)
        {
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(e.Message);
            }
        }

        protected void CerrarConexion(IDbConnection CN)
        {
            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        protected DateTime getFechaFromReader(IDataReader rd)
        {
            DateTime ztmp = DateTime.MinValue;
            try
            {
                ztmp = Convert.ToDateTime((rd["FECHA"] is DBNull ? DateTime.MinValue : rd["FECHA"]));
                return ztmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int ExecuteNonQuery(DbCommand cmd, List<IDataParameter> Lts, List<string> xQuerys)
        {
            foreach (IDataParameter P in Lts)
            {
                cmd.Parameters.Add(P);
            }

            try
            {
                if (xQuerys.Count > 0)
                {
                    foreach (string S in xQuerys)
                    {
                        cmd.CommandText = S;
                        cmd.ExecuteNonQuery();
                    }

                }
                return 1;
            }
            catch (Exception E)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(E.Message);
            }
        }

        public int ExecuteNonQuery(DbCommand cmd, IDataParameter Param)
        {
            try
            {
                cmd.Parameters.Add(Param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                CerrarConexion(cmd.Connection);
                throw new Exception(e.Message);
            }
        }
    }

}
