using BLL;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SecureProctor.Admin
{
    public partial class AssignPrimaryInstructor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.GetInstructors();
                trAddEnrollment.Visible = true;
                trAddEnrollmentConfirmation.Visible = false;

                
            }
            trMessage.Visible = false;


        }

        

        public void GetInstructors()
        {
            if (Request.QueryString["CourseID"] != null)
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                objBAdmin.BGetCoursePrimaryInstructors(objBEAdmin);
                if (objBEAdmin.DtResult.Rows.Count > 0)
                {
                    lblCourseName.Text = objBEAdmin.DtResult.Rows[0][2].ToString();
                    rcbInstructor.AppendDataBoundItems = true;
                    // rcbStudent.Items.Add(new RadComboBoxItem("--Select Student--", "-1"));
                    rcbInstructor.DataSource = objBEAdmin.DtResult;
                    rcbInstructor.DataTextField = "InstructorName";
                    rcbInstructor.DataValueField = "InstructorID";
                    rcbInstructor.DataBind();


                    foreach(RadComboBoxItem item in rcbInstructor.Items)
                {
                    foreach (DataRow dr in objBEAdmin.DtResult.Rows)
                    {
                        if (item.Value == dr[0].ToString())
                        {
                            if(dr[3].ToString()=="true")
                            {
                                item.Checked = true;

                            }
                            break;
                           
                        }
                       

                    }


                }


                }

                
            }

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {
                    BEAdmin objBEAdmin = new BEAdmin();
                    BAdmin objBAdmin = new BAdmin();
                    DataTable objDt = new DataTable();
                    objDt.Columns.Add("InstructorID");
                    objDt.Columns.Add("InstructorName");
                    objDt.Columns.Add("Status");
                    
                    foreach (RadComboBoxItem ChkStudent in rcbInstructor.Items)
                    {
                        DataRow objDr = objDt.NewRow();
                        if (ChkStudent.Checked)
                        {
                            
                            objDr["InstructorID"] = ChkStudent.Value;
                            objDr["InstructorName"] = ChkStudent.Text;
                            objDr["Status"] = 1;
                        }
                        else
                        {
                            objDr["InstructorID"] = ChkStudent.Value;
                            objDr["InstructorName"] = ChkStudent.Text;
                            objDr["Status"] = 0;
                           
                           
                        }
                        objDt.Rows.Add(objDr);
                    }
                    objDt.AcceptChanges();
                    objBEAdmin.DtResult1 = objDt;

                    objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                    objBAdmin.BAdminUpdateisPrimaryInstructor(objBEAdmin);
                    trMessage.Visible = true;
                    if (objBEAdmin.IntResult.ToString() == "1")
                    {
                        trAddEnrollment.Visible = false;
                        trAddEnrollmentConfirmation.Visible = true;
                        lblCoursenameConfirmation.Text = lblCourseName.Text;
                        lblInfo.Text = Resources.AppMessages.Admin_PrimaryInstructor_Success;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                        gvInstructors.DataSource = objDt.Select("Status=1");
                        gvInstructors.DataBind();
                      
                    }

                    else
                    {
                        trAddEnrollment.Visible = true;
                        trAddEnrollmentConfirmation.Visible = false;
                       lblInfo.Text = Resources.AppMessages.Admin_PrimaryInstructor_Failed;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                     

                    }
                   



                }
            }
            catch (Exception )
            {


            }

        }

       




    }
}