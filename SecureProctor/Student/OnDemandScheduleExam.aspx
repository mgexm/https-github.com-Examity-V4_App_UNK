<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/Student.Master" 
    CodeBehind="OnDemandScheduleExam.aspx.cs" Inherits="SecureProctor.Student.OnDemandScheduleExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
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
                ////                var validated = Page_ClientValidate('Val');
                ////                if (!validated) return;
                var dock = $find("<%= RadDock1.ClientID %>");
                dock.set_closed(true);
            }

            function OnClientClicked1(sender, args) {

                var validated = Page_ClientValidate('Val');
                if (!validated) return;
            }

        </script>
    </telerik:RadScriptBlock>
    <%--  <asp:UpdatePanel ID="UpScheduleExam" runat="server">
        <ContentTemplate>--%>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%" border="0">
                <tr>
                    <td>
                        <img src="../Images/ImgScheduleExam1.png" alt="Schedule exam" id="imgHead" runat="server" />
                    </td>
                    <%--<td width="1%" rowspan="3">
                            </td>
                            <%--<td>
                                <img src="../Images/Imghelp.png" alt="help" />
                            </td>--%>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new1">
                            <table width="100%" border="0">
                                <tr>
                                    <td colspan="4" align="left" class="messages">
                                        <%--<strong>To Schedule an Exam:</strong>
                                        <br />
                                        <ul>
                                            <li>Double-click on the date and time you want to take your exam.</li><li>You must schedule
                                                your exam at least 24 hours in advance.</li><li>If your exam deadline is less than 24
                                                    hours away, please contact Secure Proctor's <a href="mailto:support@sptemple.zendesk.com" style="text-decoration:underline;"><b>support staff by clicking here</b></a></li></ul>
                                        <%--<asp:Label ID="lblHeader" runat="server" Text="Double-click on a time to Schedule/Reschedule an exam" CssClass="messages"></asp:Label>--%>
                                        <strong>To Schedule an Exam:</strong>
                                        <br />
                                        <ul>
                                            <li>Select date from calendar.</li>
                                            <li>Double-click preferred exam time.</li>
                                            <%--<li>Schedule exam at least 48 hours prior to start.</li>
                                            <li>To schedule exam less than 48 hours prior to start, please contact support team
                                                by clicking “Help” on the left side of the screen.</li>
                                            <asp:HyperLink ID="lnkSupport" runat="server" Text="support staff by clicking here."
                                                Font-Bold="true" Font-Underline="true" Visible="false"></asp:HyperLink>--%>
                                        </ul>
                                    </td>
                                </tr>
                            <%--<tr><td >&nbsp;</td></tr>--%>
                            
                                <tr>
                                    <td colspan="4" align="center" class="messages">
                                        <asp:Literal ID="lblMsg" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td valign="top">
                                        <telerik:RadCalendar runat="server" ID="calSchedular" Skin="Web20" EnableMultiSelect="false"
                                            PresentationType="Interactive" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                                            AutoPostBack="true" OnSelectionChanged="calSchedular_SelectedIndexChanged" FirstDayOfWeek="Monday"
                                            ShowFastNavigationButtons="false" OnDefaultViewChanged="calNavigationChanged">
                                        </telerik:RadCalendar>
                                    </td>
                                    <td>
                                        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager2">
                                            <AjaxSettings>
                                                <telerik:AjaxSetting AjaxControlID="SubmitButton">
                                                    <UpdatedControls>
                                                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" />
                                                    </UpdatedControls>
                                                </telerik:AjaxSetting>
                                                <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                                                    <UpdatedControls>
                                                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" />
                                                        <telerik:AjaxUpdatedControl ControlID="PanelDock" />
                                                    </UpdatedControls>
                                                </telerik:AjaxSetting>
                                            </AjaxSettings>
                                        </telerik:RadAjaxManager>
                                        <asp:Panel runat="server" ID="DockPanel">
                                            <telerik:RadDock runat="server" ID="RadDock1" Width="500" Height="250" Closed="true"
                                                Title="Schedule" Style="z-index: 2000; position: relative;" Skin="Web20">
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
                                                                        <asp:Label ID="lblSelectCourse" runat="server" Text="Course name:"></asp:Label><strong>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCourse" runat="server" Visible="false"></asp:Label>
                                                                    <telerik:RadComboBox runat="server" ID="drpCourse" AppendDataBoundItems="true"  OnSelectedIndexChanged="drpCourse_SelectedIndexChanged" AutoPostBack="true"
                                                                       DropDownAutoWidth="Enabled" Skin="Web20">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic"
                                                                        ControlToValidate="drpCourse" InitialValue="--Select course--" ErrorMessage="Select Course name"
                                                                        ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr class="gridviewAlternatestyle">
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
                                                                        <%--<asp:Label runat="server" ID="lblTimeWindow" Text="Exam duration"></asp:Label>--%>

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
                                                                    <telerik:RadDateTimePicker ID="StartTime" runat="server" SharedTimeViewID="SharedTimeView"
                                                                        Width="190" Skin="Web20">
                                                                    </telerik:RadDateTimePicker>
                                                                    <telerik:RadTimeView ID="SharedTimeView" runat="server" StartTime="00:00:00" Interval="00:30:00"
                                                                        EndTime="23:59:59" Columns="6" Skin="Web20">
                                                                    </telerik:RadTimeView>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" Display="Dynamic"
                                                                        ValidationGroup="Val" ControlToValidate="StartTime" ErrorMessage="Start time is required"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <%--<tr class="gridviewRowstyle">
                                                                <td valign="top" align="right">
                                                                    <strong>
                                                                        <asp:Label runat="server" ID="lblDescription" Text="Description :"></asp:Label><strong>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txtDescription" TextMode="MultiLine" Rows="5" Columns="55"
                                                                        runat="server">
                                                                    </telerik:RadTextBox>
                                                                </td>
                                                            </tr>--%>
                                                            <tr class="gridviewAlternatestyle">
                                                                <td colspan="2" align="right">
                                                                    <%--<telerik:RadButton runat="server" ID="btnSchedule_Reschedule" Text="Update" OnClick="Schedule_Reschedule_Click"
                                                                                OnClientClicked="OnClientClicked" Skin="Web20">
                                                                            </telerik:RadButton>--%>
                                                                    <telerik:RadButton runat="server" ID="btnProceed" Text="Next" OnClick="Schedule_Reschedule_Proceed_Click"
                                                                        Skin="Web20" OnClientClicked="OnClientClicked1">
                                                                    </telerik:RadButton>
                                                                </td>
                                                            </tr>

                                                            <tr class="gridviewRowstyle" runat="server" ID="trError" visible="false">
                                                                <td colspan="2" align="center">
                                                                <asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="Red" ></asp:Label>
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
                                                            <%--<tr class="gridviewAlternatestyle">
                                                                <td align="right">
                                                                    <strong>
                                                                        <asp:Label runat="server" ID="lblCSubject" Text="Subject:"></asp:Label><strong>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblSubjectValue1"></asp:Label>
                                                                </td>
                                                            </tr>--%>
                                                            <tr class="gridviewRowstyle">
                                                                <td align="right">
                                                                    <strong>
                                                                        <asp:Label runat="server" ID="lblCStart" Text="Start :"></asp:Label><strong>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblStartValue"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <%--<tr class="gridviewAlternatestyle">
                                                                <td valign="top" align="right">
                                                                    <strong>
                                                                        <asp:Label runat="server" ID="lblCDescription" Text="Description :"></asp:Label><strong>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblDescriptionValue"></asp:Label>
                                                                </td>
                                                            </tr>--%>
                                                            <tr class="gridviewAlternatestyle">
                                                                <td colspan="2" align="right">
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
                                            Width="902px" DayStartTime="08:00:00" DayEndTime="19:01:00" FirstDayOfWeek="Monday"
                                            LastDayOfWeek="Sunday" DataKeyField="ScheduleID" DataSubjectField="Subject" DataDescriptionField="Description"
                                            DataStartField="StartDate" DataEndField="EndDate" OverflowBehavior="Scroll" EnableDescriptionField="true" 
                                            AppointmentStyleMode="Auto" OnFormCreating="ExamScheduler_FormCreating" AllowDelete="true" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" OnAppointmentDelete="RadScheduler1_AppointmentDelete"
                                            ShowNavigationPane="false">
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
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%-- <td width="25%" rowspan="3" valign="top" class="help_text_i">
                                <div class="help_text_i_inner">
                                    <strong>How do I schedule for an exam?</strong>
                                    <ul>
                                        <li>Select Course and Select Exam to view available times</li>
                                        <li>Right click on available time to schedule an exam</li>
                                        <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                                        <li>Select a preferred date (grayed dates mean they can't be selected)</li>
                                        <li>Select the time that suits you best.</li>
                                    </ul>
                                    <strong>What happens after I schedule?</strong>
                                    <ul>
                                        <li>You will get an email confirming your schedule</li>
                                        <li>In the email, you will have instructions what to do before and during the exam</li>
                                    </ul>
                                    <strong>How do Reschedule/cancel?</strong>
                                    <ul>
                                        <li>You can Reschedule at any time slot that best suits you</li>
                                        <li>You can Reschedule for an exam 24 hours before the previous scheduled time slot</li>
                                        <li>If a slot is grayed out, it's not a system issue. It just means that slot is full</li>
                                    </ul>
                                    <p>
                                        &nbsp;</p>
                                </div>
                            </td>--%>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>