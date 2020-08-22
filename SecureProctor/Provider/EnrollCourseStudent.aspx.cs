using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.Provider
{
   
    public partial class EnrollCourseStudent : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.BindStudents();
                this.BindCourseName();

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_ENROLLSTUDENT;

            }
            trMessage.Visible = false;

        }

        protected void BindStudents()
        {
            BEProvider objBEProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEProvider.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
            objBProvider.BGetStudentsNotInCourse(objBEProvider);
            if (objBEProvider.DtResult.Rows.Count > 0)
            {
                rcbStudents.AppendDataBoundItems = true;
               // rcbStudents.Items.Add(new RadComboBoxItem("--Select Student--", "-1"));
                rcbStudents.DataSource = objBEProvider.DtResult;
                rcbStudents.DataTextField = "StudentName";
                rcbStudents.DataValueField = "StudentID";
                rcbStudents.DataBind();

            }



        }
         protected void BindCourseName()
        {
            try
            {
               
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEProvider.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());
                objBProvider.BGetCourseDetailsbyProvider(objBEProvider);
                if (objBEProvider.DtResult != null && objBEProvider.DtResult.Rows.Count > 0)
                {
                   
                    lblCourse.Text = objBEProvider.DtResult.Rows[0]["CourseName"].ToString();
                }
            }

            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

        }     


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEProvider.IntCourseID = Convert.ToInt32(Request.QueryString["Courseid"].ToString());

                DataTable objDt = new DataTable();
                objDt.Columns.Add("StudentID");
                string studentName = string.Empty;
                foreach (RadComboBoxItem ChkStudent in rcbStudents.Items)
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
                objBEProvider.DtResult1 = objDt;

                objBEProvider.IntStudentID = 0;//Convert.ToInt32(rcbStudents.SelectedValue);

               // lblCourse.Text = ddlCourse.SelectedItem.Text;
                objBProvider.BProviderEnrollSelectedStudents(objBEProvider);
                trMessage.Visible = true;
                if (objBEProvider.IntResult.ToString() == "1")
                {
                    lblInfo.Text = Resources.AppMessages.Provider_Enrollment_Success_AddEnrollment;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    lblCourse.Visible = true;
                   
                    lblStudent.Visible = true;
                    lblStudent.Text = studentName;//rcbStudents.SelectedItem.Text;
                    rcbStudents.Visible = false;
                    trUpdate.Visible = false;
                }

                else
                {
                    lblInfo.Text = Resources.AppMessages.Provider_Enrollment_Error_AddEnrollment;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                    lblCourse.Visible = true;
                    rcbStudents.Visible = true;
                    trUpdate.Visible = true;
                }
            }

            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);

            }
        }
    }
}