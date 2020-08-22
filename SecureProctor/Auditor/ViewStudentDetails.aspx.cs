using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Auditor
{
    public partial class ViewStudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strStudentID = string.Empty;
            try
            {
                //if (Request.QueryString["Type"] != null)
                //    ((LinkButton)this.Page.Master.FindControl("lnkProcessedExamRequests")).CssClass = "main_menu_active";
                //else
                //    ((LinkButton)this.Page.Master.FindControl("lnkInbox")).CssClass = "main_menu_active";

                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"] == "P")
                    {
                        ((LinkButton)this.Page.Master.FindControl("lnkProcessedExamRequests")).CssClass = "main_menu_active";
                    }
                    else if (Request.QueryString["Type"] == "I")
                    {
                        ((LinkButton)this.Page.Master.FindControl("lnkInbox")).CssClass = "main_menu_active";
                    }
                    else if (Request.QueryString["Type"] == "s")
                    {

                        ((LinkButton)this.Page.Master.FindControl("lnkStudentLookUp")).CssClass = "main_menu_active";
                    }
                }
                if (!IsPostBack)
                {
                    if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    {
                        string strq = Request.QueryString.ToString();
                        string[] qstr = strq.Split('&');
                        string[] strAr = CommonFunctions.UrlDecryptor(Server.UrlDecode(qstr[1].ToString()));

                        foreach (string strItem in strAr)
                        {
                            if (strItem.Contains("StudentID"))
                            {
                                strStudentID = strItem.Split('=')[1].ToString();
                                Session[BaseClass.EnumPageSessions.StudentID] = strStudentID;
                            }
                            else
                                Session[BaseClass.EnumPageSessions.StudentID] = null;
                        }
                    }
                    if (Session[BaseClass.EnumPageSessions.StudentID] != null)
                    {
                        GetStudentDetails(Convert.ToInt32(Session["studentID"]));
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }

        protected void gvExamStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session[BaseClass.EnumPageSessions.StudentID] != null)
                    LoadData(Convert.ToInt32(Session[BaseClass.EnumPageSessions.StudentID]));
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadData(int studentID)
        {
            try
            {
                BEAuditor objBEAuditor = new BEAuditor();

                BAuditor objBAuditor = new BAuditor();

                objBEAuditor.IntStudentID = studentID;
                objBEAuditor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBAuditor.BGetAuditorCourseDetails(objBEAuditor);

                if (objBEAuditor.DtResult.Rows.Count > 0)
                {
                    gvExamStatus.DataSource = objBEAuditor.DtResult;
                }
                else
                {
                    gvExamStatus.DataSource = new object[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void GetStudentDetails(int StudentID)
        {
            BEAuditor objBEAuditor = new BEAuditor();
            BAuditor objBAuditor = new BAuditor();
            //objBEUser.IntStudentID = StudentID;
            objBEAuditor.IntStudentID = StudentID;
            objBAuditor.BGetStudentDetails(objBEAuditor);
            if (objBEAuditor.DtResult != null)
            {
                if (objBEAuditor.DtResult.Rows.Count > 0)
                {
                    lblstudentfirstname.Text = objBEAuditor.DtResult.Rows[0]["studentName"].ToString();
                    lblEmail.Text = objBEAuditor.DtResult.Rows[0]["EmailAddress"].ToString();
                    lblPhoneNumber.Text = objBEAuditor.DtResult.Rows[0]["PhoneNumber"].ToString();
                    lblTimeZone.Text = objBEAuditor.DtResult.Rows[0]["TimeZone"].ToString();
                    string imgpath = objBEAuditor.DtResult.Rows[0]["PhotoIdentity"].ToString();
                    //imgstudent.ImageUrl = "~/Student/Student_Identity/" + imgpath.Substring(3).ToString();
                    imgstudent.ImageUrl = new AppSecurity().ImageToBase64(imgpath.Substring(3).ToString());
                    lblSpecialNeeds.Text = objBEAuditor.DtResult.Rows[0]["SpecialNeeds"].ToString();
                    if (objBEAuditor.DtResult.Rows[0]["Comments"].ToString() != null && objBEAuditor.DtResult.Rows[0]["Comments"].ToString() != string.Empty)
                        lblComments.Text = objBEAuditor.DtResult.Rows[0]["Comments"].ToString();
                    else
                        lblComments.Text = "N/A";

                }
            }
        }

        protected void gvExamStatus_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "ViewVideo")
                {
                    Response.Redirect("ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=ViewDetails", false);
                    //Response.Redirect("ExamDetails.aspx?mode=old&TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=ViewDetails", false);
                }
                
            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }

        protected void gvExamStatus_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lbl = (Label)item.FindControl("lblExamStatus");
                if (lbl.Text == "Scheduled" || lbl.Text == "In progress" || lbl.Text == "Cancelled" || lbl.Text == "Completed" || lbl.Text == "No-show")
                {

                    Label lblView = (Label)item.FindControl("lblView");
                    lblView.Visible = true;
                }
                else
                {
                    LinkButton lnkbtnView = (LinkButton)item.FindControl("lnkView");
                    lnkbtnView.Visible = true;
                }
            }
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