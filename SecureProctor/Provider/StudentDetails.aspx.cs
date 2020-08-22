using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Provider
{
    public partial class StudentDetails : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_VIEWSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                hdExpandValue.Value = "-1";
               // gvStudents.DataSource = new Object[0];
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

                //RadGrid innerGrid = (e.Item as GridDataItem).ChildItem.FindControl("gvEnrollments") as RadGrid;
                //ImageButton ImgStudentID = (e.Item as GridDataItem).FindControl("BtnEditStudent") as ImageButton;
                //Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                //this.GetStudentEnrollments(innerGrid, ImgStudentID.CommandArgument.ToString(), lblStatus.Text);
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
        }
        #endregion

        protected void GetStudents()
        {
            BEProvider objBEProvider = new BEProvider();

            objBEProvider.IntProviderID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            if (txtfirstname.Text == "")
                objBEProvider.strFirstName = DBNull.Value.ToString();
            else
                objBEProvider.strFirstName = txtfirstname.Text;
            if (txtlastname.Text == "")
                objBEProvider.strLastName = DBNull.Value.ToString();
            else
                objBEProvider.strLastName = txtlastname.Text;
            // objBEAdmin.strLastName = txtlastname.Text;
            if (txtemail.Text == "")
                objBEProvider.strEmailAddress = DBNull.Value.ToString();
            else
                objBEProvider.strEmailAddress = txtemail.Text;

            // objBEAdmin.strEmailAddress = txtemail.Text;
            new BProvider().BGetStudentsDetails(objBEProvider);
            gvStudents.DataSource = objBEProvider.DtResult;
            
            objBEProvider = null;
        }

        protected void GetStudentEnrollments(RadGrid rdExams, string strStudentID, string Status)
        {
            BEProvider objBEProvider = new BEProvider();
            objBEProvider.IntStudentID = Convert.ToInt32(strStudentID);
            objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            new BProvider().BGetStudentEnrollments(objBEProvider);
            rdExams.DataSource = objBEProvider.DtResult;
            rdExams.Rebind();
            if (Status == "Inactive")
                rdExams.Columns[3].Visible = false;
            rdExams.Rebind();

            objBEProvider = null;
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BEProvider objBEProvider = new BEProvider();

            objBEProvider.IntProviderID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            if (txtfirstname.Text == "")
                objBEProvider.strFirstName = DBNull.Value.ToString();
            else
                objBEProvider.strFirstName = txtfirstname.Text;
            if (txtlastname.Text == "")
                objBEProvider.strLastName = DBNull.Value.ToString();
            else
                objBEProvider.strLastName = txtlastname.Text;
            // objBEAdmin.strLastName = txtlastname.Text;
            if (txtemail.Text == "")
                objBEProvider.strEmailAddress = DBNull.Value.ToString();
            else
                objBEProvider.strEmailAddress = txtemail.Text;

            // objBEAdmin.strEmailAddress = txtemail.Text;
            new BProvider().BGetStudentsDetails(objBEProvider);
            gvStudents.DataSource = objBEProvider.DtResult;
            gvStudents.DataBind();
            objBEProvider = null;
        }


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
    }
}