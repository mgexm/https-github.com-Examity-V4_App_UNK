<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="ExamCloseConfirmation.aspx.cs" Inherits="SecureProctor.Student.ExamCloseConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/examcomplete.png" />
                    </td>
                    <td width="1%" rowspan="2">
                    </td>
                    <td>
                        <img src="../Images/help.png" />
                    </td>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new">
                            <table width="100%" cellpadding="0" cellspacing="0" style="font-family: Arial; font-size: 12px;">
                                <tr style="font-size: 16px; color: #000; height: 30px;">
                                    <td align="center" valign="middle" style="font-size: 14px; color: #fff;" class="subHeadfont">
                                        <asp:Label ID="lblHead" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="4" width="100%" border="0" style="font-family: Arial;
                                            font-size: 12px; color: #000;">
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left" width="20%">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam ID</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left" width="20%">
                                                    <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Student Name</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam Name</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam Date</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam Time </strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <%-- <tr style="background: #f6f6f6; line-height: 25px;">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Open Books&nbsp;:&nbsp;&nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblBook" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>--%>
                                            <%--<tr>
                                                <td align="center" colspan="4" runat="server" id="tdButton">
                                                    <telerik:RadButton ID="imgConfirm" runat="server" Text="Confirm" Skin="Web20" 
                                                        onclick="imgConfirm_Click">
                                                    </telerik:RadButton>
                                                    &nbsp;&nbsp;
                                                    <telerik:RadButton ID="imgBack" runat="server" Text="Back" Skin="Web20" onclick="imgBack_Click">
                                                    </telerik:RadButton>
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td id="tickimg" runat="server">
                                        <img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td width="25%" rowspan="3" valign="top" class="help_text_i">
                        <div class="help_text_i_inner">
                            <strong>How do I schedule for an exam ?</strong>
                            <ul>
                                <li>You can schedule at any timeslot that best suits you</li>
                                <li>You can schedule for an exam 48 hours before the exam</li>
                                <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                                <li>Select a preferred date (grayed dates mean they can't be selected)</li>
                                <li>Select the time that suits you best.</li>
                            </ul>
                            <strong>What happens after I schedule ?</strong>
                            <ul>
                                <li>You will get an email confirming your schedule</li>
                                <li>In the email, you will have instructions what to do before and during the exam</li>
                            </ul>
                            <strong>How do Reschedule/cancel ?</strong>
                            <ul>
                                <li>You can Reschedule at any time slot that best suits you</li>
                                <li>You can Reschedule for an exam 24 hours before the previous scheduled time slot</li>
                                <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
