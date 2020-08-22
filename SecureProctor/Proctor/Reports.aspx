<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="SecureProctor.Proctor.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
    <asp:HiddenField ID="hdValue" runat="server" />
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                   <img src="../Images/Reports_new.png" alt="Proctor Reports" />
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="2" cellspacing="2">
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="0" width="100%" align="center">
                                    <tr>
                                        <td width="25%" align="center">
                                            <div class="img_bg_home" id="divExamstatusreport" runat="server">
                                                <div>
                                                    <div>
                                                        <a href="#"><img src="../Images/ExamStatusReport.png" /></a></div>
                                                   <%-- <ul class="tab_list">
                                                        <li>Exam status report</li>
                                                    </ul>--%>
                                                </div>
                                            </div>
                                        </td>
                                         <td width="25%">&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                      <%--  <td>
                                            <div class="tab_s" id="divCompletedexamsreport" runat="server">
                                                <div class="tab_inner">
                                                    <div class="customfont2_report">
                                                        <a href="#">Completed exams report</a>
                                                    </div>
                                                    <ul class="tab_list">
                                                        <li>Completed exams report</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="tab_s" id="divUnattendedexamsreport" runat="server">
                                                <div class="tab_inner">
                                                    <div class="customfont2_report">
                                                        <a href="#">Unattended exams report</a></div>
                                                    <ul class="tab_list">
                                                        <li>Unattended exams report</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="tab_s" id="divCancelledexamsreport" runat="server">
                                                <div class="tab_inner">
                                                    <div class="customfont2_report">
                                                        <a href="#">Cancelled exams report</a></div>
                                                    <ul class="tab_list">
                                                        <li>Cancelled exams report</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>--%>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <div class="tab_s" id="divIncompleteexamsreport" runat="server">
                                                <div class="tab_inner">
                                                    <div class="customfont2_report">
                                                        <a href="#">Incomplete exams report</a></div>
                                                    <ul class="tab_list">
                                                        <li>Incomplete exams report</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="tab_s" id="divViolationsdetailreport" runat="server">
                                                <div class="tab_inner">
                                                    <div class="customfont2_report">
                                                        <a href="#">Violations detail report</a></div>
                                                    <ul class="tab_list">
                                                        <li>Violations detail report</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="tab_s" id="divViolationssummaryreport" runat="server">
                                                <div class="tab_inner">
                                                    <div class="customfont2_report">
                                                        <a href="#">Violations summary report</a></div>
                                                    <ul class="tab_list">
                                                        <li>Violations summary report</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                      <%--  <tr>
                            <td width="100%">
                                <table width="100%" cellpadding="5" cellspacing="5">
                                    <tr id="trSearchCriteria1" runat="server" visible="false">
                                        <td align="left">
                                            <strong>Exam Start Date&nbsp;:&nbsp;</strong>
                                            <telerik:RadDatePicker ID="dtpstartdate" runat="server" Skin="Web20">
                                                <Calendar ID="clStartDate" runat="server" EnableKeyboardNavigation="true" Skin="Web20">
                                                </Calendar>
                                                <DateInput ID="DateInput1" runat="server" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy"
                                                    LabelWidth="40%" Skin="Web20">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                            &nbsp;&nbsp; <strong>Exam End Date&nbsp;:&nbsp;</strong>
                                            <telerik:RadDatePicker ID="dtpEnddate" runat="server" Skin="Web20">
                                                <Calendar ID="clEndDate" runat="server" EnableKeyboardNavigation="true" Skin="Web20">
                                                </Calendar>
                                                <DateInput ID="DateInput2" runat="server" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy"
                                                    LabelWidth="40%" Skin="Web20">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                            &nbsp;&nbsp;
                                            <telerik:RadButton ID="btnReports" runat="server" Text="Search" OnClick="btnReports_Click"
                                                Skin="Web20" ValidationGroup="Reports" />
                                            &nbsp;&nbsp;
                                            <asp:CompareValidator ID="cvStartDate" runat="server" ControlToCompare="dtpEnddate"
                                                CultureInvariantValues="true" Operator="LessThanEqual" Display="Dynamic" ControlToValidate="dtpstartdate"
                                                ErrorMessage="End Date Must be Greater than Start Date" Type="Date" SetFocusOnError="true"
                                                ForeColor="Red" ValidationGroup="Reports" />
                                        </td>
                                    </tr>
                                    <tr id="trSearchCriteria2" runat="server" visible="false">
                                        <td align="left">
                                            <strong>Course Name&nbsp;:&nbsp;</strong>
                                            <telerik:RadTextBox ID="txtCourseName" runat="server" CssClass="td_input" Skin="Web20"
                                                Width="150">
                                            </telerik:RadTextBox>
                                            &nbsp;&nbsp; <strong>Exam Name&nbsp;:&nbsp;</strong>
                                            <telerik:RadTextBox ID="txtExamName" runat="server" CssClass="td_input" Skin="Web20"
                                                Width="150">
                                            </telerik:RadTextBox>
                                            &nbsp;&nbsp; <strong>First Name&nbsp;:&nbsp;</strong>
                                            <telerik:RadTextBox ID="txtFirstName" runat="server" CssClass="td_input" Skin="Web20"
                                                Width="150">
                                            </telerik:RadTextBox>
                                            &nbsp;&nbsp; <strong>Last Name&nbsp;:&nbsp;</strong>
                                            <telerik:RadTextBox ID="txtLastName" runat="server" CssClass="td_input" Skin="Web20"
                                                Width="150">
                                            </telerik:RadTextBox>
                                            &nbsp;&nbsp;
                                            <telerik:RadButton ID="btnReports1" runat="server" Text="Search" OnClick="btnReports_Click"
                                                Skin="Web20" />
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trExportButtons" runat="server">
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.jpeg"
                                                CssClass="ImageButtons" OnClick="BtnExportToExcel_Click" ToolTip="Export to XLS"
                                                Width="32" Height="32" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="BtnExportToPdf" runat="server" ImageUrl="~/Images/pdf.jpeg"
                                                CssClass="ImageButtons" OnClick="BtnExportToPdf_Click" ToolTip="Export to PDF"
                                                Width="32" Height="32" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trGridView" runat="server">
                            <td>
                                <telerik:RadGrid ID="gvReports" runat="server" OnNeedDataSource="gvReports_NeedDataSource"
                                    AllowPaging="True" AllowSorting="True" Skin="Web20" CellSpacing="0" GridLines="None">
                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                        CommandItemDisplay="None" NoMasterRecordsText="No records found">
                                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                        <NoRecordsTemplate>
                                            <table width="100%" cellpadding="2" cellspacing="2">
                                                <tr>
                                                    <td align="center">
                                                        No records found
                                                    </td>
                                                </tr>
                                            </table>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <AlternatingItemStyle HorizontalAlign="Center" />
                                    <GroupingSettings CaseSensitive="false" />
                                    <ExportSettings Pdf-PageWidth="1500">
                                    </ExportSettings>
                                </telerik:RadGrid>
                            </td>
                        </tr>--%>
                  </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>