<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProctor.aspx.cs" Inherits="SecureProctor.Proctor.EditProctor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">

        function close() {

            window.close();

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager2" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
        </telerik:RadScriptManager>
       <table cellpadding="5" cellspacing="5" width="100%" border="0">
        <tr>
            <td>
                <div class="heading customfont1">
                   Edit Proctor</div>
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
                        <tr id="trAddProctor" runat="server">
                            <td colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="2">
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                               Proctor Name</strong>
                                        </td>
                                        <td align="left" width="70%">
                                           <telerik:RadComboBox ID="ddlProctorName" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                            </telerik:RadComboBox>
                                            <br />
                                           
                                        </td>
                                    </tr>
                                    
                                    
                                    <tr class="gridviewAlternatestyle">
                                        <td align="left">
                                        </td>
                                        <td class="PopupButtons">
                                            <telerik:RadButton ID="btnAdd" runat="server" Text="Save"
                                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnSave_Click">
                                            </telerik:RadButton>
                                            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel"
                                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                                OnClientClicked="close">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trViewProctor" runat="server">
                            <td colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="2">
                                    
                                    
                                    <tr class="gridviewRowstyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                               Proctor Name</strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <asp:Label ID="lblProctorName" runat="server"></asp:Label>
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
