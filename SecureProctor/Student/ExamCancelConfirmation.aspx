<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="ExamCancelConfirmation.aspx.cs" Inherits="SecureProctor.Student.ExamCancelConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgCancellation.png" alt="student registration" />
                    </td>
                    <td width="1%" rowspan="4">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr valign="top">
                    <td width="100%">
                        <div class="login_new">
                            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="vertical-align: middle;">
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="4" width="100%" border="0" style="font-family: Arial;
                                            font-size: 12px; color: #000;">
                                          <%--  <tr style="font-size: 14px; color: #fff;" class="subHeadfont">
                                                <td align="center" colspan="2">
                                                    <asp:Label ID="lblHead" runat="server"></asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left" width="20%">
                                                    <strong>ID</strong>
                                                </td>
                                                <td align="left" width="20%">
                                                    <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    <strong>Student Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    <strong>Course Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    <strong>Exam Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    <strong>Exam Date</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    <strong>Exam Time </strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                
                                <tr>
                                   
                                                <td align="center">
                                                    &nbsp;&nbsp;<asp:Label ID="lblInfo" runat="server" Font-Size="Medium"></asp:Label>
                                                </td>
                                       
                                </tr>
                            </table>
                        </div>
                    </td>
                    
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
