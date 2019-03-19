using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Caja
    {
        private int _Codigo;
        private string _Nombre;
        private List<Seriedoc> _Series;

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

        public Caja()
        {
            _Codigo = -1;
        }

        public Caja(int xCodigo, string xNombre, List<Seriedoc> xSeries)
        {
            _Codigo = xCodigo;
            _Nombre = xNombre;
            _Series = xSeries;
        }

        public Caja(string xNombre, List<Seriedoc> xSeries)
        {
            _Codigo = -1;
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
                if (S.Documento == xSerie.Documento && S.Serie.Equals(xSerie.Nombre))
                    return true;
            return false;
        }
    }
}
