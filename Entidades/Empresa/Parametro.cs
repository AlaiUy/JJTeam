using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Parametro:IEquatable<Parametro>
    {
        private int _Id;
        private string _Nombre;
        private string _Valor;

        public int Id
        {
            get
            {
                return _Id;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
        }

        public string Valor
        {
            get
            {
                return _Valor;
            }

            set
            {
                _Valor = value;
            }
        }

        public Parametro(int xId, string xNombre, string xValor)
        {
            _Id = xId;
            _Nombre = xNombre;
            _Valor = xValor;
        }

        public Parametro(string xNombre, string xValor)
        {
            _Id = -1;
            _Nombre = xNombre;
            _Valor = xValor;
        }

        public override string ToString()
        {
            return _Id + " - " + _Nombre;
        }

        public override bool Equals(object obj)
        {
            //Verifico que sea del mismo tipo
            if (obj.GetType() != typeof(Parametro)) return false;

            //Valido que el objeto no sea null
            if (ReferenceEquals(null, obj)) return false;

            //Verifico si el objeto actual es igual al que recibo por parámetro
            if (ReferenceEquals(this, obj)) return true;

            Parametro P = (Parametro)obj;

            if (P._Id == _Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _Id;
        }

        public bool Equals(Parametro obj)
        {
            //Verifico que sea del mismo tipo
            if (obj.GetType() != typeof(Parametro)) return false;

            //Valido que el objeto no sea null
            if (ReferenceEquals(null, obj)) return false;

            //Verifico si el objeto actual es igual al que recibo por parámetro
            if (ReferenceEquals(this, obj)) return true;

            Parametro P = (Parametro)obj;

            if (P._Id == _Id)
                return true;

            return false;
        }
    }
}
