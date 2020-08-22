<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GotoMeeting.aspx.cs" Inherits="SecureProctor.Proctor.GotoMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <table align="center">

                <tr id="trMessage" runat="server">
                    <td align="center" colspan="2">
                        <table width="100%" cellpadding="5" cellspacing="5">
                            <tr>
                                <td align="center">
                                    <table cellpadding="0" cellspacing="0" id="tdInfo" runat="server">
                                        <tr>
                                            <td align="right" style="padding-right: 10px;">
                                                <asp:Image ID="ImgInfo" runat="server" Width="22" Height="22" />
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="lblInfo" runat="server" CssClass="lblInfo"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>


                <tr>

                    <td>

                        <asp:Label ID="Label1" Text="Exam ID :" runat="server"></asp:Label>

                    </td>

                    <td>

                        <asp:TextBox ID="txtTransactionID" runat="server"></asp:TextBox>

                        <asp:Label ID="lblTransid" runat="server" Visible="false"></asp:Label>

                    </td>

                </tr>

                <tr>

                    <td>

                        <asp:Label ID="Label2" Text="Exam session ID :" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGotoMeeting" runat="server"></asp:TextBox>

                        <asp:Label ID="lblGotoMeetingID" runat="server" Visible="false"></asp:Label>
                    </td>

                </tr>
                <tr>

                    <td>

                        <asp:Label ID="Label3" Text="Session Type :" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSessionType" runat="server">
                            <asp:ListItem Text="GoToMeeting" Value="1"></asp:ListItem>
                            <asp:ListItem Text="WebEx" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblSessionType" runat="server" Visible="false"></asp:Label>
                    </td>

                </tr>

                <tr>

                    <td colspan="2" align="center">


                        <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                            OnClick="btnSubmit_Click">
                        </telerik:RadButton>

                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
