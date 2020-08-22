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
    public partial class EditStudent : BaseClass
    {

        #region Global Declarations

        string strStudentID = string.Empty;

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EDITSTUDENT;
            }

            trUpdate.Visible = true;
            trMessage.Visible = false;

            if (!IsPostBack)
            {
                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                {

                    strStudentID = Request.QueryString["StudentID"].ToString();

                }
                if (strStudentID != "")
                {
                    GetStudentEditDetails(int.Parse(strStudentID));
                    //  BindTimeZone(int.Parse(strStudentID));
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();

                objBECourseAdmin.IntStudentID = Convert.ToInt32(Session["studentid"]);
                objBECourseAdmin.strFirstName = lblstudentfirstname.Text;
                objBECourseAdmin.strLastName = lblStudentLastName.Text;
                objBECourseAdmin.strEmailAddress = lblEmailID.Text;
                objBECourseAdmin.strSpecialNeeds1 = ddlSpecialNeeds.SelectedValue;
                objBECourseAdmin.StrComments = txtcomments.Value;
                objBECourseAdmin.IntstatusFlag = Convert.ToInt32(ddlStatus.SelectedValue.ToString());
                objBCourseAdmin.BUpdateStudentDetails(objBECourseAdmin);

                if (objBECourseAdmin.IntResult == 1)
                {
                    trUpdate.Visible = false;
                    EnableDetails();
                    trMessage.Visible = true;
                    lblInfo.Text = Resources.AppMessages.Provider_EditStudent_Success_StudentDetailsUpdated;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);

                }

                else
                {
                    trMessage.Visible = true;
                    lblInfo.Text = Resources.AppMessages.Provider_EditStudent_Error_StudentDetails;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);

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

        #endregion

        #region Methods

        protected void GetStudentEditDetails(int StudentID)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntStudentID = StudentID;

            Session["studentid"] = StudentID;

            objBCommon.BGetStudentDetails(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {

                lblstudentfirstname.Text = objBECommon.DtResult.Rows[0]["FirstName"].ToString();
                lblSFirstName.Text = objBECommon.DtResult.Rows[0]["FirstName"].ToString();
                lblStudentLastName.Text = objBECommon.DtResult.Rows[0]["LastName"].ToString();
                lblSLastName.Text = objBECommon.DtResult.Rows[0]["LastName"].ToString();
                lblEmailID.Text = objBECommon.DtResult.Rows[0]["EmailAddress"].ToString();
                lblEmailAddress.Text = objBECommon.DtResult.Rows[0]["EmailAddress"].ToString();

                lblSpecialNeeds.Text = objBECommon.DtResult.Rows[0]["SpecialNeeds"].ToString();
                ddlSpecialNeeds.Items.FindByText(objBECommon.DtResult.Rows[0]["SpecialNeeds"].ToString()).Selected = true;
                if (ddlSpecialNeeds.SelectedItem.Value == "1")
                {
                    trcomments.Visible = true;
                    if (objBECommon.DtResult.Rows[0]["Comments"] != DBNull.Value)
                    {
                        lblcomments.Text = objBECommon.DtResult.Rows[0]["Comments"].ToString();
                        txtcomments.Value = objBECommon.DtResult.Rows[0]["Comments"].ToString();
                    }
                }
                else if (ddlSpecialNeeds.SelectedItem.Value == "0")
                {
                    trcomments.Visible = false;
                }

                lblStatus.Text = objBECommon.DtResult.Rows[0]["Status"].ToString();
                ddlStatus.Items.FindItemByText(objBECommon.DtResult.Rows[0]["Status"].ToString()).Selected = true;
            }




            objBECommon.iID = StudentID;
            objBECommon.iTypeID = 1;
            objBCommon.BGetLMSSettings(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (!Convert.ToBoolean(objBECommon.DtResult.Rows[0]["courseadmin"]))
                {
                    lblstudentfirstname.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["FirstName"]);
                    if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["FirstName"]))
                    {
                        lblstudentfirstname.CssClass = "readonly";
                        RequiredFieldValidator1.Enabled = false;
                    }

                    lblStudentLastName.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["LastName"]);
                    if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["LastName"]))
                    {
                        lblStudentLastName.CssClass = "readonly";
                        RequiredFieldValidator2.Enabled = false;
                    }


                    lblEmailID.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["EmailAddress"]);
                    if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["EmailAddress"]))
                    {
                        lblEmailID.CssClass = "readonly";
                        RequiredFieldValidator4.Enabled = false;
                        RegularExpressionValidator1.Enabled = false;
                    }
                }
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
            lblSpecialNeeds.Visible = true;
            ddlSpecialNeeds.Visible = false;
            lblcomments.Visible = true;
            txtcomments.Visible = false;
            ddlStatus.Visible = false;
            lblStatus.Visible = true;
            GetStudentEditDetails(Convert.ToInt32(Session["studentid"]));
            // BindTimeZone(Convert.ToInt32(Session["studentid"]));
        }

        #endregion

    }
}