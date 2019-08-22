using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using JJ.Reportes;
using SpreadsheetLight;
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

        public static void ExportExcel(DataTable xData, string xDestino)
        {
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda

                int Index = 1;
                SLStyle style = sl.CreateStyle();
                style.Font.FontSize = 12;
                style.Font.FontColor = System.Drawing.Color.Black;
                style.Font.Bold = true;
                style.SetTopBorder(BorderStyleValues.DashDot, System.Drawing.Color.Blue);
                style.SetBottomBorder(BorderStyleValues.DashDot, System.Drawing.Color.Blue);
                sl.SetCellStyle(1, 1, style);
                foreach (DataColumn DC in xData.Columns)
                {
                    sl.SetCellValue(1, Index, DC.ColumnName);
                    sl.SetCellStyle(1, Index, style);
                    Index += 1;
                }

                

               

                int IndexRow = 2;
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
                        
                        style = sl.CreateStyle();
                        style.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
                       
                    }
                    IndexRow += 1;
                }
                
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                if (xDestino == null)
                {
                    sl.SaveAs("C:/INFORMES/inco.xlsx");
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


    }
}
