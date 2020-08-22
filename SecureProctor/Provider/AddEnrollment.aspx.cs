using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Provider
{
    public partial class AddEnrollment : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.GetStudentName();
                this.BindCourseName();

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_ENROLLSTUDENT;

            }
            trMessage.Visible = false;

        }

        protected void GetStudentName()
        {
            try
            {
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
                objBProvider.BGetStudentName(objBEProvider);
                if (objBEProvider.DtResult != null && objBEProvider.DtResult.Rows.Count > 0)
                {


                    lblStudentName.Text = objBEProvider.DtResult.Rows[0]["StudentName"].ToString();
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

        }

        protected void BindCourseName()
        {
            try
            {
               
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBProvider.BGetProviderCourseDetails(objBEProvider);
                if (objBEProvider.DtResult.Rows.Count > 0)
                {

                    ddlCourse.AppendDataBoundItems = true;
                    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                    ddlCourse.DataSource = objBEProvider.DtResult;
                    ddlCourse.DataValueField = "CourseID";
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataBind();
                }
                else
                {
                    ddlCourse.Items.Clear();
                    ddlCourse.AppendDataBoundItems = true;
                    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                    ddlCourse.DataSource = null;
                    ddlCourse.DataBind();

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
                objBEProvider.IntCourseID = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                objBEProvider.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
                lblCourse.Text = ddlCourse.SelectedItem.Text;
                objBProvider.BProviderEnrollStudentCourse(objBEProvider);
                trMessage.Visible = true;
                if (objBEProvider.IntResult.ToString() == "1")
                {
                    lblInfo.Text = Resources.AppMessages.Provider_Enrollment_Success_AddEnrollment;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    lblCourse.Visible = true;
                    ddlCourse.Visible = false;
                    trUpdate.Visible = false;
                }

                else
                {
                    lblInfo.Text = Resources.AppMessages.Provider_Enrollment_Error_AddEnrollment;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                    lblCourse.Visible = false;
                    ddlCourse.Visible = true;
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