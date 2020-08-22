using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Student
{
    public partial class NewPayment1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //testimage.Focus();
            int PerHourFee = 0;
            if (Session["BESTUDENT"] != null)
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();

                objBCommon.BGetClientDetails(objBECommon);
                if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {
                    PerHourFee = Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["AdditonalFeePerHour"]);
                }
                BusinessEntities.BEStudent objBEStudent = (BusinessEntities.BEStudent)Session["BESTUDENT"];

                lblStudentName.Text = Session["UserName"].ToString().Replace("[ Student ]", "");

                try
                {
                    string[] str = objBEStudent.dtExam.ToString().Split(' ');
                    lblDAte.Text = objBEStudent.dtExam.ToString("MM-dd-yyyy");
                    lblTime.Text = str[1].ToString() + str[2].ToString();
                }
                catch
                {
                }
                trLeft1.Visible = true;
                trRight1.Visible = true;
                if (Session[BaseClass.EnumPayment.PaidBY_ExamFee].ToString() == "1" && Session[BaseClass.EnumPayment.PaidBY_OndeMand].ToString() == "2")
                {
                    trLeft1.Visible = false;
                    trRight1.Visible = false;

                }

                else if (Session[BaseClass.EnumPayment.PaidBY_ExamFee].ToString() == "1")
                {
                    lblExamFee.Text = "$&nbsp;&nbsp;0.00";
                    lblFirstHourFee.Text = "$&nbsp;&nbsp;0.00";

                }

                else
                {
                    lblFirstHourFee.Text = "$&nbsp;" + objBEStudent.decExamFee.ToString();
                    lblExamFee.Text = (objBEStudent.decExamFee + objBEStudent.PerHourFee).ToString();

                    try
                    {
                        objBECommon.IntExamID = objBEStudent.IntExamID;
                        objBCommon.BGetExamFeePerHour(objBECommon); 

                        int AdditonalFeePerHour = Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["AdditonalFeePerHour"]);


                        int intLoopCount = Convert.ToInt32(objBEStudent.PerHourFee) / AdditonalFeePerHour;

                        Right2.Text = AdditonalFeePerHour + "." + "00";
                        Right3.Text = AdditonalFeePerHour + "." + "00";
                        Right4.Text = AdditonalFeePerHour + "." + "00";
                        Right5.Text = AdditonalFeePerHour + "." + "00";
                        Right6.Text = AdditonalFeePerHour + "." + "00";




                        for (int i = 0; i < intLoopCount; i++)
                        {
                            if (i == 0)
                            {
                                trLeft2.Visible = true;
                                trRight2.Visible = true;
                            }
                            else if (i == 1)
                            {
                                trLeft3.Visible = true;
                                trRight3.Visible = true;
                            }
                            else if (i == 2)
                            {
                                trLeft4.Visible = true;
                                trRight4.Visible = true;
                            }
                            else if (i == 3)
                            {
                                trLeft5.Visible = true;
                                trRight5.Visible = true;
                            }
                            else if (i == 4)
                            {
                                trLeft6.Visible = true;
                                trRight6.Visible = true;
                            }

                        }
                    }
                    catch
                    {
                    }
                    //lblFeePerHour.Text = "$ " + objBEStudent.PerHourFee.ToString();

                }
                if (Session[BaseClass.EnumPayment.PaidBY_OndeMand].ToString() == "1")
                    lblOndemandFee.Text = "$&nbsp;&nbsp;&nbsp0.00";
                else

                    lblOndemandFee.Text = "$&nbsp;&nbsp;&nbsp" + objBEStudent.decOnDemandFee.ToString();

                lblAmount.Text = "$&nbsp;&nbsp;" + objBEStudent.decAmount.ToString();
                if (objBEStudent.IntScheduleID == 0)
                {
                    lblCourseName.Text = objBEStudent.strCourseName;
                    lblExamName.Text = objBEStudent.strExamName;
                }
                else
                {
                    new BStudent().BGetCourseAndExam(objBEStudent);
                    lblCourseName.Text = objBEStudent.DtResult.Rows[0][0].ToString();
                    lblExamName.Text = objBEStudent.DtResult.Rows[0][1].ToString();
                    trLeft1.Visible = false;
                    trRight1.Visible = false;
                }
            }
            else
            {
                Response.Redirect("ScheduleAnExam.aspx");
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            BECommon objBEStudent2 = new BECommon();

            objBEStudent2.IntExamID = Convert.ToInt32(Session["ExamId"]);
            new BCommon().BGetPaymentData(objBEStudent2);

            if (objBEStudent2.IntResult == 0)
            {
                Response.Redirect("fPaynow.aspx");
            }
            else
            {
                Response.Redirect("Paynow.aspx");
            }

        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='ScheduleAnExam.aspx';", true);
            //Response.Redirect("ScheduleExam.aspx");
        }
    }
}