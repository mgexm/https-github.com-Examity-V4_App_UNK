<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SecureProctor.Provider.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgHome.png" alt="home" />
                       <%-- <div id="supportpanels" style="float:right;width:360px;color:#0066FF;font-size:13px;">
                <div class="livechatpannel" style="float:left;width:70px;cursor:pointer">
                    <u>Live Chat</u>&nbsp;|
                </div>
                <div id="Emailsupport" style="float:left;width:100px;">
                    <a href="mailto:support@examity.com" style="color:#0066FF"><u>Email Support</u></a>&nbsp;|
                </div>
                <div id="phonesupport" style="float:left;width:180px">
                    Phone Support:
                    
                    855-EXAMITY
                </div>
                
                </div>--%>

                
                    </td>
                </tr>
                                   <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <table width="100%" cellpadding="2" cellspacing="4" align="left">
                                <tr style="display:none;">
                                    <td align="center" width="40%" colspan="4" style="padding-left:70px;">

  <asp:Label ID="lblMsg" runat="server" Visible="false" Text="Please update your time zone by clicking on the time on the top right hand corner of the site" ForeColor="green"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td width="33%">
                                    </td>
                                    <td valign="top" width="34%">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="ExamStatus.aspx">
                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ImgExamStatus.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="ExamStatus.aspx">
                                                                                    <img src="../Images/ImgExamStatus_DB.png" alt="Exam status" /></a>
                                                                            </td>
                                                                            <td>
                                                                                <%--Tracks status of all tests (scheduled, proctored or audited).--%>
                                                                                Track scheduled, completed and proctored exams.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="33%">
                                    </td>
                                    <%--<td width="32%" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="ExamDetails.aspx">
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgExamDetails.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="ExamDetails.aspx">
                                                                                    <img src="../Images/ImgExamDetails_DB.png" alt="Exam Details" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Manages course/exam information and proctor instruction.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <%--<td valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="Students.aspx">
                                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/ImgViewStudent.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="Students.aspx">
                                                                                    <img src="../Images/ImgStudent_DB.png" alt="View Student" /></a>
                                                                            </td>
                                                                            <td>
                                                                                View Student Details.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>--%>
                                    <td width="33%">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="CourseDetails.aspx">
                                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Courses_exams.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="CourseDetails.aspx">
                                                                                    <img src="../Images/ImgCourseDetails2.png" alt="Course Details" /></a>
                                                                            </td>
                                                                            <td>
                                                                                <%--Manages course/exam information and proctor instruction.--%>
                                                                                Edit. Select security. Input rules.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="34%" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="CourseStudents.aspx">
                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/student.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="CourseStudents.aspx">
                                                                                    <img src="../Images/ImgStudent_DB.png" alt="Enroll student" /></a>
                                                                            </td>
                                                                            <td>
                                                                                <%--View Student Details and enrollment roaster.--%>
                                                                                Add. Confirm accuracy. Edit.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" width="33%">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="Reports.aspx">
                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgReports.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="Reports.aspx">
                                                                                    <img src="../Images/ImgReports_DB.png" alt="Reports" /></a>
                                                                            </td>
                                                                            <td>
                                                                                <%--To better understand metrics and analytics associated with exams.--%>
                                                                                Review analytics.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="MyProfile.aspx">
                                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/ImgMyProfile.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="MyProfile.aspx">
                                                                                    <img src="../Images/ImgMyProfile_DB.png" alt="My Profile" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Manages account information and password.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <div class="clear">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
