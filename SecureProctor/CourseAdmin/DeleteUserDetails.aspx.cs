using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;


namespace SecureProctor.CourseAdmin
{
    public partial class DeleteUserDetails : BaseClass
    {
        #region Global Declarations

        string strStudentID = string.Empty;

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_STUDENTREGISTRATION;
           
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
                        Session[BaseClass.EnumPageSessions.StudentID] = strStudentID;
                    }
                }
                if (strStudentID != "")
                {
                    GetStudentDetails(int.Parse(strStudentID));
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            BECourseAdmin objBEProvider = new BECourseAdmin();
            BCourseAdmin objBProvider = new BCourseAdmin();
            objBEProvider.IntStudentID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.StudentID].ToString());
            objBProvider.BDeleteStudent(objBEProvider);

            if (objBEProvider.DsResult != null && objBEProvider.DsResult.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(objBEProvider.DsResult.Tables[0].Rows[0][0]))
                {
                    imgtick.Visible = true;
                    lblMsg.Visible = true;
                    btnConfirm.Visible = false;
                    btnBack.Visible = false;
                    //lblMsg.Text = "Student deleted successfully";
                    lblMsg.Text = Resources.ResMessages.Provider_UserDelSuccess;
                }
                else
                {
                    imgtick.Visible = false;
                    lblMsg.Visible = true;
                    btnConfirm.Visible = true;
                    btnBack.Visible = true;
                    //lblMsg.Text = "Deletion failed as Student has pending exams";
                    lblMsg.Text = Resources.ResMessages.Provider_UserDelPending;
                }
            }

            else
            {
                imgtick.Visible = false;
                lblMsg.Visible = true;
                btnConfirm.Visible = true;
                btnBack.Visible = true;
                //lblMsg.Text = "Student Deletion failed.Please try again.";
                lblMsg.Text = Resources.ResMessages.Provider_UserDelFail;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CourseAdmin/Students.aspx", false);
        }

        #endregion

        #region Methods

        protected void GetStudentDetails(int StudentID)
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntStudentID = StudentID;
            objBCommon.BGetStudentDetails(objBECommon);
            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                lblstudentfirstname.Text = objBECommon.DsResult.Tables[0].Rows[0]["FirstName"].ToString();
                lblStudentLastName.Text = objBECommon.DsResult.Tables[0].Rows[0]["LastName"].ToString();
                lblEmailID.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblPhoneNumber.Text = objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString();
                lblTimeZone.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeZone"].ToString();
                lblrole.Text = objBECommon.DsResult.Tables[0].Rows[0]["Role_Name"].ToString();

                lblSpecialNeeds.Text = objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString();
                if (objBECommon.DsResult.Tables[0].Rows[0]["Comments"] != DBNull.Value)
                {
                    lblComments.Text = objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                }
                else
                {
                    lblComments.Text = "N/A";
                }
            }
        }

        #endregion
    }
}