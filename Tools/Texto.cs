using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
    public static class Texto
    {
        public static bool isLarge(string xTexto, byte xMinimo, byte xMaximo)
        {
            if (xTexto.Length < xMinimo || xTexto.Length > xMaximo)
                return false;
            return true;
        }

        public static bool AcceptEmail(string xTexto)
        {
            if (xTexto.Length >= 7 && xTexto.Contains("@"))
                return true;
            return false;
        }
    }
}
