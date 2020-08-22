using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessEntities;
using BLL;

namespace SecureProctor.Provider
{
    public partial class DeleteExam : BaseClass
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_DELETE_EXAM;
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
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBProvider.BGetSelectedExamDetails(objBEExamProvider);
                lblExamName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                lblStatusValue.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["Status"].ToString();
                //ddlStatus.SelectedValue = objBEExamProvider.DsResult.Tables[0].Rows[0]["Status"].ToString();
                //if (objBEExamProvider.DsResult.Tables[0].Rows[0]["Status"].ToString() == "1")
                //    lblStatusValue.Text = "Active";
                //else
                //    lblStatusValue.Text = "Inactive";

                objBEExamProvider = null;
                objBProvider = null;
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
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBProvider.BDeleteExam(objBEExamProvider);
                trMessage.Visible = true;
                if (objBEExamProvider.IntResult == 0)
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
                objBEExamProvider = null;
                objBProvider = null;
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
    }
}