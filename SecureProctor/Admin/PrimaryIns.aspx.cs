using BLL;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor.Admin
{
    public partial class PrimaryIns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderID"].ToString());
                objBExamProvider.BCheckPrimaryIns(objBEExamProvider);

                if (objBEExamProvider.IntResult == 1)
                {
                    chkPrimary.Checked = true;
                }
                else
                {
                    chkPrimary.Checked = false;
                }
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                //objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
               //objBEAdmin.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderID"]);

                if (chkPrimary.Checked == true)
                {
                    BEProvider objBEExamProvider = new BEProvider();
                    BProvider objBExamProvider = new BProvider();
                    chkPrimary.Checked = true;
                    objBEExamProvider.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderID"].ToString());
                    //objBEExamProvider.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderID"].ToString());
                    objBEExamProvider.intPrimaryIns = true;
                    objBExamProvider.BUpdatePrimaryIns(objBEExamProvider);
                    //trMessage.Visible = true;
                    lblInfo.Text = "Details updated successfully";
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    chkPrimary.Visible = false;
                    lblPrimary.Visible = false;
                    btnUpdate.Visible = false;

                }
                else
                {
                    BEProvider objBEExamProvider = new BEProvider();
                    BProvider objBExamProvider = new BProvider();
                    chkPrimary.Checked = false;
                    objBEExamProvider.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderID"].ToString());
                    //objBEExamProvider.IntProviderID = Convert.ToInt32(Request.QueryString["ProviderID"].ToString());
                    objBEExamProvider.intPrimaryIns = false;
                    objBExamProvider.BUpdatePrimaryIns(objBEExamProvider);
                    //trMessage.Visible = true;
                    lblInfo.Text = "Details updated successfully";
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    chkPrimary.Visible = false;
                    lblPrimary.Visible = false;
                    btnUpdate.Visible = false;
                    
                }

                
                
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void chkPrimary_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}