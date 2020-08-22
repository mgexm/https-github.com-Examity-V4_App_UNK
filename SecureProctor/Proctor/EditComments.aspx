<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditComments.aspx.cs" Inherits="SecureProctor.Proctor.EditComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function close() {
            window.close();
        }

    </script>

    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <telerik:radstylesheetmanager id="RadStyleSheetManager2" runat="server">
    </telerik:radstylesheetmanager>
        <telerik:radscriptmanager id="RadScriptManager2" runat="server">
    </telerik:radscriptmanager>
        <table cellpadding="5" cellspacing="5" width="100%">
            <tr>
                <td>

                    <div class="heading customfont1">
                        <%=Resources.AppControls.Auditor_EditCourse_Label_EditComments%>
                    </div>
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
                            <tr id="trCommentsEdit" runat="server">
                                <td align="center" colspan="2">
                                    <table width="100%" cellpadding="0" cellspacing="2">

                                        <tr class="gridviewRowstyle">
                                            <td class="PopupLable">
                                                <strong>Exam Flag:</strong>
                                            </td>
                                            <td align="left">
                                                <telerik:radcombobox id="ddlFlags" runat="server" skin="Web20" width="300"
                                                    autopostback="true"  onselectedindexchanged="ddlFlags_SelectedIndexChanged">
                                                    <Items>
                                                       
                                                        <telerik:RadComboBoxItem Text="Alert" ImageUrl="../Images/ImgAlert.png" Value="4" />


                                                        <telerik:RadComboBoxItem Text="No Violation" ImageUrl="../Images/flag_g.png" Value="1" />


                                                        <telerik:RadComboBoxItem Text="Possible Violation" ImageUrl="../Images/flag_y.png" Value="2" />

                                                        <telerik:RadComboBoxItem Text="Violation" ImageUrl="../Images/flag.png" Value="3" />
                                                    </Items>
                                                </telerik:radcombobox>

                                            </td>
                                        </tr>


                                        
                                        <tr class="gridviewAlternatestyle" id="DivDropdown" runat="server">
                                            <td class="PopupLable" width="30%">
                                                <strong>Description:</strong>
                                            </td>
                                            <td align="left" width="70%">
                                                <telerik:radcombobox id="ddlAlerts" runat="server" skin="Web20" width="300" onselectedindexchanged="ddlAlerts_SelectedIndexChanged" AutoPostBack="true" Filter="Contains" MarkFirstMatch="true">
                                                </telerik:radcombobox>
                                            </td>
                                        </tr>
                                   <tr class="gridviewRowstyle" id="DivTextBox"  >
                                            <td class="PopupLable" width="30%">
                                                <strong>Comments:</strong>
                                            </td>
                                            <td align="left" width="70%">
                                                <asp:TextBox ID="txtComments" runat="server" MaxLength="300" TextMode="MultiLine" Rows="5"
                                                    Width="70%"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please add comments"
                                                                    ControlToValidate="txtComments" ForeColor="Red"  ValidationGroup="Edit">
                                                                </asp:RequiredFieldValidator>
                                                </br>
                                            
                                            </td>
                                        </tr>
                                        <tr>

                                                            <td align="left" valign="top"><strong>Incident Time Stamp:</strong></td>
                                                            
                                                            <td align="left" valign="top">

                                                                <telerik:radcombobox id="ddlHours" runat="server" appenddatabounditems="True" skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                    width="80" height="200">
                                                                                                    </telerik:radcombobox>

                                                                <telerik:radcombobox id="ddlMinutes" runat="server" appenddatabounditems="True" skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                    width="80" height="200">
                                                                                                    </telerik:radcombobox>
                                                                <telerik:radcombobox id="ddlsec" runat="server" appenddatabounditems="True" skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                    width="80" height="200">
                                                                                                    </telerik:radcombobox>

                                                            </td>

                                                        </tr>
                                        <tr class="gridviewRowstyle">
                                            <td class="PopupLable">
                                                <strong>Added By:</strong>
                                            </td>
                                            <td align="left">
                                                <telerik:radcombobox id="ddlAddedBy" runat="server" skin="<%$ Resources:AppConfigurations,Skin_Current %>" Filter="Contains" MarkFirstMatch="true">
                                                
                                            </telerik:radcombobox>
                                            </td>
                                        </tr>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>Added on:</strong>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAddedOn" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>

                                        </tr>
                                        <tr class="gridviewRowstyle" id="trUpdate" runat="server">
                                            <td align="left"></td>
                                            <td class="PopupButtons">
                                                <telerik:radbutton id="btnUpdate" runat="server" text="<%$ Resources:AppControls,Admin_EditCourse_Button_Update %>"
                                                    onclick="btnUpdate_Click" skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                    validationgroup="Edit" />
                                                <telerik:radbutton id="btnBack" runat="server" text="<%$ Resources:AppControls,Admin_EditCourse_Button_Cancel %>"
                                                    skin="<%$ Resources:AppConfigurations,Skin_Current %>" causesvalidation="false" onclientclicked="close" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trCommentsView" runat="server">
                                <td align="center" colspan="2">
                                    <table width="100%" cellpadding="0" cellspacing="2">

                                        <tr class="gridviewRowstyle">
                                            <td class="PopupLable">
                                                <strong>Exam Flag:</strong>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblflag" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                         
                                        <tr class="gridviewAlternatestyle" id="DivTextBox_View" > 
                                            <td class="PopupLable" width="30%">
                                                <strong>Comments:</strong>
                                            </td>
                                            <td align="left" width="70%">
                                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gridviewAlternatestyle" id="DivDropdown_View">
                                            <td class="PopupLable" width="30%">
                                                <strong>Description:</strong>
                                            </td>
                                            <td align="left" width="70%">
                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gridviewRowstyle">
                                            <td class="PopupLable">
                                                <strong>Incident Time Stamp:</strong>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblIncidentTimeStamp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>Added By:</strong>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAddedBy" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gridviewRowstyle">
                                            <td class="PopupLable">
                                                <strong>Added on:</strong>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAddedOn" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                    </table>
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
