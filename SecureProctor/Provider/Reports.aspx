<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="SecureProctor.Provider.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
      
    <div class="heading_menu">
                    <img src="../Images/Reports_new.png" />
                   </div>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <div class="Report_tab" style="margin-top:30px; padding-bottom:30px; ">
                        <ul>
                            <li>
          <div  id="divTestSummaryReport" runat="server"><a href="#" class="btn add gray_b"><span></span>Schedule status</a></div>
                            </li>
                            <li>
                                  <div  id="divAppointmentScheduleReport" runat="server"><a href="#" class="btn add gray_b"><span></span>Schedule details</a></div>
         
                            </li>
                            <li>
             <div  id="divTestResultReport" runat="server"><a href="#" class="btn add gray_b"><span></span>Exam status</a></div>
                            </li>
                            <li>
            <div id="Div2" runat="server" class="tab_report"><a href="QuestionSummaries.aspx" class="btn add gray_b"><span></span>Evaluations&nbsp;&nbsp;&nbsp;&nbsp;</a></div>
                            </li>
                        </ul>
                           <div class="clear"></div>
                    </div>
               
                    <table>
                        <tr>
                         <td style="display:none;">
                                            <div class="img_bg_home" id="divStudentScheduleExam" runat="server">
                                                <div >
                                                    <div >
                                                        <a href="#"><img src="../Images/ExamSummaryReport.png" /></a></div>
                                              
                                                </div>
                                            </div>
                                        </td>
                                        <td style="display:none;">
                                            <div class="img_bg_home" id="divExamstatusreport" runat="server">
                                                <div>
                                                    <div>
                                                        <a href="#"><img src="../Images/ExamSummaryReport.png" /></a></div>
                                                 
                                                </div>
                                            </div>
                                        </td></tr>
                    </table>
                    <div class="clear"></div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
