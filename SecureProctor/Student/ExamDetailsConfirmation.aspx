<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="ExamDetailsConfirmation.aspx.cs" Inherits="SecureProctor.Student.ExamDetailsConfirmation" %>
<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script type="text/javascript">
    </script>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/ImgExamdetailsHeader.png" alt="Examdetails" />
                    </td>
                    <%--<td width="1%" rowspan="2">
                    </td>
                    <td>
                        <img src="../Images/ImgHelp.png" alt="help" />
                    </td>--%>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new">
                            <table width="100%" cellpadding="3" cellspacing="4" style="font-family: Arial; font-size: 12px;">
                                <tr class="gridviewAlternatestyle">
                                    <td colspan="2" style="font-size: 14px; color: #fff" class="subHeadfont" align="center">
                                        <asp:Label ID="lblExamDetails" runat="server" Text="Student Exam Details"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle">
                                    <td align="left" width="50%">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Exam ID</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Student Name</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Course Name</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <%-- <tr class="gridviewRowstyle">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Exam Name</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr class="gridviewRowstyle">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Exam Date</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Exam Time </strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Status</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewAlternatestyle" style="display:none;">
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Uploaded file</strong>&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="lnlFile" runat="server" OnClick="lnlFile_Click" Font-Underline="true"></asp:LinkButton>
                                        <asp:Label ID="lblFile" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle" style="display:none;">
                                    <td align="left" valign="top">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Exam Tools</strong>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblTools" runat="server" Text="<%$ Resources:ResMessages,Student_ExamDetConfirmNoTools %>"></asp:Label>
                                        <asp:Image ID="imgCalc" runat="server" Height="50" ImageUrl="~/Images/ImgCalc.png" />
                                        &nbsp;&nbsp;
                                        <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                            Height="50" />
                                        <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="gridviewRowstyle">
                                    <td colspan="2">
                                        <%--<asp:GridView ID="gvStudentRules" runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="3" 
                                                    Width="100%">
                                                    <HeaderStyle CssClass="gridviewHeaderstyle" />
                                                    <RowStyle CssClass="gridviewRowstyle" />
                                                    <AlternatingRowStyle CssClass="gridviewAlternatestyle" />
                                                    <EmptyDataRowStyle CssClass="gridviewEmptyRowstyle" />
                                                    <EmptyDataTemplate>
                                                        <center>
                                                            <asp:Label ID="lblNoRows" runat="server" Text="No Rules Available." Font-Size="12px" /></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Rule ID">
                                                            <ItemTemplate>
                                                               
                                                                 <asp:Label ID="lblRuleID" runat="server" Text='<%# Eval("RuleID")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rule Description">
                                                            <ItemTemplate>
                                                               
                                                                 <asp:Label ID="lblRuleDescription" runat="server" Text='<%# Eval("RuleDesc")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        </asp:TemplateField>
                                                        </Columns>
                                                        </asp:GridView>--%>
                                          <uc:rules ID="ucRules" runat="server" DisplayFrom='STUDENT' />
                                        <%--<telerik:RadGrid ID="gvStudentRules" runat="server" OnNeedDataSource="gvStudentRules_NeedDataSource"
                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                            CellSpacing="0" GridLines="None">
                                            <GroupingSettings CaseSensitive="false" />
                                            <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                EnableNoRecordsTemplate="true" ShowHeadersWhenNoRecords="true">
                                                <NoRecordsTemplate>
                                                    No records to display.
                                                </NoRecordsTemplate>
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="RuleID" HeaderText="Rule ID" SortExpression="RuleID"
                                                        UniqueName="RuleID" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Rule Description" SortExpression="RuleDesc"
                                                        UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            </MasterTableView>
                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                        </telerik:RadGrid>--%>

                                    </td>
                                </tr>
                                <%--<tr style="background: #ccc; line-height: 25px;">
                                                                           <td width="25%">&nbsp</td>
                                                                            <td align="left">
                                                                                <strong>Student Flag</strong>&nbsp;:&nbsp;&nbsp;
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblFlag" runat="server"></asp:Label>
                                                                            </td>
                                                                          <td width="25%">&nbsp</td>
                                                                        </tr>--%>
                                <%-- <tr style="background: #f6f6f6; line-height: 25px;">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Open Books&nbsp;:&nbsp;&nbsp;
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblBook" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>--%>
                                <%--<tr>
                                                                            <td align="center" width="100%" colspan="4">
                                                                                <asp:GridView ID="gvComments" runat="server" Width="100%" Height="100%" 
                                                                                    AutoGenerateColumns="false" 
                                                                                    >
                                                                                    <HeaderStyle CssClass="gridviewHeaderstyle" />
                                                                                    <RowStyle CssClass="gridviewRowstyle" />
                                                                                    <AlternatingRowStyle CssClass="gridviewAlternatestyle" />
                                                                                    <EmptyDataRowStyle CssClass="gridviewEmptyRowstyle" />--%>
                                <%--   <EmptyDataTemplate>
                                            <center>
                                                <asp:Label ID="lblNoRows" runat="server" Text="No Row(s) to Display." Font-Size="12px" /></center>
                                        </EmptyDataTemplate>--%>
                                <%-- <Columns>
                                                                                        <asp:TemplateField HeaderText="Added By" SortExpression="AddedBy">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCommenterID" runat="server" Text='<%# Eval("AddedBy")%>' />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments")%>' />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="40%" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Added On" SortExpression="AddedOn">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAddedOn" runat="server" Text='<%# Eval("AddedOn")%>' />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>--%>
                            </table>
                        </div>
                    </td>
                    <td width="25%" rowspan="3" valign="top" class="help_text_i" style="display:none;">
                        <div class="help_text_i_inner">
                            <strong>How do I schedule for an exam ?</strong>
                            <ul>
                                <li>You can schedule at any timeslot that best suits you</li>
                                <li>You can schedule for an exam 48 hours before the exam</li>
                                <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                                <li>Select a preferred date (grayed dates mean they can't be selected)</li>
                                <li>Select the time that suits you best.</li>
                            </ul>
                            <strong>What happens after I schedule ?</strong>
                            <ul>
                                <li>You will get an email confirming your schedule</li>
                                <li>In the email, you will have instructions what to do before and during the exam</li>
                            </ul>
                            <strong>How do Reschedule/cancel ?</strong>
                            <ul>
                                <li>You can Reschedule at any time slot that best suits you</li>
                                <li>You can Reschedule for an exam 24 hours before the previous scheduled time slot</li>
                                <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
