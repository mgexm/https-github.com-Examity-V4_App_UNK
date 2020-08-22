<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="SecureProctor.Admin.EditStudent" %>

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
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    

                         <div class="heading customfont1">
                    <%=Resources.AppControls.Admin_EditStudent_Label_EditStudent%></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="login_new1">
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
                                <td class="PopupLable" width="40%">
                                    <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_StudentFirstName %></strong>&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="left" width="60%">
                                    <asp:TextBox ID="lblstudentfirstname" runat="server" MaxLength="100"></asp:TextBox>
                                    <asp:Label ID="lblSFirstName" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_EditStudent_Error_StudentFirstName %>"
                                        ControlToValidate="lblstudentfirstname" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_StudentLastName%></strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="lblStudentLastName" runat="server" MaxLength="100"></asp:TextBox>
                                    <asp:Label ID="lblSLastName" runat="server" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_EditStudent_Error_StudentLastName %>"
                                        ControlToValidate="lblStudentLastName" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_EmailAddr%></strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="lblEmailID" runat="server" Width="60%" MaxLength="100"></asp:TextBox>
                                    <asp:Label ID="lblEmailAddress" runat="server" Visible="false"></asp:Label>
                                    </br>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_EditStudent_Error_EmailAddr %>"
                                        ControlToValidate="lblEmailID" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                        ForeColor="Red" runat="server" ControlToValidate="lblEmailID" ErrorMessage="<%$ Resources:AppMessages,Admin_EditStudent_Error_InValidEmailAddr %>"
                                        ValidationGroup="Edit" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        <%--    <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                     <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_PhoneNumber%></strong>
                                </td>
                                <td align="left">
                                   
                                    <telerik:RadMaskedTextBox ID="txtPhoneNumber" runat="server" Mask="###-###-####">
                                    </telerik:RadMaskedTextBox>
                                    <asp:Label ID="lblformat" runat="server" Text="(ex:202-000-0000)"></asp:Label>
                                    <asp:Label ID="lblMobileNumber" runat="server" Visible="false"></asp:Label>
                           
                                </td>
                            </tr>--%>
                            <%--<tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                   <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_TimeZone%></strong>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTimeZone" runat="server" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlTimeZone" runat="server" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="RFTimeZone" InitialValue="Select Time Zone"
                                        Display="Dynamic" ControlToValidate="ddlTimeZone" ValidationGroup="Edit" ErrorMessage="<%$ Resources:AppMessages,Admin_EditStudent_Error_InValidTimeZone %>" />
                                </td>
                            </tr>--%>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_Status%></strong>
                                </td>
                                <td align="left">
                                     <telerik:RadScriptManager ID="sm1" runat="server">
                                    </telerik:RadScriptManager>
                                    <telerik:RadComboBox ID="ddlStatus" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="Inactive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_SpecialNeeds%></strong>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSpecialNeeds" runat="server" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlSpecialNeeds" runat="server" AppendDataBoundItems="true"
                                        OnSelectedIndexChanged="ddlSpecialNeeds_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle" runat="server" id="trcomments" visible="false">
                                <td class="PopupLable">
                                   <strong>
                                        <%= Resources.AppControls.Admin_EditStudent_Label_Comments%></strong>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblcomments" runat="server" Visible="false"></asp:Label>
                                    <textarea id="txtcomments" runat="server" style="width: 250px;"></textarea>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle" id="trUpdate" runat="server">
                                <td colspan="2" align="center" class="PopupButtons1">
                                    <telerik:RadButton ID="imgUpdate" runat="server" Text="<%$ Resources:AppControls,Admin_EditStudent_Button_Update %>"
                                        OnClick="btnUpdate_Click" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                        ValidationGroup="Edit" />
                                    <telerik:RadButton ID="imgCancel" runat="server" Text="<%$ Resources:AppControls,Admin_EditStudent_Button_Cancel %>"
                                        Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                        OnClientClick="closeWindow(); return false;" AutoPostBack="false" OnClientClicked="close" />
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
