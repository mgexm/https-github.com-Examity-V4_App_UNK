<%@ Page Title="" Language="C#" MasterPageFile="~/Auditor/Auditor.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SecureProctor.Auditor.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AuditorContent" runat="server">
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
                                <tr><td width="33%"></td>
                                    <td width="34%" valign="top" align="center">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="center">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="Inbox.aspx">
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgInbox.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="Inbox.aspx">
                                                                                    <img src="../Images/ImgInbox_DB.png" alt="Inbox" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Auditor can view the transactions that are awaiting for approval.
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
                                    </td><td width="33%"></td>
                                    <%--<td width="33%" valign="top" style="display: none;">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="ProcessedExamRequests.aspx">
                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgProcessedExams.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="ProcessedExamRequests.aspx">
                                                                                    <img src="../Images/ImgProcessedExams_DB.png" alt="Exam requests" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Auditor can view the processed transactions till date.
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
                                    <%--<td valign="top" width="32%">
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
                                                                                <img src="../Images/ImgReports_DB.png" alt="My Profile" />
                                                                            </td>
                                                                            <td>
                                                                                Auditor can generate a report for all the exams conducted in a specified date range.
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
                                    <td width="33%" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <a href="StudentLookup.aspx">
                                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Imgstudentlook.png" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="boreder_home">
                                                                <div style="padding: 10px;">
                                                                    <table cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                <a href="StudentLookup.aspx">
                                                                                    <img src="../Images/ImgStudent_DB.png" alt="Student lookup" /></a>
                                                                            </td>
                                                                            <td>
                                                                                Auditor can view the student details.
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
                                                                                Auditor can generate a report for all the exams conducted in a specified date range.
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
                                                                                Auditor can manage account information.
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
                                    <%--<td>
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
