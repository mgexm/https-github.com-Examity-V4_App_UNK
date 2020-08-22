using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessEntities;
using BLL;

namespace SecureProctor.Admin
{
    public partial class DeleteExam : BaseClass
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_COURSEDETAILS_DELETE_EXAM;
                this.getSelectedExamDetails();
            }
            trMessage.Visible = false;
        }
        #endregion
        #region getSelectedExamDetails
        protected void getSelectedExamDetails()
        {
            try
            {

                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBAdmin.BGetSelectedExamDetails(objBEAdmin);
                lblExamName.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                lblStatusValue.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["Status"].ToString();
              
                objBEAdmin = null;
                objBAdmin = null;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region DeleteButtonClick
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBAdmin.BDeleteExam(objBEAdmin);
                trMessage.Visible = true;
                if (objBEAdmin.IntResult == 0)
                {
                    lblInfo.Text = Resources.AppMessages.Admin_DeleteExam_Error_ExamIsInprogress;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                    trUpdate.Visible = true;
                }
                else
                {
                    lblInfo.Text = Resources.AppMessages.Admin_DeleteExam_Success_deleted;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    trUpdate.Visible = false;
                }
                objBEAdmin = null;
                objBAdmin = null;
            }
            catch
            {
                lblInfo.Text = Resources.AppMessages.Admin_DeleteExam_Error_whileDeleting;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trUpdate.Visible = true;
            }
        }
        #endregion
    }
}