<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminReports.aspx.cs" Inherits="SecureProctor.Admin.AdminReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    
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
                    <div class="reports_admin">
                         <div id="Div1" runat="server" class="tab_report">
                        <a href="QuestionSummaries.aspx" class="btn add gray_b">
                            <span></span>Evaluations</a>
                                            </div>
                          <div id="DivLaunch" runat="server" class="tab_report">
                        <a href="LaunchTimeReport.aspx" class="btn add gray_b">
                            <span></span>Launch time</a>
                                            </div>

                   
                   
                       
                </div>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>