using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace SecureProctor.Student
{
    public partial class PayNow : System.Web.UI.Page
    {
        public string ActionPage = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["BESTUDENT"].ToString()) != null)
            {
                BusinessEntities.BEStudent objBEStudent = (BusinessEntities.BEStudent)Session["BESTUDENT"];
                ActionPage = this.GenerateURL(objBEStudent.decAmount);
            }
            else
            {
                Response.Redirect("ScheduleAnExam.aspx");
            }
        }

        public string GenerateURL(decimal decAmount)
        { 
            string strMD5HashString = string.Empty;
            strMD5HashString = System.Configuration.ConfigurationManager.AppSettings["ProductID"].ToString() + "#" + decAmount.ToString() + System.Configuration.ConfigurationManager.AppSettings["CurrentcyCode"].ToString() + "," + System.Configuration.ConfigurationManager.AppSettings["AmountType"].ToString() + "#" + System.Configuration.ConfigurationManager.AppSettings["MD5Password"].ToString();

            StringBuilder stbPaymentURL = new StringBuilder();
            stbPaymentURL.Append(System.Configuration.ConfigurationManager.AppSettings["PaymentURL"].ToString());
            stbPaymentURL.Append("PRODUCT[" + System.Configuration.ConfigurationManager.AppSettings["ProductID"].ToString() + "]=1&languageid=1&pc=nskg6&pts=" + System.Configuration.ConfigurationManager.AppSettings["CardTypes"].ToString() + "&" + System.Configuration.ConfigurationManager.AppSettings["TrackingCode"].ToString() + "&");
            stbPaymentURL.Append("PRODUCTPRICE[" + System.Configuration.ConfigurationManager.AppSettings["ProductID"].ToString() + "]=");
            stbPaymentURL.Append(decAmount.ToString() + System.Configuration.ConfigurationManager.AppSettings["CurrentcyCode"].ToString() + "%2C");
            stbPaymentURL.Append(System.Configuration.ConfigurationManager.AppSettings["AmountType"].ToString() + "%3B");
            stbPaymentURL.Append(this.CalculateMD5Hash(strMD5HashString));

            return stbPaymentURL.ToString();
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}