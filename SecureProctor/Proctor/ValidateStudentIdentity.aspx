<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true"
    CodeBehind="ValidateStudentIdentity.aspx.cs" Inherits="SecureProctor.Proctor.ValidateStudentIdentity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
    <script language="javascript" type="text/javascript">
        function openAddProctor(ID) {

            radopen("AddProctor.aspx?TransID="+ID, "ADD PROCTOR", 500, 350);
        }

        function openEditProctor(ID) {

            radopen("EditProctor.aspx?TransID="+ID, "ADD PROCTOR", 500, 350);
        }


        function closeWin() {
            var masterTable = $find("<%= gvStudentExams.ClientID %>").get_masterTableView();
            masterTable.rebind();

        }
    </script>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table width="100%">
                <tr>

                    <td align="left">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgValidateProctor1.png" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="Red" Visible="false" />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="btnBlockedDates" runat="server" ImageUrl="~/Images/ImgBlocking.png" OnClick="btnBlockedDates_Click" />&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td colspan="3">
                        <div class="login_new1">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" valign="top">
                                        <telerik:RadCalendar ID="calDate" runat="server" PresentationType="Interactive" AutoPostBack="true"
                                            EnableMultiSelect="false" Skin="Web20" OnSelectionChanged="calDate_SelectedIndexChanged">
                                            <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
                                            <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
                                            <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
                                            <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
                                            <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
                                            <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
                                            <DayOverStyle CssClass="rcHover"></DayOverStyle>
                                            <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Web20"></FastNavigationStyle>
                                            <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                                        </telerik:RadCalendar>
                                    </td>
                                    <td width="1%">&nbsp;
                                    </td>
                                    <td width="79%" valign="top">
                                        <telerik:RadGrid ID="gvStudentExams" runat="server" OnNeedDataSource="gvStudentExams_NeedDataSource"
                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="0"
                                            GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" OnItemCommand="gvStudentExams_ItemCommand"
                                            EnableLinqExpressions="false">
                                            <GroupingSettings CaseSensitive="false" />
                                            <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                                <NoRecordsTemplate>
                                                    No records to display.
                                                </NoRecordsTemplate>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                        SortExpression="TransID" DataField="TransID" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTransID" runat="server" Text='<%# Eval("TransID")  %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentFirstName %>"
                                                        SortExpression="FirstName" DataField="FirstName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkStudentFirstName" runat="server" CommandArgument='<%# Eval("UserID")  %>'
                                                                Text='<%# Eval("FirstName")  %>' CommandName="VIEWFIRSTSTUDENT" Font-Underline="true" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentLastName %>"
                                                        SortExpression="LastName" DataField="LastName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkStudentLastName" runat="server" CommandArgument='<%# Eval("UserID")  %>'
                                                                Text='<%# Eval("LastName")  %>' CommandName="VIEWLASTSTUDENT" Font-Underline="true" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                                        SortExpression="ExamName" DataField="ExamName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkExamName" runat="server" CommandArgument='<%# Eval("TransID")  %>'
                                                                Text='<%# Eval("ExamName")  %>' CommandName="VIEWEXAMDETAILS" Font-Underline="true" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridBoundColumn DataField="ProviderFirstName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderFirstName %>"
                                                        SortExpression="ProviderFirstName" UniqueName="ProviderFirstName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ProviderLastName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderLastName %>"
                                                        SortExpression="ProviderLastName" UniqueName="ProviderLastName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ScheduleTime" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ScheduleTime %>"
                                                        SortExpression="ScheduleTime" UniqueName="ScheduleTime" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>

                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamSecurityLevel %>"
                                                        SortExpression="SecurityDescription" DataField="SecurityDescription" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSecurity" runat="server" Text='<%# Eval("SecurityDescription")  %>' ToolTip='<%# Eval("SecurityToolTip")  %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_Proctor %>"
                                                        AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnWebcam" runat="server" ImageUrl='<%# Eval("Status").ToString() == "Scheduled" ? (Eval("LockDownBrowser").ToString() == "True" ? "~/Images/ImgWebcam.png": "~/Images/ImgWebcam.png") : "~/images/webcam_blue.png" %>'
                                                                Width="35" CommandArgument='<%# Eval("TransIDandStatus")  %>' CommandName="VIEWEXAM" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Proctor Name"
                                                        SortExpression="ProctorName" DataField="ProctorName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProctorName" runat="server" Text='<%# Eval("ProctorName")  %>' ToolTip='<%# Eval("ProctorName")  %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamStatus %>" 
                                                        SortExpression="Status" DataField="Status" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <div style="width: 100%; height: 100%;">
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' />
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="status" Height="100%" HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Action %>"
                                                        HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            
                                                      
                                                    <asp:ImageButton ID="BtnAddProctor" runat="server" ImageUrl="~/Images/ImgGridAdd.png" CommandName="Add"
                                                    CommandArgument='<%# Eval("TransID")%>' ToolTip="Add Proctor"
                                                    Visible='<%# Convert.ToBoolean(Eval("ProctorAdd")) %>' OnClientClick='<%# Eval("TransID", "openAddProctor({0});return false;") %>' />
                                                                  
                                                        <asp:ImageButton ID="BtnEditProctor" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="Edit"
                                                     CommandArgument='<%# Eval("TransID")%>' ToolTip="Edit Proctor" Visible='<%# Convert.ToBoolean(Eval("ProctorEdit")) %>' OnClientClick='<%# Eval("TransID", "openEditProctor({0});return false;") %>' />
                                                                                             
                                               
                                                
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" Width="3%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>

                                                </Columns>
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            </MasterTableView>
                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                        </telerik:RadGrid>
                                        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                                            Behaviors="Close" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClientClose="closeWin"
                                            VisibleStatusbar="false">
                                            <Windows>
                                                <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="400px"
                                                    Height="400px" Title="Telerik RadWindow" Behaviors="Default">
                                                </telerik:RadWindow>
                                            </Windows>
                                        </telerik:RadWindowManager>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../Scripts/jquery-timer.js"></script>
    <script type="text/javascript">
    
    
        //$.timer(checkExams(),3000,true);
        var count = 0;
        var timer = 
            $.timer(
                function checkExams()
                {
                    var count = <%= gvStudentExams.Items.Count %>;
                    var transID = "";
                    for(var i = 0 ; i < count ; i++)
                    {
                        var row = ((i+1)*2)+2;
                        if(row<10){
                            row = "0"+row;
                        }
                        var id = "ctl00_ProctorContent_gvStudentExams_ctl00_ctl"+row+"_lblTransID";
                        if($('#'+id).html() != "Student Arrived")
                        {
                            transID = $('#'+id).html();
                            $.post('AjaxResponse.aspx', { Method: "StudentExamStatus", TransID: transID, RowNo: i }, function (data) {
                                var result = data.split("|");
                                var trID = 'ctl00_ProctorContent_gvStudentExams_ctl00__'+result[1];
                                var rowId = ((parseInt(result[1])+1)*2)+2;
                                if(rowId<10){
                                    rowId = "0"+rowId;
                                }
                                if(result[0] == "13")
                                {
                                    $('#'+trID).find(".status").attr('style','background-color:Red;');
                                    $('#'+"ctl00_ProctorContent_gvStudentExams_ctl00_ctl"+rowId+"_lblStatus").html('Exam started');
                                }
                                else if(result[0] == "2")
                                {
                                    $('#'+trID).find(".status").attr('style','background-color:Orange;');
                                    $('#'+"ctl00_ProctorContent_gvStudentExams_ctl00_ctl"+rowId+"_lblStatus").html('In progress');
                                }
                                else if(result[0] == "3")
                                {
                                    $('#'+trID).find(".status").attr('style','background-color:Green;');
                                    $('#'+"ctl00_ProctorContent_gvStudentExams_ctl00_ctl"+rowId+"_lblStatus").html('Completed');
                                }
                                else if(result[0] == "15")
                                {
                                    $('#'+trID).find(".status").attr('style','background-color:Orange;');
                                    $('#'+"ctl00_ProctorContent_gvStudentExams_ctl00_ctl"+rowId+"_lblStatus").html('Waiting for Proctor');
                                }
                                else if(result[0] == "16")
                                {
                                    $('#'+trID).find(".status").attr('style','background-color:Orange;');
                                    $('#'+"ctl00_ProctorContent_gvStudentExams_ctl00_ctl"+rowId+"_lblStatus").html('Verification in progress');
                                }
                                else if(result[0] == "1")
                                {
                                    $('#'+trID).find(".status").attr('style','background-color:White;');
                                }
                                else
                                {
                                    $('#'+trID).attr('style','display:none');
                                }
                            });
                        }
                    }
                },
		1000,
		true
	);
    
        //timer.set({ time : 3000, autostart : true });
    
    </script>
</asp:Content>
