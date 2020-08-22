<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SecureProctor.Student.Home" %>

<asp:Content ID="StudentHome" ContentPlaceHolderID="StudentContent" runat="Server">
    <%--<script src="../Scripts/deployJava.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/swfobject.js" language="javascript" type="text/javascript"></script>--%>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/Imghome.png" />
         <%--   <div id="supportpanels" style="float:right;width:360px;color:#0066FF;font-size:13px;">
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
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="2" cellspacing="4" align="left">
                        <tr>
                            <td valign="top" width="33%">
                                <%-- <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="Reports.aspx">
                                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/ImgReports.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px; height: 90px;">
                                                            <table cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../Images/ImgReports_DB.png" alt="No image" />
                                                                    </td>
                                                                    <td>
                                                                        Student can download a report of all exams(scheduled/completed).
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>--%>
                            </td>
                            <td valign="top" width="34%">
                                <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="StartAnExam.aspx">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgStartExam.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px;">
                                                            <table cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td>
                                                                        <a href="StartAnExam.aspx">
                                                                            <img src="../Images/ImgStartExam_DB.png" alt="No image" /></a>
                                                                    </td>
                                                                    <td valign="middle">
                                                                        Begin scheduled exam.
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
                                <%--<table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="RescheduleExam.aspx">
                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ImgRescheduleExam.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px;">
                                                            <table cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../Images/ImgRescheduleExam_DB.png" alt="No image" />
                                                                    </td>
                                                                    <td valign="middle">
                                                                        Student can reschedule an exam by selecting the course, exam and time.
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>--%>
                            </td>
                            <%--<td valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="MyProfile.aspx">
                                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/ImgMyProfile.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px; height: 90px;">
                                                            <table cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td align="center" valign="top">
                                                                        <img id="img" runat="server" src="~/Images/noimage.jpg" width="105" height="71" alt="No image" />
                                                                    </td>
                                                                    <td>
                                                                        Student can manage account information (ID, security questions and password).
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
                            <td valign="top" width="33%">
                                <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="MyProfile.aspx">
                                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/ImgMyProfile.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px;">
                                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                                <tr>
                                                                    <td align="center" valign="top">
                                                                        <a href="MyProfile.aspx">
                                                                            
                                                                            <img id="img" runat="server" src="../Images/noimage.png" width="105" height="71" alt="No image" /></a>
                                                                    </td>
                                                                    <td align="left">
                                                                        Upload ID. Enter security questions. Confirm time zone.
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
                                                        <a href="ScheduleAnExam.aspx">
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgScheduleexam.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px;">
                                                            <table cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td>
                                                                        <a href="ScheduleAnExam.aspx">
                                                                            <img src="../Images/ImgScheduleExam_DB.png" alt="No image" /></a>
                                                                    </td>
                                                                    <td>
                                                                        Make appointment.
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
                            <td width="33%" valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="MyExams.aspx">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/RescheduleCancel.png" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="boreder_home">
                                                        <div style="padding: 10px;">
                                                            <table cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td>
                                                                        <a href="MyExams.aspx">
                                                                            <img src="../Images/ImgMyExam_DB.png" alt="No image" /></a>
                                                                    </td>
                                                                    <td>
                                                                        Change appointment.
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
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
