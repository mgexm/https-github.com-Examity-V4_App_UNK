<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteExam.aspx.cs" Inherits="SecureProctor.Provider.DeleteExam" %>

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
                    <%=Resources.AppControls.Provider_DeleteExam_Label_DeleteExam%>
                </div>
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
                        <tr class="gridviewRowstyle">
                            <td width="40%"class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblExam" runat="server" Text="<%$ Resources:AppControls,Provider_DeleteExam_Label_ExamName %>"></asp:Label></strong>
                            </td>
                            <td width="50%" align="left">
                                <asp:Label ID="lblExamName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblStatus" Text="<%$ Resources:AppControls,Provider_DeleteExam_Label_ExamStatus %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">                              
                                <asp:Label ID="lblStatusValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle" id="trUpdate" runat="server">
                            <td class="PopupButtons1" colspan="3">
                                <telerik:RadButton ID="btnSave" runat="server" Text="<%$ Resources:AppControls,Provider_DeleteExam_Button_Update %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnSave_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Provider_DeleteExam_Button_Cancel %>"
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
