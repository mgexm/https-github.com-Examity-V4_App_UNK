<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="ValidateStudent.aspx.cs" Inherits="SecureProctor.Student.ValidateStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgIdentity.png" alt="login" />
                    </td>
                    <td width="1%" rowspan="2">
                    </td>
                 <%--   <td>
                        <img src="../Images/ImgHelp.png" alt="help" />
                    </td>--%>
                </tr>
                <tr>
                    <td width="70%" align="center">
                        <div class="login_new">
                            <table width="800" cellpadding="2" cellspacing="4">
                                <tr>
                                    <td align="center">
                                        <div class="steps">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblFailed" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table width="100%" cellpadding="5" cellspacing="5">
                                            <tr>
                                                <td align="left" style="padding-left:200px;">
                                                    <asp:Label ID="lblQuestion1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:200px;">
                                                    <telerik:RadTextBox ID="txtAnswer1" runat="server" MaxLength="100" Width="270">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:ResMessages,Student_SecAnswerEmpty %>"
                                                        ControlToValidate="txtAnswer1" ForeColor="Red" ValidationGroup="Submit">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="padding-left:200px;">
                                                    <asp:Label ID="lblQuestion2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:200px;">
                                                    <telerik:RadTextBox ID="txtAnswer2" runat="server" MaxLength="100" Width="270">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:ResMessages,Student_SecAnswerEmpty %>"
                                                        ControlToValidate="txtAnswer2" ForeColor="Red" ValidationGroup="Submit">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="padding-left:200px;">
                                                    <asp:Label ID="lblQuestion3" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:200px;">
                                                    <telerik:RadTextBox ID="txtAnswer3" runat="server" MaxLength="100" Width="270">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:ResMessages,Student_SecAnswerEmpty %>"
                                                        ControlToValidate="txtAnswer3" ForeColor="Red" ValidationGroup="Submit">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:200px;">
                                                    <telerik:RadButton ID="btnValidate" runat="server" Text="<%$ Resources:SecureProctor,Telerik_Student_Validate%>"
                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin%>" OnClick="btnValidate_Click"
                                                        CssClass="imghover" ValidationGroup="Submit">
                                                    </telerik:RadButton>
                                                    &nbsp;&nbsp;
                                                    <telerik:RadButton ID="btnClear" runat="server" Text="<%$ Resources:SecureProctor,Telerik_Student_Clear%>"
                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin%>" CssClass="imghover"
                                                        OnClick="btnClear_Click">
                                                    </telerik:RadButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td width="25%" rowspan="3" valign="top" class="help_text_i">
                        <div class="help_text_i_inner">
                            <ul>
                                <li>Please answer the security questions which matches the security answers provided
                                    during registration and click on “Validate” button.</li><br />
                                <br />
                                <li>Clicking on "Validate" button validates the answers against the answers stored in
                                    the database and if the answers are valid, then the system will proceed to the Agreements
                                    page.</li><br />
                                <br />
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
