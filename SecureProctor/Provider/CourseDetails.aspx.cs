using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;

namespace SecureProctor.Provider
{
    //public partial class CourseDetails : BaseClass
    //{
        
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        Page.MaintainScrollPositionOnPostBack = true;
    //        this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS;
    //        ((LinkButton)this.Page.Master.FindControl("lnkCourseDetails")).CssClass = "main_menu_active";

    //        lblSuccess.Text = string.Empty;
    //    }

    //    protected void gvCourseDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //    {
    //        try
    //        {
    //            GetCourseDetails();
    //        }
    //        catch (Exception Ex)
    //        {
    //            throw Ex;
    //        }
    //    }

    //    protected void BtnSaveCourse_Click(object sender, EventArgs e)
    //    {
    //        if (Page.IsValid)
    //        {
    //            BEProvider objBEExamProvider = new BEProvider();
    //            BProvider objBProvider = new BProvider();
    //            objBEExamProvider.strCourseID = txtCourseID.Text;
    //            objBEExamProvider.strCourseName = txtCourseName.Text;
    //            objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
    //            objBProvider.BSaveCourseDetails(objBEExamProvider);



    //            if (objBEExamProvider.DsResult.Tables[0].Rows.Count > 0)
    //            {
    //                if (Convert.ToInt32(objBEExamProvider.DsResult.Tables[0].Rows[0][0]) == 1)
    //                {

    //                    lblSuccess.Text = Resources.ResMessages.Provider_CourseSuccess;
    //                    lblSuccess.ForeColor = System.Drawing.Color.Green;
    //                    gvCourseDetails.Rebind();
    //                    this.Clear();

    //                }

    //                else
    //                {

    //                    lblSuccess.Text = Resources.ResMessages.Provider_CourseExists;
    //                    lblSuccess.ForeColor = System.Drawing.Color.Red;
    //                    this.Clear();

    //                }

    //            }

    //        }
    //    }

    //    protected void Clear()
    //    {

    //        txtCourseID.Text = "";

    //        txtCourseName.Text = "";
    //    }

    //    protected void BtnClear_Click(object sender, EventArgs e)
    //    {

    //        txtCourseID.Text = "";

    //        txtCourseName.Text = "";
    //    }

    //    protected void GetCourseDetails()
    //    {
    //        BEProvider objBEExamProvider = new BEProvider();
    //        BProvider objBProvider = new BProvider();
    //        objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
    //        objBEExamProvider.IntCourseID = 0;
    //        objBProvider.BGetCourseDetails(objBEExamProvider);
    //        gvCourseDetails.DataSource = objBEExamProvider.DsResult;
    //    }

    //    protected void gvCourseDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    //    {
    //        if (e.CommandName.ToString() == "EditCourse")
    //            Response.Redirect("EditCourse.aspx?CourseID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=Edit");

    //    }

    //    protected void lblExamDetailslink_Click(object sender, EventArgs e)
    //    {
    //        //Response.Redirect("ProcessedExamRequests.aspx");
    //        Response.Redirect(BaseClass.EnumAppPage.PROVIDER_EXAMDETAILS);
    //    }

    //}

     public partial class CourseDetails : BaseClass
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS;
                ((LinkButton)this.Page.Master.FindControl("lnkCourseDetails")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";
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
        #region GetExamDetails
        protected void GetExamDetails(RadGrid rdExams, string strCourseID)
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(strCourseID);
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBExamProvider.BGetExamDetails(objBEExamProvider);
                rdExams.DataSource = objBEExamProvider.DtResult;
                rdExams.Rebind();                          
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
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
                //RadGrid innerGrid = (e.Item as GridDataItem).ChildItem.FindControl("gvExamDetails") as RadGrid;
                //ImageButton imgCourseID = (e.Item as GridDataItem).FindControl("BtnEditExam") as ImageButton;
                //this.GetExamDetails(innerGrid, imgCourseID.CommandArgument.ToString());                
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
                RadGrid innerGrid = (item as GridDataItem).ChildItem.FindControl("gvExamDetails") as RadGrid;
                ImageButton imgCourseID = (item as GridDataItem).FindControl("BtnEditExam") as ImageButton;
                this.GetExamDetails(innerGrid, imgCourseID.CommandArgument.ToString());
            }
        }
        #endregion
    }

}