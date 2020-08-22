using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Provider
{
    public partial class MyProfile : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           lblUpdated.Visible = true;
            
           txtCurrentPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblUpdated.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
           txtNewPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblUpdated.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
           txtConfirmNewPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblUpdated.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");

            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.MYPROFILE;
            ((LinkButton)this.Page.Master.FindControl("lnkProfile")).CssClass = "main_menu_active";

            if (!IsPostBack)
            {
                tdEditTimeZon.Visible = true;
                tdSaveTimeZone.Visible = false;
                lblTimeZone.Visible = true;
                ddlTimeZone.Visible = false;
                this.BindDemographicDetails();
                BindTimeZone();
                //BindGender();
                GetSSOStatus();

            }
        }

        //#region BindGender
        //protected void BindGender()
        //{
        //    try
        //    {
        //        BECommon objBECommon = new BECommon();

        //        BCommon objBCommon = new BCommon();

        //        objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

        //        objBCommon.BGenderList(objBECommon);

        //        if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
        //        {
        //            ddlGender.Items.Clear();
        //            ddlGender.DataValueField = "GenderID";
        //            ddlGender.DataTextField = "GenderName";
        //            ddlGender.DataSource = objBECommon.DsResult.Tables[0];
        //            ddlGender.DataBind();
        //        }

        //        if (objBECommon.DsResult.Tables[1].Rows.Count > 0)
        //        {
        //            lblGender.Text = objBECommon.DsResult.Tables[1].Rows[0]["GenderName"].ToString();
        //            ddlGender.SelectedValue = objBECommon.DsResult.Tables[1].Rows[0]["GenderID"].ToString();


        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        //  ErrorLog.WriteError(Ex);
        //    }
        //}
        //#endregion

        protected void BindTimeZone()
        {

            try
            {
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();

                objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBUser.BGetTimeZone(objBEUser);
                if (objBEUser.DsResult.Tables[0].Rows.Count > 0)
                {
                    ddlTimeZone.Items.Clear();
                    ddlTimeZone.DataValueField = "id";
                    ddlTimeZone.DataTextField = "TimeZone";
                    ddlTimeZone.DataSource = objBEUser.DsResult.Tables[0];
                    ddlTimeZone.DataBind();
                }

                if (objBEUser.DsResult.Tables[1].Rows.Count > 0)
                {
                    //lblTimeZone.Text = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone2"].ToString();
                    if (objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString() != "0")
                        lblTimeZone.Text = CommonFunctions.CheckNullValue(objBEUser.DsResult.Tables[1].Rows[0]["TimeZone2"].ToString());

                    else
                        lblTimeZone.Text = "Please select time zone";
                    ddlTimeZone.SelectedValue = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString().Trim();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void BindDemographicDetails()
        {
            BEUser objBEUser = new BEUser();
            BUser objBUser = new BUser();
            objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

            objBUser.BGetProfileDetails(objBEUser);

            if (objBEUser.DtResult.Rows.Count > 0)
            {

                lblFirstName.Text = objBEUser.DtResult.Rows[0]["FirstName"].ToString();
                txtFirstName.Text = objBEUser.DtResult.Rows[0]["FirstName"].ToString();
                lblLastName.Text = objBEUser.DtResult.Rows[0]["LastName"].ToString();
                txtLastName.Text = objBEUser.DtResult.Rows[0]["LastName"].ToString();
                lblEmail.Text = objBEUser.DtResult.Rows[0]["EmailAddress"].ToString();
                txtEmail.Text = objBEUser.DtResult.Rows[0]["EmailAddress"].ToString();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();
                objBEUser.strOldPassword = txtCurrentPassword.Text;
                objBEUser.strNewPassword = txtNewPassword.Text;
                objBEUser.strConfirmNewPassword = txtConfirmNewPassword.Text;
                objBEUser.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBEUser.StrUserName = Session["EmailID"].ToString();

                objBUser.BChangePassword(objBEUser);

                if (objBEUser.IntResult == 0)
                {

                  //  lblUpdated.Text = "Password Updated Successfully";
                    lblUpdated.Text = Resources.ResMessages.MyProfile_PasswordUpdateSuccess;
                    lblsucc.Visible = false;
                    try
                    {

                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = objBEUser.IntUserID;
                        objBEMail.IntTransID = 0;
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.ChangePassword.ToString();

                        objBMail.BSendEmail(objBEMail);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                if (objBEUser.IntResult == 1)
                {
                    //lblUpdated.Text = "Please enter valid Current Password";
                    lblUpdated.Text = Resources.ResMessages.MyProfile_ValidCurrentPassword;
                }
            }
            else
            {
                lblUpdated.Text = string.Empty;

            }
        }


        //protected void btnEditTimeZone_Click(object sender, EventArgs e)
        //{

        //    lblsucc.Text = string.Empty;
        //    tdEditTimeZon.Visible = false;
        //    tdSaveTimeZone.Visible = true;
        //    lblTimeZone.Visible = false;
        //    ddlTimeZone.Visible = true;
        //    BindTimeZone();

        //}
        //protected void btnSaveTimeZone_Click(object sender, EventArgs e)
        //{

        //    BEUser objBEUser = new BEUser();
        //    BUser objBUser = new BUser();

        //    objBEUser.strTimeZone = ddlTimeZone.SelectedValue;
        //    objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

        //    objBUser.BUpdateTimeZone(objBEUser);

        //    if (objBEUser.IntResult == 1)
        //    {
        //        Session["TimeZoneID"] = ddlTimeZone.SelectedValue.ToString();
        //        Session["TimeZone"] = ddlTimeZone.SelectedItem.Text.ToString();
        //        LinkButton lbtnTimeZone = this.Master.FindControl("lbtnTimeZone") as LinkButton;

        //        lbtnTimeZone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
        //        //lblsucc.Text = "Time Zone has been updated successfully.";
        //        lblsucc.Text = Resources.ResMessages.MyProfile_TimeZoneUpdateSuccess;
        //    }
        //    BindTimeZone();
        //    lblTimeZone.Visible = true;
        //    ddlTimeZone.Visible = false;
        //    tdSaveTimeZone.Visible = false;
        //    tdEditTimeZon.Visible = true;

        //}
        //protected void btnCancelTimeZone_Click(object sender, EventArgs e)
        //{
        //    lblTimeZone.Visible = true;
        //    ddlTimeZone.Visible = false;
        //    tdSaveTimeZone.Visible = false;
        //    tdEditTimeZon.Visible = true;
        //    BindTimeZone();
        //}

        protected void btnEditTimeZone_Click(object sender, EventArgs e)
        {

            lblsucc.Text = string.Empty;
            tdEditTimeZon.Visible = false;
            tdSaveTimeZone.Visible = true;
            lblTimeZone.Visible = false;
            txtFirstName.Visible = true;
            txtLastName.Visible = true;
            txtEmail.Visible = true;
            //ddlGender.Visible = true;
            ddlTimeZone.Visible = true;
            lblFirstName.Visible = false;
            lblLastName.Visible = false;
            lblEmail.Visible = false;
            //lblGender.Visible = false;
            BindTimeZone();
            //BindGender();
            BindDemographicDetails();
            //BUser objBUser = new BUser();
            //BEUser objBEUser = new BEUser();
            //objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            //objBUser.BGetTimeZone(objBEUser);
            //if (objBEUser.DsResult.Tables[1].Rows.Count > 0)
            //{

            // ddlTimeZone.SelectedValue = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString();

            //}

          //  lblUpdated.Visible = false;

        }
        protected void btnSaveTimeZone_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BUser objBUser = new BUser();
                BEUser objBEUser = new BEUser();
                objBEUser.StrFirstName = txtFirstName.Text;
                objBEUser.StrLastName = txtLastName.Text;
                objBEUser.StrEmail = txtEmail.Text;
                //objBEUser.StrGender = ddlGender.SelectedValue;

                objBEUser.strTimeZone = ddlTimeZone.SelectedValue;
                objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

                objBUser.BUpdateTimeZone(objBEUser);

                if (objBEUser.IntResult == 1)
                {
                    Session["TimeZoneID"] = ddlTimeZone.SelectedValue.ToString();
                    Session["TimeZone"] = ddlTimeZone.SelectedItem.Text.ToString();
                    LinkButton lbtnTimeZone = this.Master.FindControl("lbtnTimeZone") as LinkButton;
                    //Label lblDate = this.Master.FindControl("lblDate") as Label;

                    //lbtnTimeZone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
                    BECommon objBECommon = new BECommon();
                    BCommon objBCommon = new BCommon();
                    objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                    objBCommon.BGetTimeDelay(objBECommon);
                    //lblDate.Text = "Date: " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString();
                    //lblsucc.Text = "Time Zone has been updated successfully.";
                    string[] strtimezone = Session["TimeZone"].ToString().Split('(');
                    lbtnTimeZone.Text = strtimezone[0].ToString() + " : " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy HH:mm tt");

                    Session["UserName"] = txtFirstName.Text + " " + txtLastName.Text + " [ ExamProvider ]";
                    Label lblUserName = this.Master.FindControl("lblUser") as Label;
                    lblUserName.Text = txtFirstName.Text + " " + txtLastName.Text + " [ ExamProvider ]";

                    //lblsucc.Text = Resources.ResMessages.MyProfile_TimeZoneUpdateSuccess;
                    lblUpdated.Visible = false;
                    lblsucc.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_TimeZoneUpdateSuccess + "</font>";

                }
                else
                {
                    lblsucc.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.MyProfile_TimeZoneUpdateFailed + "</font>";
                }
                BindTimeZone();
                //BindGender();
                BindDemographicDetails();
                lblTimeZone.Visible = true;
                lblFirstName.Visible = true;
                lblLastName.Visible = true;
                lblEmail.Visible = true;
                //lblGender.Visible = true;
                ddlTimeZone.Visible = false;
               // ddlGender.Visible = false;
                txtFirstName.Visible = false;
                txtLastName.Visible = false;
                txtEmail.Visible = false;
                tdSaveTimeZone.Visible = false;
                tdEditTimeZon.Visible = true;
               // Response.Redirect("myprofile.aspx");
            }
        }
        protected void btnCancelTimeZone_Click(object sender, EventArgs e)
        {
            lblTimeZone.Visible = true;
            ddlTimeZone.Visible = false;
            tdSaveTimeZone.Visible = false;
            tdEditTimeZon.Visible = true;
            lblFirstName.Visible = true;
            lblLastName.Visible = true;
            lblEmail.Visible = true;
            //lblGender.Visible = true;
            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtEmail.Visible = false;
            //ddlGender.Visible = false;
            BindTimeZone();
            BindDemographicDetails();
            //BindGender();
            lblUpdated.Visible = false;
        }

        protected void ddlTimeZone_ItemDataBound(object sender, Telerik.Web.UI.RadComboBoxItemEventArgs e)
        {
            Telerik.Web.UI.RadComboBoxItem rdCm = e.Item;
            if (rdCm.Text == "Separator")
            {
                rdCm.Text = "----------------------------------------------";
                rdCm.IsSeparator = true;
            }

        }
        protected void GetSSOStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            //objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetSSOStatus(objBECommon);

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                bool sso = Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["SSO"].ToString());
                if (sso == false)
                {

                    trChangePassword.Visible = true;
                }

                if (sso == true)
                {

                    trChangePassword.Visible = false;
                }
            }
        }
    }
}