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
    public partial class CaptureIDImage : System.Web.UI.Page
    {
        Int64 transID = 0;
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                getPhotoIdentity();
                if (Request.InputStream.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        string hexString = Server.UrlEncode(reader.ReadToEnd());

                        Session["CapturedIDBytes"] = ConvertHexToBytes(hexString);
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
                Session["CapturedIDBytes"] = Convert.FromBase64String(txtimgvalue.Value);


            if (Session["CapturedIDBytes"] != null)
            {
                byte[] bytes = Session["CapturedIDBytes"] as byte[];


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
                    objBCommon.BSaveTransIDImage(objBECommon);
                    if (objBECommon.IntstatusFlag == 1)
                    {
                        lblError.Text = "Your ID picture has been saved successfully! Click" + "<b>&#34;Next&#34;</b> to proceed.";
                        lblError.ForeColor = System.Drawing.Color.Green;
                        btnProceed.Visible = true;
                        // Response.Redirect("ExamProcess.aspx?TransID=" + AppSecurity.Encrypt(transID.ToString()), false);
                    }
                    else
                    {
                        lblError.Text = "Error in uploading Image.";
                        lblError.ForeColor = System.Drawing.Color.Red;
                    }


                }
                else
                {
                    lblError.Text = "Error in uploading Image.";
                    lblError.ForeColor = System.Drawing.Color.Red;


                }

                Session["CapturedIDBytes"] = null;
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

            if (HttpContext.Current.Session["CapturedIDBytes"] != null)
            {
                bytes = HttpContext.Current.Session["CapturedIDBytes"] as byte[];
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
            objBEStudent.IntType = 15;
            objBStudent.BUpdatePLTime(objBEStudent);
            //Response.Redirect("Authenticationcode.aspx?TransID=" + AppSecurity.Encrypt(transID.ToString()), false);

            Response.Redirect("ExamiKNOW.aspx?TransID=" + AppSecurity.Encrypt(transID.ToString()), false);

        }

        protected void getPhotoIdentity()
        {

            try
            {
                BEStudent objBEStudent = new BEStudent();

                BStudent objBStudent = new BStudent();

                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBStudent.BgetPhotoIdentity(objBEStudent);

                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                   // imgStudentPhotoID.ImageUrl = "~/Student\\Student_Identity\\" + objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                    imgStudentPhotoID.ImageUrl = new AppSecurity().ImageToBase64(objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString()); 
                    imgStudentPhotoID.ImageAlign = ImageAlign.Top;
                    string strTotalPath = Server.MapPath("~/Student\\Student_Identity\\" + objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                    //string strTotalPath = Server.MapPath(imgStudentPhotoID.ImageUrl);
                    FileInfo fi = new FileInfo(strTotalPath);
                    if (fi.Exists)
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromFile(strTotalPath);

                        if (image == null)
                        {
                            imgStudentPhotoID.ImageUrl = "~/Student\\Student_Identity\\noimage.jpg";
                        }

                    }
                    else
                    {
                        imgStudentPhotoID.ImageUrl = "~/Student\\Student_Identity\\noimage.jpg";
                    }
                }
                else
                {
                    imgStudentPhotoID.ImageUrl = "~/Student\\Student_Identity\\noimage.jpg";
                }

            }

            catch (Exception e)
            {


            }

        }
    }
}