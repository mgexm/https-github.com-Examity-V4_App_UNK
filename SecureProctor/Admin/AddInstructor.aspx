<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInstructor.aspx.cs" Inherits="SecureProctor.Admin.AddInstructor" %>

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
    <telerik:radstylesheetmanager id="RadStyleSheetManager1" runat="server">
    </telerik:radstylesheetmanager>
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblAddStudent" runat="server" Text="<%$Resources:AppControls,Admin_AddInstructor_Label_AddInstructor%>"
                    CssClass="CommonHeader"></asp:Label>
            </td>
        </tr>
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
        <tr id="trAddInstructor" runat="server">
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="30%">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_FirstName%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left" width="70%">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_AddStudent_Error_FirstName%>"
                                    ControlToValidate="txtFirstName" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_LastName%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLastName" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_AddStudent_Error_LastName%>"
                                    ControlToValidate="txtLastName" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_UserID%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUserID" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_AddStudent_Error_UserID%>"
                                    ControlToValidate="txtUserID" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_EmailAddress%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmailAddress" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_AddStudent_Error_EmailAddress%>"
                                    ControlToValidate="txtEmailAddress" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong>Send Confirmation Email</strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="chkConfirmEmail" runat="server"/>
                                <asp:Label ID="txtConfirmation" Text="(Select the check box to send an email to instructor.)" runat="server" />
                            </td>
                        </tr>

                        
                        <tr class="gridviewRowstyle">
                            <td align="left">
                            </td>
                            <td align="left" valign="middle">
                                <telerik:radbutton id="btnAdd" runat="server" text="<%$ Resources:AppControls,Admin_AddStudent_Button_Save %>" onclick="btnAdd_Click"
                                    skin="<%$ Resources:AppConfigurations,Skin_Current %>" 
                                    validationgroup="Save">
                                </telerik:radbutton>
                                <telerik:radbutton id="btnCancel" runat="server" text="<%$ Resources:AppControls,Admin_AddStudent_Button_Cancel %>"
                                    skin="<%$ Resources:AppConfigurations,Skin_Current %>" causesvalidation="false"
                                    onclientclicked="close">
                                </telerik:radbutton>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td id="trAddInstructorConfirm" runat="server">
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="30%">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_FirstName%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left" width="70%">
                                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_LastName%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                            </td>
                        </tr>
                         <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_UserID%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_EmailAddress%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                            </td>
                        </tr>

                        
                        
                        
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>


