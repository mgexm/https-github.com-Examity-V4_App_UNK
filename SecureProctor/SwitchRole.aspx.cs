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
    public partial class SwitchRole : BaseClass
    {

        protected new void Page_PreInit(object sender, EventArgs e)
        {
            //this code is added by adarsh for finding the browser name to handle the webcam functionality with html5            
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if ((browser.Browser.ToString().Trim() == "Firefox") || (browser.Browser.ToString().Trim() == "Chrome") ||
                (browser.Browser.ToString().Trim() == "Opera") || (browser.Browser.ToString().Trim() == "Edge") || (browser.Browser.ToString().Trim() == "MicrosoftEdge"))
                Session["IsHmlCompliant"] = "Yes";
            else Session["IsHmlCompliant"] = "No";



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DUALROLE"] != null)
                {
                    System.Data.DataSet objDS = (System.Data.DataSet)Session["DUALROLE"];
                    rdRoles.DataSource = objDS.Tables[0];
                    rdRoles.DataTextField = "Role_Name";
                    rdRoles.DataValueField = "UserID";
                    rdRoles.DataBind();
                }
                else
                {
                    Response.Redirect("logout.aspx?ID=" + Request.QueryString["ID"].ToString(), false);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["DUALROLE"] != null)
                {
                    System.Data.DataSet objDS = (System.Data.DataSet)Session["DUALROLE"];
                    for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                    {
                        if (objDS.Tables[0].Rows[i]["UserID"].ToString() == rdRoles.SelectedValue.ToString())
                        {
                            Session[BaseClass.EnumPageSessions.USERID] = objDS.Tables[0].Rows[i]["UserID"].ToString();
                            Session["UserName"] = objDS.Tables[0].Rows[i]["Name"].ToString();
                            Session["EmailID"] = objDS.Tables[0].Rows[i]["UserName"].ToString();
                            Session["TimeZoneID"] = objDS.Tables[0].Rows[i]["id"].ToString();
                            Session["TimeZone"] = objDS.Tables[0].Rows[i]["TimeZone"].ToString();
                            Session["RoleID"] = objDS.Tables[0].Rows[i]["RoleID"].ToString();
                            switch (objDS.Tables[0].Rows[i]["RoleID"].ToString())
                            {
                                case "6":
                                   // ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.STUDENT_HOME, false);
                                    // Response.Redirect(EnumAppPage.STUDENT_MYPROFILE, false);
                                    break;
                                case "5":
                                    //ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.PROCTOR_HOME, false);
                                    break;
                                case "4":
                                   // ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                    Response.Redirect(EnumAppPage.AUDITOR_HOME, false);
                                    break;
                                case "3":
                                   if(ValidateTimeZone())
                                       Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                   else
                                    Response.Redirect(EnumAppPage.PROVIDER_HOME, false);
                                    break;
                                case "7":
                                    //ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                    Response.Redirect(EnumAppPage.ADMIN_HOME, false);
                                    break;
                                case "8":
                                    //ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                        Response.Redirect(EnumAppPage.COURSEADMIN_HOME, false);
                                    break;

                            }
                        //    if (objDS.Tables[0].Rows[i]["RoleID"].ToString() == "6")
                        //        Response.Redirect("Student/Home.aspx", false);
                        //    else if (objDS.Tables[0].Rows[i]["RoleID"].ToString() == "3")
                        //    {
                        //        ValidateTimeZone();
                        //        Response.Redirect("Provider/Home.aspx", false);

                        //    }
                        //    else if (objDS.Tables[0].Rows[i]["RoleID"].ToString() == "7")
                        //        Response.Redirect("Admin/Home.aspx", false);
                        //    else if (objDS.Tables[0].Rows[i]["RoleID"].ToString() == "4")
                        //        Response.Redirect("Auditor/Home.aspx", false);
                        //    else if (objDS.Tables[0].Rows[i]["RoleID"].ToString() == "5")
                        //        Response.Redirect("Proctor/Home.aspx", false);
                        }
                    }
                }
                else
                {
                    Response.Redirect("logout.aspx?ID=" + Request.QueryString["ID"].ToString(), false);
                }
            }
            catch(Exception )
            {
                Response.Redirect("logout.aspx?ID=" + Request.QueryString["ID"].ToString(), false);
            }
        }

        protected bool  ValidateTimeZone()
        {
            
                BECommon objBECommon = new BECommon();
                objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                BCommon objBCommon = new BCommon();
                objBCommon.BValidateTimeZone(objBECommon);
                if (objBECommon.IntResult == 0)
                {
                    return true;
                  }
                else
                {
                    return false;
                }
            }
           

        }
    }
