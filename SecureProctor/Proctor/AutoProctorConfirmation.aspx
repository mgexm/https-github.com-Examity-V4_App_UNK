<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true" CodeBehind="AutoProctorConfirmation.aspx.cs" Inherits="SecureProctor.Proctor.AutoProctorConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="Server">
    <script type="text/javascript">

        function printDiv(divName) {

            var DocumentContainer = document.getElementById(divName);

            var html = '<html><head>' +
            //                '<link href="../CSS/ApplicationStyleSheet.css" rel="stylesheet" type="text/css" />' +
                '</head><body style="background:#ffffff;">' +
               DocumentContainer.innerHTML +
               '</body></html>';

            var WindowObject = window.open("", "PrintWindow", "width=900,height=200,top=250,left=150,toolbars=no,scrollbars=yes,status=no,resizable=yes");
            WindowObject.document.writeln(html);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
            document.getElementById(divName).style.display = 'block';
        }



    </script>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table width="100%" cellpadding="0" cellspacing="0" style="font-family: Arial; font-size: 12px;">
                <tr style="font-size: 14px; line-height: 25px; color: #FFFFFF; vertical-align: middle;"
                    class="subHeadfont">
                    <td align="center" valign="bottom">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblHead" runat="server" Style="vertical-align: middle;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="2" cellspacing="3" width="100%" border="0" style="font-family: Arial;
                            font-size: 12px;">
                            <tr>
                                <td align="left" width="20%">
                                    &nbsp;&nbsp;&nbsp; <strong>Exam ID</strong>
                                </td>
                                <td align="left" width="20%">
                                    
                                    <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background: #ccc; line-height: 25px;">
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp; <strong>Student Name</strong>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background: #f6f6f6; line-height: 25px;">
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="lblcoursename" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background: #ccc; line-height: 25px;">
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp; <strong>Exam Name</strong>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="lblexamname" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background: #f6f6f6; line-height: 25px;">
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp; <strong>Exam Date</strong>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background: #ccc; line-height: 25px;">
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp; <strong>Exam Time </strong>
                                </td>
                                <td align="left">
                                    
                                    <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                </td>
                            </tr>
                          
                            <tr>
                                <td align="center" colspan="2">
                                    <telerik:RadButton ID="imgConfirm" runat="server" Text="APPROVE" Skin="Web20" Width="80"
                                        OnClick="Confirm_Click" Visible="false">
                                    </telerik:RadButton>
                                     <%-- <telerik:RadButton ID="btnReject"  Text="REJECT" runat="server" Skin="Web20" Width="80"
                                        OnClick="btnReject_Click"  Visible="false">
                                    </telerik:RadButton>--%>

                                    <telerik:RadButton ID="imgBack" runat="server" Text="BACK" Skin="Web20" Width="80"
                                        OnClick="back_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                  <telerik:RadButton ID="btnInbox" runat="server" Text="Inbox" Skin="Web20" Width="80"
                                        OnClick="Inbox_Click" Visible="false">
                                    </telerik:RadButton>
                                     <img id="img" runat="server" src="../Images/ImgSuccessAlert.png" width="30" height="30"
                                        alt="Success" style="vertical-align: middle;" />
                                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
