<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExam.aspx.cs" Inherits="SecureProctor.CourseAdmin.AddExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table cellpadding="5" cellspacing="5" width="100%">
            <tr>
                <td>
                    <div class="heading customfont1">
                        <%=Resources.AppControls.Provider_AddExam_Label_AddExam%>
                    </div>
                </td>
            </tr>
            <tr id="trMessage" runat="server">
                <td align="center">
                    <table width="100%" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="center">
                                <table cellpadding="0" cellspacing="0" id="tdInfo" runat="server">
                                    <tr>
                                        <td align="right" style="padding-right: 10px;">
                                            <asp:Image ID="ImgInfo" runat="server" Width="22" Height="22" />
                                        </td>
                                        <td align="left" valign="middle">
                                            <asp:Label ID="lblInfo" runat="server" CssClass="lblInfo"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trAddExam" runat="server">
                <td>
                    <div class="login_new1">
                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                            <tr class="gridviewRowstyle">
                                <td width="35%" class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_AddExam_Label_CourseName %></strong>:
                                </td>
                                <td width="65%" align="left">
                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_AddExam_Label_ExamName %></strong>:
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="txtExam" runat="server" Width="250" MaxLength="100" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_ExamName %>"
                                        ControlToValidate="txtExam" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblSecurityLevel" Text="<%$ Resources:AppControls,Provider_AddExam_Label_SecurityLevel %>"
                                            runat="server"></asp:Label>
                                    </strong>:
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="upSecurity" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadComboBox ID="ddlSecurityLevel" runat="server" AppendDataBoundItems="True"
                                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" DropDownAutoWidth="Enabled"
                                                OnSelectedIndexChanged="ddlSecurityLevel_SelectedIndexChanged" AutoPostBack="true">
                                            </telerik:RadComboBox>
                                            <br />
                                            <asp:Label ID="lblLevelDesc" runat="server" Visible="false"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblExamhrs" Text="<%$ Resources:AppControls,Provider_AddExam_Label_DurationOfExam %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left" valign="bottom">
                                    <asp:Label ID="lblHours" runat="server" Text="<%$ Resources:AppControls,Provider_AddExam_Label_HH %>"></asp:Label>&nbsp;
                                <telerik:RadComboBox ID="ddlHours" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                    Width="50">
                                </telerik:RadComboBox>
                                    <asp:Label ID="lblMinutes" runat="server" Text="<%$ Resources:AppControls,Provider_AddExam_Label_MM %>"></asp:Label>&nbsp;
                                <telerik:RadComboBox ID="ddlMinutes" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                    Width="50">
                                </telerik:RadComboBox>
                                    <asp:CustomValidator ID="CustomValidator1"
                                        ControlToValidate="ddlHours"
                                        Display="Static"
                                        ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_SelectExamHours %>"
                                        OnServerValidate="ServerValidation"
                                        ValidationGroup="submit"
                                        runat="server" />
                                </td>
                            </tr>

                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblAccessExam" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamLinkToAccess %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <textarea id="txtAccessExam" runat="server" width="650" maxlength="2000" rows='5'
                                        cols='42' skin="<%$ Resources:AppConfigurations,Skin_Current %>" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_ExamURL %>"
                                        ControlToValidate="txtAccessExam" ForeColor="Red" ValidationGroup="submit">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--NEW RAD DATE AND TIME--%>
                           
                              <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblStartN" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamStartDateAndTimeN %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <telerik:RadDatePicker ID="ExamStartRadDatePicker" runat="server" DateInput-ReadOnly="false" Width="100px" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                   
                                          <DateInput ID="DateInput1" EmptyMessage="MM/DD/YYYY" runat="server" DisplayDateFormat="MM/dd/yyyy">

                                        </DateInput>
                                         </telerik:RadDatePicker>

                                    <telerik:RadTimePicker ID="ExamStartRadTimePicker" runat="server" DateInput-ReadOnly="true" Width="90px" Skin="Web20" Columns="6">
                                    <TimeView ID="TimeView1" Interval="00:30:00" Width="420px" Columns="6" StartTime="00:00:00" EndTime="23:59:59" runat="server"></TimeView> 
                                    </telerik:RadTimePicker>
                                    <div style="position: relative; top: 0px; left: 10px;">
                                        <div style="position: absolute; top: -20px; left: 200px; line-height: 15px; font-size: 11px;">


                                            <div style="float: left;">
                                                <asp:RequiredFieldValidator runat="server" ID="ExamStartRequiredFieldValidator" ControlToValidate="ExamStartRadDatePicker"
                                                    ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_StartDate %>"
                                                    ValidationGroup="submit"></asp:RequiredFieldValidator>
                                            </div>
                                            <div style="float: left;">
                                                <asp:RequiredFieldValidator runat="server" ID="ExamStartTimeRequiredFieldValidator" ControlToValidate="ExamStartRadTimePicker"
                                                    ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_StartTime %>"
                                                    ValidationGroup="submit"></asp:RequiredFieldValidator>

                                            </div>
                                            <div style="clear: both"></div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">

                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblEndN" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamEndDateAndTimeN %>"
                                            runat="server"></asp:Label></strong>:
                                </td>

                                <td>

                                    <telerik:RadDatePicker ID="ExamEndRadDatePicker" runat="server" DateInput-ReadOnly="false" Width="100px" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                    
                                     <DateInput ID="DateInput2" EmptyMessage="MM/DD/YYYY" runat="server" DisplayDateFormat="MM/dd/yyyy">

                                        </DateInput>
                                    </telerik:RadDatePicker>

                                    <telerik:RadTimePicker ID="ExamEndRadTimePicker" runat="server" DateInput-ReadOnly="true" Width="90px" Skin="Web20" Columns="6">
                                    <TimeView ID="TimeView2" Interval="00:30:00" Width="420px" Columns="6" StartTime="00:00:00" EndTime="23:59:59" runat="server"></TimeView> 
                                    </telerik:RadTimePicker>
                                    <div style="position: relative; top: 0px; left: 10px;">
                                        <div style="position: absolute; top: -20px; left: 200px; line-height: 15px; font-size: 11px;">
                                            <asp:RequiredFieldValidator runat="server" ID="ExamEndRequiredFieldValidator" ControlToValidate="ExamEndRadDatePicker"
                                                ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_EndDate %>"
                                                ValidationGroup="submit"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator runat="server" ID="ExamEndTimeRequiredFieldValidator" ControlToValidate="ExamEndRadTimePicker"
                                                ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_EndTime %>"
                                                ValidationGroup="submit"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="ExamStartRadDatePicker"
                                                EnableClientScript="true" ControlToValidate="ExamEndRadDatePicker" ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_StartAndEndDate %>" Type="String" Operator="GreaterThanEqual">  

                                            </asp:CompareValidator>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <%--NEW RAD DATE AND TIME--%>



<%--                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="Label1" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamStartDateAndTime %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <telerik:RadDateTimePicker ID="CalendarExtender1" runat="server" DateInput-ReadOnly="false" SharedTimeViewID="ExamStartTime" Skin="Web20" Width="190">
                                    </telerik:RadDateTimePicker>

                                    <telerik:RadTimeView ID="ExamStartTime" runat="server" Skin="Web20" Columns="6" >
                                    </telerik:RadTimeView>
                                    <asp:RequiredFieldValidator runat="server" ID="RFV1" ControlToValidate="CalendarExtender1"
                                        ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_StartDate %>"
                                        ValidationGroup="submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblEndDate" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamEndDateAndTime %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <telerik:RadDateTimePicker ID="CalendarExtender2" runat="server" DateInput-ReadOnly="false" SharedTimeViewID="ExamEndTime" Skin="Web20" Width="190">
                                    </telerik:RadDateTimePicker>

                                    <telerik:RadTimeView ID="ExamEndTime" runat="server" Skin="Web20" Columns="6" >
                                    </telerik:RadTimeView>

                                    <asp:RequiredFieldValidator runat="server" ID="RF4" ControlToValidate="CalendarExtender2"
                                        ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_EndDate %>" ValidationGroup="submit"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="CalendarExtender1"
                                        EnableClientScript="true" ControlToValidate="CalendarExtender2" ErrorMessage="<%$ Resources:AppMessages,Provider_AddExam_Error_StartAndEndDate %>" Type="String" Operator="GreaterThanEqual">  

                                    </asp:CompareValidator>


                                </td>
                            </tr>--%>

                              <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>



                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <asp:Label ID="lblUpload" runat="server" Text="<%$ Resources:AppControls,Provider_AddExam_Label_UploadFile %>"
                                        Font-Bold="true"></asp:Label>:
                                </td>
                               <td align="left">
                                   <%-- <asp:FileUpload ID="upFile" runat="server" EnableViewState="true" Visible="false" />&nbsp;&nbsp;&nbsp;--%>
                                    <table width="100%">
                                        <tr>
                                            <td width="20%">
 <telerik:RadAsyncUpload runat="server"  ID="AdminUpload" Width="200px" MultipleFileSelection="Automatic"   UploadedFilesRendering="BelowFileInput"  AllowedFileExtensions="jpg,jpeg,png,gif,doc,docx,xlsx,xls,txt,pdf" MaxUploadSize="10000000">
                                     </telerik:RadAsyncUpload>
                                            </td>
                                            <td align="left" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;Select single or multiple files</td>
                                        </tr>
                                    </table>
                         

                               <%-- <asp:Label ID="lblUploadText" runat="server"></asp:Label>--%>


                                </td>
                            </tr>

                             <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                                 <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                      <asp:Label runat="server" ID="lbleu" Text="Exam UserName"></asp:Label>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="txtExamUserName" runat="server" Width="250" MaxLength="100" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" AutoCompleteType="Disabled">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>

                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_AddExam_Label_ExamPassword %></strong>:
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="txtExamPassword" runat="server" Width="250" MaxLength="100" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" AutoCompleteType="Disabled">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="upSpecialNeeds" runat="server">
                                        <ContentTemplate>
                                            <table cellpadding="2" cellspacing="0" width="100%">
                                                <tr class="gridviewAlternatestyle">
                                                    <td class="PopupLable" width="35%">
                                                        <strong>
                                                            <asp:Label ID="lblBufferTime" Text="<%$ Resources:AppControls,Provider_AddExam_Label_BufferTime %>"
                                                                runat="server"></asp:Label></strong>:
                                                    </td>
                                                    <td align="left" valign="top" width="65%">
                                                        <telerik:RadComboBox ID="ddlSpecialNeeds" runat="server" AppendDataBoundItems="True"
                                                            Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="50" OnSelectedIndexChanged="ddlSpecialNeeds_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="Add">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="No" Value="No" />
                                                                <telerik:RadComboBoxItem Text="Yes" Value="Yes" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel runat="server" ID="pnlInfo" Visible="false">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr align="left">
                                                                    <td style="border: 1px solid #4e75b3; padding: 10px;">After you confirm the exam details, follow the instructions below :
                                                <ol>
                                                    <li>Click on Student link on dashboard.</li>
                                                    <li>Select edit for student.</li>
                                                    <li>Enter details of extended time and/or special accommodation for the student.</li>
                                                </ol>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>

                                                <%if (isLockDownBrowserFeatured() == "True")
                                                  { %>
                                                <tr class="gridviewAlternatestyle">
                                                    <td class="PopupLable" width="35%">
                                                        <strong>
                                                            <asp:Label ID="Label6" Text="<%$ Resources:AppControls,Provider_AddExam_Label_LockDownBrowser %>"
                                                                runat="server"></asp:Label></strong>:
                                                    </td>
                                                    <td align="left" valign="top" width="65%">
                                                        <telerik:RadComboBox ID="ddlLockDownBrowser" runat="server" AppendDataBoundItems="True"
                                                            Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="50" AutoPostBack="true" ValidationGroup="Add">
                                                            <Items>

                                                                <telerik:RadComboBoxItem Text="No" Value="0" Selected="true" />
                                                                <telerik:RadComboBoxItem Text="Yes" Value="1" />


                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <%} %>
                                                <tr class="gridviewAlternatestyle" runat="server" id="trStudentUpload" visible="false">
                                                    <td class="PopupLable" width="35%">
                                                        <strong>
                                                            <asp:Label ID="lblStudentUpload" Text="<%$ Resources:AppControls,Provider_AddExam_Label_StudentUploadFile %>"
                                                                runat="server"></asp:Label></strong>:
                                                    </td>
                                                    <td align="left" valign="top" width="65%">
                                                        <telerik:RadComboBox ID="rcbStudentUpload" runat="server" AppendDataBoundItems="True"
                                                            Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="50" AutoPostBack="true" ValidationGroup="Add">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="Yes" Value="1" Selected="true" />
                                                                <telerik:RadComboBoxItem Text="No" Value="0" />

                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <%if (isExamLevelFee() == "True")
                                                  { %>
                                                <tr class="gridviewAlternatestyle">
                                                    <td class="PopupLable">
                                                        <strong>
                                                            <asp:Label ID="Label5" Text="Exam Fee Paid By"
                                                                runat="server"></asp:Label></strong>:
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadComboBox ID="ddlExamFeePaidBy" runat="server" Width="100" AppendDataBoundItems="true" ChangeTextOnKeyBoardNavigation="true"
                                                            Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" DropDownAutoWidth="Enabled">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Value="1" Text="University" Selected="true"  />
                                                                <telerik:RadComboBoxItem Value="2" Text="Student" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr class="gridviewAlternatestyle">
                                                    <td class="PopupLable">
                                                        <strong>
                                                            <asp:Label ID="Label7" Text="On-demand Fee Paid By"
                                                                runat="server"></asp:Label></strong>:
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadComboBox ID="ddlOnDemandFeePaidBy" runat="server" Width="100" AppendDataBoundItems="true" ChangeTextOnKeyBoardNavigation="true"
                                                            Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" DropDownAutoWidth="Enabled">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Value="1" Text="University"   />
                                                                <telerik:RadComboBoxItem Value="2" Text="Student" Selected="true" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <%} %>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>


                            <tr class="gridviewRowstyle">
                                <td colspan="2" align="center" style="background: #dcedfd;">
                                    <asp:Label ID="lblProctorStudent" runat="server" Text="Exam Rules" Font-Bold="true" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="padding-top: 0px; padding-bottom: 0px;">
                                    <asp:UpdatePanel ID="upStandard" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadGrid ID="gvStandard" runat="server"
                                                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                CellSpacing="0" GridLines="None">
                                                <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                    FilterItemStyle-HorizontalAlign="Center">
                                                    <NoRecordsTemplate>
                                                        No records to display.
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="<%$ Resources:AppControls,Provider_AddExam_Standard %>"
                                                            UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>

                           <tr class="gridviewRowstyle">

                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td width="15%">
                                                <strong>
                                                    <asp:Label ID="lblreusespecl" Text="<%$ Resources:AppControls,Admin_AddExam_Label_Reusespecialinstructions %>"
                                                        runat="server"></asp:Label>
                                                </strong>:
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:UpdatePanel ID="Updatepanel" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadComboBox ID="ddlreusespecialinstructions" runat="server" AppendDataBoundItems="True"
                                                            Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="50px" OnSelectedIndexChanged="ddlreusespecialinstructions_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="Add">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="No" Value="No" Selected="true" />
                                                                <telerik:RadComboBoxItem Text="Yes" Value="Yes" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                        <telerik:RadComboBox ID="rcbCourses" runat="server" Visible="false" EmptyMessage="Select Course" EnableScreenBoundaryDetection="false" Height="400" ZIndex="30" Filter="Contains" MarkFirstMatch="true"
                                                            Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="45%"  AutoPostBack="true" ValidationGroup="Add" OnSelectedIndexChanged="rcbCourses_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadComboBox ID="ddlExams" runat="server" Visible="false" EmptyMessage="Select Exam"
                                                            Skin="<%$ Resources:AppConfigurations,Skin_Current %>" Width="25%" OnSelectedIndexChanged="ddlExams_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="Add">
                                                        </telerik:RadComboBox>
                                                        <asp:Label ID="lblNoExam" runat="server" Text="There are no exams for this course." ForeColor="Red"  Visible="false"></asp:Label>
                                                        <asp:Label ID="lblNoExams" runat="server" Text="There are no additional rules and special instructions for this exam." ForeColor="Red"  Visible="false"></asp:Label>
                                                        <asp:Label ID="lblNoSpRules" runat="server" Text="There are no additional rules and special instructions for this exam." ForeColor="Red"  Visible="false"></asp:Label>
                                                    
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </td>
                                        </tr>
                                        </table>
                                    </td>
                               </tr>



                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                    <asp:UpdatePanel ID="upAllowed" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadGrid ID="gvAllowed" runat="server"
                                                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID">
                                                <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                    FilterItemStyle-HorizontalAlign="Center">
                                                    <NoRecordsTemplate>
                                                        No records to display.
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Additional Rules"
                                                            UniqueName="NotesDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="90%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblProctorHeader" runat="server" Text=""></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkProctor" runat="server" Checked='<%# Convert.ToBoolean(Eval("Status")) %>'  CausesValidation="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                       <table width="100%">
                                        <tr>
                                            <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <telerik:RadGrid ID="gvSpecial" runat="server" AllowMultiRowSelection="false"
                                                            AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                            CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID" OnEditCommand="gvSpecial_EditCommand" OnUpdateCommand="gvSpecial_UpdateCommand" OnCancelCommand="gvSpecial_CancelCommand" OnItemCommand="gvSpecial_ItemCommand">
                                                            <GroupingSettings CaseSensitive="false" />
                                                               <ClientSettings>
                                                                            <Selecting AllowRowSelect="true" />
                                                                        </ClientSettings>
                                                            <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                FilterItemStyle-HorizontalAlign="Center">
                                                                <NoRecordsTemplate>
                                                                </NoRecordsTemplate>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Special Instructions"
                                                                        UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                        <HeaderStyle Font-Bold="true" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridTemplateColumn>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblProctorHeader" runat="server" Text="Proctor"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ChkProctor" runat="server" Checked='<%# Convert.ToBoolean(Eval("Proctor")) %>' CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                        <HeaderStyle Width="10%" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblStudentHeader" runat="server" Text="Student"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ChkStudent" runat="server" Checked='<%# Convert.ToBoolean(Eval("Student")) %>'  CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                        <HeaderStyle Width="10%" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="EDIT" CommandArgument='<%# Eval("RuleID")%>' />&nbsp;&nbsp;
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/delete_s.gif" CommandName="DELETE" CommandArgument='<%# Eval("RuleID")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                        <HeaderStyle Width="10%" />
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <EditFormSettings EditFormType="Template">
                                                                    <FormTemplate>
                                                                        <table width="100%" cellpadding="5" cellspacing="5">
                                                                            <tr>
                                                                                <td align="right" style="width: 20%">
                                                                                    <asp:Label ID="lblDesc" Text="Special Instructions : " runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="left" style="width: 20%">
                                                                                    <telerik:RadTextBox ID="txtRuleDescription" runat="server" Skin="Web20" Text='<%# Eval("RuleDesc")%>' Width="250px">
                                                                                    </telerik:RadTextBox>
                                                                                </td>

                                                                                <td align="left" colspan="2">
                                                                                    <asp:ImageButton ID="ImgRuleUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                                        CommandName="Update" CommandArgument='<%# Eval("RuleID")%>' />&nbsp;&nbsp;&nbsp;
                                                                                <asp:ImageButton ID="ImgRuleCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                                    CommandName="Cancel" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                            </tr>
                                                                        </table>
                                                                    </FormTemplate>
                                                                </EditFormSettings>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="70%" valign="middle" align="center" style="border-bottom: 1px solid #4e75b3; border-left: 1px solid #4e75b3; padding-top: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<textarea id="taAdditionalRules" runat="server" rows="3" cols="60"></textarea>
                                                    </td>
                                                    <td width="20%" valign="top" style="border-bottom: 1px solid #4e75b3; border-left: 1px solid #4e75b3; padding: 10px;">Visible to:
                                                        <br />
                                                        <asp:RadioButton ID="chkStudent" runat="server" Text="Student" GroupName="test"  />
                                                        <br />
                                                        <asp:RadioButton ID="chkProctor" runat="server" Text="Proctor" GroupName="test" Checked="true" />
                                                        <br />
                                                        <asp:RadioButton ID="chkStudentAndProctor" runat="server" Text="Student and Proctor" GroupName="test" />
                                                    </td>
                                                    <td width="10%" align="center" style="border-bottom: 1px solid #4e75b3; border-right: 1px solid #4e75b3; border-left: 1px solid #4e75b3;">
                                                        <telerik:RadButton ID="rdRulesSave" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                            Text="Save" OnClick="rdRulesSave_Click"
                                                            AutoPostBack="true">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                           <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnImgMoveUp" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnImgMoveDown" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td width="30" align="center" valign="top">
                                                <div>
                                                    <asp:ImageButton ID="btnImgMoveUp" runat="server" ImageUrl="~/Images/MoveUp.png" ToolTip="Move Up" OnClick="btnImgMoveUp_Click" />
                                                </div>
                                                <div>
                                                    <asp:ImageButton ID="btnImgMoveDown" runat="server" ImageUrl="~/Images/MoveDown.png" ToolTip="Move Down" OnClick="btnImgMoveDown_Click" />
                                                </div>
                                                <div>
                                                    <asp:ImageButton ID="btnImgMoveDelete" runat="server" ImageUrl="~/Images/MoveDelete.png" ToolTip="Delete" OnClick="btnImgMoveDelete_Click" Visible="false" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="PopupButtons">
                                <td align="center" colspan="3">
                                    <telerik:RadButton ID="BtnSaveExam" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                        Text="<%$ Resources:AppControls,Provider_AddExam_Button_SaveExam %>" OnClick="BtnSaveExam_Click"
                                        AutoPostBack="true" CausesValidation="true" ValidationGroup="submit">
                                    </telerik:RadButton>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr id="trAddExamConfirm" runat="server">
                <td>
                    <div class="login_new1">
                        <table cellpadding="0" cellspacing="3" width="100%" border="0">
                            <tr class="gridviewRowstyle">
                                <td width="35%" class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmCourse" runat="server" Text="<%$ Resources:AppControls,Provider_AddExam_Label_CourseName %>"></asp:Label></strong>:
                                </td>
                                <td width="65%" align="left">
                                    <asp:Label ID="lblConfirmCourseValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmExam" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamName %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblConfirmExamValue" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamName %>"
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmSecurityLevel" Text="<%$ Resources:AppControls,Provider_AddExam_Label_SecurityLevel %>"
                                            runat="server"></asp:Label>
                                    </strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblConfirmSecurityLevelValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmExamDuration" Text="<%$ Resources:AppControls,Provider_AddExam_Label_DurationOfExam %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left" valign="bottom">
                                    <asp:Label ID="lblConfirmExamDurationValue" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmExamLink" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamLinkToAccess %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblConfirmExamLinkValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmStartDate" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamStartDate %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblConfirmStartDateValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="lblConfirmEndDate" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamEndDate %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblConfirmEndDateValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <asp:Label ID="lblConfirmUpload" runat="server" Text="<%$ Resources:AppControls,Provider_AddExam_Label_UploadFile %>"
                                        Font-Bold="true"></asp:Label>:
                                </td>
                                <td align="left">
                                 
                                      <telerik:RadGrid ID="gvUploadFiles" runat="server"
                AutoGenerateColumns="False" 
                CellSpacing="0" GridLines="None"  PageSize="5" Width="50%" >
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#ffffff" PageSize="5"
                    FilterItemStyle-HorizontalAlign="Center">
                    <NoRecordsTemplate>
                        No records to display.
                    </NoRecordsTemplate>
                    <Columns>

                      

                        <telerik:GridTemplateColumn HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="White" HeaderStyle-Width="0px"
                                                        HeaderStyle-HorizontalAlign="left" DataField="OriginalFileName" SortExpression="OriginalFileName"
                                                        UniqueName="OriginalFileName" FilterControlWidth="40px"  HeaderText="Uploaded files">
                                                        <ItemTemplate>
                                                          <asp:LinkButton ID="lnkOriginalFileName" runat="server"  Text='<%# Eval("OriginalFileName")%>' CommandArgument='<%# Bind("StoredFileName")%>' CommandName="uploadFile" Font-Underline="true" OnClick="lnlFile_Click"/>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>



                    </Columns>

                  

                </MasterTableView>
      

            </telerik:RadGrid>
                                           
                                     
                                  <%--  <asp:Label ID="lblConfirmUploadValue" runat="server" Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkUpload" runat="server" Font-Underline="true" ForeColor="Blue"
                                        Visible="false" OnClick="lnkUpload_Click"></asp:LinkButton>--%>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="Label8" Text="Exam UserName" runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblExamUserName" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <asp:Label ID="Label4" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamPassword %>"
                                            runat="server"></asp:Label></strong>:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblExamPassword" Text="<%$ Resources:AppControls,Provider_AddExam_Label_ExamPassword %>"
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table cellpadding="2" cellspacing="0" width="100%">
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable" width="35%">
                                                <strong>
                                                    <asp:Label ID="Label2" Text="<%$ Resources:AppControls,Provider_AddExam_Label_BufferTime %>"
                                                        runat="server"></asp:Label></strong>:
                                            </td>
                                            <td align="left" width="65%">
                                                <asp:Label ID="lblspecialneedsflag" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%if (isLockDownBrowserFeatured() == "True")
                                          { %>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>
                                                    <asp:Label ID="Label3" Text="<%$ Resources:AppControls,Provider_AddExam_Label_LockDownBrowser %>"
                                                        runat="server"></asp:Label></strong>:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblLockDownBrowser" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%} %>
                                        <tr class="gridviewAlternatestyle" runat="server" id="trStudentUploadConfirm" visible="false">
                                            <td class="PopupLable">
                                                <strong>
                                                    <asp:Label ID="lblStudentUploadFile" Text="<%$ Resources:AppControls,Provider_AddExam_Label_StudentUploadFile %>"
                                                        runat="server"></asp:Label></strong>:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblStudentUploadFileConfirm" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%if (isExamLevelFee() == "True")
                                          { %>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>
                                                    <asp:Label ID="Label12" Text="Exam Fee Paid By"
                                                        runat="server"></asp:Label></strong>:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblExamFeePaidByConfirm" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>
                                                    <asp:Label ID="Label13" Text="On-demand Fee Paid By"
                                                        runat="server"></asp:Label></strong>:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblondemandFeePaidByConfirm" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%} %>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Panel runat="server" ID="Panel1" Visible="false">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr align="left">
                                                            <td style="border: 1px solid #4e75b3; padding: 10px;">After you confirm the exam details, follow the instructions below :
                                                <ol>
                                                    <li>Click on Student link on dashboard.</li>
                                                    <li>Select edit for student.</li>
                                                    <li>Enter details of extended time and/or special accommodation for the student.</li>
                                                </ol>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                    <telerik:RadGrid ID="gvViewStandard" runat="server"
                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                        CellSpacing="0" GridLines="None">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                            FilterItemStyle-HorizontalAlign="Center">
                                            <NoRecordsTemplate>
                                                No records to display.
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="<%$ Resources:AppControls,Provider_AddExam_Standard %>"
                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                    <telerik:RadGrid ID="gvViewAdditional" runat="server"
                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                        CellSpacing="0" GridLines="None">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                            FilterItemStyle-HorizontalAlign="Center">
                                            <NoRecordsTemplate>
                                                No records to display.
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Additional Rules"
                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                    <telerik:RadGrid ID="gvViewSpecial" runat="server"
                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                        CellSpacing="0" GridLines="None">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                            FilterItemStyle-HorizontalAlign="Center">
                                            <NoRecordsTemplate>
                                                No records to display.
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Special Instructions"
                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                    <ItemStyle HorizontalAlign="Left" Width="80%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblProctorHeader" runat="server" Text="Proctor"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgProctor" runat="server" ImageUrl='<%# Eval("Proctor")%>' />&nbsp;&nbsp;
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    <HeaderStyle Width="10%" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblStudentHeader" runat="server" Text="Student"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgStudent" runat="server" ImageUrl='<%# Eval("Student")%>' />&nbsp;&nbsp;
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    <HeaderStyle Width="10%" />
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
    </form>
</body>
</html>
