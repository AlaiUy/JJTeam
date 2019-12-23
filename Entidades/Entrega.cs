using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Entrega
    {
        private int _Numero;
        private string _Serie;
        private List<EntregaLin> _Lineas;


        public List<EntregaLin> LINEAS
        {
            get
            {
                return _Lineas;
            }

            set
            {
                _Lineas = value;
            }
        }

        public Entrega(int xNumero, string xSerie, List<EntregaLin> xLineas)
        {
            _Numero = xNumero;
            _Serie = xSerie;
            _Lineas = xLineas;
       
        }

        public bool Devolver(int xLinea, decimal xCantidad)
        {
            EntregaLin el =  _Lineas.Find(Obj => Obj.Linea == xLinea);
            if (el.Disponible() >= xCantidad)
                return true;

            return false;
        }
            
    }
}
