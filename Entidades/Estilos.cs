using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public static class Estilos
    {
        public static string FormatearImporte(decimal xImporte)
        {
            return xImporte.ToString("N", new CultureInfo("is-IS"));
        }
    }
}
