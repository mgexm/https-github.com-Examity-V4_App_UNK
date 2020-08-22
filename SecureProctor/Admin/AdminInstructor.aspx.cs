using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Admin
{
    public partial class AdminInstructor : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + "Instructor";
                ((LinkButton)this.Page.Master.FindControl("lnkInstructor")).CssClass = "main_menu_active";
              
            }



        }

       
        protected void gvInstructor_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GetInstructors();
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
      
      

        protected void GetInstructors()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            new BAdmin().BGetInstructors(objBEAdmin);
            gvInstructor.DataSource = objBEAdmin.DtResult;
            objBEAdmin = null;

        }
    }
}