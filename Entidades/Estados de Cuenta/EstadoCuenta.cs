using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public abstract class EstadoCuenta
    {
        
        List<object> _Movimientos;
        decimal _DeudaPesos = 0;
        decimal _DeudaDolares = 0;
        DateTime _Fecha;
        object _Pesos;
        object _Dolares;

        public object Pesos
        {
            get
            {
                return _Pesos;
            }
        }

        public object Dolares
        {
            get
            {
                return _Dolares;
            }
        }

        public decimal DeudaPesos
        {
            get
            {
                return _DeudaPesos;
            }
        }

        public decimal DeudaDolares
        {
            get
            {
                return _DeudaDolares;
            }
        }

        public EstadoCuenta(List<object> xMovimientos,DateTime xFecha)
        {
            _Fecha = xFecha;
            _Movimientos = xMovimientos;
            Movimientos();
        }

        public virtual List<object> Movimientos()
        {
            List<object> _Tablas = new List<object>();
            decimal SAP = 0; // Almaceno el saldo anterior
            decimal SAD = 0; // Almaceno el saldo anterior

            DataTable TablaP = new DataTable("MOVIMIENTOSP");
            DataColumn PesosFecha = TablaP.Columns.Add("FECHA", System.Type.GetType("System.String"));
            DataColumn PesosSerie = TablaP.Columns.Add("SERIE", Type.GetType("System.String"));
            DataColumn PesosNumero = TablaP.Columns.Add("NUMERO", Type.GetType("System.String"));
            DataColumn PesosImporte = TablaP.Columns.Add("IMPORTE", Type.GetType("System.String"));
            DataColumn PesosTotal = TablaP.Columns.Add("TOTAL", Type.GetType("System.String"));

            DataTable TablaD = new DataTable("MOVIMIENTOSD");
            DataColumn DolaresFecha = TablaD.Columns.Add("FECHA", System.Type.GetType("System.String"));
            DataColumn DolaresSerie = TablaD.Columns.Add("SERIE", Type.GetType("System.String"));
            DataColumn DolaresNumero = TablaD.Columns.Add("NUMERO", Type.GetType("System.String"));
            DataColumn DolaresImporte = TablaD.Columns.Add("IMPORTE", Type.GetType("System.String"));
            DataColumn DolaresTotal = TablaD.Columns.Add("TOTAL", Type.GetType("System.String"));

            DataRow RowAnteriorP;
            RowAnteriorP = TablaP.NewRow();

            DataRow RowAnteriorD;
            RowAnteriorD = TablaD.NewRow();

            RowAnteriorP["SERIE"] = "SALDO ANTERIOR...";
            RowAnteriorP["TOTAL"] = 0;

            RowAnteriorD["SERIE"] = "SALDO ANTERIOR...";
            RowAnteriorD["TOTAL"] = 0;

            TablaD.Rows.Add(RowAnteriorD);
            TablaP.Rows.Add(RowAnteriorP);


            foreach (Movimiento M in _Movimientos)
            {
                if (M.Fecha < _Fecha)
                {
                    if(M.Moneda == 1)
                    {
                        SAP += M.Importe;
                        _DeudaPesos += M.Importe;
                    }
                    else
                    {
                        SAD += M.Importe;
                        _DeudaDolares += M.Importe;
                    }
                    
                }else
                {
                    if (M.Moneda == 1)
                    {
                        DataRow RM = TablaP.NewRow();
                        _DeudaPesos += M.Importe;
                        RM["FECHA"] = M.Fecha.ToString("dd/MM/yyyy");
                        RM["SERIE"] = M.SerieInterna;
                        RM["NUMERO"] = M.NumeroInterno;
                        RM["IMPORTE"] = M.Importe;
                        RM["TOTAL"] = _DeudaPesos;
                        TablaP.Rows.Add(RM);
                    }
                    else
                    {
                        _DeudaDolares += M.Importe;
                        DataRow RM = TablaD.NewRow();
                        RM["FECHA"] = M.Fecha.ToString("dd/MM/yyyy");
                        RM["SERIE"] = M.SerieInterna;
                        RM["NUMERO"] = M.NumeroInterno;
                        RM["IMPORTE"] = M.Importe;
                        RM["TOTAL"] = _DeudaDolares;
                        TablaD.Rows.Add(RM);
                    }

                }
            }
            _DeudaDolares += SAD;
            _DeudaPesos += SAP;
            TablaD.Rows[0].SetField("TOTAL",SAD);
            TablaP.Rows[0].SetField("TOTAL", SAP);
            _Pesos = TablaP;
            _Dolares = TablaD;
            _Tablas.Add(TablaP);
            _Tablas.Add(TablaD);
            return _Tablas;
        }

        
      
    }
}
