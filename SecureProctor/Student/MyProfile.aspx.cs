using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace SecureProctor.Student
{
    public partial class MyProfile : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.MaintainScrollPositionOnPostBack = true;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.MYPROFILE;
                ((LinkButton)this.Page.Master.FindControl("lnkProfile")).CssClass = "main_menu_active";
                IdentificationFileUpload.Attributes.Add("onkeydown", "return false;");
                IdentificationFileUpload.Attributes.Add("onpaste", "return false;");
                txtAnswer1.Attributes.Add("onblur", "ValidatorOnChange(event);");
                txtAnswer2.Attributes.Add("onblur", "ValidatorOnChange(event);");
                txtAnswer3.Attributes.Add("onblur", "ValidatorOnChange(event);");
                txtCurrentPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblUpdated.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
                txtNewPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblUpdated.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
                txtConfirmNewPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblUpdated.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
                IdentificationFileUpload.Attributes.Add("onKeyDown", "OpenBrowse();");

                trSecurityQuestionsView.Visible = true;
                trSecurityQuestionsEdit.Visible = false;
                trDemographicView.Visible = true;
                trDemographicEdit.Visible = false;
                lblformat.Visible = false;
                this.BindDemographicDetails();
                this.BindSecurityQuestions();
                this.getPhotoIdentity();
                BindTimeZone();
                Image8.Focus();

                trKeyStrokeView.Visible = true;
                trKeyStrokeEdit.Visible = false;

         
                GetExamiBadge();
            }

            lblSecUpdated.Text = string.Empty;
            lblUpload.Text = string.Empty;
            lblsucc.Visible = true;
            lblkeyMsg.Text = string.Empty;
            ValidatePhotoIdentity();
            if (Session["UPLOAD"] != null)
            {
                if (Session["UPLOAD"].ToString() == "YES")
                {
                    lblUpload.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_FileUploadSuccess + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + lblUpload.ClientID.ToString() + "').focus();", true);
                    Session["UPLOAD"] = null;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + IdentificationFileUpload.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (!IsPostBack)
            {
                if (pnlInfo.Visible)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblHeader1.ClientID.ToString() + "').focus();", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + Image8.ClientID.ToString() + "').focus();", true);
            }

            //to hide and show examiKey
            ShowOrHideexamiKEY();

          
        }

        protected void GetExamiBadge()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BGetExamiBadge(objBEStudent);

            if(objBEStudent.StrResult=="NOBADGE")
            {
                DivExamiBADGE.Visible = false;
                divInfo.Visible = true;

            }

            else
            {
                DivExamiBADGE.Visible = true;
                divInfo.Visible = false;

                divBadge.Attributes.Add("class", objBEStudent.StrResult);
                int Count = objBEStudent.IntResult;

                if (Count == 0)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams0.ToString();
                }
                else if (Count == 1)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams1.ToString();
                }
                else if (Count == 2)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams2.ToString();
                }
                else if (Count == 3)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams3.ToString();
                }
                else if (Count == 4)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams4.ToString();
                }
                else if (Count == 5)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams5.ToString();
                }
                else if (Count == 6)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams6.ToString();
                }
                else if (Count == 7)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams7.ToString();
                }
                else if (Count == 8)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams8.ToString();
                }
                else if (Count == 9)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams9.ToString();
                }
                else if (Count >= 10)
                {
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams10.ToString();
                }
                else
                    lblExamsleft.Text = Resources.ResMessages.MYProfile_Exams0.ToString(); 
            }

            

        


        }
        protected void ValidatePhotoIdentity()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BValidateUploadandQuestions(objBEStudent);
            if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
            {
                if (objBEStudent.BoolResult == false)
                {
                    trChangePassword.Visible = true;
                }
                if (objBEStudent.BoolResult == true)
                {
                    trChangePassword.Visible = false;
                }
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["QuestionsCheck"]) == 1)
                {
                    ImgSecurityValidation.ImageUrl = "~/Images/ImgMyProfileyes.png";
                    ImgSecurityValidation.AlternateText = "Security questions configured successfully";
                    lblSecurityValidation.Text = Resources.ResMessages.MyProfile_SecurityQuestions.ToString();

                    //lblYesScurityQuestions.Text = "<img src='../Images/ImgMyProfileyes.png'/>&nbsp;<b><font color='BLACK' alt=\"Time zone configuration is successfully configured\">" + Resources.ResMessages.MyProfile_SecurityQuestions + "</font></b>";
                    //lblYesScurityQuestions.Visible = true;
                    //lblNoScurityQuestions.Visible = false;
                }
                else
                {
                    ImgSecurityValidation.ImageUrl = "~/Images/ImgMyProfileno.png";
                    ImgSecurityValidation.AlternateText = "Please select the security questions under the Security questions tab";
                    lblSecurityValidation.Text = Resources.ResMessages.MyProfile_SecurityQuestions.ToString();

                    //lblNoScurityQuestions.Text = "<img src='../Images/ImgMyProfileno.png' alt=\"Please select the time zone under the Account Information tab\"/>&nbsp;<b><font color='BLACK'>" + Resources.ResMessages.MyProfile_SecurityQuestions + "</font></b>";
                    //lblNoScurityQuestions.Visible = true;
                    //lblYesScurityQuestions.Visible = false;
                }
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["PhotoCheck"]) == 1)
                {
                    ImgPhotoIDValidation.ImageUrl = "~/Images/ImgMyProfileyes.png";
                    ImgPhotoIDValidation.AlternateText = "Photo id configured successfully";
                    lblPhotoIDValidation.Text = Resources.ResMessages.MyProfile_UploadPicture.ToString();

                    //lblYesUploadPicture.Text = "<img src='../Images/ImgMyProfileyes.png'/>&nbsp;<b><font color='BLACK'>" + Resources.ResMessages.MyProfile_UploadPicture + "</font></b>";
                    //lblYesUploadPicture.Visible = true;
                    //lblNoUploadPicture.Visible = false;
                }
                else
                {
                    ImgPhotoIDValidation.ImageUrl = "~/Images/ImgMyProfileno.png";
                    ImgPhotoIDValidation.AlternateText = "Please upload the government issued photo id under the Photo identity tab";
                    lblPhotoIDValidation.Text = Resources.ResMessages.MyProfile_UploadPicture.ToString();

                    //lblNoUploadPicture.Text = "<img src='../Images/ImgMyProfileno.png'/>&nbsp;<b><font color='BLACK'>" + Resources.ResMessages.MyProfile_UploadPicture + "</font></b>";
                    //lblNoUploadPicture.Visible = true;
                    //lblYesUploadPicture.Visible = false;
                }
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["TimeZoneCheck"]) == 1)
                {
                    ImgTimeZoneValidation.ImageUrl = "~/Images/ImgMyProfileyes.png";
                    ImgTimeZoneValidation.AlternateText = "Time zone configured successfully";
                    lblTimeZoneValidation.Text = Resources.ResMessages.MyProfile_TimeZone.ToString();
                    //lblYesTimeZone.Text = "<img src='../Images/ImgMyProfileyes.png'/>&nbsp;<b><font color='BLACK'>" + Resources.ResMessages.MyProfile_TimeZone + "</font></b>";
                    //lblYesTimeZone.Visible = true;
                    //lblNoTimeZone.Visible = false;
                }
                else
                {
                    ImgTimeZoneValidation.ImageUrl = "~/Images/ImgMyProfileno.png";
                    ImgTimeZoneValidation.AlternateText = "Please select the time zone under the Account Information tab";
                    lblTimeZoneValidation.Text = Resources.ResMessages.MyProfile_TimeZone.ToString();
                    //lblNoTimeZone.Text = "<img src='../Images/ImgMyProfileno.png'/>&nbsp;<b><font color='BLACK'>" + Resources.ResMessages.MyProfile_TimeZone + "</font></b>";
                    //lblNoTimeZone.Visible = true;
                    //lblYesTimeZone.Visible = false;
                }
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ExamiKEY"]) == 1)
                {
                    ImgKeyValidation.ImageUrl = "~/Images/ImgMyProfileyes.png";
                    ImgKeyValidation.AlternateText = "ExamiKey configured successfully";
                    lblKeyValidation.Text = Resources.ResMessages.MyProfile_ExamiKEY.ToString();

                }
                else
                {
                    ImgKeyValidation.ImageUrl = "~/Images/ImgMyProfileno.png";
                    ImgKeyValidation.AlternateText = "Please Enter the First Name and Last Name under the examiKEY tab";
                    lblKeyValidation.Text = Resources.ResMessages.MyProfile_ExamiKEY.ToString();

                }
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["QuestionsCheck"]) == 1 && Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["PhotoCheck"]) == 1 && Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["TimeZoneCheck"]) == 1)
                {
                    if (Convert.ToBoolean(objBEStudent.DsResult.Tables[0].Rows[0]["IsExamiKeyUser"].ToString()))
                    {
                        if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ExamiKEY"]) == 1)
                        {
                            tdScheduleMsg.Visible = true;
                            pnlInfo.Visible = false;

                        }
                        else
                        {
                            pnlInfo.Visible = true;
                            tdScheduleMsg.Visible = false;
                        }

                    }
                    else
                    {
                        tdScheduleMsg.Visible = true;
                        pnlInfo.Visible = false;
                    }

                }
                else
                {
                    pnlInfo.Visible = true;
                    tdScheduleMsg.Visible = false;
                }
            }
        }
        #region BindGender
        protected void BindGender()
        {
            try
            {
                BECommon objBECommon = new BECommon();

                BCommon objBCommon = new BCommon();

                objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

                objBCommon.BGenderList(objBECommon);

                if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {
                    //ddlGender.Items.Clear();
                    //ddlGender.DataValueField = "GenderID";
                    //ddlGender.DataTextField = "GenderName";
                    //ddlGender.DataSource = objBECommon.DsResult.Tables[0];
                    //ddlGender.DataBind();
                }

                if (objBECommon.DsResult.Tables[1].Rows.Count > 0)
                {
                    //lblGender.Text =CommonFunctions.CheckNullValue(objBECommon.DsResult.Tables[1].Rows[0]["GenderName"].ToString());
                    //ddlGender.SelectedValue = objBECommon.DsResult.Tables[1].Rows[0]["GenderID"].ToString();


                }
            }
            catch (Exception Ex)
            {
                //  ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        protected void BindTimeZone()
        {
            try
            {
                BUser objBUser = new BUser();
                BEUser objBEUser = new BEUser();
                objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBUser.BGetTimeZone(objBEUser);
                if (objBEUser.DsResult.Tables[0].Rows.Count > 0)
                {
                    ddlTimeZone.Items.Clear();
                    ddlTimeZone.DataValueField = "id";
                    ddlTimeZone.DataTextField = "TimeZone";
                    ddlTimeZone.DataSource = objBEUser.DsResult.Tables[0];
                    ddlTimeZone.DataBind();
                }
                if (objBEUser.DsResult.Tables[1].Rows.Count > 0)
                {
                    if (objBEUser.DsResult.Tables[1].Rows[0]["TimeZone2"].ToString() != "0")
                        lblTimeZone.Text = CommonFunctions.CheckNullValue(objBEUser.DsResult.Tables[1].Rows[0]["TimeZone2"].ToString());
                    else
                        lblTimeZone.Text = "Please select time zone";

                    ddlTimeZone.SelectedValue = objBEUser.DsResult.Tables[1].Rows[0]["TimeZone1"].ToString().Trim();
                }
            }
            catch (Exception Ex)
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        protected void BindDemographicDetails()
        {
            BEUser objBEUser = new BEUser();
            BUser objBUser = new BUser();

            objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

            objBUser.BGetProfileDetails(objBEUser);

            if (objBEUser.DtResult.Rows.Count > 0)
            {
                bool isExamikeyUser = false;
                //Examikey

                isExamikeyUser = Convert.ToBoolean(objBEUser.DtResult.Rows[0]["IsExamiKeyUser"].ToString());
                if (isExamikeyUser)
                {
                    trExamikey.Visible = true;
                    ImgKeyValidation.Visible = true;
                    lblKeyValidation.Visible = true;
                    //KEY STROKE
                    lblKeyFirstNamevalue.Text = objBEUser.DtResult.Rows[0]["FName"].ToString();
                    lblKeyFirstandLastNameValue.Text = objBEUser.DtResult.Rows[0]["LFName"].ToString();
                }
                else
                {
                    trExamikey.Visible = false;
                    ImgKeyValidation.Visible = false;
                    lblKeyValidation.Visible = false;
                }

                //
                lblFirstName.Text = objBEUser.DtResult.Rows[0]["FirstName"].ToString();
                txtFirstName.Text = objBEUser.DtResult.Rows[0]["FirstName"].ToString();
                lblLastName.Text = objBEUser.DtResult.Rows[0]["LastName"].ToString();
                txtLastName.Text = objBEUser.DtResult.Rows[0]["LastName"].ToString();
                lblEmail.Text = objBEUser.DtResult.Rows[0]["EmailAddress"].ToString();
                txtEmail.Text = objBEUser.DtResult.Rows[0]["EmailAddress"].ToString();



                if (objBEUser.DtResult.Rows[0]["PhoneNumber"] != DBNull.Value && objBEUser.DtResult.Rows[0]["PhoneNumber"].ToString().Trim() != string.Empty)
                {
                    //lblphone.Text = objBEUser.DtResult.Rows[0]["PhoneNumber"].ToString();
                    lblphone.Text = objBEUser.DtResult.Rows[0]["CountryPhoneNumber"].ToString();
                    txtPhoneNumber.Text = objBEUser.DtResult.Rows[0]["PhoneNumber"].ToString();
                }
                else
                {
                    lblphone.Text = "N/A";
                    txtPhoneNumber.Text = "";
                }




            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEUser objBEUser = new BEUser();

                BUser objBUser = new BUser();

                objBEUser.strOldPassword = txtCurrentPassword.Text;

                objBEUser.strNewPassword = txtNewPassword.Text;

                objBEUser.strConfirmNewPassword = txtConfirmNewPassword.Text;

                objBEUser.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBEUser.StrUserName = Session["EmailID"].ToString();

                objBUser.BChangePassword(objBEUser);

                if (objBEUser.IntResult == 0)
                {
                    //lblUpdated.Text = "Updated Successfully";
                    lblUpdated.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_PasswordUpdateSuccess + "</font>";

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Updated Successfully')", true);

                    //    lblSecUpdated.Text = string.Empty;
                    //    lblUpload.Text = string.Empty;

                    //    try
                    //    {

                    //        BEMail objBEMail = new BEMail();
                    //        BMail objBMail = new BMail();
                    //        objBEMail.IntUserID = objBEUser.IntUserID;
                    //        objBEMail.IntTransID = 0;
                    //        objBEMail.StrTemplateName = BaseClass.EnumEmails.ChangePassword.ToString();

                    //        objBMail.BSendEmail(objBEMail);

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        throw ex;
                    //    }

                    //}

                    //if (objBEUser.IntResult == 1)
                    //{

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Please enter valid Current Password')", true);

                    //lblUpdated.Text = "Please enter valid Current Password";
                    //lblUpdated.Text = Resources.ResMessages.MyProfile_ValidCurrentPassword;

                    lblSecUpdated.Text = string.Empty;
                    lblUpload.Text = string.Empty;

                }
            }
        }
        #region BindSecurityQuestions
        protected void BindSecurityQuestions()
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBStudent.BBindProfileSecurityQuestions(objBEStudent);
                if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    ddlSecurityQuestion1.Items.Add(new Telerik.Web.UI.RadComboBoxItem("--Select Security question--", "-1"));
                    ddlSecurityQuestion1.AppendDataBoundItems = true;
                    ddlSecurityQuestion1.DataValueField = "Qid";
                    ddlSecurityQuestion1.DataTextField = "QText";
                    ddlSecurityQuestion1.DataSource = objBEStudent.DsResult.Tables[0];
                    ddlSecurityQuestion1.DataBind();
                    ddlSecurityQuestion2.Items.Add(new Telerik.Web.UI.RadComboBoxItem("--Select Security question--", "-1"));
                    ddlSecurityQuestion2.DataValueField = "Qid";
                    ddlSecurityQuestion2.DataTextField = "QText";
                    ddlSecurityQuestion2.DataSource = objBEStudent.DsResult.Tables[0];
                    ddlSecurityQuestion2.DataBind();
                    ddlSecurityQuestion3.Items.Add(new Telerik.Web.UI.RadComboBoxItem("--Select Security question--", "-1"));
                    ddlSecurityQuestion3.DataValueField = "Qid";
                    ddlSecurityQuestion3.DataTextField = "QText";
                    ddlSecurityQuestion3.DataSource = objBEStudent.DsResult.Tables[0];
                    ddlSecurityQuestion3.DataBind();
                }

                if (objBEStudent.DsResult.Tables[1].Rows.Count > 0)
                {
                    lblSecurityQuestion1.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[0]["QText1"].ToString());
                    lblSecurityQuestion2.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[1]["QText1"].ToString());
                    lblSecurityQuestion3.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[2]["QText1"].ToString());
                    lblAnswer1.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[0]["QAnswer1"].ToString());
                    lblAnswer2.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[1]["QAnswer1"].ToString());
                    lblAnswer3.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[2]["QAnswer1"].ToString());
                    txtAnswer1.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[0]["QAnswer1"].ToString());
                    txtAnswer2.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[1]["QAnswer1"].ToString());
                    txtAnswer3.Text = CommonFunctions.CheckNullValue(objBEStudent.DsResult.Tables[1].Rows[2]["QAnswer1"].ToString());
                }
            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        protected void getPhotoIdentity()
        {

            try
            {
                BEStudent objBEStudent = new BEStudent();

                BStudent objBStudent = new BStudent();

                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBStudent.BgetPhotoIdentity(objBEStudent);

                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    //img.ImageUrl = "~/Student\\Student_Identity\\" + objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                    img.ImageUrl = new AppSecurity().ImageToBase64(objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                    img.ImageAlign = ImageAlign.Top;
                   // string strTotalPath = Server.MapPath(img.ImageUrl);
                    string strTotalPath = Server.MapPath("~/Student\\Student_Identity\\" + objBEStudent.DtResult.Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                    FileInfo fi = new FileInfo(strTotalPath);
                    if (fi.Exists)
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromFile(strTotalPath);
                        int width = 0;
                        int height = 0;
                        if (image != null)
                        {
                            width = image.Width;
                            height = image.Height;
                            if (height > 183)
                            {
                                img.Height = Unit.Pixel(183);
                                img.Width = Unit.Pixel(292);
                            }
                            else if (height < 183)
                            {
                                img.Height = height;
                                img.Width = width;
                            }
                        }
                        else
                        {
                            img.ImageUrl = "~/Student\\Student_Identity\\noimage.jpg";
                        }
                    }
                    else
                    {
                        img.ImageUrl = "~/Student\\Student_Identity\\noimage.jpg";
                    }
                }
                else
                {
                    img.ImageUrl = "~/Student\\Student_Identity\\noimage.jpg";
                }

            }

            catch (Exception e)
            {


            }

        }
        protected void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEStudent objBEStudent = new BEStudent();

                BStudent objBStudent = new BStudent();

                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                if (IdentificationFileUpload.HasFile)
                {
                    string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["UploadedDocumentsLocation"]);
                    string strOriginalFileName = IdentificationFileUpload.FileName;
                    string strUploadFileName = CommonFunctions.generateUploadFileName(IdentificationFileUpload.FileName);
                    string strTotalPath = strpath + '\\' + strUploadFileName;
                    string pathex = Path.GetExtension(strTotalPath);
                    if (pathex.ToLower() == ".jpg" || pathex.ToLower() == ".jpeg" || pathex.ToLower() == ".gif" || pathex.ToLower() == ".png" || pathex.ToLower() == ".bmp")
                    {
                        //IdentificationFileUpload.SaveAs(strTotalPath); 
                        System.Drawing.Image img = System.Drawing.Image.FromStream(IdentificationFileUpload.PostedFile.InputStream);
                        int height = img.Height;
                        int width = img.Width;
                        decimal size = Math.Round(((decimal)IdentificationFileUpload.PostedFile.ContentLength / (decimal)1024), 2);
                        if (size > 999)
                        {
                            Stream strm = IdentificationFileUpload.PostedFile.InputStream;
                            var targetFile = strTotalPath;
                            ReduceImageSize(0.3, strm, targetFile);
                        }
                        else { IdentificationFileUpload.SaveAs(strTotalPath); }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFailure", "alert('" + Resources.ResMessages.Reg_Validuploadfiles + "')", true);
                        return;
                    }
                    objBEStudent.strUploadPath = strUploadFileName;
                    objBEStudent.strOriginalFileName = strOriginalFileName;
                }
                else
                {
                    objBEStudent.strUploadPath = string.Empty;
                    objBEStudent.strOriginalFileName = string.Empty;
                }

                objBStudent.BUploadPhotoIdentity(objBEStudent);

                if (objBEStudent.IntResult > 0)
                {
                    lblUpload.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_FileUploadSuccess + "</font>";
                    this.getPhotoIdentity();
                    ValidatePhotoIdentity();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblUpload.ClientID.ToString() + "').focus();", true);
                    Session["UPLOAD"] = "YES";
                    Response.Redirect("MyProfile.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + RequiredFieldValidator13.ClientID.ToString() + "').focus();", true);
                    Session["UPLOAD"] = "NO";
                    Response.Redirect("MyProfile.aspx");
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblsucc.Visible = false;
            trSecurityQuestionsView.Visible = false;
            trSecurityQuestionsEdit.Visible = true;
            ddlSecurityQuestion1.Items.Clear();
            ddlSecurityQuestion2.Items.Clear();
            ddlSecurityQuestion3.Items.Clear();
            BindSecurityQuestions();


            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BBindProfileSecurityQuestions(objBEStudent);

            if (objBEStudent.DsResult.Tables[1].Rows.Count > 0)
            {
                if (objBEStudent.DsResult.Tables[1].Rows[0]["Qid1"].ToString() != string.Empty)
                    ddlSecurityQuestion1.SelectedValue = objBEStudent.DsResult.Tables[1].Rows[0]["Qid1"].ToString();
                else
                    ddlSecurityQuestion1.SelectedValue = "-1";
                if (objBEStudent.DsResult.Tables[1].Rows[1]["Qid1"].ToString() != string.Empty)
                    ddlSecurityQuestion2.SelectedValue = objBEStudent.DsResult.Tables[1].Rows[1]["Qid1"].ToString();
                else
                    ddlSecurityQuestion2.SelectedValue = "-1";
                if (objBEStudent.DsResult.Tables[1].Rows[2]["Qid1"].ToString() != string.Empty)
                    ddlSecurityQuestion3.SelectedValue = objBEStudent.DsResult.Tables[1].Rows[2]["Qid1"].ToString();
                else
                    ddlSecurityQuestion3.SelectedValue = "-1";

                if (txtAnswer1.Text != string.Empty)
                    txtAnswer1.Text = objBEStudent.DsResult.Tables[1].Rows[0]["QAnswer1"].ToString();
                if (txtAnswer2.Text != string.Empty)
                    txtAnswer2.Text = objBEStudent.DsResult.Tables[1].Rows[1]["QAnswer1"].ToString();
                if (txtAnswer3.Text != string.Empty)
                    txtAnswer3.Text = objBEStudent.DsResult.Tables[1].Rows[2]["QAnswer1"].ToString();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + Label4.ClientID.ToString() + "').focus();", true);

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ddlSecurityQuestion1.SelectedIndex == 0 || ddlSecurityQuestion2.SelectedIndex == 0 || ddlSecurityQuestion3.SelectedIndex == 0)
                {
                    lblSecUpdated.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_MyprofileAllthreequestions + "</font>";
                }
                else if (txtAnswer1.Text == string.Empty || txtAnswer1.Text == "N/A" || txtAnswer2.Text == "" || txtAnswer2.Text == "N/A" || txtAnswer3.Text == "" || txtAnswer3.Text == "N/A")
                {
                    lblSecUpdated.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_MyprofileAllthreeAnswers + "</font>";
                }
                else if (ddlSecurityQuestion1.SelectedValue == ddlSecurityQuestion2.SelectedValue || ddlSecurityQuestion2.SelectedValue == ddlSecurityQuestion3.SelectedValue || ddlSecurityQuestion1.SelectedValue == ddlSecurityQuestion3.SelectedValue)
                {
                    lblSecUpdated.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_MyprofilethreeDifferentQuestions + "</font>";
                }
                else
                {
                    BEStudent objBEStudent = new BEStudent();
                    BStudent objBStudent = new BStudent();
                    objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBEStudent.strQuestion1 = ddlSecurityQuestion1.SelectedValue;
                    objBEStudent.strQuestion2 = ddlSecurityQuestion2.SelectedValue;
                    objBEStudent.strQuestion3 = ddlSecurityQuestion3.SelectedValue;
                    if (txtAnswer1.Text != "N/A")
                    {
                        objBEStudent.strAnswer1 = txtAnswer1.Text;
                    }
                    if (txtAnswer2.Text != "N/A")
                    {
                        objBEStudent.strAnswer2 = txtAnswer2.Text;
                    }
                    if (txtAnswer3.Text != "N/A")
                    {
                        objBEStudent.strAnswer3 = txtAnswer3.Text;
                    }
                    objBStudent.BUpdateSecurityQuestions(objBEStudent);
                    if (objBEStudent.IntResult > 0)
                    {
                        lblSecUpdated.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_SecquestionsUpdateSuccess + "</font>";
                        lblsucc.Visible = false;
                        trSecurityQuestionsView.Visible = true;
                        trSecurityQuestionsEdit.Visible = false;
                        BindSecurityQuestions();
                    }
                }
            }
            ValidatePhotoIdentity();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblSecUpdated.ClientID.ToString() + "').focus();", true);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            trSecurityQuestionsView.Visible = true;
            trSecurityQuestionsEdit.Visible = false;
            BindSecurityQuestions();
        }
        protected void btnEditTimeZone_Click(object sender, EventArgs e)
        {
            lblsucc.Text = string.Empty;
            trDemographicView.Visible = false;
            trDemographicEdit.Visible = true;
            lblformat.Visible = true;
            BindTimeZone();
            BindDemographicDetails();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblFirstNameEdit.ClientID.ToString() + "').focus();", true);
        }
        protected void btnSaveTimeZone_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BUser objBUser = new BUser();
                BEUser objBEUser = new BEUser();
                objBEUser.StrFirstName = txtFirstName.Text;
                objBEUser.StrLastName = txtLastName.Text;
                objBEUser.StrEmail = txtEmail.Text;
                objBEUser.strPhoneNumber = txtPhoneNumber.Text;
                objBEUser.strTimeZone = ddlTimeZone.SelectedValue;
                objBEUser.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                //11sep2017----removing plus sign from the country code
                string[] ArrCodes = null;
                if (!string.IsNullOrEmpty(txtCountryCode.Text))
                {
                    ArrCodes = txtCountryCode.Text.Split('+');
                }

                if (ArrCodes != null)
                    objBEUser.CountryCode = ArrCodes[0];


                objBUser.BUpdateTimeZone(objBEUser);

                if (objBEUser.IntResult == 1)
                {
                    Session["TimeZoneID"] = ddlTimeZone.SelectedValue.ToString();
                    Session["TimeZone"] = ddlTimeZone.SelectedItem.Text.ToString();
                    LinkButton lbtnTimeZone = this.Master.FindControl("lbtnTimeZone") as LinkButton;
                    BECommon objBECommon = new BECommon();
                    BCommon objBCommon = new BCommon();
                    objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                    objBCommon.BGetTimeDelay(objBECommon);
                    string[] strtimezone = Session["TimeZone"].ToString().Split('(');
                    lbtnTimeZone.Text = strtimezone[0].ToString() + " : " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy hh:mm tt");
                    Session["UserName"] = txtFirstName.Text + " " + txtLastName.Text + " [ Student ]";
                    Label lblUserName = this.Master.FindControl("lblUser") as Label;
                    lblUserName.Text = txtFirstName.Text + " " + txtLastName.Text + " [ Student ]";
                    lblsucc.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_TimeZoneUpdateSuccess + "</font>";
                }
                else
                {
                    lblsucc.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.MyProfile_TimeZoneUpdateFailed + "</font>";
                }
                BindTimeZone();
                BindDemographicDetails();
                lblformat.Visible = false;
                trDemographicEdit.Visible = false;
                trDemographicView.Visible = true;
                this.ValidatePhotoIdentity();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblsucc.ClientID.ToString() + "').focus();", true);
            }
        }
        protected void btnCancelTimeZone_Click(object sender, EventArgs e)
        {
            trDemographicEdit.Visible = false;
            trDemographicView.Visible = true;
            lblformat.Visible = false;
            BindTimeZone();
            BindDemographicDetails();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + Label1.ClientID.ToString() + "').focus();", true);
        }
        protected void ddlTimeZone_ItemDataBound(object sender, Telerik.Web.UI.RadComboBoxItemEventArgs e)
        {
            Telerik.Web.UI.RadComboBoxItem rdCm = e.Item;
            if (rdCm.Text == "Separator")
            {
                rdCm.Text = "----------------------------------------------";
                rdCm.IsSeparator = true;
            }

        }

        protected void rbtnKeyEdit_Click(object sender, EventArgs e)
        {
            trKeyStrokeView.Visible = false;
            trKeyStrokeEdit.Visible = true;



            //PostToKeyStroke();

        }

        public void PostToKeyStroke()
        {            
            try
            {
                string userid = Session[EnumPageSessions.USERID].ToString();
                string firstname = Request["firstname"];
                string firstnamelastname = Request["firstNameLastName"];
                string refirstNameLastName = Request["refirstNameLastName"];

                var jsonObject = new JObject();
                jsonObject.Add("userId", userid);
                jsonObject.Add("client", ConfigurationManager.AppSettings["client"]);
                jsonObject.Add("firstName", firstname);
                jsonObject.Add("firstNameLastName", firstnamelastname);
                jsonObject.Add("refirstNameLastName", refirstNameLastName);

                var request1 = ConfigurationManager.AppSettings["apiurl"].ToString() + "examity/api/user/profile";
                var request = (HttpWebRequest)HttpWebRequest.Create(request1);
                request.Method = "POST";

                request.Headers["Authorization"] = ConfigurationManager.AppSettings["authkey"];

                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byteArray = encoding.GetBytes(jsonObject.ToString());
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string ret = reader.ReadToEnd();
                    response.Close();

                    dynamic json = JValue.Parse(ret);

                    if (json.statusCode == "1001")
                    {
                        trKeyStrokeView.Visible = true;
                        trKeyStrokeEdit.Visible = false;
                        BEStudent objBEStudent = new BEStudent(){
                            IntUserID= Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]),
                            strFirstName=(firstname.Split(','))[0],
                            strLastName=(firstnamelastname.Split(','))[0]
                        };
                        BStudent objBStudent = new BStudent();                                                
                        objBStudent.BUpdateKeyStrokeDetails(objBEStudent);
                        BindDemographicDetails();
                        lblkeyMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_ExamiKEYUpdated + "</font>";
                    }
                    else if (json.statusCode == "1002")
                    {
                        trKeyStrokeView.Visible = false;
                        trKeyStrokeEdit.Visible = true;
                        lblkeyMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.MyProfile_ExamiKEYNotUpdated1 + "</font>";
                    }                  
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    {
                        string ret = new StreamReader(data).ReadToEnd();
                        dynamic json = JValue.Parse(ret);
                        lblkeyMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.MyProfile_ExamiKEYNotUpdated + "</font>";
                    }
                }
            }
        }


        protected void btnradSave_Click(object sender, EventArgs e)
        {
            PostToKeyStroke();
            ValidatePhotoIdentity();

        }

        protected void btnradCancel_Click(object sender, EventArgs e)
        {
            trKeyStrokeView.Visible = true;
            trKeyStrokeEdit.Visible = false;
        }

        protected void ShowOrHideexamiKEY()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BShowOrHideexamiKEY(objBEStudent);

            if (objBEStudent.BoolResult == true)
            {
                trexamiKNOW.Visible = false;
                trexamiKNOWmsg.Visible = true;
            }
            else
            {
                trexamiKNOW.Visible = true;
                trexamiKNOWmsg.Visible = false;

            }
        }

        private void ReduceImageSize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }
    }


}