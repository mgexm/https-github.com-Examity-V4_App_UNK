using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Provider
{
    public partial class ViewStudent : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME +EnumPageTitles.EXAMPROVIDER_VIEWSTUDENT;
                ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
                this.GetStudentDetails();
            }
        }

        protected void GetStudentDetails()
        {
            BEProvider objBEProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEProvider.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["StudentID"].ToString()));
            objBProvider.BGetStudentDetails(objBEProvider);
            if (objBEProvider.DtResult != null)
            {
                if (objBEProvider.DtResult.Rows.Count > 0)
                {
                    lblstudentfirstname.Text = objBEProvider.DtResult.Rows[0]["studentName"].ToString();
                    lblEmail.Text = objBEProvider.DtResult.Rows[0]["EmailAddress"].ToString();
                    lblPhoneNumber.Text = CommonFunctions.CheckNullValue(objBEProvider.DtResult.Rows[0]["PhoneNumber"].ToString());
                    lblTimeZone.Text = objBEProvider.DtResult.Rows[0]["TimeZone"].ToString();
                    lblSpecialNeeds.Text = objBEProvider.DtResult.Rows[0]["SpecialNeeds"].ToString();
                    string imgpath = objBEProvider.DtResult.Rows[0]["PhotoIdentity"].ToString();
                    if (imgpath != "")
                    {
                        //imgstudent.ImageUrl = "~/Student/Student_Identity/" + imgpath.Substring(3).ToString();
                        imgstudent.ImageUrl = new AppSecurity().ImageToBase64(imgpath.Substring(3).ToString());
                    }
                    //if (System.IO.File.Exists(Server.MapPath("../Uploads/StudentIdentity/") + imgpath.ToString()))
                    //    imgstudent.ImageUrl = "../Uploads/StudentIdentity/" + imgpath.ToString();
                    if (objBEProvider.DtResult.Rows[0]["Comments"] != DBNull.Value && objBEProvider.DtResult.Rows[0]["Comments"].ToString() != string.Empty)
                    {
                        lblComments.Text = objBEProvider.DtResult.Rows[0]["Comments"].ToString();
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
                Response.Redirect("ViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&" + Request.QueryString.ToString() + "&" + "Type=View2");
            }
        }

        protected void gvTransDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntStudentID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["StudentID"].ToString()));
                objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBProvider.BGetStudentTransactionsForCurrentProvider(objBEProvider);
                gvTransDetails.DataSource = objBEProvider.DtResult;
            }
            catch (Exception Ex) { }
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