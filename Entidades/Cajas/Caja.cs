using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Caja
    {
        private bool isNew;
        private string _Codigo;
        private string _Nombre;
        private List<Seriedoc> _Series;
        private int _Z;

        public string Codigo
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

        public int Z
        {
            get
            {
                return _Z;
            }
        }

        public bool IsNew
        {
            get
            {
                return isNew;
            }
        }

        public List<Seriedoc> Series
        {
            get
            {
                return _Series;
            } 
        }

        public Caja(string xCodigo, string xNombre, List<Seriedoc> xSeries)
        {
            _Codigo = xCodigo;
            _Nombre = xNombre;
            _Series = xSeries;
        }

        public Caja(string xNombre, List<Seriedoc> xSeries)
        {
            _Codigo = "";
            _Nombre = xNombre;
            _Series = xSeries;
        }

        public void Addserie(Seriedoc xSerie)
        {
            if (_Series == null)
                _Series = new List<Seriedoc>();
            if(!ExisteSerie(xSerie))
                _Series.Add(xSerie);
        }

        public void Addseries(List<Seriedoc> xSeries)
        {
            if (_Series == null)
                _Series = new List<Seriedoc>();
            foreach (Seriedoc S in xSeries)
                Addserie(S);
        }
        private bool ExisteSerie(Seriedoc xSerie)
        {
            foreach (Seriedoc S in _Series)
                if (S.Documento == xSerie.Documento)
                    return true;
            return false;
        }

        public Seriedoc getSerieByID(int xCodDocumento)
        {
            return _Series.Find(x => x.Documento == xCodDocumento);
        }

        public override string ToString()
        {
            return _Codigo + " - " + _Nombre;
        }
    }
}
