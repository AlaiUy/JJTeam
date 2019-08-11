using JJ.Entidades;
using JJ.FabricaMapper;
using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Gestoras
{
    public class GesEmpresa
    {
        private static GesEmpresa _Instance = null;
        private static IMapperEmpresa _DBEmpresa;
        private static readonly object padlock = new object();
        private Empresa _Emp = null;

        public Empresa Empresa
        {
            get
            {
                return _Emp;
            }
        }

        public void AddEmpresa(Empresa xEmpresa)
        {

            if (xEmpresa == null)
                return;

            if (xEmpresa.CodEmpresa != -1)
                return;

            if (xEmpresa.Nombre.Length < 4 || xEmpresa.Nombre.Length > 100)
                throw new Exception("El nombre de la empresa no es valido. [Length 4-100]");

            if (xEmpresa.Razonsocial.Length < 3 || xEmpresa.Razonsocial.Length > 100)
                throw new Exception("La razon social de la empresa no es valida. [Length 3-100]");

            if (!Tools.Numeros.ValidaRut(xEmpresa.Rut.Trim()))
                throw new Exception("El rut no se puede validar, o ya esta ingresada la empresa");

            if (xEmpresa.Direccion.Length < 5 || xEmpresa.Direccion.Length > 100)
                throw new Exception("No se puede guardar esa direccion.[Length 5-100]");

            if (xEmpresa.Ciudad.Length < 2 || xEmpresa.Ciudad.Length > 50)
                throw new Exception("No se puede ingresar esa ciudad. [Length 2-50]");

            if (xEmpresa.Pais.Length < 4 || xEmpresa.Ciudad.Length > 50)
                throw new Exception("No se puede ingresar ese Pais. [Length 4-50]");

            if (xEmpresa.Telefono.Length > 1  && xEmpresa.Telefono.Length != 8)
                if (!Tools.Numeros.isNumeric(xEmpresa.Telefono))
                    throw new Exception("No se puede ingresar ese telefono. [Only number.]");
                else
                    throw new Exception("No se puede ingresar ese telefono. [Max 8.]");

            if (xEmpresa.Email.Length < 100)
            {
                if (!xEmpresa.Email.Contains("@"))
                {
                    throw new Exception("El email no se puede validar. [Must contain: @]");
                }   
            }
            else
            {
                throw new Exception("El direccion de correo electronico no valida en este sistema. [Max 100.]");
            }


            _DBEmpresa.addEmpresa(xEmpresa);
            _Emp = (Empresa)_DBEmpresa.getempresa();
        }

        public static GesEmpresa getInstance()
        {
            if (_Instance == null)
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new GesEmpresa();
                }
            }

            return _Instance;
        }

        public GesEmpresa()
        {
            _DBEmpresa = (IMapperEmpresa)Factory.getMapper(GetType());
            _Emp = (Empresa)_DBEmpresa.getempresa();
        }

        public void AddGroup(Grupo xGrupo)
        {
            if (_Emp == null)
                throw new Exception("Debe registrar la empresa primero");

            if(xGrupo.Caja == null)
                throw new Exception("Se debe asignar una caja al grupo");


            if (xGrupo.Id == -1)
                _DBEmpresa.Add(xGrupo);
        }

        public void UpdateGroup(Grupo xGrupo)
        {
            if (_Emp == null)
                throw new Exception("Debe registrar la empresa primero");

            if (xGrupo.Id > -1)
                _DBEmpresa.Update(xGrupo);
            return;
        }
        public Empresa getEmpresa()
        {
            _Emp =  (Empresa)_DBEmpresa.getempresa();
            if (_Emp == null)
                throw new Exception("Aun no se ha registrado una empresa");
            return _Emp;
        }

        public void AddCaja(Caja xCaja)
        {
            if (xCaja.Codigo.Length > 3)
                throw new Exception("El codigo de caja es demasiado extenso");

            if (xCaja.Codigo.Length < 1)
                throw new Exception("El codigo de caja no puede ser vacio");

            if (xCaja.Series.Count < 1)
                throw new Exception("No existen series para esta caja");

            if (CheckSeries(xCaja.Series) == false)
                throw new Exception("Algun documento no tiene serie asignada");

            if (GesCajas.getInstance().getCajaByID(xCaja.Codigo) != null)
            {
                throw new Exception("Esa caja ya existe");
            }

            _DBEmpresa.AddCaja(xCaja);
        }

        public Grupo getGrupo()
        {
            return (Grupo)_DBEmpresa.getGrupo();

        }

        private bool CheckSeries(List<Seriedoc> series)
        {
            foreach(Seriedoc S in series)
            {
                if (S.Serie.Length < 1)
                {
                    return false;
                }
                    
            }
            return true;
                
        }

        public void AgregarEquipo(Equipo xEquipo)
        {
            if (xEquipo == null)
                throw new Exception("El equipo es nulo");

            if (xEquipo.Descripcion.Length > 100)
                throw new Exception("La descripcion es demasiado extensa");
            if (xEquipo.Nombre.Length > 100)
                throw new Exception("El nombre del equipo es demasiado extenso");

            if (_Emp.Equipos.Find(x => x.Nombre == xEquipo.Nombre) != null)
                throw new Exception("El equipo ya se encuentra ingresado");

            _DBEmpresa.addEquipo(xEquipo);
            _Emp = (Empresa)_DBEmpresa.getempresa();
        }

       
    }

    
}
