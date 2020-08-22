<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="ExamSchedule.aspx.cs" Inherits="SecureProctor.Student.ExamSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%" border="0" runat="server" id="tblContent">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left" width="40%" valign="top">
                                    <img src="../Images/ImgScheduleExam1.png" alt="Schedule exam" id="imgHead" runat="server" />
                                </td>
                                <td align="center" class="messages" valign="bottom" width="20%">
                                    <table width="100%" cellpadding="0" cellspacing="6">
                                        <tr>
                                            <td width="20px;">&nbsp;</td>
                                            <td width="12px;">
                                                <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #fff;"></div>
                                            </td>
                                            <td align="left" width="30">Available</td>
                                            <td>&nbsp;</td>
                                            <td width="12px;">
                                                <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #808080;"></div>
                                            </td>
                                            <td align="left" width="30">Unavailable</td>
                                            <td>&nbsp;</td>
                                            <td width="12px;">
                                                <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #00ff21;"></div>
                                            </td>
                                            <td align="left" width="30">Scheduled</td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" class="messages" valign="top" width="40%">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="right" valign="middle" width="77" colspan="2">&nbsp;On-demand scheduling &nbsp;&nbsp;
                                                                <telerik:RadButton ID="btnOnDemand" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox"
                                                                    AutoPostBack="true" ForeColor="Black" Checked="true" Skin="Web20" Width="77" Height="19" OnClick="btnOnDemand_Click">
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
                                            <td colspan="2" style="padding-top: 8px;" align="right"><span style="font-size: 12px;">Select this option to schedule exam within 48 hours.</span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="login_new1">
                            <table width="99%" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td width="33%" class="header_calci" align="left">
                                        <asp:ImageButton ID="ImgPrevDate" runat="server" ImageUrl="~/Images/arrow_left.png" OnClick="ImgPrevDate_Click" CssClass="header_cal_TopImage" />
                                    </td>
                                    <td width="33%" class="header_calci" align="center">Date&nbsp;&nbsp;<telerik:RadDatePicker ID="calScheduleDate" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="120px" OnSelectedDateChanged="calScheduleDate_SelectedDateChanged" AutoPostBack="true">
                                        <Calendar ID="txtStartDate" runat="server" EnableKeyboardNavigation="true" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    </td>
                                    <td width="33%" class="header_calci" align="right">
                                        <asp:ImageButton ID="ImgNextDate" runat="server" ImageUrl="~/Images/arrow_right.png" OnClick="ImgNextDate_Click" CssClass="header_cal_TopImage" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="33%" class="header_Cal" align="center">Morning
                                    </td>
                                    <td width="33%" class="header_Cal" align="center">Noon - Evening</td>
                                    <td width="33%" class="header_Cal" align="center">Night
                                    </td>
                                </tr>
                                <tr>
                                    <td width="33%" align="center" valign="top">
                                        <telerik:RadScheduler runat="server" ID="ExamScheduler_Morning" Skin="Web20" SelectedView="DayView"
                                            Width="100%" DataKeyField="ScheduleID" DataSubjectField="Subject" DataDescriptionField="Description"
                                            DataStartField="StartDate" DataEndField="EndDate" OverflowBehavior="Expand" EnableDescriptionField="true"
                                            AppointmentStyleMode="Auto" AllowDelete="true" ShowNavigationPane="false" ShowFooter="false" ShowHeader="false"
                                            DayStartTime="00:00:00" DayEndTime="12:00:00" ShowAllDayRow="false"
                                            ShowHoursColumn="true" MinutesPerRow="30" NumberOfHoveredRows="1" TimeLabelRowSpan="1"
                                            OnAppointmentDataBound="RadScheduler_AppointmentDataBound" OnFormCreating="ExamScheduler_Morning_FormCreating" 
                                            OnTimeSlotCreated="ExamScheduler_TimeSlotCreated">
                                            <AdvancedForm Modal="true"></AdvancedForm>
                                            <TimelineView UserSelectable="false"></TimelineView>
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
                                    <td width="33%" align="center" valign="top">
                                        <telerik:RadScheduler runat="server" ID="ExamScheduler_Noon" Skin="Web20" SelectedView="DayView"
                                            Width="100%" FirstDayOfWeek="Monday"
                                            LastDayOfWeek="Sunday" DataKeyField="ScheduleID" DataSubjectField="Subject" DataDescriptionField="Description"
                                            DataStartField="StartDate" DataEndField="EndDate" OverflowBehavior="Expand" EnableDescriptionField="true"
                                            AppointmentStyleMode="Auto" AllowDelete="true" ShowNavigationPane="false" ShowFooter="false" ShowHeader="false"
                                            DayStartTime="12:00:00" DayEndTime="20:00:00" ShowAllDayRow="false"
                                            ShowHoursColumn="true" MinutesPerRow="30" NumberOfHoveredRows="1" TimeLabelRowSpan="1"
                                            OnAppointmentDataBound="RadScheduler_AppointmentDataBound" OnFormCreating="ExamScheduler_Noon_FormCreating" 
                                            OnTimeSlotCreated="ExamScheduler_TimeSlotCreated">
                                            <AdvancedForm Modal="true"></AdvancedForm>
                                            <TimelineView UserSelectable="false"></TimelineView>
                                            <AppointmentContextMenus>
                                                <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenu1">
                                                    <Items>
                                                        <telerik:RadMenuItem Text="Reschedule" Value="CommandEdit">
                                                        </telerik:RadMenuItem>
                                                    </Items>
                                                </telerik:RadSchedulerContextMenu>
                                            </AppointmentContextMenus>
                                            <TimeSlotContextMenus>
                                                <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenu2">
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
                                    <td width="33%" align="center" valign="top">
                                        <telerik:RadScheduler runat="server" ID="ExamScheduler_Night" Skin="Web20" SelectedView="DayView"
                                            Width="100%" FirstDayOfWeek="Monday"
                                            LastDayOfWeek="Sunday" DataKeyField="ScheduleID" DataSubjectField="Subject" DataDescriptionField="Description"
                                            DataStartField="StartDate" DataEndField="EndDate" OverflowBehavior="Expand" EnableDescriptionField="true"
                                            AppointmentStyleMode="Auto" AllowDelete="true" ShowNavigationPane="false" ShowFooter="false" ShowHeader="false"
                                            DayStartTime="20:00:00" DayEndTime="23:59:59" ShowAllDayRow="false"
                                            ShowHoursColumn="true" MinutesPerRow="30" NumberOfHoveredRows="1" TimeLabelRowSpan="1"
                                            OnAppointmentDataBound="RadScheduler_AppointmentDataBound" OnFormCreating="ExamScheduler_Night_FormCreating" 
                                            OnTimeSlotCreated="ExamScheduler_TimeSlotCreated">
                                            <AdvancedForm Modal="true"></AdvancedForm>
                                            <TimelineView UserSelectable="false"></TimelineView>
                                            <AppointmentContextMenus>
                                                <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenu3">
                                                    <Items>
                                                        <telerik:RadMenuItem Text="Reschedule" Value="CommandEdit">
                                                        </telerik:RadMenuItem>
                                                    </Items>
                                                </telerik:RadSchedulerContextMenu>
                                            </AppointmentContextMenus>
                                            <TimeSlotContextMenus>
                                                <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenu4">
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
