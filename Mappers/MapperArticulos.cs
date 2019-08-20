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
                        Tran.Commit();
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

      

        

        public object AddMarca(object xMarca)
        {

            Marca M = (Marca)xMarca;
            int Codigo = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO MARCAS(NOMBRE) OUTPUT INSERTED.CODIGO VALUES (@NOMBRE)", Con))
                {
                    List<IDataParameter> P = new List<IDataParameter>();
                    P.Add(new SqlParameter("@NOMBRE", M.Nombre.ToUpper()));
                    var Result = ExecuteScalar(Com, P);
                    int.TryParse(Result.ToString(), out Codigo);
                }

            }
            if (Codigo > -1)
            {
                return new Marca(Codigo, M.Nombre);
            }
                
            return null;
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
                using (SqlCommand Com = new SqlCommand("SELECT A.CODIGO,A.NOMBRE,A.DESCRIPCION,A.REFERENCIA,A.CODBARRAS,A.CODBARRAS1,A.ACTIVO,A.CODMARCA,A.CODSECCION,A.CODDEPARTAMENTO,A.MODELO,A.COSTO,A.IVA,A.GANANCIA,A.MONEDACOMPRA,A.RECALCULA FROM ARTICULOS A", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            Articulo A = getArticuloReader(Reader);
                            Articulos.Add(A);
                        }
                    }
                }
            }
            return Articulos;
        }

       
        public object getArticuloById(string xArticulo)
        {
            Articulo A = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 A.CODIGO,A.NOMBRE,A.DESCRIPCION,A.REFERENCIA,A.CODBARRAS,A.CODBARRAS1,A.ACTIVO,A.CODMARCA,A.CODSECCION,A.CODDEPARTAMENTO,A.MODELO,A.COSTO,A.IVA,A.GANANCIA,A.MONEDACOMPRA,A.RECALCULA FROM ARTICULOS A where A.CODIGO = @CODIGO OR A.REFERENCIA = @CODIGO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xArticulo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if(Reader.Read())
                        {
                            A = getArticuloReader(Reader);
                        }
                    }
                }
            }
            return A;
        }

        


        /* ==== METODOS PRIVADOS ==== */
        //@@ Son utilizados cuando una funcion requiere ultilizar  una transaccion para guardar en mas de 1 tabla a la vez, la idea que el codigo 
        //de cada tabla quede lo mejor legible.


        private int _addDepartamento(Departamento xDepto, SqlConnection xCon, SqlTransaction xTran)
        {
            int CodDepto = -1;
            using (SqlCommand Com = new SqlCommand("INSERT INTO DEPARTAMENTOS(NOMBRE) OUTPUT INSERTED.CODIGO VALUES (@NOMBRE)", xCon))
            {
                Com.Parameters.Add(new SqlParameter("@NOMBRE", xDepto.Nombre.Trim().ToUpper()));
                Com.Transaction = xTran;
                var Result = ExecuteScalar(Com);
                int.TryParse(Result.ToString(), out CodDepto);
            }
            return CodDepto;
        }

        private void _addSecciones(Seccion S, int xCodigoDepto, SqlConnection con, SqlTransaction tran)
        {
            
            using (SqlCommand Com = new SqlCommand("INSERT INTO SECCIONES(CODDEPARTAMENTO,NOMBRE) VALUES (@DEPTO,@NOMBRE)", (SqlConnection)con))
            {
                Com.Transaction = tran;
                Com.Parameters.Add(new SqlParameter("@DEPTO", xCodigoDepto));
                Com.Parameters.Add(new SqlParameter("@NOMBRE", S.Nombre.ToUpper()));
                ExecuteNonQuery(Com);
            }
        }

        private Articulo getArticuloReader(IDataReader Reader)
        {
            Articulo A;
            int Codigo = (int)Reader["CODIGO"];
            string Nombre = (string)Reader["NOMBRE"];
            string Descripcion = (string)(Reader["DESCRIPCION"] is DBNull ? string.Empty : Reader["DESCRIPCION"]);
            string Referencia = (string)Reader["REFERENCIA"];
            string CodBarras = (string)(Reader["CODBARRAS"] is DBNull ? string.Empty : Reader["CODBARRAS"]);
            string CodBarras1 = (string)(Reader["CODBARRAS1"] is DBNull ? string.Empty : Reader["CODBARRAS1"]);
            bool Activo;
            bool.TryParse(Reader["ACTIVO"].ToString(), out Activo);
            int Marca = (int)Reader["CODMARCA"];
            string Modelo = (string)(Reader["MODELO"] is DBNull ? string.Empty : Reader["MODELO"]);
            int CodDepartamento = (int)Reader["CODDEPARTAMENTO"];
            int xCodMoneda = (int)Reader["MONEDACOMPRA"];
            int CodSeccion = (int)Reader["CODSECCION"];
            decimal Costo = Convert.ToDecimal(Reader["COSTO"]);
            decimal Ganancia = Convert.ToDecimal(Reader["GANANCIA"]);
            int Recalcula = (int)Reader["RECALCULA"];
            Iva IVA = new MapperEmpresa().getIvaByID((int)(Reader["IVA"]));
            A = new Articulo(Codigo, Descripcion, Referencia, Costo, IVA, Ganancia,xCodMoneda,Convert.ToBoolean((Recalcula)));
            A.Nombre = Nombre;
            A.Codbarras = CodBarras;
            A.Codbarras1 = CodBarras1;
            A.Activo = Activo;
            A.Modelo = Modelo;
            A.Coddepto = CodDepartamento;
            A.Codseccion = CodSeccion;
            A.Codmarca = Marca;
            return A;
        }


        private int _AddArticulo(Articulo xA,IDbConnection xCon,IDbTransaction xTran)
        {
            int CodArtculo = -1;
            List<IDataParameter> P = new List<IDataParameter>();
            

            using (SqlCommand Com = new SqlCommand("INSERT INTO ARTICULOS(NOMBRE,DESCRIPCION,REFERENCIA,CODBARRAS,CODBARRAS1,ACTIVO,CODMARCA,MODELO,CODDEPARTAMENTO,CODSECCION,COSTO,GANANCIA,IVA,MONEDACOMPRA,RECALCULA) OUTPUT INSERTED.CODIGO VALUES (@NOMBRE,@DESCRIPCION,@REFERENCIA,@CODBARRAS,@CODBARRAS1,@ACTIVO,@CODMARCA,@MODELO,@CODDEPARTAMENTO,@CODSECCION,@COSTO,@GANANCIA,@IVA,@MONEDA,@RECALCULA)", (SqlConnection)xCon))
            {
                Com.Parameters.Add(new SqlParameter("@NOMBRE", xA.Nombre.ToUpper()));
                Com.Parameters.Add(new SqlParameter("@DESCRIPCION", xA.Descripcion.ToUpper()));
                Com.Parameters.Add(new SqlParameter("@REFERENCIA", xA.Referencia.ToUpper()));
                Com.Parameters.Add(new SqlParameter("@CODBARRAS", xA.Codbarras.ToUpper()));
                Com.Parameters.Add(new SqlParameter("@CODBARRAS1", xA.Codbarras1.ToUpper()));
                Com.Parameters.Add(new SqlParameter("@ACTIVO", xA.Activo));
                Com.Parameters.Add(new SqlParameter("@CODMARCA", xA.Codmarca));
                Com.Parameters.Add(new SqlParameter("@MODELO", xA.Modelo));
                Com.Parameters.Add(new SqlParameter("@CODDEPARTAMENTO", xA.Coddepto));
                Com.Parameters.Add(new SqlParameter("@CODSECCION", xA.Codseccion));
                Com.Parameters.Add(new SqlParameter("@COSTO", xA.Costo));
                Com.Parameters.Add(new SqlParameter("@GANANCIA", xA.Ganancia));
                Com.Parameters.Add(new SqlParameter("@IVA", xA.Iva.Id));
                Com.Parameters.Add(new SqlParameter("@MONEDA", xA.CodMoneda));
                Com.Parameters.Add(new SqlParameter("@RECALCULA", xA.Recalcula));
                Com.Transaction = (SqlTransaction)xTran;
                var Result = ExecuteScalar(Com);
                int.TryParse(Result.ToString(), out CodArtculo);
            }
            return CodArtculo;
        }

        

        public object AddDepartamento(object xDepto)
        {
            Departamento D = (Departamento)xDepto;
            int Codigo = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlTransaction Tran = Con.BeginTransaction())
                {
                    try
                    {
                         Codigo = _addDepartamento(D, Con, Tran);
                        if (Codigo > -1)
                            if (D.Secciones != null && D.Secciones.Count > 0)
                                foreach (Seccion S in D.Secciones)
                                    _addSecciones(S, Codigo, Con, Tran);
                        Tran.Commit();
                        if (Codigo > -1)
                            D = new Departamento(Codigo, D.Nombre, D.Secciones);
                        else
                            D = null;
                    }
                    catch (Exception e)
                    {
                        Tran.Rollback();
                        throw e;
                    }
                }
            }
            return D;
        }

        public object AddSeccion(object xSeccion, object xDepto)
        {
            int Codigo = -1;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO SECCIONES(CODDEPARTAMENTO,NOMBRE) OUTPUT INSERTED.CODIGO VALUES (@DEPTO,@NOMBRE)", Con))
                {

                    Com.Parameters.Add(new SqlParameter("@DEPTO", ((Departamento)xDepto).Codigo));
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", ((Seccion)xSeccion).Nombre.ToUpper()));
                    var Result = ExecuteScalar(Com);
                    int.TryParse(Result.ToString(), out Codigo);
                }

            }
            if (Codigo > -1)
            {
                return new Seccion(Codigo, ((Seccion)xSeccion).Nombre);
            }

            return null;
        }

        public object getVistaArticulos()
        {
            DataTable DT = new DataTable();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT * FROM dbo.JL_ArtciulosView", (SqlConnection)Con))
                { 
                    DT.Load(ExecuteReader(Com));
                }
            }
            return DT;
        }

        public void Actualizar(Articulo xA, decimal xGanancia, decimal xCosto)
        {
            List<IDataParameter> P = new List<IDataParameter>();

            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("UPDATE ARTICULOS SET NOMBRE=@NOMBRE,DESCRIPCION=@DESCRIPCION,REFERENCIA=@REFERENCIA,CODBARRAS=@CODBARRAS,CODBARRAS1=@CODBARRAS1,ACTIVO=@ACTIVO,CODMARCA=@CODMARCA,MODELO=@MODELO,CODDEPARTAMENTO=@CODDEPARTAMENTO,CODSECCION=@CODSECCION,COSTO=@COSTO,GANANCIA=@GANANCIA,IVA=@IVA,MONEDACOMPRA=@MONEDA,RECALCULA=@RECALCULA WHERE CODIGO = @CODIGO", (SqlConnection)Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODIGO", xA.CodArticulo));
                    Com.Parameters.Add(new SqlParameter("@NOMBRE", xA.Nombre.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@DESCRIPCION", xA.Descripcion.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@REFERENCIA", xA.Referencia.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@CODBARRAS", xA.Codbarras.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@CODBARRAS1", xA.Codbarras1.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@ACTIVO", xA.Activo));
                    Com.Parameters.Add(new SqlParameter("@CODMARCA", xA.Codmarca));
                    Com.Parameters.Add(new SqlParameter("@MODELO", xA.Modelo));
                    Com.Parameters.Add(new SqlParameter("@CODDEPARTAMENTO", xA.Coddepto));
                    Com.Parameters.Add(new SqlParameter("@CODSECCION", xA.Codseccion));
                    Com.Parameters.Add(new SqlParameter("@COSTO", xCosto));
                    Com.Parameters.Add(new SqlParameter("@GANANCIA", xGanancia));
                    Com.Parameters.Add(new SqlParameter("@IVA", xA.Iva.Id));
                    Com.Parameters.Add(new SqlParameter("@MONEDA", xA.CodMoneda));
                    Com.Parameters.Add(new SqlParameter("@RECALCULA", xA.Recalcula));
                    ExecuteNonQuery(Com);
                }
            }
        }
    }
}
