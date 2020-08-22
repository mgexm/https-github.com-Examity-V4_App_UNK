<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="TestResultReport.aspx.cs" Inherits="SecureProctor.CourseAdmin.TestResultReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
 <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <table width="100%" cellpadding="5" cellspacing="5">
                    <tr id="trSearchCriteria1" runat="server" visible="true">
                         <td width="20%" align="left"> <strong>From : </strong>
                                    <telerik:RadDatePicker  DateInput-ReadOnly="true" ID="txtFromDate" runat="server" Width="120" Skin="Web20"></telerik:RadDatePicker>
                                    &nbsp;&nbsp;</td>
                         <td width="20%" align="left"> <strong>To :</strong>
            <telerik:RadDatePicker  DateInput-ReadOnly="true" ID="txtToDate" runat="server" Width="120" Skin="Web20">
            </telerik:RadDatePicker>
                                </td>

                        <td align="left" width="10%">
                            <strong>Course Name&nbsp;:&nbsp;</strong>
               
                        </td>
                        <td align="left"  width="20%">
                             <telerik:RadComboBox ID="rcbCourses" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="       --Select Course--       "
                            Width="150"   Localization-AllItemsCheckedString="All Courses selected" DropDownAutoWidth="Enabled"   Filter="StartsWith" MarkFirstMatch="true" AutoCompleteSeparator="," >
                        </telerik:RadComboBox>
                        </td>
                            
                        <td align="left">   <telerik:RadButton ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"
                                                Skin="Web20" ValidationGroup="Reports" /></td>
                         <td align="right">
            <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.jpeg" CssClass="ImageButtons"  ToolTip="Export to XLS" Width="22" Height="22" OnClick="BtnExportToExcel_Click" ValidationGroup="Reports" />                                      
        </td>
                    </tr>
                    
                   
                </table>
            </td>
        </tr>
     
        <tr id="trGridView" runat="server">
            <td>
                <telerik:RadGrid ID="gvReports" runat="server"  OnNeedDataSource="gvReports_NeedDataSource" OnPageIndexChanged="gvReports_PageIndexChanged"                   
                    AllowPaging="True" AllowSorting="False" Skin="Web20" CellSpacing="0" GridLines="None"  PageSize="50" AutoGenerateColumns="false" OnItemCommand="gvReports_ItemCommand" OnPageSizeChanged="gvReports_PageSizeChanged" OnItemDataBound="gvReports_ItemDataBound">
                   
                    <ClientSettings Scrolling-AllowScroll="true">

                        
                    </ClientSettings>
                    
                     <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" DataKeyNames="CourseID,ExamID"
                        CommandItemDisplay="None" NoMasterRecordsText="No records found" Height="70%">
                       
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        
                        <Columns>
                        
                            <telerik:GridBoundColumn DataField="ExamID" HeaderText="ExamID"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentFirstName" HeaderText="Student First Name"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="StudentLastName" HeaderText="Student Last Name"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="Email Address"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InstructorName" HeaderText="Instructor Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AppointmentCreationDate" HeaderText="Appointment Creation Date[EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AppointmentDate" HeaderText="Appointment Date[EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamDuration" HeaderText="Exam Duration"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="FairExamLevel" HeaderText="<%$ Resources:ResMessages,Common_FairExamLevel%>"></telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="StatusName" HeaderText="Status"></telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Alert" HeaderText="<img src='../Images/ImgAlert.png' alt='my image' />"
                                                            SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>

                                                           <telerik:GridBoundColumn DataField="Green" HeaderText="<img src='../Images/flag_g.png' alt='my image' />"
                                                            SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center"/>
                                                            <HeaderStyle Font-Bold="true" /> 
                                                        </telerik:GridBoundColumn>

                                                       
                                                        <telerik:GridBoundColumn DataField="Orange" HeaderText="<img src='../Images/flag_y.png' alt='my image' />"
                                                            SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center"/>
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>

                                                      


                                                        <telerik:GridBoundColumn DataField="Red" HeaderText="<img src='../Images/flag.png' alt='my image' />"
                                                            SortExpression="Red" UniqueName="Red" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center"  />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>

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


