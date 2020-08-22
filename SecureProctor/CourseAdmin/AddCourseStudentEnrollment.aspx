<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourseStudentEnrollment.aspx.cs" Inherits="SecureProctor.CourseAdmin.AddCourseStudentEnrollment" %>

<!DOCTYPE html>

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
                           <%-- <telerik:RadComboBox ID="rcbStudent" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                             </telerik:RadComboBox>--%>
                             <telerik:RadComboBox ID="rcbStudent" runat="server" CheckBoxes="true" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" DropDownAutoWidth="Enabled"
                               EnableCheckAllItemsCheckBox="true" EmptyMessage="          --Select Student--          " LabelCssClass="SelectClient_text" Localization-AllItemsCheckedString="All Students selected" Filter="Contains" MarkFirstMatch="true">
                             </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="--Select Student--"
                                                ErrorMessage="Please select student name" ControlToValidate="rcbStudent" ForeColor="Red"  Display="Dynamic"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="gridviewAlternatestyle">
                        <td class="PopupLable">
                          <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_InstuctorName %></strong>
                        </td>
                        <td align="left">
                            
                            <asp:Label ID="lblInstructor" runat="server"></asp:Label>
                           
                        </td>
                    </tr>
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable">
                           <strong><%= Resources.AppControls.Admin_AddEnrollment_Label_CourseName %></strong>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCourse" runat="server" ></asp:Label>

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
