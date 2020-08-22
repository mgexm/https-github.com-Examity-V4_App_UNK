using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor
{
    public partial class ChangeTimeZone : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindTimeZone();
            }
            //trTimeZone.Visible = true;
           // tblMsg.Visible = false;
        }
        protected void BindTimeZone()
        {
            try
            {
                BUser objBUser = new BUser();
                BEUser objBEUser = new BEUser();
                objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBUser.BGetTimeZone(objBEUser);
                if (objBEUser.DsResult.Tables[0].Rows.Count > 0)
                {
                    ddlTimeZone.Items.Clear();
                    ddlTimeZone.DataValueField = "id";
                    ddlTimeZone.DataTextField = "TimeZone";
                    ddlTimeZone.DataSource = objBEUser.DsResult.Tables[0];
                    ddlTimeZone.DataBind();
                }
               
            }
            catch (Exception Ex)
            {
                // ErrorLog.WriteError(Ex);
            }
        }

        protected void btnSaveTimeZone_Click(object sender, EventArgs e)
        {
            BUser objBUser = new BUser();
            BEUser objBEUser = new BEUser();
            objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (ddlTimeZone.SelectedIndex != -1)
            {
                objBEUser.IntTimeZoneID = Convert.ToInt32(ddlTimeZone.SelectedItem.Value);
                Session["TimeZoneID"] = Convert.ToInt32(ddlTimeZone.SelectedItem.Value);
                Session["TimeZone"] = ddlTimeZone.SelectedItem.Text.ToString();
            }
            else
                objBEUser.IntTimeZoneID = 0;
            objBUser.BCommonUpdateTimeZone(objBEUser);
            //trTimeZone.Visible = false;
            if(objBEUser.IntResult==1)
            RoutetoHome();
            else
           ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Time zone Updation falied.Please try again.')", true);
           

           // tblMsg.Visible = true;
            //lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Time zone updated successfully." + "</font>";


        }

        //protected void imgOK_Click(object sender, EventArgs e)
        //{
        //    if (Session["RoleID"] != null)
        //    {
        //        switch (Session["RoleID"].ToString())
        //        {
        //            case "6":

        //                Response.Redirect(EnumAppPage.STUDENT_HOME, false);
        //                break;
        //            case "5":
        //                Response.Redirect(EnumAppPage.PROCTOR_HOME, false);
        //                break;
        //            case "4":
        //                Response.Redirect(EnumAppPage.AUDITOR_HOME, false);
        //                break;
        //            case "3":
        //                Response.Redirect(EnumAppPage.PROVIDER_HOME, false);
        //                break;
        //            case "7":
        //                Response.Redirect(EnumAppPage.ADMIN_HOME, false);
        //                break;

        //        }



        //    }

        //}

        protected void RoutetoHome()
        {
            if (Session["RoleID"] != null)
            {
                switch (Session["RoleID"].ToString())
                {
                    case "6":

                        Response.Redirect(EnumAppPage.STUDENT_HOME, false);
                        break;
                    case "5":
                        Response.Redirect(EnumAppPage.PROCTOR_HOME, false);
                        break;
                    case "4":
                        Response.Redirect(EnumAppPage.AUDITOR_HOME, false);
                        break;
                    case "3":
                        Response.Redirect(EnumAppPage.PROVIDER_HOME, false);
                        break;
                    case "7":
                        Response.Redirect(EnumAppPage.ADMIN_HOME, false);
                        break;
                    case "8":
                        Response.Redirect(EnumAppPage.COURSEADMIN_HOME, false);
                        break;

                }

            }
        }

        protected void ddlTimeZone_ItemDataBound(object sender, Telerik.Web.UI.RadComboBoxItemEventArgs e)
        {
            Telerik.Web.UI.RadComboBoxItem rdCm = e.Item;
            if (rdCm.Text == "Separator")
            {
                rdCm.Text = "----------------------------------------------";
                rdCm.IsSeparator = true;
            }

        }
    }
}