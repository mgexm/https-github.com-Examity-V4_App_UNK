<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="SecureProctor.CourseAdmin.AddCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">
        function close(sender, args) {
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
        <table cellpadding="5" cellspacing="5" width="100%">
            <tr>
                <td>
                    <div class="heading customfont1">
                        <%= Resources.AppControls.Provider_AddCourse_Label_AddCourse%>
                    </div>
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
            <tr id="trAddCourse" runat="server">
                <td>
                    <div class="login_new1">
                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                            <tr class="gridviewAlternatestyle">
                                <td width="30%" class="PopupLable">
                                    <strong>Instructors</strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <telerik:RadComboBox ID="ddlprovider" runat="server" Width="200" Height="100"
                                        EmptyMessage="Select Instructor" DataTextField="Name" DataValueField="ExamProviderID" Filter="Contains" MarkFirstMatch="true" >
                                    </telerik:RadComboBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please select Instructor"
                                        ControlToValidate="ddlprovider" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td width="30%" class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_AddCourse_Label_CourseID%></strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <asp:TextBox ID="txtCourseID" runat="server" Width="150" MaxLength="50"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddCourse_Error_CourseID%>"
                                        ControlToValidate="txtCourseID" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong><%= Resources.AppControls.Provider_AddCourse_Label_CourseName %></strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCourseName" runat="server" Width="300" MaxLength="100"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddCourse_Error_CourseName%>"
                                        ControlToValidate="txtCourseName" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td align="left"></td>
                                <td class="PopupButtons">
                                    <telerik:RadButton ID="btnAdd" runat="server" Text="<%$ Resources:AppControls,Provider_AddCourse_Button_Save %>"
                                        Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnAdd_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Provider_AddCourse_Button_Cancel %>"
                                        Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                        OnClientClicked="close">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr id="trAddCourseConfirm" runat="server">
                <td>
                    <div class="login_new1">
                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable" width="30%">
                                    <strong><%= Resources.AppControls.Provider_AddCourse_Label_CourseID%></strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblCourseID" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td align="left" class="PopupLable">
                                    <strong><%= Resources.AppControls.Provider_AddCourse_Label_CourseName %></strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
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
