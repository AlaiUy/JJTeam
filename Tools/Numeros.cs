using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tools
{
    public static class Numeros
    {
        public static bool isNumeric(string xCadena)
        {
            Regex reNum = new Regex(@"^\d+$");
            if (reNum.Match(xCadena).Success) // evaluates to true
            {
                try
                {
                    double i = double.Parse(xCadena); // throws FormatException
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return false;
        }

        public static bool VerificaDocumento(int pNumero)
        {
            //Control inicial sobre la cantidad de números ingresados. 
            if (pNumero.ToString().Length > 5 && pNumero.ToString().Length < 9)
            {

                int[] _formula = { 2, 9, 8, 7, 6, 3, 4 };
                int _suma = 0;
                int _guion = 0;
                int _aux = 0;
                int[] _numero = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

                if (pNumero.ToString().Length == 8)
                {
                    _numero[0] = Convert.ToInt32(pNumero.ToString()[0].ToString());
                    _numero[1] = Convert.ToInt32(pNumero.ToString()[1].ToString());
                    _numero[2] = Convert.ToInt32(pNumero.ToString()[2].ToString());
                    _numero[3] = Convert.ToInt32(pNumero.ToString()[3].ToString());
                    _numero[4] = Convert.ToInt32(pNumero.ToString()[4].ToString());
                    _numero[5] = Convert.ToInt32(pNumero.ToString()[5].ToString());
                    _numero[6] = Convert.ToInt32(pNumero.ToString()[6].ToString());
                    _numero[7] = Convert.ToInt32(pNumero.ToString()[7].ToString());
                }

                //Para cédulas menores a un millón. 
                if (pNumero.ToString().Length == 7)
                {
                    _numero[0] = 0;
                    _numero[1] = Convert.ToInt32(pNumero.ToString()[0].ToString());
                    _numero[2] = Convert.ToInt32(pNumero.ToString()[1].ToString());
                    _numero[3] = Convert.ToInt32(pNumero.ToString()[2].ToString());
                    _numero[4] = Convert.ToInt32(pNumero.ToString()[3].ToString());
                    _numero[5] = Convert.ToInt32(pNumero.ToString()[4].ToString());
                    _numero[6] = Convert.ToInt32(pNumero.ToString()[5].ToString());
                    _numero[7] = Convert.ToInt32(pNumero.ToString()[6].ToString());
                }

                if (pNumero.ToString().Length == 6)
                {
                    _numero[0] = 0;
                    _numero[1] = 0;
                    _numero[2] = Convert.ToInt32(pNumero.ToString()[0].ToString());
                    _numero[3] = Convert.ToInt32(pNumero.ToString()[1].ToString());
                    _numero[4] = Convert.ToInt32(pNumero.ToString()[2].ToString());
                    _numero[5] = Convert.ToInt32(pNumero.ToString()[3].ToString());
                    _numero[6] = Convert.ToInt32(pNumero.ToString()[4].ToString());
                    _numero[7] = Convert.ToInt32(pNumero.ToString()[5].ToString());

                }

                _suma = (_numero[0] * _formula[0]) + (_numero[1] * _formula[1]) + (_numero[2] * _formula[2]) + (_numero[3] * _formula[3]) + (_numero[4] * _formula[4]) + (_numero[5] * _formula[5]) + (_numero[6] * _formula[6]);

                for (int i = 0; i < 10; i++)
                {
                    _aux = _suma + i;
                    if (_aux % 10 == 0)
                    {
                        _guion = _aux - _suma;
                        i = 10;
                    }
                }

                if (_numero[7] == _guion)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }

        public static bool ValidaTelefono(string telefono)
        {
            if (telefono == "0")
                return true;
            if (!isNumeric(telefono))
                return false;
            if (telefono.Length != 8)
                return false;
            return true;
        }

        public static bool ValidaCelular(string telefono)
        {
            if (telefono == "0")
                return true;
            if (!isNumeric(telefono))
                return false;
            if (telefono.Length != 9)
                return false;
            return true;
        }

        public static bool ValidaRut(string rut)
        {
            if (!isNumeric(rut))
                return false;
            if (rut == "0")
                return true;
            if (rut.Length < 11 || rut.Length > 12)
                return false;
            return true;
        }

        public static string ConvertirImporte(string xImporte)
        {
            return string.Empty;
        }
    }
    
}
