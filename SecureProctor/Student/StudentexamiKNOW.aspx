<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="StudentexamiKNOW.aspx.cs" Inherits="SecureProctor.Student.StudentexamiKNOW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById('<%=txtAnswer1.ClientID%>').focus();

          });
    </script>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <h1 style="padding: 10px; color: #666;">
                    <asp:Label ID="Label1" runat="server" Text="examiKNOW <sup>®</sup>"></asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <div class="chat_window">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td align="center" class="AAStep_shadow" valign="top">
                                    <div class="AAStep_shadow_inner">
                                        <div class="NewStep_eK2" style="width: 800px; margin: 0px auto; display: none;" id="WithKEYStep2" runat="server"></div>
                                        <div class="steps1" style="margin: 0px auto; display: none;" id="WithoutKEYStep2" runat="server"></div>
                                        <asp:UpdatePanel ID="up" runat="server">
                                            <ContentTemplate>
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td width="100%" align="center">
                                                            <div class="login_new_steps">
                                                                <table width="600" cellpadding="2" cellspacing="4">
                                                                    <tr>
                                                                        <td align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <div>
                                                                                <table width="100%" cellpadding="5" cellspacing="5">
                                                                                    <tr>
                                                                                        <td align="left" style="padding-left: 50px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblQHead" Text="Question :" runat="server" TabIndex="20" CssClass="Display"></asp:Label></strong>
                                                                                            <asp:Label ID="lblQuestion1" runat="server" TabIndex="21" CssClass="Display"></asp:Label>
                                                                                            <asp:HiddenField ID="hfQid" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding-left: 50px;">
                                                                                            <telerik:RadTextBox ID="txtAnswer1" runat="server" MaxLength="100" Width="270" TabIndex="22" CssClass="Display" onpaste="return false;" oncopy="return false;" autocomplete="off" autofocus="autofocus">
                                                                                            </telerik:RadTextBox>
                                                                                            <asp:RequiredFieldValidator ID="rf" ControlToValidate="txtAnswer1" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                                                ForeColor="Red" Font-Bold="true" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                                                            <br />

                                                                                            <br></br>
                                                                                            <asp:Label ID="msg" runat="server" CssClass="attempts" Text="You have three attempts to answer the above question."></asp:Label>
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:Label ID="lblFailed" runat="server" Font-Bold="true" Font-Size="14px" ForeColor="Red"></asp:Label>
                                                                                            <br></br>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding-left: 50px; font-size: 16px;"><b>Note that answers are not case-sensitive.</b></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding-left: 50px;">
                                                                                            <asp:Button runat="server" CssClass="button1 orange" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="save" />
                                                                                            &nbsp;&nbsp;
                                                                                               
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
