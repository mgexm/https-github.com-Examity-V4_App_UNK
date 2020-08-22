<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="DeleteUserDetails.aspx.cs" Inherits="SecureProctor.CourseAdmin.DeleteUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <table cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td>
                <img src="../Images/Imgdelete_student.png" alt="delete" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="3" cellspacing="4" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="50%">&nbsp;&nbsp;&nbsp; <strong>Student First Name</strong>
                            </td>
                            <td align="left" width="50%">
                                <asp:Label ID="lblstudentfirstname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">&nbsp;&nbsp;&nbsp; <strong>Student Last Name</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStudentLastName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">&nbsp;&nbsp;&nbsp; <strong>Email Address</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmailID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">&nbsp;&nbsp;&nbsp; <strong>Role</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblrole" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">&nbsp;&nbsp;&nbsp; <strong>Phone Number</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">&nbsp;&nbsp;&nbsp; <strong>Time Zone</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">&nbsp;&nbsp;&nbsp;<strong>Special Accommodations</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">&nbsp;&nbsp;&nbsp;<strong>Comments</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle" id="trUpdate" runat="server">
                            <td colspan="2" align="center">
                                <telerik:RadButton ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click"
                                    Skin="Web20" />
                                &nbsp;&nbsp;&nbsp;
                                <telerik:RadButton ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"
                                    Skin="Web20" />
                            </td>
                        </tr>
                        <tr id="imgSuccess" runat="server">
                            <td valign="middle" align="right" width="20%">
                                <img src="../Images/ImgSuccessAlert.png" alt="Success" runat="server" id="imgtick"
                                    visible="false" />&nbsp;&nbsp;
                            </td>
                            <td valign="middle" align="left" width="80%">&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
