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
                    P.Add(new SqlParameter("@NOMBRE", T.Nombre.ToUpper()));
                    P.Add(new SqlParameter("@ACTIVO", T.Activa));
                    ExecuteNonQuery(Com, P);
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
                using (SqlCommand Com = new SqlCommand("SELECT T.CODIGO,T.NOMBRE FROM TARIFAS T WHERE T.ACTIVA = 1", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            Tarifas.Add(new Tarifa(Codigo, Nombre));
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
    }
}
