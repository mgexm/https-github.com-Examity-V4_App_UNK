using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;


namespace SecureProctor.Provider
{
    public partial class CourseStudents : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_VIEWSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";
            }
        }

        #region gvStudents
        protected void gvCourseDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GetCourseDetails();
            }
            catch (Exception Ex)
            {
                //ErrorHandlers.ErrorLog.WriteError(Ex);
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
        protected void gvCourseDetails_PreRender(object sender, EventArgs e)
        {
            if (hdExpandValue.Value != "-1" && gvCourseDetails.Items.Count > 0 && hdExpandValue.Value != gvCourseDetails.Items.Count.ToString())
            {
                GridDataItem item = (GridDataItem)gvCourseDetails.Items[Convert.ToInt32(hdExpandValue.Value)];
                item.Expanded = true;
                RadGrid innerGrid = (item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                ImageButton imgCourseID = (item as GridDataItem).FindControl("BtnEditExam") as ImageButton;
              
                int IntProviderID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                this.GetStudentEnrollments(innerGrid, imgCourseID.CommandArgument.ToString(), IntProviderID);
            }
        }
        #endregion

        #region GetCourseDetails
        protected void GetCourseDetails()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBProvider.BGetCourseDetails(objBEExamProvider);
                gvCourseDetails.DataSource = objBEExamProvider.DsResult;

                objBEExamProvider = null;
                objBProvider = null;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
        #endregion

        protected void GetStudentEnrollments(RadGrid rdExams, string strCourseID,  int IntProviderID)
        {
            BEProvider objBEProvider = new BEProvider();
            objBEProvider.IntCourseID = Convert.ToInt32(strCourseID);
            objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            new BProvider().BGetCourseStudents(objBEProvider);
            rdExams.DataSource = objBEProvider.DtResult;
            rdExams.Rebind();

            foreach (GridColumn column in rdExams.MasterTableView.OwnerGrid.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            rdExams.MasterTableView.FilterExpression = string.Empty;

            objBEProvider = null;
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




