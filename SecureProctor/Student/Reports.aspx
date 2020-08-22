<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="SecureProctor.Student.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script language="javascript" type="text/javascript">
        function validateFields(txtStart, txtEnd) {
            if (document.getElementById(txtStart).value.length != 0) {
                if (!isDate(document.getElementById(txtStart).value)) {
                    alert("Please select the valid start date [MM/DD/YYYY]");
                    return false;
                }
            }
            if (document.getElementById(txtEnd).value.length != 0) {
                if (!isDate(document.getElementById(txtEnd).value) == 'false') {
                    alert("Please select the valid start date [MM/DD/YYYY]");
                    return false;
                }
            }
            return true;
        }
        function isDate(value) {
            try {
                //Change the below values to determine which format of date you wish to check. It is set to dd/mm/yyyy by default.
                var DayIndex = 1;
                var MonthIndex = 0;
                var YearIndex = 2;

                value = value.replace(/-/g, "/").replace(/\./g, "/");
                var SplitValue = value.split("/");
                var OK = true;
                if (!(SplitValue[DayIndex].length == 1 || SplitValue[DayIndex].length == 2)) {
                    OK = false;
                }
                if (OK && !(SplitValue[MonthIndex].length == 1 || SplitValue[MonthIndex].length == 2)) {
                    OK = false;
                }
                if (OK && SplitValue[YearIndex].length != 4) {
                    OK = false;
                }
                if (OK) {
                    var Day = parseInt(SplitValue[DayIndex], 10);
                    var Month = parseInt(SplitValue[MonthIndex], 10);
                    var Year = parseInt(SplitValue[YearIndex], 10);

                    if (OK = ((Year > 1900) && (Year <= new Date().getFullYear()))) {
                        if (OK = (Month <= 12 && Month > 0)) {
                            var LeapYear = (((Year % 4) == 0) && ((Year % 100) != 0) || ((Year % 400) == 0));

                            if (Month == 2) {
                                OK = LeapYear ? Day <= 29 : Day <= 28;
                            }
                            else {
                                if ((Month == 4) || (Month == 6) || (Month == 9) || (Month == 11)) {
                                    OK = (Day > 0 && Day <= 30);
                                }
                                else {
                                    OK = (Day > 0 && Day <= 31);
                                }
                            }
                        }
                    }
                }
                return OK;
            }
            catch (e) {
                return false;
            }
        }
    </script>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgReports1.png" />
                    </td>
                    <td width="1%" rowspan="3">
                    </td>
                    <%--<td>
                        <img src="../Images/Imghelp.png" alt="help" />
                    </td>--%>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSuccess" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                    <td align="right" width="20%">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="left" width="30%">
                                        : &nbsp;&nbsp;<telerik:RadDatePicker ID="txtStartDate" runat="server" Skin="Web20">
                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Web20">
                                            </Calendar>
                                            <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                            </DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle" style="height: 35px;">
                                    <td align="right" width="20%">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date " Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="left" width="30%" valign="middle">
                                        : &nbsp;&nbsp;<telerik:RadDatePicker ID="txtEndDate" runat="server" Skin="Web20">
                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Web20">
                                            </Calendar>
                                            <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                            </DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:RadDatePicker>
                                        <asp:CompareValidator ID="dateCompareValidator" runat="server" ControlToValidate="txtEndDate"
                                            ControlToCompare="txtStartDate" Operator="GreaterThan" Type="Date" ErrorMessage="The second date must be after the first one.">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                    <td align="right" width="20%">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" Text="Exam Status" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="left" width="30%">
                                        : &nbsp;&nbsp;<telerik:RadComboBox ID="ddlExam" runat="server" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="All" Value="0" />
                                                <telerik:RadComboBoxItem Text="Scheduled" Value="1" />
                                                <telerik:RadComboBoxItem Text="In progress" Value="2" />
                                                <telerik:RadComboBoxItem Text="Completed" Value="3" />
                                                <telerik:RadComboBoxItem Text="Cancelled" Value="4" />
                                                <telerik:RadComboBoxItem Text="Approved By Proctor" Value="5" />
                                                <telerik:RadComboBoxItem Text="Approved By Auditor" Value="6" />
                                                <telerik:RadComboBoxItem Text="Rejected By Auditor" Value="7" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle" style="height: 35px;">
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                    <td colspan="2" align="center">
                                        <telerik:RadButton ID="btnSearch" runat="server" Text="Generate Report" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                            Width="100" OnClick="btnSearch_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p>
                                            &nbsp;</p>
                                        <p>
                                            &nbsp;</p>
                                        <p>
                                            &nbsp;</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td width="25%" rowspan="3" valign="top" class="help_text_i">
                        <div class="help_text_i_inner">
                            <ul>
                                <li>A report can be generated by giving specified date range for a selected exam status.</li><br />
                                <br />
                                <li>Any option can be selected from the exam status dropdown to generate a report specific
                                    to the exam status.</li><br />
                                <br />
                            </ul>
                            <p>
                                &nbsp;</p>
                            <p>
                                &nbsp;</p>
                            <p>
                                &nbsp;</p>
                            <p>
                                &nbsp;</p>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
