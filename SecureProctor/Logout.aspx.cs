using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["ID"] != null)
            {

                string id = Request.QueryString["ID"].ToString();

                if (id == "1")
                {
                    tdLogOut.Visible = true;
                    tdSession.Visible = false;

                    //hLogout.InnerText = "https://temple.edu";
                    //hLogout.HRef = "https://temple.edu";
                    //lnkSession.InnerText = "https://temple.edu";
                    //lnkSession.HRef = "https://temple.edu";
                    //hLogout.InnerText = "site";
                    //hLogout.HRef = "https://www.coursesites.com";
                    //lnkSession.InnerText = "site";
                    //lnkSession.HRef = "https://www.coursesites.com";
                    hLogout.Text = Resources.ResMessages.LogOut_V;

                    lnkSession.Text = Resources.ResMessages.Session_V;
                    //lblLogout.Visible = true;

                    //lblSession.Visible = false;

                }

                if (id == "0")
                {
                    tdLogOut.Visible = false;
                    tdSession.Visible = true;
                    hLogout.Text = Resources.ResMessages.LogOut_V;

                    lnkSession.Text = Resources.ResMessages.Session_V;
                    //hLogout.InnerText = "site";
                    //hLogout.HRef = "https://www.coursesites.com";
                    //lnkSession.InnerText = "site";
                    //lnkSession.HRef = "https://www.coursesites.com";
                    //lblLogout.Visible = false;

                    //lblSession.Visible = true;

                }
            }

            else
            {
                tdLogOut.Visible = false;
                tdSession.Visible = true;

            }

        }
    }
}