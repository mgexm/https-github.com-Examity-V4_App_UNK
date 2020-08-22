using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Auditor
{
    public partial class StudentLookup : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.AUDITOR_StudentLookUp;
            ((LinkButton)this.Page.Master.FindControl("lnkStudentLookUp")).CssClass = "main_menu_active";
        }

        protected void gvStudentLookUp_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadData()
        {
            try
            {
                BEAuditor objBEAuditor = new BEAuditor();
                BAuditor objBAuditor = new BAuditor();
                objBAuditor.BSearchStudentDetails(objBEAuditor);
                if (objBEAuditor.DtResult.Rows.Count > 0)
                {
                    Session[BaseClass.EnumPageSessions.DATATABLE] = objBEAuditor.DtResult;
                    //ViewState[BaseClass.EnumPageSessions.CurrentPage] = CurrentPage;
                    //this.BindGrid("LOAD");
                    gvStudentLookUp.DataSource = objBEAuditor.DtResult;
                }
                else
                {
                    Session[BaseClass.EnumPageSessions.DATATABLE] = objBEAuditor.DtResult;
                    //ViewState[BaseClass.EnumPageSessions.CurrentPage] = CurrentPage;
                    //this.BindGrid("LOAD");
                    gvStudentLookUp.DataSource = new object[] { }; ;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void lblStudentName_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lblStudentName = (LinkButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

                Response.Redirect("ViewStudentDetails.aspx?Type=s&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected string GetStudentUrl(string StudentID)
        {
            string s = "ViewStudentDetails.aspx?Type=s&" + AppSecurity.Encrypt("StudentID=" + StudentID);
            return s;

        }
    }
}