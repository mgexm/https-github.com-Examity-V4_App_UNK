using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Data;
using System.IO;
using Telerik.Web.UI;

namespace SecureProctor.Student
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // btnRegistration.Attributes.Add("onclick", "return ValidateStudentRegistration('" + txtFirstName.ClientID + "','" + txtLastName.ClientID + "','" + txtUserName.ClientID + "','" + IdentificationFileUpload.ClientID + "','" + ddlGender.ClientID + "','" + txtPassword.ClientID + "','" + txtConfirmPassword.ClientID + "','" + ddlSecurityQuestion1.ClientID + "','" + txtAnswer1.ClientID + "','" + ddlSecurityQuestion2.ClientID + "','" + txtAnswer2.ClientID + "','" + ddlSecurityQuestion3.ClientID + "','" + txtAnswer3.ClientID + "')");
                this.Page.Title = BaseClass.EnumPageTitles.APPNAME + BaseClass.EnumPageTitles.STUDENT_REGISTRATION;

                IdentificationFileUpload.Attributes.Add("onkeydown", "return false;");

                IdentificationFileUpload.Attributes.Add("onpaste", "return false;");

                txtFirstName.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtLastName.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtUserName.Attributes.Add("onblur", "ValidatorOnChange(event);");

                ddlGender.Attributes.Add("onblur", "ValidatorOnChange(event);");

                IdentificationFileUpload.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtPassword.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtConfirmPassword.Attributes.Add("onblur", "ValidatorOnChange(event);");

                ddlSecurityQuestion1.Attributes.Add("onblur", "ValidatorOnChange(event);");
                ddlSecurityQuestion2.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtAnswer1.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtAnswer2.Attributes.Add("onblur", "ValidatorOnChange(event);");

                ddlSecurityQuestion3.Attributes.Add("onblur", "ValidatorOnChange(event);");

                txtAnswer3.Attributes.Add("onblur", "ValidatorOnChange(event);");

                //btnRegistration.Attributes.Add("onclick", "return ValidateStudentRegistration('" + txtPhoneNumber.ClientID + "','" + txtPhoneNumber2.ClientID + "','" + txtPhoneNumber3.ClientID + "','"+lblmsg.ClientID+"')");

                //btnRegistration.Attributes.Add("onclick", "return ValidateStudentRegistration('" + ddlSecurityQuestion1.ClientID + "','" + ddlSecurityQuestion2.ClientID + "','" + ddlSecurityQuestion3.ClientID + "','" + lblQuestion1.ClientID + "','" + lblQuestion2.ClientID + "','" + lblQuestion3.ClientID + "')");

                //btnRegistration.Attributes.Add("onclick", "return ValidateStudentRegistration('" + ddlSecurityQuestion1.ClientID + "','" + ddlSecurityQuestion2.ClientID + "','" + ddlSecurityQuestion3.ClientID + "','" + lblQuestion1.ClientID + "','" + lblQuestion2.ClientID + "','" + lblQuestion3.ClientID + "')");

                //lblQuestion1.Text = string.Empty;

                //lblQuestion2.Text = string.Empty;

                //lblQuestion3.Text = string.Empty;

                if (!IsPostBack)
                {
                    lblMessage.Text = string.Empty;
                    this.BindGender();
                    this.BindSecurityQuestions();
                    this.BindTimeZone();
                }
            }

            catch (Exception )
            {
                //ErrorLog.WriteError(Ex);
            }
        }

        #region BindGender
        protected void BindGender()
        {
            try
            {
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();
                objBUser.BGenderList(objBEUser);
                if (objBEUser.DtResult.Rows.Count > 0)
                {
                    RadComboBoxItem rdItem = new RadComboBoxItem("Select", "-1");
                    ddlGender.Items.Add(rdItem);
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataSource = objBEUser.DtResult;
                    ddlGender.DataBind();
                }
            }
            catch (Exception )
            {
                //  ErrorLog.WriteError(Ex);
            }
        }
        #endregion

        #region BindTimeZone
        protected void BindTimeZone()
        {
            try
            {
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();
                objBUser.BGetTimeZone(objBEUser);
                if (objBEUser.DsResult.Tables[0].Rows.Count > 0)
                {
                    RadComboBoxItem rdItem = new RadComboBoxItem("Select", "-1");
                    ddlTimeZone.Items.Add(rdItem);
                    ddlTimeZone.DataValueField = "id";
                    ddlTimeZone.DataTextField = "TimeZone";
                    ddlTimeZone.DataSource = objBEUser.DsResult.Tables[0];
                    ddlTimeZone.DataBind();
                }
            }
            catch (Exception )
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region BindSecurityQuestions
        protected void BindSecurityQuestions()
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntUserID = 0;
                objBStudent.BBindProfileSecurityQuestions(objBEStudent);
                if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    Session["Dataset"] = objBEStudent.DsResult;

                    ddlSecurityQuestion1.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    ddlSecurityQuestion1.AppendDataBoundItems = true;
                    ddlSecurityQuestion1.DataSource = objBEStudent.DsResult.Tables[0];
                    ddlSecurityQuestion1.DataTextField = objBEStudent.DsResult.Tables[0].Columns[1].ToString();
                    ddlSecurityQuestion1.DataValueField = objBEStudent.DsResult.Tables[0].Columns[0].ToString();
                    ddlSecurityQuestion1.DataBind();
                    ddlSecurityQuestion1.SelectedValue = "-1";
                    ddlSecurityQuestion2.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));


                }
            }
            catch (Exception )
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region BtnRegistration
        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {

                    BStudent objBStudent = new BStudent();
                    BEStudent objBEStudent = new BEStudent()
                    {

                        strFirstName = txtFirstName.Text.Trim(),
                        strLastName = txtLastName.Text.Trim(),
                        strPassword = txtPassword.Text.Trim(),
                        strConfirmPassword = txtConfirmPassword.Text.Trim(),
                        strUserName = txtUserName.Text.Trim(),
                        strGender = ddlGender.SelectedValue,
                        strphoneNumber = txtPhoneNumber.Text,
                        strTimeZone = ddlTimeZone.SelectedValue,
                        strQuestion1 = ddlSecurityQuestion1.SelectedValue,
                        strPrefferedPhoneNumber = txtPrefferedPhoneNumber.Text,
                        strAnswer1 = txtAnswer1.Text,
                        strQuestion2 = ddlSecurityQuestion2.SelectedValue,
                        strAnswer2 = txtAnswer2.Text,
                        strQuestion3 = ddlSecurityQuestion3.SelectedValue,
                        strAnswer3 = txtAnswer3.Text,
                    };



                    if (IdentificationFileUpload.HasFile)
                    {
                        string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["UploadedDocumentsLocation"]);
                        string strOriginalFileName = IdentificationFileUpload.FileName;
                        string strUploadFileName = CommonFunctions.generateUploadFileName(IdentificationFileUpload.FileName);
                        string strTotalPath = strpath + '\\' + strUploadFileName;
                        string pathex = Path.GetExtension(strTotalPath);
                        if (pathex.ToLower() == ".jpg" || pathex.ToLower() == ".gif" || pathex.ToLower() == ".png" || pathex.ToLower() == ".bmp" || pathex.ToLower() == ".pdf")
                        {
                            IdentificationFileUpload.SaveAs(strTotalPath);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFailure", "alert('" + Resources.ResMessages.Reg_Validuploadfiles + "')", true);
                            return;
                        }

                        //if (IdentificationFileUpload.PostedFile.ContentLength > 1024000)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFail", "alert('" + Resources.ResMessages.Reg_Uploadfilesize + "')", true);
                        //    File.Delete(strTotalPath);
                        //    return;
                        //}

                        //System.Drawing.Image image = System.Drawing.Image.FromFile(strTotalPath);
                        //int width = 0;
                        //int height = 0;
                        //if (image != null)
                        //{
                        //    width = image.Width;
                        //    height = image.Height;
                        //    if (height > 300)
                        //    {
                        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFailure", "alert('" + Resources.ResMessages.Reg_Uploadfileheight + "')", true);
                        //        image.Dispose();
                        //        File.Delete(strTotalPath);
                        //        return;
                        //    }
                        //}
                        objBEStudent.strUploadPath = strUploadFileName;
                        objBEStudent.strOriginalFileName = strOriginalFileName;

                        objBStudent.BStudentRegistration(objBEStudent);

                        if (objBEStudent.IntResult == 0)
                        {
                            lblMessage.Text = Resources.ResMessages.Reg_UserExists;
                            this.ClearFields();
                        }
                        else if (objBEStudent.IntResult == 1)
                        {
                            lblMessage.Text = Resources.ResMessages.Reg_StudentRegSuccess;
                            this.ClearFields();
                            try
                            {

                                BEMail objBEMail = new BEMail();
                                BMail objBMail = new BMail();
                                if (objBEStudent.IntUserID != 0)
                                {
                                    objBEMail.IntUserID = objBEStudent.IntUserID;
                                }
                                else
                                {
                                    objBEMail.IntUserID = 0;
                                }
                                objBEMail.IntTransID = 0;
                                objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentRegistrationConfirmation.ToString();
                                objBMail.BSendEmail(objBEMail);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            this.ClearFields();
                        }
                        else if (objBEStudent.IntResult == 9)
                        {
                            lblMessage.Text = Resources.ResMessages.Reg_StudentRegFail;
                            lblMessage.Text = Resources.ResMessages.Reg_NoStudentDet;
                            this.ClearFields();
                        }
                    }
                    else
                    {
                        objBEStudent.strUploadPath = string.Empty;
                        objBEStudent.strOriginalFileName = string.Empty;
                        lblMessage.Text = "Please upload the valid file";
                    }
                }
            }
            catch (Exception )
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region ClearFields
        protected void ClearFields()
        {
            try
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtUserName.Text = "";
                ddlGender.SelectedValue = "-1";
                ddlSecurityQuestion1.SelectedValue = "-1";
                ddlSecurityQuestion2.SelectedValue = "-1";
                ddlSecurityQuestion3.SelectedValue = "-1";
                ddlTimeZone.SelectedValue = "-1";
                txtAnswer1.Text = "";
                txtAnswer2.Text = "";
                txtAnswer3.Text = "";
                txtPhoneNumber.Text = "";
                txtPrefferedPhoneNumber.Text = "";
            }
            catch (Exception )
            {

                //  ErrorLog.WriteError(Ex);
            }
        }
        #endregion


        protected void ddlSecurityQuestion3_IndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {


        }
        protected void ddlSecurityQuestion2_IndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            try
            {

                if (ddlSecurityQuestion1.SelectedValue != "-1")
                {
                    ddlSecurityQuestion3.Items.Clear();
                    ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    ddlSecurityQuestion2.AppendDataBoundItems = true;
                    txtAnswer2.Text = string.Empty;
                    txtAnswer3.Text = string.Empty;

                    string i = ddlSecurityQuestion1.SelectedValue.ToString();
                    string j = ddlSecurityQuestion2.SelectedValue.ToString();
                    DataSet ObjDs = new DataSet();
                    ObjDs = (DataSet)Session["Dataset"];
                    if (ObjDs.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ObjDs.Tables[0].Rows)
                        {
                            if (dr[0].ToString() != i && dr[0].ToString() != j)
                                ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem(dr[1].ToString(), dr[0].ToString()));

                        }

                    }

                }


                else
                {
                    ddlSecurityQuestion3.Items.Clear();
                    ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    ddlSecurityQuestion3.AppendDataBoundItems = true;
                    txtAnswer2.Text = string.Empty;
                    txtAnswer3.Text = string.Empty;
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }



        }
        protected void ddlSecurityQuestion1_IndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            try
            {
                if (ddlSecurityQuestion1.SelectedValue != "-1")
                {
                    ddlSecurityQuestion2.Items.Clear();
                    ddlSecurityQuestion2.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    ddlSecurityQuestion2.AppendDataBoundItems = true;
                    ddlSecurityQuestion3.Items.Clear();
                    ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    ddlSecurityQuestion3.AppendDataBoundItems = true;

                    txtAnswer1.Text = string.Empty;
                    txtAnswer2.Text = string.Empty;
                    txtAnswer3.Text = string.Empty;


                    string i = ddlSecurityQuestion1.SelectedValue.ToString();
                    DataSet ObjDs = new DataSet();
                    ObjDs = (DataSet)Session["Dataset"];
                    if (ObjDs.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ObjDs.Tables[0].Rows)
                        {
                            if (dr[0].ToString() != i)
                                ddlSecurityQuestion2.Items.Add(new Telerik.Web.UI.RadComboBoxItem(dr[1].ToString(), dr[0].ToString()));

                        }

                    }





                }
                else
                {

                    ddlSecurityQuestion2.Items.Clear();
                    ddlSecurityQuestion2.AppendDataBoundItems = true;
                    ddlSecurityQuestion2.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    txtAnswer2.Text = string.Empty;
                    ddlSecurityQuestion3.Items.Clear();
                    ddlSecurityQuestion3.AppendDataBoundItems = true;
                    ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem("-- Select Security question --", "-1"));
                    txtAnswer1.Text = string.Empty;
                    txtAnswer3.Text = string.Empty;


                }
            }

            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
