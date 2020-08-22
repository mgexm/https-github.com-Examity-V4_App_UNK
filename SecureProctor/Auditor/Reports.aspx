<%@ Page Title="" Language="C#" MasterPageFile="~/Auditor/Auditor.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="SecureProctor.Auditor.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AuditorContent" runat="server">
    <asp:HiddenField ID="hdValue" runat="server" />
    <div class="heading_menu">
                    <img src="../Images/Reports_new.png" />
                   </div>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <div class="reports_admin">
                         <div  id="divTestSummaryReport" runat="server" class="tab_report" >
                                                        <a href="#" class="btn add gray_b"><span></span>Schedule status</a>
                                            </div>
                         <div  id="divAppointmentScheduleReport" runat="server"  class="tab_report">
                                                          <a href="#" class="btn add gray_b"><span></span>Schedule details</a>
                                            </div>
                        <div  id="divTestResultReport" runat="server"  class="tab_report">
                                                          <a href="#" class="btn add gray_b"><span></span>Exam status</a>
                                            </div>
                       
    
                    </div>       
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
