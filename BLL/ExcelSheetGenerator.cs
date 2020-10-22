using System;
using System.Web;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Globalization;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.IO;
using BusinessEntities;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml.Packaging;
//using Spire.Xls;

//using Microsoft.Office.Interop.Excel;
public class ExcelSheetGenerator
{
    public string strCompanyName = "Examity";
    public bool boolAutofilter = true;
    public string strReportComments = "Examity ";

    protected BEExcelStyles GetExcelStyles()
    {
        BEExcelStyles objBEExcelStyles = new BEExcelStyles();
        objBEExcelStyles.intHeader_BackGround_Red = 247;
        objBEExcelStyles.intHeader_BackGround_Green = 150;
        objBEExcelStyles.intHeader_BackGround_Blue = 70;
        objBEExcelStyles.intHeader_ForeGround_Red = 255;
        objBEExcelStyles.intHeader_ForeGround_Green = 255;
        objBEExcelStyles.intHeader_ForeGround_Blue = 255;
        objBEExcelStyles.intStyle_BackGround_Red = 255;
        objBEExcelStyles.intStyle_BackGround_Green = 255;
        objBEExcelStyles.intStyle_BackGround_Blue = 255;
        objBEExcelStyles.intStyle_ForeGround_Red = 0;
        objBEExcelStyles.intStyle_ForeGround_Green = 0;
        objBEExcelStyles.intStyle_ForeGround_Blue = 0;
        objBEExcelStyles.intAltStyle_BackGround_Red = 255;
        objBEExcelStyles.intAltStyle_BackGround_Green = 255;
        objBEExcelStyles.intAltStyle_BackGround_Blue = 255;
        objBEExcelStyles.intAltStyle_ForeGround_Red = 0;
        objBEExcelStyles.intAltStyle_ForeGround_Green = 0;
        objBEExcelStyles.intAltStyle_ForeGround_Blue = 0;
        return objBEExcelStyles;
    }

    public void GenerateReport(DataTable objDt, System.IO.FileInfo rptFileName, string strReportName, string strUserName)
    {
        BEExcelStyles objBEExcelStyles = GetExcelStyles();

        using (ExcelPackage package = new ExcelPackage(rptFileName))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strReportName);

            int intRowCount = 1;
            int intColCount = 0;
            int intMaxColCount = 1;

            #region HeaderColumns
            //Adding Header to WorkSheet : Start
            foreach (DataColumn objDC in objDt.Columns)
            {
                intColCount++;


                worksheet.Cells[intRowCount, intColCount].Value = objDC.ColumnName;



            }
            //Adding Header to WorkSheet : End
            #endregion
            //worksheet.Column(8).Style.Numberformat.Format = @"dd MMM yyyy hh:mm";

            #region AddingDataToSheet
            intMaxColCount = intColCount;
            for (int i = 0; i < objDt.Rows.Count; i++)
            {
                intRowCount++;
                for (int j = 0; j < intMaxColCount; j++)
                {

                    //worksheet.Cells[1, 8].Style.Numberformat.Format = @"dd MMM yyyy hh:mm";
                    //worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                    string objDataType = objDt.Rows[i][j].GetType().ToString();
                    //Add text to text cell
                    if (objDataType.Contains(TypeCode.Int32.ToString()) || objDataType.Contains(TypeCode.Int64.ToString()))
                    {

                        worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                    }
                    else if (objDataType.Contains(TypeCode.DateTime.ToString()))
                    {
                        //worksheet.Column(j + 1).Style.Numberformat.Format= "m/d/yyyy h:mm";
                        //string date = objDt.Rows[i][j].ToString();
                        //worksheet.Cells[intRowCount, j + 1].Value = date;  

                        DateTime dt1 = Convert.ToDateTime(objDt.Rows[i][j].ToString());
                        var date = "";
                        if (strReportName == "Exams list Report ")
                        {
                            if (objDt.Columns.Contains("Client Name"))
                            {

                                //  bool isNotEST = Convert.ToBoolean(objDt.Rows[i]["isNotEST"].ToString());

                                if (objDt.Rows[i]["Client Name"].ToString() == "Patten University" || objDt.Rows[i]["Client Name"].ToString() == "New Charter University")
                                {
                                    date = string.Format("{0:MM/dd/yyyy }", dt1);
                                }
                                else
                                {
                                    date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                                }
                            }
                        }
                        else if (strReportName == "Exams timestamp_ report")
                        {
                            if (objDt.Columns.Contains("Exam Time(EST)"))
                            {
                                if (objDt.Columns[j].ColumnName == "Exam Time(EST)")
                                {
                                    date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                                }
                                else
                                {
                                    date = string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", dt1);
                                }
                            }
                            else
                            {
                                date = string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", dt1);
                            }
                        }
                        else if (strReportName == "Dormant Report")
                        {
                            date = string.Format("{0:MM/dd/yyyy}", dt1);
                        }
                        else if (strReportName == "Launch Time Report")
                        {
                            date = string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", dt1);
                        }
                        else
                        {
                            date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                        }
                        worksheet.Cells[intRowCount, j + 1].Value = date;

                        // worksheet.Column(j + 1).Style.Numberformat.Format = "MM/dd/yyyy HH:mm";

                    }
                    else if (objDataType.Contains(TypeCode.Decimal.ToString()))
                    {

                        if (objDt.Columns[j].ColumnName == "ExamFee (Paid by Student)" || objDt.Columns[j].ColumnName == "On-demandFee (Paid by Student)" || objDt.Columns[j].ColumnName == "ExamFee (Billed to University)" || objDt.Columns[j].ColumnName == "On-demandFee (Paid by University)" || objDt.Columns[j].ColumnName == "Total Fee (Billed to University)" || objDt.Columns[j].ColumnName == "Revenue for Examity" ||
                            objDt.Columns[j].ColumnName == "University Pay" || objDt.Columns[j].ColumnName == "Credit card payments" || objDt.Columns[j].ColumnName == "Level 0" || objDt.Columns[j].ColumnName == "Level 1" || objDt.Columns[j].ColumnName == "Level 2" || objDt.Columns[j].ColumnName == "Level 3" || objDt.Columns[j].ColumnName == "Exam Fee" || objDt.Columns[j].ColumnName == "On-demand fee"
                           || objDt.Columns[j].ColumnName == "Exam Payment Amount Received" || objDt.Columns[j].ColumnName == "Proctor Fees" || objDt.Columns[j].ColumnName == "Amount Due to Compuware" || objDt.Columns[j].ColumnName == "Amount Due to Examity")
                        {
                            decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);
                            worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                            worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "$ #,##0.00";
                        }
                        else if (strReportName == "Revenue Report" && objDt.Columns[j].ColumnName == "Total")
                        {
                            decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);
                            worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                            worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "$ #,##0.00";
                        }
                        else
                        {
                            decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);

                            worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                            worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "#,##0.00";
                        }


                    }

                    else
                    {

                        worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];


                    }

                }



            }
            worksheet.Cells[1, 8].Style.Numberformat.Format = "mm/dd/yyyy";

            #endregion
            #region HeaderStyles
            //Header Style Settings : Start

            using (var range = worksheet.Cells[1, 1, 1, intMaxColCount])
            {
                // Setting bold font
                range.Style.Font.Bold = true;
                // Setting fill type solid
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // Setting background System.Drawing.Color dark blue
                //  range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intHeader_BackGround_Red, objBEExcelStyles.intHeader_BackGround_Green, objBEExcelStyles.intHeader_BackGround_Blue));
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);
                // Setting font color
                range.Style.Font.Color.SetColor(System.Drawing.Color.Black);
            }
            //Header Style Settings : End
            #endregion
            #region RowStyle
            //Row Style Settings : Start
            for (int i = 2; i < intRowCount + 1; i = i + 2)
            {
                // Formatting style of the header
                using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Font.Bold = false;
                    // Setting fill type solid
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    // Setting background color dark blue
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_BackGround_Red, objBEExcelStyles.intStyle_BackGround_Green, objBEExcelStyles.intStyle_BackGround_Blue));
                    // Setting font color
                    range.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_ForeGround_Red, objBEExcelStyles.intStyle_ForeGround_Green, objBEExcelStyles.intStyle_ForeGround_Blue));

                }
            }
            //Row Style Settings : End
            #endregion



            #region AltRowStyle
            //AltRow Style Settings : Start
            for (int i = 3; i < intRowCount + 1; i = i + 2)
            {
                // Formatting style of the header
                using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Font.Bold = false;
                    // Setting fill type solid
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    // Setting background color dark blue
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_BackGround_Red, objBEExcelStyles.intAltStyle_BackGround_Green, objBEExcelStyles.intAltStyle_BackGround_Blue));
                    // Setting font color
                    range.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intAltStyle_ForeGround_Red, objBEExcelStyles.intAltStyle_ForeGround_Green, objBEExcelStyles.intAltStyle_ForeGround_Blue));
                    //range.Style.Border.Top.Style = range.Style.Border.Left.Style = range.Style.Border.Right.Style = range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                }
            }
            //AltRow Style Settings : End
            #endregion
            //worksheet("A1").Errors(xlEmptyCellReferences).Ignore = True

            for (int i = 1; i < intRowCount + 1; i = i + 1)
            {
                // Formatting style of the header
                using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Border.Top.Style = range.Style.Border.Left.Style = range.Style.Border.Right.Style = range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    //   worksheet.ConditionalFormatting.AddNotContainsErrors(range);
                    worksheet.ConditionalFormatting.AddNotContainsErrors(range);
                    range.Style.Font.Size = 14;


                    //Change the NumberFormat from '' to 'Text'
                    //  range.Style.Numberformat.Format = "0";


                }
            }


            //  Range cell = ActiveWorksheet.Cells[1, 1];
            //The @ is the indicator for Excel, that the content should be text



            //var cell = worksheet.Cells[rowIndex, colIndex];

            ////Setting top,left,right,bottom border of header cells
            //var border = cell.Style.Border;
            //border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            if (objDt.Columns.Contains("Client Name"))
            {
                if (objDt.Rows[0]["Client Name"].ToString() == "New York University")
                {
                    if (objDt.Columns.Contains("Certification fee (Student)"))
                    {
                        decimal strcerfee = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["Certification fee (Student)"].ToString());
                        decimal strprocefee = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["Total Fee"].ToString());

                        decimal ExamFeeStudent = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["ExamFee (Student)"].ToString());
                        decimal OndemandFeeStudent = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["On-demandFee (Student)"].ToString());
                        decimal Proctoringchargespaidbystudent = ExamFeeStudent + OndemandFeeStudent;

                        decimal ExamFeeUniversity = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["ExamFee (University)"].ToString());
                        decimal OndemandFeeUniversity = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["On-demandFee (University)"].ToString());
                        decimal ProctoringchargespaidbyUniversity = ExamFeeUniversity + OndemandFeeUniversity;

                        decimal ProcessingfeeUniversity = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["Processing fee (University)"].ToString());



                        worksheet.Cells[objDt.Rows.Count + 3, 18].Value = "Certification fee paid by student";
                        worksheet.Cells[objDt.Rows.Count + 4, 18].Value = "Proctoring charges paid by student";
                        worksheet.Cells[objDt.Rows.Count + 5, 18].Value = "Proctoring charges paid by University";
                        worksheet.Cells[objDt.Rows.Count + 6, 18].Value = "Processing fee paid by university (15%)";
                        worksheet.Cells[objDt.Rows.Count + 7, 18].Value = "Amount owed to University";


                        worksheet.Cells[objDt.Rows.Count + 3, 19].Value = strcerfee;
                        worksheet.Cells[objDt.Rows.Count + 3, 19].Style.Numberformat.Format = "$ #,##0.00";

                        worksheet.Cells[objDt.Rows.Count + 4, 19].Value = Proctoringchargespaidbystudent;
                        worksheet.Cells[objDt.Rows.Count + 4, 19].Style.Numberformat.Format = "$ #,##0.00";

                        worksheet.Cells[objDt.Rows.Count + 5, 19].Value = ProctoringchargespaidbyUniversity;
                        worksheet.Cells[objDt.Rows.Count + 5, 19].Style.Numberformat.Format = "$ #,##0.00";

                        worksheet.Cells[objDt.Rows.Count + 6, 19].Value = ProcessingfeeUniversity;
                        worksheet.Cells[objDt.Rows.Count + 6, 19].Style.Numberformat.Format = "$ #,##0.00";

                        decimal TotalValue = strcerfee - ProctoringchargespaidbyUniversity - ProcessingfeeUniversity;
                        worksheet.Cells[objDt.Rows.Count + 7, 19].Value = TotalValue;
                        worksheet.Cells[objDt.Rows.Count + 7, 19].Style.Numberformat.Format = "$ #,##0.00";
                    }

                    #region SetAutoFilter
                    worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


                    #endregion
                    #region FooterRowLineSettings
                    //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
                    // Formatting the footer row
                    // Setting top border of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    // Setting font bold of the footer row
                    //worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Font.Bold = true;
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 5, intColCount].Style.Font.Size = 14;

                    // Setting font bold of the footer row
                    worksheet.Cells[intRowCount + 6, 1, intRowCount + 6, intColCount].Style.Font.Bold = true;


                    worksheet.Cells[intRowCount + 6, 1, intRowCount + 6, intColCount].Style.Font.Size = 16;
                    #endregion
                    #region RightEndRowLineSettings
                    // Formatting the Right end row
                    // Setting top border of the Right end row
                    worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    #endregion

                }
                else
                {
                    #region SetAutoFilter
                    worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


                    #endregion
                    #region FooterRowLineSettings
                    //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
                    // Formatting the footer row
                    // Setting top border of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    // Setting font bold of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Font.Bold = true;

                    // Setting font bold of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Bold = true;


                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Size = 16;
                    #endregion
                    #region RightEndRowLineSettings
                    // Formatting the Right end row
                    // Setting top border of the Right end row
                    worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    #endregion
                }

            }
            else
            {
                #region SetAutoFilter
                worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


                #endregion
                #region FooterRowLineSettings
                //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
                // Formatting the footer row
                // Setting top border of the footer row
                worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                // Setting font bold of the footer row
                worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Font.Bold = true;

                // Setting font bold of the footer row
                worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Bold = true;


                worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Size = 16;
                #endregion
                #region RightEndRowLineSettings
                // Formatting the Right end row
                // Setting top border of the Right end row
                worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                #endregion
            }
            #region OtherSettings
            worksheet.Cells.AutoFitColumns();
            worksheet.View.PageLayoutView = true;
            worksheet.View.FreezePanes(2, 1);

            #endregion



            // Setting some document properties
            package.Workbook.Properties.Title = strReportName;
            package.Workbook.Properties.Author = strUserName;
            package.Workbook.Properties.Comments = strReportComments;
            package.Workbook.Properties.Company = strCompanyName;
            package.Workbook.Properties.SetCustomPropertyValue("Checked by", strUserName);
            package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");



            // Switch the page layout view back to the normal
            worksheet.View.PageLayoutView = false;
            // Save our new workbook, we are done
            package.Save();



        }
    }

    public void GenerateReport(DataSet objDS, System.IO.FileInfo rptFileName, string strReportName, string strUserName)
    {
        DataTable objDt = objDS.Tables[0];

        BEExcelStyles objBEExcelStyles = GetExcelStyles();

        using (ExcelPackage package = new ExcelPackage(rptFileName))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strReportName);

            int intRowCount = 1;
            int intColCount = 0;
            int intMaxColCount = 1;

            #region HeaderColumns
            //Adding Header to WorkSheet : Start
            foreach (DataColumn objDC in objDt.Columns)
            {
                intColCount++;


                worksheet.Cells[intRowCount, intColCount].Value = objDC.ColumnName;



            }
            //Adding Header to WorkSheet : End
            #endregion
            //worksheet.Column(8).Style.Numberformat.Format = @"dd MMM yyyy hh:mm";

            #region AddingDataToSheet
            intMaxColCount = intColCount;
            for (int i = 0; i < objDt.Rows.Count; i++)
            {
                intRowCount++;
                for (int j = 0; j < intMaxColCount; j++)
                {

                    //worksheet.Cells[1, 8].Style.Numberformat.Format = @"dd MMM yyyy hh:mm";
                    //worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                    string objDataType = objDt.Rows[i][j].GetType().ToString();
                    //Add text to text cell
                    if (objDataType.Contains(TypeCode.Int32.ToString()) || objDataType.Contains(TypeCode.Int64.ToString()))
                    {
                        worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                    }
                    else if (objDataType.Contains(TypeCode.DateTime.ToString()))
                    {
                        //worksheet.Column(j + 1).Style.Numberformat.Format= "m/d/yyyy h:mm";
                        //string date = objDt.Rows[i][j].ToString();
                        //worksheet.Cells[intRowCount, j + 1].Value = date;  

                        DateTime dt1 = Convert.ToDateTime(objDt.Rows[i][j].ToString());
                        var date = "";
                        date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                        worksheet.Cells[intRowCount, j + 1].Value = date;

                    }
                    else if (objDataType.Contains(TypeCode.Decimal.ToString()))
                    {
                        if (objDt.Columns[j].ColumnName == "Exam Payment Amount Received" || objDt.Columns[j].ColumnName == "Proctor Fees" || objDt.Columns[j].ColumnName == "Processing Charges" || objDt.Columns[j].ColumnName == "Amount Due to Compuware" || objDt.Columns[j].ColumnName == "Amount Due to Examity")
                        {
                            decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);
                            worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                            worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "$ #,##0.00";

                        }
                        else
                        {
                            decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);
                            worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                            worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "#,##0.00";
                        }
                    }
                    else
                    {
                        worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                    }
                }
            }
            worksheet.Cells[1, 8].Style.Numberformat.Format = "mm/dd/yyyy";

            #endregion
            #region HeaderStyles
            //Header Style Settings : Start

            using (var range = worksheet.Cells[1, 1, 1, intMaxColCount])
            {
                // Setting bold font
                range.Style.Font.Bold = true;
                // Setting fill type solid
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // Setting background System.Drawing.Color dark blue
                //  range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intHeader_BackGround_Red, objBEExcelStyles.intHeader_BackGround_Green, objBEExcelStyles.intHeader_BackGround_Blue));
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);
                // Setting font color
                range.Style.Font.Color.SetColor(System.Drawing.Color.Black);
            }
            //Header Style Settings : End
            #endregion
            #region RowStyle
            //Row Style Settings : Start
            for (int i = 2; i < intRowCount + 1; i = i + 2)
            {
                // Formatting style of the header
                using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Font.Bold = false;
                    // Setting fill type solid
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    // Setting background color dark blue
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_BackGround_Red, objBEExcelStyles.intStyle_BackGround_Green, objBEExcelStyles.intStyle_BackGround_Blue));
                    // Setting font color
                    range.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_ForeGround_Red, objBEExcelStyles.intStyle_ForeGround_Green, objBEExcelStyles.intStyle_ForeGround_Blue));

                }
            }
            //Row Style Settings : End
            #endregion



            #region AltRowStyle
            //AltRow Style Settings : Start
            for (int i = 3; i < intRowCount + 1; i = i + 2)
            {
                // Formatting style of the header
                using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Font.Bold = false;
                    // Setting fill type solid
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    // Setting background color dark blue
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_BackGround_Red, objBEExcelStyles.intAltStyle_BackGround_Green, objBEExcelStyles.intAltStyle_BackGround_Blue));
                    // Setting font color
                    range.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intAltStyle_ForeGround_Red, objBEExcelStyles.intAltStyle_ForeGround_Green, objBEExcelStyles.intAltStyle_ForeGround_Blue));
                    //range.Style.Border.Top.Style = range.Style.Border.Left.Style = range.Style.Border.Right.Style = range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                }
            }
            //AltRow Style Settings : End
            #endregion
            //worksheet("A1").Errors(xlEmptyCellReferences).Ignore = True

            for (int i = 1; i < intRowCount + 1; i = i + 1)
            {
                // Formatting style of the header
                using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Border.Top.Style = range.Style.Border.Left.Style = range.Style.Border.Right.Style = range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    //   worksheet.ConditionalFormatting.AddNotContainsErrors(range);
                    worksheet.ConditionalFormatting.AddNotContainsErrors(range);
                    range.Style.Font.Size = 14;


                    //Change the NumberFormat from '' to 'Text'
                    //  range.Style.Numberformat.Format = "0";


                }
            }
            if (objDS.Tables[0].Columns.Contains("Date created (EST)") && objDS.Tables[1].Columns.Contains("AmountDuetoCompuware"))
            {
                decimal AmountDuetoCompuware = decimal.Parse(objDS.Tables[1].Rows[0]["AmountDuetoCompuware"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 2, 19].Value = AmountDuetoCompuware;
                worksheet.Cells[objDt.Rows.Count + 2, 19].Style.Numberformat.Format = "$ #,##0.00";

                decimal AmountDuetoExamity = decimal.Parse(objDS.Tables[1].Rows[0]["AmountDuetoExamity"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 2, 20].Value = AmountDuetoExamity;
                worksheet.Cells[objDt.Rows.Count + 2, 20].Style.Numberformat.Format = "$ #,##0.00";

                worksheet.Cells[objDt.Rows.Count + 4, 19].Value = objDS.Tables[1].Rows[0]["TotalText"].ToString();

                decimal TotalValue = decimal.Parse(objDS.Tables[1].Rows[0]["TotalValue"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 4, 20].Value = TotalValue;
                worksheet.Cells[objDt.Rows.Count + 4, 20].Style.Numberformat.Format = "$ #,##0.00";
            }
            else if (objDS.Tables[1].Columns.Contains("AmountDuetoCompuware"))
            {
                decimal AmountDuetoCompuware = decimal.Parse(objDS.Tables[1].Rows[0]["AmountDuetoCompuware"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 2, 18].Value = AmountDuetoCompuware;
                worksheet.Cells[objDt.Rows.Count + 2, 18].Style.Numberformat.Format = "$ #,##0.00";

                decimal AmountDuetoExamity = decimal.Parse(objDS.Tables[1].Rows[0]["AmountDuetoExamity"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 2, 19].Value = AmountDuetoExamity;
                worksheet.Cells[objDt.Rows.Count + 2, 19].Style.Numberformat.Format = "$ #,##0.00";

                worksheet.Cells[objDt.Rows.Count + 4, 18].Value = objDS.Tables[1].Rows[0]["TotalText"].ToString();

                decimal TotalValue = decimal.Parse(objDS.Tables[1].Rows[0]["TotalValue"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 4, 19].Value = TotalValue;
                worksheet.Cells[objDt.Rows.Count + 4, 19].Style.Numberformat.Format = "$ #,##0.00";
            }
            else if (objDS.Tables[1].Columns.Contains("AmountDuetoNyu"))
            {
                decimal AmountDuetoCompuware = decimal.Parse(objDS.Tables[1].Rows[0]["AmountDuetoNyu"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 2, 15].Value = AmountDuetoCompuware;
                worksheet.Cells[objDt.Rows.Count + 2, 15].Style.Numberformat.Format = "$ #,##0.00";

                decimal AmountDuetoExamity = decimal.Parse(objDS.Tables[1].Rows[0]["AmountDuetoExamity"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 2, 16].Value = AmountDuetoExamity;
                worksheet.Cells[objDt.Rows.Count + 2, 16].Style.Numberformat.Format = "$ #,##0.00";

                worksheet.Cells[objDt.Rows.Count + 4, 15].Value = objDS.Tables[1].Rows[0]["TotalText"].ToString();

                decimal TotalValue = decimal.Parse(objDS.Tables[1].Rows[0]["TotalValue"].ToString(), CultureInfo.CurrentCulture);
                worksheet.Cells[objDt.Rows.Count + 4, 16].Value = TotalValue;
                worksheet.Cells[objDt.Rows.Count + 4, 16].Style.Numberformat.Format = "$ #,##0.00";
            }



            #region SetAutoFilter
            worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


            #endregion
            #region FooterRowLineSettings
            //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
            // Formatting the footer row
            // Setting top border of the footer row
            worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            // Setting font bold of the footer row
            worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Bold = true;


            worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Size = 16;
            // Setting font bold of the footer row

            #endregion
            #region RightEndRowLineSettings
            // Formatting the Right end row
            // Setting top border of the Right end row
            worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            #endregion
            #region OtherSettings
            worksheet.Cells.AutoFitColumns();
            worksheet.View.PageLayoutView = true;
            worksheet.View.FreezePanes(2, 1);

            #endregion



            // Setting some document properties
            package.Workbook.Properties.Title = strReportName;
            package.Workbook.Properties.Author = strUserName;
            package.Workbook.Properties.Comments = strReportComments;
            package.Workbook.Properties.Company = strCompanyName;
            package.Workbook.Properties.SetCustomPropertyValue("Checked by", strUserName);
            package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");



            // Switch the page layout view back to the normal
            worksheet.View.PageLayoutView = false;
            // Save our new workbook, we are done
            package.Save();



        }
    }

    public void GenerateReport(DataSet objDS, System.IO.FileInfo rptFileName, string strReportName, string strUserName, bool issheet)
    {
        BEExcelStyles objBEExcelStyles = GetExcelStyles();

        using (ExcelPackage package = new ExcelPackage(rptFileName))
        {
            foreach (DataTable objDt in objDS.Tables)
            {
                strReportName = objDt.Columns[1].ColumnName;
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strReportName);

                int intRowCount = 1;
                int intColCount = 0;
                int intMaxColCount = 1;

                #region HeaderColumns
                //Adding Header to WorkSheet : Start
                foreach (DataColumn objDC in objDt.Columns)
                {
                    intColCount++;


                    worksheet.Cells[intRowCount, intColCount].Value = objDC.ColumnName;



                }
                //Adding Header to WorkSheet : End
                #endregion
                //worksheet.Column(8).Style.Numberformat.Format = @"dd MMM yyyy hh:mm";

                #region AddingDataToSheet
                intMaxColCount = intColCount;
                for (int i = 0; i < objDt.Rows.Count; i++)
                {
                    intRowCount++;
                    for (int j = 0; j < intMaxColCount; j++)
                    {

                        //worksheet.Cells[1, 8].Style.Numberformat.Format = @"dd MMM yyyy hh:mm";
                        //worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                        string objDataType = objDt.Rows[i][j].GetType().ToString();
                        //Add text to text cell
                        if (objDataType.Contains(TypeCode.Int32.ToString()) || objDataType.Contains(TypeCode.Int64.ToString()))
                        {

                            worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];
                        }
                        else if (objDataType.Contains(TypeCode.DateTime.ToString()))
                        {
                            //worksheet.Column(j + 1).Style.Numberformat.Format= "m/d/yyyy h:mm";
                            //string date = objDt.Rows[i][j].ToString();
                            //worksheet.Cells[intRowCount, j + 1].Value = date;  

                            DateTime dt1 = Convert.ToDateTime(objDt.Rows[i][j].ToString());
                            var date = "";
                            if (strReportName == "Exams list Report ")
                            {
                                if (objDt.Columns.Contains("Client Name"))
                                {

                                    //  bool isNotEST = Convert.ToBoolean(objDt.Rows[i]["isNotEST"].ToString());

                                    if (objDt.Rows[i]["Client Name"].ToString() == "Patten University" || objDt.Rows[i]["Client Name"].ToString() == "New Charter University")
                                    {
                                        date = string.Format("{0:MM/dd/yyyy }", dt1);
                                    }
                                    else
                                    {
                                        date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                                    }
                                }
                            }
                            else if (strReportName == "Exams timestamp_ report")
                            {
                                if (objDt.Columns.Contains("Exam Time(EST)"))
                                {
                                    if (objDt.Columns[j].ColumnName == "Exam Time(EST)")
                                    {
                                        date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                                    }
                                    else
                                    {
                                        date = string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", dt1);
                                    }
                                }
                                else
                                {
                                    date = string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", dt1);
                                }
                            }
                            else if (strReportName == "Dormant Report")
                            {
                                date = string.Format("{0:MM/dd/yyyy}", dt1);
                            }
                            else
                            {
                                date = string.Format("{0:MM/dd/yyyy hh:mm tt}", dt1);
                            }
                            worksheet.Cells[intRowCount, j + 1].Value = date;

                            // worksheet.Column(j + 1).Style.Numberformat.Format = "MM/dd/yyyy HH:mm";

                        }
                        else if (objDataType.Contains(TypeCode.Decimal.ToString()))
                        {

                            if (objDt.Columns[j].ColumnName == "ExamFee (Paid by Student)" || objDt.Columns[j].ColumnName == "On-demandFee (Paid by Student)" || objDt.Columns[j].ColumnName == "ExamFee (Billed to University)" || objDt.Columns[j].ColumnName == "On-demandFee (Paid by University)" || objDt.Columns[j].ColumnName == "Total Fee (Billed to University)" || objDt.Columns[j].ColumnName == "Revenue for Examity" ||
                                objDt.Columns[j].ColumnName == "University Pay" || objDt.Columns[j].ColumnName == "Credit card payments" || objDt.Columns[j].ColumnName == "Level 0" || objDt.Columns[j].ColumnName == "Level 1" || objDt.Columns[j].ColumnName == "Level 2" || objDt.Columns[j].ColumnName == "Level 3" || objDt.Columns[j].ColumnName == "Exam Fee" || objDt.Columns[j].ColumnName == "On-demand fee"
                               || objDt.Columns[j].ColumnName == "Exam Payment Amount Received" || objDt.Columns[j].ColumnName == "Proctor Fees" || objDt.Columns[j].ColumnName == "Amount Due to Compuware" || objDt.Columns[j].ColumnName == "Amount Due to Examity")
                            {
                                decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);
                                worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                                worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "$ #,##0.00";
                            }
                            else if (strReportName == "Revenue Report" && objDt.Columns[j].ColumnName == "Total")
                            {
                                decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);
                                worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                                worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "$ #,##0.00";
                            }
                            else
                            {
                                decimal decimalvalue = decimal.Parse(objDt.Rows[i][j].ToString(), CultureInfo.CurrentCulture);

                                worksheet.Cells[intRowCount, j + 1].Value = decimalvalue;
                                worksheet.Cells[intRowCount, j + 1].Style.Numberformat.Format = "#,##0.00";
                            }


                        }

                        else
                        {

                            worksheet.Cells[intRowCount, j + 1].Value = objDt.Rows[i][j];


                        }

                    }



                }
                worksheet.Cells[1, 8].Style.Numberformat.Format = "mm/dd/yyyy";

                #endregion
                #region HeaderStyles
                //Header Style Settings : Start

                using (var range = worksheet.Cells[1, 1, 1, intMaxColCount])
                {
                    // Setting bold font
                    range.Style.Font.Bold = true;
                    // Setting fill type solid
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    // Setting background System.Drawing.Color dark blue
                    //  range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intHeader_BackGround_Red, objBEExcelStyles.intHeader_BackGround_Green, objBEExcelStyles.intHeader_BackGround_Blue));
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);
                    // Setting font color
                    range.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                }
                //Header Style Settings : End
                #endregion
                #region RowStyle
                //Row Style Settings : Start
                for (int i = 2; i < intRowCount + 1; i = i + 2)
                {
                    // Formatting style of the header
                    using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                    {
                        // Setting bold font
                        range.Style.Font.Bold = false;
                        // Setting fill type solid
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        // Setting background color dark blue
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_BackGround_Red, objBEExcelStyles.intStyle_BackGround_Green, objBEExcelStyles.intStyle_BackGround_Blue));
                        // Setting font color
                        range.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_ForeGround_Red, objBEExcelStyles.intStyle_ForeGround_Green, objBEExcelStyles.intStyle_ForeGround_Blue));

                    }
                }
                //Row Style Settings : End
                #endregion



                #region AltRowStyle
                //AltRow Style Settings : Start
                for (int i = 3; i < intRowCount + 1; i = i + 2)
                {
                    // Formatting style of the header
                    using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                    {
                        // Setting bold font
                        range.Style.Font.Bold = false;
                        // Setting fill type solid
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        // Setting background color dark blue
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intStyle_BackGround_Red, objBEExcelStyles.intAltStyle_BackGround_Green, objBEExcelStyles.intAltStyle_BackGround_Blue));
                        // Setting font color
                        range.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(objBEExcelStyles.intAltStyle_ForeGround_Red, objBEExcelStyles.intAltStyle_ForeGround_Green, objBEExcelStyles.intAltStyle_ForeGround_Blue));
                        //range.Style.Border.Top.Style = range.Style.Border.Left.Style = range.Style.Border.Right.Style = range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    }
                }
                //AltRow Style Settings : End
                #endregion
                //worksheet("A1").Errors(xlEmptyCellReferences).Ignore = True

                for (int i = 1; i < intRowCount + 1; i = i + 1)
                {
                    // Formatting style of the header
                    using (var range = worksheet.Cells[i, 1, i, intMaxColCount])
                    {
                        // Setting bold font
                        range.Style.Border.Top.Style = range.Style.Border.Left.Style = range.Style.Border.Right.Style = range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        //   worksheet.ConditionalFormatting.AddNotContainsErrors(range);
                        worksheet.ConditionalFormatting.AddNotContainsErrors(range);
                        range.Style.Font.Size = 14;


                        //Change the NumberFormat from '' to 'Text'
                        //  range.Style.Numberformat.Format = "0";


                    }
                }


                //  Range cell = ActiveWorksheet.Cells[1, 1];
                //The @ is the indicator for Excel, that the content should be text



                //var cell = worksheet.Cells[rowIndex, colIndex];

                ////Setting top,left,right,bottom border of header cells
                //var border = cell.Style.Border;
                //border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                if (objDt.Columns.Contains("Client Name"))
                {
                    if (objDt.Rows[0]["Client Name"].ToString() == "New York University")
                    {
                        if (objDt.Columns.Contains("Certification fee (Student)"))
                        {
                            decimal strcerfee = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["Certification fee (Student)"].ToString());
                            decimal strprocefee = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["Total Fee"].ToString());

                            decimal ExamFeeStudent = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["ExamFee (Student)"].ToString());
                            decimal OndemandFeeStudent = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["On-demandFee (Student)"].ToString());
                            decimal Proctoringchargespaidbystudent = ExamFeeStudent + OndemandFeeStudent;

                            decimal ExamFeeUniversity = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["ExamFee (University)"].ToString());
                            decimal OndemandFeeUniversity = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["On-demandFee (University)"].ToString());
                            decimal ProctoringchargespaidbyUniversity = ExamFeeUniversity + OndemandFeeUniversity;

                            decimal ProcessingfeeUniversity = Convert.ToDecimal(objDt.Rows[objDt.Rows.Count - 1]["Processing fee (University)"].ToString());



                            worksheet.Cells[objDt.Rows.Count + 3, 18].Value = "Certification fee paid by student";
                            worksheet.Cells[objDt.Rows.Count + 4, 18].Value = "Proctoring charges paid by student";
                            worksheet.Cells[objDt.Rows.Count + 5, 18].Value = "Proctoring charges paid by University";
                            worksheet.Cells[objDt.Rows.Count + 6, 18].Value = "Processing fee paid by university (15%)";
                            worksheet.Cells[objDt.Rows.Count + 7, 18].Value = "Amount owed to University";


                            worksheet.Cells[objDt.Rows.Count + 3, 19].Value = strcerfee;
                            worksheet.Cells[objDt.Rows.Count + 3, 19].Style.Numberformat.Format = "$ #,##0.00";

                            worksheet.Cells[objDt.Rows.Count + 4, 19].Value = Proctoringchargespaidbystudent;
                            worksheet.Cells[objDt.Rows.Count + 4, 19].Style.Numberformat.Format = "$ #,##0.00";

                            worksheet.Cells[objDt.Rows.Count + 5, 19].Value = ProctoringchargespaidbyUniversity;
                            worksheet.Cells[objDt.Rows.Count + 5, 19].Style.Numberformat.Format = "$ #,##0.00";

                            worksheet.Cells[objDt.Rows.Count + 6, 19].Value = ProcessingfeeUniversity;
                            worksheet.Cells[objDt.Rows.Count + 6, 19].Style.Numberformat.Format = "$ #,##0.00";

                            decimal TotalValue = strcerfee - ProctoringchargespaidbyUniversity - ProcessingfeeUniversity;
                            worksheet.Cells[objDt.Rows.Count + 7, 19].Value = TotalValue;
                            worksheet.Cells[objDt.Rows.Count + 7, 19].Style.Numberformat.Format = "$ #,##0.00";
                        }

                        #region SetAutoFilter
                        worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


                        #endregion
                        #region FooterRowLineSettings
                        //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
                        // Formatting the footer row
                        // Setting top border of the footer row
                        worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        // Setting font bold of the footer row
                        //worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Font.Bold = true;
                        worksheet.Cells[intRowCount + 1, 1, intRowCount + 5, intColCount].Style.Font.Size = 14;

                        // Setting font bold of the footer row
                        worksheet.Cells[intRowCount + 6, 1, intRowCount + 6, intColCount].Style.Font.Bold = true;


                        worksheet.Cells[intRowCount + 6, 1, intRowCount + 6, intColCount].Style.Font.Size = 16;
                        #endregion
                        #region RightEndRowLineSettings
                        // Formatting the Right end row
                        // Setting top border of the Right end row
                        worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        #endregion

                    }
                    else
                    {
                        #region SetAutoFilter
                        worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


                        #endregion
                        #region FooterRowLineSettings
                        //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
                        // Formatting the footer row
                        // Setting top border of the footer row
                        worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        // Setting font bold of the footer row
                        worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Font.Bold = true;

                        // Setting font bold of the footer row
                        worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Bold = true;


                        worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Size = 16;
                        #endregion
                        #region RightEndRowLineSettings
                        // Formatting the Right end row
                        // Setting top border of the Right end row
                        worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        #endregion
                    }

                }
                else
                {
                    #region SetAutoFilter
                    worksheet.Cells[1, 1, 1, intMaxColCount].AutoFilter = boolAutofilter;


                    #endregion
                    #region FooterRowLineSettings
                    //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";
                    // Formatting the footer row
                    // Setting top border of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    // Setting font bold of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 1, intColCount].Style.Font.Bold = true;

                    // Setting font bold of the footer row
                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Bold = true;


                    worksheet.Cells[intRowCount + 1, 1, intRowCount + 3, intColCount].Style.Font.Size = 16;
                    #endregion
                    #region RightEndRowLineSettings
                    // Formatting the Right end row
                    // Setting top border of the Right end row
                    worksheet.Cells[1, intMaxColCount, intRowCount, intMaxColCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    #endregion
                }
                #region OtherSettings
                worksheet.Cells.AutoFitColumns();
                worksheet.View.PageLayoutView = true;
                worksheet.View.FreezePanes(2, 1);

                #endregion




                // Switch the page layout view back to the normal
                worksheet.View.PageLayoutView = false;


            }
            // Setting some document properties
            package.Workbook.Properties.Title = strReportName;
            package.Workbook.Properties.Author = strUserName;
            package.Workbook.Properties.Comments = strReportComments;
            package.Workbook.Properties.Company = strCompanyName;
            package.Workbook.Properties.SetCustomPropertyValue("Checked by", strUserName);
            package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");




            // Save our new workbook, we are done
            package.Save();
        }

    }

    public void GenerateReportGraph(DataSet objDataSet, System.IO.FileInfo rptFileName, string strReportName, string strUserName, DateTime startDate, DateTime endDate)
    {
        int intRowCount;
        int intGraphValueRowCount;
        string strGraphText = "DA";
        string strGraphValue = "DB";
        int intStartPosition = 0;
        int intGraphSPacing = 2;
        int intGraphWidth = 600;
        int intGraphHeight = 160;
        //int intPieHeight = 400;
        int intColCount = 0;
        //int intMaxColCount = 1;
        //int intMaxRowCount = 1;
        int intCellPosition = 2;

        //BEExcelStyles objBEExcelStyles = GetExcelStyles();

        using (ExcelPackage package = new ExcelPackage(rptFileName))
        {
            for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
            {
                if (objDataSet.Tables[1].Rows[i]["QTypeID"].ToString() != "5" && objDataSet.Tables[1].Rows[i]["QTypeID"].ToString() != "4")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Question-" + (i + 1).ToString());
                    worksheet.Cells[1, 1].Style.Font.Size = 14;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.View.PageLayoutView = false;


                    worksheet.Cells["A" + Convert.ToString(1) + ":" + "Z" + Convert.ToString(1)].Merge = true;

                    worksheet.Cells[1, 1].Value = "Survey Report From " + startDate.ToShortDateString() + " To "+endDate.ToShortDateString();
                    intRowCount = 2;


                    worksheet.Cells["B" + intRowCount.ToString() + ":" + "Z" + intRowCount.ToString()].Merge = true;

                    worksheet.Cells[intRowCount, 2].Value = objDataSet.Tables[1].Rows[i]["QText"].ToString();
                    worksheet.Cells[intRowCount, 2].Style.Font.Size = 14;
                    worksheet.Cells[intRowCount, 2].Style.Font.Bold = true;
                    intRowCount = intRowCount + 1;

                    worksheet.Cells["B" + intRowCount.ToString() + ":" + "Z" + intRowCount.ToString()].Merge = true;
                    intRowCount = intRowCount + 1;
                    worksheet.Cells["B" + intRowCount.ToString() + ":" + "Z" + intRowCount.ToString()].Merge = true;

                    worksheet.Cells[intRowCount, 2].Value = "Answered : " + objDataSet.Tables[1].Rows[i]["Answered"].ToString() + " ,     " + "Skipped : " + objDataSet.Tables[1].Rows[i]["Skipped"].ToString();
                    worksheet.Cells[intRowCount, 2].Style.Font.Size = 12;
                    intRowCount++;


                    int QID = Convert.ToInt32(objDataSet.Tables[1].Rows[i]["QID"].ToString());
                    if (objDataSet.Tables[2].Rows.Count > 0)
                    {
                        DataTable tblFiltered = objDataSet.Tables[2].AsEnumerable()
                             .Where(r => r.Field<int>("QID") == QID)
                             .CopyToDataTable();


                        int val;
                        var maxVal = tblFiltered.AsEnumerable()
                                .Where(rw => int.TryParse(rw["value"].ToString(), out val))
                                .Select(rw => Convert.ToInt32(rw["value"])).Max();


                        if (tblFiltered.Rows.Count > 0)
                        {
                            // intGraphRowCount = 1;
                            intGraphValueRowCount = 1;

                            decimal sum = Convert.ToDecimal(tblFiltered.Compute("SUM(vcounts)", string.Empty));
                            decimal WeightedAvg;
                            try
                            {
                                WeightedAvg = (sum / Convert.ToDecimal(tblFiltered.Rows[0]["Total"]));
                            }
                            catch
                            {
                                WeightedAvg = 0;
                            }

                            worksheet.Cells[strGraphText + intGraphValueRowCount.ToString()].Value = "";
                            worksheet.Cells[strGraphValue + intGraphValueRowCount.ToString()].Value = WeightedAvg;

                            var BarChart = worksheet.Drawings.AddChart("BarChart" + QID.ToString(), eChartType.BarStacked);
                            BarChart.SetPosition(intRowCount, 0, intCellPosition - 1, 0);

                            BarChart.Legend.Border.Fill.Color = Color.FromArgb(217, 217, 217);
                            BarChart.SetSize(intGraphWidth, intGraphHeight);
                            intStartPosition = 1;
                            intRowCount = intRowCount + (intGraphHeight / 20);
                            intRowCount = intRowCount + intGraphSPacing;
                            var BarSeries = BarChart.Series.Add(strGraphValue + intStartPosition.ToString() + ":" + strGraphValue + intGraphValueRowCount.ToString(), strGraphText + intStartPosition.ToString() + ":" + strGraphText + intGraphValueRowCount.ToString());
                            intColCount = 1;
                            int rowcount = intRowCount;
                            for (int h = 0; h < tblFiltered.Rows.Count; h++)
                            {
                                intColCount++;
                                #region HeaderColumns
                                worksheet.Cells[intRowCount, intColCount].Value = tblFiltered.Rows[h]["answertext"].ToString() + " ";
                                worksheet.Cells[intRowCount, intColCount].Merge = true;
                                worksheet.Cells[intRowCount, intColCount].AutoFitColumns();

                                worksheet.Cells[intRowCount, intColCount].Style.Numberformat.Format = "";

                                worksheet.Cells[intRowCount, intColCount].Style.Font.Bold = true;
                                // Setting fill type solid
                                worksheet.Cells[intRowCount, intColCount].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                // Setting background System.Drawing.Color dark blue
                                worksheet.Cells[intRowCount, intColCount].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);
                                // Setting font color
                                worksheet.Cells[intRowCount, intColCount].Style.Font.Color.SetColor(System.Drawing.Color.Black);

                                worksheet.Cells[intRowCount + 1, intColCount].Value = tblFiltered.Rows[h]["Percentage"].ToString() + " " + "%";

                                worksheet.Cells[intRowCount + 2, intColCount].Value = tblFiltered.Rows[h]["Answercounts"].ToString() + " ";

                                #endregion

                            }
                            worksheet.Cells[intRowCount, intColCount + 1].Value = "Total";
                            worksheet.Cells[intRowCount + 1, intColCount + 1].Value = tblFiltered.Rows[0]["Total"].ToString() + " ";

                            worksheet.Cells[intRowCount, intColCount + 2].Value = "Weighted Averages";
                            worksheet.Cells[intRowCount + 1, intColCount + 2].Value = WeightedAvg;

                            worksheet.Cells[intRowCount, intColCount + 1].Style.Font.Bold = true;
                            // Setting fill type solid
                            worksheet.Cells[intRowCount, intColCount + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            // Setting background System.Drawing.Color dark blue
                            worksheet.Cells[intRowCount, intColCount + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);
                            // Setting font color
                            worksheet.Cells[intRowCount, intColCount + 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);

                            worksheet.Cells[intRowCount, intColCount + 2].Style.Font.Bold = true;
                            // Setting fill type solid
                            worksheet.Cells[intRowCount, intColCount + 2].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            // Setting background System.Drawing.Color dark blue
                            worksheet.Cells[intRowCount, intColCount + 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);
                            // Setting font color
                            worksheet.Cells[intRowCount, intColCount + 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);

                            #region BorderSettings
                            // Setting top border of the footer row
                            worksheet.Cells[intRowCount, intCellPosition, intRowCount + 2, intColCount + 2].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            worksheet.Cells[intRowCount, intCellPosition, intRowCount + 2, intColCount + 2 + intCellPosition - 1].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            // Setting top border of the Right end row
                            worksheet.Cells[intRowCount, intCellPosition, intRowCount + 3, intColCount + 2].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            worksheet.Cells.AutoFitColumns();
                            #endregion

                        }
                    }

                    worksheet = null;
                }

            }

            // Setting some document properties
            package.Workbook.Properties.Title = strReportName;
            package.Workbook.Properties.Author = strUserName;
            package.Workbook.Properties.Comments = strReportComments;
            package.Workbook.Properties.Company = strCompanyName;
            package.Workbook.Properties.SetCustomPropertyValue("Checked by", strUserName);
            package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");

            // Save our new workbook, we are done
            package.Save();
        }

    }
}
