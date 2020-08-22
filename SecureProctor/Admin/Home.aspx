<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SecureProctor.Admin.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgHome.png" alt="home" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <table width="100%" cellpadding="2" cellspacing="4" align="left">
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
                                                                <a href="AdminExamStatus.aspx">
                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ImgExamStatus.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="AdminExamStatus.aspx">
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
                                  
                                </tr>
                                <tr>
                                   
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
                                                                <a href="AdminReports.aspx">
                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgReports.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="AdminReports.aspx">
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
