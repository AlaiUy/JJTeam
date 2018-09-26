using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Departamento
    {
        private int _Codigo;
        private string _Nombre;
        private IList<Seccion> _Secciones;

        public int Codigo
        {
            get
            {
                return _Codigo;
            }
            
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public IList<Seccion> Secciones
        {
            get
            {
                return _Secciones;
            }

            protected set
            {
                _Secciones = value;
            }
        }

        public Departamento()
        { }

        public Departamento(int xCodigo, string xNombre) {
            _Codigo = xCodigo;
            _Nombre = xNombre;
        }

        public Departamento(int xCodigo, string xNombre,IList<Seccion> xSecciones) {
            _Codigo = xCodigo;
            _Nombre = xNombre;
            _Secciones = xSecciones;

        }

        public void addSeccion(Seccion xSeccion)
        {
            if (_Secciones == null)
                _Secciones = new List<Seccion>();

            if (_Secciones.Contains(xSeccion))
                return;

            _Secciones.Add(xSeccion);
        }

        public void addSecciones(IList<object> xSecciones)
        {
            if (xSecciones == null)
                return;
            foreach (object O in xSecciones)
                addSeccion((Seccion)O);
        }

        public override string ToString()
        {
            return _Codigo  + " - " + _Nombre;
        }


    }
}
