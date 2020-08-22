<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TestSummaryReport.aspx.cs" Inherits="SecureProctor.Admin.TestSummaryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

     <telerik:RadWindowManager ID="RadWindowManager1" ir="rdM1" runat="server" Localization-Cancel="No" Localization-OK="Yes"></telerik:RadWindowManager>

              <asp:UpdateProgress id="UpdateProgress1" runat="server" associatedUpdatePanelID="up">
        <ProgressTemplate>
            <div  style="text-align: center; background-color: White; position: absolute;top: 50%;left: 50%; margin: -50px 0px 0px -50px;">
                   
                    <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="56"
                        Height="56" />
                </div>
        </ProgressTemplate>
                  </asp:UpdateProgress>

    <div class="heading_menu"><a href="AdminReports.aspx">Reports</a> <img src="../Images/arrowRight.png " width="18" /> Schedule status </div>
    <%--<div class="note">
        <p>This report provides the summary of scheduled and unscheduled appointments with a drill down of the details. </p>
    </div>--%>
     <div class="export_div">
             <div class="export_div_div">       
                 <asp:ImageButton ID="btnExportOptions" runat="server" ImageUrl="~/Images/email.png" CssClass="ImageButtons"  ToolTip="Email" Width="22" OnClick="btnExportOptions_Click" ValidationGroup="Reports" /> 
                 
                    &nbsp;&nbsp;    <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.png" CssClass="ImageButtons"  ToolTip="Export to XLS" Width="22" Height="22" OnClick="BtnExportToExcel_Click" ValidationGroup="Reports" />                                      
</div>
         </div> 

        <telerik:RadWindow ID="windowExportOptions"  runat="server" IconUrl="../Images/ExamityLock.png" Title="Send Email" Width="500px" Height="300px">
                            <ContentTemplate>
                                <div class="export_model">
                               
                                  <strong>Enter Email Address </strong><br /><br />
                                    <asp:TextBox placeholder="Enter e-mail ID" TextMode="MultiLine" ID="txtEmail" Width="200px" runat="server" CssClass="textBox medium" ClientIDMode="Static" ValidationGroup="SendMail" />
                                    <br />
                                    <span id="spanMultipleEmails">(To specify multiple addresses, separate the addresses with commas.)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" ErrorMessage="<br />Email cannot be empty!" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[\W]*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4}[\W]*,{1}[\W]*)*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4})[\W]*$" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" Display="Dynamic" ErrorMessage="<br />Invalid Email Format!" />
                                    <br />
                                    <br />
                                  
                                   
                                    <asp:Button ID="btnSendMail" ClientIDMode="Static" runat="server"  Width="150px" CssClass="button_new orange" Text="Send Mail" ValidationGroup="SendMail"  OnClick="btnSendMail_Click"/>

                                     </br>
                                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
    <asp:UpdatePanel ID="up" runat="server">

        <ContentTemplate>
    <div class="search">
         <table width="100%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td align="right" width="100">
                            <strong>Course Name&nbsp;:&nbsp;</strong>
               
                        </td>
                        <td align="left"  width="15%"  valign="top"><telerik:RadComboBox ID="rcbCourses" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="       --Select Course--       "
                            Width="150"  Localization-AllItemsCheckedString="All Courses selected" DropDownAutoWidth="Enabled" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged"  Filter="Contains" MarkFirstMatch="true" AutoCompleteSeparator=","  AutoPostBack="true">
                        </telerik:RadComboBox><br />
                             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="rcbCourses" ValidationGroup="Reports"
    Display="Dynamic" ErrorMessage="Please select a course" />
                        </td>
                       
                            
                        <td align="left"  valign="top">   <telerik:RadButton ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"
                                                Skin="Web20" ValidationGroup="Reports" /></td>
                         <td align="right"  valign="top">
          
        </td>
                    </tr>
                   
                   
                </table>
    </div>
    
    
            <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
               
            </td>
        </tr>
     
        <tr id="trGridView" runat="server">
            <td>
                <telerik:RadGrid ID="gvReports" runat="server"  OnNeedDataSource="gvReports_NeedDataSource" OnPageIndexChanged="gvReports_PageIndexChanged"                   
                    AllowPaging="True" AllowSorting="False" Skin="Web20" CellSpacing="0" GridLines="None"   LabelCssClass="SelectClient_text" PageSize="50" AutoGenerateColumns="false" OnItemCommand="gvReports_ItemCommand" OnPageSizeChanged="gvReports_PageSizeChanged" OnItemDataBound="gvReports_ItemDataBound">


                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" DataKeyNames="CourseID,ExamID"
                        CommandItemDisplay="None" NoMasterRecordsText="No records found">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                           
                            <telerik:GridBoundColumn DataField="CourseID" HeaderText="CourseID" Visible="false"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamID" HeaderText="ExamID" Visible="false"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Instructor Name" HeaderText="Instructor Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamStartDate" HeaderText="Exam Start Date [EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamEndDate" HeaderText="Exam End Date [EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"></telerik:GridBoundColumn>
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
       
      </ContentTemplate>
      
        
    </asp:UpdatePanel>
         
</asp:Content>
