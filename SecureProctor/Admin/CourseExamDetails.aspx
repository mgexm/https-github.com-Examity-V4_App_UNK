﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="CourseExamDetails.aspx.cs" Inherits="SecureProctor.Admin.CourseExamDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
<script type="text/javascript">
    function onRequestStart(sender, args) {
        if (args.get_eventTarget().indexOf("ExportTo") >= 0) {
            args.set_enableAjax(false);
        }
    }
    </script>
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All"
        EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents OnRequestStart="onRequestStart"></ClientEvents>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvCourseStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvCourseStatus"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvNotes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvNotes"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvRules">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvRules"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvExamDetails">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvExamDetails"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgCourseDetails.png" alt="Home" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkCourse" runat="server" Text="Course Details" Font-Bold="true"
                    Font-Underline="true" OnClick="lnkCourse_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                        ID="lnkExam" runat="server" Text="Exam Details" Font-Bold="true" Font-Underline="true"
                        OnClick="lnkExam_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upCourse" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr id="trCourse" runat="server">
                                <td width="100%" align="center" valign="top">
                                    <div class="login_new1">
                                        <table width="100%" cellpadding="2" cellspacing="4">
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                                        <tr class="td_header">
                                                            <td colspan="4" align="left">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" class="boreder_home_pro">
                                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgCreateNewCourse.png" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <asp:Label ID="lblSuccess" runat="server" Font-Bold="true"></asp:Label></tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="Label1" Text="Instructor Name" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddlprovider" runat="server" DropDownAutoWidth="Enabled"
                                                                    AppendDataBoundItems="true" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                                                </telerik:RadComboBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="--Select Instructor--"
                                                                    ErrorMessage="Please select instructor name" ControlToValidate="ddlprovider"
                                                                    ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td width="10%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <strong>
                                                                    <asp:Label ID="lblCourse" runat="server" Text="Course ID"></asp:Label></strong>
                                                            </td>
                                                            <td width="70%" align="left">
                                                                <telerik:RadTextBox ID="txtCourseID" runat="server" Width="250" MaxLength="100" Skin="Web20">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter course ID"
                                                                    ControlToValidate="txtCourseID" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="lblCourseName" Text="Course Name" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txtCourseName" runat="server" Width="250" MaxLength="100"
                                                                    Skin="Web20">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter course name"
                                                                    ControlToValidate="txtCourseName" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle" style="padding-top: 10px;">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadButton ID="BtnSaveCourse" runat="server" Skin="Web20" Text="Save" CausesValidation="true"
                                                                    ValidationGroup="submit" OnClick="BtnSaveCourse_Click">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton ID="BtnClear" runat="server" Skin="Web20" Text="Clear" OnClick="BtnClear_Click"
                                                                    CausesValidation="true">
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                                        <tr class="td_header">
                                                            <td align="left" colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" class="boreder_home_pro">
                                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgViewCourse.png" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <telerik:RadGrid ID="gvCourseStatus" runat="server" OnNeedDataSource="gvCourseStatus_NeedDataSource"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" OnItemCommand="gvCourseStatus_ItemCommand" EnableLinqExpressions="false">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="Course_ID" HeaderText="Course ID" SortExpression="Course_ID"
                                                                    UniqueName="Course_ID" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName"
                                                                    UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <%--<telerik:GridBoundColumn DataField="ExamProviderID" HeaderText="Provider ID" SortExpression="ExamProviderID"
                                                            UniqueName="ExamProviderID" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                                <telerik:GridBoundColumn DataField="ProviderName" HeaderText="Instructor Name" SortExpression="ProviderName"
                                                                    UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                                    AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgExamEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="EditCourse"
                                                                            CommandArgument='<%# Eval("CourseID") + "," + Eval("ExamProviderID") %>' ToolTip="Edit" />&nbsp;&nbsp;
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="18%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        </MasterTableView>
                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        <FilterMenu EnableImageSprites="False">
                                                        </FilterMenu>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="trExam" runat="server" visible="false">
                                <td width="100%" align="center" valign="top">
                                    <div class="login_new1">
                                        <table width="100%" cellpadding="2" cellspacing="4">
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                                        <tr class="td_header">
                                                            <td colspan="3" align="left">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" class="boreder_home_pro">
                                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ImgCreatNewExam.png" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" align="center">
                                                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td width="10%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <strong>
                                                                    <asp:Label ID="Label3" runat="server" Text="Course Name"></asp:Label></strong>
                                                            </td>
                                                            <td width="70%" align="left">
                                                                <telerik:RadComboBox ID="ddlCourse" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                                                    DropDownAutoWidth="Enabled">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="lblExam" Text="Exam Name" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txtExam" runat="server" Width="250" MaxLength="100" Skin="Web20">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_ExamDetExam %>"
                                                                    ControlToValidate="txtExam" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="lblExamhrs" Text="Duration of the Exam (hrs)" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left" valign="bottom">
                                                                <asp:Label ID="lblHours" runat="server" Text="Hours"></asp:Label>&nbsp;
                                                                <telerik:RadComboBox ID="ddlHours" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                                                    Width="50">
                                                                </telerik:RadComboBox>
                                                                &nbsp;&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblMinutes" runat="server" Text="Minutes"></asp:Label>&nbsp;
                                                                <telerik:RadComboBox ID="ddlMinutes" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                                                    Width="50">
                                                                </telerik:RadComboBox>
                                                                <asp:CompareValidator ID="cv" runat="server" ValidationGroup="submit" InitialValue="00"
                                                                    ControlToValidate="ddlHours" ControlToCompare="ddlMinutes" Operator="NotEqual"
                                                                    Text="Please select exam duration(hrs)" Type="String" />
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" width="100%">
                                                                <strong>
                                                                    <asp:Label ID="lblBufferTime" Text="Extended time for special accommodations students" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left" valign="bottom">
                                                                <asp:Label ID="Label15" runat="server" Text="Minutes"></asp:Label>&nbsp;
                                                                <telerik:RadComboBox ID="ddlBufferTime" runat="server" AppendDataBoundItems="True"
                                                                    Skin="Web20" Width="50">
                                                                </telerik:RadComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="lblAccessExam" Text="Link to access Exam" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <%--<telerik:RadTextBox ID="txtAccessExam" runat="server" Width="350" MaxLength="2000"
                                                Skin="Web20">
                                            </telerik:RadTextBox>--%>
                                                                <textarea id="txtAccessExam" runat="server" width="350" maxlength="2000" rows='1'
                                                                    cols='40' skin="Web20" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_ExamURL %>"
                                                                    ControlToValidate="txtAccessExam" ForeColor="Red" ValidationGroup="submit">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="Label4" Text="Exam Start Date" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadDatePicker ID="CalendarExtender1" runat="server" Skin="Web20">
                                                                    <Calendar ID="txtStartDate" runat="server" EnableKeyboardNavigation="true" Skin="Web20">
                                                                    </Calendar>
                                                                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                                                    </DateInput>
                                                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                </telerik:RadDatePicker>
                                                                <asp:RequiredFieldValidator runat="server" ID="RFV1" ControlToValidate="CalendarExtender1"
                                                                    ErrorMessage="Please select exam start date" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="lblEndDate" Text="Exam End Date" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadDatePicker ID="CalendarExtender2" runat="server" Skin="Web20">
                                                                    <Calendar ID="txtEndDate" runat="server" EnableKeyboardNavigation="true" Skin="Web20">
                                                                    </Calendar>
                                                                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                                                    </DateInput>
                                                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                </telerik:RadDatePicker>
                                                                <asp:RequiredFieldValidator runat="server" ID="RF4" ControlToValidate="CalendarExtender2"
                                                                    ErrorMessage="Please select exam end date" ValidationGroup="submit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvtxtStartDate" runat="server" ControlToCompare="CalendarExtender2"
                                                                    CultureInvariantValues="true" Operator="LessThanEqual" Display="Dynamic" ControlToValidate="CalendarExtender1"
                                                                    ErrorMessage="End date must be greater than start date" Type="Date" SetFocusOnError="true"
                                                                    ForeColor="Red" ValidationGroup="submit" />
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <strong>
                                                                    <asp:Label ID="Label5" Text="Exam Tools" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Image ID="imgCalc" runat="server" ImageUrl="~/Images/ImgCalc.png" Height="50" />
                                                                <asp:CheckBox ID="chkCalc" runat="server" Text="Calculator" />&nbsp;&nbsp;
                                                                <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                                                    Height="50" />
                                                                <asp:CheckBox ID="chkStickynotes" runat="server" Text="Scrap paper" />
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblUpload" runat="server" Text="Upload a file" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="upFile" runat="server" EnableViewState="true" />&nbsp;&nbsp;&nbsp;
                                                                <asp:Label ID="lblUploadText" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <strong>
                                                                    <asp:Label ID="Label6" Text="Notes for Proctors and Auditors" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <telerik:RadTextBox ID="txtNotes" runat="server" Width="500" MaxLength="5000" Height="40"
                                                                    TextMode="MultiLine" Skin="Web20">
                                                                </telerik:RadTextBox>
                                                                <telerik:RadButton ID="BtnAddNotes" runat="server" Skin="Web20" Text="Add" OnClick="BtnAddNotes_Click"
                                                                    ValidationGroup="AddNotes">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton ID="btnClearNotes" runat="server" Skin="Web20" Text="Clear" OnClick="BtnClearNotes_Click">
                                                                </telerik:RadButton>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_Notes %>"
                                                                    ControlToValidate="txtNotes" ForeColor="Red" ValidationGroup="AddNotes">
                                                                </asp:RequiredFieldValidator>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                                                <telerik:RadGrid ID="gvNotes" runat="server" OnNeedDataSource="gvNotes_NeedDataSource"
                                                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                                    CellSpacing="0" GridLines="None" OnUpdateCommand="gvNotes_UpdateCommand" OnDeleteCommand="gvNotes_DeleteCommand">
                                                                    <GroupingSettings CaseSensitive="false" />
                                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                                        </RowIndicatorColumn>
                                                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                                        </ExpandCollapseColumn>
                                                                        <NoRecordsTemplate>
                                                                            No records to display.
                                                                        </NoRecordsTemplate>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="Head" HeaderText="#" SortExpression="Head" UniqueName="Head"
                                                                                HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="Text" HeaderText="Notes for Proctors and Auditors"
                                                                                SortExpression="Text" UniqueName="Text" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgNoteEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="Edit"
                                                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                                                    <asp:ImageButton ID="imgNoteDelete" runat="server" ImageUrl="~/Images/delete_s.png"
                                                                                        CommandName="Delete" CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                        <EditFormSettings EditFormType="Template">
                                                                            <FormTemplate>
                                                                                <table width="100%" cellpadding="5" cellspacing="5">
                                                                                    <tr>
                                                                                        <td align="right" style="padding-right: 5px;">
                                                                                            <asp:Label ID="lblDesc" Text="Notes for Proctors and Auditors : " runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="padding-left: 5px;">
                                                                                            <telerik:RadTextBox ID="txtNotesDescription" runat="server" Skin="Web20" Text='<%# Eval("Text")%>'>
                                                                                            </telerik:RadTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:ImageButton ID="ImgNoteUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                                                CommandName="Update" CommandArgument='<%# Eval("ID")%>' />&nbsp;&nbsp;&nbsp;
                                                                                            <asp:ImageButton ID="ImgNotesCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                                                CommandName="Cancel" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FormTemplate>
                                                                        </EditFormSettings>
                                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                        <FilterItemStyle BackColor="#DCEDFD"></FilterItemStyle>
                                                                    </MasterTableView>
                                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                    <FilterMenu EnableImageSprites="False">
                                                                    </FilterMenu>
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <strong>
                                                                    <asp:Label ID="Label7" Text="Rules for Student" runat="server"></asp:Label></strong>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <telerik:RadTextBox ID="txtRules" runat="server" Width="500" MaxLength="5000" Height="40"
                                                                    TextMode="MultiLine" Skin="Web20">
                                                                </telerik:RadTextBox>
                                                                <telerik:RadButton ID="BtnAddRules" runat="server" Skin="Web20" Text="Add" OnClick="BtnAddRules_Click"
                                                                    ValidationGroup="AddRules">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton ID="BtnClearRules" runat="server" Skin="Web20" Text="Clear" OnClick="BtnClearRules_Click">
                                                                </telerik:RadButton>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_Rules %>"
                                                                    ControlToValidate="txtRules" ForeColor="Red" ValidationGroup="AddRules">
                                                                </asp:RequiredFieldValidator>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewRowstyle">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                                                <telerik:RadGrid ID="gvRules" runat="server" OnNeedDataSource="gvRules_NeedDataSource"
                                                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                                    CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnDeleteCommand="gvRules_DeleteCommand"
                                                                    OnUpdateCommand="gvRules_UpdateCommand">
                                                                    <GroupingSettings CaseSensitive="false" />
                                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="Head" HeaderText="#" SortExpression="Head" UniqueName="Head"
                                                                                HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="Text" HeaderText="Rules for Student" SortExpression="Text"
                                                                                UniqueName="Text" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgRuleEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="Edit"
                                                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                                                    <asp:ImageButton ID="imgRuleDelete" runat="server" ImageUrl="~/Images/delete_s.png"
                                                                                        CommandName="Delete" CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                        <EditFormSettings EditFormType="Template">
                                                                            <FormTemplate>
                                                                                <table width="100%" cellpadding="5" cellspacing="5">
                                                                                    <tr>
                                                                                        <td align="right" style="padding-right: 5px;">
                                                                                            <asp:Label ID="lblDesc" Text="Rules for Student : " runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="padding-left: 5px;">
                                                                                            <telerik:RadTextBox ID="txtRuleDescription" runat="server" Skin="Web20" Text='<%# Eval("Text")%>'>
                                                                                            </telerik:RadTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:ImageButton ID="ImgRuleUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                                                CommandName="Update" CommandArgument='<%# Eval("ID")%>' />&nbsp;&nbsp;&nbsp;
                                                                                            <asp:ImageButton ID="ImgRuleCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                                                CommandName="Cancel" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FormTemplate>
                                                                        </EditFormSettings>
                                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                    </MasterTableView>
                                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                    <FilterMenu EnableImageSprites="False">
                                                                    </FilterMenu>
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridviewAlternatestyle" style="padding-top: 10px;">
                                                            <td align="center" colspan="3">
                                                                <telerik:RadButton ID="BtnSaveExam" runat="server" Skin="Web20" Text="Save Exam"
                                                                    OnClick="BtnSaveExam_Click" AutoPostBack="true" CausesValidation="true" ValidationGroup="submit">
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                                        <tr class="td_header">
                                                            <td align="left" colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" class="boreder_home_pro">
                                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgViewExam.png" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <telerik:RadGrid ID="gvExamDetails" runat="server" OnNeedDataSource="gvExamDetails_NeedDataSource"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnItemCommand="gvExamDetails_ItemCommand">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName"
                                                                    UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name" SortExpression="ExamName"
                                                                    UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ExamDuration" HeaderText="Duration (in Hrs)"
                                                                    SortExpression="ExamDuration" UniqueName="ExamDuration" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ExamStartDate" HeaderText="Start Date" SortExpression="ExamStartDate"
                                                                    UniqueName="ExamStartDate" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ExamEndDate" HeaderText="End Date" SortExpression="ExamEndDate"
                                                                    UniqueName="ExamEndDate" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                                    AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgExamView" runat="server" ImageUrl="~/Images/View_s.png" CommandArgument='<%# Eval("ExamID")%>'
                                                                            CommandName="ViewExam" ToolTip="View" />&nbsp;&nbsp;
                                                                        <asp:ImageButton ID="imgExamEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="EditExam"
                                                                            CommandArgument='<%# Eval("ExamID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                                        <asp:ImageButton ID="imgExamDelete" runat="server" ImageUrl="~/Images/delete_s.png"
                                                                            CommandName="DeleteExam" CommandArgument='<%# Eval("ExamID")%>' ToolTip="Delete" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="18%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkCourse" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkExam" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>