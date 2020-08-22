using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Text;
using System.IO;

using System.Configuration;
using System.Net;


namespace SecureProctor.Admin
{
    public partial class AdminViewExamScreens : BaseClass
    {
        string streamingurl;
        protected void Page_Load(object sender, EventArgs e)
        {

            //GetURL();
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_VIEW_STUDENT_EXAM;
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_EXAMSTATUS;
            ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";


            tdDesktop.InnerHtml = getPlayer("Desktop");
            //tdWebcam.InnerHtml = getPlayer("Webcam");
            //  tdDesktop.InnerHtml = getPlayer("Desktop");
            //RadMediaPlayer1.TitleBar.ShareButton.Visible = false;
            //RadMediaPlayer1.ToolBar.Visible = true;
            //RadMediaPlayer1.ToolbarDocked = true;
            //RadMediaPlayer1.ToolBar.HDButton.Visible = false;
            //RadMediaPlayer1.Source = System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".mp4";
            this.GetStudentUploadFileStatus();
            if (Request.QueryString["TransID"] != null)
            {
                this.getExamFileUploadStatus();

            }




            //tdVoice.InnerHtml = getPlayer("Voice");
            //BindProctorreviewDetails();
            //txtComments.Visible = false;
            //RequiredFieldValidator11.Enabled = false;
            //RequiredFieldValidator11.ValidationGroup = string.Empty;

        }
        //protected void BindAlerts()
        //{
        //    try
        //    {

        //        BECommon objBEComon = new BECommon();
        //        BCommon objBCommon = new BCommon();
        //        objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
        //        objBEComon.intAlertID = 4;
        //        objBCommon.BGetAlerts(objBEComon);
        //        ddlAlerts.DataSource = objBEComon.DtResult;
        //        ddlAlerts.DataValueField = "AlertID";
        //        ddlAlerts.DataTextField = "AlertText";
        //        ddlAlerts.DataBind();
        //    }
        //    catch
        //    {
        //    }
        //}
        //protected void gvStudentNotes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    try
        //    {
        //        this.BindExamDetails();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        protected void GetURL()
        {

            string clientname = ConfigurationManager.AppSettings["clientname"];
            string transid = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["RackServiceURL"] + transid + "/" + clientname);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader reader = new StreamReader(str);

            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            streamingurl = responseFromServer.ToString();
        }

        protected void GetStudentUploadFileStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStudentUploadFileStatus(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (objBECommon.DtResult.Rows[0][0].Equals(true))
                {
                    ucUploadFiles.Visible = true;

                }
                else
                    ucUploadFiles.Visible = false;

            }
        }

        protected void getExamFileUploadStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBCommon.BgetExamFileUploadStatus(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows != null && objBECommon.DsResult.Tables[0].Rows.Count > 0 && objBECommon.DsResult.Tables[1].Rows != null && objBECommon.DsResult.Tables[1].Rows.Count > 0)
            {
                if (objBECommon.DsResult.Tables[0].Rows[0][0].Equals(true) && objBECommon.DsResult.Tables[1].Rows[0][0].Equals(true))
                {
                    ucUploadFiles.Visible = true;

                }
                else
                    ucUploadFiles.Visible = false;

            }
        }


        protected void gvComments_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                BindTransactionsComments();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BindExamDetails
        protected void BindExamDetails()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();

                if (Request.QueryString["TransID"] != null)
                {

                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBCommon.BGetStudentExamDetails(objBECommon);



                    if (objBECommon.DsResult != null)
                    {
                        if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
                            ViewState[BaseClass.EnumPageSessions.TransID] = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                            gvexamdetails.DataSource = objBECommon.DsResult.Tables[0];
                            if (Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["ExamiKey"]) == true)
                            {
                                lblKeyScore.Text = objBECommon.DsResult.Tables[0].Rows[0]["Examikeyscore"].ToString() + "%";
                                lblKeyScore.Visible = true;
                                lblKeyScoretext.Visible = true;
                            }
                            else
                            {
                                lblKeyScore.Visible = false;
                                lblKeyScoretext.Visible = false;
                            }


                            // string strTotalPath = "~/Student/Student_Identity/" + objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                            img.ImageUrl = new AppSecurity().ImageToBase64(objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                            //string strTotalPath = Server.MapPath("/Student/Student_Identity/" + objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                            // if (File.Exists(strTotalPath))
                            //{
                            //    img.ImageUrl = strTotalPath;
                            //}
                            //else
                            //{

                            //    img.ImageUrl = Server.MapPath("~/Student\\Student_Identity\\noimage.jpg");
                            //}


                            // img.ImageUrl = "..\\Student\\Student_Identity\\" + objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                            // img.ImageUrl = strTotalPath;

                            img.ImageAlign = ImageAlign.Top;

                            //    lblTransactionID.Text = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());

                            //    lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                            //    lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                            //    lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                            //    lblDate.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                            //    lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
                            //    lblExamSatus.Text = objBECommon.DsResult.Tables[0].Rows[0]["StatusName"].ToString();
                            //    lblEmailID.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                            //    lblSpecialNeeds.Text = objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString();
                            //    if (objBECommon.DsResult.Tables[0].Rows[0]["Comments"] != DBNull.Value && objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString() != string.Empty)
                            //    {
                            //        lblComments.Text = objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                            //    }
                            //    else
                            //    {
                            //        lblComments.Text = "N/A";
                            //    }

                            //    lblMaxAttempts.Text = objBECommon.DsResult.Tables[0].Rows[0]["AllowedAttempts"].ToString();
                            //    lblUsedAttempts.Text = objBECommon.DsResult.Tables[0].Rows[0]["UsedAttempts"].ToString();

                        }


                        if (objBECommon.DsResult.Tables[5].Rows.Count > 0)
                        {
                            lblExamLevel.Text = objBECommon.DsResult.Tables[5].Rows[0]["Level"].ToString();

                        }

                        if (objBECommon.DsResult.Tables[6].Rows.Count > 0)
                        {
                            //If exam security is auto-standard, hide Comments , Added By , Added On columns. Github #197 
                            if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["secirtyType"]) == 6)
                            {
                                hideCommentGridColumnsForAutoStandard();
                            }


                            if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["secirtyType"]) == 5 || Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["IsexamiFACE"]) == 1)
                            {
                                tdDesktop.Visible = false;
                                trNonProctorImages.Visible = true;
                                trExamLevel.Visible = false;
                                if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["IsexamiFACE"]) == 1)
                                {
                                    if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["secirtyType"]) == 2)
                                    {
                                        // if (new CommonFunctions().GetVideoVisibleStatus(Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()))))
                                        trVideoPlayer.Visible = true;
                                    }

                                    else
                                        trVideoPlayer.Visible = false;
                                }
                                else
                                    trVideoPlayer.Visible = false;
                                if (objBECommon.DsResult.Tables[6].Rows[0]["studentImageTimeStamp"] != DBNull.Value)
                                    lblPic1TimeStamp.Text = objBECommon.DsResult.Tables[6].Rows[0]["studentImageTimeStamp"].ToString();
                                else
                                    lblPic1TimeStamp.Text = string.Empty;

                                if (objBECommon.DsResult.Tables[6].Rows[0]["studentIDImageTimeStamp"] != DBNull.Value)

                                    lblPic2TimeStamp.Text = objBECommon.DsResult.Tables[6].Rows[0]["studentIDImageTimeStamp"].ToString();
                                else
                                    lblPic2TimeStamp.Text = string.Empty;

                                if (objBECommon.DsResult.Tables[6].Rows[0]["StudentImage"].ToString() != "" && objBECommon.DsResult.Tables[6].Rows[0]["StudentImage"] != null)
                                    imgPLExamPic.Src = "data:image/png;base64," + Convert.ToBase64String(objBECommon.DsResult.Tables[6].Rows[0]["StudentImage"] as byte[]);
                                else
                                    imgPLExamPic.Src = "~/Images/noimage.jpg";
                                if (objBECommon.DsResult.Tables[6].Rows[0]["StudentIDImage"].ToString() != "" && objBECommon.DsResult.Tables[6].Rows[0]["StudentIDImage"] != null)
                                    imgPLExamPic1.Src = "data:image/png;base64," + Convert.ToBase64String(objBECommon.DsResult.Tables[6].Rows[0]["StudentIDImage"] as byte[]);
                                else
                                    imgPLExamPic1.Src = "~/Images/noimage.jpg";

                            }
                            else
                            {
                                trNonProctorImages.Visible = false;
                                tdDesktop.Visible = true;
                                trExamLevel.Visible = true;
                                trVideoPlayer.Visible = true;

                            }
                            //if (objBECommon.DsResult.Tables[6].Rows[0][0] != null && objBECommon.DsResult.Tables[6].Rows[0][1] != null)
                            //{
                            //    //System.Drawing.Image image1= getImage(objBECommon.DsResult.Tables[6].Rows[0][0]  as byte[]);
                            //    //System.Drawing.Image image2 = getImage(objBECommon.DsResult.Tables[6].Rows[0][1] as byte[]);
                            //    trNonProctorImages.Visible = true;
                            //    //imgpic1.ImageUrl = image1.ToString();
                            //    //imgpic2.ImageUrl = image2.ToString();

                            //    imgPLExamPic.Src = "data:image/png;base64," + Convert.ToBase64String(objBECommon.DsResult.Tables[6].Rows[0][0] as byte[]);
                            //    imgPLExamPic1.Src = "data:image/png;base64," + Convert.ToBase64String(objBECommon.DsResult.Tables[6].Rows[0][1] as byte[]);
                            //    tdDesktop.Visible = false;

                            //}
                            //else
                            //{
                            //    trNonProctorImages.Visible = false;
                            //    tdDesktop.Visible = true;
                            //}

                        }



                    }

                }
                //if (Request.QueryString["Type"] != null)
                //{
                //    btnApprove.Visible = false;
                //    btnReject.Visible = false;
                //}
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public string getStreamURL(string StreamType)
        {
            if (StreamType == "Voice")
                return System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + "Voice/" + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".wav";
            else
                return System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + StreamType + "/" + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".avi";
        }
        public string getPlayer(string StreamType)
        {


            StringBuilder strMediaPlayer = new StringBuilder();
            //string path = System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".mp4";
            //GetURL();
            string path = streamingurl;

            strMediaPlayer.AppendLine("<video id='myvideo' width='880' height='600' controls>");
            strMediaPlayer.AppendLine("<source type='video/mp4' src=" + path + ">");
            strMediaPlayer.AppendLine("</video>");
            return strMediaPlayer.ToString();
        }

        public System.Drawing.Image getImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;

        }
        #endregion

        #region BindTransactionsComments
        protected void BindTransactionsComments()
        {
            try
            {
                //if (Request.QueryString["TransID"] != null)
                //{

                //    BCommon objBCommon = new BCommon();
                //    BECommon objBECommon = new BECommon();
                //    objBECommon.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                //    objBCommon.BGetTransactionComments(objBECommon);
                //    gvComments.DataSource = objBECommon.DtResult;
                //}
                if (Request.QueryString["TransID"] != null)
                {
                    gvComments.DataSource = null;
                    BCommon objBCommon = new BCommon();
                    BECommon objBECommon = new BECommon();
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBCommon.BGetTransactionComments(objBECommon);
                    if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                        gvComments.DataSource = objBECommon.DtResult;
                    else
                        gvComments.DataSource = new object[] { };


                }
            }
            catch (Exception Ex)
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Type"] == "View")
                {
                    Response.Redirect("AdminExamStatus.aspx", false);

                }

                if (Request.QueryString["Type"] == "View1")
                {

                    Response.Redirect("AdminViewUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + Session[BaseClass.EnumPageSessions.StudentID].ToString()), false);

                }

                if (Request.QueryString["Type"] == "View2")
                {

                    Response.Redirect("ViewStudent.aspx?StudentID=" + Request.QueryString["StudentID"], false);

                }

            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }

        public string isAllowAttemptsFeatured()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBCommon.BGetClientDetails(objBECommon);

            return objBECommon.DsResult.Tables[0].Rows[0]["MaxAttemptsFeatured"].ToString();
        }

        protected void gvexamdetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            this.BindExamDetails();

        }

        private void hideCommentGridColumnsForAutoStandard(){
            gvComments.MasterTableView.GetColumn("Comments").Display = false;
            gvComments.MasterTableView.GetColumn("AddedBy").Display = false;
            gvComments.MasterTableView.GetColumn("AddedOn").Display = false;
        }
    }
}