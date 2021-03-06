﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class DeleteStudent : BaseClass
    {
        #region Global Declaration

        string strStudentID = string.Empty;

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_DELETESTUDENT;


                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                {
                    strStudentID = Request.QueryString["StudentID"].ToString();
                    Session[BaseClass.EnumPageSessions.StudentID] = strStudentID;
                }
                if (strStudentID != "")
                {
                    GetStudentDetails(int.Parse(strStudentID));
                }
            }
            trMessage.Visible = false;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            BECourseAdmin objBEProvider = new BECourseAdmin();
            BCourseAdmin objBProvider = new BCourseAdmin();
            objBEProvider.IntStudentID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.StudentID].ToString());
            objBProvider.BDeleteStudent(objBEProvider);
            trMessage.Visible = true;
            if (objBEProvider.DsResult != null && objBEProvider.DsResult.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(objBEProvider.DsResult.Tables[0].Rows[0][0]))
                {
                    trUpdate.Visible = false;

                    lblInfo.Text = Resources.AppMessages.Provider_DeletStudent_Success_StudentDeleted;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);

                }
                else
                {
                    trUpdate.Visible = true;

                    lblInfo.Text = Resources.AppMessages.Provider_DeletStudent_Error_DeleteStudentPending;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                }
            }

            else
            {
                trUpdate.Visible = true;
                lblInfo.Text = Resources.AppMessages.Provider_DeletStudent_Error_DeleteStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
            }
        }

        #endregion

        #region Methods

        protected void GetStudentDetails(int StudentID)
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntStudentID = StudentID;
            objBCommon.BGetStudentDetails(objBECommon);
            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                lblstudentfirstname.Text = objBECommon.DtResult.Rows[0]["FirstName"].ToString();
                lblStudentLastName.Text = objBECommon.DtResult.Rows[0]["LastName"].ToString();
                lblEmailID.Text = objBECommon.DtResult.Rows[0]["EmailAddress"].ToString();
                lblPhoneNumber.Text = objBECommon.DtResult.Rows[0]["PhoneNumber"].ToString();
                lblTimeZone.Text = objBECommon.DtResult.Rows[0]["TimeZone"].ToString();
                lblrole.Text = objBECommon.DtResult.Rows[0]["Role_Name"].ToString();

                lblSpecialNeeds.Text = objBECommon.DtResult.Rows[0]["SpecialNeeds"].ToString();
                if (lblSpecialNeeds.Text == "Yes")
                {
                    trcomments.Visible = true;
                    if (objBECommon.DtResult.Rows[0]["Comments"] != DBNull.Value)
                    {
                        lblComments.Text = objBECommon.DtResult.Rows[0]["Comments"].ToString();
                    }
                }

                else
                {
                    trcomments.Visible = false;
                }
            }

        }
        #endregion
    }
}