using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.Data;
using System.IO;
using System.Configuration;
using System.Net;


namespace SecureProctor.Proctor
{
    public partial class AutoProctorInbox : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.AUTOPROC_INBOX;
            ((LinkButton)this.Page.Master.FindControl("lnkAutoProctor")).CssClass = "main_menu_active";
            if (!IsPostBack)
                lblSuccess.Text = string.Empty;
        }

        protected void gvAutoProctorInbox_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
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
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                //BEAuditor objBEAuditor = new BEAuditor() { };
                objBEProctor.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBProctor.BGetAutoProctorInbox(objBEProctor);
                if (objBEProctor.objDs.Tables[1].Rows.Count > 0)
                {
                    // trGridPages.Visible = true;
                    Session[BaseClass.EnumPageSessions.DATATABLE] = objBEProctor.objDs.Tables[1];
                    //ViewState[BaseClass.EnumPageSessions.CurrentPage] = CurrentPage;
                    // lblCount.Text = objBEAuditor.objDs.Tables[0].Rows[0]["TRANSID"].ToString();
                    //this.BindGrid("LOAD");
                    gvAutoProctorInbox.DataSource = objBEProctor.objDs.Tables[1];
                    //gvAuditorInbox.DataBind();
                    btnApprove.Visible = true;
                }
                else
                {
                    // trGridPages.Visible = false;
                    Session[BaseClass.EnumPageSessions.DATATABLE] = null;
                    //ViewState[BaseClass.EnumPageSessions.CurrentPage] = CurrentPage;
                    //  lblCount.Text = "0";
                    gvAutoProctorInbox.DataSource = new object[] { };

                    //gvAuditorInbox.DataBind();
                    btnApprove.Visible = false;
                    //this.SetDefaultPagingImages();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected string GetStudentUrl(string StudentID)
        {
            string s = "ViewUserDetails.aspx?Type=I&" + AppSecurity.Encrypt("StudentID=" + StudentID);
            return s;

        }
        protected string GetUrl(string transid)
        {
            string s = "AutoExamDetails.aspx?TransID=" + AppSecurity.Encrypt(transid);
            return s;

        }
        protected void gvAutoProctorInbox_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                //if (e.CommandName.ToString() == "ViewVideo")
                //{
                //    Response.Redirect("ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);

                //    //   Response.Redirect("ExamDetails.aspx?mode=old&TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);
                //}

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void gvAutoProctorInbox_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                ////GridDataItem item = (GridDataItem)e.Item;
                ////Label lblTransID = (Label)item.FindControl("lblExamID");
                ////HyperLink lnkView = (HyperLink)item.FindControl("lnkView");


                //string fileName = lblTransID.Text + ".mp4";
                //string clientname = ConfigurationManager.AppSettings["clientname"];
                //string transid = lblTransID.Text;
                ////  string transid = "24100057";
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["Rackservice"] + transid + "/" + clientname);
                //request.Method = "GET";
                //WebResponse response = request.GetResponse();
                //Stream str = response.GetResponseStream();
                //StreamReader reader = new StreamReader(str);
                //string responseFromServer = reader.ReadToEnd();

                //BECommon objBECommon = new BECommon();
                //BCommon objBCommon = new BCommon();
                //string transid = lblTransID.Text;
                //objBECommon.IntTransID = Convert.ToInt32(transid);
                //objBCommon.BAuditorCheckVideoLink(objBECommon);

                //if (objBECommon.IntstatusFlag == 1)
                //{
                //    lnkView.Visible = true;
                //}
                //else
                //{
                //    lnkView.Visible = false;

                //}
            }




        }
        protected void gvAutoProctorInbox_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            //if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            //{
            //    GridSortExpression sortExpr = new GridSortExpression();
            //    sortExpr.FieldName = e.SortExpression;
            //    sortExpr.SortOrder = GridSortOrder.Ascending;

            //    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
            //}
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string strTransID = string.Empty;
            //foreach (GridViewRow row in gvAuditorInbox.Rows)
            //{
            //    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkSelect");
            //    if (chk.Checked == true)
            //    {
            //        Label lbl = (Label)row.Cells[1].FindControl("lblExamID");
            //        strTransID = strTransID + lbl.Text.ToString() + "$";
            //    }
            //}

            foreach (GridDataItem item in gvAutoProctorInbox.Items)
            {
                CheckBox chk = (CheckBox)item.Cells[0].FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    Label lbl = (Label)item.Cells[1].FindControl("lblExamID");
                    strTransID = strTransID + lbl.Text.ToString() + "$";
                }
            }
            if (strTransID != string.Empty)
            {
                strTransID = strTransID.Substring(0, strTransID.Length - 1);
                
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.strTransID = strTransID;
                objBEProctor.IntEmployeeID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBProctor.BApproveAutoProcTransaction(objBEProctor);
                objBEProctor = null;
                objBEProctor = null;
                //foreach (GridDataItem item in gvAuditorInbox.Items)
                //{
                //    CheckBox chk = (CheckBox)item.Cells[0].FindControl("chkSelect");
                //    //EmailMsg obj;
                //    if (chk.Checked == true)
                //    {
                //BEAuditor objBEAuditor1 = new BEAuditor();
                BAuditor objBAuditor1 = new BAuditor();
                BEProctor objBEProctor1 = new BEProctor();
                BProctor objBProctor1 = new BProctor();
                objBEProctor1.strTransID = strTransID;

                objBProctor1.BGetAutoProctorProviderDetails(objBEProctor1);
                if (objBEProctor1.DsResult.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < objBEProctor1.DsResult.Tables[0].Rows.Count; i++)
                    {
                        DataTable objDT = new DataTable();

                        objDT = objBEProctor1.DsResult.Tables[0];

                        objBEProctor1.IntUserID = Convert.ToInt32(objDT.Rows[i]["ExamProviderID"]);

                        objBEProctor1.IntProviderID = Convert.ToInt32(objDT.Rows[i]["UserID"]);

                        objBEProctor1.IntTransID = Convert.ToInt64(objDT.Rows[i]["TransID"]);


                        //BEMail objBEMail = new BEMail();
                        //BMail objBMail = new BMail();
                        //objBEMail.IntTransID = objBEProctor1.IntTransID;
                        //string FYI = "FYI";
                        //string mail = "Mail";
                        //if (mail == "Mail")
                        //{
                        //    objBEMail.IntUserID = objBEAuditor1.IntUserID;
                        //    objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovedbyAuditor.ToString();
                        //    objBMail.BSendEmail(objBEMail);

                        //}

                        //if (FYI == "FYI")
                        //{
                        //    BECommon objBECommon = new BECommon();
                        //    BCommon objBCommon = new BCommon();
                        //    objBECommon.IntTransID = objBEProctor1.IntTransID;
                        //    objBCommon.BAuditorCheckEmailForApproval(objBECommon);

                        //    if (objBECommon.IntstatusFlag == 1)
                        //    {
                        //        objBEMail.IntUserID = objBEProctor1.IntUserID;

                        //        objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovedbyAuditorFYI.ToString();
                        //        objBMail.BSendEmail(objBEMail);
                        //    }

                        //}
                    }




                    // Label lbl = (Label)item.Cells[1].FindControl("lblExamID");

                }


                lblSuccess.Text = Resources.ResMessages.Audit_TransApprove;

                // this.LoadData();
                gvAutoProctorInbox.Rebind();
            }

            else
            {

                lblSuccess.Text = Resources.ResMessages.Audit_TransSelect;
            }
        }

    }
}