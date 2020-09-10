using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Presupuesto
    {
        private DateTime _Fecha;
        private string _Nombre;
        private List<PresupuestoLin> _Lineas;

        public List<PresupuestoLin> Lineas
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

        public void addLinea(PresupuestoLin xLinea)
        {
            if (_Lineas == null)
            {
                _Lineas = new List<PresupuestoLin>();
            }
            PresupuestoLin P = _Lineas.Find((obj => obj.Articulo.CodArticulo == xLinea.Articulo.CodArticulo));
            if (P != null)
            {
                P.Cantidad += xLinea.Cantidad;
            }else
            {
                _Lineas.Add(xLinea);
            }
        }

        public object Popular()
        {
            DataTable _Tabla = new DataTable("ARTICULOS");

            DataColumn codigo = _Tabla.Columns.Add("CODIGO", Type.GetType("System.String"));
            DataColumn linea = _Tabla.Columns.Add("LINEA", Type.GetType("System.String"));
            DataColumn referencia = _Tabla.Columns.Add("REFERENCIA", Type.GetType("System.String"));
            DataColumn nombre = _Tabla.Columns.Add("NOMBRE", Type.GetType("System.String"));
            DataColumn cantidad = _Tabla.Columns.Add("CANTIDAD", Type.GetType("System.String"));
            DataColumn precio = _Tabla.Columns.Add("FINAL", Type.GetType("System.String"));


            DataRow RowAnteriorP;
            RowAnteriorP = _Tabla.NewRow();
            int Index = 1;
            foreach (PresupuestoLin M in _Lineas)
            {
                DataRow RM = _Tabla.NewRow();

                RM["CODIGO"] = M.Articulo.CodArticulo;
                RM["LINEA"] = Index;
                RM["REFERENCIA"] = M.Articulo.Referencia;
                RM["NOMBRE"] = M.Descripcion;
                RM["CANTIDAD"] = M.Cantidad;
                RM["FINAL"] = Estilos.FormatearImporte(M.Total());
                _Tabla.Rows.Add(RM);


            }
            return _Tabla;
        }

        public decimal Total()
        {
            decimal xSuma = 0;
            foreach (PresupuestoLin L in _Lineas)
                xSuma += L.Total();
            return xSuma;
        }

        public void CambiarPrecio(int xCodArticulo, decimal xPrecio)
        {
            if (_Lineas.Count > 0)
            {
                PresupuestoLin L = _Lineas.Find((obj => obj.Articulo.CodArticulo == xCodArticulo));
                if(L != null)
                {
                    L.Descuento = 0;
                    L.SubTotal = xPrecio / ((L.Iva / 100) + 1);
                }
                    
            }
        }

        public void CambiarCantidad(int xCodArticulo, decimal xCantidad)
        {
            if(_Lineas.Count   > 0)
            {
                PresupuestoLin L = _Lineas.Find((obj => obj.Articulo.CodArticulo == xCodArticulo));
                if (L != null)
                    L.Cantidad = xCantidad;
            }
            

        }

        public void BorrarLinea(int xCodArticulo, decimal xCantidad)
        {
            if (_Lineas.Count > 0)
            {
                PresupuestoLin L = _Lineas.Find((obj => obj.Articulo.CodArticulo == xCodArticulo && obj.Cantidad == xCantidad));
                if (L != null)
                    _Lineas.Remove(L);
            }
        }

        public void AsignarDescuento(decimal xPrecio)
        {
            foreach (PresupuestoLin L in _Lineas)
                L.Descuento = xPrecio;
        }
    }
}
