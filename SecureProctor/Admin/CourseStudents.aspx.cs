using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Admin
{
    public partial class CourseStudents : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_STUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";
            }
        }

        #region GetCourseDetails
        protected void GetCourseDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBAdmin.BGetCourseDetails_CourseStudents(objBEAdmin);
                gvStudents.DataSource = objBEAdmin.DtResult;
                objBEAdmin = null;
                objBAdmin = null;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
        #endregion

        #region gvStudents
        protected void gvStudents_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GetCourseDetails();
               // GetStudents();
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
                hdExpandValue.Value = e.Item.ItemIndex.ToString();
                //RadGrid innerGrid = (e.Item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                //ImageButton ImgStudentID = (e.Item as GridDataItem).FindControl("BtnEditStudent") as ImageButton;
                //Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                //this.GetStudentEnrollments(innerGrid, ImgStudentID.CommandArgument.ToString(), lblStatus.Text);
            }
            else if (e.CommandName.ToString() == "ExpandCollapse" && e.Item.Expanded)
            {
                hdExpandValue.Value = "-1";
                
            }
            else if (e.CommandName.ToString() == "View")
            {
                ImageButton ImgStudentID = (e.Item as GridDataItem).FindControl("BtnEditStudent") as ImageButton;
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

        protected void GetStudentEnrollments(RadGrid rdExams, string strCouseId, string providerId)
        {
            BEAdmin objBEAdmin = new BEAdmin();
            objBEAdmin.IntCourseID = Convert.ToInt32(strCouseId);
            objBEAdmin.IntProviderID = Convert.ToInt32(providerId);

            new BAdmin().BGetCourseStudents(objBEAdmin);
            rdExams.DataSource = objBEAdmin.DtResult;
            rdExams.Rebind();
            //if (Status == "Inactive")
            //    rdExams.Columns[3].Visible = false;
           // rdExams.Rebind();
            foreach (GridColumn column in rdExams.MasterTableView.OwnerGrid.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            rdExams.MasterTableView.FilterExpression = string.Empty;

            objBEAdmin = null;
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;
                ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";
            }
        }

        protected void gvStudents_PreRender(object sender, EventArgs e)
        {
            if (hdExpandValue.Value != "-1" && gvStudents.Items.Count > 0 && hdExpandValue.Value != gvStudents.Items.Count.ToString())
            {
                GridDataItem item = (GridDataItem)gvStudents.Items[Convert.ToInt32(hdExpandValue.Value)];
                item.Expanded = true;
                RadGrid innerGrid = (item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                ImageButton imgCourseID = (item as GridDataItem).FindControl("BtnEditExam") as ImageButton;
                HiddenField imgproviderId = (item as GridDataItem).FindControl("hdnProvider") as HiddenField;
                
                //Label lblStatus = (Label)item.FindControl("lblStatus");
                this.GetStudentEnrollments(innerGrid, imgCourseID.CommandArgument.ToString(), imgproviderId.Value);
            }
        }

        protected string GetUrl(string studentid)
        {
            string s = "ViewStudent.aspx?StudentID=" + AppSecurity.Encrypt(studentid);
            return s;

        }

        protected void linkserachstudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetails.aspx");
        }
    }

}