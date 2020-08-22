using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.Data;
using System.Collections.Generic;
using System.Linq;


namespace SecureProctor.CourseAdmin
{
    public partial class Students : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.COURSEADMIN_VIEWSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";
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
                //ErrorHandlers.ErrorLog.WriteError(Ex);
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

        protected void gvStudents_PreRender(object sender, EventArgs e)
        {
            if (hdExpandValue.Value != "-1" && gvStudents.Items.Count > 0 && hdExpandValue.Value != gvStudents.Items.Count.ToString())
            {
                GridDataItem item = (GridDataItem)gvStudents.Items[Convert.ToInt32(hdExpandValue.Value)];
                item.Expanded = true;
                RadGrid innerGrid = (item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                ImageButton ImgStudentID = (item as GridDataItem).FindControl("BtnEditStudent") as ImageButton;
                Label lblStatus = (Label)item.FindControl("lblStatus");
                this.GetStudentEnrollments(innerGrid, ImgStudentID.CommandArgument.ToString(), lblStatus.Text);
            }

            #region AddStudent button hiding code for courseAdmin who has no instructor role.
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
            //    GridItem cmdItem = gvStudents.MasterTableView.GetItems(GridItemType.CommandItem)[0];

            //    ImageButton btnImgBtn = cmdItem.FindControl("imgplus") as ImageButton;
            //    btnImgBtn.Visible = false;

            //    LinkButton lnkAdd = cmdItem.FindControl("lnkAddStudent") as LinkButton;
            //    lnkAdd.Visible = false;
            //}
            /////////////////////////////.....End........////////////////////////////////////////////////
            #endregion
        }

        #endregion

        #endregion

        #region Methods

        protected void GetStudents()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            objBECourseAdmin.IntProviderID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            new BCourseAdmin().BGetProviderStudentsFiltered(objBECourseAdmin);

            gvStudents.DataSource = objBECourseAdmin.DtResult;
            objBECourseAdmin = null;
        }

        protected void GetStudentEnrollments(RadGrid rdExams, string strStudentID, string Status)
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            objBECourseAdmin.IntStudentID = Convert.ToInt32(strStudentID);
            objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            new BCourseAdmin().BGetStudentEnrollments(objBECourseAdmin);
            rdExams.DataSource = objBECourseAdmin.DtResult;
            rdExams.Rebind();
            if (Status == "Inactive")
                rdExams.Columns[3].Visible = false;
            rdExams.Rebind();

            objBECourseAdmin = null;
        }

        #endregion

        #region Commented Code

        //protected void lblStudentName_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ImageButton lblStudentName = (ImageButton)sender;
        //        int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

        //        Response.Redirect("ViewUserDetails.aspx?Type=R&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //}

        //protected void lblStudentNameEdit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ImageButton lblStudentName = (ImageButton)sender;
        //        int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

        //        Response.Redirect("EditUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //}

        //protected void lblStudentNameDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ImageButton lblStudentName = (ImageButton)sender;
        //        int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());

        //        Response.Redirect("DeleteUserDetails.aspx?Type=D&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //}

        //#region AddStudent
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        try
        //        {
        //            BEProvider objBEExamProvider = new BEProvider();
        //            BProvider objBExamProvider = new BProvider();
        //            objBEExamProvider.strFirstName = txtFirstName.Text;
        //            objBEExamProvider.strLastName = txtLastName.Text;
        //            objBEExamProvider.strEmailAddress = txtEmailAddress.Text;
        //            objBEExamProvider.StrComments = txtcomments.Value;
        //            if (chk.Checked == true)
        //            {
        //                objBEExamProvider.strSpecialNeeds = true;
        //            }
        //            else
        //            {
        //                objBEExamProvider.strSpecialNeeds = false;
        //            }
        //            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtEmailAddress.Text != "")
        //            {
        //                objBExamProvider.BSaveStudentDetails(objBEExamProvider);

        //                if (objBEExamProvider.IntResult == 0)
        //                {
        //                    //lblSuccess1.Text = "Student is enrolled successfully";
        //                    //lblSuccess1.Text = "Student is enrolled successfully";
        //                    lblSuccess1.Text = Resources.AppMessages.Provider_Students_Success_StudentEnrollment;
        //                    LoadDataTable();
        //                    this.clearDetails();
        //                }

        //                if (objBEExamProvider.IntResult == 1)
        //                {
        //                    //lblSuccess1.Text = "Student already Exists";
        //                    lblSuccess1.Text = Resources.AppMessages.Provider_Students_Error_StudentExists;
        //                    this.clearDetails();
        //                }
        //            }
        //            else
        //            {
        //                lblSuccess1.Text = "";
        //            }
        //        }
        //        catch (Exception Ex)
        //        {
        //        }
        //    }
        //}

        //#endregion

        //protected void gvExamStatus_ItemDataBound(object sender, GridItemEventArgs e)
        //{

        //    if (e.Item is GridDataItem)
        //    {
        //        GridDataItem item = (GridDataItem)e.Item;
        //        //Label lblFlag = item.FindControl("lblFlag") as Label;
        //        Label lblStatus = item.FindControl("lblStatus") as Label;

        //        if (lblStatus.Text != "Active")
        //        {
        //            Label lblMsg = (Label)item.FindControl("lblMsg");
        //            ImageButton btnView = (ImageButton)item.FindControl("lblView");
        //            ImageButton btnEdit = (ImageButton)item.FindControl("lblEdit");
        //            ImageButton btnDelete = (ImageButton)item.FindControl("lblDelete");
        //            btnView.Visible = false;
        //            btnEdit.Visible = false;
        //            btnDelete.Visible = false;
        //            lblMsg.Visible = true;
        //            //lblMsg.Text = "Not yet registered.";
        //        }
        //    }
        //}

        //protected void chk_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk.Checked == true)
        //    {
        //        trcomments.Visible = true;
        //    }
        //    else
        //    {
        //        trcomments.Visible = false;
        //        txtcomments.Value = "";
        //    }
        //}

        #endregion

    }
}