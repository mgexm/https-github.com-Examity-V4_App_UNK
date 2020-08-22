using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using Telerik.Web.UI;
using System.Configuration;
using System.Net;

namespace SecureProctor.Auditor
{
    public partial class ExamDetails : BaseClass
    {
        string streamingurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetURL();
            RequiredFieldValidator11.Enabled = false;
            RequiredFieldValidator11.ValidationGroup = string.Empty;


            if (Request.QueryString["Type"] != null)
            {
                ((LinkButton)this.Page.Master.FindControl("lnkProcessedExamRequests")).CssClass = "main_menu_active";
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
            else
            {
                ((LinkButton)this.Page.Master.FindControl("lnkInbox")).CssClass = "main_menu_active";
                btnApprove.Visible = true;
                btnReject.Visible = true;
            }
            if (!IsPostBack)
            {
                // lblTools.Visible = false;
                //imgCalc.Visible = false;
                // imgStickyNotes.Visible = false;
                if (Request.QueryString["TransID"] != null)
                {
                    Session[BaseClass.EnumPageSessions.TransID] = Request.QueryString["TransID"].ToString();
                }
                else
                    Session[BaseClass.EnumPageSessions.TransID] = null;

                // this.LoadData();
                // this.BindAlerts();

                // this.GetCommentsType();
                //this.BindExamDetails();
                //tdWebcam.InnerHtml = getPlayer("Webcam");
                tdDesktop.InnerHtml = getPlayer("Desktop");
                ////tdDesktop.InnerHtml = getPlayer("Desktop");
                //RadMediaPlayer1.TitleBar.ShareButton.Visible = false;
                //RadMediaPlayer1.ToolBar.Visible = true;
                //RadMediaPlayer1.ToolbarDocked = true;
                //RadMediaPlayer1.ToolBar.HDButton.Visible = false;
                //RadMediaPlayer1.Source = System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".mp4";
                this.BindDropDowns();
                //tdVoice.InnerHtml = getPlayer("Voice");
                // BindProctorreviewDetails();
            }

            this.GetStudentUploadFileStatus();
            if (Request.QueryString["TransID"] != null)
            {
                this.getExamFileUploadStatus();

            }


            if (ddlAlerts.Items.Count > 0)
            {
                // if (ddlAlerts.SelectedItem.Text.ToUpper() == "OTHER")
                txtComments.Visible = true;
                //else
                //    txtComments.Visible = false;
            }
            else
                txtComments.Visible = false;
        }


        protected void BindDropDowns()
        {
            DataTable dtHrs = GetHrsTable();
            DataTable dtMin = GetMinTable();
            DataTable dtSec = GetSecTable();
            ddlHours.DataSource = dtHrs;
            ddlHours.DataTextField = "Hrs";
            ddlHours.DataValueField = "Hrs";
            ddlHours.DataBind();
            ddlMinutes.DataSource = dtMin;
            ddlMinutes.DataTextField = "Min";
            ddlMinutes.DataValueField = "Min";
            ddlMinutes.DataBind();
            ddlsec.DataSource = dtSec;
            ddlsec.DataTextField = "Sec";
            ddlsec.DataValueField = "Sec";
            ddlsec.DataBind();



        }
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

        public static DataTable GetHrsTable()
        {
            DataTable dtHrs = new DataTable();
            DataRow dr;
            dtHrs.Columns.Add("Hrs", typeof(string));
            //
            dr = dtHrs.NewRow();
            dr["Hrs"] = "Hours";
            dtHrs.Rows.Add(dr);
            dr = dtHrs.NewRow();
            dr["Hrs"] = "0";
            dtHrs.Rows.Add(dr);
            //
            for (int i = 1; i <= 23; i++)
            {
                dr = dtHrs.NewRow();
                dr["Hrs"] = i.ToString("D1");
                dtHrs.Rows.Add(dr);
            }
            dtHrs.AcceptChanges();
            return dtHrs;
        }
        public static DataTable GetMinTable()
        {
            DataTable dtMin = new DataTable();
            DataRow dr;
            dtMin.Columns.Add("Min", typeof(string));
            //
            dr = dtMin.NewRow();
            dr["Min"] = "Minutes";
            dtMin.Rows.Add(dr);

            dr = dtMin.NewRow();
            dr["Min"] = "00";
            dtMin.Rows.Add(dr);
            //
            for (int i = 1; i <= 59; i = i + 1)
            {
                dr = dtMin.NewRow();
                dr["Min"] = i.ToString("D2");
                dtMin.Rows.Add(dr);
            }
            dtMin.AcceptChanges();
            return dtMin;
        }

        public static DataTable GetSecTable()
        {
            DataTable dtSec = new DataTable();
            DataRow dr;
            dtSec.Columns.Add("Sec", typeof(string));
            //
            dr = dtSec.NewRow();
            dr["Sec"] = "Seconds";
            dtSec.Rows.Add(dr);

            dr = dtSec.NewRow();
            dr["Sec"] = "00";
            dtSec.Rows.Add(dr);
            //
            for (int i = 1; i <= 59; i = i + 1)
            {
                dr = dtSec.NewRow();
                dr["Sec"] = i.ToString("D2");
                dtSec.Rows.Add(dr);
            }
            dtSec.AcceptChanges();
            return dtSec;
        }

        protected void GetStudentUploadFileStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStudentUploadFileStatus(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (objBECommon.DtResult.Rows[0][0].Equals(true))
                    ucUploadFiles.Visible = true;
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
        #region BindTransactionsComments
        protected void BindTransactionsComments()
        {
            try
            {
                if (Request.QueryString["TransID"] != null)
                {

                    BCommon objBCommon = new BCommon();
                    BECommon objBECommon = new BECommon();
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBCommon.BGetTransactionComments(objBECommon);
                    gvComments.DataSource = objBECommon.DtResult;

                    ViewState["ALERTS"] = objBECommon.DtResult;


                }

            }

            catch (Exception Ex)
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion

        protected void BindAlerts()
        {
            try
            {


                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = 4;
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();
            }
            catch
            {
            }
        }

        protected void ddlFlags_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(ddlFlags.SelectedValue.ToString()))
            {
                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = Convert.ToInt32(ddlFlags.SelectedValue.ToString());
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();
                txtComments.Visible = true;

            }
            else
            {
                txtComments.Visible = false;
                ddlAlerts.Items.Clear();
            }

            //if (ddlFlags.SelectedIndex == 0)
            //{
            //    txtComments.Visible = false;
            //}
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
                if (Session[BaseClass.EnumPageSessions.TransID] != null)
                {

                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBECommon.DsResult = new DataSet();
                    objBCommon.BGetStudentExamDetails(objBECommon);
                    if (objBECommon.DsResult != null)
                    {
                        if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
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

                            // img.ImageUrl = "~/Student\\Student_Identity\\" + objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                            img.ImageUrl = new AppSecurity().ImageToBase64(objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                            img.ImageAlign = ImageAlign.Top;


                        }


                        //if (objBECommon.DsResult.Tables[4].Rows.Count > 0)
                        //{
                        //    lblExamProviderName.Text = objBECommon.DsResult.Tables[4].Rows[0]["ExamProviderName"].ToString();
                        //    lblExamProviderNameEmailAddress.Text = objBECommon.DsResult.Tables[4].Rows[0]["EmailAddress"].ToString();

                        //}

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
                                //   trExamiKEY.Visible = true;
                                if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["IsexamiFACE"]) == 1)
                                {
                                    if (new CommonFunctions().GetVideoVisibleStatus(Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()))))
                                        trVideoPlayer.Visible = true;
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
                                // trExamiKEY.Visible = false;
                                trVideoPlayer.Visible = true;
                            }
                        }
                    }

                }
                //if (Request.QueryString["Type"] != null)
                //{
                //    btnApprove.Visible = false;
                //    btnReject.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getPlayer(string StreamType)
        {
            StringBuilder strMediaPlayer = new StringBuilder();
            string path = System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".mp4";
            //GetURL();
            //string path = streamingurl;

            //string path = System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + "990010" + ".mp4";
            strMediaPlayer.AppendLine("<video id='myvideo' width='880' height='600' controls>");
            strMediaPlayer.AppendLine("<source type='video/mp4' src=" + path + ">");
            strMediaPlayer.AppendLine("</video>");
            return strMediaPlayer.ToString();
        }
        #endregion

        //#region Approve/Reject
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AuditorConfirmation.aspx?type=1&" + Request.QueryString.ToString(), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AuditorConfirmation.aspx?type=0&" + Request.QueryString.ToString(), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region AddComments


        protected void btnAddComments_Click(object sender, EventArgs e)
        {
            try
            {
                BCommon objBCommon = new BCommon();
                BECommon objBECommon = new BECommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBECommon.StrComments = txtComments.Text.ToString();
                objBECommon.StrddlComments = ddlFlags.SelectedValue.ToString();
                objBECommon.intAlertID = Convert.ToInt32(ddlAlerts.SelectedValue.ToString());
                string TimeChoosed = string.Empty;
                if (ddlHours.SelectedIndex != 0 && ddlHours.SelectedIndex != 1)
                {
                    TimeChoosed = ddlHours.SelectedValue.ToString();

                    if (ddlMinutes.SelectedIndex != 0)
                        TimeChoosed = TimeChoosed + ":" + ddlMinutes.SelectedValue.ToString();
                    else
                        TimeChoosed = TimeChoosed + ":00";

                    if (ddlsec.SelectedIndex != 0)
                        TimeChoosed = TimeChoosed + ":" + ddlsec.SelectedValue.ToString();
                    else
                        TimeChoosed = TimeChoosed + ":00";

                }
                else if (ddlMinutes.SelectedIndex != 0 && ddlMinutes.SelectedIndex != 1)
                {
                    TimeChoosed = "00:" + ddlMinutes.SelectedValue.ToString();
                    if (ddlsec.SelectedIndex != 0)
                        TimeChoosed = TimeChoosed + ":" + ddlsec.SelectedValue.ToString();
                    else
                        TimeChoosed = TimeChoosed + ":00";


                }
                else if (ddlsec.SelectedIndex != 0 && ddlsec.SelectedIndex != 1)
                {
                    TimeChoosed = "00:00:" + ddlsec.SelectedValue.ToString();

                }
                else
                {
                    TimeChoosed = string.Empty;
                }

                objBECommon.strTime = TimeChoosed;

                objBCommon.BAddComments(objBECommon);
                objBECommon = null;
                objBECommon = null;
                txtComments.Text = string.Empty;
                gvComments.Rebind();
                ddlFlags.SelectedValue = "-1";
                ddlHours.SelectedIndex = 0;
                ddlMinutes.SelectedIndex = 0;
                ddlsec.SelectedIndex = 0;
                //txtComments.Visible = false;
                ddlAlerts.Items.Clear();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlAlerts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
            {
                txtComments.Text = string.Empty;
                txtComments.Visible = true;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator11.ValidationGroup = "Add";
            }
            else
            {
                txtComments.Visible = false;
                txtComments.Text = string.Empty;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator11.ValidationGroup = string.Empty;
            }
        }
        //protected int getSelectFlag()
        //{
        //    int i = 1;
        //    if (rdGreen.Checked == true)
        //        i = 1;
        //    else if (rdOrange.Checked == true)
        //        i = 2;
        //    else if (rdRed.Checked == true)
        //        i = 3;
        //    else if (rdAlert.Checked == true)
        //        i = 4;
        //    return i;
        //}


        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtComments.Text = string.Empty;
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["Type"] == "ViewDetails" & Request.QueryString["TransID"] != null)
                {
                    string a = Session[BaseClass.EnumPageSessions.StudentID].ToString();
                    //Response.Redirect("~/Auditor/ViewStudentDetails.aspx?Type=P&StudentID=" + AppSecurity.Encrypt(Session[BaseClass.EnumPageSessions.StudentID].ToString()), false);
                    Response.Redirect("ViewStudentDetails.aspx?Type=P&" + AppSecurity.Encrypt("StudentID=" + Session[BaseClass.EnumPageSessions.StudentID].ToString()), false);
                }

                else if (Request.QueryString["Type"] == "View" & Request.QueryString["TransID"] != null)
                {

                    Response.Redirect("~/Auditor/ProcessedExamRequests.aspx", false);

                }

                else if (Request.QueryString["TransID"] != null)
                {
                    Response.Redirect(BaseClass.EnumAppPage.AUDITOR_INBOX);

                }


            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }

        #endregion



        protected void gvComments_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "EDIT")
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }

        }

        protected void gvComments_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DataTable objDT = (DataTable)ViewState["ALERTS"];
            if (e.CommandName == "DELETE")
            {
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    if (e.CommandArgument.ToString() == objDT.Rows[i][0].ToString())
                    {
                        objDT.Rows.RemoveAt(i);
                        objDT.AcceptChanges();
                        BECommon objBECommon = new BECommon();
                        BCommon objBCommon = new BCommon();
                        objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        objBECommon.intTypeID = 0;
                        objBECommon.intCommentID = Convert.ToInt32(e.CommandArgument);
                        objBECommon.StrComments = string.Empty;
                        objBECommon.strCommentID = string.Empty;
                        objBCommon.BDeleteUpdateAlerts(objBECommon);


                    }
                    ViewState["ALERTS"] = objDT;
                    gvComments.DataSource = objDT;
                    gvComments.DataBind();
                }


            }
        }



        protected void gvComments_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "UPDATE")
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)e.Item.FindControl("txtRuleDescription");
                DataTable objDT = (DataTable)ViewState["ALERTS"];

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.intTypeID = 1;
                objBECommon.intCommentID = Convert.ToInt32(e.CommandArgument);
                objBECommon.StrComments = txt.Text.Trim();
                objBCommon.BDeleteUpdateAlerts(objBECommon);
                ViewState["ALERTS"] = objDT;
                gvComments.DataSource = objDT;
                gvComments.DataBind();
                BindTransactionsComments();
            }
        }

        protected void gvComments_CancelCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "CANCEL")
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }

        }

        public string isAllowAttemptsFeatured()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBCommon.BGetClientDetails(objBECommon);

            return objBECommon.DsResult.Tables[0].Rows[0]["MaxAttemptsFeatured"].ToString();
        }

        protected void gvComments_ItemDataBound(object sender, GridItemEventArgs e)
        {


            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                string CommentText = ((DataRowView)e.Item.DataItem)["Comments"].ToString();
                ImageButton img = (ImageButton)item.FindControl("ImgDelete");
                ImageButton imgEdit = (ImageButton)item.FindControl("ImgEdit");

                if (CommentText.ToString().Trim() == "Reviewed by Auditor")
                {

                    img.Visible = false;
                    imgEdit.Visible = false;

                }


            }

        }

        protected void gvexamdetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            this.BindExamDetails();

        }

        protected void btnDeleteAlerts_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                string strAlertID = "";
                foreach (GridDataItem item in gvComments.SelectedItems)
                {
                    DataRow[] dr = objDT.Select(" CommentID=" + item.GetDataKeyValue("CommentID").ToString());
                    objDT.Rows.Remove(dr[0]);
                    objDT.AcceptChanges();
                    if (strAlertID.Length == 0)
                        strAlertID = item.GetDataKeyValue("CommentID").ToString();
                    else
                        strAlertID = strAlertID + "," + item.GetDataKeyValue("CommentID").ToString();
                }

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.intTypeID = 0;
                objBECommon.strCommentID = strAlertID;
                objBECommon.StrComments = string.Empty;
                objBCommon.BDeleteUpdateAlerts(objBECommon);
                ViewState["ALERTS"] = objDT;
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }
            catch
            {
            }
        }

        private void hideCommentGridColumnsForAutoStandard()
        {
            gvComments.MasterTableView.GetColumn("Comments").Display = false;
            gvComments.MasterTableView.GetColumn("AddedBy").Display = false;
            gvComments.MasterTableView.GetColumn("AddedOn").Display = false;
        }
    }
}