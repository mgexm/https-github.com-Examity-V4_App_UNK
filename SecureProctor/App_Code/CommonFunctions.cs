using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Threading;
using BusinessEntities;
using BLL;

namespace SecureProctor
{
    public class CommonFunctions
    {

        public CommonFunctions()
        {

        }

        public static DateTime GetTime(DateTime dt, string strTimeZone)
        {
            if (strTimeZone.ToUpper().ToString() == "CT")
                dt = dt.AddHours(-5);
            else if (strTimeZone.ToUpper().ToString() == "ET")
                dt = dt.AddHours(-4);
            else if (strTimeZone.ToUpper().ToString() == "PT")
                dt = dt.AddHours(-7);
            else if (strTimeZone.ToUpper().ToString() == "MT")
                dt = dt.AddHours(-6);
            return dt;
        }




        public static string generateUploadFileName(string fileName)
        {
            string strFileName = string.Empty;
            strFileName = fileName.Substring(0, fileName.IndexOf(".")) + GetRandom() + Path.GetExtension(fileName);
            return strFileName;
        }
        public static string getCurrentDate()
        {
            string strCurrentDate = string.Empty;
            strCurrentDate = DateTime.Now.ToString("MMddyyyy");
            return strCurrentDate;
        }
        public static string getStudentCurrentTime()
        {
            string strCurrentDate = string.Empty;
            strCurrentDate = DateTime.Now.ToString("hhmmss.ffffff");
            return strCurrentDate;
        }
        public static string getCurrentTime()
        {
            string strCurrentDate = string.Empty;
            strCurrentDate = DateTime.Now.ToString("hhmmssfff");
            return strCurrentDate;
        }
        public static string generateUploadStudentFileName(string fileName)
        {
            string strFileName = string.Empty;
            // strFileName = getCurrentDate().ToString() + getStudentCurrentTime().ToString() + Path.GetExtension(fileName);
            strFileName = fileName.Substring(0, fileName.IndexOf(".")) + GetRandom() + Path.GetExtension(fileName);
            return strFileName;
        }

        public static string[] UrlDecryptor(string strEncrypted)
        {
            string[] strAr = null;
            string strDecrypted = AppSecurity.Decrypt(strEncrypted);
            if (strDecrypted.Contains('&'))
                strAr = strDecrypted.Split('&');
            else
                strAr = new string[1] { strDecrypted };
            return strAr;
        }

        public static string UrlEncryptor(string strDecrypted)
        {
            return AppSecurity.Encrypt(strDecrypted);
        }

        public static string GetRandom()
        {

            char[] chars = "1234567890".ToCharArray();
            string password = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                int x = random.Next(1, chars.Length);
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            Thread.Sleep(20);
            return password;


        }
       


        public static DataTable getExamDataTable()
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("ID");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Head");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Text");
            objDT.Columns.Add(objDC);
            return objDT;
        }


        public static string convertTimeZone(string strTimeZone, string Time)
        {
            string strRetTime = Time;
            string strTime = "12/12/2013 " + Time.ToString();
            DateTime dt = Convert.ToDateTime(strTime);
            switch (strTimeZone.ToUpper().ToString())
            {
                case "CT":
                    strRetTime = dt.AddHours(0).ToShortTimeString();
                    break;
                case "ET":
                    strRetTime = dt.AddHours(1).ToShortTimeString();
                    break;
                case "PT":
                    strRetTime = dt.AddHours(-2).ToShortTimeString();
                    break;
                case "MT":
                    strRetTime = dt.AddHours(-1).ToShortTimeString();
                    break;
            }
            return strRetTime;
        }

        public static string CheckNullValue(string value)
        {

            if (value != "" && value!=null)
            {

                return value;
            }
            else
            {

                return "N/A";
            }
        }

        public void setExamDetailsForExamityMeeting(string transID, HiddenField isLockDown, HiddenField examPassword, HiddenField examDomain, HiddenField hdnExamSecurity)
        {
            try
            {
                BECommon objBECommon = new BECommon();
                objBECommon.IntTransID = Int64.Parse(AppSecurity.Decrypt(transID));
                BCommon bCommon = new BCommon();
                bCommon.BGetExamDetailsForExamityMeeting(objBECommon);

                if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0)
                {
                    var islockDown = (objBECommon.DsResult.Tables[0].Rows[0]["IsLockDown"]);
                    isLockDown.Value = islockDown.ToString();

                    var isPasswordExists = (objBECommon.DsResult.Tables[0].Rows[0]["ExamPassword"]);
                    examPassword.Value = isPasswordExists.ToString();

                    examDomain.Value = objBECommon.DsResult.Tables[0].Rows[0]["ExamDomain"].ToString();

                    var examSecurity = (objBECommon.DsResult.Tables[0].Rows[0]["ExamSecurity"]).ToString();
                    hdnExamSecurity.Value = examSecurity == "4" ? "L3" : examSecurity;
                }
            }
            catch (Exception)
            {
            }

        }

        public bool GetVideoVisibleStatus(long intTransID)
        {
            bool boolResult = true;
            try
            {
                BLL.BCommon objBCommon = new BLL.BCommon();
                BusinessEntities.BECommon objBECommon = new BusinessEntities.BECommon();
                objBECommon.LngTransID = intTransID;
                objBCommon.BGetVideoVisibleStatus(objBECommon);
                if (objBECommon.IntResult == 1)
                    boolResult = true;
                else
                    boolResult = false;
            }
            catch
            {
                boolResult = true;
            }
            return boolResult;
        }
    }
}
