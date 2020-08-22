using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Data;
using System.IO;


namespace SecureProctor.Provider
{
    public partial class ViewExam : BaseClass
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_VIEW_EXAM;
                this.getSelectedExamDetails();
                this.GetStudentUploadFileStatus();
            }
        }
        #endregion

        protected void GetStudentUploadFileStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStudentUploadFileStatus(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (objBECommon.DtResult.Rows[0][0].Equals(true))
                    trStudentUpload.Visible = true;
                else
                    trStudentUpload.Visible = false;

            }
        }



        #region getSelectedExamDetails
        protected void getSelectedExamDetails()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBProvider.BGetSelectedExamDetails(objBEExamProvider);
                if (objBEExamProvider.DsResult != null)
                {
                    lblCourseName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                    lblExamName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                    lblExamSecurityLevel.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["Description"].ToString();


                    string[] str = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString().Split('.');
                    if (str[0].ToString().Length == 1)
                        lblHoursValue.Text = "0" + str[0].ToString();
                    else
                        lblHoursValue.Text = str[0].ToString();
                    if (str[1].ToString().Length == 1)
                        lblMinutesValue.Text = "0" + str[1].ToString();
                    else
                        lblMinutesValue.Text = str[1].ToString();

                    //lblSpecialNeeds.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["Specialneedsflag"].ToString();
                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["Specialneedsflag"].ToString() == "False")
                    {
                        lblSpecialNeeds.Text = "No";
                    }
                    else
                    {
                        lblSpecialNeeds.Text = "Yes";
                    }
                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["LockDownBrowser"].ToString() == "True")
                    {
                        lblLockdownBrowser.Text = "Yes";
                    }
                    else
                    {
                        lblLockdownBrowser.Text = "No";
                    }


                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PastSpecialRules"].ToString() == "1")
                    {
                        lblNoSpRules.Text = "Yes";
                    }
                    else
                    {
                        lblNoSpRules.Text = "No";
                    }

                    lblExamLink.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != "--")
                    {
                        lblExamStartDate.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                    }

                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != "--")
                    {

                        lblExamEndDate.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();
                    }
                    lblExamPassword.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamPassword"].ToString();
                    lblExamUserName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamUserName"].ToString();
                    lblStudentUploadFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["StudentUploadFile"].ToString();

                    //if (objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "" && objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != "")
                    //{
                    //    lnkUploadFile.Visible = true;
                    //    lblUploadValue.Visible = false;
                    //    lnkUploadFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                    //    lnkUploadFile.CommandArgument = objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();
                    //}
                    //else
                    //{
                    //    lnkUploadFile.Visible = false;
                    //    lblUploadValue.Visible = true;
                    //    lblUploadValue.Text = "N/A";

                    //}

                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"] != null)
                    {
                        if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString() == "1")
                            lblExamFeePaidByConfirm.Text = "University";
                        else if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString() == "2")
                            lblExamFeePaidByConfirm.Text = "Student";
                    }
                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"] != null)
                    {
                        if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString() == "1")
                            lblondemandFeePaidByConfirm.Text = "University";
                        else if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString() == "2")
                            lblondemandFeePaidByConfirm.Text = "Student";
                    }
                }
            }
            catch
            {
            }
        }
        #endregion
       

        

       
    }
}