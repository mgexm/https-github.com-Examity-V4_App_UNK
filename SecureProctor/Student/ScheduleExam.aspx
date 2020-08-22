<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="ScheduleExam.aspx.cs" Inherits="SecureProctor.Student.ScheduleExam" %>



<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <style type="text/css">
                   .RadScheduler_Web20 .rsNonWorkHour, .RadScheduler_Web20 .rsSunCol, .RadScheduler_Web20 .rsSatCol {
                background-color: white;                
                }
                .RadCalendar_Web20 .rcMain .rcWeekend a {
    color: #000;
}
                </style>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
                <script type="text/javascript">
                    function openForm() {
                        var dock = $find("<%= RadDock1.ClientID %>");
                        // Center the RadDock on the screen
                        var viewPort = $telerik.getViewPortSize();
                        var xPos = Math.round((viewPort.width - parseInt(dock.get_width())) / 2);
                        var yPos = Math.round((viewPort.height - parseInt(dock.get_height())) / 2);
                        $telerik.setLocation(dock.get_element(), { x: xPos, y: yPos });
                        dock.set_closed(false);
                        Sys.Application.remove_load(openForm);
                    }
                    function hideForm() {
                        var dock = $find("<%= RadDock1.ClientID %>"); 
                        dock.set_closed(true);
                        return true;
                    }
                    function OnClientClicked(sender, args) {
                        var dock = $find("<%= RadDock1.ClientID %>");
                        dock.set_closed(true);
                    }
                    function OnClientClicked1(sender, args) {
                        var validated = Page_ClientValidate('Val');
                        if (!validated) return;
                    }
                    function OnEnterKeyPress(sender, args) {
                        openForm();
                    }


                </script>
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager runat="server" ID="RadAjaxManager2">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="SubmitButton">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="ExamScheduler">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="PanelDock" />
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="PanelDock">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="PanelDockConfirm" />
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btnOnDemand">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="calSchedular" />
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="StartTime" />
                            <telerik:AjaxUpdatedControl ControlID="SharedTimeView" />
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                            <telerik:AjaxUpdatedControl ControlID="PanelDockConfirm" />
                            <telerik:AjaxUpdatedControl ControlID="PanelDock" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="calSchedular">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="StartTime" />
                            <telerik:AjaxUpdatedControl ControlID="SharedTimeView" />
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="StartTime">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="SharedTimeView" />
                            <telerik:AjaxUpdatedControl ControlID="calSchedular" />
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btnSchedule_Reschedule">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                            <telerik:AjaxUpdatedControl ControlID="calSchedular" />
                            <telerik:AjaxUpdatedControl ControlID="ExamScheduler" LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btnProceed">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="PanelDockConfirm" />
                            <telerik:AjaxUpdatedControl ControlID="PanelDock" />
                            <telerik:AjaxUpdatedControl ControlID="lblExamError" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="StartTime">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="PanelDockConfirm" />
                            <telerik:AjaxUpdatedControl ControlID="PanelDock" />
                            <telerik:AjaxUpdatedControl ControlID="trError" />
                            <telerik:AjaxUpdatedControl ControlID="btnProceed" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20"
                Transparency="50">
                <div class="loading" style="text-align: center; background-color: White;">
                    <asp:Label ID="lblLoader" runat="server" Text="Please wait..." Font-Size="Large" Font-Bold="true" ForeColor="Black"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="36"
                        Height="36" />
                </div>
            </telerik:RadAjaxLoadingPanel>
            <table cellpadding="2" cellspacing="2" width="100%" border="0" runat="server" id="tblContent">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">
                                    <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgScheduleExam1.png" AlternateText="Schedule/Reschedule Exam" title="Schedule/Reschedule Exam" TabIndex="11" /></td>
                                <td align="right" class="messages">
                                    <asp:Panel ID="pnlAccessibility" runat="server">
                                        <asp:Label ID="Label1" runat="server" Text="Accessibility View" title="Please select the Accessibility button" TabIndex="12"></asp:Label>&nbsp;&nbsp;
                                    <telerik:RadButton ID="btnAccessibility" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" TabIndex="13"
                                        AutoPostBack="true" ForeColor="Black" Checked="true" Skin="Web20" Width="77" Height="19" OnClick="btnAccessibility_Click" title="Please click here to Enable/Disable the Accessibility setting">
                                        <ToggleStates>
                                            <telerik:RadButtonToggleState Value="ON" ImageUrl="../Images/ImgOn.png" HoveredImageUrl="../Images/ImgOn.png"
                                                Text="ON" Width="77" Height="19"></telerik:RadButtonToggleState>
                                            <telerik:RadButtonToggleState Value="OFF" ImageUrl="../Images/ImgOff.png" HoveredImageUrl="../Images/ImgOff.png"
                                                Text="OFF" Width="77" Height="19"></telerik:RadButtonToggleState>
                                        </ToggleStates>
                                    </telerik:RadButton>
                                        &nbsp;&nbsp;
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new1">
                            <asp:Panel ID="pnlSchedule_Accessibility_On" runat="server">
                                <table width="100%" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="messages" valign="top" width="40%">
                                                        <strong>
                                                            <asp:Label ID="Label2" runat="server" Text="To Schedule an Exam:" TabIndex="14"></asp:Label>
                                                        </strong>
                                                        <br />
                                                        <ul>
                                                            <li>
                                                                <asp:Label ID="Label5" runat="server" Text="Schedule exam at least 24 hours prior to start." TabIndex="17"></asp:Label></li>
                                                        </ul>
                                                    </td>
                                                    <td align="right" class="messages" valign="top" width="60%">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="right" valign="middle" width="77" colspan="2">&nbsp;<asp:Label ID="Label6" runat="server" Text="On-demand scheduling " TabIndex="18"></asp:Label>&nbsp;&nbsp;
                                                                <telerik:RadButton ID="btnOnDemand1" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" TabIndex="20"
                                                                    AutoPostBack="true" ForeColor="Black" Checked="true" Skin="Web20" Width="77" Height="19" OnClick="btnOnDemand1_Click" title="Please click here to Enable/Disable the On-Demand setting">
                                                                    <ToggleStates>
                                                                        <telerik:RadButtonToggleState Value="ON" ImageUrl="../Images/ImgOn.png" HoveredImageUrl="../Images/ImgOn.png"
                                                                            Text="ON" Width="77" Height="19"></telerik:RadButtonToggleState>
                                                                        <telerik:RadButtonToggleState Value="OFF" ImageUrl="../Images/ImgOff.png" HoveredImageUrl="../Images/ImgOff.png"
                                                                            Text="OFF" Selected="true" Width="77" Height="19"></telerik:RadButtonToggleState>
                                                                    </ToggleStates>
                                                                </telerik:RadButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding-top: 8px;" align="right"><span style="font-size: 12px;">
                                                                    <asp:Label ID="Label7" runat="server" Text="Select this option to schedule exam within 24 hours." TabIndex="19"></asp:Label></span></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" class="messages">
                                            <asp:Label ID="lblMsg1" runat="server" TabIndex="34"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%">
                                            <table cellpadding="5" cellspacing="5" width="100%" border="0" style="background: #f2f2f2; border: 1px solid #e3e3e3;">
                                                <tr>
                                                    <td align="right" width="10%"><strong>
                                                        <asp:Label ID="lblC1" runat="server" Text="Course Name :" TabIndex="21"></asp:Label></strong></td>
                                                    <td align="left" width="25%">
                                                        <telerik:RadComboBox runat="server" ID="ddlCourses" AppendDataBoundItems="true" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Vista" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged" TabIndex="22">
                                                        </telerik:RadComboBox>
                                                        <asp:Label ID="lblAccessibilityCourseName" runat="server" TabIndex="22"></asp:Label>
                                                        <asp:HiddenField ID="hdAccessibilityCourseID" runat="server" />
                                                    </td>
                                                    <td align="right" width="10%"><strong>
                                                        <asp:Label ID="lblE1" runat="server" Text="Exam Name :" TabIndex="23"></asp:Label></strong></td>
                                                    <td align="left" width="55%">
                                                        <telerik:RadComboBox runat="server" ID="ddlExams" AppendDataBoundItems="true" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Vista" TabIndex="24" OnSelectedIndexChanged="ddlExams_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                        <asp:Label ID="lblAccessibilityExamName" runat="server" TabIndex="24"></asp:Label>
                                                        <asp:HiddenField ID="hdAccessibilityExamID" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="5" cellspacing="5" width="100%" border="0" style="background: #286094; color: #fff;">
                                                <tr>
                                                    <td align="right" width="10%"><strong>
                                                        <asp:Label ID="lblY1" runat="server" Text="Year :" TabIndex="25"></asp:Label></strong></td>
                                                    <td align="left" width="15%">
                                                        <telerik:RadComboBox runat="server" ID="ddlYear" AppendDataBoundItems="true" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Vista" TabIndex="26" Width="120" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="--Select Year--" Value="-1" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="right" width="10%"><strong>
                                                        <asp:Label ID="lblM1" runat="server" Text="Month :" TabIndex="27"></asp:Label></strong></td>
                                                    <td align="left" width="15%">
                                                        <telerik:RadComboBox runat="server" ID="ddlMonth" AppendDataBoundItems="true" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Vista" TabIndex="28" Width="120" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="--Select Month--" Value="-1" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="right" width="10%"><strong>
                                                        <asp:Label ID="lblD1" runat="server" Text="Date :" TabIndex="29"></asp:Label></strong></td>
                                                    <td align="left" width="15%">
                                                        <telerik:RadComboBox runat="server" ID="ddlDay" AppendDataBoundItems="true" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Vista" TabIndex="30" Width="120" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="--Select Day--" Value="-1" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="right" width="10%"><strong>
                                                        <asp:Label ID="lblT1" runat="server" Text="Time :" TabIndex="31"></asp:Label></strong></td>
                                                    <td align="left" width="15%">
                                                        <telerik:RadComboBox runat="server" ID="ddlTime" AppendDataBoundItems="true" AutoPostBack="false"
                                                            DropDownAutoWidth="Enabled" Skin="Vista" TabIndex="32" Width="120">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="--Select Time--" Value="-1" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnScheduleExam" runat="server" Text="Schedule" class="button_new orange" OnClick="btnScheduleExam_Click" TabIndex="33" />
                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>
                            <asp:Panel ID="pnlSchedule_Accessibility_Off" runat="server">
                                <table width="100%" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="messages" valign="top" width="40%">
                                                       <table width="100%" cellpadding="0" cellspacing="6">
                                                                        <tr>
                                                                            <td width="20px;">&nbsp;</td>
                                                                            <td width="12px;">
                                                                                <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #fff;"></div>
                                                                            </td>
                                                                            <td align="left" width="30">Available</td>
                                                                            <td width="5px;">&nbsp;</td>
                                                                            <td width="12px;">
                                                                                <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #CCCCCC;"></div>
                                                                            </td>
                                                                            <td align="left" width="30">Unavailable</td>
                                                                            <td width="5px;">&nbsp;</td>
                                                                            <td width="12px;">
                                                                                <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #00ff21;"></div>
                                                                            </td>
                                                                            <td align="left" width="30">Scheduled</td>
                                                                        </tr>

                                                                    </table>
                                                        
                                                        
                                                    </td>
                                                    <td align="right" class="messages" valign="top" width="60%">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="right" valign="middle" width="77" colspan="2">&nbsp;<asp:Label ID="lblHeaderMsg5" runat="server" Text="On-demand scheduling "></asp:Label>&nbsp;&nbsp;
                                                                <telerik:RadButton ID="btnOnDemand" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox"
                                                                    AutoPostBack="true" ForeColor="Black" Checked="true" Skin="Web20" Width="77" Height="19" OnClick="btnOnDemand_Click" title="Please click here to Enable/Disable the On-Demand setting">
                                                                    <ToggleStates>
                                                                        <telerik:RadButtonToggleState Value="ON" ImageUrl="../Images/ImgOn.png" HoveredImageUrl="../Images/ImgOn.png"
                                                                            Text="ON" Width="77" Height="19"></telerik:RadButtonToggleState>
                                                                        <telerik:RadButtonToggleState Value="OFF" ImageUrl="../Images/ImgOff.png" HoveredImageUrl="../Images/ImgOff.png"
                                                                            Text="OFF" Selected="true" Width="77" Height="19"></telerik:RadButtonToggleState>
                                                                    </ToggleStates>
                                                                </telerik:RadButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding-top: 8px;" align="right"><span style="font-size: 12px;">
                                                                    <asp:Label ID="lblOndemandText" runat="server" Text="Select this option to schedule exam within 24 hours."></asp:Label></span></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="messages" valign="bottom" width="30%">
                                                                    
                                                                </td>
                                                                <td width="40%"></td>
                                                            </tr>
                                                        </table>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" >
                                                        <table cellpadding="6" cellspacing="2" width="100%" border="0" style="border:1px solid #ccc;">
                                                            <tr><td valign="top">
                                                                <div><strong class="messages">To</strong> <strong class="messages_Black"> SCHEDULE </strong><strong class="messages"> an exam: </strong> </div>
                                                                <ul class="messages">
                                                                    <li>Select date from calendar</li>
                                                                    <li>Double-click preferred exam time</li>
                                                                    <li>Select course and exam</li>
                                                                    <li>Confirm</li>
                                                                </ul>
                                                                </td>

                                                                <td style="border-right:1px solid #ccc;border-left:1px solid #ccc;" valign="top"><div><strong class="messages">To</strong><strong class="messages_Black" > RESCHEDULE </strong><strong class="messages"> an exam: </strong> </div>
                                                                <ul class="messages">
                                                                    <li>Double click existing green appointment </li>
                                                                    <li>Select new date (<img alt="calender" src="../Images/calender.png" />) and time (<img alt="clock" src="../Images/time.png" />)</li>
                                                                    <li>Confirm</li>
                                                                </ul></td>
                                                                <td valign="top"><div><strong class="messages">To</strong> <strong class="messages_Black"> CANCEL </strong><strong class="messages"> an exam: </strong></div>
                                                                <ul class="messages">
                                                                    <li>Click “X” on top right corner of existing green appointment</li>                                                                  
                                                                    <li>Confirm</li>
                                                                </ul></td>

                                                            </tr>
                                                        </table>
                                                 <%--       <div class="divTable">
                                                            <div class="divRow">
                                                                <div class="divColumn1"><strong>To schedule an exam </strong></div>
                                                                <div class="divColumn2"><strong>To reschedule an exam </strong></div>
                                                                <div class="divColumn3"><strong>To cancel an exam </strong></div>
                                                            </div>
                                                            <div class="divRow">
                                                                <div class="divColumn1"></div>
                                                                <div class="divColumn2">Double-click the appointment you want to move.</div>
                                                                <div class="divColumn3">Select the exam you want to cancel.</div>
                                                            </div>
                                                            <div class="divRow">
                                                                <div class="divColumn11"></div>
                                                                <div class="divColumn21">Select the date and time you want to schedule your new appointment slot and click “next”.</div>
                                                                <div class="divColumn31">Click the “x” in the upper right hand corner of the appointment.</div>
                                                            </div>
                                                            <div class="divRow">
                                                                <div class="divColumn1_t"></div>
                                                                <div class="divColumn2_t">Click confirm</div>
                                                                <div class="divColumn3_t">Click confirm</div>
                                                            </div>

                                                            <div class="clear"></div>
                                                        </div>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" class="messages">
                                            <asp:Literal ID="lblMsg" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="20%">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <telerik:RadCalendar runat="server" ID="calSchedular" Skin="Web20" EnableMultiSelect="false"
                                                            PresentationType="Interactive" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                                                            FirstDayOfWeek="Sunday" ShowFastNavigationButtons="true" ShowRowHeaders="false"
                                                            EnableKeyboardNavigation="true"
                                                            AutoPostBack="true" OnSelectionChanged="calSchedular_SelectedIndexChanged">
                                                        </telerik:RadCalendar>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="80%">
                                            <asp:Panel runat="server" ID="DockPanel">
                                                <telerik:RadDock runat="server" ID="RadDock1" Width="500" Height="270" Closed="true"
                                                    Title="Schedule" Style="z-index: 2000;" Skin="Web20" Top="200" Left="420">
                                                    <Commands>
                                                        <telerik:DockCloseCommand></telerik:DockCloseCommand>
                                                    </Commands>
                                                    <ContentTemplate>
                                                        <asp:Panel ID="PanelDock" runat="server">
                                                            <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                                                <tr class="gridviewAlternatestyle" runat="server" id="trExamID" visible="false">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblExamID" runat="server" Text="Exam ID:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblExamIDValue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                <td align="right">
                                                                    <strong>
                                                                        <asp:Label ID="lblSelectInstuctor" runat="server" Text="Instructor name:"></asp:Label><strong>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblInstructor" runat="server" Visible="false"></asp:Label>
                                                                    <telerik:RadComboBox runat="server" ID="drpInstructor" AppendDataBoundItems="true" OnSelectedIndexChanged="drpInstructor_SelectedIndexChanged" AutoPostBack="true"
                                                                        DropDownAutoWidth="Enabled" Skin="Web20">
                                                                    </telerik:RadComboBox>



                                                                    <asp:RequiredFieldValidator ID="RfInstructor" runat="server" Display="Dynamic"
                                                                        ControlToValidate="drpInstructor" InitialValue="--Select Instructor--" ErrorMessage="Select Instructor"
                                                                        ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>


                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblSelectCourse" runat="server" Text="Course name:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCourse" runat="server" Visible="false"></asp:Label>
                                                                        <telerik:RadComboBox runat="server" ID="drpCourse" AppendDataBoundItems="true" OnSelectedIndexChanged="drpCourse_SelectedIndexChanged" AutoPostBack="true"
                                                                            DropDownAutoWidth="Enabled" Skin="Web20">
                                                                        </telerik:RadComboBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic"
                                                                            ControlToValidate="drpCourse" InitialValue="--Select course--" ErrorMessage="Select Course name"
                                                                            ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblSelectExam" runat="server" Text="Exam name:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblExam" runat="server" Visible="false"></asp:Label>
                                                                        <telerik:RadComboBox runat="server" ID="drpExam" AutoPostBack="true" OnSelectedIndexChanged="drpExam_IndexChanged"
                                                                            AppendDataBoundItems="true" DropDownAutoWidth="Enabled" Skin="Web20">
                                                                        </telerik:RadComboBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                            ControlToValidate="drpExam" InitialValue="--Select exam--" ErrorMessage="Select Exam name"
                                                                            ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label runat="server" ID="lblSubject" Text="Exam duration:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblSubjectValue"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label runat="server" ID="lblStart" Text="Start :"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDateTimePicker AutoPostBackControl="Both" DateInput-ReadOnly="true" ID="StartTime" runat="server" SharedTimeViewID="SharedTimeView" OnSelectedDateChanged="StartTime_SelectedDateChanged"
                                                                            Width="190" Skin="Web20">
                                                                        </telerik:RadDateTimePicker>
                                                                        <telerik:RadTimeView ID="SharedTimeView" runat="server" Skin="Web20" Columns="6" StartTime="00:00:00" Interval="00:30:00" EndTime="23:59:59">
                                                                        </telerik:RadTimeView>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" Display="Dynamic"
                                                                            ValidationGroup="Val" ControlToValidate="StartTime" ErrorMessage="Start time is required"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td colspan="2" align="right">
                                                                        <telerik:RadButton runat="server" ID="btnProceed" Text="Next" OnClick="Schedule_Reschedule_Proceed_Click"
                                                                            Skin="Web20" OnClientClicked="OnClientClicked1">
                                                                        </telerik:RadButton>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle" runat="server" id="trError" visible="false">
                                                                    <td colspan="2" align="center">
                                                                        <asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle" runat="server" id="trRescheduleWarningMessage" visible="false">
                                                                    <td colspan="2" align="center">
                                                                        <asp:Label ID="Label3" runat="server" visible="false" Font-Bold="false" ForeColor="Red" Text="Are you sure you want to reschedule your test appointment? If your new appointment is less than 24 hours from now, you will be responsible for any on-demand scheduling fees not covered by your university."></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="PanelDockConfirm" runat="server" Visible="false">
                                                            <table cellpadding="5" cellspacing="3" width="100%" border="0">
                                                                <tr class="gridviewAlternatestyle" runat="server" id="tr1" visible="false">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblCExamID" runat="server" Text="ID:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCExamValue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblStudentName" runat="server" Text="Student name:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStudentNameValue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblCCoursename" runat="server" Text="Course name:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCoursevalue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label ID="lblCExamname" runat="server" Text="Exam name:"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblExamnamevalue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="right">
                                                                        <strong>
                                                                            <asp:Label runat="server" ID="lblCStart" Text="Start :"></asp:Label><strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblStartValue"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="center" colspan="2">
                                                                        <asp:Label ID="lblExamError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="left">&nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        <telerik:RadButton runat="server" ID="btnSchedule_Reschedule" Text="Confirm" OnClick="Schedule_Reschedule_Click"
                                                                            OnClientClicked="OnClientClicked" Skin="Web20">
                                                                        </telerik:RadButton>
                                                                        <telerik:RadButton runat="server" ID="RadButton1" Text="Cancel" OnClientClicked="hideForm"
                                                                            Skin="Web20">
                                                                        </telerik:RadButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </telerik:RadDock>
                                            </asp:Panel>
                                            <telerik:RadScheduler runat="server" ID="ExamScheduler" Skin="Web20" SelectedView="DayView"
                                                Width="100%" FirstDayOfWeek="Monday" ShowFooter="false" ShowFullTime="true" WorkDayStartTime="00:00:00" WorkDayEndTime="23:59:59" 
                                                LastDayOfWeek="Sunday" DataKeyField="ScheduleID" DataSubjectField="Subject" DataDescriptionField="Description"
                                                DataStartField="StartDate" DataEndField="EndDate" OverflowBehavior="Scroll" EnableDescriptionField="true"
                                                AppointmentStyleMode="Auto" OnFormCreating="ExamScheduler_FormCreating" AllowDelete="true" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" OnAppointmentDelete="RadScheduler1_AppointmentDelete"
                                                ShowNavigationPane="false" OnTimeSlotCreated="ExamScheduler_TimeSlotCreated" Height="600" BackColor="White" OnNavigationComplete="ExamScheduler_NavigationComplete">

                                               <%-- <Localization ConfirmDeleteText="Are you sure you want to cancel your appointment? <br> You will be responsible for paying any fees associated with scheduling a new appointment that are not covered by your university."
                                                    ConfirmDeleteTitle="Confirm Cancel appointment" ConfirmOK="Yes" ConfirmCancel="No" />--%>
                                                <Localization ConfirmDeleteText ="Are you sure you want to cancel this appointment?" ConfirmOK="Yes" ConfirmCancel="No" ConfirmDeleteTitle="Confirm Cancellation"/>
                                                <AdvancedForm Modal="true"></AdvancedForm>
                                                <TimelineView UserSelectable="false"></TimelineView>
                                                <MonthView UserSelectable="false" />
                                                <WeekView UserSelectable="false" />
                                                <AppointmentContextMenus>
                                                    <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenu">
                                                        <Items>
                                                            <telerik:RadMenuItem Text="Reschedule" Value="CommandEdit">
                                                            </telerik:RadMenuItem>
                                                        </Items>
                                                    </telerik:RadSchedulerContextMenu>
                                                </AppointmentContextMenus>
                                                <TimeSlotContextMenus>
                                                    <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerTimeSlotContextMenu">
                                                        <Items>
                                                            <telerik:RadMenuItem Text="Schedule" Value="CommandAddAppointment">
                                                            </telerik:RadMenuItem>
                                                        </Items>
                                                    </telerik:RadSchedulerContextMenu>
                                                </TimeSlotContextMenus>
                                                <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
                                                <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
                                                <Localization HeaderWeek="Week" />
                                            </telerik:RadScheduler>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
            </table>
            <table id="tblMyProfile" runat="server" visible="false" width="100%" border="0" cellpadding="2"
                cellspacing="2">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblMyprofile" runat="server" CssClass="messages"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
