<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="SecureProctor.CourseAdmin.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <asp:HiddenField ID="hdValue" runat="server" />
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <div class="heading customfont1">
                <img src="../Images/Reports_new.png" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <table cellpadding="2" cellspacing="0" width="90%" style="margin:30px 0px">
                        <tr>

                            <td>
                                           
                                         <div  id="divTestSummaryReport" runat="server">
                                                

                                                        <a href="#" class="btn add gray_b"><span></span>Test Summary Report</a>
                                            </div>


                                       </td> 

                              <td>
                                           
                                         <div  id="divTestResultReport" runat="server">
                                               
                                                          <a href="#" class="btn add gray_b"><span></span>Test Result Report</a>
                                                      

                                            </div>



                                       </td> 

                                         <td>
                                           
                                         <div  id="div1" runat="server">
                                               
                                                          <a href="#" class="btn add gray_b"><span></span>Appointment Schedule Report</a>
                                                      

                                            </div>



                                       </td> 
                            <td  style="display:none;">
                                <div class="img_bg_home" id="divStudentScheduleExam" runat="server">
                                    <div>
                                        <div>
                                            <a href="#">
                                                <img src="../Images/ExamSummaryReport.png" /></a>
                                        </div>
                                        <%-- <ul class="tab_list">
                                                        <li>Exam Summary Report</li>
                                                    </ul>--%>
                                    </div>
                                </div>
                            </td>
                            <td  style="display:none;">
                                <div class="img_bg_home" id="divExamstatusreport" runat="server">
                                    <div>
                                        <div>
                                            <a href="#">
                                                <img src="../Images/ExamSummaryReport.png" /></a>
                                        </div>
                                     
                                    </div>
                                </div>
                            </td>
                       

                        </tr>

                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
