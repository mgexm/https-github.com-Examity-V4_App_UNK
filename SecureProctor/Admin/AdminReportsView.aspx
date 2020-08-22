<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminReportsView.aspx.cs" Inherits="SecureProctor.Admin.AdminReportsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
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
                    <tr id="trSearchCriteria3" runat="server" visible="false">
                        <td align="left">
                            <strong>Billing Month&nbsp;:&nbsp;</strong>
                            <telerik:RadComboBox ID="ddlMonths" runat="server"
                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="200">
                                <Items>
                                    <telerik:RadComboBoxItem Text="-- Select Month --" Value="0" />
                                    <telerik:RadComboBoxItem Text="January" Value="1" />
                                    <telerik:RadComboBoxItem Text="February" Value="2" />
                                    <telerik:RadComboBoxItem Text="March" Value="3" />
                                    <telerik:RadComboBoxItem Text="April" Value="4" />
                                    <telerik:RadComboBoxItem Text="May" Value="5" />
                                    <telerik:RadComboBoxItem Text="June" Value="6" />
                                    <telerik:RadComboBoxItem Text="July" Value="7" />
                                    <telerik:RadComboBoxItem Text="August" Value="8" />
                                    <telerik:RadComboBoxItem Text="September" Value="9" />
                                    <telerik:RadComboBoxItem Text="October" Value="10" />
                                    <telerik:RadComboBoxItem Text="November" Value="11" />
                                    <telerik:RadComboBoxItem Text="December" Value="12" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp; <strong>Billing Year&nbsp;:&nbsp;</strong>
                            <telerik:RadComboBox ID="ddlYear" runat="server"
                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="150">
                                <Items>
                                    <telerik:RadComboBoxItem Text="-- Select Year --" Value="0" />
                                    <telerik:RadComboBoxItem Text="2013" Value="1" />
                                    <telerik:RadComboBoxItem Text="2014" Value="2" />
                                    <telerik:RadComboBoxItem Text="2015" Value="3" />
                                    <telerik:RadComboBoxItem Text="2016" Value="4" />
                                    <telerik:RadComboBoxItem Text="2017" Value="5" />
                                    <telerik:RadComboBoxItem Text="2018" Value="6" />
                                </Items>
                            </telerik:RadComboBox>

                            &nbsp;&nbsp;
                                            <telerik:RadButton ID="btnReports2" runat="server" Text="Search" OnClick="btnReports_Click"
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
                        <td align="left">&nbsp;
                        </td>
                        <td align="right">
                            <asp:Button ID="btnInvoice" runat="server" Text="Invoice" OnClick="GenerateReport" CssClass="button_new blue"  ToolTip="Generate Invoice" Style="vertical-align:top;" />&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.jpeg"
                                CssClass="ImageButtons" OnClick="BtnExportToExcel_Click" ToolTip="Export to XLS"
                                Width="22" Height="22" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="BtnExportToPdf" Visible="false" runat="server" ImageUrl="~/Images/pdf.jpeg"
                                                CssClass="ImageButtons" OnClick="BtnExportToPdf_Click" ToolTip="Export to PDF"
                                                Width="22" Height="22" />
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table width="1000px" cellspacing="0" cellpadding="4">
                                <tr id="trexamfee" runat="server">
                                    <td colspan="1" align="left" width="120px"><strong>Total no. of records :</strong>  </td>
                                    <td align="left" colspan="1" width="50px">
                                        <asp:Label ID="lblRecords" runat="server" /></td>
                                    <td id="tdexamfeelabel" runat="server" colspan="1" align="left" width="160px"><strong><asp:Label ID="lblexamfeetitle" runat="server" Text="Total Exam Fee :" /></strong></td>
                                    <td id="tdexamfee" runat="server" colspan="1" width="80px">
                                        <asp:Label ID="lblExamFee" runat="server" /></td>
                                    <td id="tdondemandfeelabel" runat="server" colspan="1" width="190px"><strong><asp:Label ID="lblondemandtitle" runat="server" Text="Total On-demand Fee :" /></strong></td>
                                    <td id="tdondemandfee" runat="server" colspan="1" width="70px">
                                        <asp:Label ID="lblOnDemandFee" runat="server" /></td>
                                    <td id="tdtotalfeelabel" runat="server" colspan="1" width="165px"><strong><asp:Label ID="lbltotalfeetitle" runat="server" Text="Total Fee :" /></strong></td>
                                    <td id="tdtotalfee" runat="server" colspan="1" width="80px">
                                        <asp:Label ID="lblTotalFee" runat="server" /></td>
                                </tr>
                                <%--<tr id="trondemandfee" runat="server">
                                    <td><strong>Total On-demand Fee :</strong></td>
                                    <td>
                                        <asp:Label ID="lblOnDemandFee" runat="server" /></td>
                                    <td><strong>Total Fee :</strong></td>
                                    <td>
                                        <asp:Label ID="lblTotalFee" runat="server" /></td>
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trGridView" runat="server">
            <td>
                <telerik:RadGrid ID="gvReports" runat="server" OnNeedDataSource="gvReports_NeedDataSource"
                    AllowPaging="True" AllowSorting="True" Skin="Web20" CellSpacing="0" GridLines="None" OnItemDataBound="gvReports_ItemDataBound" PageSize="50">
                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                        CommandItemDisplay="None" NoMasterRecordsText="No records found">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <NoRecordsTemplate>
                            <table width="100%" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td align="center">No records found
                                    </td>
                                </tr>
                            </table>
                        </NoRecordsTemplate>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column" Created="True"></ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterItemStyle BackColor="#DCEDFD"></FilterItemStyle>
                    </MasterTableView>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <AlternatingItemStyle HorizontalAlign="Center" />
                    <GroupingSettings CaseSensitive="false" />
                    <ExportSettings Pdf-PageWidth="1500">
<Pdf PageWidth="1500px"></Pdf>
                    </ExportSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
