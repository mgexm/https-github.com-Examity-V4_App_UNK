<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAppointment.aspx.cs" Inherits="SecureProctor.Student.NewAppointment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <title>Schedule Exam</title>
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
        <div class="login_new1">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="padding-left: 20px; padding-top: 20px;">
                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                            <tr class="gridviewAlternatestyle">
                                <td width="30%" class="PopupLable">
                                    <strong>Course Name</strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td width="30%" class="PopupLable">
                                    <strong>Exam Name</strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td width="30%" class="PopupLable">
                                    <strong>Exam Duration</strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblDuration" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td width="30%" class="PopupLable">
                                    <strong>Exam Slot</strong>&nbsp;:&nbsp;
                                </td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td align="left"></td>
                                <td class="PopupButtons">
                                    <telerik:RadButton ID="btnSchedule" runat="server" Text="Confirm"
                                        Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnSchedule_Click"> 
                                    </telerik:RadButton>&nbsp;&nbsp;
                                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel"
                                        Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                        OnClientClicked="close">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
