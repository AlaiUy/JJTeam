using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Iva
    {
        private int _id;
        private string _nombre;
        private decimal _valor;

        public Iva(int xId,string xNombre,decimal xValor)
        {
            _id = xId;
            _nombre = xNombre;
            _valor = xValor;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            
        }

        public decimal Valor
        {
            get
            {
                return _valor;
            }
        }

        public override string ToString()
        {
            return _id + " - " + _nombre + " " + _valor + "%";
        }
    }
}
