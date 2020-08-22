<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEditEnrollment.aspx.cs" Inherits="SecureProctor.Admin.AdminEditEnrollment" %>

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
                                <telerik:RadTextBox ID="txtStudentName" runat="server" Width="250" MaxLength="100" Skin="Web20" Visible="false">
                                            </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Email Address</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                                <telerik:RadTextBox ID="txtEmailAddress" runat="server" Width="250" MaxLength="100" Skin="Web20" Visible="false">
                                            </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Gender</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                                <telerik:RadComboBox ID="ddlGender" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                                Width="100" Visible="false"></telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                <telerik:RadComboBox ID="ddlCourseName" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                                Width="150" Visible="false"></telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Status</strong>
                            </td>
                            <td align="left">
                                <%--<asp:Label ID="lblTimeZone" runat="server"></asp:Label>--%>
                                <%-- <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="true">
                                                                               
                                                                               <asp:ListItem Value="1">Active</asp:ListItem>
                                                                               <asp:ListItem Value="0">In Active</asp:ListItem>

                                                                               </asp:DropDownList>--%>
                                <telerik:RadComboBox ID="ddlStatus" runat="server" Width="170" AutoPostBack="true"
                                    Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Active" Value="1" />
                                        <telerik:RadComboBoxItem Text="Inactive" Value="0" />
                                    </Items>
                                </telerik:RadComboBox><asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle" id="trUpdate" runat="server">
                            <td colspan="2" align="center">
                                <%--<telerik:RadButton ID="btnEdit" runat="server" Text="<%$Resources:SecureProctor,Common_Edit%>"
                                    Skin="<%$Resources:SecureProctor,Telerik_Button_Skin%>" OnClick="btnEdit_Click" Visible="false">
                                </telerik:RadButton>--%>
                                <telerik:RadButton ID="btnUpdate" runat="server" Text="<%$Resources:SecureProctor,Telerik_Student_Update%>"
                                    Skin="<%$Resources:SecureProctor,Telerik_Button_Skin%>" OnClick="btnUpdate_Click">
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
