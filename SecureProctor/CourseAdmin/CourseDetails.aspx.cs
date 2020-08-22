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
    public partial class CourseDetails : BaseClass
    {
        #region Events

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.COURSEADMIN_COURSEDETAILS;
                ((LinkButton)this.Page.Master.FindControl("lnkCourseDetails")).CssClass = "main_menu_active";
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
                RadGrid innerGrid = (item as GridDataItem).ChildItem.FindControl("gvExamDetails") as RadGrid;
                ImageButton imgCourseID = (item as GridDataItem).FindControl("BtnEditExam") as ImageButton;
                this.GetExamDetails(innerGrid, imgCourseID.CommandArgument.ToString());
            }

            #region Addcourse button hiding code for courseAdmin who has no instructor role.
            ////////////////////////////...Start....//////////////////////////////////////////////////
            /* Hiding AddCourse button if loggedin user has no Instructor Role.
             * BRule: If logged-in user is Only CourseAdmin then he can't add courses or student details
             * If Session["DUALROLE"]==null means has only 'CourseAdmin' role.
             * Role 3 is Instructor.
             */
            //////////////////////////////////////////////////////////////////////////////////////////
            //bool isInstructorRoleExists = false;
            //if (Session["DUALROLE"] != null)
            //{
            //    System.Data.DataSet objDS = (System.Data.DataSet)Session["DUALROLE"];

            //    var row = from DataRow myRow in objDS.Tables[0].Rows
            //              where (int)myRow["RoleID"] == 3
            //              select myRow;
            //    if (row.Count() == 1)
            //        isInstructorRoleExists = true;
            //}
            //if (!isInstructorRoleExists || Session["DUALROLE"] == null)
            //{
            //    GridItem cmdItem = gvCourseDetails.MasterTableView.GetItems(GridItemType.CommandItem)[0];

            //    ImageButton btnImgBtn = cmdItem.FindControl("imgplus") as ImageButton;
            //    btnImgBtn.Visible = false;

            //    LinkButton lnkAdd = cmdItem.FindControl("lnkAddCourse") as LinkButton;
            //    lnkAdd.Visible = false;
            //}
            /////////////////////////////.....End........////////////////////////////////////////////////
            #endregion
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

        #region GetExamDetails

        protected void GetExamDetails(RadGrid rdExams, string strCourseID)
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBExamProvider = new BCourseAdmin();
                objBECourseAdmin.IntCourseID = Convert.ToInt32(strCourseID);
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBExamProvider.BGetExamDetails(objBECourseAdmin);
                rdExams.DataSource = objBECourseAdmin.DtResult;
                rdExams.Rebind();
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        #endregion


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            if (txtCourseID.Text == "")
                objBECourseAdmin.strCourseID = DBNull.Value.ToString();
            else
                objBECourseAdmin.strCourseID = txtCourseID.Text;
            if (txtcoursename.Text == "")
                objBECourseAdmin.strCourseName = DBNull.Value.ToString();
            else
                objBECourseAdmin.strCourseName = txtcoursename.Text;
            // objBEAdmin.strLastName = txtlastname.Text;
            if (txtinstructorname.Text == "")
                objBECourseAdmin.strStudentName = DBNull.Value.ToString();
            else
                objBECourseAdmin.strStudentName = txtinstructorname.Text;

            objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
            // objBEAdmin.strEmailAddress = txtemail.Text;
            objBCourseAdmin.BGetCourseAdminDetails(objBECourseAdmin);
            gvCourseDetails.DataSource = objBECourseAdmin.DtResult;
            gvCourseDetails.DataBind();
            objBECourseAdmin = null;

        }

        #endregion

    }
}