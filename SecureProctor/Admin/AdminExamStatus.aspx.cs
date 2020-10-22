using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;

namespace SecureProctor.Admin
{
    public partial class AdminExamStatus : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_EXAMSTATUS;
                ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";

               // this.BindExams();
            }

        }

        protected void gvExamStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.BindExams();
            }
            catch (Exception )
            {

            }
        }

        //#region SearchButton
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.BindExams();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw (Ex);
        //    }
        //}
        //#endregion


        #region BindExams
        protected void BindExams()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBAdmin.BGetAdminExamStatus(objBEAdmin);
                if (objBEAdmin.DtResult.Rows.Count > 0)
                    gvExamStatus.DataSource = objBEAdmin.DtResult;
                else
                    gvExamStatus.DataSource = new string[] { };

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region StudentName click
        protected void btnStudentName_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnStudentName = (LinkButton)sender;
                int StudentID = int.Parse(btnStudentName.CommandArgument.ToString());

                Response.Redirect("AdminViewUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        protected void gvExamStatus_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "view")
            {
                Response.Redirect("AdminViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View", false);


            }



        }
        protected void gvExamStatus_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lbl = (Label)item.FindControl("lblExamStatus");
                //TableCell Alert = item["Alert"];

                //if ((Convert.ToInt16(Alert.Text) > 0))
                //{
                //    item.ForeColor = System.Drawing.Color.Orange;
                //    item.Font.Bold = true;

                //    LinkButton lnkFname = (LinkButton)item.FindControl("btnStudentFirstName");
                //    LinkButton lnkLname = (LinkButton)item.FindControl("btnStudentLastName");
                //    lnkFname.ForeColor = System.Drawing.Color.Orange;
                //    lnkLname.ForeColor = System.Drawing.Color.Orange;
                //}
                if (lbl.Text == "Scheduled" || lbl.Text == "In progress" || lbl.Text == "Cancelled" || lbl.Text == "No-show" || lbl.Text == "Exam Started" || lbl.Text == "Pending at Auditor" || lbl.Text == "Completed")
                {

                    Label lblView = (Label)item.FindControl("lblView");
                    lblView.Visible = true;


                }
                else
                {
                    HyperLink lnkbtnView = (HyperLink)item.FindControl("lnkView");
                    lnkbtnView.Visible = true;

                }

            }


        }
        protected string GetStudentUrl(string StudentID)
        {
            string s = "AdminViewUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + StudentID);
            return s;

        }
        protected string GetUrl(string transid)
        {
            string s = "AdminViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(transid) + "&Type=View";
            return s;

        }
        protected void gvExamStatus_SortCommand(object sender, GridSortCommandEventArgs e)
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