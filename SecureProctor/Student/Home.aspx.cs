using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.IO;

namespace SecureProctor.Student
{
    public partial class Home : BaseClass 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;
            ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {
                CheckExamiKEY();
                this.getPhotoIdentity(); 
            }
        }

        protected void getPhotoIdentity()
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();

                BStudent objBStudent = new BStudent();

                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBStudent.BgetPhotoIdentity(objBEStudent);

                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    string strTotalPath = Server.MapPath("~/Student\\Student_Identity\\" + objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                    if (File.Exists(strTotalPath))
                    {
                        //img.Src = "~/Student\\Student_Identity\\" + objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                        img.Src = new AppSecurity().ImageToBase64(objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                    }
                    else
                    {
                        img.Src = "../Images/noimage.png";
                    }
                }
                else
                {
                    img.Src = "../Images/noimage.png";
                }
            }
            catch (Exception e)
            {

            }

        }

        protected void CheckExamiKEY()
        {

            BEStudent objBEStudent = new BEStudent();

            BStudent objBStudent = new BStudent();

            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            objBStudent.BCheckExamiKEY(objBEStudent);

            if (objBEStudent.BoolResult == true)
            {
                Response.Redirect("UpdateExamiKEY.aspx", false);
            }


        }
    }
}