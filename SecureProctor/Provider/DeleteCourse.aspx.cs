using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Provider
{
    public partial class DeleteCourse : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_DELETECOURSE_DELETECOURSE;

                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    GetSelectedDetails();

            }
            trMessage.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEExamProvider.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
            objBProvider.BDeleteCourse(objBEExamProvider);
            if (objBEExamProvider.IntResult == 1)
            {
                lblInfo.Text = Resources.AppMessages.Provider_DeleteCourse_Success_DeleteCourse;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                trMessage.Visible = true;
                trDelete.Visible = false;


            }
            if (objBEExamProvider.IntResult == 0)
            {

                lblInfo.Text = Resources.AppMessages.Provider_DeletCourse_Error_DeleteCoursePending;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trMessage.Visible = true;
            }
        }

        protected void GetSelectedDetails()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                objBProvider.BGetSelectedCourseDetails(objBEExamProvider);
                if (objBEExamProvider.DtResult != null && objBEExamProvider.DtResult.Rows.Count > 0)
                {
                    lblCourseID.Text = objBEExamProvider.DtResult.Rows[0]["Course_ID"].ToString();
                    lblCourseName.Text = objBEExamProvider.DtResult.Rows[0]["CourseName"].ToString();


                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

        }
    }
}