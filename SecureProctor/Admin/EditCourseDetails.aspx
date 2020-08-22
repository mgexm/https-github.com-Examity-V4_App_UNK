<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="EditCourseDetails.aspx.cs" Inherits="SecureProctor.Admin.EditCourseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgCourseDetails.png" alt="Edit Course Details" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="3" cellspacing="4" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="40%">
                                &nbsp;&nbsp;&nbsp; <strong>Course ID</strong>&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="TxtCourseID" runat="server"></asp:TextBox>
                                <asp:Label ID="lblCourseID" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$Resources:SecureProctor,Grid_Header_CourseID%>"
                                    ControlToValidate="TxtCourseID" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCourseName" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="lblCourseName" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:SecureProctor,Grid_Header_CourseName%>"
                                    ControlToValidate="txtCourseName" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Instructor Name</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblProviderName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                            </td>
                            <td align="left" valign="middle">
                                <telerik:RadButton ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" ValidationGroup="Edit" />
                                <telerik:RadButton ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"
                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" CausesValidation="false" />
                                <img id="imgSuccess" runat="server" src="../Images/ImgSuccessAlert.png" alt="Success"
                                    valign="middle" visible="false" />&nbsp;&nbsp;
                                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
