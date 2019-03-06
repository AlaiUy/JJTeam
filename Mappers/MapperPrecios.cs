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
    public class MapperPrecios : DataAccess, IMapperPrecios
    {
        
        public bool Add(object xObject)
        {
            throw new NotImplementedException();
        }

        public void AddTarifa(object xTarifa)
        {
            Tarifa T = (Tarifa)xTarifa;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO TARIFAS(NOMBRE,ACTIVA) VALUES (@NOMBRE,@ACTIVO)", Con))
                {
                    List<IDataParameter> P = new List<IDataParameter>();
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", T.Nombre.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@ACTIVO", T.Activa));
                    ExecuteNonQuery(Com);
                }
            }
        }

        public void AgregarMoneda(object xMoneda)
        {
            Moneda M = (Moneda)xMoneda;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO MONEDAS(NOMBRE,SUBFIJO,ACTIVA) VALUES (@NOMBRE,@SUBFIJO,@ACTIVA)", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", M.Nombre.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@SUBFIJO", M.SubFijo));
                    Com.Parameters.Add(new SqlParameter("@ACTIVA", 1));
                    ExecuteNonQuery(Com);
                }
            }
        }

        public IList<object> getMonedas()
        {
            return MapperGeneral.getInstance().getMonedas();
        }

        public IList<object> getTarifas()
        {

            IList<object> Tarifas = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT T.CODIGO,T.NOMBRE,T.CARGO FROM TARIFAS T WHERE T.ACTIVA = 1", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            Tarifa T = getTarifaReader(Reader);
                            Tarifas.Add(T);
                        }
                    }
                }
            }
            return Tarifas;

            
        }

        public bool Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object xObject)
        {
            throw new NotImplementedException();
        }

        private Tarifa getTarifaReader(IDataReader Reader)
        {
            Tarifa T;
            int Codigo = (int)Reader["CODIGO"];
            string Nombre = (string)Reader["NOMBRE"];
            decimal Cargo = Convert.ToDecimal(Reader["CARGO"]);
            T = new Tarifa(Codigo, Nombre, Cargo);
            return T;
        }
    }
}
