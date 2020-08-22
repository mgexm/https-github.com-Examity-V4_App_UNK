using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using CarlosAg.ExcelXmlWriter;
using BLL;
using BusinessEntities;

namespace SecureProctor.Reports
{
    public partial class Reports1 : System.Web.UI.Page
    {
        string SQLStudentData;
        string SQLGetExamStatus;
        string SQLGetViolationReport;
        // string cs = ("server=MGST-CORE\\SQL2008R2;database=SecureProctor;uid=Core;pwd=C0r35ql");
        string cs = ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString;
        //CONVERT(VARCHAR(8),ET.ExamDate,108) ExamTime
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLGetExamStatus = "Select UI.UserID [Student ID],UI.FirstName [First Name],UI.LastName [Last Name],UI.EmailAddress [Email ID],SI.PhoneNumber [Phone Number], " +
           " ET.TransID [Transaction ID],S.StatusName [Transaction Status],CR.CourseName [Course Name],E.ExamName [Exam Name]," +
           " ET.ExamDate [Exam Date], " +
           " REPLACE(REPLACE(CONVERT(varchar(15),CAST(CONVERT(VARCHAR(8),DBO.GetExamTime(ET.ExamDate,UI.UserID),108) AS TIME),100),'AM', ' AM'),'PM',' PM') AS ScheduledTime, " +
           " ET.ExamStarttime [Exam Start Time],t.TimeZone [Time Zone]," +
           " CASE WHEN ISNULL(E.OpenBook,0)=1 THEN 'YES'ELSE 'NO' END [Open Book],E.ExamDuration,CR.ExamProviderID,ET.DateCreated [Created On]," +
           " 'Proctor Name'=(Select FirstName+' '+ LastName from tblUserInformation where RoleID=5),  " +
           " 'Temple University' as 'Client Name'" +
           " FROM tblUserInformation UI,tblUsers U,tblExamTransactions ET, " +
           " tblCourses CR,tblExamDetails E,tblStatus S ,tblTimeZone t  ,tblGenders G ,tblStudentInfo SI  " +
           " WHERE UI.UserID=U.UserID and ET.UserID=UI.UserID and" +
           " ET.CourseID=CR.CourseID and UI.TimeZone = t.id " +
           " and E.ExamID=ET.ExamID and ET.TransactionStatus=S.StatusID " +
           " and UI.Gender=G.GenderID AND SI.StudentID=UI.UserID ";

            SQLGetViolationReport = " Select UI.UserID [Student ID],UI.FirstName [First Name],UI.LastName [Last Name],UI.EmailAddress [Email ID], SI.PhoneNumber [Phone Number], " +
            " ET.TransID [Transaction ID],S.StatusName [Transaction Status],CR.CourseName [Course Name],E.ExamName [Exam Name]," +
            " ET.ExamDate [Exam Date], " +
            "  REPLACE(REPLACE(CONVERT(varchar(15),CAST(CONVERT(VARCHAR(8),DBO.GetExamTime(ET.ExamDate,UI.UserID),108) AS TIME),100),'AM', ' AM'),'PM',' PM') AS ScheduledTime, " +
            " ET.ExamStarttime [Exam Start Time],t.TimeZone [Time Zone]," +
            " CASE WHEN ISNULL(E.OpenBook,0)=1 THEN 'YES'ELSE 'NO' END [Open Book],E.ExamDuration,CR.ExamProviderID,ET.DateCreated [Created On]," +
            " CT.CommentType,CT.FlagColour,C.Comments,C.CommenterID,CTUI.FirstName,CTUI.LastName,CTUI.EmailAddress, C.DateCreated, " +
            " 'Proctor Name'=(Select FirstName+' '+ LastName from tblUserInformation where RoleID=5),  " +
            " 'Temple University' as 'Client Name'" +
            " FROM tblUserInformation UI,tblUsers U,tblExamTransactions ET, " +
            " tblCourses CR,tblExamDetails E,tblStatus S ,tblTimeZone t  ,tblGenders G  ,tblStudentInfo SI ," +
            " tblCommentsType CT,tblComments C,tblUserInformation CTUI" +
            " WHERE UI.UserID=U.UserID and ET.UserID=UI.UserID and  " +
            " ET.CourseID=CR.CourseID and UI.TimeZone = t.id" +
            " and E.ExamID=ET.ExamID and ET.TransactionStatus=S.StatusID " +
            " and UI.Gender=G.GenderID" +
            " and CT.CommentTypeID=C.CommentTypeID" +
            " and C.TransactionID=ET.TransID" +
            " and C.CommenterID=CTUI.UserID  AND SI.StudentID=UI.UserID ";

        }

        public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {

                string filename = "ReportDetails.xls";

                string excelHeader = "";// "Database table";

                System.IO.StringWriter tw = new System.IO.StringWriter();

                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                DataGrid dgGrid = new DataGrid();

                dgGrid.DataSource = dt;

                dgGrid.DataBind();

                // Report Header

                hw.WriteLine("<b><u><font size='3'> " + excelHeader + " </font></u></b>");

                //Get the HTML for the control.

                dgGrid.RenderControl(hw);

                //Write the HTML back to the browser.

                Response.ContentType = "application/vnd.ms-excel";

                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + " ");

                this.EnableViewState = false;

                Response.Write(tw.ToString());

                Response.End();

            }

        }


        protected void lnkGetStudentReport_Click(object sender, EventArgs e)
        {
            string AppTextVal;
            AppTextVal = "";

            //if (txtDate.Text != string.Empty)
            //{
            //    AppTextVal = " and ET.ExamDate= Convert(Varchar(10), '" + txtDate.Text+"',101) ";
            //}
            //    else
            //{
            //    AppTextVal="";
            //}
            SQLStudentData = "Select UI.UserID [Student ID],UI.FirstName [First Name],UI.LastName [Last Name],UI.EmailAddress [Email ID],SI.PhoneNumber [Phone Number], " +
           " ET.TransID [Transaction ID],S.StatusName [Transaction Status],CR.CourseName [Course Name],E.ExamName [Exam Name]," +
           " ET.ExamDate [Exam Date], " +
           " REPLACE(REPLACE(CONVERT(varchar(15),CAST(CONVERT(VARCHAR(8),DBO.GetExamTime(ET.ExamDate,UI.UserID),108) AS TIME),100),'AM', ' AM'),'PM',' PM') AS ScheduledTime, " +
           " ET.ExamStarttime [Exam Start Time],t.TimeZone [Time Zone]," +
           " CASE WHEN ISNULL(E.OpenBook,0)=1 THEN 'YES' ELSE 'NO' END [Open Book],E.ExamDuration,CR.ExamProviderID,ET.DateCreated [Created On], " +
           " 'Proctor Name'=(Select FirstName+' '+ LastName from tblUserInformation where RoleID=5),  " +
            " 'Temple University' as 'Client Name'" +
           " FROM tblUserInformation UI,tblUsers U,tblExamTransactions ET, " +
           " tblCourses CR,tblExamDetails E,tblStatus S ,tblTimeZone t  ,tblGenders G,tblStudentInfo SI  " +
           " WHERE UI.UserID=U.UserID and ET.UserID=UI.UserID and" +
           " ET.CourseID=CR.CourseID and UI.TimeZone = t.id " +
           " and E.ExamID=ET.ExamID and ET.TransactionStatus=S.StatusID" +
           " and UI.Gender=G.GenderID AND SI.StudentID=UI.UserID and ET.TransactionStatus=1 " + AppTextVal + "  ";
            // lblMSG.Text = SQLStudentData;

            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQLStudentData, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable d = new DataTable();
            d = ds.Tables[0];
            ExportToExcel(d);
            conn.Close();

        }

        protected void lnkGetExamStatusReport_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQLGetExamStatus, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable d = new DataTable();
            d = ds.Tables[0];
            ExportToExcel(d);
            conn.Close();
        }

        protected void lnkGetStudentviolationReport_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQLGetViolationReport, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable d = new DataTable();
            d = ds.Tables[0];
            ExportToExcel(d);
            conn.Close();

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
        
        }
    }
}