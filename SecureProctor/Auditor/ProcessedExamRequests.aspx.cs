using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Data;
using Telerik.Web.UI;

namespace SecureProctor.Auditor
{
    public partial class ProcessedExamRequests : BaseClass 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.AUDITOR_PROCESSEDEXAMREQUESTS;
            //((LinkButton)this.Page.Master.FindControl("lnkProcessedExamRequests")).CssClass = "main_menu_active";
            ((LinkButton)this.Page.Master.FindControl("lnkInbox")).CssClass = "main_menu_active";

            //if (!IsPostBack)
            //{
            //    this.LoadData();
            //}
        }

        protected void gvProcessedExamRequest_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadData()
        {
            try
            {
                BEAuditor objBEAuditor = new BEAuditor();
                BAuditor objBAuditor = new BAuditor();
                objBEAuditor.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBAuditor.BProcessedExamRequest(objBEAuditor);
                if (objBEAuditor.DtResult.Rows.Count > 0)
                {
                    //  trGridPages.Visible = true;
                    Session[BaseClass.EnumPageSessions.DATATABLE] = objBEAuditor.DtResult;
                    gvProcessedExamRequest.DataSource = objBEAuditor.DtResult;
                    //ViewState[BaseClass.EnumPageSessions.CurrentPage] = CurrentPage;
                    //this.BindGrid("LOAD");
                }
                else
                {
                    //  trGridPages.Visible = false;
                    Session[BaseClass.EnumPageSessions.DATATABLE] = null;
                    //ViewState[BaseClass.EnumPageSessions.CurrentPage] = CurrentPage;
                    gvProcessedExamRequest.DataSource = new string[] { };
                    //gvProcessedExamRequest.DataBind();
                    //this.SetDefaultPagingImages();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //#region SearchButton
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.LoadData();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw (Ex);
        //    }
        //}
        //#endregion


        protected void gvProcessedExamRequest_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                ////string NextPage = string.Empty;
                ////if (e.CommandName == "ViewVideo")
                ////    NextPage = "ExamDetails.aspx?mode=old&TransID=";
                ////else
                ////    NextPage = "ExamDetails.aspx?mode=new&TransID=";

                ////Response.Redirect(NextPage+AppSecurity.Encrypt(e.CommandArgument.ToString())+"&Type=View", false);

                if (e.CommandName.ToString() == "ViewVideo")
                {
                    Response.Redirect("ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View", false);
                    //Response.Redirect("ExamDetails.aspx?mode=old&TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View", false);
                }
                

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void lblStudentName_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lblStudentName = (LinkButton)sender;
                int StudentID = int.Parse(lblStudentName.CommandArgument.ToString());
                Session[BaseClass.EnumPageSessions.StudentID] = StudentID;

                Response.Redirect("ViewStudentDetails.aspx?Type=P&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void lblinboxlink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inbox.aspx");
        }
        protected string GetStudentUrl(string StudentID)
        {
            string s = "ViewStudentDetails.aspx?Type=P&" + AppSecurity.Encrypt("StudentID=" + StudentID);
            return s;

        }
        protected string GetUrl(string transid)
        {
            string s = "ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(transid) + "&Type=View";
            return s;

        }
        protected void gvProcessedExamRequest_SortCommand(object sender, GridSortCommandEventArgs e)
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