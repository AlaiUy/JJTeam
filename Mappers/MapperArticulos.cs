using System;
using JJ.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using JJ.Entidades;
using System.Data.Common;

namespace JJ.Mappers
{
    public class MapperArticulos : DataAccess, IMapperArticulos
    {
       
        public bool Add(object xObject)
        {
            Articulo A = (Articulo)xObject;
            int Codigo =-1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    try
                    {
                        Codigo = _AddArticulo(A, Con, Tran);
                        if (Codigo > -1)
                            foreach (PreciosVenta PV in A.Precios)
                                _AddPrecioVenta(PV, Codigo, Con, Tran);
                        return true;
                    }
                    catch (Exception E)
                    {
                        Tran.Rollback();
                        throw E;
                    }
                }
            }
            
        }

        public void AddDepartamento(object xDepto)
        {
            Departamento D = (Departamento)xDepto;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO DEPARTAMENTOS(NOMBRE) VALUES (@NOMBRE)", Con))
                {
                    List<IDataParameter> P = new List<IDataParameter>();
                    P.Add(new SqlParameter("@NOMBRE", D.Nombre.ToUpper()));
                    ExecuteNonQuery(Com, P);
                }

            }
        } //Faster

        public void AddMarca(object xMarca)
        {

            Marca M = (Marca)xMarca;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO MARCAS(NOMBRE) VALUES (@NOMBRE)", Con))
                {
                    List<IDataParameter> P = new List<IDataParameter>();
                    P.Add(new SqlParameter("@NOMBRE", M.Nombre.ToUpper()));
                    ExecuteNonQuery(Com, P);
                }

            }
        }

        public IList<object> getDepartamentos()
        {

            IList<object> Departamentos = new List<object>();
            Departamento Entity = null;
            IList<object> Secciones;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT D.CODIGO,D.NOMBRE FROM DEPARTAMENTOS D WHERE D.ACTIVO = 1", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            Secciones = getSeccionesByDpto(Codigo);
                            Entity = new Departamento(Codigo, Nombre);
                            Entity.addSecciones(Secciones);
                            Departamentos.Add(Entity);
                        }
                    }
                }
            }    
            return Departamentos;
        }

        public IList<object> getSeccionesByDpto(int codigo)
        {

            IList<object> Secciones = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT S.CODIGO,S.NOMBRE FROM SECCIONES S WHERE CODDEPARTAMENTO = @CODIGODPTO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGODPTO", codigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            Secciones.Add(new Seccion(Codigo, Nombre));
                        }
                    }
                }
            }
            return Secciones;
        }

        public IList<object> getMonedas()
        {
            return MapperGeneral.getInstance().getMonedas();
        }

        public bool Remove(object xObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object xObject)
        {
            throw new NotImplementedException();
        }

        public IList<object> getMarcas()
        {
            IList<object> Marcas = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT M.CODIGO,M.NOMBRE FROM MARCAS M", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            Marcas.Add(new Marca(Codigo, Nombre));
                        }
                    }
                }
            }
            return Marcas;
        }

        public IList<object> getArticulos()
        {
            IList<object> Articulos = new List<object>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT A.CODIGO,A.NOMBRE,A.DESCRIPCION,A.REFERENCIA,A.CODBARRAS,A.CODBARRAS1,A.ACTIVO,A.CODMARCA,A.CODSECCION,A.CODDEPARTAMENTO,A.MODELO FROM ARTICULOS A", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Codigo = (int)Reader["CODIGO"];
                            string Nombre = (string)Reader["NOMBRE"];
                            string Descripcion = (string)(Reader["DESCRIPCION"] is DBNull ? string.Empty : Reader["DESCRIPCION"]);
                            string Referencia = (string)Reader["REFERENCIA"];
                            string CodBarras = (string)(Reader["CODBARRAS"] is DBNull ? string.Empty : Reader["CODBARRAS"]);
                            string CodBarras1 = (string)(Reader["CODBARRAS1"] is DBNull ? string.Empty : Reader["CODBARRAS1"]);
                            bool Activo;
                            bool.TryParse(Reader["ACTIVO"].ToString(),out Activo);
                            int Marca = (int)Reader["CODMARCA"];
                            string Modelo = (string)(Reader["MODELO"] is DBNull ? string.Empty : Reader["MODELO"]);
                            int CodDepartamento = (int)Reader["CODDEPARTAMENTO"];
                            int CodSeccion = (int)Reader["CODSECCION"];
                            IList<PreciosVenta> Precios = getPreciosByArticulo(Codigo);
                            Articulo A = new Articulo(Codigo,Descripcion,Referencia,Precios);
                            A.Nombre = Nombre;
                            A.Codbarras = CodBarras;
                            A.Codbarras1 = CodBarras1;
                            A.Activo = Activo;
                            A.Modelo = Modelo;
                            A.Coddepto = CodDepartamento;
                            A.Codseccion = CodSeccion;
                            Articulos.Add(A);
                        }
                    }
                }
            }
            return Articulos;
        }

        private IList<PreciosVenta> getPreciosByArticulo(int codigo)
        {
            IList<PreciosVenta> Precios = new List<PreciosVenta>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT AP.CODTARIFA,AP.BRUTO,AP.GANANCIA,AP.CODMONEDA FROM ARTICULOPRECIOS AP WHERE AP.ACTIVO = 1 AND AP.CODARTICULO = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int Tarifa = (int)Reader["CODTARIFA"];
                            decimal Bruto,Ganancia;
                            decimal.TryParse(Reader["BRUTO"].ToString(),out Bruto);
                            decimal.TryParse(Reader["GANANCIA"].ToString(), out Ganancia);
                            int CodMoneda = (int)Reader["CODMONEDA"];
                            Precios.Add(new PreciosVenta(Tarifa, Bruto, Ganancia, CodMoneda));
                        }
                    }
                }
            }
            return Precios;
        }


        /* ==== METODOS PRIVADOS ==== */
        //@@ Son utilizados cuando una funcion requiere ultilizar  una transaccion para guardar en mas de 1 tabla a la vez, la idea que el codigo 
        //de cada tabla quede lo mejor legible.

        private int _AddArticulo(Articulo xA,IDbConnection xCon,IDbTransaction xTran)
        {
            //Agrego los datos en la tabla articulo, no uso conexion, porque viene en una transaccion, asumo que la conexion viene de afuera.
            int CodArtculo = -1;
            List<IDataParameter> P = new List<IDataParameter>();
            P.Add(new SqlParameter("@NOMBRE", xA.Nombre.ToUpper()));
            P.Add(new SqlParameter("@DESCRIPCION", xA.Descripcion.ToUpper()));
            P.Add(new SqlParameter("@REFERENCIA", xA.Referencia.ToUpper()));
            P.Add(new SqlParameter("@CODBARRAS", xA.Codbarras.ToUpper()));
            P.Add(new SqlParameter("@CODBARRAS1", xA.Codbarras1.ToUpper()));
            P.Add(new SqlParameter("@ACTIVO", xA.Activo));
            //CODMARCA,MODELO,CODDEPARTAMENTO,CODSECCION
            P.Add(new SqlParameter("@CODMARCA", xA.Codmarca));
            P.Add(new SqlParameter("@MODELO", xA.Modelo));
            P.Add(new SqlParameter("@CODDEPARTAMENTO", xA.Coddepto));
            P.Add(new SqlParameter("@CODSECCION", xA.Codseccion));
            using (SqlCommand Com = new SqlCommand("INSERT INTO ARTICULOS(NOMBRE,DESCRIPCION,REFERENCIA,CODBARRAS,CODBARRAS1,ACTIVO,CODMARCA,MODELO,CODDEPARTAMENTO,CODSECCION) OUTPUT INSERTED.CODIGO VALUES (@NOMBRE,@DESCRIPCION,@REFERENCIA,@CODBARRAS,@CODBARRAS1,@ACTIVO,@CODMARCA,@MODELO,@CODDEPARTAMENTO,@CODSECCION)", (SqlConnection)xCon))
            {
                Com.Transaction = (SqlTransaction)xTran;
                var Result = ExecuteScalar(Com, P);
                int.TryParse(Result.ToString(), out CodArtculo);
            }
            return CodArtculo;
        }

        private void _AddPrecioVenta(PreciosVenta xPV,int xCodArticulo, IDbConnection xCon, IDbTransaction xTran)
        {
            //Agrego los datos en la tabla ARTICULOPRECIOS, no uso conexion, porque viene en una transaccion, asumo que la conexion viene de afuera.

            List<IDataParameter> P = new List<IDataParameter>();
            P.Add(new SqlParameter("@CODARTICULO", xCodArticulo));
            P.Add(new SqlParameter("@CODTARIFA", xPV.CodTarifa));
            P.Add(new SqlParameter("@GANANCIA", xPV.Ganancia));
            P.Add(new SqlParameter("@CODMONEDA", xPV.CodMoneda));
            P.Add(new SqlParameter("@BRUTO", xPV.PrecioBruto));
            using (SqlCommand Com = new SqlCommand("INSERT INTO ARTICULOPRECIOS(CODARTICULO,CODTARIFA,BRUTO,GANANCIA,CODMONEDA) VALUES (@CODARTICULO,@CODTARIFA,@BRUTO,@GANANCIA,@CODMONEDA)", (SqlConnection)xCon))
            {
                Com.Transaction = (SqlTransaction)xTran;
                ExecuteNonQuery(Com, P);
            }
           
        }

        
    }
}
