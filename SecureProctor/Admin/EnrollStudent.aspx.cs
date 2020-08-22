using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.Admin
{
    public partial class EnrollStudent : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.GetCourseDetails();
                this.BindStudents();
                trAddEnrollment.Visible = true;
                trAddEnrollmentConfirmation.Visible = false;

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_ENROLLSTUDENT;

            }
            trMessage.Visible = false;


        }

        protected void GetCourseDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
                objBEAdmin.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderId"].ToString());
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
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
            objBAdmin.BGetStudentsNotInCourse(objBEAdmin);
            if (objBEAdmin.DtResult.Rows.Count > 0)
            {
                rcbStudent.AppendDataBoundItems = true;
               // rcbStudent.Items.Add(new RadComboBoxItem("--Select Student--", "-1"));
                rcbStudent.DataSource = objBEAdmin.DtResult;
                rcbStudent.DataTextField = "StudentName";
                rcbStudent.DataValueField = "StudentID";
                rcbStudent.DataBind();

            }

           

        }

        

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BEAdmin objBEAdmin = new BEAdmin();
                    BAdmin objBAdmin = new BAdmin();
                    objBEAdmin.IntStudentID = 1;//Convert.ToInt32(rcbStudent.SelectedValue);
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
                    objBEAdmin.IntUserID = Convert.ToInt32(Request.QueryString["ProviderId"].ToString());
                    objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
                    objBAdmin.BAdminEnrollStudent(objBEAdmin);
                    trMessage.Visible = true;
                    if (objBEAdmin.IntResult.ToString() == "1")
                    {
                        lblInfo.Text = Resources.AppMessages.Admin_Enrollment_Success_AddEnrollment;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                        lblStudentnameConfirmation.Text = studentName;
                      //  ddlCourse.Visible = false;
                        trUpdate.Visible = false;
                       // lblInstructor.Visible = true;
                      //  ddlprovider.Visible = false;
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




    }
}