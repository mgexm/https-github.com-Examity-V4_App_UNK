using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessEntities;
using BLL;

namespace SecureProctor
{
    /// <summary>
    /// Summary description for ReverseAjax
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ReverseAjax : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetExamTransactionStatus(string TransID)
        {
            return ClientAdapter.Instance.GetMessage(AppSecurity.Decrypt(TransID));
        }

        [WebMethod]
        public string GetExamLink(string TransID)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(TransID);
            objBEStudent.IntFlag = 1;
            objBStudent.BSetExamStartandEndTime(objBEStudent);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            objBStudent.BGetExamLink(objBEStudent);
            string ExamLink = string.Empty;
            string ExamByFile = string.Empty;

            if (objBEStudent.strExamLink != string.Empty)
            {
                ExamByFile = objBEStudent.strExamLink.Split('|')[0];
                if (ExamByFile == "0")
                    ExamLink = objBEStudent.strExamLink.Split('|')[1];
                else
                {
                    ExamLink = System.Configuration.ConfigurationManager.AppSettings["ProviderUploadsPath"].ToString() + objBEStudent.strExamLink.Split('|')[2];
                }

                if (!ExamLink.Contains("http://") && !ExamLink.Contains("https://"))
                {
                    ExamLink = "http://" + ExamLink;
                }
                return ExamByFile + "|" + ExamLink;
            }
            else
                return string.Empty;
        }
    }
}