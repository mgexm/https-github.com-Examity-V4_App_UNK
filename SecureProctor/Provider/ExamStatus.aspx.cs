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

namespace SecureProctor.Provider
{
    public partial class ExamStatus : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_EXAMSTATUS;
                    ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";

                   // this.BindExams();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void gvExamStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.BindExams();
            }
            catch (Exception Ex)
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
                BEProvider objBEProvider = new BEProvider();
                objBEProvider.IntTransID = 0;
                objBEProvider.strExamName = string.Empty;
                objBEProvider.strStudentName = string.Empty;
                objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                new BProvider().BGetProviderExams(objBEProvider);
                if (objBEProvider.DtResult.Rows.Count > 0)
                    gvExamStatus.DataSource = objBEProvider.DtResult;
                else
                    gvExamStatus.DataSource = new object[] { };

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

                Response.Redirect("ViewUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        protected void gvExamStatus_ItemCommand(object sender, GridCommandEventArgs e)
        {


            //string NextPage = string.Empty;
            //if (e.CommandName == "view")
            //    NextPage = "ViewExamScreens.aspx?mode=old&TransID=";
            //else
            //    NextPage = "ViewExamScreens.aspx?mode=new&TransID=";


           // Response.Redirect(NextPage+AppSecurity.Encrypt(e.CommandArgument.ToString())+"&Type=View", false);

            if (e.CommandName == "view")
            {
                Response.Redirect("ViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View", false);
                //Response.Redirect("ViewExamScreens.aspx?mode=old&TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View", false);
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

                //    LinkButton lnkFname=(LinkButton)item.FindControl("btnStudentFirstName");
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
            string s = "ViewUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + StudentID);
            return s;

        }
        protected string GetUrl(string transid)
        {
            string s = "ViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(transid) + "&Type=View";
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