using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Grupo
    {
        private int _id;
        private string _Nombre;
        private List<Parametro> _Parametros;
        private Caja _Caja;
        private List<Equipo> _Equipos;
        

        public Grupo(int xId, string xNombre, List<Parametro> xParams)
        {
            _id = xId;
            _Nombre = xNombre;
            _Parametros = xParams;
        }

        public Grupo(int xId, string xNombre, Caja xCaja)
        {
            _id = xId;
            _Nombre = xNombre;
            _Caja = xCaja;
        }

        public Grupo(string xNombre, List<Parametro> xParams,Caja xCaja)
        {
            _id = -1;
            _Nombre = xNombre;
            _Parametros = xParams;
            _Caja = xCaja;
        }

        public Grupo(string xNombre,Caja xCaja)
        {
            _id = -1;
            _Nombre = xNombre;
            _Caja = xCaja;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
        }

        public List<Parametro> Parametros
        {
            get
            {
                return _Parametros;
            }
        }

        public Caja Caja
        {
            get
            {
                return _Caja;
            }
        }

        public List<Equipo> Equipos
        {
            get
            {
                return _Equipos;
            }
        }

        public void Addparam(Parametro xParam)
        {
            if (_Parametros == null)
            {
                _Parametros = new List<Parametro>();
                _Parametros.Add(xParam);
                return;
            }

            foreach (Parametro P in _Parametros)
            {
                if (P.Id == xParam.Id)
                    return;
            }

            _Parametros.Add(xParam);

        }

        public void Addparams(List<Parametro> xParams)
        {
            if (_Parametros == null)
            {
                _Parametros = xParams;
                return;
            }

            foreach (Parametro P in xParams)
            {
                Addparam(P);
            }
            
        }

        public void Remove(object xType)
        {
            if(xType is Parametro)
            {
                if (_Parametros == null)
                    return;

                if (_Parametros.Remove(((Parametro)xType)) == true)
                    return;

                for (int Index = 0; Index <= _Parametros.Count; Index++)
                    if (_Parametros[Index].Id == ((Parametro)xType).Id)
                        _Parametros.RemoveAt(Index);
            }
            

        }


        public bool AddEquipo(Equipo xEquipo)
        {
            if (_Equipos == null)
            {
                _Equipos = new List<Equipo>();
                _Equipos.Add(xEquipo);
                return true;
            }

            foreach (Equipo P in _Equipos)
            {
                if (P.Id == P.Id)
                    return false;
                if (P.DirIP.Length > 15)
                    return false;
            }

            _Equipos.Add(xEquipo);
            return true;
        }

        public string AddEquipos(List<Equipo> xEquipos)
        {
            
            foreach (Equipo E in xEquipos)
            {
                if(AddEquipo(E) == false)
                {
                    return "El equipo " + E.Nombre + " No se agrego";
                    
                }
            }
            return "Exito";

        }

        public override string ToString()
        {
            return _id + " - " + _Nombre;
        }


        public bool Parametroexists(Parametro xParam)
        {
            if (_Parametros.Find(x => x.Id == xParam.Id) != null)
                return true;
            return false;
        }

        public bool Parametroexists(int xParam)
        {
            if (_Parametros.Find(x => x.Id == xParam) != null)
                return true;
            return false;
        }

        public void UpdateParameter(Parametro xParam, string xValor)
        {
            _Parametros.Find(x => x.Id == xParam.Id).Valor = xValor;
        }

        public void UpdateParameter(int xParam, string xValor)
        {
            _Parametros.Find(x => x.Id == xParam).Valor = xValor;
        }

        public bool EquipoExists(Equipo xEquipo)
        {
            if (_Equipos == null)
                return false;
            if (_Equipos.Find(x => x.Id == xEquipo.Id) != null)
                return true;
            return false;
        }

        public bool EquipoExists(int xEquipo)
        {
            if (_Equipos == null)
                return false;
            if (_Equipos.Find(x => x.Id == xEquipo) != null)
                return true;
            return false;
        }

    }
}
