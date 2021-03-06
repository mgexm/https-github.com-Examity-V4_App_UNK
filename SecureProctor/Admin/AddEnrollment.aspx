﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEnrollment.aspx.cs" Inherits="SecureProctor.Admin.AddEnrollment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
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
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                

                     <div class="heading customfont1">
                    <%=Resources.AppControls.Admin_AddEnrollment_Label_EnrollStudent%></div>
            </td>
        </tr>
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
        <tr id="trAddEnrollment" runat="server">
            <td>
            <div class="login_new1">
                <table cellpadding="0" cellspacing="2" width="100%" border="0">
                    
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable" width="30%">
                            <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_StudentName%></strong>
                        </td>
                        <td align="left" width="70%">
                            <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="gridviewAlternatestyle">
                        <td class="PopupLable">
                          <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_InstuctorName %></strong>
                        </td>
                        <td align="left">
                             <telerik:RadComboBox ID="ddlprovider" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnSelectedIndexChanged="ddlProviderName_SelectedIndexChanged" Filter="Contains" MarkFirstMatch="true"
                                                             AutoPostBack="true">
                                                        </telerik:RadComboBox>
                            <asp:Label ID="lblInstructor" runat="server" Visible="false"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="--Select Instructor--"
                                                ErrorMessage="Please select instructor name" ControlToValidate="ddlprovider" ForeColor="Red"  Display="Dynamic"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable">
                           <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_CourseName %></strong>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="ddlCourse" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Filter="Contains" MarkFirstMatch="true">
                               
                            </telerik:RadComboBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="--Select Course--"
                                                ErrorMessage="Please select course name" ControlToValidate="ddlCourse" ForeColor="Red"  Display="Dynamic"
                                          ValidationGroup="Save"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr class="gridviewAlternatestyle" id="trUpdate" runat="server">
                        <td align="left">
                        </td>
                        <td class="PopupButtons" valign="middle">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="<%$ Resources:AppControls,Admin_AddEnrollment_Button_Save %>"
                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnAdd_Click"  ValidationGroup="Save">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Admin_AddEnrollment_Button_Cancel %>"
                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false" OnClientClicked="close">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </div>
                </td>
        </tr>
        <tr id="trAddEnrollmentConfirmation" runat="server">
            <td>
            <div class="login_new1">
                <table cellpadding="0" cellspacing="2" width="100%" border="0">
                    
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable" width="30%">
                            <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_StudentName%></strong>
                        </td>
                        <td align="left" width="70%">
                            <asp:Label ID="lblStudentnameConfirmation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="gridviewAlternatestyle">
                        <td class="PopupLable">
                          <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_InstuctorName %></strong>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblInstuctorNameConfirm" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable">
                           <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_CourseName %></strong>
                        </td>
                        <td align="left">
                         <asp:Label ID="lblCourseNameConfirm" runat="server"></asp:Label>

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
