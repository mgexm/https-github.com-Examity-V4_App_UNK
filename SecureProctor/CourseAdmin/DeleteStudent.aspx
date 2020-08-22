<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteStudent.aspx.cs" Inherits="SecureProctor.CourseAdmin.DeleteStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function close() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="5" cellspacing="5" width="100%">
                <tr>
                    <td>
                        <div class="heading customfont1">
                            <%=Resources.AppControls.Provider_DeleteStudent_Label_DeleteStudent%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="login_new1">
                            <telerik:RadScriptManager ID="smDeleteStudent" runat="server">
                            </telerik:RadScriptManager>
                            <table cellpadding="0" cellspacing="2" width="100%" border="0">
                                <tr id="trMessage" runat="server">
                                    <td align="center" colspan="2">
                                        <table width="100%" cellpadding="2" cellspacing="2">
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
                                <tr class="gridviewAlternatestyle">
                                    <td class="PopupLable" width="50%">
                                        <strong>

                                            <%= Resources.AppControls.Provider_DeleteStudent_Label_StudentFirstName%>
                                        
                                        </strong>
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Label ID="lblstudentfirstname" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle">
                                    <td class="PopupLable">
                                        <strong>
                                            <%= Resources.AppControls.Provider_DeleteStudent_Label_StudentLastName%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblStudentLastName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle">
                                    <td class="PopupLable">
                                        <strong>
                                            <%= Resources.AppControls.Provider_DeleteStudent_Label_EmailAddress%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblEmailID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle">
                                    <td class="PopupLable">
                                        <strong>
                                            <%= Resources.AppControls.Provider_DeleteStudent_Label_Role%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblrole" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle">
                                    <td class="PopupLable">
                                        <strong>
                                            <%= Resources.AppControls.Provider_DeleteStudent_Label_PhoneNumber%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle">
                                    <td class="PopupLable">
                                        <strong>
                                            <%= Resources.AppControls.Provider_DeleteStudent_Label_TimeZone%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle">
                                    <td class="PopupLable">
                                        <strong><%= Resources.AppControls.Provider_DeleteStudent_Label_SpecilalNeeds%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle" id="trcomments" runat="server" visible="false">
                                    <td class="PopupLable">
                                        <strong><%= Resources.AppControls.Provider_DeleteStudent_Label_Comments%></strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblComments" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" id="trUpdate" runat="server">
                                    <td colspan="2" class="PopupButtons1">
                                        <telerik:RadButton ID="btnConfirm" runat="server" Text="<%$ Resources:AppControls,Provider_DeleteStudent_Button_Confirm %>"
                                            OnClick="btnConfirm_Click" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" />
                                        &nbsp;&nbsp;&nbsp;
                                    <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Provider_DeleteStudent_Button_Cancel %>"
                                        Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClientClicked="close" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
