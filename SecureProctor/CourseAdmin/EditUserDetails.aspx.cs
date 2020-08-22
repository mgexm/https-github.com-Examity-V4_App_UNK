using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class EditUserDetails : System.Web.UI.Page
    {
        #region Global Declarations

        string strStudentID = string.Empty;

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSuccess.Visible = false;
            trUpdate.Visible = true;

            ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";

            if (!IsPostBack)
            {
                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                {
                    string strq = Request.QueryString.ToString();
                    string[] qstr = strq.Split('&');
                    string[] strAr = CommonFunctions.UrlDecryptor(Server.UrlDecode(qstr[1].ToString()));

                    foreach (string strItem in strAr)
                    {
                        if (strItem.Contains("StudentID"))
                            strStudentID = strItem.Split('=')[1].ToString();
                        //  ViewState["StudentID"] = strStudentID;
                    }
                }
                if (strStudentID != "")
                {
                    GetStudentEditDetails(int.Parse(strStudentID));
                    BindTimeZone(int.Parse(strStudentID));
                    //  BindGender(int.Parse(strStudentID));
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BECourseAdmin objBEExamProvider = new BECourseAdmin();

                BCourseAdmin objBExamProvider = new BCourseAdmin();

                objBEExamProvider.IntStudentID = Convert.ToInt32(Session["studentid"]);

                objBEExamProvider.strFirstName = lblstudentfirstname.Text;

                objBEExamProvider.strLastName = lblStudentLastName.Text;

                //objBEExamProvider.strGenderName = ddlGender.SelectedValue;

                objBEExamProvider.strEmailAddress = lblEmailID.Text;

                //  objBEExamProvider.strRoleName = lblrole.Text;

                objBEExamProvider.strPhoneNumber = txtPhoneNumber.Text;

                objBEExamProvider.strTimeZone = ddlTimeZone.SelectedValue;

                objBEExamProvider.strSpecialNeeds1 = ddlSpecialNeeds.SelectedValue;

                objBEExamProvider.StrComments = txtcomments.Value;

                objBExamProvider.BUpdateStudentDetails(objBEExamProvider);

                if (objBEExamProvider.IntResult == 1)
                {
                    imgSuccess.Visible = true;
                    trUpdate.Visible = true;
                    EnableDetails();
                    //lblMsg.Text = "Student Details Updated Successfully";
                    lblMsg.Text = Resources.ResMessages.Provider_StudentUpdateSuccess;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    imgCancel.Visible = true;
                    imgUpdate.Visible = false;
                }

                else
                {
                    //lblMsg.Text = "Please enter Valid Details";
                    lblMsg.Text = Resources.ResMessages.Provider_StudentUpdateFail;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    imgCancel.Visible = true;
                    imgUpdate.Visible = false;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Students.aspx", false);
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

        #endregion

        #region Methods

        protected void GetStudentEditDetails(int StudentID)
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntStudentID = StudentID;

            Session["studentid"] = StudentID;

            objBCommon.BGetStudentDetails(objBECommon);
            if (objBECommon.DsResult != null)
            {
                if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {
                    //lblStudentName.Text = objBEProctor.dtStudentResult.Rows[0]["studentName"].ToString();
                    // lblstudentid.Text = objBEProctor.StudentID.ToString();
                    lblstudentfirstname.Text = objBECommon.DsResult.Tables[0].Rows[0]["FirstName"].ToString();
                    lblSFirstName.Text = objBECommon.DsResult.Tables[0].Rows[0]["FirstName"].ToString();
                    lblStudentLastName.Text = objBECommon.DsResult.Tables[0].Rows[0]["LastName"].ToString();
                    lblSLastName.Text = objBECommon.DsResult.Tables[0].Rows[0]["LastName"].ToString();
                    // lblgender.Text = objBEProctor.dtStudentResult.Rows[0]["GenderName"].ToString();
                    lblEmailID.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblEmailAddress.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                    // lblStatus.Text = objBEProctor.dtStudentResult.Rows[0]["StatusName"].ToString();
                    // lblusername.Text = objBEProctor.dtStudentResult.Rows[0]["UserName"].ToString();
                    txtPhoneNumber.Text = objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    lblMobileNumber.Text = objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    lblSpecialNeeds.Text = objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString();
                    //ddlSpecialNeeds.SelectedItem.Text = objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString();
                    ddlSpecialNeeds.Items.FindByText(objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString()).Selected = true;
                    if (ddlSpecialNeeds.SelectedItem.Value == "1")
                    {
                        trcomments.Visible = true;
                        if (objBECommon.DsResult.Tables[0].Rows[0]["Comments"] != DBNull.Value)
                        {
                            lblcomments.Text = objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                            txtcomments.Value = objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                        }
                    }
                    else if (ddlSpecialNeeds.SelectedItem.Value == "0")
                    {
                        trcomments.Visible = false;
                    }
                }
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
                        ddlTimeZone.Items.FindByValue(objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString().Trim()).Selected = true;

                        lblTimeZone.Text = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone2"].ToString();
                    }
                }
                catch (Exception Ex)
                {
                    // ErrorLog.WriteError(Ex);
                }
            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }

        protected void EnableDetails()
        {

            lblSFirstName.Visible = true;
            lblstudentfirstname.Visible = false;

            lblSLastName.Visible = true;
            lblStudentLastName.Visible = false;

            lblEmailAddress.Visible = true;
            lblEmailID.Visible = false;

            lblMobileNumber.Visible = true;
            txtPhoneNumber.Visible = false;
            ddlTimeZone.Visible = false;

            lblTimeZone.Visible = true;
            lblformat.Visible = false;

            lblSpecialNeeds.Visible = true;
            ddlSpecialNeeds.Visible = false;

            lblcomments.Visible = true;
            txtcomments.Visible = false;

            GetStudentEditDetails(Convert.ToInt32(Session["studentid"]));
            BindTimeZone(Convert.ToInt32(Session["studentid"]));

        }

        #endregion

        #region Commented Code

        //protected void BindGender(int studentid)
        //{

        //    try
        //    {
        //        BEStudent objBEStudent = new BEStudent();
        //        BStudent objBStudent = new BStudent();

        //        objBEStudent.intStudentID = studentid;

        //        objBStudent.BGenderList1(objBEStudent);
        //        if (objBEStudent.dtResult.Rows.Count > 0)
        //        {
        //            ddlGender.DataValueField = "GenderID";
        //            ddlGender.DataTextField = "GenderName";

        //            ddlGender.DataSource = objBEStudent.dtResult;
        //            ddlGender.DataBind();
        //        }

        //        if (objBEStudent.dtResult1.Rows.Count > 0)
        //        {

        //            ddlGender.SelectedValue = objBEStudent.dtResult1.Rows[0]["GenderName1"].ToString();
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        //  ErrorLog.WriteError(Ex);
        //    }


        //}             

        #endregion
    }
}