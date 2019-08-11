using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Seriedoc
    {
        private int _Documento;
        private string _Nombre;
        private string _Serie;

        public int Documento
        {
            get
            {
                return _Documento;
            }

            set
            {
                _Documento = value;
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

        public string Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
            }
        }

        public Seriedoc(int xDocumento, string xNombre)
        {
            _Documento = xDocumento;
            _Nombre = xNombre;
        }

        public Seriedoc(int xDocumento, string xNombre, string xSerie) {
            _Documento = xDocumento;
            _Nombre = xNombre;
            _Serie = xSerie;
        }

        public override string ToString()
        {
            return _Documento + " - " + _Nombre;
        }
    }
}
