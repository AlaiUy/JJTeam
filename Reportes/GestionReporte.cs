using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
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


    }
}
