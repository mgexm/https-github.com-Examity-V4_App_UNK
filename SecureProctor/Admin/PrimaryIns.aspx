<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrimaryIns.aspx.cs" Inherits="SecureProctor.Admin.PrimaryIns" %>

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
                    Primary Instructor</div>
            </td>
        </tr>
        <tr id="trMessage" runat="server">
                <td align="center">
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
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                       
                        <tr id="trIsprimaryEdit" runat="server">
                            <td align="center" colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="2">
                                    <tr class="gridviewAlternatestyle">
                                        <td align="right" width="30%">
                                            <asp:CheckBox ID="chkPrimary" runat="server"  Checked='<%# Convert.ToBoolean(Eval("Status")) %>' OnCheckedChanged="chkPrimary_CheckedChanged" CausesValidation="false" />
                                        </td>
                                        <td class="PopupLable" width="70%">
                                          
                                            <asp:Label ID="lblPrimary" runat="server" Text="Is Primary Istructor"></asp:Label> 
                                        </td>
                                        
                                    </tr>
                                   
                                    <tr class="gridviewRowstyle" id="trUpdate" runat="server">
                                        <td align="left">
                                        </td>
                                        <td class="PopupButtons">
                                            <telerik:RadButton ID="btnUpdate" runat="server" Text="<%$ Resources:AppControls,Admin_EditCourse_Button_Update %>"
                                                OnClick="btnUpdate_Click" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                ValidationGroup="Edit" />
                                            <telerik:RadButton ID="btnBack" runat="server" Text="<%$ Resources:AppControls,Admin_EditCourse_Button_Cancel %>"
                                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false" OnClientClicked="close" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                       <%-- <tr id="trIsPrimaryView" runat="server">
                            <td align="center" colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="2">
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable" width="30%">
                                           <strong>Is Primary Istructor</strong>
                                        </td>
                                        <td align="left" width="70%">                                            
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </td>
                                    </tr>
                                                                    
                                </table>
                            </td>
                        </tr>--%>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>