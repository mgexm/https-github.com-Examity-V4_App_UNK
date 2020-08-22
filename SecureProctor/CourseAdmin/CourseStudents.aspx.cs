using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.CourseAdmin
{
    public partial class CourseStudents : System.Web.UI.Page
    {

        #region Events

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = SecureProctor.BaseClass.EnumPageTitles.APPNAME + SecureProctor.BaseClass.EnumPageTitles.COURSEADMIN_COURSESTUDENTS;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";

            }
        }

        #endregion

        #region gvCourseDetails

        protected void gvCourseDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GetCourseDetails();
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void gvCourseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
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

            }
            else if (e.CommandName.ToString() == "ExpandCollapse" && e.Item.Expanded)
            {
                hdExpandValue.Value = "-1";
            }
        }

        protected void gvCourseDetails_PreRender(object sender, EventArgs e)
        {
            if (hdExpandValue.Value != "-1" && gvCourseDetails.Items.Count > 0 && hdExpandValue.Value != gvCourseDetails.Items.Count.ToString())
            {
                GridDataItem item = (GridDataItem)gvCourseDetails.Items[Convert.ToInt32(hdExpandValue.Value)];
                item.Expanded = true;
                RadGrid innerGrid = (item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                ImageButton imgCourseID = (item as GridDataItem).FindControl("BtnEditExam") as ImageButton;
                this.GetStudentEnrollments(innerGrid, imgCourseID.CommandArgument.ToString());
            }           
        }

        #endregion

        #endregion

        #region Methods

        #region GetCourseDetails

        protected void GetCourseDetails()
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBCourseAdmin.BGetCourseDetails(objBECourseAdmin);
                gvCourseDetails.DataSource = objBECourseAdmin.DsResult;
                objBECourseAdmin = null;
                objBCourseAdmin = null;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        #endregion
         

        protected string GetUrl(string studentid)
        {
            string s = "ViewStudent.aspx?StudentID=" + AppSecurity.Encrypt(studentid);
            return s;

        }

        protected void GetStudentEnrollments(RadGrid rdExams, string strCouseId)
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            objBECourseAdmin.IntCourseID = Convert.ToInt32(strCouseId);

            new BCourseAdmin().BGetStudentsByCourseId(objBECourseAdmin);
            rdExams.DataSource = objBECourseAdmin.DtResult;
            rdExams.Rebind();

            foreach (GridColumn column in rdExams.MasterTableView.OwnerGrid.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            rdExams.MasterTableView.FilterExpression = string.Empty;



            objBECourseAdmin = null;

            if (!IsPostBack)
            {
                this.Page.Title = SecureProctor.BaseClass.EnumPageTitles.APPNAME + SecureProctor.BaseClass.EnumPageTitles.HOME;
                ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";
            }
        }

        #endregion

        protected void linkserachstudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetails.aspx");
        }
    }
}