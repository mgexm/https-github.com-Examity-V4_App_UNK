using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;
using BusinessEntities;
using BLL;


namespace SecureProctor.Student
{
    public partial class CaptureImage : System.Web.UI.Page
    {
        Int64 transID = 0;
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                Session["Flowcheck"] = null;

                if (Request.InputStream.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        string hexString = Server.UrlEncode(reader.ReadToEnd());

                        Session["CapturedBytes"] = ConvertHexToBytes(hexString);
                    }
                }



            }
            if (Request.QueryString["TransID"] != null)
            {
                transID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            }
        }

        #region Upload to Server

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //new code added by adarsh for video playeer tag
            if (Session["IsHmlCompliant"] == "Yes")
                Session["CapturedBytes"] = Convert.FromBase64String(txtimgvalue.Value);


            if (Session["CapturedBytes"] != null)
            {
                byte[] bytes = Session["CapturedBytes"] as byte[];


                if (transID != 0)
                {

                    BECommon objBECommon = new BECommon();
                    BCommon objBCommon = new BCommon();

                    objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
                    objBCommon.BGetTimeDelay(objBECommon);
                    string SavedTime = DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy hh:mm tt");

                    lblError.Visible = true;

                    objBECommon.IntTransID = transID;
                    objBECommon.image = bytes;
                    objBECommon.strTime = SavedTime;
                    objBCommon.BSaveTransImage(objBECommon);
                    if (objBECommon.IntstatusFlag == 1)
                    {
                        lblError.Text = "Your picture has been saved successfully! Click " + "<b>&#34;Next&#34;</b> to proceed.";
                        lblError.ForeColor = System.Drawing.Color.Green;
                        btnProceed.Visible = true;
                        // Response.Redirect("ExamProcess.aspx?TransID=" + AppSecurity.Encrypt(transID.ToString()), false);
                    }
                    else
                    {
                        lblError.Text = "Error in saving Image.";
                        lblError.ForeColor = System.Drawing.Color.Red;
                    }


                }
                else
                {
                    lblError.Text = "Error in uploading Image.";
                    lblError.ForeColor = System.Drawing.Color.Red;


                }

                Session["CapturedBytes"] = null;
                //Session["TransID"] = null;
            }
        }

        #endregion

        #endregion

        #region Methods

        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        #endregion

        #region Callback

        [WebMethod(EnableSession = true)]
        public static string GetCapturedImage()
        {
            string url = string.Empty;
            byte[] bytes = null;

            if (HttpContext.Current.Session["CapturedBytes"] != null)
            {
                bytes = HttpContext.Current.Session["CapturedBytes"] as byte[];
                url = "data:image/png;base64," + Convert.ToBase64String(bytes);
            }

            return url;
        }

        #endregion

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = transID;
            objBEStudent.IntResult = 1;
            objBEStudent.IntType = 14;
            objBStudent.BUpdateNonProctorExamStatus(objBEStudent);
            objBStudent.BUpdatePLTime(objBEStudent);


            Response.Redirect("CaptureIDImage.aspx?TransID=" + AppSecurity.Encrypt(transID.ToString()), false);

        }
    }
}