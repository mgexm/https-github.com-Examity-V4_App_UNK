<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true" CodeBehind="ReportsView.aspx.cs" Inherits="SecureProctor.Proctor.ReportsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">

        <table width="100%" cellpadding="2" cellspacing="2" >
            <tr>
                             <td >
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
                                                Width="22" Height="22" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="BtnExportToPdf" runat="server" ImageUrl="~/Images/pdf.jpeg"
                                                CssClass="ImageButtons" OnClick="BtnExportToPdf_Click" ToolTip="Export to PDF"
                                                Width="22" Height="22" />
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
                        </tr>
        </table>
</asp:Content>
