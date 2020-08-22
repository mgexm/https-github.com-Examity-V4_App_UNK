<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="TestSummaryReport.aspx.cs" Inherits="SecureProctor.CourseAdmin.TestSummaryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
 <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <table width="100%" cellpadding="5" cellspacing="5">
                    <tr id="trSearchCriteria1" runat="server" visible="true">
                        <td align="left" width="100">
                            <strong>Course Name&nbsp;:&nbsp;</strong>
               
                        </td>
                        <td align="left"  width="10%"><telerik:RadComboBox ID="rcbCourses" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="       --Select Course--       "
                            Width="150"  LabelCssClass="SelectClient_text" Localization-AllItemsCheckedString="All Courses selected" DropDownAutoWidth="Enabled" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged"  Filter="StartsWith" MarkFirstMatch="true" AutoCompleteSeparator="," >
                        </telerik:RadComboBox>
                        </td>
                            
                        <td align="left">   <telerik:RadButton ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"
                                                Skin="Web20" ValidationGroup="Reports" /></td>
                         <td align="right">
            <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.jpeg" CssClass="ImageButtons"  ToolTip="Export to XLS" Width="22" Height="22" OnClick="BtnExportToExcel_Click" ValidationGroup="Reports" />                                      
        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td><td>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="rcbCourses" ValidationGroup="Reports"
    Display="Dynamic" ErrorMessage="Please select a course" />
                        </td><td colspan="2">&nbsp;</td></tr>
                   
                </table>
            </td>
        </tr>
     
        <tr id="trGridView" runat="server">
            <td>
                <telerik:RadGrid ID="gvReports" runat="server"  OnNeedDataSource="gvReports_NeedDataSource" OnPageIndexChanged="gvReports_PageIndexChanged"                   
                    AllowPaging="True" AllowSorting="False" Skin="Web20" CellSpacing="0" GridLines="None"  PageSize="50" AutoGenerateColumns="false" OnItemCommand="gvReports_ItemCommand" OnPageSizeChanged="gvReports_PageSizeChanged" OnItemDataBound="gvReports_ItemDataBound">
                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" DataKeyNames="CourseID,ExamID"
                        CommandItemDisplay="None" NoMasterRecordsText="No records found">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="CourseID" HeaderText="CourseID" Visible="false"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamID" HeaderText="ExamID" Visible="false"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Instructor Name" HeaderText="Instructor Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamStartDate" HeaderText="Exam Start Date[EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamEndDate" HeaderText="Exam End Date[EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentsEnrolled" HeaderText="Total Students"></telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn HeaderText="Scheduled Appointments" HeaderStyle-HorizontalAlign="Center" DataField="ScheduledAppointments" SortExpression="ScheduledAppointments" >
                                <ItemTemplate>                                   
                                    
                                    <asp:LinkButton ID="hplnkScheduledAppointments" runat="server" Text='<%#Eval("ScheduledAppointments") %>' Font-Underline="true"   CommandName="scheduled" CommandArgument='<%#Eval("CourseID")+","+Eval("ExamID") %>' OnClick="hplnkScheduledAppointments_Click"   ></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Unscheduled Appointments" HeaderStyle-HorizontalAlign="Center" DataField="Unscheduledappointments" SortExpression="Unscheduledappointments">
                                <ItemTemplate>                                    
                                    <asp:LinkButton ID="hplnkUnScheduledAppointments" runat="server" Text='<%#Eval("Unscheduledappointments") %>' Font-Underline="true" CommandName="unscheduled" CommandArgument='<%#Eval("CourseID")+","+Eval("ExamID") %>' OnClick="hplnkUnScheduledAppointments_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
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
