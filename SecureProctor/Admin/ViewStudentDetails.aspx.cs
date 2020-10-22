using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Admin
{
    public partial class ViewStudentDetails : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                //((LinkButton)this.Page.Master.FindControl("lnkStudents")).CssClass = "main_menu_active";
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";

                if (!IsPostBack)
                {
                    if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    {

                        BEAdmin objBEAdmin = new BEAdmin();
                        BAdmin objBAdmin = new BAdmin();
                        objBEAdmin.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["UserID"].ToString()));
                        objBAdmin.BViewStudentDetails(objBEAdmin);
                        if (objBEAdmin.DtResult != null)
                        {
                            if (objBEAdmin.DtResult.Rows.Count > 0)
                            {

                                if (Request.QueryString["Type"].ToString() == "Edit")
                                {
                                    this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Editstudentdetails;
                                    this.EnableDisable("Edit");
                                    GetStudentDeetails();
                                }


                                else if (Request.QueryString["Type"].ToString() == "View")
                                {
                                    this.Page.Title = EnumPageTitles.APPNAME +EnumPageTitles.Viewstudentdetails;
                                    this.EnableDisable("View");
                                    lblFirstName.Text = objBEAdmin.DtResult.Rows[0]["FirstName"].ToString();
                                    lblLastName.Text = objBEAdmin.DtResult.Rows[0]["LastName"].ToString();
                                    lblEmailAddress.Text = objBEAdmin.DtResult.Rows[0]["EmailAddress"].ToString();
                                    lblPhoneNumber.Text = objBEAdmin.DtResult.Rows[0]["PhoneNumber"].ToString();
                                    lblTimeZone.Text = objBEAdmin.DtResult.Rows[0]["TimeZone"].ToString();
                                    lblSpecialNeeds.Text = objBEAdmin.DtResult.Rows[0]["SpecialNeeds"].ToString();
                                    lblComments.Text = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();


                                }
                                else if (Request.QueryString["Type"].ToString() == "Delete")
                                {
                                    this.Page.Title = EnumPageTitles.APPNAME +EnumPageTitles.Deletedeletedetails;
                                    this.EnableDisable("Delete");
                                    lblFirstName.Text = objBEAdmin.DtResult.Rows[0]["FirstName"].ToString();
                                    lblLastName.Text = objBEAdmin.DtResult.Rows[0]["LastName"].ToString();
                                    lblEmailAddress.Text = objBEAdmin.DtResult.Rows[0]["EmailAddress"].ToString();
                                    lblPhoneNumber.Text = objBEAdmin.DtResult.Rows[0]["PhoneNumber"].ToString();
                                    lblTimeZone.Text = objBEAdmin.DtResult.Rows[0]["TimeZone"].ToString();
                                    lblSpecialNeeds.Text = objBEAdmin.DtResult.Rows[0]["SpecialNeeds"].ToString();
                                    lblComments.Text = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();
                                }
                            } 
                        }
                    }
                }
            }
            catch (Exception )
            {

            }
        }
        protected void BindTimeZone(int studentid)
        {

            try
            {
                try
                {
                    BUser objBUser = new BUser();
                    BEUser objBEUser = new BEUser();
                    objBEUser.IntUserID = studentid;
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

                        //ddlTimeZone.SelectedValue = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString();
                        ddlTimeZone.FindItemByValue(objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString().Trim()).Selected = true;

                        lblTimeZone.Text = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone2"].ToString();


                    }
                }
                catch (Exception )
                {
                    // ErrorLog.WriteError(Ex);
                }
            }
            catch (Exception )
            {
                //ErrorLog.WriteError(Ex);
            }

        }
        protected void EnableDisable(string Type)
        {
            switch (Type)
            {
                case "Edit":
                    lblFirstName.Visible = false;
                    txtFirstName.Visible = true;
                    lblLastName.Visible = false;
                    txtStudentLastName.Visible = true;
                    lblPhoneNumber.Visible = false;
                    txtPhoneNumber.Visible = true;
                    lblEmailAddress.Visible = false;
                    txtEmailAddress.Visible = true;
                    lblTimeZone.Visible = false;
                    ddlTimeZone.Visible = true;
                    lblSpecialNeeds.Visible = false;
                    ddlSpecialNeeds.Visible = true;
                    lblSpecialNeeds.Visible = false;
                    trEditButton.Visible = true;
                    trDeleteButton.Visible = false;
                    trViewButton.Visible = false;
                    trMessage.Visible = false;
                    txtcomments.Visible = true;
                    lblComments.Visible = false;

                    break;
                case "View":
                    lblFirstName.Visible = true;
                    txtFirstName.Visible = false;
                    lblLastName.Visible = true;
                    txtStudentLastName.Visible = false;
                    lblPhoneNumber.Visible = true;
                    txtPhoneNumber.Visible = false;
                    lblEmailAddress.Visible = true;
                    txtEmailAddress.Visible = false;
                    lblTimeZone.Visible = true;
                    ddlTimeZone.Visible = false;
                    lblSpecialNeeds.Visible = true;
                    ddlSpecialNeeds.Visible = false;
                    lblSpecialNeeds.Visible = true;
                    trEditButton.Visible = false;
                    trDeleteButton.Visible = false;
                    trViewButton.Visible = true;
                    trMessage.Visible = false;
                    txtcomments.Visible = false;
                    lblComments.Visible = true;
                    break;
                case "Delete":
                    lblFirstName.Visible = true;
                    txtFirstName.Visible = false;
                    lblLastName.Visible = true;
                    txtStudentLastName.Visible = false;
                    lblPhoneNumber.Visible = true;
                    txtPhoneNumber.Visible = false;
                    lblEmailAddress.Visible = true;
                    txtEmailAddress.Visible = false;
                    lblTimeZone.Visible = true;
                    ddlTimeZone.Visible = false;
                    lblSpecialNeeds.Visible = true;
                    ddlSpecialNeeds.Visible = false;
                    lblSpecialNeeds.Visible = true;
                    trEditButton.Visible = false;
                    trDeleteButton.Visible = true;
                    trViewButton.Visible = false;
                    trMessage.Visible = false;
                    txtcomments.Visible = false;
                    lblComments.Visible = true;
                    break;




            }
        }


        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEProvider objBEExamProvider = new BEProvider();

                BProvider objBExamProvider = new BProvider();

                objBEExamProvider.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["UserID"].ToString()));

                objBEExamProvider.strFirstName = txtFirstName.Text;

                objBEExamProvider.strLastName = txtStudentLastName.Text;

                objBEExamProvider.strEmailAddress = txtEmailAddress.Text;

                objBEExamProvider.strPhoneNumber = txtPhoneNumber.Text;

                objBEExamProvider.strTimeZone = ddlTimeZone.SelectedValue;

                objBEExamProvider.strSpecialNeeds1 = ddlSpecialNeeds.SelectedValue;

                objBEExamProvider.StrComments = txtcomments.Value;

                objBExamProvider.BUpdateStudentDetails(objBEExamProvider);

                if (objBEExamProvider.IntResult == 1)
                {
                    trMessage.Visible = true;
                    trEditButton.Visible = false;
                    lblFirstName.Visible = true;
                    txtFirstName.Visible = false;
                    lblLastName.Visible = true;
                    txtStudentLastName.Visible = false;
                    lblPhoneNumber.Visible = true;
                    txtPhoneNumber.Visible = false;
                    lblEmailAddress.Visible = true;
                    txtEmailAddress.Visible = false;
                    lblTimeZone.Visible = true;
                    ddlTimeZone.Visible = false;
                    lblSpecialNeeds.Visible = true;
                    ddlSpecialNeeds.Visible = false;
                    lblSpecialNeeds.Visible = true;
                    trEditButton.Visible = false;
                    trDeleteButton.Visible = false;
                    trViewButton.Visible = true;
                    lblComments.Visible = true;
                    txtcomments.Visible = false;
                    lblMessage.Text = Resources.ResMessages.Provider_StudentUpdateSuccess;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    BindTimeZone(objBEExamProvider.IntStudentID);
                    GetStudentDeetails();
                }

                else
                {

                    lblMessage.Text = Resources.ResMessages.Provider_StudentUpdateFail;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudent.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudent.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            BEProvider objBEProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEProvider.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["UserID"].ToString()));
            objBProvider.BDeleteStudent(objBEProvider);

            if (objBEProvider.DsResult != null && objBEProvider.DsResult.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(objBEProvider.DsResult.Tables[0].Rows[0][0]))
                {
                    trMessage.Visible = true;
                    trDeleteButton.Visible = false;
                    trViewButton.Visible = true;
                    
                    lblMessage.Text = Resources.ResMessages.Provider_UserDelSuccess;
                }
                else
                {

                    //trMessage.Visible = false;
                    trMessage.Visible = true;
                    trDeleteButton.Visible = false;
                    trViewButton.Visible = true;
                   
                    lblMessage.Text = Resources.ResMessages.Provider_UserDelPending;
                }

            }

            else
            {

                trDeleteButton.Visible = false;
                trViewButton.Visible = true;
                lblMessage.Text = Resources.ResMessages.Provider_UserDelFail;
            }

        }

        protected void GetStudentDeetails()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["UserID"].ToString()));
            objBAdmin.BViewStudentDetails(objBEAdmin);
            if (objBEAdmin.DtResult != null)
            {
                if (objBEAdmin.DtResult.Rows.Count > 0)
                {
  

                    this.BindTimeZone(objBEAdmin.IntStudentID);

                    lblFirstName.Text = objBEAdmin.DtResult.Rows[0]["FirstName"].ToString();
                    txtFirstName.Text = objBEAdmin.DtResult.Rows[0]["FirstName"].ToString();
                    lblLastName.Text = objBEAdmin.DtResult.Rows[0]["LastName"].ToString();
                    txtStudentLastName.Text = objBEAdmin.DtResult.Rows[0]["LastName"].ToString();
                    lblEmailAddress.Text = objBEAdmin.DtResult.Rows[0]["EmailAddress"].ToString();
                    txtEmailAddress.Text = objBEAdmin.DtResult.Rows[0]["EmailAddress"].ToString();
                    lblPhoneNumber.Text = objBEAdmin.DtResult.Rows[0]["PhoneNumber"].ToString();
                    txtPhoneNumber.Text = objBEAdmin.DtResult.Rows[0]["PhoneNumber"].ToString();
                    lblTimeZone.Text = objBEAdmin.DtResult.Rows[0]["TimeZone"].ToString();
                    lblSpecialNeeds.Text = objBEAdmin.DtResult.Rows[0]["SpecialNeeds"].ToString();

                   // lblComments.Text = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();

                  //  txtcomments.Value = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();
                 
                    string SpecialNeeds = objBEAdmin.DtResult.Rows[0]["SpecialNeeds"].ToString();
                    if (SpecialNeeds == "Yes")
                    {
                        trcomments.Visible = true;
                        if (objBEAdmin.DtResult.Rows[0]["Comments"] != DBNull.Value)
                        {
                            lblComments.Text = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();
                            txtcomments.Value = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();
                        }
                        ddlSpecialNeeds.SelectedValue = "1";
                    }
                    else if (SpecialNeeds == "No")
                    {
                        trcomments.Visible = false;
                        ddlSpecialNeeds.SelectedValue = "0";
                    }

                   
                   

                  
                }

            }
        }

        protected void ddlSpecialNeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSpecialNeeds.SelectedItem.Value == "1")
            {
                trcomments.Visible = true;
            }
            else if (ddlSpecialNeeds.SelectedItem.Value == "0")
            {
                trcomments.Visible = false;
                txtcomments.Value = "";
            }
        }

    }
}
    