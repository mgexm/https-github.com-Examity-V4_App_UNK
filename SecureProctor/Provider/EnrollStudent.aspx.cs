using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Provider
{
    public partial class EnrollStudent : BaseClass
    {
        #region GlobalDeclarations
        const int CurrentPage = 1;
        const string SortTypeDsc = "DESC";
        const string SortColumn = "StudentName";
        const string sortTypeAsc = "ASC";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_ENTOLLSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";

                if (!IsPostBack)
                {
                    this.BindDropdowns();
                }
            }
            catch (Exception Ex)
            {
            }
        }

        protected void BindDropdowns()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBExamProvider.BGetStudentsAndCourses(objBEExamProvider);
                ddlStudents.DataSource = objBEExamProvider.DsResult.Tables[0];
                ddlStudents.DataValueField = "UserId";
                ddlStudents.DataTextField = "UserName";
                ddlStudents.DataBind();
                ddlCourse.DataSource = objBEExamProvider.DsResult.Tables[1];
                ddlCourse.DataValueField = "CourseID";
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataBind();
            }
            catch
            {
            }
        }

        protected void gvExamStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadDataTable();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region LoadDataTable
        protected void LoadDataTable()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                //objBEExamProvider.strStudentName = txtStudentName.Text.Trim().ToString();
                objBEExamProvider.strStudentName = "";
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                new BProvider().BGetStudentEnrollments(objBEExamProvider);
                if (objBEExamProvider.DtResult.Rows.Count > 0)
                {
                    trGridPages.Visible = true;
                    gvExamStatus.DataSource = objBEExamProvider.DtResult;
                    gvExamStatus.Rebind();
                }
                else
                {
                    trGridPages.Visible = true;
                    gvExamStatus.DataSource = new string[] { };
                    //gvExamStatus.DataBind();
                }
            }
            catch (Exception Ex)
            {
            }
        }
        #endregion


        protected void lblStudentName_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton lblStudentName = (ImageButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

                Response.Redirect("ViewUserDetails.aspx?Type=R&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            catch (Exception Ex)
            {
            }
        }

        protected void lblStudentNameEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton lblStudentName = (ImageButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

                Response.Redirect("EditEnrollment.aspx?EnrollID=" + AppSecurity.Encrypt(StudentID.ToString()), false);
            }
            catch (Exception Ex)
            {
            }
        }

        protected void lblStudentNameDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton lblStudentName = (ImageButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

                Response.Redirect("DeleteEnrollment.aspx?EnrollID=" + AppSecurity.Encrypt(StudentID.ToString()), false);
            }
            catch (Exception Ex)
            {
            }
        }

        protected void gvExamStatus_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                Label lblFlag = (Label)e.Item.FindControl("lblFlag");
                ImageButton lnkEdit = (ImageButton)e.Item.FindControl("lblEdit");
                ImageButton lnkDelete = (ImageButton)e.Item.FindControl("lblDelete");
                if (lblFlag != null && lblFlag.Text == "No")
                {
                    lnkEdit.Enabled = false;
                    lnkDelete.Enabled = false;
                    lnkEdit.Font.Underline = false;
                    lnkDelete.Font.Underline = false;
                }
                else
                {
                    lnkEdit.Font.Underline = true;
                    lnkDelete.Font.Underline = true;
                    lnkEdit.Enabled = true;
                    lnkDelete.Enabled = true;
                }
            }
        }


        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEExamProvider.IntCourseID = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                objBEExamProvider.IntExamID = Convert.ToInt32(ddlStudents.SelectedValue.ToString());
                objBExamProvider.BEnrollStudent(objBEExamProvider);
                if (objBEExamProvider.IntResult.ToString() == "1")
                {
                    lblSuccess.Visible = true;
                    //lblSuccess.Text = "Student is enrolled for an exam successfully";
                    lblSuccess.Text = Resources.ResMessages.Provider_EnrollStudentSuccess;
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                    this.LoadDataTable();
                }
                else
                {
                    lblSuccess.Visible = true;
                    //lblSuccess.Text = "Student is already enrolled for this Exam";
                    lblSuccess.Text = Resources.ResMessages.Provider_EnrollStudentExam;
                    lblSuccess.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
            }
        }
        protected void lblAddStudentlink_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ProcessedExamRequests.aspx");
            Response.Redirect(BaseClass.EnumAppPage.PROVIDER_VIEWSTUDENT);
        }

    }
}