using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Proctor
{
    public partial class Students : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_STUDENT;
                ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";
            }
        }

        #region gvStudents
        protected void gvStudents_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GetStudents();
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
        protected void gvStudents_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "ExpandCollapse" && !e.Item.Expanded)
            {
                foreach (GridItem item in e.Item.OwnerTableView.Items)
                {
                    if (item.Expanded && item != e.Item)
                    {
                        item.Expanded = false;
                    }
                }


                RadGrid innerGrid = (e.Item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                ImageButton ImgStudentID = (e.Item as GridDataItem).FindControl("BtnViewStudent") as ImageButton;
                Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                this.GetStudentEnrollments(innerGrid, ImgStudentID.CommandArgument.ToString(), lblStatus.Text);
            }
            else if (e.CommandName.ToString() == "View")
            {
                ImageButton ImgStudentID = (e.Item as GridDataItem).FindControl("BtnViewStudent") as ImageButton;
                Response.Redirect("ViewStudent.aspx?StudentID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()));
            }
        }
        #endregion

        protected void GetStudents()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            new BAdmin().BGetStudents(objBEAdmin);
            gvStudents.DataSource = objBEAdmin.DtResult;
            objBEAdmin = null;

        }

        protected void GetStudentEnrollments(RadGrid rdExams, string strStudentID, string Status)
        {
            BEAdmin objBEAdmin = new BEAdmin();
            objBEAdmin.IntStudentID = Convert.ToInt32(strStudentID);

            new BAdmin().BGetStudentEnrollments(objBEAdmin);
            rdExams.DataSource = objBEAdmin.DtResult;
            rdExams.Rebind();
            if (Status == "Inactive")
                rdExams.Columns[3].Visible = false;
            rdExams.Rebind();

            objBEAdmin = null;
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;
                ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";
            }
        }

        protected void lnkStudentLookup_Click(object sender, EventArgs e)
        {
            Response.Redirect(BaseClass.EnumAppPage.PROCTOR_STUDENTLOOKUP);
        }
    }
}