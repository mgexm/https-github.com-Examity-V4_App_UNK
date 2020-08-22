using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;

namespace SecureProctor.Admin
{
    public partial class CourseDetails : BaseClass
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_VIEWCOURSE;
                ((LinkButton)this.Page.Master.FindControl("lnkCourses")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";
            }
        }
        #endregion
        #region GetCourseDetails
        protected void GetCourseDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                if (txtCourseID.Text == "")
                    objBEAdmin.strCourseID = DBNull.Value.ToString();
                else
                    objBEAdmin.strCourseID = txtCourseID.Text;
                if (txtcoursename.Text == "")
                    objBEAdmin.strCourseName = DBNull.Value.ToString();
                else
                    objBEAdmin.strCourseName = txtcoursename.Text;
                // objBEAdmin.strLastName = txtlastname.Text;
                if (txtinstructorname.Text == "")
                    objBEAdmin.strStudentName = DBNull.Value.ToString();
                else
                    objBEAdmin.strStudentName = txtinstructorname.Text;

                // objBEAdmin.strEmailAddress = txtemail.Text;
                new BAdmin().BGetCourseExamDetails(objBEAdmin);
                gvCourseDetails.DataSource = objBEAdmin.DtResult;
                objBEAdmin = null;

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
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntCourseID = Convert.ToInt32(strCourseID);
                objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBAdmin.BGetExamDetails(objBEAdmin);
                rdExams.DataSource = objBEAdmin.DtResult;
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

        //protected void gvCourseDetails_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if (e.Item is GridDataItem)
        //    {
        //        GridDataItem dataBoundItem = e.Item as GridDataItem;
        //        if (dataBoundItem["Status"].Text == "Deleted")
        //            dataBoundItem["Status"].ForeColor = System.Drawing.Color.FromName(Resources.AppControls.Deleted_Text);
        //            //dataBoundItem.CssClass = "DeletedText";
        //    }
        //}


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
        #endregion

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


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BEAdmin objBEAdmin = new BEAdmin();
            if (txtCourseID.Text == "")
                objBEAdmin.strCourseID = DBNull.Value.ToString();
            else
                objBEAdmin.strCourseID = txtCourseID.Text;
            if (txtcoursename.Text == "")
                objBEAdmin.strCourseName = DBNull.Value.ToString();
            else
                objBEAdmin.strCourseName = txtcoursename.Text;
            // objBEAdmin.strLastName = txtlastname.Text;
            if (txtinstructorname.Text == "")
                objBEAdmin.strStudentName = DBNull.Value.ToString();
            else
                objBEAdmin.strStudentName = txtinstructorname.Text;

            // objBEAdmin.strEmailAddress = txtemail.Text;
            new BAdmin().BGetCourseExamDetails(objBEAdmin);
            gvCourseDetails.DataSource = objBEAdmin.DtResult;
            gvCourseDetails.DataBind();
            objBEAdmin = null;

        }
    }

}