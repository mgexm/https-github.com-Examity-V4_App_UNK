<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SecureProctor.Proctor.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgHome.png" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <table width="100%" cellpadding="2" cellspacing="4" align="left">
                                <tr>
                                    <td width="33%">
                                    </td>
                                    <td width="34%" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="ValidateStudentIdentity.aspx">
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgValidateProctor.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="ValidateStudentIdentity.aspx">
                                                                                    <img src="../Images/ImgValidateProctor_DB.png" alt="Validate proctor" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Proctor can view and validate the list of scheduled, ongoing and completed exams.
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
                                    <td width="33%" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="ExamStatus.aspx">
                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgStudentLookUp.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="ExamStatus.aspx">
                                                                                    <img src="../Images/ImgStudentLookUp_DB.png" alt="Student/Exam lookup" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Proctor can validate a student by viewing the videos.
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
                                    <td valign="top" width="34%">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="Reports.aspx">
                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ImgReports.png" /></a>
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
                                                                                Proctor can generate a report of all the exams conducted in a particular date range.
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
                                                                <a href="MyProfile.aspx">
                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgMyProfile.png" /></a>
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
                                                                                Proctor can manage account information.
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
                                    <%--<td colspan="2">
                                        &nbsp;
                                    </td>--%>
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
