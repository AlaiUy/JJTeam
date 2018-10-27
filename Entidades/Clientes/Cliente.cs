using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Cliente
    {
        private int _CodCliente;
        private int _Cedula;
        private int _Rut;
        private string _Celular;
        private string _Telefono;
        private string _Direccion;
        private int _DireccionNumero;
        private int _DireccionApto;
        private int _Categoria;
        private int _Tipo;
        private IList<Cuenta> Cuentas;

        public int CodCliente
        {
            get
            {
                return _CodCliente;
            }

            set
            {
                _CodCliente = value;
            }
        }
    }
}
