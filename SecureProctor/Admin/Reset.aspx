<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="SecureProctor.Admin.Reset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
    <asp:UpdatePanel ID="uplReset" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <%--<table><tr><td><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr></table>--%>
     <table align="center" cellpadding="3" cellspacing="4" width="100%" border="0">

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

    <tr class="gridviewRowstyle">
    
    <td class="PopupLable" width="30%">
    <strong> <%= Resources.AppControls.Admin_Reset_Label_EmailAddress%> </strong> 
     
    </td>

    <td align="left" width="70%">
    
    <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
    
    </td>
    
    
    </tr>

    <tr align="center" class="gridviewAlternatestyle">
    
    <td colspan="3" class="PopupButtons">
    
    <telerik:RadButton ID="btnReset" runat="server" Text="<%$ Resources:AppControls,Admin_Reset_Button_Reset%>" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnReset_Click">
                        </telerik:RadButton></td></tr>
    
    </table>
    </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="btnReset" EventName="Click" />
  </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
