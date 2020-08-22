using BLL;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SecureProctor.CourseAdmin
{
    public partial class AddCourseStudentEnrollment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCourseDetails();
                BindStudents();
                trAddEnrollment.Visible = true;
                trAddEnrollmentConfirmation.Visible = false;
                this.Page.Title = SecureProctor.BaseClass.EnumPageTitles.APPNAME + SecureProctor.BaseClass.EnumPageTitles.ADMIN_ENROLLSTUDENT;
            }
            trMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BECourseAdmin objBEAdmin = new BECourseAdmin();
                    BCourseAdmin objBAdmin = new BCourseAdmin();
                    objBEAdmin.IntStudentID = 0;//Convert.ToInt32(rcbStudent.SelectedValue);

                    DataTable objDt = new DataTable();
                    objDt.Columns.Add("StudentID");
                    string studentName = string.Empty;
                    foreach (RadComboBoxItem ChkStudent in rcbStudent.Items)
                    {
                        if (ChkStudent.Checked)
                        {
                            DataRow objDr = objDt.NewRow();
                            objDr["StudentID"] = ChkStudent.Value;
                            objDt.Rows.Add(objDr);
                            if (studentName == string.Empty)
                            {
                                studentName = ChkStudent.Text;
                            }
                            else
                            {
                                studentName = studentName + ',' + ' ' + ChkStudent.Text;
                            }
                        }
                    }
                    objDt.AcceptChanges();
                    objBEAdmin.DtResult1 = objDt;

                    objBEAdmin.IntUserID = Convert.ToInt32(Request.QueryString["InstructorID"].ToString());
                    objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
                    objBAdmin.BCourseAdminEnrollStudents(objBEAdmin);
                    trMessage.Visible = true;
                    if (objBEAdmin.IntResult.ToString() == "1")
                    {
                        lblInfo.Text = Resources.AppMessages.Admin_Enrollment_Success_AddEnrollment;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                        lblStudentnameConfirmation.Text = studentName;//rcbStudent.SelectedItem.Text;
                        trUpdate.Visible = false;
                        lblInstuctorNameConfirm.Text = lblInstructor.Text;
                        lblCourseNameConfirm.Text = lblCourse.Text;
                        trAddEnrollment.Visible = false;
                        trAddEnrollmentConfirmation.Visible = true;

                    }
                    else
                    {
                        lblInfo.Text = Resources.AppMessages.Admin_Enrollment_Error_AddEnrollment;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                        trAddEnrollment.Visible = true;
                        trAddEnrollmentConfirmation.Visible = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void GetCourseDetails()
        {
            try
            {
                BECourseAdmin objBEAdmin = new BECourseAdmin();
                BCourseAdmin objBAdmin = new BCourseAdmin();

                objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
                objBEAdmin.IntProviderID = Convert.ToInt32(Request.QueryString["InstructorID"].ToString());
                objBAdmin.BGetCourseDetailsbyProvider(objBEAdmin);
                if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                {

                    lblInstructor.Text = objBEAdmin.DtResult.Rows[0]["ProviderName"].ToString();
                    lblCourse.Text = objBEAdmin.DtResult.Rows[0]["CourseName"].ToString();
                }

            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

        }

        protected void BindStudents()
        {
            BECourseAdmin objBEAdmin = new BECourseAdmin();
            BCourseAdmin objBAdmin = new BCourseAdmin();
            objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
            objBAdmin.BGetStudentsNotInCourse(objBEAdmin);
            if (objBEAdmin.DtResult.Rows.Count > 0)
            {
                rcbStudent.AppendDataBoundItems = true;
                //rcbStudent.Items.Add(new RadComboBoxItem("--Select Student--", "-1"));
                rcbStudent.DataSource = objBEAdmin.DtResult;
                rcbStudent.DataTextField = "StudentName";
                rcbStudent.DataValueField = "StudentID";
                rcbStudent.DataBind();

            }



        }

    }
}