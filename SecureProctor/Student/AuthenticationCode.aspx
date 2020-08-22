<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="AuthenticationCode.aspx.cs" Inherits="SecureProctor.Student.AuthenticationCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script language="javascript" type="text/javascript">
        function showalert() {
            var v = confirm("You are requesting a new authentication code?");
            if (v == true)
                return true;
            else
                return false;
        }
    </script>
    <div>
        <table cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td>
                    <h1 style="padding: 10px; color: #666;">
                        <asp:Label ID="lblHead" runat="server" Text="Authentication code"></asp:Label>
                    </h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div class="stepsID3"></div>
                </td>
            </tr>
        </table>
        <div class="login_new_steps">
            <table cellpadding="2" cellspacing="20" width="100%" runat="server" id="tbl1">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblMail" runat="server" Text="Examity will now send you an email with the authentication code needed to continue.  This code will be sent to " Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btncode" Text="Click to send the code" CssClass="button3 orange" OnClick="btncode_Click" />

                    </td>
                </tr>
            </table>
            <table id="tbl2" cellpadding="2" cellspacing="2" width="100%" runat="server" visible="false">
                <tr>
                    <td align="center">
                        <p align="center">

                            <span style="font-size: 23px;">
                                <asp:Label ID="Label1" runat="server" Text="Enter your authentication code."></asp:Label>
                            </span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblText" runat="server" Text="The code was sent via email. When you receive it, enter it below." Font-Size="Medium"></asp:Label><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:TextBox ID="txtCode" runat="server" Width="260px" Height="35px" Font-Size="25px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnValidate" runat="server" Text="Next" OnClick="btnValidate_Click" CssClass="button3 orange" /><br />
                        <br />
                        <asp:Label ID="lblText1" runat="server" Text="Please check your spam folder if you do not receive the email within 5 minutes." Font-Size="Medium"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <p>
                            <asp:LinkButton ID="lbtnResend" runat="server" OnClick="lbtnResend_Click" Text="Resend code." OnClientClick="return showalert();" Font-Size="Medium" ForeColor="Blue"></asp:LinkButton><br />
                            <asp:Label ID="Label2" runat="server" Text="Note: Prior code will be disabled." Font-Size="Medium"></asp:Label>
                        </p>
                    </td>
                </tr>
            </table>
            <table id="tbl3" cellpadding="2" cellspacing="20" width="100%" runat="server" visible="false">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblresult" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
