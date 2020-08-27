using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class EstadoCuentaProveedor : EstadoCuenta
    {
        Proveedor _Proveedor;
        public EstadoCuentaProveedor(List<Object> xMovimientos,DateTime xFecha,Proveedor xProveedor) : base(xMovimientos, xFecha)
        {
            _Proveedor = xProveedor;
        }

        public Proveedor Proveedor
        {
            get
            {
                return _Proveedor;
            }
        }
    }
}
