﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Data;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;

namespace SecureProctor.Proctor
{
    public partial class ViewUserDetails : BaseClass
    {
        string strStudentID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;

                    if (Request.QueryString["Type"] != null)
                    {
                        if (Request.QueryString["Type"] == "V")
                        {
                            ((LinkButton)this.Page.Master.FindControl("lnkValidate")).CssClass = "main_menu_active";
                        }
                        if (Request.QueryString["Type"] == "E")
                        {
                            ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";
                        }

                        if (Request.QueryString["Type"] == "s")
                        {
                            ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";
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
            }

            catch (Exception ex)
            {
                throw ex;
            }




        }


        protected void gvStudentExamStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session[BaseClass.EnumPageSessions.StudentID]!= null)
                    BindCourseDetails(Convert.ToInt32(Session[BaseClass.EnumPageSessions.StudentID]));

               
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void GetStudentDetails(int StudentID)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntStudentID = StudentID;

            objBCommon.BGetStudentDetails(objBECommon);
            if (objBECommon.DtResult != null)
            {
                if (objBECommon.DtResult.Rows.Count > 0)
                {
                    //lblstudentfirstname.Text = objBECommon.DsResult.Tables[0].Rows[0]["studentName"].ToString();
                    lblstudentfirstname.Text = objBECommon.DtResult.Rows[0]["FirstName"].ToString() + ' ' + objBECommon.DtResult.Rows[0]["LastName"].ToString();
                    lblEmail.Text = objBECommon.DtResult.Rows[0]["EmailAddress"].ToString();
                    lblPhoneNumber.Text = objBECommon.DtResult.Rows[0]["PhoneNumber"].ToString();
                    lblTimeZone.Text = objBECommon.DtResult.Rows[0]["TimeZone"].ToString();
                    string imgpath = objBECommon.DtResult.Rows[0]["PhotoIdentity"].ToString();
                    if (imgpath != "")
                    {
                       // imgstudent.ImageUrl = "~/Student/Student_Identity/" + imgpath.Substring(3).ToString();
                        imgstudent.ImageUrl = new AppSecurity().ImageToBase64(imgpath.Substring(3).ToString());
                    }
                    lblSpecialNeeds.Text = objBECommon.DtResult.Rows[0]["SpecialNeeds"].ToString();
                    if (objBECommon.DtResult.Rows[0]["Comments"] != DBNull.Value && objBECommon.DtResult.Rows[0]["Comments"].ToString() != string.Empty)
                    {
                        lblComments.Text = objBECommon.DtResult.Rows[0]["Comments"].ToString();
                    }
                    else
                    {
                        lblComments.Text = "N/A";
                    }
                }
            }
        }

        protected void BindCourseDetails(int studentID)
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntStudentID = studentID;
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            objBCommon.BGetStudentCourseDetails(objBECommon);

            if (objBECommon.DtResult.Rows.Count > 0)
                gvStudentExamStatus.DataSource = objBECommon.DtResult;
            else
                gvStudentExamStatus.DataSource = new string[] { };


        }

        protected void gvStudentExamStatus_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lbl = (Label)item.FindControl("lblExamStatus");
                if (lbl.Text == "Scheduled" || lbl.Text == "In progress" || lbl.Text == "Cancelled" || lbl.Text == "No-show")
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

        protected void gvStudentExamStatus_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "view")
            {
               
                Response.Redirect("ViewExamScreens.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View", false);


            }



        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] == "V")
            {
                Response.Redirect("ValidateStudentIdentity.aspx");
            }

            if (Request.QueryString["Type"] == "E")
            {
                Response.Redirect("ExamStatus.aspx");

            }
            if (Request.QueryString["Type"] == "s")
            {
                Response.Redirect("StudentLookup.aspx");

            }
        }

        protected void gvStudentExamStatus_SortCommand(object sender, GridSortCommandEventArgs e)
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