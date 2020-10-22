using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class ExamCancelConfirmation : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (Request.QueryString["TransID"] != null)
                {
                    this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULEDetails;
                    //((LinkButton)this.Page.Master.FindControl("lnkReschedule")).CssClass = "main_menu_active";
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBCommon.BGetStudentExamDetails(objBECommon);
                    if (objBECommon.DsResult != null)
                    {
                        if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
                            lblTransactionID.Text = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                            lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                            lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                            lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                            lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                            lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
                            //lblHead.Text = "Exam Cancellation Request";

                        }
                    }
                    lblInfo.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Appointment " + Resources.ResMessages.AppointmentDeleteSuccess + "</font>";


                }
            }
            catch (Exception )
            {
                //ErrorLog.WriteError(Ex);
            }

        }




    }

}