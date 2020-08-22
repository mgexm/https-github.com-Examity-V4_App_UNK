using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using BusinessEntities;
using BLL;
using CarlosAg.ExcelXmlWriter;

namespace SecureProctor.Student
{
    public partial class Reports : BaseClass 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_REPORTS;
            ((LinkButton)this.Page.Master.FindControl("lnkReport")).CssClass = "main_menu_active";

           
            //btnSearch.Attributes.Add("onclick", "return validateFields('" + txtStartDate.ClientID.ToString() + "','" + txtEndDate.ClientID.ToString() + "');");

            txtStartDate.Attributes.Add("onkeydown", "return false;");
            txtStartDate.Attributes.Add("onpaste", "return false;");
            txtEndDate.Attributes.Add("onkeydown", "return false;");
            txtEndDate.Attributes.Add("onpaste", "return false;");

           
        }

        #region GenerateExcelReport
        private void GenerateExcelReport(DataTable dtTable, DataTable dtLength, string strFilePath, string ReportName, string strFileName)
        {

            //Add a workbook   
            CarlosAg.ExcelXmlWriter.Workbook book = new CarlosAg.ExcelXmlWriter.Workbook();
            #region SheetProperties
            // Specify which Sheet should be opened and the size of window by default            
            book.ExcelWorkbook.ActiveSheetIndex = 1;
            book.ExcelWorkbook.WindowTopX = 100;
            book.ExcelWorkbook.WindowTopY = 200;
            book.ExcelWorkbook.WindowHeight = 7000;
            book.ExcelWorkbook.WindowWidth = 8000;
            // Some optional properties of the Document            
            book.Properties.Author = "Secure Proctor Report";
            book.Properties.Title = "Excel Export";
            book.Properties.Created = DateTime.Now;
            #endregion
            #region CellStyle
            WorksheetStyle CellStyle = book.Styles.Add("CellStyle");
            CellStyle.Font.FontName = "Arial";
            CellStyle.Font.Size = 11;
            CellStyle.Font.Color = "#000000";
            CellStyle.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            CellStyle.Alignment.Vertical = StyleVerticalAlignment.Center;
            CellStyle.Alignment.WrapText = false;
            CellStyle.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            CellStyle.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            CellStyle.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            CellStyle.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            CellStyle.NumberFormat = "@";
            #endregion
            #region HeaderStyle
            WorksheetStyle HeaderStyle = book.Styles.Add("HeaderStyle");
            HeaderStyle.Font.FontName = "Arial";
            HeaderStyle.Font.Size = 11;
            HeaderStyle.Font.Bold = true;
            HeaderStyle.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            HeaderStyle.Alignment.WrapText = false;
            HeaderStyle.Font.Color = "#000000";
            HeaderStyle.Interior.Color = "#99CCFF";
            HeaderStyle.Interior.Pattern = StyleInteriorPattern.Solid;
            HeaderStyle.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            HeaderStyle.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            HeaderStyle.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            HeaderStyle.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            #endregion
            // Add a Worksheet with some data            
            Worksheet sheet = book.Worksheets.Add(ReportName);
            //Add row with some properties            
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Index = 0;
            row.Height = 35;
            row.AutoFitHeight = true;
            //Set worksheet column names   
            int ColNumber = 0;
            int ColumnLength = 100;
            int colSeedValue = 7;
            foreach (DataColumn dc in dtTable.Columns)
            {
                ///* SET COLUMN WIDTH - START */
                if (dtLength.Rows[0][ColNumber] != null)
                {
                    if (dtLength.Rows[0][ColNumber].ToString().Length != 0)
                    {
                        if (Convert.ToInt32(dtLength.Rows[0][ColNumber].ToString()) > dc.ColumnName.Length)
                            ColumnLength = Convert.ToInt32(dtLength.Rows[0][ColNumber].ToString()) * colSeedValue;
                        else
                            ColumnLength = dc.ColumnName.Length * colSeedValue;
                    }
                    else
                        ColumnLength = dc.ColumnName.Length * colSeedValue;
                }
                else
                    ColumnLength = dc.ColumnName.Length * colSeedValue;
                ///* SET COLUMN WIDTH - END */
                //ColumnLength = 100;
                sheet.Table.Columns.Add(new WorksheetColumn(ColumnLength));
                WorksheetCell wcHeader = new WorksheetCell(dc.ColumnName, CarlosAg.ExcelXmlWriter.DataType.String, "HeaderStyle");
                row.Cells.Add(wcHeader);
                ColNumber++;
            }
            foreach (DataRow dtrrow in dtTable.Rows)
            {
                //Add row to the excel sheet			
                row = sheet.Table.Rows.Add();
                //row.Height = 30;
                row.AutoFitHeight = true;
                //Loop through each column                        
                foreach (DataColumn col in dtTable.Columns)
                {
                    WorksheetCell wc = new WorksheetCell(dtrrow[col.ColumnName].ToString(), DataType.String, "CellStyle");
                    row.Cells.Add(wc);
                }
            }
            //Save the work book            
            book.Save(strFilePath);
            DownloadFile(strFilePath, strFileName);
        }
        #endregion
        #region DownloadFile
        protected void DownloadFile(string strFilePath, string strFileName)
        {
            FileInfo rptFileName = new FileInfo(strFilePath);
            if (rptFileName.Exists)
            {
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
                Response.AddHeader("Content-Length", rptFileName.Length.ToString());
                Response.ContentType = "application/vnd.ms-excel";
                Response.TransmitFile(rptFileName.FullName);
                rptFileName = null;
                Response.Output.Flush();
                Response.End();
            }
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string strFilePrefix = "Student";
            //BEStudent objBEStudent = new BEStudent();
            //BStudent objBStudent = new BStudent();
            //objBEStudent.DtStartDate = txtStartDate.ToString();
            //objBEStudent.DtEndDate = txtEndDate.ToString();
            //objBEStudent.IntType = Convert.ToInt32(ddlExam.SelectedValue.ToString());
            //objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
            //objBStudent.BGetStudentReprot(objBEStudent);
            //this.DeleteHistoricFiles();
            //if (objBEStudent.DsResult != null)
            //{
            //    if (objBEStudent.DsResult.Tables.Count > 0)
            //    {
            //        if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
            //        {
            //            string strFileName = strFilePrefix + "_FileDate_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".XLS";
            //            GenerateExcelReport(objBEStudent.DsResult.Tables[0], objBEStudent.DsResult.Tables[1], Server.MapPath("../Reports") + "\\" + strFileName, "Student Report", strFileName);
            //        }
            //        else
            //        {
            //            // ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('No records found for the selected criteria');", true);

            //            lblSuccess.Text = "No records found for the selected criteria";
            //        }
            //    }
            //    else
            //    {
            //        //  ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('No records found for the selected criteria');", true);
            //        lblSuccess.Text = "No records found for the selected criteria";
            //    }
            //}
            //else
            //{
            //    // ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('No records found for the selected criteria');", true);
            //    lblSuccess.Text = "No records found for the selected criteria";
            //}
        }

        protected void DeleteHistoricFiles()
        {
            DirectoryInfo drInfo = new DirectoryInfo(Server.MapPath("../Reports"));
            foreach (FileInfo fileReport in drInfo.GetFiles())
            {
                try
                {
                    string strFileDate = fileReport.FullName.ToString().Substring(fileReport.FullName.ToString().IndexOf("FileDate_") + 9, 10);
                    if (DateTime.Compare(Convert.ToDateTime(strFileDate), Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"))) < 0)
                    {
                        fileReport.Delete();
                    }
                }
                catch
                {
                }
            }
        }
    }
}