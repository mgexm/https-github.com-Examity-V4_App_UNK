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
    public partial class EditProctor :BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_ADD_PROCTOR;
                BindProctors();
                trAddProctor.Visible = true;
                trViewProctor.Visible = false;
            }
            trMessage.Visible = false;
        }

        protected void BindProctors()
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();

            objBProctor.BGetProctor(objBEProctor);

            if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
            {
                ddlProctorName.DataTextField = "ProctorName";
                ddlProctorName.DataValueField = "UserID";
                ddlProctorName.DataSource = objBEProctor.DsResult.Tables[0];
                ddlProctorName.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(Request.QueryString["TransID"].ToString());
            objBEProctor.ProctorID = Convert.ToInt32(ddlProctorName.SelectedValue);

            objBProctor.BAddProctor(objBEProctor);

            if (objBEProctor.IntResult == 1)
            {

                trMessage.Visible = true;
                trAddProctor.Visible = false;
                trViewProctor.Visible = true;
                lblProctorName.Text = ddlProctorName.SelectedItem.Text.ToString();
                lblInfo.Text = Resources.ResMessages.Proctor_AddProctor;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);


            }

            else
            {

                trMessage.Visible = true;
                lblInfo.Text = Resources.ResMessages.Proctor_Error_AddProctor;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
            }
        }
    }
}