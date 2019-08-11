using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Equipo
    {
        private int _id;
        private string _nombre;
        private string _Descripcion;
        private string _DirIP;

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
                return _nombre;
            }
        }

        public string DirIP
        {
            get
            {
                return _DirIP;
            }

            set
            {
                _DirIP = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        

        public Equipo(string xNombre,string xDescripcion)
        {
            _id = -1;
            _nombre = xNombre;
            _Descripcion = xDescripcion;
        }
        public Equipo(int xId, string xNombre, string xDescripcion, string xIP)
        {
            _id = xId;
            _nombre = xNombre;
            _Descripcion = xDescripcion;
            _DirIP = xIP;
        }

        public override string ToString()
        {
           return _id + " - " + _nombre;
        }


    }
}
