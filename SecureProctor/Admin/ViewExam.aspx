<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewExam.aspx.cs" Inherits="SecureProctor.Admin.ViewExam" %>

<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>
<%@ Register TagPrefix="uc" TagName="uploadfiles" Src="~/GetExamUploadedFiles.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table cellpadding="2" width="100%">
            <tr>
                <td>
                    <div class="heading customfont1">
                        <%=Resources.AppControls.Admin_ViewExam_Label_ViewExam%>

                          <asp:Label ID="lblUpdatedFromApp" Text="[Updated From App]" runat="server"></asp:Label>
                        <strong>                          
                            :<asp:Label ID="lblUpdatedFromAppResult" runat="server"></asp:Label>
                         </strong>
                    </div>
                     
                                   
                </td>
               
                            <td class="PopupLable" align="left">
                              
                            </td>
                        
            </tr>
            <tr>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr class="gridviewRowstyle">

                            <td width="45%" class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblCourse" runat="server" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_CourseName %>"></asp:Label></strong>
                            </td>
                            <td width="55%" align="left">:
                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblExam" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamName %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblExamName" runat="server"></asp:Label>
                            </td>
                        </tr>


                        <tr class="gridviewRowstyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblSecurityLevel" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamSecurityLevel %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblExamSecurityLevel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblExamhrs" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_DurationOfExam %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left" valign="bottom">:
                                <asp:Label ID="lblHours" runat="server" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_HH %>"></asp:Label>&nbsp;
                            <asp:Label ID="lblHoursValue" runat="server"></asp:Label>
                                &nbsp;&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblMinutes" runat="server" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_MM %>"></asp:Label>&nbsp;
                             <asp:Label ID="lblMinutesValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr class="gridviewRowstyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblBufferTime" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_BufferTime %>"
                                        runat="server"></asp:Label></strong>:
                            </td>
                            <td align="left" valign="bottom">
                                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_MM %>"></asp:Label>&nbsp;
                            <asp:Label ID="lblBufferTimeValue" runat="server"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr class="gridviewAlternatestyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblAccessExam" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamLinkToAccess %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblExamLink" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="Label1" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamStartDate %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblExamStartDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">

                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="lblEndDate" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamEndDate %>"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblExamEndDate" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr class="gridviewAlternatestyle">

                            <td class="PopupLable">

                                <strong>
                                    <asp:Label ID="lblUpload" runat="server" Text="Uploaded files"
                                        Font-Bold="true"></asp:Label>

                                </strong>
                            </td>
                            <%--<td align="left"   >
                                <asp:LinkButton ID="lnkUploadFile" runat="server" OnClick="lnkUploadFile_Click"></asp:LinkButton>
                                :
                                <asp:Label ID="lblUploadValue" runat="server"></asp:Label>
                                
                                 

                            </td>--%>
                            <td>
                                <uc:uploadfiles ID="ucUploadFiles" runat="server" />
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable"><strong>Exam UserName</strong></td>
                            <td align="left">:<asp:Label ID="lblExamUserName" runat="server"></asp:Label></td>
                        </tr>

                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong>Exam Password</strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblExamPassword" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr class="gridviewRowstyle">
                            <td class="PopupLable" width="35%">
                                <strong><%= Resources.AppControls.Provider_AddExam_Label_BufferTime %></strong>
                            </td>
                            <td align="left" width="65%">:
                                <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%if (isLockDownBrowserFeatured() == "True")
                          { %>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddExam_Label_LockDownBrowser %></strong>
                            </td>
                            <td align="left">:
                                <asp:Label ID="lblLockdownBrowser" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%} %>
                        <%--<tr class="gridviewRowstyle">

                            <td colspan="3" style="padding-top: 5px; padding-bottom: 5px;">
                                <telerik:RadGrid ID="gvNotes" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CellSpacing="0"
                                    GridLines="None">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" FilterItemStyle-HorizontalAlign="Center">
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                        </ExpandCollapseColumn>
                                        <NoRecordsTemplate>
                                            No records to display.
                                        </NoRecordsTemplate>
                                        <Columns>

                                            <telerik:GridBoundColumn DataField="Text" HeaderText="<%$ Resources:AppControls,Admin_ViewExam_GridHeader_NotesForProdAndAud %>"
                                                SortExpression="Text" UniqueName="Text" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
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

                            <td colspan="3" style="padding-top: 5px; padding-bottom: 5px;">
                                <telerik:RadGrid ID="gvRules" runat="server"
                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                    CellSpacing="0" GridLines="None" AllowFilteringByColumn="false">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" FilterItemStyle-HorizontalAlign="Center">
                                        <Columns>

                                            <telerik:GridBoundColumn DataField="Text" HeaderText="<%$ Resources:AppControls,Admin_ViewExam_GridHeader_RulesForStudent %>"
                                                SortExpression="Text" UniqueName="Text" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                    </MasterTableView>
                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>--%>
                        <tr class="gridviewRowstyle" id="trStudentUpload" runat="server">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddExam_Label_StudentUploadFile %></strong>
                            </td>
                            <td align="left" valign="bottom">:
                                    <asp:Label ID="lblStudentUploadFile" runat="server"></asp:Label>
                            </td>
                        </tr>
                      <%--  <%if (isExamLevelFee() == "True")
                          { %>--%>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="Label12" Text="Exam Fee Paid By"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:<asp:Label ID="lblExamFeePaidByConfirm" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="Label13" Text="On-demand Fee Paid By"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:<asp:Label ID="lblondemandFeePaidByConfirm" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <%--<%} %>--%>
                         <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong>
                                    <asp:Label ID="Label2" Text="Exam attempts"
                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:<asp:Label ID="lblExamAttempts" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong>
                                     <asp:Label ID="lblreusespecl" Text="<%$ Resources:AppControls,Admin_AddExam_Label_Reusespecialinstructions %>"
                                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:<asp:Label ID="lblNoSpRules" runat="server"></asp:Label>
                            </td>
                        </tr>



                    </table>
                </div>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="100%">
                                <uc:rules ID="ucRules" runat="server" DisplayFrom="PROCTOR" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
