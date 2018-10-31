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
        public bool Add(object xObject)
        {
            throw new NotImplementedException();
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


        public IList<object> getDocumentoEspera()
        {
            IList<object> DocumentosEspera = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM ESPERA   WHERE ESTADO=1 AND FECHA= GETDATE() ", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        Espera Entity;
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            DateTime fecha = (DateTime)Reader["FECHA"];
                            int Moneda = (int)Reader["MONEDA"];
                            int CodPersona = (int)Reader["CODPERSONA"];
                            int CodCuenta = (int)Reader["CODCUENTA"];
                            byte Estado = (byte)Reader["ESTADO"];
                            int Tipo = (int)Reader["TIPO"];
                            string NombreOpc = (String)Reader["NombreOpc"];
                            string Diropc = (string)Reader["DirOpc"];
                            string RutOpc = (string)Reader["RUTOPC"];
                            string Adenda = (string)Reader["ADENDA"];

                            Entity = new Espera(Codigo,fecha,CodPersona,CodCuenta,Moneda,1,Estado,NombreOpc,Diropc,RutOpc,Adenda,null);




                            DocumentosEspera.Add(Entity);
                        }
                    }

                }
            }
            return DocumentosEspera;
        }

        public IList<object> getDocumentoEsperaLineas(int xCodigoEspera)
        {
            IList<object> DocumentosEspera = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM ESPERALIN WHERE CODIGO=@CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xCodigoEspera));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        Esperalin Entity;
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            int CodEspera = (int)Reader["MONEDA"];
                            int CodArticulo = (int)Reader["CODPERSONA"];
                            int Cantidad = (int)Reader["CODCUENTA"];
                            byte Precio = (byte)Reader["ESTADO"];
                            int Descuento = (int)Reader["TIPO"];
                            string Iva = (String)Reader["NombreOpc"];
                            

                        //    Entity = new Espera(Codigo, fecha, CodPersona, CodCuenta, Moneda, 1, Estado, NombreOpc, Diropc, RutOpc, Adenda);


                         //   DocumentosEspera.Add(new Factura());
                        }
                    }

                }
            }
            return DocumentosEspera;
        }




    }
}
