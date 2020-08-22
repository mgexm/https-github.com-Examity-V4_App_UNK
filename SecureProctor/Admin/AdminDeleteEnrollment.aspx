<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminDeleteEnrollment.aspx.cs" Inherits="SecureProctor.Admin.AdminDeleteEnrollment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgEnrollStudentExam.png" alt="Home" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="3" cellspacing="4" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="40%">
                                &nbsp;&nbsp;&nbsp; <strong>Student Name</strong>&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="left" width="60%">
                                <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Email Address</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Gender</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Status</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle" id="trDelete" runat="server">
                            <td colspan="2" align="center">
                                <telerik:RadButton ID="btnDelete" runat="server" Text="<%$Resources:SecureProctor,Telerik_Student_Delete%>"
                                    Skin="<%$Resources:SecureProctor,Telerik_Button_Skin%>" OnClick="btnDelete_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" Text="<%$Resources:SecureProctor,Telerik_Student_Cancel%>"
                                    Skin="<%$Resources:SecureProctor,Telerik_Button_Skin%>" OnClick="btnCancel_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                        <tr id="imgSuccess" runat="server">
                            <td valign="middle" align="right">
                                <img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;
                            </td>
                            <td valign="middle" align="left">
                                &nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
