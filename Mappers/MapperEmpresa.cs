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
    public class MapperEmpresa : DataAccess, IMapperEmpresa
    {
        public bool Add(object xObject)
        {
            Grupo G = (Grupo)xObject;
            try
            {
                using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
                {
                    Con.Open();
                    using (SqlCommand Com = new SqlCommand("INSERT INTO EGRUPOS(NOMBRE,CAJA) VALUES (@NOMBRE,@CAJA)", Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@NOMBRE", G.Nombre));
                        Com.Parameters.Add(new SqlParameter("@CAJA", G.Caja.Codigo));
                        ExecuteNonQuery(Com);
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void AddCaja(object xCaja)
        {
            MapperCajas M = new MapperCajas();
            M.CrearCaja((Caja)xCaja);

        }

        public IList<object> getMonedas()
        {
            throw new NotImplementedException();
        }

        public bool Remove(object xObject)
        {
            Grupo G = (Grupo)xObject;
            try
            {
                using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
                {
                    Con.Open();
                    using (SqlCommand Com = new SqlCommand("DELETE * FROM EPARAMETROS WHERE IDGRUPO = @GRUPO", Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@GRUPO", G.Id));
                        ExecuteNonQuery(Com);
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool Update(object xObject)
        {
            Grupo G = (Grupo)xObject;
            try
            {
                using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
                {
                    Con.Open();
                    SqlTransaction T = Con.BeginTransaction();
                    using (SqlCommand Com = new SqlCommand("DELETE FROM EPARAMETROS WHERE IDGRUPO = @GRUPO", Con))
                    {
                        Com.Transaction = T;
                        Com.Parameters.Add(new SqlParameter("@GRUPO", G.Id));
                        ExecuteNonQuery(Com);
                    }

                    

                    foreach (Parametro P in G.Parametros)
                    {
                        using (SqlCommand Com = new SqlCommand("INSERT INTO EPARAMETROS(IDPAR,IDGRUPO,VALOR) VALUES (@IDPAR,@IDGRUPO,@VALOR)", Con))
                        {
                            Com.Transaction = T;
                            Com.Parameters.Add(new SqlParameter("@IDPAR", P.Id));
                            Com.Parameters.Add(new SqlParameter("@IDGRUPO", G.Id));
                            Com.Parameters.Add(new SqlParameter("@VALOR", P.Valor));
                            ExecuteNonQuery(Com);
                        }
                    }

                    foreach (Equipo E in G.Equipos)
                    {
                        using (SqlCommand Com = new SqlCommand("UPDATE EQUIPOS SET IDGRUPO = @IDGRUPO WHERE NOMBRE = @NOMBRE", Con))
                        {
                            Com.Transaction = T;
                            Com.Parameters.Add(new SqlParameter("@NOMBRE", E.Nombre));
                            Com.Parameters.Add(new SqlParameter("@IDGRUPO", G.Id));
                            ExecuteNonQuery(Com);
                        }
                    }
                    T.Commit();
                    return true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void addEquipo(object xEquipo)
        {
            Equipo E = (Equipo)xEquipo;
            try
            {
                using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
                {
                    Con.Open();
                    using (SqlCommand Com = new SqlCommand("INSERT INTO EQUIPOS(NOMBRE,DESCRIPCION,DIRIP) VALUES (@NOMBRE,@DESCRIPCION,@DIRIP)", Con))
                    {
                        Com.Parameters.Add(new SqlParameter("@NOMBRE", E.Nombre));
                        Com.Parameters.Add(new SqlParameter("@DESCRIPCION", E.Descripcion));
                        Com.Parameters.Add(new SqlParameter("@DIRIP", E.DirIP));
                        ExecuteNonQuery(Com);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public object getempresa()
        {
            Empresa ObjEmpresa = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 CODEMPRESA,NOMBRE,RAZONSOCIAL,RUT,DIRECCION,CIUDAD,PAIS,TELEFONO,EMAIL,LOGO,DESCUENTO_CONTADO AS DESCUENTO FROM EMPRESA", Con))
                {

                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        if (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["CODEMPRESA"]);
                            string xNombre = (string)(Reader["NOMBRE"]);
                            string xRz = (string)(Reader["RAZONSOCIAL"]);
                            string xRut = (string)(Reader["RUT"] is DBNull ? string.Empty : Reader["RUT"]);
                            string xDir = (string)(Reader["DIRECCION"]);
                            string xCiudad = (string)(Reader["CIUDAD"]);
                            string xPais = (string)(Reader["PAIS"]);
                            string xTelefono = (string)(Reader["TELEFONO"] is DBNull ? string.Empty : Reader["TELEFONO"]);
                            string xEmail = (string)(Reader["EMAIL"] is DBNull ? string.Empty : Reader["EMAIL"]);
                            decimal xDescuento = Convert.ToDecimal((Reader["DESCUENTO"]));
                            byte[] xLogo = (byte[])((Reader["LOGO"] is DBNull ? string.Empty : Reader["LOGO"]));
                            ObjEmpresa = new Empresa(xCodigo, xRz, xRut);
                            ObjEmpresa.Ciudad = xCiudad;
                            ObjEmpresa.Direccion = xDir;
                            ObjEmpresa.Email = xEmail;
                            ObjEmpresa.Imagen = xLogo;
                            ObjEmpresa.Nombre = xNombre;
                            ObjEmpresa.Pais = xPais;
                            ObjEmpresa.Telefono = xTelefono;
                            ObjEmpresa.Parametros = getParametros();
                            ObjEmpresa.Grupos = getGrupos();
                            ObjEmpresa.Series = getDocumentos();
                            ObjEmpresa.Cajas = new MapperCajas().getCajas();
                            ObjEmpresa.Equipos = getEquipos();
                            ObjEmpresa.Ivas = getIvas();
                            ObjEmpresa.Vendedores = getVendedores();
                            ObjEmpresa.DescuentoContado = xDescuento;

                        }
                    }
                }
            }

            return ObjEmpresa;
        }

        private List<object> getVendedores()
        {
            return new MapperVendedores().getVendedores();
        }

        private List<Iva> getIvas()
        {
            List<Iva> ListIva = new List<Iva>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT IDIVA,NOMBRE,VALOR FROM TIPOSIVA", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        while (Reader.Read())
                        {

                            Iva I = getIvaFromReader(Reader);
                            ListIva.Add(I);
                        }
                    }
                }
            }
            return ListIva;
        }

        private Iva getIvaFromReader(IDataReader Reader)
        {
            int xCodigo = (int)(Reader["IDIVA"]);
            string xNombre = (string)(Reader["NOMBRE"]);
            decimal xValor = Convert.ToDecimal((Reader["VALOR"]));
            Iva I = new Iva(xCodigo, xNombre, xValor);
            return I;
        }

        private List<Equipo> getEquipos()
        {
            List<Equipo> Equipos = new List<Equipo>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT IDEQUIPO,NOMBRE,DESCRIPCION,DIRIP FROM EQUIPOS", Con))
                {
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        while (Reader.Read())
                        {

                            Equipo E = getEquipoFromReader(Reader);
                            Equipos.Add(E);
                        }
                    }
                }
            }
            return Equipos;
        }

        private Equipo getEquipoFromReader(IDataReader Reader)
        {
            int xCodigo = (int)(Reader["IDEQUIPO"]);
            string xNombre = (string)(Reader["NOMBRE"]);
            string xDescripcion = (string)(Reader["DESCRIPCION"]);
            string xIP = (string)(Reader["DIRIP"] is DBNull ? string.Empty : Reader["DIRIP"]);
            Equipo E = new Equipo(xCodigo, xNombre, xDescripcion, xIP);
            return E;
        }

        internal Iva getIvaByID(int xIdIva)
        {
            Iva I = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 IDIVA,NOMBRE,VALOR FROM TIPOSIVA WHERE IDIVA = @ID", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@ID", xIdIva));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        if(Reader.Read())
                        {

                            I= getIvaFromReader(Reader);
                        }
                    }
                }
            }
            return I;
        }




        /// <summary>
        /// Devuelve una lista de los documentos disponibles, sin la serie asiganada (Eso es cuando se asigna a una caja).
        /// Necesita se invocado en un try and catch, puede generar una excepcion.
        /// </summary>
        private List<Seriedoc> getDocumentos()
        {
            List<Seriedoc> Documentos = new List<Seriedoc>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT CODIGO,NOMBRE FROM DOCUMENTOS", Con))
                {

                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        while (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["CODIGO"]);
                            string xNombre = (string)(Reader["NOMBRE"]);
                            Seriedoc S = new Seriedoc(xCodigo, xNombre);
                            Documentos.Add(S);
                        }
                    }
                }
            }
            return Documentos;
        }




        public void addEmpresa(object xEmpresa)
        {
            Empresa Em = (Empresa)xEmpresa;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO EMPRESA(NOMBRE,RAZONSOCIAL,RUT,DIRECCION,CIUDAD,PAIS,TELEFONO,EMAIL,LOGO) VALUES (@NOMBRE,@RAZONSOCIAL,@RUT,@DIRECCION,@CIUDAD,@PAIS,@TELEFONO,@EMAIL,@LOGO)", Con))
                {

                    Com.Parameters.Add(new SqlParameter("@NOMBRE", Em.Nombre.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@RAZONSOCIAL", Em.Razonsocial.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@RUT", Em.Rut));
                    Com.Parameters.Add(new SqlParameter("@DIRECCION", Em.Direccion.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@CIUDAD", Em.Ciudad.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@PAIS", Em.Pais.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@TELEFONO", Em.Telefono.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@EMAIL", Em.Email.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@LOGO", Em.Imagen));
                    ExecuteNonQuery(Com);
                }

            }
        }



        private List<Grupo> getGrupos()
        {
            List<Grupo> Grupos = new List<Grupo>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT IDGRUPO,NOMBRE,CAJA FROM EGRUPOS", Con))
                {

                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        while (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["IDGRUPO"]);
                            string xNombre = (string)(Reader["NOMBRE"]);
                            string xCaja = (string)(Reader["CAJA"]);
                            Caja C = (Caja)new MapperCajas().getCajaById(xCaja);
                            Grupo G = new Grupo(xCodigo, xNombre,C);
                            G.Addparams(getParametros(xCodigo));
                            G.AddEquipos(getEquiposByGroup(xCodigo));
                            Grupos.Add(G);
                        }
                    }
                }
            }
            return Grupos;
        }

        public object getGrupo()
        {
            Grupo G = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 G.IDGRUPO,G.NOMBRE,G.CAJA FROM EGRUPOS G INNER JOIN EQUIPOS E ON G.IDGRUPO = E.IDGRUPO WHERE E.NOMBRE = @EQUIPO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@EQUIPO", Environment.MachineName));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        while (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["IDGRUPO"]);
                            string xNombre = (string)(Reader["NOMBRE"]);
                            string xCaja = (string)(Reader["CAJA"]);
                            Caja C = (Caja)new MapperCajas().getCajaById(xCaja);
                             G = new Grupo(xCodigo, xNombre, C);
                            G.Addparams(getParametros(xCodigo));
                            G.AddEquipos(getEquiposByGroup(xCodigo));
                        }
                    }
                }
            }
            return G;
        }

        private List<Equipo> getEquiposByGroup(int xCodigo)
        {
            List<Equipo> Equipos = new List<Equipo>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT IDEQUIPO,NOMBRE,DESCRIPCION,DIRIP FROM EQUIPOS WHERE IDGRUPO = @GRUPO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@GRUPO", xCodigo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            Equipos.Add(getEquipoFromReader(Reader));
                        }
                    }
                }
            }
            return Equipos;
        }

        private List<Parametro> getParametros()
        {
            List<Parametro> Parametros = new List<Parametro>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT IDPAR,NOMBRE FROM PARAMETROS", Con))
                {

                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        while (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["IDPAR"]);
                            string xNombre = (string)(Reader["NOMBRE"]);
                            Parametro P = new Parametro(xCodigo, xNombre, "");
                            Parametros.Add(P);
                        }
                    }
                }
            }
            return Parametros;
        }

        private Parametro getParametroByID(int xIdParametro)
        {
            Parametro P = null;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT TOP 1 IDPAR,NOMBRE FROM PARAMETROS WHERE IDPAR = @ID", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@ID", xIdParametro));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {

                        if (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["IDPAR"]);
                            string xNombre = (string)(Reader["NOMBRE"]);
                            P = new Parametro(xCodigo, xNombre, "");
                        }
                    }
                }
            }
            return P;
        }

        private List<Parametro> getParametros(int xCodGrupo)
        {
            List<Parametro> Parametros = new List<Parametro>();
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("SELECT IDPAR,IDGRUPO,VALOR FROM EPARAMETROS WHERE IDGRUPO = @GRUPO", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@GRUPO", xCodGrupo));
                    using (IDataReader Reader = ExecuteReader(Com))
                    {
                        while (Reader.Read())
                        {
                            int xCodigo = (int)(Reader["IDPAR"]);
                            string xValor = (string)(Reader["VALOR"]);
                            Parametro P = getParametroByID(xCodigo);
                            P.Valor = xValor;
                            Parametros.Add(P);
                        }
                    }
                }
            }
            return Parametros;
        }

        public void UpdateEmpresa(Empresa xEmpresa)
        {
            Empresa Em = (Empresa)xEmpresa;
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("UPDATE EMPRESA SET NOMBRE=@NOMBRE,DIRECCION=@DIRECCION,CIUDAD=@CIUDAD,PAIS=@PAIS,TELEFONO=@TELEFONO,EMAIL=@EMAIL,LOGO=@LOGO,DESCUENTO_CONTADO=@DESCUENTO", Con))
                {

                    Com.Parameters.Add(new SqlParameter("@NOMBRE", Em.Nombre.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@DIRECCION", Em.Direccion.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@CIUDAD", Em.Ciudad.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@PAIS", Em.Pais.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@TELEFONO", Em.Telefono.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@EMAIL", Em.Email.ToUpper()));
                    Com.Parameters.Add(new SqlParameter("@LOGO", Em.Imagen));
                    Com.Parameters.Add(new SqlParameter("@DESCUENTO", Em.DescuentoContado));
                    ExecuteNonQuery(Com);
                }

            }
        }

        public void ChangeCot(decimal xCotizacion, int xCodigo)
        {
            using (SqlConnection Con = new SqlConnection(GlobalConnectionString))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand("INSERT INTO COTIZACIONES (CODMONEDA,VALOR,FECHA)VALUES(@CODMONEDA,@VALOR,GETDATE())", Con))
                {
                    Com.Parameters.Add(new SqlParameter("@CODMONEDA", xCodigo));
                    Com.Parameters.Add(new SqlParameter("@VALOR", xCotizacion));
                    ExecuteNonQuery(Com);
                }

            }
        }
    }
}
