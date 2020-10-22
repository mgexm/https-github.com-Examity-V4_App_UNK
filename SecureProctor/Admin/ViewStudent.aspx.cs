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
    public partial class ViewStudent : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_VIEWSTUDENT;

            this.Page.MaintainScrollPositionOnPostBack = true;
            //((LinkButton)this.Page.Master.FindControl("lnkStudents")).CssClass = "main_menu_active";
            ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";

            this.GetStudentDetails();
        }

        protected void GetStudentDetails()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["StudentID"].ToString()));
            objBAdmin.BGetStudentDetails(objBEAdmin);
            if (objBEAdmin.DtResult != null)
            {
                if (objBEAdmin.DtResult.Rows.Count > 0)
                {
                    lblstudentfirstname.Text = objBEAdmin.DtResult.Rows[0]["studentName"].ToString();
                    lblEmail.Text = objBEAdmin.DtResult.Rows[0]["EmailAddress"].ToString();
                    lblPhoneNumber.Text = CommonFunctions.CheckNullValue(objBEAdmin.DtResult.Rows[0]["PhoneNumber"].ToString());
                    lblTimeZone.Text = objBEAdmin.DtResult.Rows[0]["TimeZone"].ToString();
                    lblSpecialNeeds.Text = objBEAdmin.DtResult.Rows[0]["SpecialNeeds"].ToString();
                    string imgpath = objBEAdmin.DtResult.Rows[0]["PhotoIdentity"].ToString();
                    if (imgpath != "")
                    {
                     //   imgstudent.ImageUrl = "~/Student/Student_Identity/" + imgpath.Substring(3).ToString();
                        imgstudent.ImageUrl = new AppSecurity().ImageToBase64(imgpath.Substring(3).ToString());
                    }
                    //if (imgpath == string.Empty)
                    //    imgstudent.ImageUrl = Server.MapPath("../Images/ImgNoImage.jpg");
                    //else if (System.IO.File.Exists("../Uploads/StudentIdentity/" + imgpath.ToString()))
                    //    imgstudent.ImageUrl = "../Uploads/StudentIdentity/" + imgpath.ToString();
                    //else
                    //    imgstudent.ImageUrl = Server.MapPath("../Images/ImgNoImage.jpg");
                    if (objBEAdmin.DtResult.Rows[0]["Comments"] != DBNull.Value && objBEAdmin.DtResult.Rows[0]["Comments"].ToString() != string.Empty)
                    {
                        lblComments.Text = objBEAdmin.DtResult.Rows[0]["Comments"].ToString();
                    }
                    else
                    {
                        lblComments.Text = "N/A";
                    }
                }
            }
        }

        protected void gvTransDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "View")
            {
                Response.Redirect("AdminViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&" + Request.QueryString.ToString() + "&" + "Type=View2");
            }
        }

        protected void gvTransDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["StudentID"].ToString()));
                // objBEAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBAdmin.BGetStudentTransactionsForAllProviders(objBEAdmin);
                gvTransDetails.DataSource = objBEAdmin.DtResult;
            }
            catch (Exception ) { }
        }

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
