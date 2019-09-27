using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using JJ.Entidades;
using JJ.Reportes;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JJ.Reportes
{
    public static class GestionReporte
    {
        public static void ImprimirPrecio(DataTable xPrecios)
        {
            xPrecios.TableName = "dtPrecios";
            ReportDocument rptDoc;
            rptDoc = new Precios.rptPrintPrice();
            rptDoc.SetDataSource(xPrecios);
            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }

        public static void ImprimirArticulos(DataTable xArticulos)
        {
            xArticulos.TableName = "Articulos";
            ReportDocument rptDoc;
            rptDoc = new Articulos.rptArticulos();
            rptDoc.SetDataSource(xArticulos);
            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }

        public static void Presupuesto(DataTable xArticulos,int xDias,string xFormaPago,string dtoExtra)
        {
            xArticulos.TableName = "Presupuesto";
            ReportDocument rptDoc;
            rptDoc = new Presupuesto.rptPresupuesto();
            rptDoc.SetDataSource(xArticulos);
            TextObject Campo;

            Campo = (TextObject)rptDoc.ReportDefinition.ReportObjects["txtNumberDias"];
            Campo.Text = xDias.ToString();

            Campo = (TextObject)rptDoc.ReportDefinition.ReportObjects["dtoExtra"];
            Campo.Text = dtoExtra;


            Campo = (TextObject)rptDoc.ReportDefinition.ReportObjects["txtFormaPago"];
            Campo.Text = xFormaPago;
            


            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }

        public static void FacturaContado(VentaContado xobjF, decimal coti )
        {
            DataSet Factura = new DataSet();

            DataTable T = Factura.Tables.Add("Cabecera");
            DataTable T2 = Factura.Tables.Add("Contado");


            T.Columns.Add("RUT");
            T.Columns.Add("CLIENTE");
            T.Columns.Add("SUBTOTAL");
            T.Columns.Add("IVA");
            T.Columns.Add("TOTAL");
            T.Columns.Add("ADENDA");
            T.Columns.Add("DIRECCION");
            T.Columns.Add("FINAL");


            T2.Columns.Add("CODIGO");
            T2.Columns.Add("NOMBRE");
            T2.Columns.Add("CANTIDAD");
            T2.Columns.Add("PRECIO S/IVA");

            DataRow R;
            R = T.NewRow();
            R["RUT"] = xobjF.Cliente.Documento;
            R["DIRECCION"] = xobjF.Env_Direccion;
            R["ADENDA"] = xobjF.Detalle;
            R["CLIENTE"] = xobjF.Cliente.Nombre;
            R["SUBTOTAL"] =  Redondear(xobjF.Subtotal(1,coti));
            R["IVA"] = Redondear(xobjF.IvaTotal(1,coti));
            R["TOTAL"] = Redondear(xobjF.Subtotal(1,coti)+xobjF.IvaTotal(1,coti));
            R["DIRECCION"] = xobjF.Cliente.Direccion;

            if (xobjF.Cliente.Documento.Length < 11)
                R["FINAL"] = "X";



            if (xobjF.Env_Direccion != "")
            {
                R["ADENDA"] = "Serie: " + xobjF.Serie + " Numero: " + xobjF.Numero + "\n" + "Direccion Envio: " + xobjF.Env_Direccion + "\n" + "Comentarios: " + xobjF.Detalle;
             
            }
            else if (xobjF.Detalle!="")
            {
                R["ADENDA"] = "Serie: " + xobjF.Serie + " Numero: " + xobjF.Numero + "\n" +  "Comentarios: " + xobjF.Detalle;

            }else
            {
                R["ADENDA"] = "Serie: " + xobjF.Serie + " Numero: " + xobjF.Numero;
            }

          

            T.Rows.Add(R);

            DataRow R2;
            int Diferencia = (12 - xobjF.Lineas.Count);
            foreach(VentaLin l in xobjF.Lineas)
            {
                R2 = T2.NewRow();
                if (l.Articulo.CodMoneda == 2)
                {
                    R2["PRECIO S/IVA"] = Redondear(l.SubTotal()*coti);
                }
                else
                {
                    R2["PRECIO S/IVA"] = Redondear(l.SubTotal());
                }
                R2["CODIGO"] = l.Articulo.Referencia;
                R2["NOMBRE"] = l.Descripcion;
                R2["CANTIDAD"] = l.Cantidad;

                T2.Rows.Add(R2);


            }

            while (Diferencia > 0)
            {
                R2 = T2.NewRow();
                R2["CODIGO"] = string.Empty;
                R2["NOMBRE"] = string.Empty;
                R2["CANTIDAD"] = string.Empty;
                R2["PRECIO S/IVA"] = string.Empty;
                T2.Rows.Add(R2);
                Diferencia--;
            }





            ReportDocument rptDoc;
            rptDoc = new DiseñoFacturas.rptContado();
            //rptDoc = new DiseñoFacturas.rptDiseñoContado();
            //rptDoc.SetDataSource(xArticulos);
            rptDoc.SetDataSource(Factura);


            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
          
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }

        public static void ExportExcel(DataTable xData, string xDestino)
        {
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();
                int Index = 1;
                SLStyle style = sl.CreateStyle();
                style.Font.FontSize = 12;
                style.Font.FontColor = System.Drawing.Color.Black;
                style.Font.Bold = true;
                style.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                style.SetVerticalAlignment(VerticalAlignmentValues.Center);
                style.SetTopBorder(BorderStyleValues.DashDot, System.Drawing.Color.Blue);
                style.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Blue);
                sl.SetCellStyle(1, 1, style);

                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(Properties.Resources.LogoChico);
                byte[] ba;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Close();
                    ba = ms.ToArray();
                }

                //we need the image type because in byte array form, we don't know the type
                SLPicture pic = new SLPicture(ba, DocumentFormat.OpenXml.Packaging.ImagePartType.Png);
                pic.SetPosition(0, 0);
                sl.InsertPicture(pic);



                foreach (DataColumn DC in xData.Columns)
                {
                    sl.SetCellValue(8, Index, DC.ColumnName);
                    sl.SetCellStyle(8, Index, style);
                    sl.AutoFitColumn(Index);
                    Index += 1;
                }

                int IndexRow = 9;
                foreach (DataRow row in xData.Rows)
                {
                    foreach (DataColumn DC in xData.Columns)
                    {

                        switch (Type.GetTypeCode(row[DC.Ordinal].GetType()))
                        {
                            case TypeCode.Byte:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToByte(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.SByte:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToSByte(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.UInt16:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToUInt16(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.UInt32:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToUInt32(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.UInt64:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToUInt64(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.Int16:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToInt16(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.Int32:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToInt32(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.Int64:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToInt64(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.Decimal:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToDecimal(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.Double:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToDouble(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.Single:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, Convert.ToSingle(row[DC.Ordinal].ToString()));
                                break;
                            case TypeCode.String:
                                sl.SetCellValue(IndexRow, DC.Ordinal + 1, row[DC.Ordinal].ToString());
                                break;
                        }


                    }
                    IndexRow += 1;
                }
                sl.SetRowHeight(1, IndexRow, 20);

                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                if (xDestino == null)
                {
                    sl.SaveAs("C:/INFORMES/Informe.xlsx");
                }
                else
                {
                    sl.SaveAs(xDestino);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ImprimirPagos(DataSet xPagos)
        {
            ReportDocument rptDoc;
            rptDoc = new Diversos.rptPagos();
            rptDoc.SetDataSource(xPagos);
            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }

        public static void ImprimirCierre(DataTable xCierre)
        {

            ReportDocument rptDoc;
            rptDoc = new Diversos.rptCierre();
            rptDoc.SetDataSource(xCierre);
            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }
        public static decimal Redondear(decimal xvalor)
        {
            return decimal.Round(xvalor, 2);
        }

        public static void Ventas(DataTable xVentas, DateTime xFechaInicio, DateTime xFechaFinal)
        {
            xVentas.TableName = "Ventas";
            ReportDocument rptDoc;
            rptDoc = new Ventas.rptVentas();
            rptDoc.SetDataSource(xVentas);
            TextObject Campo;

            Campo = (TextObject)rptDoc.ReportDefinition.ReportObjects["txtPeriodo"];
            Campo.Text = "Periodo: " + xFechaInicio.ToShortDateString() + " hasta " + xFechaFinal.ToShortDateString();
                

            frmInforme frmReport = new frmInforme();
            CrystalReportViewer RP = (CrystalReportViewer)frmReport.Controls["RPViewer"];
            RP.ReportSource = rptDoc;
            frmReport.Show();
        }

    }

  
       
    
}
