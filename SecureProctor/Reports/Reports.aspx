<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="SecureProctor.Reports.Reports1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgReports1.png" alt="reports" />
                    </td>
                    <td width="1%" rowspan="4">
                    </td>
                    <td>
                        <img src="../Images/Imghelp.png" alt="help" />
                    </td>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                    <td align="right" width="20%">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date :" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="left" width="30%">
                                        &nbsp;&nbsp;<telerik:RadDatePicker ID="txtStartDate" runat="server" Skin="Web20">
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
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date :" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="left" width="30%" valign="middle">
                                        &nbsp;&nbsp;<telerik:RadDatePicker ID="txtEndDate" runat="server" Skin="Web20">
                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Web20">
                                            </Calendar>
                                            <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                            </DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                    <td align="right" width="20%">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" Text="Exam Status :" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="left" width="30%">
                                        &nbsp;&nbsp;<telerik:RadComboBox ID="ddlExam" runat="server" Width="150px" AppendDataBoundItems="true"
                                            Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="0" Text="All" />
                                                <telerik:RadComboBoxItem Value="1" Text="Scheduled" />
                                                <telerik:RadComboBoxItem Value="2" Text="In progress" />
                                                <telerik:RadComboBoxItem Value="3" Text="Completed" />
                                                <telerik:RadComboBoxItem Value="4" Text="Cancelled" />
                                                <telerik:RadComboBoxItem Value="5" Text="Approved By Proctor" />
                                                <telerik:RadComboBoxItem Value="6" Text="Approved By Auditor" />
                                                <telerik:RadComboBoxItem Value="7" Text="Rejected By Auditor" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle" style="height: 30px;">
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                    <td colspan="2" align="center">
                                        &nbsp;&nbsp;<telerik:RadButton ID="btnSearch" runat="server" Text="Generate Report" Skin="Web20"
                                            Width="150px" OnClick="btnSearch_Click">
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
                    <td width="29%" rowspan="3" valign="top" class="help_text_i">
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
    <table>
        <tr>
            <td><b>Download Online Reports</b></td>
        </tr>
        <tr>
            <td>
                <ol>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkGetStudentReport" Text="Get Student Report" ForeColor="Blue" OnClick="lnkGetStudentReport_Click"  ToolTip="Gets all the pending students data"></asp:LinkButton></li> <br />
                    <li>
                        <asp:LinkButton runat="server" ID="lnkGetExamStatusReport" Text="Get Exam Status Report" ForeColor="Blue" OnClick="lnkGetExamStatusReport_Click" ToolTip="Gets all the Exam Data"></asp:LinkButton></li> <br />                       
                    <li>
                        <asp:LinkButton runat="server" ID="lnkGetStudentviolationReport" Text="Get Student violation Report" ForeColor="Blue" OnClick="lnkGetStudentviolationReport_Click" ToolTip="Gets all the students data with violation comments"></asp:LinkButton></li><br />
                </ol>
                 <%--<asp:Calendar ID="cal" runat="server"></asp:Calendar>--%>
            </td>
        </tr>
        <tr>
            <td>
               <%-- Get Student Data by Exam Date (MM/DD/YYYY)--%>
            </td>
            <td>
                <%--<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>--%>
            </td>
            
        </tr>
        <tr><td><asp:Label ID="lblMSG" runat="server" Text=""></asp:Label></td></tr>

       
    </table>
</asp:Content>
