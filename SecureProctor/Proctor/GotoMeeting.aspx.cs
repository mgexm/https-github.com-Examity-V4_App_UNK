using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Proctor
{
    public partial class GotoMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            trMessage.Visible = false;


        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();

                objBECommon.TransID = txtTransactionID.Text;

                objBECommon.GotoMeetingID = txtGotoMeeting.Text;

                objBECommon.intTypeID = Convert.ToInt32(ddlSessionType.SelectedValue.ToString());

                lblTransid.Text = txtTransactionID.Text;

                lblGotoMeetingID.Text = txtGotoMeeting.Text;

                lblSessionType.Text = ddlSessionType.SelectedItem.Text.ToString();

                objBCommon.BUpdateGotoMeeting(objBECommon);

                if (objBECommon.IntstatusFlag == 0)
                {

                   
                    
                    trMessage.Visible = true;
                    lblInfo.Text = Resources.ResMessages.Proctor_Add_Success_AddMeeting;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);

                    btnSubmit.Visible = false;

                   txtTransactionID.Visible = false;

                   txtGotoMeeting.Visible = false;
                   ddlSessionType.Visible = false;

                    lblTransid.Visible = true;

                    lblGotoMeetingID.Visible = true;
                    lblSessionType.Visible = true;

                }

                if (objBECommon.IntstatusFlag == 1)
                {

                    trMessage.Visible = true;
                    lblInfo.Text = Resources.ResMessages.Proctor_Add_Error_AddMeeting;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);

                    

                }

            }

            catch (Exception Ex)
            {


                trMessage.Visible = true;
                lblInfo.Text = Resources.ResMessages.Proctor_Add_Error_AddMeeting;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);

            }

        }
    }
}