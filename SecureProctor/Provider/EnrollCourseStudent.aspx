<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollCourseStudent.aspx.cs" Inherits="SecureProctor.Provider.EnrollCourseStudent" %>

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
    <table cellpadding="5" cellspacing="5" width="100%">
        <tr>
            <td>
                <div class="heading customfont1">
                    <%=Resources.AppControls.Provider_AddEnrollment_Label_EnrollStudent%></div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr id="trMessage" runat="server">
                            <td align="left" colspan="2">
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
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable" width="25%">
                                <strong><%= Resources.AppControls.Provider_AddEnrollment_Label_StudentName%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left" width="75%">
                              <%-- <telerik:RadComboBox ID="rcbStudents" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"                                    >
                                </telerik:RadComboBox>--%>
                                <telerik:RadComboBox ID="rcbStudents" runat="server" CheckBoxes="true" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" DropDownAutoWidth="Enabled"
                               EnableCheckAllItemsCheckBox="true" EmptyMessage="          --Select Student--          " LabelCssClass="SelectClient_text" Localization-AllItemsCheckedString="All Students selected"   Filter="Contains" MarkFirstMatch="true">
                             </telerik:RadComboBox>
                                 <asp:Label ID="lblStudent" runat="server" Visible="false"></asp:Label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="--Select Student--"
                                                ErrorMessage="Please select Student name" ControlToValidate="rcbStudents" ForeColor="Red" Display="Dynamic"
                                               ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddEnrollment_Label_CourseName %></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                               
                                          <asp:Label ID="lblCourse" runat="server" ></asp:Label>
                                
                                     
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle" id="trUpdate" runat="server">
                            <td align="left">
                            </td>
                            <td class="PopupButtons">
                                <telerik:RadButton ID="btnAdd" runat="server" Text="<%$ Resources:AppControls,Provider_AddEnrollment_Button_Save %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnAdd_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Provider_AddEnrollment_Button_Cancel %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                    OnClientClicked="close">
                                </telerik:RadButton>
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
