using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Data;
using System.IO;


namespace SecureProctor.CourseAdmin
{
    public partial class ViewExam : BaseClass
    {
        #region Events

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

        #region Methods

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
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBCourseAdmin.BGetSelectedExamDetails(objBECourseAdmin);
                if (objBECourseAdmin.DsResult != null)
                {
                    lblCourseName.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                    lblExamName.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                    lblExamSecurityLevel.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["Description"].ToString();


                    string[] str = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString().Split('.');
                    if (str[0].ToString().Length == 1)
                        lblHoursValue.Text = "0" + str[0].ToString();
                    else
                        lblHoursValue.Text = str[0].ToString();
                    if (str[1].ToString().Length == 1)
                        lblMinutesValue.Text = "0" + str[1].ToString();
                    else
                        lblMinutesValue.Text = str[1].ToString();

                    //lblSpecialNeeds.Text = objBEExamProvider.DsResult.Tables[1].Rows[0]["Specialneedsflag"].ToString();
                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["Specialneedsflag"].ToString() == "False")
                    {
                        lblSpecialNeeds.Text = "No";
                    }
                    else
                    {
                        lblSpecialNeeds.Text = "Yes";
                    }
                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["LockDownBrowser"].ToString() == "True")
                    {
                        lblLockdownBrowser.Text = "Yes";
                    }
                    else
                    {
                        lblLockdownBrowser.Text = "No";
                    }

                    //20/9/2016

                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PastSpecialRules"].ToString() == "1")
                    {
                        lblNoSpRules.Text = "Yes";
                    }
                    else
                    {
                        lblNoSpRules.Text = "No";
                    }


                    lblExamLink.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != null && objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != "--")
                    {
                        lblExamStartDate.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                    }

                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != null && objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != "--")
                    {

                        lblExamEndDate.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();
                    }
                    lblExamPassword.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamPassword"].ToString();
                    lblExamUserName.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["ExamUserName"].ToString();

                    lblStudentUploadFile.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["StudentUploadFile"].ToString();

                    //if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "" && objBECourseAdmin.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != "")
                    //{
                    //    lnkUploadFile.Visible = true;
                    //    lblUploadValue.Visible = false;
                    //    lnkUploadFile.Text = objBECourseAdmin.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                    //    lnkUploadFile.CommandArgument = objBECourseAdmin.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();
                    //}
                    //else
                    //{
                    //    lnkUploadFile.Visible = false;
                    //    lblUploadValue.Visible = true;
                    //    lblUploadValue.Text = "N/A";

                    //}

                    //if (objBECourseAdmin.DsResult.Tables[4].Rows.Count > 0)
                    //{
                    //    ucUploadFiles.Visible = true;

                    //}
                    //else
                    //    ucUploadFiles.Visible = false;

                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"] != null)
                    {
                        if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString() == "1")
                            lblExamFeePaidByConfirm.Text = "University";
                        else if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString() == "2")
                            lblExamFeePaidByConfirm.Text = "Student";
                    }
                    if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"] != null)
                    {
                        if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString() == "1")
                            lblondemandFeePaidByConfirm.Text = "University";
                        else if (objBECourseAdmin.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString() == "2")
                            lblondemandFeePaidByConfirm.Text = "Student";
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

       

        

        #endregion        
    }
}