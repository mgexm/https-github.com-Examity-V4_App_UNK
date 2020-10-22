using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Admin
{
    public partial class AdminEnrollStudent : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_ENTOLLSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";

                if (!IsPostBack)
                {
                
                    this.BindDropdowns();

                    BindProviderNames();
                }
            }
            catch (Exception )
            {
            }
        }

        protected void BindProviderNames()
        {
            BECommon objBECommon = new BECommon();
            new BCommon().BindProviderNames(objBECommon);
            if (objBECommon.DtResult.Rows.Count > 0)
            {
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = objBECommon.DtResult;
                ddlprovider.DataTextField = "Name";
                ddlprovider.DataValueField = "ExamProviderID";
                ddlprovider.DataBind();

                ddlCourse.AppendDataBoundItems = true;
                ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
              

            }

            else
            {
                ddlprovider.Items.Clear();
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = null;
                ddlprovider.DataBind();
                ddlCourse.Items.Clear();
                ddlCourse.AppendDataBoundItems = true;
                ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                ddlCourse.DataSource = null;
                ddlCourse.DataBind();


            }

        }

        protected void ddlProviderName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            BEAdmin objBEAdmin = new BEAdmin();

            BAdmin objBAdmin = new BAdmin();

            objBEAdmin.IntProviderID =Convert.ToInt32(ddlprovider.SelectedValue);
            objBAdmin.BBindCourse(objBEAdmin);
            ddlCourse.DataSource = objBEAdmin.DtResult.DefaultView;
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataBind();

           
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
                //BEAdmin objBEAdmin = new BEAdmin();

                //BAdmin objBAdmin = new BAdmin();
                //objBAdmin.BBindCourse(objBEAdmin);
                //ddlCourse.DataSource = objBEAdmin.DtResult.DefaultView;
                //ddlCourse.DataValueField = "CourseID";
                //ddlCourse.DataTextField = "CourseName";
                //ddlCourse.DataBind();
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
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                // objBECommon.IntStudentID = EnrollID;
                objBCommon.BAdminGetEnrollStudentDetails(objBECommon);
                if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {


                    gvExamStatus.DataSource = objBECommon.DsResult.Tables[0];

                    gvExamStatus.Rebind();
                }

                else
                {

                    gvExamStatus.DataSource = new string[] { };

                    gvExamStatus.DataBind();

                }
            }
            catch (Exception )
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
            catch (Exception )
            {
            }
        }

        protected void lblStudentNameEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton lblStudentName = (ImageButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

                Response.Redirect("AdminEditEnrollment.aspx?EnrollID=" + AppSecurity.Encrypt(StudentID.ToString()), false);
            }
            catch (Exception )
            {
            }
        }

        protected void lblStudentNameDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton lblStudentName = (ImageButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

                Response.Redirect("AdminDeleteEnrollment.aspx?EnrollID=" + AppSecurity.Encrypt(StudentID.ToString()), false);
            }
            catch (Exception )
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
                objBEExamProvider.IntUserID = Convert.ToInt32(ddlprovider.SelectedValue.ToString());
                objBEExamProvider.IntCourseID = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                objBEExamProvider.IntExamID = Convert.ToInt32(ddlStudents.SelectedValue.ToString());
                objBExamProvider.BAdminEnrollStudent(objBEExamProvider);
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
            Response.Redirect(BaseClass.EnumAppPage.ADMIN_VIEWSTUDENT);
        }


    }
}