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
    public class MapperGeneral: DataAccess,IMapper
    {
        private static MapperGeneral _Instance = null;
        private static readonly object _padlock = new object();
        private IList<object> _Monedas;


        public IList<object> Monedas
        {
            get
            {
                return _Monedas;
            }

            protected set
            {
                _Monedas = value;
            }
        }

        public static MapperGeneral getInstance()
        {
            if (_Instance == null)
            {
                lock (_padlock)
                {
                    if (_Instance == null)
                        _Instance = new MapperGeneral();
                }
            }

            return _Instance;
        }

        private MapperGeneral() {
            _Monedas = getMonedas();
        }

        public bool Add(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        public IList<object> getMonedas()
        {

            IList<object> Monedas = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT T.CODIGO,T.NOMBRE,T.SUBFIJO, T.COEFICIENTE FROM MONEDAS T WHERE T.ACTIVA = 1", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            string SubFijo = (string)Reader["SUBFIJO"];
                            decimal Coeficiente= (Decimal)Reader["COEFICIENTE"];
                            Monedas.Add(new Moneda(Codigo, Nombre, SubFijo,Coeficiente));
                        }
                    }
                }
            }
            return Monedas;
        }

        public void AddMoneda(Moneda M)
        {
            if (_Monedas == null)
                _Monedas = new List<object>();
            _Monedas.Add(M);
        }

        

    }
}
