using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.CourseAdmin
{
    public partial class ViewStudent : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.COURSEADMIN_VIEWSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                this.GetStudentDetails();
            }
        }

        protected void gvTransDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "View")
            {
                Response.Redirect("ViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&" + Request.QueryString.ToString() + "&" + "Type=View2");
            }
        }

        protected void gvTransDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["StudentID"].ToString()));
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBCourseAdmin.BGetStudentTransactionsByLoggedInCourseAdminCourses(objBECourseAdmin);
                gvTransDetails.DataSource = objBECourseAdmin.DtResult;
            }
            catch (Exception ) { }
        }

        #endregion

        #region Methods


        protected void GetStudentDetails()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            objBECourseAdmin.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["StudentID"].ToString()));
            objBCourseAdmin.BGetStudentDetails(objBECourseAdmin);
            if (objBECourseAdmin.DtResult != null)
            {
                if (objBECourseAdmin.DtResult.Rows.Count > 0)
                {
                    lblstudentfirstname.Text = objBECourseAdmin.DtResult.Rows[0]["studentName"].ToString();
                    lblEmail.Text = objBECourseAdmin.DtResult.Rows[0]["EmailAddress"].ToString();
                    lblPhoneNumber.Text = CommonFunctions.CheckNullValue(objBECourseAdmin.DtResult.Rows[0]["PhoneNumber"].ToString());
                    lblTimeZone.Text = objBECourseAdmin.DtResult.Rows[0]["TimeZone"].ToString();
                    lblSpecialNeeds.Text = objBECourseAdmin.DtResult.Rows[0]["SpecialNeeds"].ToString();
                    string imgpath = objBECourseAdmin.DtResult.Rows[0]["PhotoIdentity"].ToString();
                    if (imgpath != "")
                    {
                        //imgstudent.ImageUrl = "~/Student/Student_Identity/" + imgpath.Substring(3).ToString();
                        imgstudent.ImageUrl = new AppSecurity().ImageToBase64(imgpath.Substring(3).ToString());
                    }
                    if (objBECourseAdmin.DtResult.Rows[0]["Comments"] != DBNull.Value && objBECourseAdmin.DtResult.Rows[0]["Comments"].ToString() != string.Empty)
                    {
                        lblComments.Text = objBECourseAdmin.DtResult.Rows[0]["Comments"].ToString();
                    }
                    else
                    {
                        lblComments.Text = "N/A";
                    }
                }
            }
        }


        #endregion

        protected void gvTransDetails_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;

                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
            }
        }

    }
}