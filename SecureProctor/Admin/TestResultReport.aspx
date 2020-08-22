<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TestResultReport.aspx.cs" Inherits="SecureProctor.Admin.TestResultReport" %>




<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

    <script type="text/javascript">

        function ValidateCourseAndExam(ddlCourse, ddlExam) {
            debugger
            var ddlCourse = $find(ddlCourse);
            var ddlExams = $find(ddlExam);
            var items = ddlCourse.get_items();
            var Examitems = ddlExams.get_items();
            var checked = 0;
            var Examchecked = 0;
            for (var i = 0; i < ddlCourse.get_items().get_count() ; i++) {
                if (items._array[i].get_checked()) {
                    checked = 1;
                    break;
                }
            }
            if (checked == 0) {
                alert("Please select Course");
                return false;
            }

            if (ddlCourse.get_checkedItems().length == 1) {

                for (var i = 0; i < ddlExams.get_items().get_count() ; i++) {
                    if (Examitems._array[i].get_checked()) {
                        Examchecked = 1;

                        break;

                        return true;
                    }
                }

                if (Examchecked == 0) {
                    alert("Please select Exam");
                    return false;
                }

            }





            return true;


        }

        function postbackrcbCourses(sender, args) {

            __doPostBack("<%=rcbCourses.UniqueID%>", '');


        }

        function GridCreated(sender, args) {
            var scrollArea = sender.GridDataDiv;
            var dataHeight = sender.get_masterTableView().get_element().clientHeight; if (dataHeight < 500) {
                scrollArea.style.height = dataHeight + 17 + "px";
            }
        }


        </script>




               <asp:UpdateProgress id="UpdateProgress1" runat="server" associatedUpdatePanelID="up">
        <ProgressTemplate>
            <div  style="text-align: center; background-color: White; position: absolute;top: 50%;left: 50%; margin: -50px 0px 0px -50px;">
                   
                    <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="56"
                        Height="56" />
                </div>
        </ProgressTemplate>
                  </asp:UpdateProgress>
 
     <div class="heading_menu"><a href="AdminReports.aspx">Reports</a> <img src="../Images/arrowRight.png " width="18" /> Exam status</div>
 
        
  <%--  <div class="note">
        <p>This report provides the flag details with description.</p>                                       
    </div>--%>
      <div class="export_div">
             <div class="export_div_div">
                   <asp:ImageButton ID="btnExportOptions" runat="server" ImageUrl="~/Images/email.png" CssClass="ImageButtons"  ToolTip="Email" Width="22" OnClick="btnExportOptions_Click" ValidationGroup="Reports" /> 
                 &nbsp;&nbsp;  <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.png" CssClass="ImageButtons"  ToolTip="Export to XLS" Width="22" Height="22" OnClick="BtnExportToExcel_Click" ValidationGroup="Reports" />

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

                                     <br>

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
                        <%-- <td width="15%" align="left" valign="top"> <strong>From : </strong>
                                    <telerik:RadDatePicker  DateInput-ReadOnly="true" ID="txtFromDate" runat="server" Width="120" Skin="Web20"></telerik:RadDatePicker>
                                    &nbsp;&nbsp;</td>
                         <td width="15%" align="left" valign="top"> <strong>To :</strong>
            <telerik:RadDatePicker  DateInput-ReadOnly="true" ID="txtToDate" runat="server" Width="120" Skin="Web20">
            </telerik:RadDatePicker>
                                </td>--%>

                        <td align="right" width="90px">
                            <strong>Course Name :</strong>
               
                        </td>
                        <td align="left"  width="70px" valign="top">
                             <telerik:RadComboBox ID="rcbCourses" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="       --Select Course--       "
                            Width="150"   Localization-AllItemsCheckedString="All Courses selected" DropDownAutoWidth="Enabled"   Filter="Contains" MarkFirstMatch="true" AutoCompleteSeparator=","  AutoPostBack="false"  OnSelectedIndexChanged="rcbCourses_SelectedIndexChanged"  onclientblur="postbackrcbCourses"> 
                               
                        </telerik:RadComboBox>

                        </td>
                          <td align="right" width="90px">
                            <strong>Exam Name&nbsp;:&nbsp;</strong>
               
                        </td>
                        <td align="left"  width="70px">
                             <telerik:RadComboBox ID="rcbExams" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" EmptyMessage="       --Select Exam--       "
                            Width="150"   Localization-AllItemsCheckedString="All exams selected" DropDownAutoWidth="Enabled"   Filter="Contains" MarkFirstMatch="true" AutoCompleteSeparator=",">
                        </telerik:RadComboBox>
                        

                        </td>
                        <td align="right" width="70px">
                            <strong>Start date&nbsp;:&nbsp;</strong>
                        </td>
                        <td align="left" width="70px">
                              <telerik:RadDatePicker ID="ExamStartRadDatePicker" placeholder="mm/dd/yyyy" runat="server" DateInput-ReadOnly="false" Width="120px" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                   
                                         <DateInput ID="DateInput1" EmptyMessage="MM/DD/YYYY" runat="server" DisplayDateFormat="MM/dd/yyyy">

                                        </DateInput>
                                         </telerik:RadDatePicker>
                        </td>
                            <td  align="right" width="70px">
                            <strong>End date&nbsp;:&nbsp;</strong>
                        </td>
                        <td align="left"  width="70px">
                              <telerik:RadDatePicker ID="ExamEndRadDatePicker" placeholder="mm/dd/yyyy" runat="server" DateInput-ReadOnly="false" Width="120px" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                   
                                         <DateInput ID="DateInput2" EmptyMessage="MM/DD/YYYY" runat="server" DisplayDateFormat="MM/dd/yyyy">

                                        </DateInput>
                                         </telerik:RadDatePicker>
                        </td>
                            
                        <td align="left" valign="top">   <telerik:RadButton ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"  Skin="Web20"/></td>
                                               
                         <td align="right" valign="top">
           
        </td>
                    </tr>
                    
                   
                </table>
        </div>
      
                <div style="width:100%;">

                <telerik:RadGrid ID="gvReports" runat="server"  OnNeedDataSource="gvReports_NeedDataSource" OnPageIndexChanged="gvReports_PageIndexChanged"                   
                    AllowPaging="True" AllowSorting="true" Skin="Web20" GridLines="None"  PageSize="6" AutoGenerateColumns="false" OnItemCommand="gvReports_ItemCommand" OnPageSizeChanged="gvReports_PageSizeChanged" OnItemDataBound="gvReports_ItemDataBound" >
                 


                    
                     <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" DataKeyNames="CourseID,ExamID"
                        CommandItemDisplay="None" NoMasterRecordsText="No records found" TableLayout="Auto">
                       
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        
                        <Columns>
                        
<telerik:GridBoundColumn DataField="ExamID" HeaderText="Exam ID" HeaderStyle-Width="70px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="StudentFirstName" HeaderText="Student First Name" HeaderStyle-Width="70px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="StudentLastName" HeaderText="Student Last Name" HeaderStyle-Width="70px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="EmailAddress" HeaderText="Email Address" HeaderStyle-Width="140px" ></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name" HeaderStyle-Width="100px" ></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="InstructorName" HeaderText="Instructor Name" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="AppointmentCreationDate" HeaderText="Appointment Creation Date [EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}" HeaderStyle-Width="90px" ></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="AppointmentDate" HeaderText="Appointment Date [EST]" DataFormatString="{0:MM/dd/yyyy HH:mm tt}" HeaderStyle-Width="90px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="ExamDuration" HeaderText="Exam Duration" HeaderStyle-Width="70px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="FairExamLevel" HeaderText="<%$ Resources:ResMessages,Common_FairExamLevel%>" HeaderStyle-Width="80px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="StatusName" HeaderText="Status" HeaderStyle-Width="70px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="AlertCount" HeaderText="Blue" HeaderStyle-Width="60px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Alert" HeaderText="Blue Comments"
SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" HeaderStyle-Width="90px">
<ItemStyle HorizontalAlign="Center"  />

</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="GreenCount" HeaderText="Green" HeaderStyle-Width="70px"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Green" HeaderText="Green Comments"
SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center"
AllowFiltering="false" HeaderStyle-Width="100px">
<ItemStyle HorizontalAlign="Center"/>

</telerik:GridBoundColumn>
           <telerik:GridBoundColumn DataField="OrangeCount" HeaderText="Yellow" HeaderStyle-Width="70px"></telerik:GridBoundColumn>                                            
<telerik:GridBoundColumn DataField="Orange" HeaderText="Yellow Comments"
SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center"
AllowFiltering="false" HeaderStyle-Width="100px">
<ItemStyle HorizontalAlign="Center"/>

</telerik:GridBoundColumn>

<telerik:GridBoundColumn DataField="RedCount" HeaderText="Red" HeaderStyle-Width="70px"></telerik:GridBoundColumn> 
<telerik:GridBoundColumn DataField="Red" HeaderText="Red Comments"
SortExpression="Red" UniqueName="Red" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" HeaderStyle-Width="100px">
<ItemStyle HorizontalAlign="Center"  />

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
                      
            <ClientSettings> 
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="300px"  SaveScrollPosition="true"  FrozenColumnsCount="2"></Scrolling>  
                <ClientEvents OnGridCreated="GridCreated" /> 
            </ClientSettings> 
                </telerik:RadGrid>
                    </div>
            
            </ContentTemplate>
          </asp:UpdatePanel>
                 
</asp:Content>