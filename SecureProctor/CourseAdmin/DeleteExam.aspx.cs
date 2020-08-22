using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessEntities;
using BLL;

namespace SecureProctor.CourseAdmin
{
    public partial class DeleteExam : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_DELETE_EXAM;
                this.getSelectedExamDetails();
            }
            trMessage.Visible = false;
        }            

        #region DeleteButtonClick

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBCourseAdmin.BDeleteExam(objBECourseAdmin);
                trMessage.Visible = true;
                if (objBECourseAdmin.IntResult == 0)
                {
                    lblInfo.Text = Resources.AppMessages.Provider_DeleteExam_Error_ExamIsInprogress;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                    trUpdate.Visible = true;
                }
                else
                {
                    lblInfo.Text = Resources.AppMessages.Provider_DeleteExam_Success_deleted;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    trUpdate.Visible = false;
                }
                objBECourseAdmin = null;
                objBCourseAdmin = null;
            }
            catch
            {
                lblInfo.Text = Resources.AppMessages.Provider_DeleteExam_Error_whileDeleting;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trUpdate.Visible = true;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region getSelectedExamDetails

        protected void getSelectedExamDetails()
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBCourseAdmin.BGetSelectedExamDetails(objBECourseAdmin);
                lblExamName.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                lblStatusValue.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["Status"].ToString();

                objBECourseAdmin = null;
                objBCourseAdmin = null;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        #endregion

        #endregion
    }
}