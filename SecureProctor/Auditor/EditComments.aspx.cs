using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using BusinessEntities;

namespace SecureProctor.Auditor
{
    public partial class EditComments : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator11.Enabled = false;
            RequiredFieldValidator11.ValidationGroup = string.Empty;
            if (!IsPostBack)
            {
                //DivTextBox.Visible = false;

                BindDropDowns();
                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    this.GetComments();

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Auditor_EditComments;
                this.GetAddedBydropdown();
                trCommentsEdit.Visible = true;
                trCommentsView.Visible = false;
            }

            trMessage.Visible = false;

        }

        protected void GetAddedBydropdown()
        {
            try
            {


                BEAuditor objBEAuditor = new BEAuditor();
                BAuditor objBAuditor = new BAuditor();

                objBAuditor.BGetAddedBy(objBEAuditor);
                ddlAddedBy.DataSource = objBEAuditor.DsResult;
                ddlAddedBy.DataValueField = "UserID";
                ddlAddedBy.DataTextField = "Name";
                ddlAddedBy.DataBind();
            }
            catch
            {
            }

        }

        protected void ddlFlags_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //DivTextBox.Visible = false;
            if (!string.IsNullOrEmpty(ddlFlags.SelectedValue.ToString()))
            {
                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = Convert.ToInt32(ddlFlags.SelectedValue.ToString());
                objBEComon.intCommentID = Convert.ToInt32(Request.QueryString["CommentID"].ToString());
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();

            }
            else
            {
                ddlAlerts.Items.Clear();
            }

            //if (ddlFlags.SelectedIndex == 0)
            //{
            //    txtComments.Visible = false;
            //}
        }


        protected void GetComments()
        {

            BEAuditor objBEAuditor = new BEAuditor();
            BAuditor objBAuditor = new BAuditor();
            objBEAuditor.IntCommentID = Convert.ToInt32(Request.QueryString["CommentID"].ToString());
            objBEAuditor.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBAuditor.BGetComments(objBEAuditor);
            if (objBEAuditor.DsResult != null && objBEAuditor.DsResult.Tables[0].Rows.Count > 0)
            {

                ddlFlags.SelectedValue = objBEAuditor.DsResult.Tables[0].Rows[0]["CommentTypeID"].ToString();

                txtComments.Text = objBEAuditor.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                //if (objBEAuditor.DsResult.Tables[0].Rows[0]["Type"].ToString() != "0")
                //{
                //    txtComments.Text = objBEAuditor.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                //    DivTextBox.Visible = true;

                //}
                //else
                //    DivTextBox.Visible = false;

                if (objBEAuditor.DsResult.Tables[1] != null)
                {
                    ddlAlerts.DataSource = objBEAuditor.DsResult.Tables[1];
                    ddlAlerts.DataValueField = "AlertID";
                    ddlAlerts.DataTextField = "AlertText";
                    ddlAlerts.DataBind();


                }
                ddlAlerts.SelectedValue = objBEAuditor.DsResult.Tables[0].Rows[0]["AlertID"].ToString();

                if (objBEAuditor.DsResult.Tables[0].Rows[0]["AllertImageID"].ToString() != "0")
                {
                    trDeleteImage.Visible = true;
                    lblImage.Text = objBEAuditor.DsResult.Tables[0].Rows[0]["AllertImageID"].ToString();
                }
                else
                    trDeleteImage.Visible = false;

                if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
                {

                    RequiredFieldValidator11.Enabled = true;
                    RequiredFieldValidator11.ValidationGroup = "Edit";
                }
                else
                {
                    RequiredFieldValidator11.Enabled = false;
                    RequiredFieldValidator11.ValidationGroup = string.Empty;
                }


                txtAddedOn.Text = objBEAuditor.DsResult.Tables[0].Rows[0]["AddedOn"].ToString();

                ddlAddedBy.SelectedValue = objBEAuditor.DsResult.Tables[0].Rows[0]["CommenterID"].ToString();

                string CommentTime = string.Empty;
                CommentTime = objBEAuditor.DsResult.Tables[0].Rows[0]["CommentTime"].ToString();
                if (CommentTime != null && CommentTime != string.Empty)
                {
                    char[] separator = { ':' };
                    //string[] time=new string[3];

                    string[] time = CommentTime.Split(separator);

                    ddlHours.SelectedValue = time[0];
                    ddlMinutes.SelectedValue = time[1];
                    ddlsec.SelectedValue = time[2];

                }


                //txtincidenttimestamp.Text = objBEAuditor.DsResult.Tables[0].Rows[0]["CommentTime"].ToString();

            }



        }
        protected void ddlAlerts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
            {
                txtComments.Text = string.Empty;
                //   DivTextBox.Visible = true;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator11.ValidationGroup = "Edit";
            }
            else
            {
                // DivTextBox.Visible = false;
                txtComments.Text = string.Empty;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator11.ValidationGroup = string.Empty;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER" && txtComments.Text == string.Empty)
                {
                    RequiredFieldValidator11.Enabled = true;
                    RequiredFieldValidator11.ValidationGroup = "Edit";
                }
                else
                {
                    BEAuditor objBEAuditor = new BEAuditor();
                    BAuditor objBAuditor = new BAuditor();
                    objBEAuditor.IntCommentID = Convert.ToInt32(Request.QueryString["CommentID"].ToString());
                    objBEAuditor.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBEAuditor.IntAletID = Convert.ToInt32(ddlAlerts.SelectedValue.ToString());
                    //if (DivTextBox.Visible)
                    //{
                    objBEAuditor.StrComments = txtComments.Text;
                    objBEAuditor.IntstatusFlag = 1;

                    //}
                    //else
                    //{
                    //    objBEAuditor.StrComments = ddlAlerts.SelectedValue.ToString();
                    //    objBEAuditor.IntstatusFlag = 0;
                    //}

                    //objBEAuditor.TimeStamp = txtincidenttimestamp.Text;
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


                    objBEAuditor.TimeStamp = TimeChoosed;
                    objBEAuditor.IntFlag = Convert.ToInt32(ddlFlags.SelectedValue);

                    objBEAuditor.strAddedBy = ddlAddedBy.SelectedValue.ToString();

                    objBEAuditor.strAddedOn = Convert.ToDateTime(txtAddedOn.Text);

                    objBAuditor.BUpdateComments(objBEAuditor);

                    trMessage.Visible = true;

                    if (objBEAuditor.IntResult == 1)
                    {

                        lblInfo.Text = Resources.ResMessages.Auditor_Edit_Success_CommentsUpdated;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                        //if (DivTextBox.Visible)
                        //{
                        lblComments.Text = txtComments.Text;
                        //DivTextBox_View.Visible = true;
                        //DivDropdown_View.Visible = false;

                        //}
                        //else
                        //{
                        lblDescription.Text = ddlAlerts.SelectedItem.Text.ToString();
                        //    DivTextBox_View.Visible = false;
                        //    DivDropdown_View.Visible = true;

                        //}


                        lblIncidentTimeStamp.Text = TimeChoosed;

                        lblAddedBy.Text = ddlAddedBy.SelectedItem.Text.ToString();
                        lblAddedOn.Text = txtAddedOn.Text;
                        lblflag.Text = ddlFlags.SelectedItem.Text.ToString();
                        trCommentsEdit.Visible = false;
                        trCommentsView.Visible = true;

                    }

                    else
                    {

                        lblInfo.Text = Resources.ResMessages.Auditor_EditComments_Error_Comments;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);


                    }
                }



            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }



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

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            BEAuditor objBEAuditor = new BEAuditor();
            BAuditor objBAuditor = new BAuditor();
            objBEAuditor.IntCommentID = Convert.ToInt32(Request.QueryString["CommentID"].ToString());
            objBAuditor.BDeleteAlertImage(objBEAuditor);
            objBEAuditor = null;
            objBAuditor = null;
            trDeleteImage.Visible = false;
        }
    }
}